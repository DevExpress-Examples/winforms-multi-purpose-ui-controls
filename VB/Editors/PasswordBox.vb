Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports UITemplatesExampleVB.Assets.Toolbox
Imports DevExpress.UITemplates.Collection.Images
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils
Imports DevExpress.Utils.Design
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils.Html
Imports DevExpress.Utils.Svg
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Internal
Imports DevExpress.XtraEditors.Repository

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True)>
    <System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "PasswordBox.bmp")>
    <Description("A masked field used to enter passwords with integrated password strength indication.")>
    Public Class PasswordBox
        Inherits HtmlTextBoxBase
        Protected Overrides Function CreateRepositoryItemCore() As RepositoryItem
            Return New PasswordBoxProperties()
        End Function
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Overloads ReadOnly Property Properties As PasswordBoxProperties
            Get
                Return TryCast(MyBase.Properties, PasswordBoxProperties)
            End Get
        End Property
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Public Property Password As String
            Get
                Return TryCast(EditValue, String)
            End Get
            Set(value As String)
                EditValue = value
            End Set
        End Property
        <Browsable(False)>
        Public ReadOnly Property IsPasswordWeak As Boolean
            Get
                Dim strength = Utilities.Password.Check(TryCast(EditValue, String))
                Return strength > Utilities.Password.Strength.Blank AndAlso strength < Utilities.Password.Strength.Strong
            End Get
        End Property
#Region "Properties"
        <DefaultValue(False), ComponentModel.Category(CategoryName.Appearance)>
        Public Property ShowStrengthIndicator As Boolean
            Get
                Return Properties.ShowStrengthIndicator
            End Get
            Set(value As Boolean)
                Properties.ShowStrengthIndicator = value
            End Set
        End Property
        <ComponentModel.Category(CategoryName.ToolTip)>
        Public Property ShowPasswordWeaknessWarningToolTip As Boolean
            Get
                Return Properties.ShowPasswordWeaknessWarningToolTip
            End Get
            Set(value As Boolean)
                Properties.ShowPasswordWeaknessWarningToolTip = value
            End Set
        End Property
        Private Function ShouldSerializeShowPasswordWeaknessWarningToolTip() As Boolean
            Return Properties.ShouldSerializeShowPasswordWeaknessWarningToolTip()
        End Function
        Private Sub ResetShowPasswordWeaknessWarningToolTip()
            Properties.ResetShowPasswordWeaknessWarningToolTip()
        End Sub
        <ComponentModel.Category(CategoryName.ToolTip)>
        Public Property ShowCapsLockWarningToolTip As Boolean
            Get
                Return Properties.ShowCapsLockWarningToolTip
            End Get
            Set(value As Boolean)
                Properties.ShowCapsLockWarningToolTip = value
            End Set
        End Property
        Private Function ShouldSerializeShowCapsLockWarningToolTip() As Boolean
            Return Properties.ShouldSerializeShowCapsLockWarningToolTip()
        End Function
        Private Sub ResetShowCapsLockWarningToolTip()
            Properties.ResetShowCapsLockWarningToolTip()
        End Sub
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <Category("Appearance")>
        Public ReadOnly Property LeadingIconOptions As ContextImageOptions
            Get
                Return Properties.ContextImageOptions
            End Get
        End Property
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <Category("Appearance")>
        Public ReadOnly Property TrailingIconOptions As ContextImageOptions
            Get
                Return Properties.TrailingIconOptions
            End Get
        End Property
