Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Linq
Imports DevExpress.Utils
Imports DevExpress.Utils.Html
Imports DevExpress.Utils.Html.Internal

Namespace DevExpress.UITemplates.Collection.Components

    Public NotInheritable Class ItemsSelector
        Inherits DxHtmlComponent
        Private ReadOnly Shared EmptyCollection As ICollection = New Object(-1) {}
        Public Shared Sub Register()
            DxHtmlDocument.Define(Of ItemsSelector)("items-selector")
            DxHtmlDocument.Define(Of Item)("items-selector-item")
        End Sub
        Public Shared Function GetItem(Of TItem As Collection.Editors.ItemBase)(element As DxHtmlElementBase) As TItem
            Dim parent = element.ParentElement
            While parent IsNot Nothing
                If Equals(parent.TagName, "items-selector-item") Then Return TryCast(parent.GetAttribute(NameOf(Item.ItemObject)), TItem)
                parent = parent.ParentElement
            End While
            Return Nothing
        End Function
        '
        Public Interface IItemContentProvider
            Function OnCreateItemContent(root As DxHtmlRootElement, item As Item) As Boolean
        End Interface
        Public Enum Size
            Small = -1
            [Default] = 0
            Large = 1
        End Enum
        Public ReadOnly Property Items As ICollection
            Get
                Return TryCast(GetAttribute(NameOf(ItemsSelector.Items)), ICollection)
            End Get
        End Property
        Public ReadOnly Property SelectedItem As Object
            Get
                Return GetAttribute(NameOf(ItemsSelector.SelectedItem))
            End Get
        End Property
        Public ReadOnly Property Selection As ICollection(Of Object)
            Get
                Return If(TryCast(GetAttribute(NameOf(ItemsSelector.Selection)), ICollection(Of Object)), selectionCore)
            End Get
        End Property
        Public ReadOnly Property IsMultiSelect As Boolean
            Get
                Dim value = GetAttribute(NameOf(ItemsSelector.IsMultiSelect))
                Return TypeOf value Is Boolean AndAlso CBool(value)
            End Get
        End Property
        Public ReadOnly Property IsMandatorySelection As Boolean?
            Get
                Dim value = GetAttribute(NameOf(ItemsSelector.IsMandatorySelection))
                Return If(TypeOf value Is Boolean, New Boolean?(DirectCast(value, Boolean)), Nothing)
            End Get
        End Property
        Public ReadOnly Property ItemClass As String
            Get
                Return If(TryCast(GetAttribute(NameOf(ItemsSelector.ItemClass)), String), String.Empty)
            End Get
        End Property
        Public ReadOnly Property ItemTemplate As String
            Get
                Return If(TryCast(GetAttribute(NameOf(ItemsSelector.ItemTemplate)), String), String.Empty)
            End Get
        End Property
        Public ReadOnly Property ItemSize As Size?
            Get
                Dim value = GetAttribute(NameOf(ItemsSelector.ItemSize))
                If TypeOf value Is Integer Then Return New Size?(CType(CInt(value), Size))
                If TypeOf value Is String Then
                    If String.Equals(CStr(value), NameOf(Size.Small), StringComparison.OrdinalIgnoreCase) Then Return Size.Small
                    If String.Equals(CStr(value), NameOf(Size.Default), StringComparison.OrdinalIgnoreCase) Then Return Size.Default
                    If String.Equals(CStr(value), NameOf(Size.Large), StringComparison.OrdinalIgnoreCase) Then Return Size.Large
                End If
                Return If(TypeOf value Is Size, New Size?(DirectCast(value, Size)), Nothing)
            End Get
        End Property
        Private ReadOnly selectionCore As HashSet(Of Object) = New HashSet(Of Object)()
        Private itemsCollection As ICollection
        Public Overrides Sub ConnectedCallback()
            MyBase.ConnectedCallback()
            If String.IsNullOrEmpty(Element.ClassName) Then Element.ClassName = "items-selector"
            CreateItems(EnsureItemsCollection(), ItemClass, ItemSize)
            SetAttribute("self", Me)
        End Sub
        Public Overrides Sub DisconnectedCallback()
            MyBase.DisconnectedCallback()
            If itemsCollection IsNot Nothing Then Unsubscribe(itemsCollection)
            itemsCollection = Nothing
        End Sub
        Public Overrides Sub AttributeChangedCallback(attributeName As String)
            MyBase.AttributeChangedCallback(attributeName)
            If String.Equals(attributeName, NameOf(ItemsSelector.Items), StringComparison.OrdinalIgnoreCase) Then
                ResetItems()
                Return
            End If
            If String.Equals(attributeName, NameOf(ItemsSelector.ItemSize), StringComparison.OrdinalIgnoreCase) Then
                UpdateItemSizes(ItemClass, ItemSize)
                Return
            End If
            If lockSelection = 0 Then
                If String.Equals(attributeName, NameOf(ItemsSelector.SelectedItem), StringComparison.OrdinalIgnoreCase) Then
                    SyncSelection(Selection, SelectedItem, IsMultiSelect)
                    UpdateItemsSelection(Selection)
                    Return
                End If
                If String.Equals(attributeName, NameOf(ItemsSelector.Selection), StringComparison.OrdinalIgnoreCase) Then
                    UpdateItemsSelection(Selection)
                    Return
                End If
            End If
        End Sub
        Public Sub UpdateSelection()
            UpdateItemsSelection(Selection)
        End Sub
        Friend ReadOnly Property ItemContentProvider As IItemContentProvider
            Get
                Return TryCast(GetAttribute(NameOf(ItemsSelector.ItemContentProvider)), IItemContentProvider)
            End Get
        End Property
        Friend Function OnCreateItemContent(item As Item) As Boolean
            Dim itemTemplateId = ItemTemplate
            If Not String.IsNullOrEmpty(itemTemplateId) Then
                Dim template = Element.RootElement.FindTemplate(itemTemplateId)
                If template IsNot Nothing Then item.SetContent(template)
                Return template IsNot Nothing
            End If
            Return TryCreateItemContent(item)
        End Function
        Private Function TryCreateItemContent(item As Item) As Boolean
            Dim itemContentProvider = TryCast(GetAttribute(NameOf(ItemsSelector.ItemContentProvider)), IItemContentProvider)
            Return itemContentProvider IsNot Nothing AndAlso itemContentProvider.OnCreateItemContent(Element.RootElement, item)
        End Function
        Public Sub ResetItems(Optional resetSelection As Boolean = True)
            ClearChildren()
            If resetSelection Then selectionCore.Clear()
            CreateItems(EnsureItemsCollection(), ItemClass, ItemSize)
        End Sub
        Private Function EnsureItemsCollection() As ICollection
            If itemsCollection Is Nothing Then
                itemsCollection = TryCast(GetAttribute(NameOf(ItemsSelector.Items)), ICollection)
                If itemsCollection IsNot Nothing Then Subscribe(itemsCollection)
            End If
            Return If(itemsCollection, EmptyCollection)
        End Function
        Private Sub Subscribe(collection As ICollection)
            Dim bList = TryCast(collection, IBindingList)
            If bList IsNot Nothing Then AddHandler bList.ListChanged, AddressOf OnBindingChanged
            Dim incc = TryCast(collection, INotifyCollectionChanged)
            If incc IsNot Nothing Then AddHandler incc.CollectionChanged, AddressOf OnCollectionChanged
        End Sub
        Private Sub Unsubscribe(collection As ICollection)
            Dim bList = TryCast(collection, IBindingList)
            If bList IsNot Nothing Then RemoveHandler bList.ListChanged, AddressOf OnBindingChanged
            Dim incc = TryCast(collection, INotifyCollectionChanged)
            If incc IsNot Nothing Then RemoveHandler incc.CollectionChanged, AddressOf OnCollectionChanged
        End Sub
        Private Sub OnBindingChanged(sender As Object, e As ListChangedEventArgs)
            If e.ListChangedType = ListChangedType.Reset Then ResetItems()
        End Sub
        Private Sub OnCollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
            If e.Action = NotifyCollectionChangedAction.Reset Then ResetItems()
        End Sub
        Private Function SyncSelection(selection As ICollection(Of Object), itemObject As Object, isMultiSelect As Boolean) As Boolean
            If Not isMultiSelect Then
                Return SyncSingleSelection(selection, itemObject, IsMandatorySelection)
            Else
                If Not selection.Remove(itemObject) Then selection.Add(itemObject)
                Return True
            End If
        End Function
        Private Function SyncSingleSelection(selection As ICollection(Of Object), itemObject As Object, isMandatory As Boolean?) As Boolean
            Dim selectedBefore As Object = selection.FirstOrDefault()
            If Not isMandatory.HasValue Then
                selection.Clear()
                If Not IsControlPressed Then selection.Add(itemObject)
            Else
                Dim wasSelected = selection.Contains(itemObject)
                selection.Clear()
                If wasSelected AndAlso Not isMandatory.Value Then
                    SetSelectedItemCore(Nothing)
                    Return True
                End If
                selection.Add(itemObject)
            End If
            Dim selectedAfter As Object = selection.FirstOrDefault()
            SetSelectedItemCore(selectedAfter)
            Return Not Equals(selectedBefore, selectedAfter)
        End Function
        Private Sub SetSelectedItemCore(selectedAfter As Object)
            If lockSelection > 0 Then SetAttribute(NameOf(ItemsSelector.SelectedItem), selectedAfter)
        End Sub
        Private lockSelection As Integer = 0
        Friend Sub OnItemSelected(args As DxHtmlElementEventArgs)
            Dim itemObject = args.Element.GetAttribute(NameOf(Item.ItemObject))
            lockSelection += 1
            Try
                If SyncSelection(Selection, itemObject, IsMultiSelect) Then
                    UpdateItemsSelection(Selection)
                    DispatchEvent("selection-changed", args)
                End If

            Finally
                lockSelection -= 1
            End Try
        End Sub
        Private Shared ReadOnly Property IsControlPressed As Boolean
            Get
                Return System.Windows.Forms.Control.ModifierKeys = System.Windows.Forms.Keys.Control
            End Get
        End Property
        Private Sub UpdateItemsSelection(selection As ICollection(Of Object))
            For Each child In Element.Children
                Dim selectorItem = TryCast(child.GetAttribute("self"), Item)
                If selectorItem IsNot Nothing Then selectorItem.UpdateStates(selection.Contains(selectorItem.ItemObject))
            Next
        End Sub
        Private Sub UpdateItemSizes(itemClassName As String, itemSize As Size?)
            Dim index = 0, count = If(itemsCollection IsNot Nothing, itemsCollection.Count, 0)
            For Each child In Element.Children
                child.ClassName = CalcClassName(itemClassName, itemSize, Math.Min(Threading.Interlocked.Increment(index), index - 1), count)
            Next
        End Sub
        Private Sub CreateItems(itemsCollection As ICollection, itemClassName As String, itemSize As Size?)
            Dim index = 0, count = itemsCollection.Count
            For Each itemObject In itemsCollection
                Dim itemElement = DxHtmlDocument.CreateElement("items-selector-item")
                itemElement.ClassName = CalcClassName(itemClassName, itemSize, Math.Min(Threading.Interlocked.Increment(index), index - 1), count)
                itemElement.SetAttribute(NameOf(Item.ItemObject), itemObject)
                itemElement.SetAttribute("items-selector", Me)
                AppendChild(itemElement)
            Next
        End Sub
        Private Shared Function CalcClassName(className As String, size As Size?, index As Integer, count As Integer) As String
            If String.IsNullOrEmpty(className) Then className = "items-selector-item"
            className = className & " " & size.GetValueOrDefault().ToString().ToLowerInvariant()
            If index = 0 AndAlso count > 1 Then Return className & " first"
            If index = count - 1 AndAlso count > 1 Then Return className & " last"
            Return className & " middle"
        End Function
        Public NotInheritable Class Item
            Inherits DxHtmlComponent
            Public ReadOnly Property ItemObject As Object
                Get
                    Return GetAttribute(NameOf(Item.ItemObject))
                End Get
            End Property
            Private _internals As ElementInternals
            Public Overrides Sub ConnectedCallback()
                MyBase.ConnectedCallback()
                _internals = AttachInternals()
                Dim selector = TryCast(GetAttribute("items-selector"), ItemsSelector)
                Dim itemObject = Me.ItemObject
                If selector Is Nothing OrElse Not selector.OnCreateItemContent(Me) Then SetInnerText(GetText(itemObject))
                AddEventListener("mouseup", New Action(Of DxHtmlElementEventArgs)(AddressOf OnItemMouseUp))
                SetAttribute("self", Me)
                Dim selection = If(selector IsNot Nothing, selector.Selection, Nothing)
                If selection IsNot Nothing AndAlso selection.Count > 0 Then UpdateStates(selection.Contains(itemObject))
            End Sub
            Public Overrides Sub DisconnectedCallback()
                RemoveEventListener("mouseup", New Action(Of DxHtmlElementEventArgs)(AddressOf OnItemMouseUp))
                DetachInternals()
                _internals = Nothing
                MyBase.DisconnectedCallback()
            End Sub
            Private Sub OnItemMouseUp(args As DxHtmlElementEventArgs)
                Dim mouseArgs = TryCast(args, DxHtmlElementMouseEventArgs)
                If mouseArgs IsNot Nothing AndAlso mouseArgs.IsClick Then
                    Dim meArgs = TryCast(mouseArgs.MouseArgs, DXMouseEventArgs)
                    If meArgs IsNot Nothing AndAlso meArgs.Handled Then Return
                    OnSelectItem(args)
                End If
            End Sub
            Private Sub OnSelectItem(args As DxHtmlElementEventArgs)
                Dim selector = TryCast(GetAttribute("items-selector"), ItemsSelector)
                If selector IsNot Nothing Then selector.OnItemSelected(args)
                args.CancelBubble = True
                args.SuppressOwnerEvent = True
            End Sub
            Public Sub UpdateStates(isSelected As Boolean)
                If _internals Is Nothing Then Return
                If isSelected Then
                    _internals.States.Add("--selected")
                Else
                    _internals.States.Delete("--selected")
                End If
            End Sub
            Public Sub SetContent(template As DxHtmlDocumentFragment)
                AppendChild(template.CloneNode(True))
            End Sub
            Public Sub SetContent(content As DxHtmlElement)
                AppendChild(content)
            End Sub
            Public Sub SetContent(content As String)
                SetInnerHtml(content)
            End Sub
            Private Shared Function GetText(itemObject As Object) As String
                If itemObject Is Nothing Then Return String.Empty
                Return If(TryCast(itemObject, String), itemObject.ToString())
            End Function
        End Class
    End Class
End Namespace
