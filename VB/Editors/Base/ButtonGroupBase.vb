Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports DevExpress.UITemplates.Collection.Components
Imports DevExpress.UITemplates.Collection.Editors.Base
Imports DevExpress.Utils
Imports DevExpress.Utils.Design
Imports DevExpress.Utils.Html
Imports DevExpress.XtraEditors.Internal

Namespace DevExpress.UITemplates.Collection.Editors

    <SmartTagAction(GetType(HtmlItemsControlActions), "AddItem", "Add Item", SmartTagActionType.RefreshBoundsAfterExecute Or SmartTagActionType.RefreshContentAfterExecute)>
    Public MustInherit Class ButtonGroupBase
        Inherits HtmlButtonBase
        Implements IHtmlItemsControl
        <Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
        Shared Sub New()
            Components.ItemsSelector.Register()
        End Sub
        Private ReadOnly itemsCore As ButtonGroupItem.Collection
        Protected Sub New()
            itemsCore = CreateItemsCollection()
            AddHandler Items.CollectionChanged, AddressOf OnItemsCollectionChanged
        End Sub
        Protected Overrides Sub Dispose(disposing As Boolean)
            If selectorElement IsNot Nothing Then selectorElement.RemoveEventListener("selection-changed", AddressOf OnItemsSelectorSelectionChanged)
            RemoveHandler Items.CollectionChanged, AddressOf OnItemsCollectionChanged
            MyBase.Dispose(disposing)
        End Sub
        Protected Overridable Function CreateItemsCollection() As ButtonGroupItem.Collection
            Return New ButtonGroupItem.Collection()
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
                selectorElement.SetAttribute(NameOf(ButtonGroupBase.ItemSize), ItemSize)
                Me.SetupItemsSelector(selectorElement)
                selectorElement.AddEventListener("selection-changed", AddressOf OnItemsSelectorSelectionChanged)
            End If
        End Sub
        Protected MustOverride Sub SetupItemsSelector(selectorElement As DxHtmlElement)
        Protected MustOverride Sub OnItemsSelectorSelectionChanged(args As DxHtmlElementEventArgs)
#Region "Properties"
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <ComponentModel.EditorAttribute(GetType(DevExpress.Utils.Design.DXCollectionEditorBase), GetType(System.Drawing.Design.UITypeEditor)), Localizable(True)>
        <Category("Data")>
        Public ReadOnly Property Items As ButtonGroupItem.Collection
            Get
                Return itemsCore
            End Get
        End Property
        Private itemSizeCore As Components.ItemsSelector.Size
        <Category("Layout"), DefaultValue(Components.ItemsSelector.Size.Default)>
        Public Property ItemSize As Components.ItemsSelector.Size
            Get
                Return itemSizeCore
            End Get
            Set(value As Components.ItemsSelector.Size)
                If itemSizeCore = value Then Return
                itemSizeCore = value
                Me.SetItemsSelectorItemSize(value)
            End Set
        End Property
        <Browsable(False), ComponentModel.DefaultValueAttribute(GetType(String), Nothing), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Overrides Property Text As String
            Get
                Return MyBase.Text
            End Get
            Set(value As String)
                MyBase.Text = value
            End Set
        End Property
#End Region
#Region "API"
        Protected Sub UpdateItemsSelectorSelection()
            If selectorElement IsNot Nothing Then
                Dim selector = TryCast(selectorElement.GetAttribute("self"), Components.ItemsSelector)
                If selector IsNot Nothing Then selector.UpdateSelection()
            End If
        End Sub
        Protected Function GetItemsSelectorSelectedItem() As ButtonGroupItem
            Return TryCast(selectorElement.GetAttribute(NameOf(Components.ItemsSelector.SelectedItem)), ButtonGroupItem)
        End Function
        Protected Sub SetItemsSelectorSelectedItem(value As ButtonGroupItem)
            If selectorElement IsNot Nothing Then selectorElement.SetAttribute(NameOf(Components.ItemsSelector.SelectedItem), value)
        End Sub
        Protected Sub SetItemsSelectorItemSize(value As Components.ItemsSelector.Size)
            If selectorElement IsNot Nothing Then selectorElement.SetAttribute(NameOf(ButtonGroupBase.ItemSize), value)
        End Sub
#End Region
        Protected Overrides Sub OnMouseUp(e As System.Windows.Forms.MouseEventArgs)
            Dim dxArgs = DXMouseEventArgs.GetMouseArgs(e)
            dxArgs.Handled = GetValidationCanceled()
            MyBase.OnMouseUp(dxArgs)
        End Sub
        Protected Overrides ReadOnly Property IsAutoHeight As Boolean
            Get
                Return False
            End Get
        End Property
        Protected Overrides ReadOnly Property IsAutoWidth As Boolean
            Get
                Return AutoSize
            End Get
        End Property
        Private Sub OnInitializeNewComponent()
            Items.Add(New ButtonGroupItem(1, "Item 1"))
            Items.Add(New ButtonGroupItem(2, "Item 2"))
        End Sub
        Private Sub AddItem()
            Items.Add(New ButtonGroupItem(Items.Count + 1, "Item " & (Items.Count + 1).ToString()))
        End Sub

        Private Sub IHtmlItemsControl_AddItem() Implements IHtmlItemsControl.AddItem
            AddItem()
        End Sub

        Private Sub IHtmlItemsControl_OnInitializeNewComponent() Implements IHtmlItemsControl.OnInitializeNewComponent
            OnInitializeNewComponent()
        End Sub
    End Class
End Namespace