#End Region
        Protected Overrides Sub OnGotFocus(e As EventArgs)
            MyBase.OnGotFocus(e)
            If Properties.ShowCapsLockWarningToolTip AndAlso IsCapsLockOn Then QueueWarningToolTip(New Action(AddressOf ShowCapsLockWarning))
        End Sub
        Protected Overrides Sub OnEditValueChanging(e As ChangingEventArgs)
            MyBase.OnEditValueChanging(e)
            If Not e.Cancel AndAlso Not IsPasswordWeak Then HideLeadingIconTooltip()
        End Sub
        Protected Overrides Sub OnValidatingCore(e As CancelEventArgs)
            MyBase.OnValidatingCore(e)
            If e.Cancel OrElse Not IsModified Then Return
            If Properties.ShowPasswordWeaknessWarningToolTip AndAlso IsPasswordWeak Then QueueWarningToolTip(New Action(AddressOf ShowPasswordWeaknessWarning))
        End Sub
        Protected Overridable Sub ShowCapsLockWarning()
            Dim controller = GetToolTipController()
            If controller Is Nothing Then Return
            Dim title = "Caps Lock is On"
            Dim text = "Having Caps Lock on may cause you to enter your password incorrectly. You should press Caps Lock to turn it off before entering your password."
            Dim showArgs = New ToolTipControllerShowEventArgs(Me, Me, text, title, WarningToolTipLocation, False, False, 0, ToolTipIconType.Warning, ToolTipIconSize.Small, Nothing, -1, controller.Appearance, controller.AppearanceTitle)
            showArgs.ToolTipType = ToolTipType.SuperTip
            If WarningTooltipAnchor = EditToolTipAnchor.LeadingIcon Then showArgs.ObjectBounds = RectangleToScreen(Properties.GetLeadingIconBounds())
            ShowCapsLockWarning(controller, showArgs)
        End Sub
        Protected Overridable Sub ShowCapsLockWarning(controller As ToolTipController, showArgs As ToolTipControllerShowEventArgs)
            ShowLeadingIconTooltip(controller, showArgs)
        End Sub
        Protected Overridable Sub ShowPasswordWeaknessWarning()
            Dim controller = GetToolTipController()
            If controller Is Nothing Then Return
            Dim title = "Password is Weak"
            Dim text = "A strong password should contain at least 8 characters, including upper and lowercase letters, digits and special characters."
            Dim showArgs = New ToolTipControllerShowEventArgs(Me, Me, text, title, WarningToolTipLocation, False, False, 0, ToolTipIconType.Warning, ToolTipIconSize.Small, Nothing, -1, controller.Appearance, controller.AppearanceTitle)
            showArgs.ToolTipType = ToolTipType.SuperTip
            If WarningTooltipAnchor = EditToolTipAnchor.LeadingIcon Then showArgs.ObjectBounds = RectangleToScreen(Properties.GetLeadingIconBounds())
            ShowPasswordWeaknessWarning(controller, showArgs)
        End Sub
        Protected Overridable Sub ShowPasswordWeaknessWarning(controller As ToolTipController, showArgs As ToolTipControllerShowEventArgs)
            ShowLeadingIconTooltip(controller, showArgs)
        End Sub
        Private Function QueueWarningToolTip(Optional action As Action = Nothing) As Boolean
            If action Is Nothing AndAlso Properties.ShowPasswordWeaknessWarningToolTip AndAlso IsPasswordWeak Then action = New Action(AddressOf ShowPasswordWeaknessWarning)
            If action Is Nothing AndAlso Properties.ShowCapsLockWarningToolTip AndAlso IsCapsLockOn Then action = New Action(AddressOf ShowCapsLockWarning)
            If action IsNot Nothing AndAlso IsHandleCreated Then BeginInvoke(action)
            Return action IsNot Nothing
        End Function
        Protected Overrides Function QueryLeadingIconTooltip() As Boolean
            Return QueueWarningToolTip()
        End Function
        Public Class PasswordBoxProperties
            Inherits HtmlTextBoxBaseProperties
            Private trailingIconOptionsCore As ContextImageOptions
            Private ReadOnly passwordShowingActionRef As Action(Of Object)
            Public Sub New()
                trailingIconOptionsCore = CreateTrailingIconOptions()
                passwordShowingActionRef = New Action(Of Object)(AddressOf OnPasswordShowing)
            End Sub
            Protected Overrides Sub Dispose(disposing As Boolean)
                CancelPasswordShowing()
                DevExpress.Utils.DisposeHelper.Dispose(trailingIconOptionsCore)
                MyBase.Dispose(disposing)
            End Sub
            Public Overrides Function CreateEditor() As BaseEdit
                Return New PasswordBox()
            End Function
            Protected Overrides ReadOnly Property IsPasswordBox As Boolean
                Get
                    Return True
                End Get
            End Property
            <DefaultValue("●"c)>
            Public Overrides Property PasswordChar As Char
                Get
                    Return If(fPasswordChar = ChrW(0), "●"c, fPasswordChar)
                End Get
                Set(value As Char)
                    MyBase.PasswordChar = value
                End Set
            End Property
            Private showStrengthIndicatorCore As Boolean = False
            <DefaultValue(False)>
            Public Property ShowStrengthIndicator As Boolean
                Get
                    Return showStrengthIndicatorCore
                End Get
                Set(value As Boolean)
                    If showStrengthIndicatorCore = value Then Return
                    showStrengthIndicatorCore = value
                    OnPropertiesChanged(New PropertyChangedEventArgs(NameOf(PasswordBoxProperties.ShowStrengthIndicator)))
                End Set
            End Property
            Private showPasswordWeaknessWarningToolTipCore As Boolean?
            Public Property ShowPasswordWeaknessWarningToolTip As Boolean
                Get
                    Return showPasswordWeaknessWarningToolTipCore.GetValueOrDefault(ShowStrengthIndicator)
                End Get
                Set(value As Boolean)
                    If ShowPasswordWeaknessWarningToolTip = value Then Return
                    showPasswordWeaknessWarningToolTipCore = value
                    OnPropertiesChanged(New PropertyChangedEventArgs(NameOf(PasswordBoxProperties.ShowPasswordWeaknessWarningToolTip)))
                End Set
            End Property
            Protected Friend Function ShouldSerializeShowPasswordWeaknessWarningToolTip() As Boolean
                Return showPasswordWeaknessWarningToolTipCore.HasValue
            End Function
            Protected Friend Sub ResetShowPasswordWeaknessWarningToolTip()
                showPasswordWeaknessWarningToolTipCore = Nothing
            End Sub
            Private showCapsLockWarningToolTipCore As Boolean?
            Public Property ShowCapsLockWarningToolTip As Boolean
                Get
                    Return showCapsLockWarningToolTipCore.GetValueOrDefault(True)
                End Get
                Set(value As Boolean)
                    If ShowCapsLockWarningToolTip = value Then Return
                    showCapsLockWarningToolTipCore = value
                    OnPropertiesChanged(New PropertyChangedEventArgs(NameOf(PasswordBoxProperties.ShowCapsLockWarningToolTip)))
                End Set
            End Property
            Protected Friend Function ShouldSerializeShowCapsLockWarningToolTip() As Boolean
                Return showCapsLockWarningToolTipCore.HasValue
            End Function
            Protected Friend Sub ResetShowCapsLockWarningToolTip()
                showCapsLockWarningToolTipCore = Nothing
            End Sub
