namespace DevExpress.UITemplates.Collection.Repositories {
    using DevExpress.UITemplates.Collection.Models;

    public interface IRepository<TKey, TEntity>
        : IReadOnlyRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : Entity<TKey> {
        bool HasChanges(TEntity entity);
        // Update operation
        bool CanSave(TEntity entity);
        TKey Save(TEntity entity);
        // Delete operation
        bool Delete(TKey id);
    }
}
