namespace DevExpress.UITemplates.Collection.Repositories {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using DevExpress.UITemplates.Collection.Models;

    public abstract class InMemoryRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : Entity<TKey> {
        #region Storage
        static Dictionary<TKey, TEntity> storage;
        static TEntity Empty;
        protected InMemoryRepository() {
            Empty = Empty ?? CreateEntity();
            Empty.ID = NewEntityID;
            if(storage == null) {
                storage = new Dictionary<TKey, TEntity>() {
                    { NewEntityID, Empty },
                };
                OnInitializeStorage(storage);
            }
        }
        protected virtual void OnInitializeStorage(Dictionary<TKey, TEntity> storage) {
            /* do initialize records */
        }
        protected int StorageCount {
            get { return storage.Count; }
        }
        protected IEnumerable<TKey> StorageKeys {
            get { return storage.Keys; }
        }
        public abstract TKey NewEntityID {
            get;
        }
        protected abstract TKey GenerateNextID();
        #endregion
        public TEntity Load(TKey id) {
            TEntity storageEntity;
            if(!storage.TryGetValue(id, out storageEntity))
                return null;
            return Assign(CreateEntity(), storageEntity);
        }
        readonly BindingList<TEntity> localEntities = new BindingList<TEntity>();
        public IReadOnlyCollection<TEntity> Local {
            get { return localEntities; }
        }
        public IReadOnlyCollection<TEntity> Load() {
            localEntities.Clear();
            foreach(var storageEntry in storage) {
                if(EqualityComparer<TKey>.Default.Equals(storageEntry.Key, NewEntityID))
                    continue;
                LocalAdd(storageEntry.Key, Assign(CreateEntity(), storageEntry.Value));
            }
            return localEntities;
        }
        static readonly EqualityComparer<TKey> keyComparer = EqualityComparer<TKey>.Default;
        int FindLocalIndex(TKey id) {
            for(int i = 0; i < localEntities.Count; i++) {
                if(keyComparer.Equals(localEntities[i].ID, id))
                    return i;
            }
            return -1;
        }
        public TEntity ReloadLocal(TKey id) {
            TEntity storageEntity;
            if(storage.TryGetValue(id, out storageEntity)) {
                TEntity localEntity = null;
                int localIndex = FindLocalIndex(id);
                try {
                    if(localIndex >= 0)
                        localEntity = localEntities[localIndex];
                    if(localEntity != null)
                        return Assign(localEntity, storageEntity);
                }
                finally {
                    if(localEntity != null)
                        localEntities.ResetItem(localIndex);
                }
            }
            return null;
        }
        public bool HasChanges(TEntity entity) {
            TEntity storageEntity;
            if(!storage.TryGetValue(entity.ID, out storageEntity))
                return false;
            return !Equals(storageEntity, entity);
        }
        public bool CanSave(TEntity entity) {
            var validationResults = new List<ValidationResult>();
            if(!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
                return false;
            return validationResults.Count == 0;
        }
        public TKey Save(TEntity entity) {
            TEntity storageEntity;
            if(EqualityComparer<TKey>.Default.Equals(entity.ID, NewEntityID) ||
                !storage.TryGetValue(entity.ID, out storageEntity)) {
                TKey newItemID = GenerateNextID();
                LocalAdd(newItemID, entity);
                TEntity createdEntity = CreateEntity();
                Assign(createdEntity, entity);
                storage.Add(newItemID, createdEntity);
            }
            else Assign(storageEntity, entity);
            return entity.ID;
        }
        public bool Delete(TKey id) {
            if(!storage.Remove(id))
                return false;
            int index = FindLocalIndex(id);
            if(index >= 0)
                localEntities.RemoveAt(index);
            return true;
        }
        void LocalAdd(TKey id, TEntity entity) {
            entity.ID = id;
            localEntities.Add(entity);
        }
        public bool IsEmpty(TEntity entity) {
            return Equals(entity, Empty);
        }
        public void Clear(TEntity entity) {
            TKey id = entity.ID;
            Assign(entity, Empty);
            entity.ID = id;
        }
        protected abstract TEntity CreateEntity();
        protected abstract TEntity Assign(TEntity target, TEntity source);
        protected abstract bool Equals(TEntity target, TEntity source);
    }
}