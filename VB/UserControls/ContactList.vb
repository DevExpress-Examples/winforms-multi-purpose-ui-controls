Imports System.Collections.Generic
Imports DevExpress.Data
Imports DevExpress.UITemplates.Collection.Models
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Tile

Namespace DevExpress.UITemplates.Collection.UserControls

    Public Partial Class ContactList
        Inherits XtraUserControl
        Public Sub New()
            InitializeComponent()
            If Not mvvmContext.IsDesignMode Then
                InitializeStyles()
                InitializeBinding()
                InitializeBehavior()
            End If
        End Sub
        Private Sub InitializeStyles()
            Assets.SearchPanel.Apply(searchPanel)
            searchPanel.HtmlImages = Collection.Images.UIElements.SvgImages
            contactsTileView.HtmlImages = Collection.Images.UIElements.SvgImages
        End Sub
        Private Sub InitializeBinding()
            Dim fluent = mvvmContext.OfType(Of ViewModel)()
            ' Bind the contacts
            fluent.SetBinding(gridControl, Function(gc) gc.DataSource, Function(x) x.Contacts)
            fluent.WithEvent(Of TileView, FocusedRowObjectChangedEventArgs)(contactsTileView, NameOf(ColumnView.FocusedRowObjectChanged)).SetBinding(Function(x) x.SelectedContact, Function(args) TryCast(args.Row, Collection.Models.Contact), Sub(gView, entity) gView.FocusedRowHandle = gView.FindRow(entity))
            ' We need update our contacts list when the ViewModel detect changes
            fluent.SetTrigger(Function(x) x.Contacts, Sub(contacts) contactsTileView.RefreshData())
            ' Bind life-cycle events
            fluent.WithEvent(Me, NameOf(HandleCreated)).EventToCommand(Sub(x) x.OnCreate())
            fluent.WithEvent(Me, NameOf(HandleDestroyed)).EventToCommand(Sub(x) x.OnDestroy())
        End Sub
        Private Sub InitializeBehavior()
            ' Setup default sorting for contacts
            Dim colLastActivity = contactsTileView.Columns("LastActivity")
            If colLastActivity IsNot Nothing Then contactsTileView.SortInfo.Add(colLastActivity, ColumnSortOrder.Descending)
            ' Setup search by user name only
            AddHandler searchControl.QueryIsSearchColumn, AddressOf OnQueryIsSearchColumn
        End Sub
        Private Sub OnQueryIsSearchColumn(sender As Object, e As QueryIsSearchColumnEventArgs)
            e.IsSearchColumn = Equals(e.FieldName, "UserName")
        End Sub
        Private Sub OnContactItemTemplate(sender As Object, e As TileViewCustomItemTemplateEventArgs)
            Assets.Contact.Apply(e.HtmlTemplate)
        End Sub
        Private Sub OnContactItemTemplateCustomize(sender As Object, e As TileViewItemCustomizeEventArgs)
            Dim contact = TryCast(contactsTileView.GetRow(e.RowHandle), DevExpress.UITemplates.Collection.Models.Contact)
            If contact IsNot Nothing Then
                Dim statusBadge = e.HtmlElement.FindElementById("statusBadge")
                If statusBadge IsNot Nothing AndAlso contact.IsActive Then statusBadge.Style.SetBackgroundColor("@Green")
                If Not contact.HasUnreadMessages Then
                    Dim unreadBadge = e.HtmlElement.FindElementById("unreadBadge")
                    If unreadBadge IsNot Nothing Then unreadBadge.Hidden = True
                End If
            End If
        End Sub
        Public Class ViewModel
            Public Overridable Property Contacts As List(Of Collection.Models.Contact)
            Public Overridable Property SelectedContact As Collection.Models.Contact
            Public Sub OnCreate()
                ' do loading contact DTOs from data-layer
                Collection.Models.ContactSampleData.Contact1.Avatar = Images.Users.CreateAvatar(1, Collection.Images.Users.SampleUser1)
                Collection.Models.ContactSampleData.Contact2.Avatar = Images.Users.CreateAvatar(2, Collection.Images.Users.SampleUser2)
                Contacts = New List(Of DevExpress.UITemplates.Collection.Models.Contact)(Collection.Models.ContactSampleData.Contacts)
            End Sub
            Public Sub OnDestroy()
                ' do some cleanup if required 
            End Sub
        End Class
#Region "Theme"
        Public Class Assets
            Public Shared Contact As Collection.Utilities.HtmlCssAsset = New ContactHtmlCssAsset()
            Public Shared SearchPanel As Collection.Utilities.HtmlCssAsset = New ContactSearchPanelHtmlCssAsset()
            '
            Friend NotInheritable Class ContactHtmlCssAsset
                Inherits Collection.Utilities.HtmlCssAsset
            End Class
            Friend NotInheritable Class ContactSearchPanelHtmlCssAsset
                Inherits Collection.Utilities.HtmlCssAsset
            End Class
        End Class
#End Region
    End Class
End Namespace
