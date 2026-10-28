Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading.Tasks
Imports System.Windows.Forms
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
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils.Text

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True)>
    <System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "PhoneNumberBox.bmp")>
    <Description("A masked field used to enter phone numbers, with integrated country selector and auto-formatted user input.")>
    Public Class PhoneNumberBox
        Inherits HtmlLookUpBase
        Protected Overrides Function CreateRepositoryItemCore() As RepositoryItem
            Return New PhoneNumberBoxProperties()
        End Function
#Region "Properties"
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Overloads ReadOnly Property Properties As PhoneNumberBoxProperties
            Get
                Return TryCast(BaseProperties, PhoneNumberBoxProperties)
            End Get
        End Property
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property PhoneNumber As String
            Get
                Return TryCast(EditValue, String)
            End Get
            Set(value As String)
                EditValue = value
            End Set
        End Property
        <Browsable(False)>
        Public ReadOnly Property IsPhoneNumberInvalid As Boolean
            Get
                Dim phoneNumber As String = TryCast(EditValue, String)
                If String.IsNullOrEmpty(phoneNumber) Then Return False
                Return Not Utilities.PhoneNumber.Validate(phoneNumber, invalidPhoneNumberWarningText, currentCountryInfo)
            End Get
        End Property
        <ComponentModel.Category(CategoryName.ToolTip)>
        Public Property ShowInvalidPhoneNumberWarningToolTip As Boolean
            Get
                Return Properties.ShowInvalidPhoneNumberWarningToolTip
            End Get
            Set(value As Boolean)
                Properties.ShowInvalidPhoneNumberWarningToolTip = value
            End Set
        End Property
        Private Function ShouldSerializeShowInvalidPhoneNumberWarningToolTip() As Boolean
            Return Properties.ShouldSerializeShowInvalidPhoneNumberWarningToolTip()
        End Function
        Private Sub ResetShowInvalidPhoneNumberWarningToolTip()
            Properties.ResetShowInvalidPhoneNumberWarningToolTip()
        End Sub
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <Category("Appearance")>
        Public ReadOnly Property LeadingIconOptions As ContextImageOptions
            Get
                Return Properties.LeadingIconOptions
            End Get
        End Property
