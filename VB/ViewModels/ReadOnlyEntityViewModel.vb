Imports System.Collections.Generic
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.UITemplates.Collection.Messages
Imports DevExpress.UITemplates.Collection.Models
Imports DevExpress.UITemplates.Collection.Repositories

Namespace DevExpress.UITemplates.Collection.ViewModels

    Public MustInherit Class ReadOnlyEntityViewModel(Of TKey As Structure, TEntity As Collection.Models.Entity(Of TKey))
        Implements ISupportParameter
        Public Sub New()
            Call Messenger.Default.Register(Of Collection.Messages.ReloadRequired(Of TKey, TEntity))(Me, New Action(Of Global.DevExpress.UITemplates.Collection.Messages.ReloadRequired(Of TKey, TEntity))(AddressOf Me.OnReloadRequired))
        End Sub
        Public Overridable Sub OnDestroy()
            Call Messenger.Default.Unregister(Of Collection.Messages.ReloadRequired(Of TKey, TEntity))(Me, New Action(Of Global.DevExpress.UITemplates.Collection.Messages.ReloadRequired(Of TKey, TEntity))(AddressOf Me.OnReloadRequired))
        End Sub
        Private Property Parameter As Object Implements ISupportParameter.Parameter
            Get
                Return Entity
            End Get
            Set(value As Object)
                If TypeOf value Is TKey Then
                    Load(DirectCast(value, TKey))
                Else
                    Entity = Nothing
                End If
            End Set
        End Property
        Protected Sub LoadNew()
            Load(NewEntityID)
        End Sub
        Protected Sub Load(id As TKey)
            OnReloadEntity(id)
        End Sub
        Private Sub OnReloadRequired(message As Collection.Messages.ReloadRequired(Of TKey, TEntity))
            Me.OnReloadEntity(message.Id)
        End Sub

        Public Overridable Property Entity As TEntity
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

        Public Overridable Property HasChanges As Boolean
        Protected ReadOnly Property IsNew As Boolean
            Get
                Return Entity IsNot Nothing AndAlso EqualityComparer(Of TKey).Default.Equals(Entity.ID, NewEntityID)
            End Get
        End Property
        Public Overridable ReadOnly Property Title As String
            Get
                If Entity Is Nothing Then Return String.Empty
                Dim suffix = If(HasChanges, "*", String.Empty)
                Dim entityName = GetType(TEntity).Name
                If IsNew Then Return "New " & entityName.ToLowerInvariant() & suffix
                Return entityName & " #" & Entity.ID.ToString() & suffix
            End Get
        End Property
        Protected Overridable Sub OnReloadEntity(id As TKey)
            Entity = ReadOnlyRepository.Load(id)
        End Sub
        Protected Sub OnEntityChanged()
            HasChanges = False
            RaisePropertyChanged(Function(x) x.Title)
            UpdateCommands()
        End Sub
        Protected Sub OnHasChangesChanged()
            RaisePropertyChanged(Function(x) x.Title)
            UpdateCommands()
        End Sub
        Protected Overridable Sub UpdateCommands()
            ' do update commands here 
        End Sub
        Protected ReadOnly Property NavigationService As INavigationService
            Get
                Return GetService(Of INavigationService)()
            End Get
        End Property
        Protected ReadOnly Property DocumentManagerService As IDocumentManagerService
            Get
                Return GetService(Of IDocumentManagerService)()
            End Get
        End Property
        Public Sub GoBackOrClose()
            Dim currentDocument As IDocument = Nothing
            If NavigationService IsNot Nothing Then
                currentDocument = TryCast(NavigationService.Current, IDocument)
                NavigationService.GoBack()
            End If
            If DocumentManagerService IsNot Nothing Then currentDocument = DocumentManagerService.ActiveDocument
            If currentDocument IsNot Nothing Then currentDocument.Close(True)
        End Sub
    End Class
End Namespace
