Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Threading.Tasks
Imports DevExpress.Data
Imports UITemplatesExampleVB.Assets.Toolbox
Imports DevExpress.UITemplates.Collection.Images
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils
Imports DevExpress.Utils.Design
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils.Html
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Internal
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils.Text

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True)>
    <System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "CountryChooser.bmp")>
    <Description("A predesigned drop-down editor that allows users to quickly choose from over 200 countries.")>
    Public Class CountryChooser
        Inherits HtmlLookUpBase
        Protected Overrides Function CreateRepositoryItemCore() As RepositoryItem
            Return New CountryChooserProperties()
        End Function
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property Country As String
            Get
                Return TryCast(EditValue, String)
            End Get
            Set(value As String)
                EditValue = value
            End Set
        End Property
#Region "Properties"
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Overloads ReadOnly Property Properties As CountryChooserProperties
            Get
                Return TryCast(BaseProperties, CountryChooserProperties)
            End Get
        End Property
        <ComponentModel.Category(CategoryName.ToolTip)>
        Public Property ShowCountryToolTip As Boolean
            Get
                Return Properties.ShowCountryToolTip
            End Get
            Set(value As Boolean)
                Properties.ShowCountryToolTip = value
            End Set
        End Property
        Private Function ShouldSerializeShowCountryToolTip() As Boolean
            Return Properties.ShouldSerializeShowCountryToolTip()
        End Function
        Private Sub ResetShowCountryToolTip()
            Properties.ResetShowCountryToolTip()
        End Sub
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <Category("Appearance")>
        Public ReadOnly Property LeadingIconOptions As ContextImageOptions
            Get
                Return Properties.ContextImageOptions
            End Get
        End Property
#End Region
        Public Class CountryChooserProperties
            Inherits HtmlLookUpBaseProperties
            Implements DevExpress.Utils.Text.IStringImageProvider
            Public Sub New()
                AddHandler AutoSuggest, AddressOf OnAutoSuggest
                AddHandler CustomDrawCell, AddressOf OnCustomDrawCell
            End Sub
            Protected Overrides Sub Dispose(disposing As Boolean)
                RemoveHandler AutoSuggest, AddressOf OnAutoSuggest
                RemoveHandler CustomDrawCell, AddressOf OnCustomDrawCell
                MyBase.Dispose(disposing)
            End Sub
            Private showFooterCore As Boolean?
            <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
            Public Overrides Property ShowFooter As Boolean
                Get
                    Return showFooterCore.GetValueOrDefault()
                End Get
                Set(value As Boolean)
                    showFooterCore = value
                End Set
            End Property
            Private Sub OnAutoSuggest(sender As Object, e As LookUpEditAutoSuggestEventArgs)
                Dim currentCountry = CType(sender, CountryChooser).currentCountryInfo
                e.QuerySuggestions = Task.Run(GetGetCountries(e.Text, currentCountry, e.CancellationToken))
                e.SetHighlightRange(GetGetRangeFromDisplayText(e.Text, currentCountry))
            End Sub
            Private Sub OnCustomDrawCell(sender As Object, e As LookUpCustomDrawCellArgs)
                Dim info = Countries.GetCountryByName(TryCast(e.RowKey, String))
                If info IsNot Nothing Then
                    e.DrawHtmlText(GetHtmlRepresentation(info))
                    e.Handled = True
                End If
            End Sub
            Friend Shared Function GetGetCountries(text As String, currentCountry As Countries.Info, cancellationToken As Threading.CancellationToken) As Func(Of ICollection)
                Dim entries = Countries.All
                Dim contains = If(Not CountryChooserProperties.IsCurrentCountry(text, currentCountry), IgnoreCaseComparisonFunctions.GetContains(CultureInfo.CurrentCulture.CompareInfo, CompareOptions.IgnoreCase, text), New Func(Of String, Boolean)(Function(__) True))
                Return New Func(Of ICollection)(Function() entries.[Select](Function(x) x.Country).Where(Function(x)
                                                                                                             cancellationToken.ThrowIfCancellationRequested()
                                                                                                             Return contains(x)
                                                                                                         End Function).ToList())
            End Function
            Friend Shared Function GetGetRangeFromDisplayText(text As String, currentCountry As Countries.Info) As Func(Of String, DisplayTextHighlightRange?)
                If CountryChooserProperties.IsCurrentCountry(text, currentCountry) Then Return Function(__) Nothing
                Dim indexOf = IgnoreCaseComparisonFunctions.GetIndexOf(CultureInfo.CurrentCulture.CompareInfo, CompareOptions.IgnoreCase, text)
                Return Function(country)
                           Dim index As Integer = indexOf(country)
                           If index = -1 Then Return Nothing
                           Return New DisplayTextHighlightRange(index + 1, text.Length)
                       End Function
            End Function
            Private Shared Function IsCurrentCountry(text As String, currentCountry As Countries.Info) As Boolean
                Return currentCountry IsNot Nothing AndAlso String.Equals(text, currentCountry.Country, StringComparison.OrdinalIgnoreCase)
            End Function
            Friend Shared Function GetHtmlRepresentation(info As Countries.Info) As String
                Return $"<image={info.ISO2}><nbsp>{info.Country}<nbsp><color=@disabledtext>{info.ISO3}</color>"
            End Function
            Public Overrides Function CreateEditor() As BaseEdit
                Return New CountryChooser()
            End Function
            Protected Overrides Function GetDefaultSearchMode() As SearchMode
                Return SearchMode.AutoSuggest
            End Function
            Private showCountryToolTipCore As Boolean?
            <ComponentModel.Category(CategoryName.ToolTip)>
            Public Property ShowCountryToolTip As Boolean
                Get
                    Return showCountryToolTipCore.GetValueOrDefault(True)
                End Get
                Set(value As Boolean)
                    If ShowCountryToolTip = value Then Return
                    showCountryToolTipCore = value
                    OnPropertiesChanged(New PropertyChangedEventArgs(NameOf(CountryChooserProperties.ShowCountryToolTip)))
                End Set
            End Property
            Protected Friend Function ShouldSerializeShowCountryToolTip() As Boolean
                Return showCountryToolTipCore.HasValue
            End Function
            Protected Friend Sub ResetShowCountryToolTip()
                showCountryToolTipCore = Nothing
            End Sub