#Region "Icons"
            <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
            Public ReadOnly Property TrailingIconOptions As ContextImageOptions
                Get
                    Return trailingIconOptionsCore
                End Get
            End Property
            Protected Overridable Function CreateTrailingIconOptions() As ContextImageOptions
                Return New PasswordTrailingIconOptions(Me)
            End Function
            Protected Overrides Function CreateContextImageOptions() As ContextImageOptions
                Return New PasswordLeadingIconOptions()
            End Function
            Friend MustInherit Class PasswordBoxIconOptions
                Inherits ContextImageOptions
                Protected Sub New()
                    MyBase.SvgImage = GetDefaultIcon()
                    SvgImageSize = GetDefaultIconSize()
                End Sub
                Protected Overridable Function GetDefaultIconSize() As Size
                    Return New Size(16, 16)
                End Function
                Protected Overrides Function ShouldSerializeSvgImage() As Boolean
                    Return MyBase.ShouldSerializeSvgImage() AndAlso Not ReferenceEquals(SvgImage, GetDefaultIcon())
                End Function
                Protected Overrides Function ShouldSerializeSvgImageSize() As Boolean
                    Return MyBase.ShouldSerializeSvgImageSize() AndAlso (SvgImageSize <> GetDefaultIconSize())
                End Function
                Protected MustOverride Function GetDefaultIcon() As SvgImage
            End Class
            Friend NotInheritable Class PasswordLeadingIconOptions
                Inherits PasswordBoxIconOptions
                Protected Overrides Function GetDefaultIcon() As SvgImage
                    Return DataEntry.Key
                End Function
            End Class
            Friend NotInheritable Class PasswordTrailingIconOptions
                Inherits PasswordBoxIconOptions
                Private ReadOnly owner As PasswordBoxProperties
                Private ReadOnly SvgBitmapInverted As SvgBitmap
                Public Sub New(owner As PasswordBoxProperties)
                    Me.owner = owner
                    SvgBitmapInverted = SvgBitmap.Create(UIElements.Hide)
                End Sub
                Protected Overrides Function GetDefaultIcon() As SvgImage
                    Return UIElements.Show
                End Function
                Protected Overrides Function GetImageFromSvg(userSvgImageSize As Size, scaleSvgImageSize As Boolean, palette As ISvgPaletteProvider) As Image
                    palette = CheckSvgPalette(palette)
                    If Not owner.IsPasswordVisible Then Return SvgBitmap.Render(GetSvgImageSize(SvgImage, SvgImageSize, userSvgImageSize, scaleSvgImageSize, ForcedScaleFactor), palette)
                    Return SvgBitmapInverted.Render(GetSvgImageSize(UIElements.Hide, SvgImageSize, userSvgImageSize, scaleSvgImageSize, ForcedScaleFactor), palette)
                End Function
            End Class
