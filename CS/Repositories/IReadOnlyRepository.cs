namespace DevExpress.UITemplates.Collection.Repositories {
    using System;
    using System.Collections.Generic;
    using DevExpress.UITemplates.Collection.Models;

    public interface IReadOnlyRepository<TKey, out TEntity>
        where TKey : struct
        where TEntity : Entity<TKey> {
        // Items Loading
        TKey NewEntityID { get; }
        IReadOnlyCollection<TEntity> Load();
        TEntity Load(TKey id);
        // Local Entities
        IReadOnlyCollection<TEntity> Local { get; }
        TEntity ReloadLocal(TKey id);
    }
}
