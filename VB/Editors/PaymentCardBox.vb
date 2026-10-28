Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports UITemplatesExampleVB.Assets.Toolbox
Imports DevExpress.UITemplates.Collection.Images
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils
Imports DevExpress.Utils.Design
Imports DevExpress.Utils.Html
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Internal
Imports DevExpress.XtraEditors.Repository
Imports System.Runtime.InteropServices

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True)>
    <System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "PaymentCardBox.bmp")>
    <Description("A masked field used for credit card/payment information.")>
    Public Class PaymentCardBox
        Inherits HtmlTextBoxBase
        Protected Overrides Function CreateRepositoryItemCore() As RepositoryItem
            Return New PaymentCardBoxProperties()
        End Function
#Region "Properties"
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Overloads ReadOnly Property Properties As PaymentCardBoxProperties
            Get
                Return TryCast(BaseProperties, PaymentCardBoxProperties)
            End Get
        End Property
        <ComponentModel.Category(CategoryName.ToolTip)>
        Public Property ShowInvalidCardWarningToolTip As Boolean
            Get
                Return Properties.ShowInvalidCardWarningToolTip
            End Get
            Set(value As Boolean)
                Properties.ShowInvalidCardWarningToolTip = value
            End Set
        End Property
        Private Function ShouldSerializeShowInvalidCardWarningToolTip() As Boolean
            Return Properties.ShouldSerializeShowInvalidCardWarningToolTip()
        End Function
        Private Sub ResetShowInvalidCardWarningToolTip()
            Properties.ResetShowInvalidCardWarningToolTip()
        End Sub
        <ComponentModel.DefaultValueAttribute(GetType(String), Nothing), ComponentModel.Category(CategoryName.ToolTip)>
        Public Property InvalidCardWarningTitle As String
            Get
                Return Properties.InvalidCardWarningTitle
            End Get
            Set(value As String)
                Properties.InvalidCardWarningTitle = value
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
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        <Category("Data")>
        Public Property Card As PaymentCard
            Get
                Return TryCast(EditValue, PaymentCard)
            End Get
            Set(value As PaymentCard)
                EditValue = value
            End Set
        End Property
        <EditorBrowsable(EditorBrowsableState.Never), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Overrides Property EditValue As Object
            Get
                Return MyBase.EditValue
            End Get
            Set(value As Object)
                MyBase.EditValue = value
            End Set
        End Property
        Public Class PaymentCardBoxProperties
            Inherits HtmlTextBoxBaseProperties
            Public Overrides Function CreateEditor() As BaseEdit
                Return New PaymentCardBox()
            End Function
            Protected NotOverridable Overrides Function GetDefaultMaskManagerType() As Type
                Return GetType(PaymentCardMaskManager)
            End Function
            Protected NotOverridable Overrides ReadOnly Property ShouldCreateMaskSettingsWhenMaskLoadedOrUpdated As Boolean
                Get
                    Return True
                End Get
            End Property
            Protected NotOverridable Overrides Function GetUseMaskAsDisplayFormat() As Boolean
                Return True
            End Function
            Protected NotOverridable Overrides Function GetNullValuePrompt() As String
                Dim base = MyBase.GetNullValuePrompt()
                If String.IsNullOrEmpty(base) Then Return $"0000 0000 0000 0000{PaymentCard.Separator}MM/YY{PaymentCard.Separator}000"
                Return base
            End Function
            Private showInvalidCardWarningToolTipCore As Boolean?
            <DefaultValue(True)>
            Public Property ShowInvalidCardWarningToolTip As Boolean
                Get
                    Return showInvalidCardWarningToolTipCore.GetValueOrDefault(True)
                End Get
                Set(value As Boolean)
                    If ShowInvalidCardWarningToolTip = value Then Return
                    showInvalidCardWarningToolTipCore = value
                    OnPropertiesChanged(New PropertyChangedEventArgs(NameOf(PaymentCardBoxProperties.ShowInvalidCardWarningToolTip)))
                End Set
            End Property
            Protected Friend Function ShouldSerializeShowInvalidCardWarningToolTip() As Boolean
                Return showInvalidCardWarningToolTipCore.HasValue
            End Function
            Protected Friend Sub ResetShowInvalidCardWarningToolTip()
                showInvalidCardWarningToolTipCore = Nothing
            End Sub
            Private invalidCardWarningTitleCore As String
            <ComponentModel.DefaultValueAttribute(GetType(String), Nothing)>
            Public Property InvalidCardWarningTitle As String
                Get
                    Return invalidCardWarningTitleCore
                End Get
                Set(value As String)
                    If Equals(InvalidCardWarningTitle, value) Then Return
                    invalidCardWarningTitleCore = value
                    OnPropertiesChanged(New PropertyChangedEventArgs(NameOf(PaymentCardBoxProperties.InvalidCardWarningTitle)))
                End Set
            End Property
            Protected Friend Overridable Function GetInvalidCardWarningTitle() As String
                Return If(String.IsNullOrEmpty(InvalidCardWarningTitle), "Card data is invalid", InvalidCardWarningTitle)
            End Function
