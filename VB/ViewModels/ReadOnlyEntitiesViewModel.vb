Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.UITemplates.Collection.Messages
Imports DevExpress.UITemplates.Collection.Models
Imports DevExpress.UITemplates.Collection.Repositories

Namespace DevExpress.UITemplates.Collection.ViewModels

    Public MustInherit Class ReadOnlyEntitiesViewModel(Of TKey As Structure, TEntity As Collection.Models.Entity(Of TKey))
        Public Sub New()
            Call Messenger.Default.Register(Of Collection.Messages.ReloadRequired(Of TKey, TEntity))(Me, New Action(Of Global.DevExpress.UITemplates.Collection.Messages.ReloadRequired(Of TKey, TEntity))(AddressOf Me.OnReloadRequired))
        End Sub
        Public Overridable Sub OnDestroy()
            Call Messenger.Default.Unregister(Of Collection.Messages.ReloadRequired(Of TKey, TEntity))(Me, New Action(Of Global.DevExpress.UITemplates.Collection.Messages.ReloadRequired(Of TKey, TEntity))(AddressOf Me.OnReloadRequired))
        End Sub
        Protected ReadOnly Property ReadOnlyRepository As Collection.Repositories.IReadOnlyRepository(Of TKey, TEntity)
            Get
                Return GetRequiredService(Of DevExpress.UITemplates.Collection.Repositories.IReadOnlyRepository(Of TKey, TEntity))()
            End Get
        End Property
        Protected ReadOnly Property NewEntityID As TKey
            Get
                Return ReadOnlyRepository.NewEntityID
            End Get
        End Property
        Private Sub OnReloadRequired(message As Collection.Messages.ReloadRequired(Of TKey, TEntity))
            If message.Equals(ReloadRequired(Of TKey, TEntity).All(NewEntityID)) OrElse message.IsNew Then
                ReloadEntities()
                If message.IsNew Then
                    SelectedEntity = ReadOnlyRepository.Local.FirstOrDefault(
                        Function(x) EqualityComparer(Of TKey).Default.Equals(x.ID, message.Id))
                End If
            Else
                If localSelectionChange > 0 Then Return
                Dim selectedID As TKey? = SelectedEntity?.ID
                If selectedID.HasValue AndAlso EqualityComparer(Of TKey).Default.Equals(message.Id, selectedID.Value) Then
                    SelectedEntity = ReadOnlyRepository.ReloadLocal(message.Id)
                Else
                    SelectedEntity = Nothing
                End If
            End If
        End Sub
        Public ReadOnly Property Entities As IReadOnlyCollection(Of TEntity)
            Get
                Return ReadOnlyRepository.Local
            End Get
        End Property
        Protected Sub ReloadEntities()
            Dim selectedID As TKey? = SelectedEntity?.ID
            ReloadEntitiesCore()
            If selectedID.HasValue Then
                SelectedEntity = ReadOnlyRepository.Local.FirstOrDefault(Function(x) EqualityComparer(Of TKey).Default.Equals(x.ID, selectedID.Value))
            Else
                SelectedEntity = Nothing
            End If
        End Sub
        Protected Overridable Sub ReloadEntitiesCore()
            ReadOnlyRepository.Load()
            RaisePropertyChanged(Function(x) x.Entities)
            OnEntitiesChanged()
        End Sub
        Public Overridable Property SelectedEntity As TEntity
        Protected Overridable Sub OnEntitiesChanged()
            SelectedEntity = Entities.FirstOrDefault()
        End Sub
        Private localSelectionChange As Integer = 0
        Protected Overridable Sub OnSelectedEntityChanged()
            localSelectionChange += 1
            Try
                If SelectedEntity IsNot Nothing Then Messenger.Default.Send(Collection.Messages.ReloadRequired(Of TKey, TEntity).FromID(SelectedEntity.ID))
            Finally
                localSelectionChange -= 1
            End Try
            UpdateCommands()
        End Sub
        Protected Overridable Sub UpdateCommands()
            ' do update commands here 
        End Sub
    End Class
End Namespace
