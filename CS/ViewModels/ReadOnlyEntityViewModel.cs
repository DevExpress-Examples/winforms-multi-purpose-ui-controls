namespace DevExpress.UITemplates.Collection.ViewModels {
    using System.Collections.Generic;
    using DevExpress.Mvvm;
    using DevExpress.Mvvm.POCO;
    using DevExpress.UITemplates.Collection.Messages;
    using DevExpress.UITemplates.Collection.Models;
    using DevExpress.UITemplates.Collection.Repositories;

    public abstract class ReadOnlyEntityViewModel<TKey, TEntity> : ISupportParameter
        where TKey : struct
        where TEntity : Entity<TKey> {
        public ReadOnlyEntityViewModel() {
            Messenger.Default.Register<ReloadRequired<TKey, TEntity>>(this, OnReloadRequired);
        }
        public virtual void OnDestroy() {
            Messenger.Default.Unregister<ReloadRequired<TKey, TEntity>>(this, OnReloadRequired);
        }
        object ISupportParameter.Parameter {
            get { return Entity; }
            set {
                if(value is TKey)
                    Load((TKey)value);
                else 
                    Entity = null;
            }
        }
        protected void LoadNew() {
            Load(NewEntityID);
        }
        protected void Load(TKey id) {
            OnReloadEntity(id);
        }
        void OnReloadRequired(ReloadRequired<TKey, TEntity> message) {
            OnReloadEntity(message.Id);
        }
        public virtual TEntity Entity {
            get;
            protected set;
        }
        protected IReadOnlyRepository<TKey, TEntity> ReadOnlyRepository {
            get { return this.GetRequiredService<IReadOnlyRepository<TKey, TEntity>>(); }
        }
        protected TKey NewEntityID {
            get { return ReadOnlyRepository.NewEntityID; }
        }
        public virtual bool HasChanges {
            get;
            protected set;
        }
        protected bool IsNew {
            get { return (Entity != null) && EqualityComparer<TKey>.Default.Equals(Entity.ID, NewEntityID); }
        }
        public virtual string Title {
            get {
                if(Entity == null)
                    return string.Empty;
                var suffix = (HasChanges ? "*" : string.Empty);
                var entityName = typeof(TEntity).Name;
                if(IsNew)
                    return "New " + entityName.ToLowerInvariant() + suffix;
                return entityName + " #" + Entity.ID.ToString() + suffix;
            }
        }
        protected virtual void OnReloadEntity(TKey id) {
            Entity = ReadOnlyRepository.Load(id);
        }
        protected void OnEntityChanged() {
            HasChanges = false;
            this.RaisePropertyChanged(x => x.Title);
            UpdateCommands();
        }
        protected void OnHasChangesChanged() {
            this.RaisePropertyChanged(x => x.Title);
            UpdateCommands();
        }
        protected virtual void UpdateCommands() { 
            /* do update commands here */
        }
        protected INavigationService NavigationService {
            get { return this.GetService<INavigationService>(); }
        }
        protected IDocumentManagerService DocumentManagerService {
            get { return this.GetService<IDocumentManagerService>(); }
        }
        public void GoBackOrClose() {
            IDocument currentDocument = null;
            if(NavigationService != null) {
                currentDocument = NavigationService.Current as IDocument;
                NavigationService.GoBack();
            }
            if(DocumentManagerService != null)
                currentDocument = DocumentManagerService.ActiveDocument;
            if(currentDocument != null)
                currentDocument.Close(true);
        }
    }
}