#Region "Icons"
            Protected Overrides Function CreateContextImageOptions() As ContextImageOptions
                Return New CountrySelectorContextImageOptions(Me)
            End Function
            Private Function GetImage(id As String) As Image
                Dim scaleDpi = If(CType(OwnerEdit, CountryChooser)?.ScaleDPI, DevExpress.Utils.DPI.ScaleHelper.NoScale)
                Dim imgSize = scaleDpi.ScaleSize(ContextImageOptions.SvgImageSize)
                Return CountryFlags.GetISO2GlyphOrFlag(LookAndFeel, id, imgSize)
            End Function
            Friend NotInheritable Class CountrySelectorContextImageOptions
                Inherits ContextImageOptions
                Private ReadOnly owner As CountryChooserProperties
                Public Sub New(owner As CountryChooserProperties)
                    Me.owner = owner
                    SvgImage = DataEntry.World
                    SvgImageSize = New Size(16, 16)
                End Sub
                Protected Overrides Function ShouldSerializeSvgImage() As Boolean
                    Return MyBase.ShouldSerializeSvgImage() AndAlso Not ReferenceEquals(SvgImage, DataEntry.World)
                End Function
                Protected Overrides Function ShouldSerializeSvgImageSize() As Boolean
                    Return MyBase.ShouldSerializeSvgImageSize() AndAlso (SvgImageSize <> New Size(16, 16))
                End Function
                Private ReadOnly Property ChoosenCountry As Countries.Info
                    Get
                        Return CType(owner.OwnerEdit, CountryChooser)?.currentCountryInfo
                    End Get
                End Property
                Protected Overrides Function GetImageFromSvg(userSvgImageSize As Size, scaleSvgImageSize As Boolean, palette As ISvgPaletteProvider) As Image
                    palette = CheckSvgPalette(palette)
                    Dim size As Size = GetSvgImageSize(SvgImage, SvgImageSize, userSvgImageSize, scaleSvgImageSize, ForcedScaleFactor)
                    Dim choosenCountry = Me.ChoosenCountry
                    If choosenCountry IsNot Nothing Then Return CountryFlags.GetISO2GlyphOrFlag(owner.LookAndFeel, choosenCountry.ISO2, size, palette)
                    Return SvgBitmap.Render(size, palette)
                End Function
            End Class
