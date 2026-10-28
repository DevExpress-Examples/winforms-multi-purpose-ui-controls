Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports UITemplatesExampleVB.Assets.Toolbox
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils.Html
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Internal
Imports DevExpress.XtraEditors.Mask
Imports DevExpress.XtraEditors.Repository

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True), System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "EditBox.bmp")>
    <Description("A styled text input field.")>
    <DevExpress.Utils.Design.SmartTagFilter(GetType(HtmlTextBoxBase.HtmlTextBoxBaseFilterWithMask))>
    Public Class EditBox
        Inherits HtmlTextBoxBase
        Protected Overrides Function CreateRepositoryItemCore() As RepositoryItem
            Return New EditBoxProperties()
        End Function
#Region "Properties"
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Overloads ReadOnly Property Properties As EditBoxProperties
            Get
                Return TryCast(MyBase.Properties, EditBoxProperties)
            End Get
        End Property
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <Category("Appearance")>
        <Utils.Design.SmartTagProperty("LeadingIcon", "", 2, Utils.Design.SmartTagActionType.RefreshBoundsAfterExecute Or Utils.Design.SmartTagActionType.RefreshContentAfterExecute)>
        Public ReadOnly Property LeadingIconOptions As ContextImageOptions
            Get
                Return Properties.LeadingIconOptions
            End Get
        End Property
        <DefaultValue(CharacterCasing.Normal), Category("Behavior")>
        Public Overridable Property CharacterCasing As CharacterCasing
            Get
                Return Properties.CharacterCasing
            End Get
            Set(value As CharacterCasing)
                Properties.CharacterCasing = value
            End Set
        End Property
        <DefaultValue(0), Category("Text")>
        Public Overridable Property MaxLength As Integer
            Get
                Return Properties.MaxLength
            End Get
            Set(value As Integer)
                Properties.MaxLength = value
            End Set
        End Property
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <RefreshProperties(RefreshProperties.All)>
        <Editor("DevExpress.XtraEditors.Design.MaskSettingsDesigner, " & AssemblyInfo.SRAssemblyEditorsDesignFull, GetType(System.Drawing.Design.UITypeEditor))>
        <Category("Format")>
        Public Overridable ReadOnly Property MaskSettings As MaskSettings
            Get
                Return Properties.MaskSettings
            End Get
        End Property
#End Region
        Public Class EditBoxProperties
            Inherits HtmlTextBoxBaseProperties
            Public Overrides Function CreateEditor() As BaseEdit
                Return New EditBox()
            End Function
#Region "Icons"
            <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
            Public ReadOnly Property LeadingIconOptions As ContextImageOptions
                Get
                    Return ContextImageOptions
                End Get
            End Property
            Protected Overrides Function CreateContextImageOptions() As ContextImageOptions
                Return New EditBoxContextImageOptions()
            End Function
            Friend NotInheritable Class EditBoxContextImageOptions
                Inherits ContextImageOptions
                Public Sub New()
                    SvgImageSize = New Size(16, 16)
                End Sub
                Protected Overrides Function ShouldSerializeSvgImageSize() As Boolean
                    Return MyBase.ShouldSerializeSvgImageSize() AndAlso (SvgImageSize <> New Size(16, 16))
                End Function
            End Class
#End Region
#Region "Assets"
            Protected Overrides Function LoadDefaultStyles() As String
                Return EditBoxHtmlCssAsset.Default.Css
            End Function
            Protected Overrides Function LoadDefaultTemplate() As String
                Return EditBoxHtmlCssAsset.Default.Html
            End Function
            Friend NotInheritable Class EditBoxHtmlCssAsset
                Inherits HtmlCssAsset
                Public Shared ReadOnly [Default] As HtmlCssAsset = New EditBoxHtmlCssAsset()
            End Class
#End Region
        End Class
        Protected Overrides Function CreateHtmlEditorPreview() As ICustomDxHtmlPreview
            Dim previewControl = New EditBox()
            previewControl.Properties.BeginUpdate()
            previewControl.Properties.HeaderLabel = If(String.IsNullOrEmpty(HeaderLabel), "{HeaderLabel}", HeaderLabel)
            previewControl.Properties.FooterLabel = If(String.IsNullOrEmpty(FooterLabel), "{FooterLabel}", FooterLabel)
            previewControl.Properties.NullValuePrompt = If(String.IsNullOrEmpty(Placeholder), "{Placeholder}", Placeholder)
            previewControl.Properties.MaxLength = MaxLength
            previewControl.Properties.EndUpdate()
            Return previewControl
        End Function
    End Class
End Namespace