#End Region
#Region "Parts"
            Protected ReadOnly Shared strengthIndicator As Object = New Object()
            '
            Protected Overrides Sub FindParts(parts As Dictionary(Of Object, DxHtmlElement), root As DxHtmlRootElement)
                parts(trailingIcon) = root.FindElementById(NameOf(trailingIcon))
                trailingIconElement = parts(trailingIcon)
                parts(strengthIndicator) = root.FindElementById(NameOf(strengthIndicator))
                MyBase.FindParts(parts, root)
            End Sub
            Private trailingIconClassNameOriginal As String
            Protected Overrides Sub InitializePartsOriginalClassNames()
                If trailingIconElement IsNot Nothing Then trailingIconClassNameOriginal = trailingIconElement.ClassName
                MyBase.InitializePartsOriginalClassNames()
            End Sub
            Private trailingIconElement As DxHtmlElement
            Protected Overrides Sub SetEditorSizeForParts(value As EditSize)
                Dim sizeClassModifier = value.ToString().ToLowerInvariant()
                If trailingIconElement IsNot Nothing Then trailingIconElement.ClassName = trailingIconClassNameOriginal & " trailing-icon-" & sizeClassModifier
                MyBase.SetEditorSizeForParts(value)
            End Sub
            Protected Overrides Sub CalcPartsVisibility(parts As Dictionary(Of Object, DxHtmlElement), editValue As Object)
                MyBase.CalcPartsVisibility(parts, editValue)
                parts(trailingIcon).Hidden = Not IsTrailingIconVisible(editValue)
                parts(strengthIndicator).Hidden = Not IsStrengthIndicatorVisible(editValue)
            End Sub
            Protected Overrides Function CalcPartBounds(parts As Dictionary(Of Object, DxHtmlElement), partKey As Object) As Rectangle
                If Equals(partKey, trailingIcon) Then Return parts(trailingIcon).AbsoluteBounds
                Return MyBase.CalcPartBounds(parts, partKey)
            End Function
            Protected Overrides Function GetPartImage(partName As String, state As ObjectState) As Object
                If Equals(partName, "TrailingIcon") Then Return TrailingIconOptions.GetImage(LookAndFeel, state)
                Return MyBase.GetPartImage(partName, state)
            End Function
            Protected Overridable Function IsTrailingIconVisible(editValue As Object) As Boolean
                Return TrailingIconOptions.HasImage AndAlso Not IsEmptyValue(editValue)
            End Function
            Protected Overridable Function IsStrengthIndicatorVisible(editValue As Object) As Boolean
                Return ShowStrengthIndicator
            End Function
            Protected Overrides Function OnPartClick(args As DxHtmlElementMouseEventArgs) As Boolean
                If IsPasswordVisibilityIcon(args) Then Return TogglePasswordVisibility()
                Return MyBase.OnPartClick(args)
            End Function
            Private Function IsPasswordVisibilityIcon(args As DxHtmlElementEventArgs) As Boolean
                Return IsTrailingIcon(args)
            End Function
            Private isPasswordVisibilityIconPressed As Integer
            Protected Overrides Function OnPartMouseDown(args As DxHtmlElementMouseEventArgs) As Boolean
                If IsPasswordVisibilityIcon(args) Then
                    If 0 = Math.Min(Threading.Interlocked.Increment(isPasswordVisibilityIconPressed), isPasswordVisibilityIconPressed - 1) Then
                        If Not isPasswordVisibleByVisibilityMode Then StartPasswordShowing()
                    End If
                End If
                Return MyBase.OnPartMouseDown(args)
            End Function
            Protected Overrides Function OnPartMouseUp(args As DxHtmlElementMouseEventArgs) As Boolean
                If IsPasswordVisibilityIcon(args) Then
                    If Threading.Interlocked.Decrement(isPasswordVisibilityIconPressed) = 0 Then
                        CancelPasswordShowing()
                        UpdatePasswordVisibility()
                    End If
                End If
                Return MyBase.OnPartMouseUp(args)
            End Function
            Protected ReadOnly Property IsPasswordVisible As Boolean
                Get
                    Return isPasswordVisibleByTimer OrElse isPasswordVisibleByVisibilityMode
                End Get
            End Property
            Private Sub CancelPasswordShowing()
                DevExpress.Utils.DTimer.Current.RemoveTimer(passwordShowingActionRef)
                isPasswordVisibleByTimer = False
            End Sub
            Private isPasswordVisibleByVisibilityMode, isPasswordVisibleByTimer As Boolean
            Protected Overridable Sub StartPasswordShowing()
                DevExpress.Utils.DTimer.Current.AddTimer(passwordShowingActionRef, 500)
            End Sub
            Private Sub OnPasswordShowing(sender As Object)
                DevExpress.Utils.DTimer.Current.RemoveTimer(passwordShowingActionRef)
                isPasswordVisibleByTimer = isPasswordVisibilityIconPressed > 0
                UpdatePasswordVisibility()
            End Sub
            Protected Overridable Function TogglePasswordVisibility() As Boolean
                If Not isPasswordVisibleByTimer Then
                    CancelPasswordShowing()
                    isPasswordVisibleByVisibilityMode = Not isPasswordVisibleByVisibilityMode
                    UpdatePasswordVisibility()
                    Return True
                End If
                Return False
            End Function
            Private Sub UpdatePasswordVisibility()
                InvokeControllerAction(AddressOf TogglePasswordVisibility)
            End Sub
            Private Sub TogglePasswordVisibility(controller As XtraEditors.TextEditController.TextEditController)
                If controller.ShowPassword = IsPasswordVisible Then Return
                controller.TogglePasswordVisibility()
                InvalidatePart(trailingIcon)
            End Sub
            Private prevStrength As Integer
            Protected Overrides Sub RaiseEditValueChanged(e As EventArgs)
                MyBase.RaiseEditValueChanged(e)
                Dim args = TryCast(e, XtraEditors.Controls.ChangingEventArgs)
                If args IsNot Nothing Then
                    Dim strength As Integer = CInt(Utilities.Password.Check(TryCast(args.NewValue, String)))
                    If strength <> prevStrength Then UpdatePart(strengthIndicator, Sub(x) x.SetAttribute("value", strength.ToString()), True, True)
                    prevStrength = strength
                End If
            End Sub
            Protected Friend Function GetLeadingIconBounds() As Rectangle
                Return GetPartBounds(leadingIcon)
            End Function