#End Region
#Region "Parts"
            Protected Overrides Function GetPartImage(partName As String, state As ObjectState) As Object
                If Equals(partName, "DropDownIcon") Then Return UIElements.DropDown
                Return MyBase.GetPartImage(partName, state)
            End Function
            Protected Friend Function GetLeadingIconBounds() As Rectangle
                Return GetPartBounds(leadingIcon)
            End Function
            Protected Overrides Function IsDropDownIconVisible() As Boolean
                Return Countries.All.Count > 0
            End Function
#End Region
#Region "Assets"
            Protected Overrides Function LoadDefaultStyles() As String
                Return CountryChooserHtmlCssAsset.Default.Css
            End Function
            Protected Overrides Function LoadDefaultTemplate() As String
                Return CountryChooserHtmlCssAsset.Default.Html
            End Function

            Private Function IStringImageProvider_GetImage(id As String) As Image Implements IStringImageProvider.GetImage
                Return GetImage(id)
            End Function

            Friend NotInheritable Class CountryChooserHtmlCssAsset
                Inherits HtmlCssAsset
                Public Shared ReadOnly [Default] As HtmlCssAsset = New CountryChooserHtmlCssAsset()
            End Class
#End Region
        End Class
        Protected Overrides Function QueryLeadingIconTooltip() As Boolean
            Return QueueToolTip()
        End Function
        Private Function QueueToolTip(Optional action As Action = Nothing) As Boolean
            Dim country As String = TryCast(EditValue, String)
            If action Is Nothing AndAlso Properties.ShowCountryToolTip AndAlso currentCountryInfo IsNot Nothing Then action = New Action(AddressOf ShowCountryInformation)
            If action IsNot Nothing AndAlso IsHandleCreated Then BeginInvoke(action)
            Return action IsNot Nothing
        End Function
        Protected Overridable Sub ShowCountryInformation()
            Dim controller = GetToolTipController()
            If controller Is Nothing Then Return
            Dim information As String = $"Continent: {currentCountryInfo.Continent}<br>" & $"Capital: {currentCountryInfo.Capital}<br>".ToString() & $"Currency: {currentCountryInfo.Currency}"
            Dim showArgs = New ToolTipControllerShowEventArgs(Me, Me, information, currentCountryInfo.Country, WarningToolTipLocation, False, False, 0, ToolTipIconType.None, ToolTipIconSize.Small, Nothing, -1, controller.Appearance, controller.AppearanceTitle)
            showArgs.ToolTipType = ToolTipType.SuperTip
            showArgs.ObjectBounds = RectangleToScreen(Properties.GetLeadingIconBounds())
            ShowCountryInformation(controller, showArgs)
        End Sub
        Protected Overridable Sub ShowCountryInformation(controller As ToolTipController, showArgs As ToolTipControllerShowEventArgs)
            ShowLeadingIconTooltip(controller, showArgs)
        End Sub
        Protected Overrides Sub ShowAutoSuggestPopup(args As LookUpEditAutoSuggestEventArgs)
            MyBase.ShowAutoSuggestPopup(args)
            HideLeadingIconTooltip()
        End Sub
        Private currentCountryInfo As Countries.Info
        Protected Overrides Sub OnEditValueChanging(e As ChangingEventArgs)
            If Not e.Cancel Then
                Dim country As String = TryCast(e.NewValue, String)
                If Not String.IsNullOrEmpty(country) Then
                    currentCountryInfo = Countries.GetCountryByName(country)
                Else
                    currentCountryInfo = Nothing
                End If
            End If
            MyBase.OnEditValueChanging(e)
        End Sub
        Protected Overrides Function CreateHtmlEditorPreview() As ICustomDxHtmlPreview
            Dim previewControl = New CountryChooser()
            previewControl.Properties.BeginUpdate()
            previewControl.Properties.HeaderLabel = If(String.IsNullOrEmpty(HeaderLabel), "{HeaderLabel}", HeaderLabel)
            previewControl.Properties.FooterLabel = If(String.IsNullOrEmpty(FooterLabel), "{FooterLabel}", FooterLabel)
            previewControl.Properties.NullValuePrompt = If(String.IsNullOrEmpty(Placeholder), "{Placeholder}", Placeholder)
            previewControl.Properties.EndUpdate()
            Return previewControl
        End Function
    End Class
End Namespace