#End Region
        Public Class PhoneNumberBoxProperties
            Inherits HtmlLookUpBaseProperties
            Implements DevExpress.Utils.Text.IStringImageProvider
            Public Sub New()
                AddHandler AutoSuggest, AddressOf OnAutoSuggest
                AddHandler CustomDrawCell, AddressOf OnCustomDrawCell
                AddHandler GetNotInListValue, AddressOf OnGetNotInListValue
            End Sub
            Protected Overrides Sub Dispose(disposing As Boolean)
                RemoveHandler AutoSuggest, AddressOf OnAutoSuggest
                RemoveHandler CustomDrawCell, AddressOf OnCustomDrawCell
                RemoveHandler GetNotInListValue, AddressOf OnGetNotInListValue
                MyBase.Dispose(disposing)
            End Sub
            Public Overrides Sub PopulateColumns()
                BeginUpdate()
                Columns.Clear()
                Columns.Add(New LookUpColumnInfo("Phone"))
                EndUpdate()
            End Sub
            Public Overrides Function CreateEditor() As BaseEdit
                Return New PhoneNumberBox()
            End Function
            Protected NotOverridable Overrides Function GetDefaultMaskManagerType() As Type
                Return GetType(PhoneNumberMaskManager)
            End Function
            Protected NotOverridable Overrides ReadOnly Property ShouldCreateMaskSettingsWhenMaskLoadedOrUpdated As Boolean
                Get
                    Return True
                End Get
            End Property
            Protected NotOverridable Overrides Function GetUseMaskAsDisplayFormat() As Boolean
                Return True
            End Function
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
            Private showHeaderCore As Boolean?
            <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
            Public Overrides Property ShowHeader As Boolean
                Get
                    Return showHeaderCore.GetValueOrDefault()
                End Get
                Set(value As Boolean)
                    showHeaderCore = value
                End Set
            End Property
            Private Sub OnGetNotInListValue(sender As Object, e As GetNotInListValueEventArgs)
                If e.FieldName = "Phone" Then e.Value = PhoneNumberBoxProperties.GetPhone(TryCast(DataAdapter.GetRowByListSourceIndex(e.RecordIndex), Countries.Info))
            End Sub
            Private Sub OnAutoSuggest(sender As Object, e As LookUpEditAutoSuggestEventArgs)
                Dim currentCountry = CType(sender, PhoneNumberBox).currentCountryInfo
                Dim digits As String = Utilities.PhoneNumber.GetDigits(If(e.Text, String.Empty))
                If String.IsNullOrEmpty(digits) AndAlso Not String.IsNullOrEmpty(e.Text) Then
                    e.Cancel = True
                Else
                    e.QuerySuggestions = Task.Run(GetGetCountries(digits, currentCountry, e.CancellationToken))
                    e.SetHighlightRange(PhoneNumberBoxProperties.GetGetRangeFromDisplayText(digits, currentCountry))
                End If
            End Sub
            Private Sub OnCustomDrawCell(sender As Object, e As XtraEditors.Popup.LookUpCustomDrawCellArgs)
                Dim info = TryCast(e.Row, Countries.Info)
                If info IsNot Nothing Then
                    e.DrawHtmlText(PhoneNumberBoxProperties.GetHtmlRepresentation(info))
                    e.Handled = True
                End If
            End Sub
            Friend Shared Function GetGetCountries(digits As String, currentCountry As Countries.Info, cancellationToken As Threading.CancellationToken) As Func(Of ICollection)
                Dim startsWith As Func(Of String, Boolean) = Function(code) digits.StartsWith(code, StringComparison.OrdinalIgnoreCase) OrElse code.StartsWith(digits, StringComparison.OrdinalIgnoreCase)
                If String.IsNullOrEmpty(digits) OrElse PhoneNumberBoxProperties.IsCurrentCountry(digits, currentCountry) Then startsWith = Function(__) True
                Dim entries = Countries.All
                Return New Func(Of ICollection)(Function() entries.Where(Function(x)
                                                                             cancellationToken.ThrowIfCancellationRequested()
                                                                             Return startsWith(x.PhoneCodeDigits)
                                                                         End Function).ToList())
            End Function
            Friend Shared Function GetGetRangeFromDisplayText(digits As String, currentCountry As Countries.Info) As Func(Of String, DisplayTextHighlightRange?)
                If String.IsNullOrEmpty(digits) OrElse PhoneNumberBoxProperties.IsCurrentCountry(digits, currentCountry) Then Return Function(__) Nothing
                Return Function(code)
                           Dim codeStart = code.LastIndexOf("+"c)
                           Dim codeLength = Math.Min(digits.Length, code.Length - codeStart - 1)
                           Dim start = -1, [end] = -1, currentCodePos = codeStart + 1, currentDigitsPos = 0
                           While currentCodePos < code.Length
                               Dim c = code(currentCodePos)
                               If Char.IsDigit(c) Then
                                   If currentDigitsPos >= digits.Length OrElse digits(Math.Min(Threading.Interlocked.Increment(currentDigitsPos), currentDigitsPos - 1)) <> c Then Exit While
                                   If start < 0 Then start = currentCodePos
                                   [end] = currentCodePos + 1
                               End If

                               currentCodePos += 1
                           End While
                           If start < 0 Then Return Nothing
                           Return New DisplayTextHighlightRange(start, [end] - start)
                       End Function
            End Function
            Private Shared Function IsCurrentCountry(digits As String, currentCountry As Countries.Info) As Boolean
                Return currentCountry IsNot Nothing AndAlso String.Equals(digits, currentCountry.PhoneCodeDigits, StringComparison.OrdinalIgnoreCase)
            End Function
            Private Shared Function GetPhone(info As Countries.Info) As String
                Return $"{info.ISO2}{info.Country}+{info.PhoneCode}"
            End Function
            Friend Shared Function GetHtmlRepresentation(info As Countries.Info) As String
                Return $"<image={info.ISO2}><nbsp>{info.Country}<nbsp><color=@disabledtext>+{info.PhoneCode}</color>"
            End Function
            Protected Overrides Function GetDefaultSearchMode() As SearchMode
                Return SearchMode.AutoSuggest
            End Function
            Private showInvalidPhoneNumberWarningToolTipCore As Boolean?
            Public Property ShowInvalidPhoneNumberWarningToolTip As Boolean
                Get
                    Return showInvalidPhoneNumberWarningToolTipCore.GetValueOrDefault(True)
                End Get
                Set(value As Boolean)
                    If ShowInvalidPhoneNumberWarningToolTip = value Then Return
                    showInvalidPhoneNumberWarningToolTipCore = value
                    OnPropertiesChanged(New PropertyChangedEventArgs(NameOf(PhoneNumberBoxProperties.ShowInvalidPhoneNumberWarningToolTip)))
                End Set
            End Property
            Protected Friend Function ShouldSerializeShowInvalidPhoneNumberWarningToolTip() As Boolean
                Return showInvalidPhoneNumberWarningToolTipCore.HasValue
            End Function
            Protected Friend Sub ResetShowInvalidPhoneNumberWarningToolTip()
                showInvalidPhoneNumberWarningToolTipCore = Nothing
            End Sub
