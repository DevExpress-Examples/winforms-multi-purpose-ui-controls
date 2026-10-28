Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports UITemplatesExampleVB.Assets.Toolbox
Imports DevExpress.UITemplates.Collection.Images
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils
Imports DevExpress.Utils.Html
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Internal
Imports DevExpress.XtraEditors.Repository

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True)>
    <System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "EmailBox.bmp")>
    <Description("A predesigned email input field with automatic email address validation and error indication.")>
    Public Class EmailBox
        Inherits HtmlTextBoxBase
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Overloads ReadOnly Property Properties As EmailBoxProperties
            Get
                Return TryCast(MyBase.Properties, EmailBoxProperties)
            End Get
        End Property
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property Email As String
            Get
                Return TryCast(EditValue, String)
            End Get
            Set(value As String)
                EditValue = value
            End Set
        End Property
        <Browsable(False)>
        Public ReadOnly Property IsEmailInvalid As Boolean
            Get
                Dim email As String = Text
                If String.IsNullOrEmpty(email) Then Return False
                Return Not Utilities.Email.Validate(email, invalidEmailWarningText)
            End Get
        End Property
        Protected Overrides Function CreateRepositoryItemCore() As RepositoryItem
            Return New EmailBoxProperties()
        End Function
#Region "Properties"
        <ComponentModel.Category(CategoryName.ToolTip)>
        Public Property ShowInvalidEmailWarningToolTip As Boolean
            Get
                Return Properties.ShowInvalidEmailWarningToolTip
            End Get
            Set(value As Boolean)
                Properties.ShowInvalidEmailWarningToolTip = value
            End Set
        End Property
        Private Function ShouldSerializeShowInvalidEmailWarningToolTip() As Boolean
            Return Properties.ShouldSerializeShowInvalidEmailWarningToolTip()
        End Function
        Private Sub ResetShowInvalidEmailWarningToolTip()
            Properties.ResetShowInvalidEmailWarningToolTip()
        End Sub
        <ComponentModel.DefaultValueAttribute(GetType(String), Nothing), ComponentModel.Category(CategoryName.ToolTip)>
        Public Property InvalidEmailWarningTitle As String
            Get
                Return Properties.InvalidEmailWarningTitle
            End Get
            Set(value As String)
                Properties.InvalidEmailWarningTitle = value
            End Set
        End Property
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <Category("Appearance")>
        Public ReadOnly Property LeadingIconOptions As ContextImageOptions
            Get
                Return Properties.ContextImageOptions
            End Get
        End Property
#End Region
        Public Class EmailBoxProperties
            Inherits HtmlTextBoxBaseProperties
            Public Overrides Function CreateEditor() As BaseEdit
                Return New EmailBox()
            End Function
            Private showInvalidEmailWarningToolTipCore As Boolean?
            <DefaultValue(True)>
            Public Property ShowInvalidEmailWarningToolTip As Boolean
                Get
                    Return showInvalidEmailWarningToolTipCore.GetValueOrDefault(True)
                End Get
                Set(value As Boolean)
                    If ShowInvalidEmailWarningToolTip = value Then Return
                    showInvalidEmailWarningToolTipCore = value
                    OnPropertiesChanged(New PropertyChangedEventArgs(NameOf(EmailBoxProperties.ShowInvalidEmailWarningToolTip)))
                End Set
            End Property
            Protected Friend Function ShouldSerializeShowInvalidEmailWarningToolTip() As Boolean
                Return showInvalidEmailWarningToolTipCore.HasValue
            End Function
            Protected Friend Sub ResetShowInvalidEmailWarningToolTip()
                showInvalidEmailWarningToolTipCore = Nothing
            End Sub
            Private invalidEmailWarningTitleCore As String
            <ComponentModel.DefaultValueAttribute(GetType(String), Nothing)>
            Public Property InvalidEmailWarningTitle As String
                Get
                    Return invalidEmailWarningTitleCore
                End Get
                Set(value As String)
                    If Equals(InvalidEmailWarningTitle, value) Then Return
                    invalidEmailWarningTitleCore = value
                    OnPropertiesChanged(New PropertyChangedEventArgs(NameOf(EmailBoxProperties.InvalidEmailWarningTitle)))
                End Set
            End Property
            Protected Friend Overridable Function GetInvalidEmailWarningTitle() As String
                Return If(String.IsNullOrEmpty(InvalidEmailWarningTitle), "Email address is invalid", InvalidEmailWarningTitle)
            End Function
