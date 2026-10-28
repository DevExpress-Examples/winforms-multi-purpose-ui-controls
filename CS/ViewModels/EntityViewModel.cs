namespace DevExpress.UITemplates.Collection.ViewModels {
    using DevExpress.Mvvm;
    using DevExpress.Mvvm.POCO;
    using DevExpress.UITemplates.Collection.Messages;
    using DevExpress.UITemplates.Collection.Models;
    using DevExpress.UITemplates.Collection.Repositories;

    public abstract class EntityViewModel<TKey, TEntity> : ReadOnlyEntityViewModel<TKey,TEntity>
        where TKey : struct
        where TEntity : Entity<TKey> {
        protected IRepository<TKey, TEntity> Repository {
            get { return this.GetRequiredService<IRepository<TKey, TEntity>>(); }
        }
        public void Update() {
            HasChanges = (Entity != null) && Repository.HasChanges(Entity);
            UpdateCommands();
        }
        public bool CanReset() {
            return (Entity != null) && HasChanges;
        }
        public void Reset() {
            TEntity entity = Entity;
            Entity = ReadOnlyRepository.Load(Entity.ID);
            if(object.ReferenceEquals(entity, Entity))
                this.RaisePropertyChanged(x => x.Entity);
            HasChanges = false;
        }
        public bool CanSave() {
            return (Entity != null) && HasChanges && Repository.CanSave(Entity);
        }
        public void Save() {
            bool isNew = IsNew;
            TKey id = Repository.Save(Entity);
            var msg = isNew ? ReloadRequired<TKey, TEntity>.FromNew(id) : ReloadRequired<TKey, TEntity>.FromID(id);
            Messenger.Default.Send(msg);
            HasChanges = false;
        }
        public bool CanDelete() {
            return (Entity != null) && !IsNew;
        }
        public void Delete() {
            if(MessageBoxService.ShowMessage(GetDeleteConfirmation(Entity), Title,
                MessageButton.YesNo, MessageIcon.Question) != MessageResult.Yes)
                return;
            if(Repository.Delete(Entity.ID)) {
                Messenger.Default.Send(ReloadRequired<TKey, TEntity>.All(NewEntityID));
                GoBackOrClose();
            }
        }
        protected IMessageBoxService MessageBoxService {
            get { return this.GetService<IMessageBoxService>(); }
        }
        protected virtual string GetDeleteConfirmation(TEntity entity) {
            var type = typeof(TEntity).Name.ToLowerInvariant();
            return $"Do you really want to delete {GetName(entity)} {type}?";
        }
        protected abstract string GetName(TEntity entity);
        protected override void UpdateCommands() {
            base.UpdateCommands();
            this.RaiseCanExecuteChanged(x => x.Save());
            this.RaiseCanExecuteChanged(x => x.Reset());
            this.RaiseCanExecuteChanged(x => x.Delete());
        }
    }
}
