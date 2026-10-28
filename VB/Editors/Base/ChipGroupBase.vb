Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Windows.Forms
Imports DevExpress.UITemplates.Collection.Components
Imports DevExpress.UITemplates.Collection.Editors.Base
Imports DevExpress.Utils
Imports DevExpress.Utils.Design
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils.Html
Imports DevExpress.Utils.Layout
Imports DevExpress.XtraEditors.Internal

Namespace DevExpress.UITemplates.Collection.Editors

    <Designer("DevExpress.XtraEditors.Design.HtmlItemsControlDesigner, " & AssemblyInfo.SRAssemblyEditorsDesign, Aliases.IDesigner)>
    <SmartTagAction(GetType(HtmlItemsControlActions), "AddItem", "Add Item", SmartTagActionType.RefreshBoundsAfterExecute Or SmartTagActionType.RefreshContentAfterExecute)>
    Public MustInherit Class ChipGroupBase
        Inherits HtmlButtonBase
        Implements ItemsSelector.IItemContentProvider, IHtmlItemsControl
        <Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
        Shared Sub New()
            ItemsSelector.Register()
        End Sub
        Private ReadOnly itemsCore As Chip.Collection
        Protected Sub New()
            itemsCore = CreateItemsCollection()
            AddHandler Items.CollectionChanged, AddressOf OnItemsCollectionChanged
        End Sub
        Protected Overrides Sub Dispose(disposing As Boolean)
            If selectorElement IsNot Nothing Then selectorElement.RemoveEventListener("selection-changed", AddressOf OnItemsSelectorSelectionChanged)
            RemoveHandler Items.CollectionChanged, AddressOf OnItemsCollectionChanged
            MyBase.Dispose(disposing)
        End Sub
        Protected Overridable Function CreateItemsCollection() As Chip.Collection
            Return New Chip.Collection()
        End Function
        Protected Overridable Sub OnItemsCollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
            If selectorElement IsNot Nothing Then selectorElement.SetAttribute(NameOf(ItemsSelector.Items), Items)
            OnPropertiesChanged()
        End Sub
        Private selectorElement As DxHtmlElement
        Protected Overrides Sub FindParts(parts As Dictionary(Of Object, DxHtmlElement), root As DxHtmlRootElement)
            MyBase.FindParts(parts, root)
            selectorElement = root.FindElementsByTag("items-selector").FirstOrDefault()
            If selectorElement IsNot Nothing Then
                selectorElement.SetAttribute(NameOf(ChipGroupBase.ItemSize), ItemSize)
                selectorElement.SetAttribute(NameOf(ItemsSelector.ItemContentProvider), Me)
                selectorElement.SetAttribute(NameOf(ItemsSelector.Items), Items)
                Me.SetupItemsSelector(selectorElement)
                selectorElement.AddEventListener("selection-changed", AddressOf OnItemsSelectorSelectionChanged)
            End If
        End Sub
        Protected Overrides Function GetPartImage(partName As String, state As ObjectState, element As DxHtmlElementBase) As Object
            If Equals(partName, "Item.Check") Then Return Collection.Images.UIElements.Check
            If Equals(partName, "Item.Icon") Then
                Dim chip = ItemsSelector.GetItem(Of Chip)(element)
                If chip IsNot Nothing Then Return chip.Caption
            End If
            Return MyBase.GetPartImage(partName, state, element)
        End Function
        Protected Overrides Function GetPartText(partName As String, element As DxHtmlElementBase) As String
            If Equals(partName, "Item.Caption") Then
                Dim chip = ItemsSelector.GetItem(Of Chip)(element)
                If chip IsNot Nothing Then Return chip.Caption
            End If
            Return MyBase.GetPartText(partName, element)
        End Function
        Protected MustOverride Sub SetupItemsSelector(selectorElement As DxHtmlElement)
        Protected MustOverride Sub OnItemsSelectorSelectionChanged(args As DxHtmlElementEventArgs)
