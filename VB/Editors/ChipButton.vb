Imports System.ComponentModel
Imports System.Drawing
Imports UITemplatesExampleVB.Assets.Toolbox
Imports DevExpress.UITemplates.Collection.Components
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils.Html

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True)>
    <System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "ChipButton.bmp")>
    <Description("Chips are compact but highly functional visual elements that allow users to make selections, filter content, or trigger actions.")>
    Public Class ChipButton
        Inherits CheckButtonBase
#Region "Properties"
        Private showCheckCore As Boolean = True
        <DefaultValue(True)>
        <Category("Appearance")>
        <Utils.Design.SmartTagProperty("ShowCheck", "", 2, Utils.Design.SmartTagActionType.RefreshBoundsAfterExecute Or Utils.Design.SmartTagActionType.RefreshContentAfterExecute)>
        Public Property ShowCheck As Boolean
            Get
                Return showCheckCore
            End Get
            Set(value As Boolean)
                If showCheckCore = value Then Return
                showCheckCore = value
                OnShowCheckChanged()
            End Set
        End Property
        Protected Overridable Sub OnShowCheckChanged()
            OnPropertiesChanged()
            EnsureButtonContentTemplate()
            If Checked AndAlso AutoSize Then AdjustSize()
        End Sub
        Protected Overrides Sub OnCheckedChanged()
            MyBase.OnCheckedChanged()
            If ShowCheck AndAlso AutoSize Then AdjustSize()
        End Sub
        Protected Overrides Sub OnIconImageOptionsChanged(sender As Object, args As ImageOptionsChangedEventArgs)
            MyBase.OnIconImageOptionsChanged(sender, args)
            UpdatePartVisibility(icon)
        End Sub
#End Region
#Region "Parts"
        Protected Overrides Function GetPartImage(partName As String, state As ObjectState, element As DxHtmlElementBase) As Object
            If Equals(partName, "Check") Then Return Collection.Images.UIElements.Check
            Return MyBase.GetPartImage(partName, state, element)
        End Function
#End Region
#Region "Theme"
        Protected Overrides Function GetButtonContentTemplateId() As String
            Return If(ShowCheck, "chip-button-check-template", "chip-button-template")
        End Function
        Protected Overrides Function LoadDefaultTemplate() As String
            Return ChipButtonHtmlCssAsset.Default.Html
        End Function
        Protected Overrides Function LoadDefaultStyles() As String
            Return ChipButtonHtmlCssAsset.Default.Css
        End Function
        Friend NotInheritable Class ChipButtonHtmlCssAsset
            Inherits HtmlCssAsset
            Shared Sub New()
                CheckItemBase.Register()
            End Sub
            Public Shared ReadOnly [Default] As HtmlCssAsset = New ChipButtonHtmlCssAsset()
        End Class
#End Region
        Protected Overrides Function CreateHtmlEditorPreview() As ICustomDxHtmlPreview
            Dim previewControl = New ChipButton()
            previewControl.Text = If(String.IsNullOrEmpty(Text), "{Text}", Text)
            previewControl.IconImageOptions.Assign(IconImageOptions)
            Return previewControl
        End Function
    End Class
End Namespace
