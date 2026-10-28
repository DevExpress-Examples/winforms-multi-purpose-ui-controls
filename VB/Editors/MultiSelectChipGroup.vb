Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports UITemplatesExampleVB.Assets.Toolbox
Imports DevExpress.UITemplates.Collection.Components
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils.Html

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True)>
    <System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "MultiSelectChipGroup.bmp")>
    <Description("A chip group with multi value selection support.")>
    Public Class MultiSelectChipGroup
        Inherits ChipGroupBase
        Private ReadOnly selectionCore As Chip.Selection = New Chip.Selection()
        Protected Overrides Sub Dispose(disposing As Boolean)
            selectionCore.Clear()
            MyBase.Dispose(disposing)
        End Sub
        Protected Overrides Sub SetupItemsSelector(selectorElement As DxHtmlElement)
            selectorElement.SetAttribute(NameOf(ItemsSelector.IsMultiSelect), True)
            selectorElement.SetAttribute(NameOf(ItemsSelector.Selection), Selection)
        End Sub
        Protected Overrides Sub OnItemsSelectorSelectionChanged(args As DxHtmlElementEventArgs)
            RaiseSelectionChanged()
            RaiseSelectedValuesChanged()
        End Sub
#Region "Properties"
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public ReadOnly Property Selection As Chip.Selection
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
            Return MultiSelectChipGroupHtmlCssAsset.Default.Html
        End Function
        Protected Overrides Function LoadDefaultStyles() As String
            Return MultiSelectChipGroupHtmlCssAsset.Default.Css
        End Function
        Friend NotInheritable Class MultiSelectChipGroupHtmlCssAsset
            Inherits HtmlCssAsset
            <Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Shared Sub New()
                ItemsSelector.Register()
            End Sub
            Public Shared ReadOnly [Default] As HtmlCssAsset = New MultiSelectChipGroupHtmlCssAsset()
        End Class
#End Region
#Region "API"
        Public Sub SelectAll()
            If Selection.Count = Items.Count Then Return
            Selection.Clear()
            For Each item As Chip In Items
                Selection.Add(item)
            Next
            OnSelectionChanged()
        End Sub
        Public Sub UnselectAll()
            If Selection.Count = 0 Then Return
            Selection.Clear()
            OnSelectionChanged()
        End Sub
        Public Shadows Sub [Select](item As Chip)
            If Selection.Add(item) Then OnSelectionChanged()
        End Sub
        Public Sub SelectValue(value As Object)
            Dim item = If(TryCast(value, Chip), Items.GetItemByValue(value))
            If item IsNot Nothing AndAlso Selection.Add(item) Then OnSelectionChanged()
        End Sub
        Public Sub Unselect(item As Chip)
            If Selection.Remove(item) Then OnSelectionChanged()
        End Sub
        Public Sub UnselectValue(value As Object)
            Dim item = If(TryCast(value, Chip), Items.GetItemByValue(value))
            If item IsNot Nothing AndAlso Selection.Remove(item) Then OnSelectionChanged()
        End Sub
        Public Function IsValueSelected(value As Object) As Boolean
            Dim item = TryCast(value, Chip)
            Return If(item IsNot Nothing, Selection.Contains(item), Selection.ContainsValue(value))
        End Function
        Protected Overridable Sub OnSelectionChanged()
            UpdateItemsSelectorSelection()
            RaiseSelectionChanged()
            RaiseSelectedValuesChanged()
        End Sub
#End Region
        Protected Overrides Function CreateHtmlEditorPreview() As ICustomDxHtmlPreview
            Dim previewControl = New MultiSelectChipGroup()
            previewControl.Items.AddRange(New Chip() {New Chip(1, "One"), New Chip(2, "Two"), New Chip(3, "Three")})
            previewControl.[Select](previewControl.Items(0))
            Return previewControl
        End Function
    End Class
End Namespace