#Region "Icons"
            Protected Overrides Function CreateContextImageOptions() As ContextImageOptions
                Return New PaymentCardContextImageOptions(Me)
            End Function
            Friend NotInheritable Class PaymentCardContextImageOptions
                Inherits ContextImageOptions
                Private ReadOnly owner As PaymentCardBoxProperties
                Public Sub New(owner As PaymentCardBoxProperties)
                    Me.owner = owner
                    SvgImage = DataEntry.Card
                    SvgImageSize = New Size(16, 16)
                End Sub
                Protected Overrides Function ShouldSerializeSvgImage() As Boolean
                    Return MyBase.ShouldSerializeSvgImage() AndAlso Not ReferenceEquals(SvgImage, DataEntry.Card)
                End Function
                Protected Overrides Function ShouldSerializeSvgImageSize() As Boolean
                    Return MyBase.ShouldSerializeSvgImageSize() AndAlso (SvgImageSize <> New Size(16, 16))
                End Function
                <ThreadStatic>
                Private Shared glyphCache As Dictionary(Of Integer, Image)
                Protected Overrides Function GetImageFromSvg(userSvgImageSize As Size, scaleSvgImageSize As Boolean, palette As ISvgPaletteProvider) As Image
                    palette = CheckSvgPalette(palette)
                    Dim size As Size = GetSvgImageSize(SvgImage, SvgImageSize, userSvgImageSize, scaleSvgImageSize, ForcedScaleFactor)
                    Dim card = CType(owner.OwnerEdit, PaymentCardBox)?.Card
                    If card IsNot Nothing AndAlso card.CardType > PaymentCard.Type.Undefined AndAlso card.CardType < PaymentCard.Type.Invalid Then
                        If glyphCache Is Nothing Then glyphCache = New Dictionary(Of Integer, Image)(CardLogos.SvgImages.Count * 2)
                        Dim key As Integer = HashCodeHelper.Calculate(size.Width, size.Height, CInt(card.CardType))
                        Dim glyph As Image = Nothing
                        If Not glyphCache.TryGetValue(key, glyph) Then
                            glyph = New Bitmap(size.Width, size.Height, Imaging.PixelFormat.Format32bppArgb)
                            Dim svgImage = CardLogos.SvgImages(card.CardType.ToString())
                            Using g = Graphics.FromImage(glyph)
                                g.Clear(Color.Transparent)
                                Dim factor As Double = CDbl(svgImage.Height) / svgImage.Width
                                Dim offset As Single = CInt(Math.Ceiling((glyph.Height - factor * glyph.Width) / 2))
                                g.TranslateTransform(0, offset)
                                Dim svgBmp = DevExpress.Utils.Svg.SvgBitmap.Create(svgImage)
                                svgBmp.RenderToGraphics(g, palette, glyph.Width / svgImage.Width)
                            End Using
                            glyphCache.Add(key, glyph)
                        End If
                        Return glyph
                    End If
                    Return SvgBitmap.Render(size, palette)
                End Function
            End Class
#End Region
#Region "Parts"
            Protected Friend Function GetLeadingIconBounds() As Rectangle
                Return GetPartBounds(leadingIcon)
            End Function
            Protected Overrides Sub RaiseEditValueChanged(e As EventArgs)
                MyBase.RaiseEditValueChanged(e)
                Dim args = TryCast(e, XtraEditors.Controls.ChangingEventArgs)
                If args IsNot Nothing Then
                    Dim prevType = TryCast(args.OldValue, PaymentCard)?.CardType
                    Dim newType = TryCast(args.NewValue, PaymentCard)?.CardType
                    If prevType <> newType Then
                        InvalidatePart(leadingIcon)
                    End If
                End If
            End Sub
