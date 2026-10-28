Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports UITemplatesExampleVB.Assets.Toolbox
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils
Imports DevExpress.Utils.Html

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True)>
    <System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "Button.bmp")>
    <Description("A styled, simple button.")>
    Public Class Button
        Inherits ButtonBase
        Implements IButtonControl
        Private dialogResultCore As DialogResult
        <System.ComponentModel.Category(XtraEditors.CategoryName.Behavior), DefaultValue(DialogResult.None)>
        Public Property DialogResult As DialogResult Implements IButtonControl.DialogResult
            Get
                Return dialogResultCore
            End Get
            Set(value As DialogResult)
                If dialogResultCore = value Then Return
                dialogResultCore = value
                OnPropertiesChanged()
            End Set
        End Property
        Protected Overrides Sub OnIconImageOptionsChanged(sender As Object, args As ImageOptionsChangedEventArgs)
            MyBase.OnIconImageOptionsChanged(sender, args)
            If Not isSimpleButton Then UpdatePartVisibility(icon)
            If AutoSize Then AdjustSize()
        End Sub
        Protected Overrides Sub OnButtonSizeChanged(value As SizeType)
            MyBase.OnButtonSizeChanged(value)
            If Not isSimpleButton Then InvalidatePart(button)
            If AutoSize Then AdjustSize()
        End Sub
        Protected Overrides Sub SetButtonElementSize(value As SizeType)
            If Not isSimpleButton AndAlso buttonElement IsNot Nothing Then buttonElement.ClassName = buttonClassNameOriginal & " " & value.ToString().ToLowerInvariant()
        End Sub
        Private isSimpleButton As Boolean
        Protected ReadOnly Shared button As Object = New Object()
        Private buttonClassNameOriginal As String
        Private buttonElement As DxHtmlElement
        Protected Overrides Sub FindParts(parts As Dictionary(Of Object, DxHtmlElement), root As DxHtmlRootElement)
            MyBase.FindParts(parts, root)
            parts(button) = root.FindElementById(NameOf(button))
            Dim simpleButtonElement = root.FindElementsByTag("dx-simple-button").FirstOrDefault()
            isSimpleButton = simpleButtonElement IsNot Nothing
            buttonElement = If(parts(button), simpleButtonElement)
            If buttonElement IsNot Nothing Then buttonClassNameOriginal = buttonElement.ClassName
            SetButtonElementSize(ButtonSize)
        End Sub
        Protected Overrides Sub CalcPartsVisibility(parts As Dictionary(Of Object, DxHtmlElement))
            If Not isSimpleButton Then MyBase.CalcPartsVisibility(parts)
        End Sub
        Protected Overrides Function OnGotFocus(parts As Dictionary(Of Object, DxHtmlElement), root As DxHtmlRootElement) As Boolean
            If buttonElement IsNot Nothing Then buttonElement.Focus(True)
            Return buttonElement IsNot Nothing
        End Function
        Protected Overrides Function OnLostFocus(parts As Dictionary(Of Object, DxHtmlElement), root As DxHtmlRootElement) As Boolean
            If buttonElement IsNot Nothing Then buttonElement.Focus(False)
            Return buttonElement IsNot Nothing
        End Function
        Protected Overrides Function IsIconVisible() As Boolean
            Return Not isSimpleButton AndAlso IconImageOptions.HasImage
        End Function
        Public Sub NotifyDefault(value As Boolean) Implements IButtonControl.NotifyDefault
            ' TODO
        End Sub
        Public Sub PerformClick() Implements IButtonControl.PerformClick
            PerformClickCore()
        End Sub
        Protected Overrides Sub OnClick(e As EventArgs)
            Dim form As Form = FindForm()
            If form IsNot Nothing Then form.DialogResult = DialogResult
            If ShouldNotifyAccessibilityClients Then
                NotifyAccessibilityClients(AccessibleEvents.StateChange, -1)
                NotifyAccessibilityClients(AccessibleEvents.NameChange, -1)
            End If
            MyBase.OnClick(e)
        End Sub
#Region "Theme"
        Protected Overrides Function LoadDefaultTemplate() As String
            Return ButtonHtmlCssAsset.Default.Html
        End Function
        Protected Overrides Function LoadDefaultStyles() As String
            Return ButtonHtmlCssAsset.Default.Css
        End Function
        Friend NotInheritable Class ButtonHtmlCssAsset
            Inherits HtmlCssAsset
            Public Shared ReadOnly [Default] As HtmlCssAsset = New ButtonHtmlCssAsset()
        End Class
#End Region
        Protected Overrides Function CreateHtmlEditorPreview() As ICustomDxHtmlPreview
            Dim previewControl = New Button()
            previewControl.Text = If(String.IsNullOrEmpty(Text), "{Text}", Text)
            previewControl.IconImageOptions.Assign(IconImageOptions)
            Return previewControl
        End Function
    End Class
End Namespace
