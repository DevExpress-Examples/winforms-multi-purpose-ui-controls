namespace DevExpress.UITemplates.Collection.ViewModels {
    using DevExpress.Mvvm;
    using DevExpress.Mvvm.POCO;
    using DevExpress.UITemplates.Collection.Models;
    using DevExpress.UITemplates.Collection.Repositories;

    public abstract class EntitiesViewModel<TKey, TEntity> : ReadOnlyEntitiesViewModel<TKey, TEntity>
        where TKey : struct
        where TEntity : Entity<TKey> {
        protected IRepository<TKey, TEntity> Repository {
            get { return this.GetRequiredService<IRepository<TKey, TEntity>>(); }
        }
        public string Title {
            get;
            protected set;
        }
        public virtual bool CanDelete() {
            return (SelectedEntity != null);
        }
        public void Delete() {
            var entity = SelectedEntity;
            if(MessageBoxService.ShowMessage(GetDeleteConfirmation(entity), Title,
                MessageButton.YesNo, MessageIcon.Question) != MessageResult.Yes) {
                return;
            }
            Repository.Delete(SelectedEntity.ID);
        }
        public bool CanEdit() {
            return (SelectedEntity != null);
        }
        public void Edit() {
            NavigationService.Navigate(GetDetailViewType(), SelectedEntity.ID, this);
        }
        public void EditNew() {
            NavigationService.Navigate(GetDetailViewType(), NewEntityID, this);
        }
        protected INavigationService NavigationService {
            get { return this.GetService<INavigationService>(); }
        }
        protected IMessageBoxService MessageBoxService {
            get { return this.GetService<IMessageBoxService>(); }
        }
        protected virtual string GetDeleteConfirmation(TEntity entity) {
            var type = typeof(TEntity).Name.ToLowerInvariant();
            return $"Do you really want to delete {GetName(entity)} {type}?";
        }
        protected virtual string GetDetailViewType() {
            return typeof(TEntity).Name + "View";
        }
        protected abstract string GetName(TEntity entity);
        protected override void UpdateCommands() {
            base.UpdateCommands();
            this.RaiseCanExecuteChanged(x => x.Edit());
            this.RaiseCanExecuteChanged(x => x.Delete());
        }
    }
}