Imports System.ComponentModel
Imports UITemplatesExampleVB.Assets.Toolbox
Imports DevExpress.UITemplates.Collection.Components
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils
Imports DevExpress.Utils.Html

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True)>
    <System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "ToggleButton.bmp")>
    <Description("A toggle button used to select one of two mutually exclusive options/values.")>
    Public Class ToggleButton
        Inherits CheckButtonBase
#Region "Properties"
        Public Enum Position
            Inside
            Outside
            None
        End Enum
        Private textPositionCore As Position = Position.Outside
        <DefaultValue(Position.Outside), Category("Text")>
        <Utils.Design.SmartTagProperty("Text Position", "", 1, Utils.Design.SmartTagActionType.RefreshBoundsAfterExecute Or Utils.Design.SmartTagActionType.RefreshContentAfterExecute)>
        Public Property TextPosition As Position
            Get
                Return textPositionCore
            End Get
            Set(value As Position)
                If textPositionCore = value Then Return
                textPositionCore = value
                OnPropertiesChanged()
            End Set
        End Property
        Private checkedTextCore As String
        <ComponentModel.DefaultValueAttribute(GetType(String), Nothing), Category("Text")>
        <Utils.Design.SmartTagProperty("Checked Text", "", 1, Utils.Design.SmartTagActionType.RefreshBoundsAfterExecute Or Utils.Design.SmartTagActionType.RefreshContentAfterExecute)>
        Public Property CheckedText As String
            Get
                Return checkedTextCore
            End Get
            Set(value As String)
                If Equals(checkedTextCore, value) Then Return
                checkedTextCore = value
                OnPropertiesChanged()
            End Set
        End Property
        Private uncheckedTextCore As String
        <ComponentModel.DefaultValueAttribute(GetType(String), Nothing), Category("Text")>
        <Utils.Design.SmartTagProperty("Unchecked Text", "", 1, Utils.Design.SmartTagActionType.RefreshBoundsAfterExecute Or Utils.Design.SmartTagActionType.RefreshContentAfterExecute)>
        Public Property UncheckedText As String
            Get
                Return uncheckedTextCore
            End Get
            Set(value As String)
                If Equals(uncheckedTextCore, value) Then Return
                uncheckedTextCore = value
                OnPropertiesChanged()
            End Set
        End Property
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)>
        Public Overrides Property Text As String
            Get
                If TextPosition <> Position.None Then
                    If Checked Then
                        Return If(checkedTextCore, "ON")
                    Else
                        Return If(uncheckedTextCore, "OFF")
                    End If
                End If
                Return String.Empty
            End Get
            Set(value As String)
            End Set
        End Property
#End Region
#Region "Theme"
        Protected Overrides Function GetPartText(partName As String, element As DxHtmlElementBase) As String
            If Equals(partName, "InsideText") Then Return If(TextPosition = Position.Inside, Text, Nothing)
            If Equals(partName, "OutsideText") Then Return If(TextPosition = Position.Outside, Text, Nothing)
            Return MyBase.GetPartText(partName, element)
        End Function
        Protected Overrides Sub OnIconImageOptionsChanged(sender As Object, args As ImageOptionsChangedEventArgs)
            MyBase.OnIconImageOptionsChanged(sender, args)
            EnsureButtonContentTemplate()
        End Sub
        Protected Overrides Function GetButtonContentTemplateId() As String
            Return If(IconImageOptions.HasImage, "toggle-button-image-template", "toggle-button-template")
        End Function
        Protected Overrides Function LoadDefaultTemplate() As String
            Return ToggleButtonHtmlCssAsset.Default.Html
        End Function
        Protected Overrides Function LoadDefaultStyles() As String
            Return ToggleButtonHtmlCssAsset.Default.Css
        End Function
        Friend NotInheritable Class ToggleButtonHtmlCssAsset
            Inherits HtmlCssAsset
            Shared Sub New()
                CheckItemBase.Register()
            End Sub
            Public Shared ReadOnly [Default] As HtmlCssAsset = New ToggleButtonHtmlCssAsset()
        End Class
#End Region
        Protected Overrides Function CreateHtmlEditorPreview() As ICustomDxHtmlPreview
            Dim previewControl = New ToggleButton()
            previewControl.TextPosition = TextPosition
            previewControl.CheckedText = If(String.IsNullOrEmpty(CheckedText), "{CheckedText}", CheckedText)
            previewControl.UncheckedText = If(String.IsNullOrEmpty(UncheckedText), "{CheckedText}", UncheckedText)
            previewControl.IconImageOptions.Assign(IconImageOptions)
            Return previewControl
        End Function
    End Class
End Namespace
