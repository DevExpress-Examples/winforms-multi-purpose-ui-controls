Imports System.Collections.Generic
Imports DevExpress.UITemplates.Collection.Models

Namespace DevExpress.UITemplates.Collection.Repositories

    Public Interface IReadOnlyRepository(Of TKey As Structure, Out TEntity)
        ' Items Loading
        ReadOnly Property NewEntityID As TKey
        Function Load() As IReadOnlyCollection(Of TEntity)
        Function Load(id As TKey) As TEntity
        ' Local Entities
        ReadOnly Property Local As IReadOnlyCollection(Of TEntity)
        Function ReloadLocal(id As TKey) As TEntity
    End Interface
End Namespace
