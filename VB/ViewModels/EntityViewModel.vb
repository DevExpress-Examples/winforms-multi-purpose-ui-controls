Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.UITemplates.Collection.Messages
Imports DevExpress.UITemplates.Collection.Models
Imports DevExpress.UITemplates.Collection.Repositories

Namespace DevExpress.UITemplates.Collection.ViewModels

    Public MustInherit Class EntityViewModel(Of TKey As Structure, TEntity As Collection.Models.Entity(Of TKey))
        Inherits ReadOnlyEntityViewModel(Of TKey, TEntity)
        Protected ReadOnly Property Repository As Collection.Repositories.IRepository(Of TKey, TEntity)
            Get
                Return GetRequiredService(Of DevExpress.UITemplates.Collection.Repositories.IRepository(Of TKey, TEntity))()
            End Get
        End Property
        Public Sub Update()
            HasChanges = Entity IsNot Nothing AndAlso Repository.HasChanges(Entity)
            UpdateCommands()
        End Sub
        Public Function CanReset() As Boolean
            Return Entity IsNot Nothing AndAlso HasChanges
        End Function
        Public Sub Reset()
            Dim id = Entity.ID
            Entity = ReadOnlyRepository.Load(id)
            If ReferenceEquals(Entity, Entity) Then RaisePropertyChanged(Function(x) x.Entity)
            HasChanges = False
        End Sub
        Public Function CanSave() As Boolean
            Return Entity IsNot Nothing AndAlso HasChanges AndAlso Repository.CanSave(Entity)
        End Function
        Public Sub Save()
            Dim isNewVar = IsNew
            Dim id As TKey = Repository.Save(Entity)
            Dim msg = If(isNewVar, Collection.Messages.ReloadRequired(Of TKey, TEntity).FromNew(id), Collection.Messages.ReloadRequired(Of TKey, TEntity).FromID(id))
            Messenger.Default.Send(msg)
            HasChanges = False
        End Sub
        Public Function CanDelete() As Boolean
            Return Entity IsNot Nothing AndAlso Not IsNew
        End Function
        Public Sub Delete()
            If MessageBoxService.ShowMessage(GetDeleteConfirmation(Entity), Title, MessageButton.YesNo, MessageIcon.Question) <> MessageResult.Yes Then Return
            If Repository.Delete(Entity.ID) Then
                Messenger.Default.Send(Collection.Messages.ReloadRequired(Of TKey, TEntity).All(NewEntityID))
                GoBackOrClose()
            End If
        End Sub
        Protected ReadOnly Property MessageBoxService As IMessageBoxService
            Get
                Return GetService(Of IMessageBoxService)()
            End Get
        End Property
        Protected Overridable Function GetDeleteConfirmation(entity As TEntity) As String
            Dim type = GetType(TEntity).Name.ToLowerInvariant()
            Return $"Do you really want to delete {GetName(entity)} {type}?"
        End Function
        Protected MustOverride Function GetName(entity As TEntity) As String
        Protected Overrides Sub UpdateCommands()
            MyBase.UpdateCommands()
            RaiseCanExecuteChanged(Sub(x) x.Save())
            RaiseCanExecuteChanged(Sub(x) x.Reset())
            RaiseCanExecuteChanged(Sub(x) x.Delete())
        End Sub
    End Class
End Namespace
