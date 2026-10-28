Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports UITemplatesExampleVB.Assets.Toolbox
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils.Html

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True)>
    <System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "ToggleButtonGroup.bmp")>
    <Description("A set of two-state buttons that can be toggled on or off.")>
    Public Class ToggleButtonGroup
        Inherits ButtonGroupBase
        Private ReadOnly selectionCore As ButtonGroupItem.Selection = New ButtonGroupItem.Selection()
        Protected Overrides Sub Dispose(disposing As Boolean)
            selectionCore.Clear()
            MyBase.Dispose(disposing)
        End Sub
        Protected Overrides Sub SetupItemsSelector(selectorElement As DxHtmlElement)
            selectorElement.SetAttribute(NameOf(Items), Items)
            selectorElement.SetAttribute(NameOf(Components.ItemsSelector.IsMultiSelect), True)
            selectorElement.SetAttribute(NameOf(Components.ItemsSelector.Selection), Selection)
        End Sub
        Protected Overrides Sub OnItemsSelectorSelectionChanged(args As DxHtmlElementEventArgs)
            RaiseSelectionChanged()
            RaiseSelectedValuesChanged()
        End Sub
#Region "Properties"
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public ReadOnly Property Selection As ButtonGroupItem.Selection
            Get
                Return selectionCore
            End Get
        End Property
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public ReadOnly Property SelectedValues As HashSet(Of Object)
            Get
                Return Items.GetValues(Selection)
            End Get
        End Property
#End Region
#Region "Events"
        Private ReadOnly Shared selectionChangedField As Object = New Object()
        Private ReadOnly Shared selectedValuesChangedField As Object = New Object()
        '
        Public Custom Event SelectionChanged As EventHandler
            AddHandler(value As EventHandler)
                Events.AddHandler(selectionChangedField, value)
            End AddHandler
            RemoveHandler(value As EventHandler)
                Events.RemoveHandler(selectionChangedField, value)
            End RemoveHandler
            RaiseEvent(sender As Object, e As EventArgs)
            End RaiseEvent
        End Event
        Protected Sub RaiseSelectionChanged()
            Dim handler = TryCast(Events(selectionChangedField), EventHandler)
            handler?.Invoke(Me, EventArgs.Empty)
        End Sub
        Public Custom Event SelectedValuesChanged As EventHandler
            AddHandler(value As EventHandler)
                Events.AddHandler(selectedValuesChangedField, value)
            End AddHandler
            RemoveHandler(value As EventHandler)
                Events.RemoveHandler(selectedValuesChangedField, value)
            End RemoveHandler
            RaiseEvent(sender As Object, e As EventArgs)
            End RaiseEvent
        End Event
        Protected Sub RaiseSelectedValuesChanged()
            Dim handler = TryCast(Events(selectedValuesChangedField), EventHandler)
            handler?.Invoke(Me, EventArgs.Empty)
        End Sub
#End Region
#Region "Theme"
        Protected Overrides Function LoadDefaultTemplate() As String
            Return ToggleButtonGroupHtmlCssAsset.Default.Html
        End Function
        Protected Overrides Function LoadDefaultStyles() As String
            Return ToggleButtonGroupHtmlCssAsset.Default.Css
        End Function
        Friend NotInheritable Class ToggleButtonGroupHtmlCssAsset
            Inherits HtmlCssAsset
            <Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Shared Sub New()
                Components.ItemsSelector.Register()
            End Sub
            Public Shared ReadOnly [Default] As HtmlCssAsset = New ToggleButtonGroupHtmlCssAsset()
        End Class
#End Region
#Region "API"
        Public Sub SelectAll()
            If Selection.Count = Items.Count Then Return
            Selection.Clear()
            For Each item As ButtonGroupItem In Items
                Selection.Add(item)
            Next
            OnSelectionChanged()
        End Sub
        Public Sub UnselectAll()
            If Selection.Count = 0 Then Return
            Selection.Clear()
            OnSelectionChanged()
        End Sub
        Public Shadows Sub [Select](item As ButtonGroupItem)
            If Selection.Add(item) Then OnSelectionChanged()
        End Sub
        Public Sub SelectValue(value As Object)
            Dim item = If(TryCast(value, ButtonGroupItem), Items.GetItemByValue(value))
            If item IsNot Nothing AndAlso Selection.Add(item) Then OnSelectionChanged()
        End Sub
        Public Sub Unselect(item As ButtonGroupItem)
            If Selection.Remove(item) Then OnSelectionChanged()
        End Sub
        Public Sub UnselectValue(value As Object)
            Dim item = If(TryCast(value, ButtonGroupItem), Items.GetItemByValue(value))
            If item IsNot Nothing AndAlso Selection.Remove(item) Then OnSelectionChanged()
        End Sub
        Public Function IsValueSelected(value As Object) As Boolean
            Dim item = TryCast(value, ButtonGroupItem)
            Return If(item IsNot Nothing, Selection.Contains(item), Selection.ContainsValue(value))
        End Function
        Protected Overridable Sub OnSelectionChanged()
            UpdateItemsSelectorSelection()
            RaiseSelectionChanged()
            RaiseSelectedValuesChanged()
        End Sub
#End Region
        Protected Overrides Function CreateHtmlEditorPreview() As ICustomDxHtmlPreview
            Dim previewControl = New ToggleButtonGroup()
            previewControl.Items.AddRange(New ButtonGroupItem() {New ButtonGroupItem(1, "One"), New ButtonGroupItem(2, "Two"), New ButtonGroupItem(3, "Three")})
            previewControl.[Select](previewControl.Items(0))
            Return previewControl
        End Function
    End Class
End Namespace