#End Region
#Region "Assets"
            Protected Overrides Function LoadDefaultStyles() As String
                Return PasswordBoxHtmlCssAsset.Default.Css
            End Function
            Protected Overrides Function LoadDefaultTemplate() As String
                Return PasswordBoxHtmlCssAsset.Default.Html
            End Function
            Friend NotInheritable Class PasswordBoxHtmlCssAsset
                Inherits HtmlCssAsset
                <Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
                Shared Sub New()
                    Components.StrengthIndicator.Register()
                End Sub
                Public Shared ReadOnly [Default] As HtmlCssAsset = New PasswordBoxHtmlCssAsset()
            End Class

            Private Class CSharpImpl
                <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
                Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                    target = value
                    Return value
                End Function
            End Class
#End Region
        End Class
        Protected Overrides Function CreateHtmlEditorPreview() As ICustomDxHtmlPreview
            Dim previewControl = New PasswordBox()
            previewControl.Properties.BeginUpdate()
            previewControl.Properties.HeaderLabel = If(String.IsNullOrEmpty(HeaderLabel), "{HeaderLabel}", HeaderLabel)
            previewControl.Properties.FooterLabel = If(String.IsNullOrEmpty(FooterLabel), "{FooterLabel}", FooterLabel)
            previewControl.Properties.NullValuePrompt = If(String.IsNullOrEmpty(Placeholder), "{Placeholder}", Placeholder)
            previewControl.Properties.EndUpdate()
            Return previewControl
        End Function
    End Class
End Namespace