#Region "Icons"
            Private Function GetImage(id As String) As Image
                Dim scaleDpi = If(CType(OwnerEdit, PhoneNumberBox)?.ScaleDPI, DevExpress.Utils.DPI.ScaleHelper.NoScale)
                Dim imgSize = scaleDpi.ScaleSize(ContextImageOptions.SvgImageSize)
                Return CountryFlags.GetISO2GlyphOrFlag(LookAndFeel, id, imgSize)
            End Function
            Protected Overrides Function CreateContextImageOptions() As ContextImageOptions
                Return New PhoneNumberBoxContextImageOptions(Me)
            End Function
            <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
            Public ReadOnly Property LeadingIconOptions As ContextImageOptions
                Get
                    Return ContextImageOptions
                End Get
            End Property
            Friend NotInheritable Class PhoneNumberBoxContextImageOptions
                Inherits ContextImageOptions
                Private ReadOnly owner As PhoneNumberBoxProperties
                Public Sub New(owner As PhoneNumberBoxProperties)
                    Me.owner = owner
                    SvgImage = DataEntry.Phone
                    SvgImageSize = New Size(16, 16)
                End Sub
                Protected Overrides Function ShouldSerializeSvgImage() As Boolean
                    Return MyBase.ShouldSerializeSvgImage() AndAlso Not ReferenceEquals(SvgImage, DataEntry.Phone)
                End Function
                Protected Overrides Function ShouldSerializeSvgImageSize() As Boolean
                    Return MyBase.ShouldSerializeSvgImageSize() AndAlso (SvgImageSize <> New Size(16, 16))
                End Function
                Private ReadOnly Property ChoosenCountry As Countries.Info
                    Get
                        Return CType(owner.OwnerEdit, PhoneNumberBox)?.currentCountryInfo
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
            Protected Shared ReadOnly separator As Object = New Object()
            '
            Protected Overrides Sub FindParts(parts As Dictionary(Of Object, DxHtmlElement), root As DxHtmlRootElement)
                MyBase.FindParts(parts, root)
                parts(separator) = root.FindElementById(NameOf(separator))
            End Sub
            Protected Overrides Sub CalcPartsVisibility(parts As Dictionary(Of Object, DxHtmlElement), editValue As Object)
                MyBase.CalcPartsVisibility(parts, editValue)
                parts(separator).Hidden = Not IsDropDownIconVisible()
            End Sub
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
                Return PhoneNumberBoxHtmlCssAsset.Default.Css
            End Function
            Protected Overrides Function LoadDefaultTemplate() As String
                Return PhoneNumberBoxHtmlCssAsset.Default.Html
            End Function

            Private Function IStringImageProvider_GetImage(id As String) As Image Implements IStringImageProvider.GetImage
                Return GetImage(id)
            End Function

            Friend NotInheritable Class PhoneNumberBoxHtmlCssAsset
                Inherits HtmlCssAsset
                Public Shared ReadOnly [Default] As HtmlCssAsset = New PhoneNumberBoxHtmlCssAsset()
            End Class
