Imports System
Imports System.ComponentModel
Imports UITemplatesExampleVB.Assets.Toolbox
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils.Html

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True)>
    <System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "RadioButtonGroup.bmp")>
    <Description("A predesigned group of toggle buttons used to select a single option/value from multiple choices.")>
    Public Class RadioButtonGroup
        Inherits ButtonGroupBase
        Protected Overrides Sub SetupItemsSelector(selectorElement As DxHtmlElement)
            selectorElement.SetAttribute(NameOf(Items), Items)
            selectorElement.SetAttribute(NameOf(Components.ItemsSelector.IsMultiSelect), False)
            If selectedItemField IsNot Nothing Then selectorElement.SetAttribute(NameOf(RadioButtonGroup.SelectedItem), selectedItemField)
        End Sub
        Protected Overrides Sub OnItemsSelectorSelectionChanged(args As DxHtmlElementEventArgs)
            selectedItemField = GetItemsSelectorSelectedItem()
            RaiseSelectedItemChanged()
            RaiseSelectedValueChanged()
        End Sub
#Region "Properties"
        Private selectedItemField As ButtonGroupItem
        <Browsable(False), ComponentModel.DefaultValueAttribute(GetType(ButtonGroupItem), Nothing), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property SelectedItem As ButtonGroupItem
            Get
                Return selectedItemField
            End Get
            Set(value As ButtonGroupItem)
                If selectedItemField Is value Then Return
                selectedItemField = value
                Me.OnSelectedItemChanged(value)
            End Set
        End Property
        Protected Overridable Sub OnSelectedItemChanged(item As ButtonGroupItem)
            SetItemsSelectorSelectedItem(item)
            RaiseSelectedItemChanged()
            RaiseSelectedValueChanged()
        End Sub
        <Browsable(False), ComponentModel.DefaultValueAttribute(GetType(Object), Nothing), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property SelectedValue As Object
            Get
                Return selectedItemField?.Value
            End Get
            Set(value As Object)
                SelectedItem = If(TryCast(value, ButtonGroupItem), Items.GetItemByValue(value))
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
            Return RadioButtonGroupHtmlCssAsset.Default.Html
        End Function
        Protected Overrides Function LoadDefaultStyles() As String
            Return RadioButtonGroupHtmlCssAsset.Default.Css
        End Function
        Friend NotInheritable Class RadioButtonGroupHtmlCssAsset
            Inherits HtmlCssAsset
            <Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Shared Sub New()
                Components.ItemsSelector.Register()
            End Sub
            Public Shared ReadOnly [Default] As HtmlCssAsset = New RadioButtonGroupHtmlCssAsset()
        End Class
#End Region
        Protected Overrides Function CreateHtmlEditorPreview() As ICustomDxHtmlPreview
            Dim previewControl = New RadioButtonGroup()
            previewControl.Items.AddRange(New ButtonGroupItem() {New ButtonGroupItem(1, "One"), New ButtonGroupItem(2, "Two"), New ButtonGroupItem(3, "Three")})
            previewControl.SelectedItem = previewControl.Items(0)
            Return previewControl
        End Function
    End Class
End Namespace
