Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.UITemplates.Collection.Components
Imports DevExpress.Utils
Imports DevExpress.Utils.Html

Namespace DevExpress.UITemplates.Collection.Editors

    <ComponentModel.DefaultEventAttribute("CheckedChanged")>
    Public MustInherit Class CheckButtonBase
        Inherits ButtonBase
        Protected Overrides Sub Dispose(disposing As Boolean)
            If buttonElement IsNot Nothing Then buttonElement.RemoveEventListener("checked-changed", AddressOf OnCheckedChanged)
            MyBase.Dispose(disposing)
        End Sub
        Protected Overrides Sub SetButtonElementSize(value As SizeType)
            If buttonElement IsNot Nothing Then buttonElement.SetAttribute(NameOf(CheckItemBase.ItemSize), CType(CInt(value), CheckItemBase.Size))
        End Sub
#Region "Properties"
        Private checkedQueuedValue, designModeValue As Boolean?
        <DefaultValue(False), Category("Data")>
        <Utils.Design.SmartTagProperty("Checked", "", 1, Utils.Design.SmartTagActionType.RefreshBoundsAfterExecute Or Utils.Design.SmartTagActionType.RefreshContentAfterExecute)>
        Public Property Checked As Boolean
            Get
                If DesignMode Then Return designModeValue.GetValueOrDefault()
                If buttonElement Is Nothing Then Return checkedQueuedValue.GetValueOrDefault()
                Dim checkItem = TryCast(buttonElement.GetAttribute("self"), CheckItemBase)
                Return checkItem IsNot Nothing AndAlso checkItem.IsChecked
            End Get
            Set(value As Boolean)
                If DesignMode Then designModeValue = value
                If Checked = value Then Return
                If buttonElement IsNot Nothing Then
                    buttonElement.SetAttribute(NameOf(CheckItemBase.IsChecked), value)
                Else
                    checkedQueuedValue = value
                End If
                OnCheckedChanged()
            End Set
        End Property
        Protected Overridable Sub OnCheckedChanged()
            RaiseCheckedChanged()
        End Sub
        Protected Overrides Sub OnKeyClick()
            Toggle()
            MyBase.OnKeyClick()
        End Sub
        Public Sub Toggle()
            If GetValidationCanceled() Then Return
            Checked = Not Checked
        End Sub
        Protected Overrides Sub OnMouseUp(e As System.Windows.Forms.MouseEventArgs)
            Dim dxArgs = DXMouseEventArgs.GetMouseArgs(e)
            dxArgs.Handled = GetValidationCanceled()
            MyBase.OnMouseUp(dxArgs)
        End Sub
#End Region
#Region "Parts"
        Protected ReadOnly Shared button As Object = New Object()
        Private buttonElement As DxHtmlElement
        Protected Overrides Sub FindParts(parts As Dictionary(Of Object, DxHtmlElement), root As DxHtmlRootElement)
            MyBase.FindParts(parts, root)
            buttonElement = root.FindElementById(NameOf(button))
            buttonElement.SetAttribute(NameOf(CheckItemBase.Template), GetButtonContentTemplateId())
            If checkedQueuedValue.GetValueOrDefault() Then
                buttonElement.SetAttribute(NameOf(CheckItemBase.IsChecked), True)
                checkedQueuedValue = Nothing
            End If
            Dim iSize = CType(CInt(ButtonSize), CheckItemBase.Size)
            If iSize <> CheckItemBase.Size.[Default] Then buttonElement.SetAttribute(NameOf(CheckItemBase.ItemSize), iSize)
            buttonElement.AddEventListener("checked-changed", AddressOf OnCheckedChanged)
            parts(icon) = buttonElement.FindElementById(NameOf(icon))
            parts(button) = buttonElement
        End Sub
        Protected Overrides Function OnGotFocus(parts As Dictionary(Of Object, DxHtmlElement), root As DxHtmlRootElement) As Boolean
            If buttonElement IsNot Nothing Then buttonElement.Focus(True)
            Return buttonElement IsNot Nothing
        End Function
        Protected Overrides Function OnLostFocus(parts As Dictionary(Of Object, DxHtmlElement), root As DxHtmlRootElement) As Boolean
            If buttonElement IsNot Nothing Then buttonElement.Focus(False)
            Return buttonElement IsNot Nothing
        End Function
#End Region
#Region "Events"
        Private ReadOnly Shared checkedChangedField As Object = New Object()
        '
        Public Custom Event CheckedChanged As EventHandler
            AddHandler(value As EventHandler)
                Events.AddHandler(checkedChangedField, value)
            End AddHandler
            RemoveHandler(value As EventHandler)
                Events.RemoveHandler(checkedChangedField, value)
            End RemoveHandler
            RaiseEvent(sender As Object, e As EventArgs)
            End RaiseEvent
        End Event
        Protected Sub RaiseCheckedChanged()
            Dim handler = TryCast(Events(checkedChangedField), EventHandler)
            handler?.Invoke(Me, EventArgs.Empty)
        End Sub
#End Region
#Region "Theme"
        Protected MustOverride Function GetButtonContentTemplateId() As String
#End Region
#Region "API"
        Protected Sub EnsureButtonContentTemplate()
            If buttonElement IsNot Nothing Then
                Dim currentTemplateId = GetButtonContentTemplateId()
                buttonElement.SetAttribute(NameOf(CheckItemBase.Template), currentTemplateId)
            End If
        End Sub
#End Region
    End Class
End Namespace
