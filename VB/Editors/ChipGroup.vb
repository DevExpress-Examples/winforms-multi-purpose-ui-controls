Imports System
Imports System.ComponentModel
Imports UITemplatesExampleVB.Assets.Toolbox
Imports DevExpress.UITemplates.Collection.Components
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils.Html

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True)>
    <System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "ChipGroup.bmp")>
    <Description("Similar to a radio group, a Chip Group displays chips across multiple lines. It supports single value and mandatory selection.")>
    Public Class ChipGroup
        Inherits ChipGroupBase
        Protected Overrides Sub SetupItemsSelector(selectorElement As DxHtmlElement)
            selectorElement.SetAttribute(NameOf(ItemsSelector.IsMultiSelect), False)
            selectorElement.SetAttribute(NameOf(ItemsSelector.IsMandatorySelection), IsMandatorySelection)
            If selectedItemField IsNot Nothing Then selectorElement.SetAttribute(NameOf(ItemsSelector.SelectedItem), selectedItemField)
        End Sub
        Protected Overrides Sub OnItemsSelectorSelectionChanged(args As DxHtmlElementEventArgs)
            selectedItemField = GetItemsSelectorSelectedItem()
            RaiseSelectedItemChanged()
            RaiseSelectedValueChanged()
        End Sub
#Region "Properties"
        Private selectedItemField As Chip
        <Browsable(False), ComponentModel.DefaultValueAttribute(GetType(Chip), Nothing), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property SelectedItem As Chip
            Get
                Return selectedItemField
            End Get
            Set(value As Chip)
                If selectedItemField Is value Then Return
                selectedItemField = value
                Me.OnSelectedItemChanged(value)
            End Set
        End Property
        Protected Overridable Sub OnSelectedItemChanged(chip As Chip)
            SetItemsSelectorSelectedItem(chip)
            RaiseSelectedItemChanged()
            RaiseSelectedValueChanged()
        End Sub
        <Browsable(False), ComponentModel.DefaultValueAttribute(GetType(Object), Nothing), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property SelectedValue As Object
            Get
                Return selectedItemField?.Value
            End Get
            Set(value As Object)
                SelectedItem = If(TryCast(value, Chip), Items.GetItemByValue(value))
            End Set
        End Property
        Private mandatoryCore As Boolean
        <DefaultValue(False), ComponentModel.Category(XtraEditors.CategoryName.Behavior)>
        Public Property IsMandatorySelection As Boolean
            Get
                Return mandatoryCore
            End Get
            Set(value As Boolean)
                If mandatoryCore = value Then Return
                mandatoryCore = value
                SetItemsSelectorIsMandatorySelection(value)
            End Set
        End Property
#End Region
#Region "Events"
        Private ReadOnly Shared selectedItemChangedField As Object = New Object()
        Private ReadOnly Shared selectedValueChangedField As Object = New Object()
        '
        Public Custom Event SelectedItemChanged As EventHandler
            AddHandler(value As EventHandler)
                Events.AddHandler(selectedItemChangedField, value)
            End AddHandler
            RemoveHandler(value As EventHandler)
                Events.RemoveHandler(selectedItemChangedField, value)
            End RemoveHandler
            RaiseEvent(sender As Object, e As EventArgs)
            End RaiseEvent
        End Event
        Protected Sub RaiseSelectedItemChanged()
            Dim handler = TryCast(Events(selectedItemChangedField), EventHandler)
            handler?.Invoke(Me, EventArgs.Empty)
        End Sub
        Public Custom Event SelectedValueChanged As EventHandler
            AddHandler(value As EventHandler)
                Events.AddHandler(selectedValueChangedField, value)
            End AddHandler
            RemoveHandler(value As EventHandler)
                Events.RemoveHandler(selectedValueChangedField, value)
            End RemoveHandler
            RaiseEvent(sender As Object, e As EventArgs)
            End RaiseEvent
        End Event
        Protected Sub RaiseSelectedValueChanged()
            Dim handler = TryCast(Events(selectedValueChangedField), EventHandler)
            handler?.Invoke(Me, EventArgs.Empty)
        End Sub
#End Region
#Region "Theme"
        Protected Overrides Function LoadDefaultTemplate() As String
            Return ChipGroupHtmlCssAsset.Default.Html
        End Function
        Protected Overrides Function LoadDefaultStyles() As String
            Return ChipGroupHtmlCssAsset.Default.Css
        End Function
        Friend NotInheritable Class ChipGroupHtmlCssAsset
            Inherits HtmlCssAsset
            <Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Shared Sub New()
                ItemsSelector.Register()
            End Sub
            Public Shared ReadOnly [Default] As HtmlCssAsset = New ChipGroupHtmlCssAsset()
        End Class
#End Region
        Protected Overrides Function CreateHtmlEditorPreview() As ICustomDxHtmlPreview
            Dim previewControl = New ChipGroup()
            previewControl.Items.AddRange(New Chip() {New Chip(1, "One"), New Chip(2, "Two"), New Chip(3, "Three")})
            previewControl.SelectedItem = previewControl.Items(0)
            Return previewControl
        End Function
    End Class
End Namespace