#Region "Icons"
            Protected Overrides Function CreateContextImageOptions() As ContextImageOptions
                Return New EmailContextImageOptions()
            End Function
            Friend NotInheritable Class EmailContextImageOptions
                Inherits ContextImageOptions
                Public Sub New()
                    SvgImage = DataEntry.Email
                    SvgImageSize = New Size(16, 16)
                End Sub
                Protected Overrides Function ShouldSerializeSvgImage() As Boolean
                    Return MyBase.ShouldSerializeSvgImage() AndAlso Not ReferenceEquals(SvgImage, DataEntry.Email)
                End Function
                Protected Overrides Function ShouldSerializeSvgImageSize() As Boolean
                    Return MyBase.ShouldSerializeSvgImageSize() AndAlso (SvgImageSize <> New Size(16, 16))
                End Function
            End Class
#End Region
#Region "Parts"
            Protected Friend Function GetLeadingIconBounds() As Rectangle
                Return GetPartBounds(leadingIcon)
            End Function
#End Region
#Region "Assets"
            Protected Overrides Function LoadDefaultStyles() As String
                Return EmailBoxHtmlCssAsset.Default.Css
            End Function
            Protected Overrides Function LoadDefaultTemplate() As String
                Return EmailBoxHtmlCssAsset.Default.Html
            End Function
            Friend NotInheritable Class EmailBoxHtmlCssAsset
                Inherits HtmlCssAsset
                Public Shared ReadOnly [Default] As HtmlCssAsset = New EmailBoxHtmlCssAsset()
            End Class
#End Region
        End Class
        Protected Overrides Sub OnEditValueChanging(e As ChangingEventArgs)
            MyBase.OnEditValueChanging(e)
            If Not e.Cancel AndAlso Not IsEmailInvalid Then HideLeadingIconTooltip()
        End Sub
        Protected Overrides Sub OnValidatingCore(args As CancelEventArgs)
            MyBase.OnValidatingCore(args)
            Dim email As String = Text
            If args.Cancel OrElse String.IsNullOrEmpty(email) Then Return
            args.Cancel = Not Utilities.Email.Validate(email, invalidEmailWarningText)

            If args.Cancel Then
                ErrorText = invalidEmailWarningText
                If Properties.ShowInvalidEmailWarningToolTip Then QueueWarningToolTip(New Action(AddressOf ShowInvalidEmailWarning))
            End If
        End Sub
        Private invalidEmailWarningText As String
        Private Function QueueWarningToolTip(Optional action As Action = Nothing) As Boolean
            If action Is Nothing AndAlso Properties.ShowInvalidEmailWarningToolTip AndAlso IsEmailInvalid Then action = New Action(AddressOf ShowInvalidEmailWarning)
            If action IsNot Nothing AndAlso IsHandleCreated Then BeginInvoke(action)
            Return action IsNot Nothing
        End Function
        Protected Overridable Sub ShowInvalidEmailWarning()
            Dim controller = GetToolTipController()
            If controller Is Nothing Then Return
            Dim title As String = Properties.GetInvalidEmailWarningTitle()
            Dim showArgs = New ToolTipControllerShowEventArgs(Me, Me, invalidEmailWarningText, title, WarningToolTipLocation, False, False, 0, ToolTipIconType.Warning, ToolTipIconSize.Small, Nothing, -1, controller.Appearance, controller.AppearanceTitle)
            showArgs.ToolTipType = ToolTipType.SuperTip
            showArgs.ObjectBounds = RectangleToScreen(Properties.GetLeadingIconBounds())
            ShowInvalidEmailWarning(controller, showArgs)
        End Sub
        Protected Overridable Sub ShowInvalidEmailWarning(controller As ToolTipController, showArgs As ToolTipControllerShowEventArgs)
            ShowLeadingIconTooltip(controller, showArgs)
        End Sub
        Protected Overrides Function QueryLeadingIconTooltip() As Boolean
            Return QueueWarningToolTip()
        End Function
        Protected Overrides Function CreateHtmlEditorPreview() As ICustomDxHtmlPreview
            Dim previewControl = New EmailBox()
            previewControl.Properties.BeginUpdate()
            previewControl.Properties.HeaderLabel = If(String.IsNullOrEmpty(HeaderLabel), "{HeaderLabel}", HeaderLabel)
            previewControl.Properties.FooterLabel = If(String.IsNullOrEmpty(FooterLabel), "{FooterLabel}", FooterLabel)
            previewControl.Properties.NullValuePrompt = If(String.IsNullOrEmpty(Placeholder), "{Placeholder}", Placeholder)
            previewControl.Properties.EndUpdate()
            Return previewControl
        End Function

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