#End Region
#Region "Assets"
            Protected Overrides Function LoadDefaultStyles() As String
                Return PaymentCardBoxHtmlCssAsset.Default.Css
            End Function
            Protected Overrides Function LoadDefaultTemplate() As String
                Return PaymentCardBoxHtmlCssAsset.Default.Html
            End Function
            Friend NotInheritable Class PaymentCardBoxHtmlCssAsset
                Inherits HtmlCssAsset
                Public Shared ReadOnly [Default] As HtmlCssAsset = New PaymentCardBoxHtmlCssAsset()
            End Class
#End Region
        End Class
        Protected Overrides Sub OnEditValueChanging(e As ChangingEventArgs)
            MyBase.OnEditValueChanging(e)
            If Not e.Cancel AndAlso DoValidateCard(invalidCardWarningText) Then HideLeadingIconTooltip()
        End Sub
        Protected Overrides Sub OnValidatingCore(args As CancelEventArgs)
            MyBase.OnValidatingCore(args)
            If args.Cancel OrElse Card Is Nothing Then Return
            args.Cancel = Not DoValidateCard(invalidCardWarningText)

            If args.Cancel Then
                ErrorText = invalidCardWarningText
                If Properties.ShowInvalidCardWarningToolTip Then QueueWarningToolTip(New Action(AddressOf ShowInvalidCardWarning))
            End If
        End Sub
        Private invalidCardWarningText As String
        Private Function QueueWarningToolTip(Optional action As Action = Nothing) As Boolean
            If action Is Nothing AndAlso Properties.ShowInvalidCardWarningToolTip AndAlso Not DoValidateCard(invalidCardWarningText) Then action = New Action(AddressOf ShowInvalidCardWarning)
            If action IsNot Nothing AndAlso IsHandleCreated Then BeginInvoke(action)
            Return action IsNot Nothing
        End Function
        Protected Overridable Function DoValidateCard(<Out> ByRef errorText As String) As Boolean
            Return Me.DoValidateCard(Card, errorText)
        End Function
        Protected Overridable Function DoValidateCard(card As PaymentCard, <Out> ByRef errorText As String) As Boolean
            If card Is Nothing Then
                errorText = Nothing
                Return True
            End If
            Dim cardType = PaymentCardType.Validate(card.Number, errorText)
            Dim cardInvalid = (cardType = PaymentCard.Type.Invalid)
            If Not cardInvalid AndAlso Me.Card.ExpirationDate < Date.Now.Date Then
                errorText = "Your card is expired"
                cardInvalid = True
            End If
            If Not cardInvalid AndAlso If(Me.Card.CVC, String.Empty).Length <> 3 Then
                errorText = "CVC code is incomplete"
                cardInvalid = True
            End If
            Return Not cardInvalid AndAlso String.IsNullOrEmpty(errorText)
        End Function
        Protected Overridable Sub ShowInvalidCardWarning()
            Dim controller = GetToolTipController()
            If controller Is Nothing Then Return
            Dim title As String = Properties.GetInvalidCardWarningTitle()
            Dim showArgs = New ToolTipControllerShowEventArgs(Me, Me, invalidCardWarningText, title, WarningToolTipLocation, False, False, 0, ToolTipIconType.Warning, ToolTipIconSize.Small, Nothing, -1, controller.Appearance, controller.AppearanceTitle)
            showArgs.ToolTipType = ToolTipType.SuperTip
            showArgs.ObjectBounds = RectangleToScreen(Properties.GetLeadingIconBounds())
            ShowInvalidCardWarning(controller, showArgs)
        End Sub
        Protected Overridable Sub ShowInvalidCardWarning(controller As ToolTipController, showArgs As ToolTipControllerShowEventArgs)
            ShowLeadingIconTooltip(controller, showArgs)
        End Sub
        Protected Overrides Function QueryLeadingIconTooltip() As Boolean
            Return QueueWarningToolTip()
        End Function
        Protected Overrides Function CreateHtmlEditorPreview() As ICustomDxHtmlPreview
            Dim previewControl = New PaymentCardBox()
            previewControl.Properties.BeginUpdate()
            previewControl.Properties.HeaderLabel = If(String.IsNullOrEmpty(HeaderLabel), "{HeaderLabel}", HeaderLabel)
            previewControl.Properties.FooterLabel = If(String.IsNullOrEmpty(FooterLabel), "{FooterLabel}", FooterLabel)
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