#End Region
        End Class
        Protected Overrides Function QueryLeadingIconTooltip() As Boolean
            Return QueueWarningToolTip()
        End Function
        Protected Overrides Sub OnValidatingCore(args As CancelEventArgs)
            MyBase.OnValidatingCore(args)
            Dim phoneNumber As String = TryCast(EditValue, String)
            If args.Cancel OrElse String.IsNullOrEmpty(phoneNumber) Then Return
            args.Cancel = Not Utilities.PhoneNumber.Validate(phoneNumber, invalidPhoneNumberWarningText, currentCountryInfo)

            If args.Cancel Then
                ErrorText = invalidPhoneNumberWarningText
                If Properties.ShowInvalidPhoneNumberWarningToolTip Then QueueWarningToolTip(New Action(AddressOf ShowInvalidPhoneNumberWarning))
            End If
        End Sub
        Private invalidPhoneNumberWarningText As String
        Private Function QueueWarningToolTip(Optional action As Action = Nothing) As Boolean
            If action Is Nothing AndAlso Properties.ShowInvalidPhoneNumberWarningToolTip AndAlso IsPhoneNumberInvalid Then action = New Action(AddressOf ShowInvalidPhoneNumberWarning)
            If action IsNot Nothing AndAlso IsHandleCreated Then BeginInvoke(action)
            Return action IsNot Nothing
        End Function
        Protected Overridable Sub ShowInvalidPhoneNumberWarning()
            Dim controller = GetToolTipController()
            If controller Is Nothing Then Return
            Dim title = "Phone number is invalid"
            Dim showArgs = New ToolTipControllerShowEventArgs(Me, Me, invalidPhoneNumberWarningText, title, WarningToolTipLocation, False, False, 0, ToolTipIconType.Warning, ToolTipIconSize.Small, Nothing, -1, controller.Appearance, controller.AppearanceTitle)
            showArgs.ToolTipType = ToolTipType.SuperTip
            showArgs.ObjectBounds = RectangleToScreen(Properties.GetLeadingIconBounds())
            ShowInvalidPhoneNumberWarning(controller, showArgs)
        End Sub
        Protected Overridable Sub ShowInvalidPhoneNumberWarning(controller As ToolTipController, showArgs As ToolTipControllerShowEventArgs)
            ShowLeadingIconTooltip(controller, showArgs)
        End Sub
        Private currentCountryInfo As Countries.Info
        Protected Overrides Sub OnEditValueChanging(e As ChangingEventArgs)
            If Not e.Cancel Then e.NewValue = Utilities.PhoneNumber.EnsureCountry(e.NewValue, e.OldValue, currentCountryInfo)
            MyBase.OnEditValueChanging(e)
            If Not e.Cancel AndAlso Not IsPhoneNumberInvalid Then HideLeadingIconTooltip()
        End Sub
        Protected Overrides Function CreateHtmlEditorPreview() As ICustomDxHtmlPreview
            Dim previewControl = New PhoneNumberBox()
            previewControl.Properties.BeginUpdate()
            previewControl.Properties.HeaderLabel = If(String.IsNullOrEmpty(HeaderLabel), "{HeaderLabel}", HeaderLabel)
            previewControl.Properties.FooterLabel = If(String.IsNullOrEmpty(FooterLabel), "{FooterLabel}", FooterLabel)
            previewControl.Properties.Placeholder = If(String.IsNullOrEmpty(Placeholder), "{Placeholder}", Placeholder)
            previewControl.Properties.EndUpdate()
            Return previewControl
        End Function
#Region "AutoSuggest vs Mask"
        ' below we override some methods in order to avoid conflicts with masked input and autosuggest-autocompletion
        Protected Overrides Overloads Sub UpdateSearchTextOnAutoSuggest(args As LookUpEditSearchHighlightEventArgs, autoSuggestValueFound As Boolean)
            ' do nothing 
        End Sub
        Protected Overrides Overloads Sub UpdateSearchTextOnAutoSuggest(args As LookUpEditSearchHighlightEventArgs, helper As KeyPressHelper, keepSelection As Boolean?)
            ' do nothing 
        End Sub
        Protected Overrides Function IsAutoSearchCharHandled(helper As KeyPressHelper, eventArgs As KeyPressEventArgs) As Boolean
            Return False
        End Function
        Protected Overrides Function FindAutoSuggestValue(helper As KeyPressHelper) As Boolean
            Return False
        End Function
        Protected Overrides Function AcceptEditorTextAsPopupAutoSearchValue() As Boolean
            Return True
        End Function
        Protected Overrides Sub OnControllerValueChanged(controllerGetEditValue As Func(Of Object))
            BaseControllerValueChanged(controllerGetEditValue)
        End Sub
        Protected Overrides Sub OnControllerValueChanging(e As ChangingEventArgs)
            BaseControllerValueChanging(e)
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
#End Region
    End Class
End Namespace