#Region "Properties"
        Public Enum GroupAutoSizeMode
            [Default]
            Horizontal
            Vertical
            None
        End Enum
        Private autoSizeModeCore As GroupAutoSizeMode = GroupAutoSizeMode.Default
        <DefaultValue(GroupAutoSizeMode.Default), SmartTagProperty("Auto Size Mode", "", SmartTagActionType.RefreshBoundsAfterExecute)>
        <Category("Layout")>
        Public Property AutoSizeMode As GroupAutoSizeMode
            Get
                Return autoSizeModeCore
            End Get
            Set(value As GroupAutoSizeMode)
                If AutoSizeMode = value Then Return
                autoSizeModeCore = value
                MyBase.AutoSize = GetActualAutoSize(value)
                LayoutChanged()
                RaiseSizeableChanged()
            End Set
        End Property
        Private Function GetActualAutoSize(mode As GroupAutoSizeMode) As Boolean
            If mode = GroupAutoSizeMode.Horizontal Then Return True
            Return TypeOf Parent Is TableLayoutPanel OrElse TypeOf Parent Is TablePanel
        End Function
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <System.ComponentModel.EditorAttribute(GetType(DevExpress.Utils.Design.DXCollectionEditorBase), GetType(System.Drawing.Design.UITypeEditor)), Localizable(True)>
        <SmartTagProperty("Items", "", 2)>
        <Category("Data")>
        Public ReadOnly Property Items As Chip.Collection
            Get
                Return itemsCore
            End Get
        End Property
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Overrides Property AutoSize As Boolean
            Get
                Return MyBase.AutoSize
            End Get
            Set(value As Boolean)
                MyBase.AutoSize = value
            End Set
        End Property
        Private showCheckCore As Boolean = True
        <DefaultValue(True)>
        <Category("Appearance")>
        Public Property ShowCheck As Boolean
            Get
                Return showCheckCore
            End Get
            Set(value As Boolean)
                If showCheckCore = value Then Return
                showCheckCore = value
                ResetItemsSelectorItems()
            End Set
        End Property
        Private itemSizeCore As ItemsSelector.Size = ItemsSelector.Size.Default
        <DefaultValue(ItemsSelector.Size.Default)>
        <Category("Layout")>
        Public Property ItemSize As ItemsSelector.Size
            Get
                Return itemSizeCore
            End Get
            Set(value As ItemsSelector.Size)
                If itemSizeCore = value Then Return
                itemSizeCore = value
                Me.SetItemsSelectorItemSize(value)
            End Set
        End Property
#End Region
#Region "Theme"
        Private Function OnCreateItemContent(root As DxHtmlRootElement, item As ItemsSelector.Item) As Boolean
            Dim itemTemplateId = If(ShowCheck, "chip-check-template", "chip-template")
            Dim template As DxHtmlDocumentFragment = root.FindTemplate(itemTemplateId)
            If template IsNot Nothing Then item.SetContent(template)
            Return template IsNot Nothing
        End Function
#End Region
#Region "API"
        Protected Sub ResetItemsSelectorItems()
            If selectorElement IsNot Nothing Then
                Dim selector = TryCast(selectorElement.GetAttribute("self"), ItemsSelector)
                If selector IsNot Nothing Then selector.ResetItems()
            End If
        End Sub
        Protected Sub UpdateItemsSelectorSelection()
            If selectorElement IsNot Nothing Then
                Dim selector = TryCast(selectorElement.GetAttribute("self"), ItemsSelector)
                If selector IsNot Nothing Then selector.UpdateSelection()
            End If
        End Sub
        Protected Function GetItemsSelectorSelectedItem() As Chip
            Return TryCast(selectorElement.GetAttribute(NameOf(ItemsSelector.SelectedItem)), Chip)
        End Function
        Protected Sub SetItemsSelectorSelectedItem(chip As Chip)
            If selectorElement IsNot Nothing Then selectorElement.SetAttribute(NameOf(ItemsSelector.SelectedItem), chip)
        End Sub
        Protected Sub SetItemsSelectorIsMandatorySelection(value As Boolean)
            If selectorElement IsNot Nothing Then selectorElement.SetAttribute(NameOf(ItemsSelector.IsMandatorySelection), value)
        End Sub
        Protected Sub SetItemsSelectorItemSize(value As ItemsSelector.Size)
            If selectorElement IsNot Nothing Then selectorElement.SetAttribute(NameOf(ChipGroupBase.ItemSize), value)
        End Sub
#End Region
        Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
            Dim dxArgs = DXMouseEventArgs.GetMouseArgs(e)
            dxArgs.Handled = GetValidationCanceled()
            MyBase.OnMouseUp(dxArgs)
        End Sub
        Protected Overrides Sub AdjustSize()
            If AutoSizeMode = GroupAutoSizeMode.Horizontal Then Size = PreferredSize
            If AutoSizeMode = GroupAutoSizeMode.Vertical Then Size = GetPreferredSize(Size)
        End Sub
        Protected Overrides ReadOnly Property IsAutoHeight As Boolean
            Get
                Return AutoSizeMode = GroupAutoSizeMode.Vertical
            End Get
        End Property
        Protected Overrides ReadOnly Property IsAutoWidth As Boolean
            Get
                Return AutoSizeMode = GroupAutoSizeMode.Horizontal
            End Get
        End Property
        Private Sub OnInitializeNewComponent()
            Items.Add(New Chip(1, "Item 1"))
            Items.Add(New Chip(2, "Item 2"))
        End Sub
        Private Sub AddItem()
            Items.Add(New Chip(Items.Count + 1, "Item " & (Items.Count + 1).ToString()))
        End Sub

        Private Sub IHtmlItemsControl_AddItem() Implements IHtmlItemsControl.AddItem
            AddItem()
        End Sub

        Private Sub IHtmlItemsControl_OnInitializeNewComponent() Implements IHtmlItemsControl.OnInitializeNewComponent
            OnInitializeNewComponent()
        End Sub

        Private Function IItemContentProvider_OnCreateItemContent(root As DxHtmlRootElement, item As ItemsSelector.Item) As Boolean Implements ItemsSelector.IItemContentProvider.OnCreateItemContent
            Return OnCreateItemContent(root, item)
        End Function
    End Class
End Namespace
