Imports DevExpress.UITemplates.Collection.Models

Namespace DevExpress.UITemplates.Collection.Repositories

    Public Interface IRepository(Of TKey As Structure, TEntity As Collection.Models.Entity(Of TKey))
        Inherits IReadOnlyRepository(Of TKey, TEntity)
        Function HasChanges(entity As TEntity) As Boolean
        ' Update operation
        Function CanSave(entity As TEntity) As Boolean
        Function Save(entity As TEntity) As TKey
        ' Delete operation
        Function Delete(id As TKey) As Boolean
    End Interface
End Namespace
