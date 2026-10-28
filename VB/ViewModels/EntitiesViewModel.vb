Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.UITemplates.Collection.Models
Imports DevExpress.UITemplates.Collection.Repositories

Namespace DevExpress.UITemplates.Collection.ViewModels

    Public MustInherit Class EntitiesViewModel(Of TKey As Structure, TEntity As Collection.Models.Entity(Of TKey))
        Inherits ReadOnlyEntitiesViewModel(Of TKey, TEntity)
        Private _Title As String
        Protected ReadOnly Property Repository As Collection.Repositories.IRepository(Of TKey, TEntity)
            Get
                Return GetRequiredService(Of DevExpress.UITemplates.Collection.Repositories.IRepository(Of TKey, TEntity))()
            End Get
        End Property

        Public Property Title As String
            Get
                Return _Title
            End Get
            Protected Set(value As String)
                _Title = value
            End Set
        End Property
        Public Overridable Function CanDelete() As Boolean
            Return SelectedEntity IsNot Nothing
        End Function
        Public Sub Delete()
            Dim entity = SelectedEntity
            If MessageBoxService.ShowMessage(GetDeleteConfirmation(entity), Title, MessageButton.YesNo, MessageIcon.Question) <> MessageResult.Yes Then
                Return
            End If
            Repository.Delete(SelectedEntity.ID)
        End Sub
        Public Function CanEdit() As Boolean
            Return SelectedEntity IsNot Nothing
        End Function
        Public Sub Edit()
            NavigationService.Navigate(GetDetailViewType(), SelectedEntity.ID, Me)
        End Sub
        Public Sub EditNew()
            NavigationService.Navigate(GetDetailViewType(), NewEntityID, Me)
        End Sub
        Protected ReadOnly Property NavigationService As INavigationService
            Get
                Return GetService(Of INavigationService)()
            End Get
        End Property
        Protected ReadOnly Property MessageBoxService As IMessageBoxService
            Get
                Return GetService(Of IMessageBoxService)()
            End Get
        End Property
        Protected Overridable Function GetDeleteConfirmation(entity As TEntity) As String
            Dim type = GetType(TEntity).Name.ToLowerInvariant()
            Return $"Do you really want to delete {GetName(entity)} {type}?"
        End Function
        Protected Overridable Function GetDetailViewType() As String
            Return GetType(TEntity).Name & "View"
        End Function
        Protected MustOverride Function GetName(entity As TEntity) As String
        Protected Overrides Sub UpdateCommands()
            MyBase.UpdateCommands()
            RaiseCanExecuteChanged(Sub(x) x.Edit())
            RaiseCanExecuteChanged(Sub(x) x.Delete())
        End Sub
    End Class
End Namespace
