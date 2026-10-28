Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports DevExpress.UITemplates.Collection.Models

Namespace DevExpress.UITemplates.Collection.Repositories

    Public MustInherit Class InMemoryRepository(Of TKey As Structure, TEntity As Collection.Models.Entity(Of TKey))
        Implements IRepository(Of TKey, TEntity)
#Region "Storage"
        Private Shared storage As Dictionary(Of TKey, TEntity)
        Private Shared Empty As TEntity
        Protected Sub New()
            Empty = If(Empty, CreateEntity())
            Empty.ID = NewEntityID
            If storage Is Nothing Then
                storage = New Dictionary(Of TKey, TEntity)() From {
                    {NewEntityID, Empty}
                }
                OnInitializeStorage(storage)
            End If
        End Sub
        Protected Overridable Sub OnInitializeStorage(storage As Dictionary(Of TKey, TEntity))
            ' do initialize records 
        End Sub
        Protected ReadOnly Property StorageCount As Integer
            Get
                Return storage.Count
            End Get
        End Property
        Protected ReadOnly Property StorageKeys As IEnumerable(Of TKey)
            Get
                Return storage.Keys
            End Get
        End Property
        Public MustOverride ReadOnly Property NewEntityID As TKey Implements IReadOnlyRepository(Of TKey, TEntity).NewEntityID
        Protected MustOverride Function GenerateNextID() As TKey
#End Region
        Public Function Load(id As TKey) As TEntity Implements IReadOnlyRepository(Of TKey, TEntity).Load
            Dim storageEntity As TEntity
            If Not storage.TryGetValue(id, storageEntity) Then Return Nothing
            Return Assign(CreateEntity(), storageEntity)
        End Function
        Private ReadOnly localEntities As BindingList(Of TEntity) = New BindingList(Of TEntity)()
        Public ReadOnly Property Local As IReadOnlyCollection(Of TEntity) Implements IReadOnlyRepository(Of TKey, TEntity).Local
            Get
                Return localEntities
            End Get
        End Property
        Public Function Load() As IReadOnlyCollection(Of TEntity) Implements IReadOnlyRepository(Of TKey, TEntity).Load
            localEntities.Clear()
            For Each storageEntry In storage
                If EqualityComparer(Of TKey).Default.Equals(storageEntry.Key, NewEntityID) Then Continue For
                LocalAdd(storageEntry.Key, Assign(CreateEntity(), storageEntry.Value))
            Next
            Return localEntities
        End Function
        Private Shared ReadOnly keyComparer As EqualityComparer(Of TKey) = EqualityComparer(Of TKey).Default
        Private Function FindLocalIndex(id As TKey) As Integer
            For i As Integer = 0 To localEntities.Count - 1
                If keyComparer.Equals(localEntities(i).ID, id) Then
                    Return i
                End If
            Next

            Return -1
        End Function
        Public Function ReloadLocal(id As TKey) As TEntity Implements IReadOnlyRepository(Of TKey, TEntity).ReloadLocal
            Dim storageEntity As TEntity
            If storage.TryGetValue(id, storageEntity) Then
                Dim localEntity As TEntity = Nothing
                Dim localIndex = FindLocalIndex(id)
                Try
                    If localIndex >= 0 Then localEntity = localEntities(localIndex)
                    If localEntity IsNot Nothing Then Return Assign(localEntity, storageEntity)
                Finally
                    If localEntity IsNot Nothing Then localEntities.ResetItem(localIndex)
                End Try
            End If
            Return Nothing
        End Function
        Public Function HasChanges(entity As TEntity) As Boolean Implements IRepository(Of TKey, TEntity).HasChanges
            Dim storageEntity As TEntity
            If Not storage.TryGetValue(entity.ID, storageEntity) Then Return False
            Return Not Equals(storageEntity, entity)
        End Function
        Public Function CanSave(entity As TEntity) As Boolean Implements IRepository(Of TKey, TEntity).CanSave
            Dim validationResults = New List(Of ValidationResult)()
            If Not Validator.TryValidateObject(entity, New ValidationContext(entity), validationResults) Then Return False
            Return validationResults.Count = 0
        End Function
        Public Function Save(entity As TEntity) As TKey Implements IRepository(Of TKey, TEntity).Save
            Dim storageEntity As TEntity
            If EqualityComparer(Of TKey).Default.Equals(entity.ID, NewEntityID) OrElse Not storage.TryGetValue(entity.ID, storageEntity) Then
                Dim newItemID As TKey = GenerateNextID()
                LocalAdd(newItemID, entity)
                Dim createdEntity As TEntity = CreateEntity()
                Assign(createdEntity, entity)
                storage.Add(newItemID, createdEntity)
            Else
                Assign(storageEntity, entity)
            End If
            Return entity.ID
        End Function
        Public Function Delete(id As TKey) As Boolean Implements IRepository(Of TKey, TEntity).Delete
            If Not storage.Remove(id) Then Return False
            Dim index As Integer = FindLocalIndex(id)
            If index >= 0 Then localEntities.RemoveAt(index)
            Return True
        End Function
        Private Sub LocalAdd(id As TKey, entity As TEntity)
            entity.ID = id
            localEntities.Add(entity)
        End Sub
        Public Function IsEmpty(entity As TEntity) As Boolean
            Return Equals(entity, Empty)
        End Function
        Public Sub Clear(entity As TEntity)
            Dim id As TKey = entity.ID
            Assign(entity, Empty)
            entity.ID = id
        End Sub
        Protected MustOverride Function CreateEntity() As TEntity
        Protected MustOverride Function Assign(target As TEntity, source As TEntity) As TEntity
        Protected MustOverride Function Equals(target As TEntity, source As TEntity) As Boolean
    End Class
End Namespace
