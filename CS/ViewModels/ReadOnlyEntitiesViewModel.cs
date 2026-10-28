namespace DevExpress.UITemplates.Collection.ViewModels {
    using System.Collections.Generic;
    using System.Linq;
    using DevExpress.Mvvm;
    using DevExpress.Mvvm.POCO;
    using DevExpress.UITemplates.Collection.Messages;
    using DevExpress.UITemplates.Collection.Models;
    using DevExpress.UITemplates.Collection.Repositories;

    public abstract class ReadOnlyEntitiesViewModel<TKey, TEntity>
        where TKey : struct
        where TEntity : Entity<TKey> {
        public ReadOnlyEntitiesViewModel() {
            Messenger.Default.Register<ReloadRequired<TKey, TEntity>>(this, OnReloadRequired);
        }
        public virtual void OnDestroy() {
            Messenger.Default.Unregister<ReloadRequired<TKey, TEntity>>(this, OnReloadRequired);
        }
        protected IReadOnlyRepository<TKey, TEntity> ReadOnlyRepository {
            get { return this.GetRequiredService<IReadOnlyRepository<TKey, TEntity>>(); }
        }
        protected TKey NewEntityID {
            get { return ReadOnlyRepository.NewEntityID; }
        }
        void OnReloadRequired(ReloadRequired<TKey, TEntity> message) {
            if(message.Equals(ReloadRequired<TKey, TEntity>.All(NewEntityID)) || message.IsNew) {
                ReloadEntities();
                if(message.IsNew)
                    SelectedEntity = ReadOnlyRepository.Local.FirstOrDefault(x => EqualityComparer<TKey>.Default.Equals(x.ID, message.Id));
            }
            else {
                if(localSelectionChange > 0)
                    return;
                TKey? selectedID = SelectedEntity?.ID;
                if(selectedID.HasValue && EqualityComparer<TKey>.Default.Equals(message.Id, selectedID.Value))
                    SelectedEntity = ReadOnlyRepository.ReloadLocal(message.Id);
                else SelectedEntity = null;
            }
        }
        public IReadOnlyCollection<TEntity> Entities {
            get { return ReadOnlyRepository.Local; }
        }
        protected void ReloadEntities() {
            TKey? selectedID = SelectedEntity?.ID;
            ReloadEntitiesCore();
            if(selectedID.HasValue)
                SelectedEntity = ReadOnlyRepository.Local.FirstOrDefault(x => EqualityComparer<TKey>.Default.Equals(x.ID, selectedID.Value));
            else SelectedEntity = null;
        }
        protected virtual void ReloadEntitiesCore() {
            ReadOnlyRepository.Load();
            this.RaisePropertyChanged(x => x.Entities);
            OnEntitiesChanged();
        }
        public virtual TEntity SelectedEntity {
            get;
            set;
        }
        protected virtual void OnEntitiesChanged() {
            SelectedEntity = Entities.FirstOrDefault();
        }
        int localSelectionChange = 0;
        protected virtual void OnSelectedEntityChanged() {
            localSelectionChange++;
            try {
                if(SelectedEntity != null)
                    Messenger.Default.Send(ReloadRequired<TKey, TEntity>.FromID(SelectedEntity.ID));
            }
            finally { localSelectionChange--; }
            UpdateCommands();
        }
        protected virtual void UpdateCommands() {
            /* do update commands here */
        }
    }
}