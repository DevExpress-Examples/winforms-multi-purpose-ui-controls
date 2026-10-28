Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports UITemplatesExampleVB.Assets.Toolbox
Imports DevExpress.UITemplates.Collection.Components
Imports DevExpress.UITemplates.Collection.Utilities
Imports DevExpress.Utils
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils.Html
Imports DevExpress.XtraEditors.ButtonsPanelControl
Imports DevExpress.XtraEditors.Internal

Namespace DevExpress.UITemplates.Collection.Editors

    <ToolboxItem(True)>
    <System.Drawing.ToolboxBitmapAttribute(GetType(ToolboxBitmapRoot), "TwinButton.bmp")>
    <Description("A button consisting of two buttons with opposing actions displayed side by side.")>
    Public Class TwinButton
        Inherits HtmlButtonBase
        Private ReadOnly firstIconImageOptionsCore As TwinButtonImageOptions
        Private ReadOnly secondIconImageOptionsCore As TwinButtonImageOptions
        Public Sub New()
            firstIconImageOptionsCore = CreateImageOptions()
            AddHandler firstIconImageOptionsCore.Changed, AddressOf OnIconImageOptionsChanged
            secondIconImageOptionsCore = CreateImageOptions()
            AddHandler secondIconImageOptionsCore.Changed, AddressOf OnIconImageOptionsChanged
        End Sub

        Protected Overrides Sub Dispose(disposing As Boolean)
            If firstIconImageOptionsCore IsNot Nothing Then
                RemoveHandler firstIconImageOptionsCore.Changed, AddressOf OnIconImageOptionsChanged
                firstIconImageOptionsCore.Dispose()
            End If
            If secondIconImageOptionsCore IsNot Nothing Then
                RemoveHandler secondIconImageOptionsCore.Changed, AddressOf OnIconImageOptionsChanged
                secondIconImageOptionsCore.Dispose()
            End If
            If firstButtonElement IsNot Nothing Then firstButtonElement.RemoveEventListener("item-click", AddressOf OnButtonItemClick)
            If secondButtonElement IsNot Nothing Then secondButtonElement.RemoveEventListener("item-click", AddressOf OnButtonItemClick)

            MyBase.Dispose(disposing)
        End Sub
#Region "Properties"
        Public Enum SizeType
            Small = -1
            [Default] = 0
            Large = 1
        End Enum
        Private buttonSizeTypeCore As SizeType = SizeType.Default
        <DefaultValue(SizeType.Default), Category("Layout")>
        Public Property ButtonSize As SizeType
            Get
                Return buttonSizeTypeCore
            End Get
            Set(value As SizeType)
                If buttonSizeTypeCore = value Then Return
                buttonSizeTypeCore = value
                OnButtonSizeChanged(value)
            End Set
        End Property
        Protected Overridable Sub OnButtonSizeChanged(value As SizeType)
            SetButtonElementSize(value)
            InvalidatePart(firstButtonElement)
            InvalidatePart(secondButtonElement)
            If AutoSize Then AdjustSize()
            OnPropertiesChanged()
        End Sub
        Protected Overridable Sub SetButtonElementSize(value As SizeType)
            If firstButtonElement IsNot Nothing Then firstButtonElement.SetAttribute(NameOf(TwinButtonItem.ItemSize), CType(value, TwinButtonItem.Size))
            If secondButtonElement IsNot Nothing Then secondButtonElement.SetAttribute(NameOf(TwinButtonItem.ItemSize), CType(value, TwinButtonItem.Size))
        End Sub
        <Utils.Design.SmartTagProperty("AutoSize", "", 3)>
        Public Overrides Property AutoSize As Boolean
            Get
                Return MyBase.AutoSize
            End Get
            Set(value As Boolean)
                MyBase.AutoSize = value
            End Set
        End Property
        Private firstTextCore As String
        <ComponentModel.DefaultValueAttribute(GetType(String), Nothing), Category("Text")>
        <Utils.Design.SmartTagProperty("First Text", "", 1, Utils.Design.SmartTagActionType.RefreshBoundsAfterExecute Or Utils.Design.SmartTagActionType.RefreshContentAfterExecute)>
        Public Property FirstText As String
            Get
                Return firstTextCore
            End Get
            Set(value As String)
                If Equals(firstTextCore, value) Then Return
                firstTextCore = value
                OnPropertiesChanged()
            End Set
        End Property
        Private secondTextCore As String
        <ComponentModel.DefaultValueAttribute(GetType(String), Nothing), Category("Text")>
        <Utils.Design.SmartTagProperty("Second Text", "", 1, Utils.Design.SmartTagActionType.RefreshBoundsAfterExecute Or Utils.Design.SmartTagActionType.RefreshContentAfterExecute)>
        Public Property SecondText As String
            Get
                Return secondTextCore
            End Get
            Set(value As String)
                If Equals(secondTextCore, value) Then Return
                secondTextCore = value
                OnPropertiesChanged()
            End Set
        End Property
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)>
        Public Overrides Property Text As String
            Get
                Return $"{If(FirstText, "First")} {If(SecondText, "Second")}"
            End Get
            Set(value As String)
            End Set
        End Property
        <ComponentModel.Category(XtraEditors.CategoryName.Appearance), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <Utils.Design.SmartTagProperty("FirstIcon", "", 2, Utils.Design.SmartTagActionType.RefreshBoundsAfterExecute Or Utils.Design.SmartTagActionType.RefreshContentAfterExecute)>
        Public ReadOnly Property FirstIconImageOptions As TwinButtonImageOptions
            Get
                Return firstIconImageOptionsCore
            End Get
        End Property
        <ComponentModel.Category(XtraEditors.CategoryName.Appearance), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <Utils.Design.SmartTagProperty("SecondIcon", "", 2, Utils.Design.SmartTagActionType.RefreshBoundsAfterExecute Or Utils.Design.SmartTagActionType.RefreshContentAfterExecute)>
        Public ReadOnly Property SecondIconImageOptions As TwinButtonImageOptions
            Get
                Return secondIconImageOptionsCore
            End Get
        End Property
        Protected Overridable Sub OnIconImageOptionsChanged(sender As Object, args As ImageOptionsChangedEventArgs)
            shouldRaiseSizeableChanged = args.ImageSizeChanged
            If sender Is firstIconImageOptionsCore Then UpdatePartVisibility(firstButtonIcon)
            If sender Is secondIconImageOptionsCore Then UpdatePartVisibility(secondButtonIcon)
            If AutoSize Then AdjustSize()
            OnPropertiesChanged()
        End Sub
        Protected Overridable Function CreateImageOptions() As TwinButtonImageOptions
            Return New TwinButtonImageOptions()
        End Function
        Public Class TwinButtonImageOptions
            Inherits ButtonImageOptionsBase
        End Class
#End Region
#Region "Events"
        Private ReadOnly Shared firstClickField As Object = New Object()
        Private ReadOnly Shared secondClickField As Object = New Object()
        '
        <ComponentModel.Category(XtraEditors.CategoryName.Action)>
        Public Custom Event FirstClick As EventHandler
            AddHandler(value As EventHandler)
                Events.AddHandler(firstClickField, value)
            End AddHandler
            RemoveHandler(value As EventHandler)
                Events.RemoveHandler(firstClickField, value)
            End RemoveHandler
            <ComponentModel.Category(XtraEditors.CategoryName.Action)>
            RaiseEvent(sender As Object, e As EventArgs)
            End RaiseEvent
        End Event
        Protected Sub RaiseFirstClick()
            Dim handler = TryCast(Events(firstClickField), EventHandler)
            handler?.Invoke(Me, EventArgs.Empty)
        End Sub
        <ComponentModel.Category(XtraEditors.CategoryName.Action)>
        Public Custom Event SecondClick As EventHandler
            AddHandler(value As EventHandler)
                Events.AddHandler(secondClickField, value)
            End AddHandler
            RemoveHandler(value As EventHandler)
                Events.RemoveHandler(secondClickField, value)
            End RemoveHandler
            <ComponentModel.Category(XtraEditors.CategoryName.Action)>
            RaiseEvent(sender As Object, e As EventArgs)
            End RaiseEvent
        End Event
        Protected Sub RaiseSecondClick()
            Dim handler = TryCast(Events(secondClickField), EventHandler)
            handler?.Invoke(Me, EventArgs.Empty)
        End Sub
        Protected Overridable Sub OnButtonItemClick(args As DxHtmlElementEventArgs)
            activeElement = args.Element
            If args.Element.Id = NameOf(firstButton) Then RaiseFirstClick()
            If args.Element.Id = NameOf(secondButton) Then RaiseSecondClick()
        End Sub
        Private clickTarget As DxHtmlElement
        Public Sub PerformClick()
            clickTarget = activeElement
            Try
                PerformClickCore()
            Finally
                clickTarget = Nothing
            End Try
        End Sub
        Public Sub PerformFirstClick()
            clickTarget = firstButtonElement
            Try
                PerformClickCore()
            Finally
                clickTarget = Nothing
            End Try
        End Sub
        Public Sub PerformSecondClick()
            clickTarget = secondButtonElement
            Try
                PerformClickCore()
            Finally
                clickTarget = Nothing
            End Try
        End Sub
        Protected Overrides Sub OnClick(e As EventArgs)
            MyBase.OnClick(e)
            If clickTarget Is firstButtonElement Then RaiseFirstClick()
            If clickTarget Is secondButtonElement Then RaiseSecondClick()
        End Sub
#End Region
#Region "Parts"
        Protected ReadOnly Shared firstButton As Object = New Object()
        Protected ReadOnly Shared secondButton As Object = New Object()
        Protected ReadOnly Shared icon As Object = New Object()
        Protected ReadOnly Shared firstButtonIcon As Object = New Object()
        Protected ReadOnly Shared secondButtonIcon As Object = New Object()
        '
        Private firstButtonElement, secondButtonElement, activeElement As DxHtmlElement
        Protected Overrides Sub FindParts(parts As Dictionary(Of Object, DxHtmlElement), root As DxHtmlRootElement)
            MyBase.FindParts(parts, root)
            firstButtonElement = root.FindElementById(NameOf(firstButton))
            secondButtonElement = root.FindElementById(NameOf(secondButton))
            Dim iSize = CType(ButtonSize, TwinButtonItem.Size)
            If iSize <> TwinButtonItem.Size.[Default] Then
                firstButtonElement.SetAttribute(NameOf(TwinButtonItem.ItemSize), iSize)
                secondButtonElement.SetAttribute(NameOf(TwinButtonItem.ItemSize), iSize)
            End If
            Dim contentTemplateId = GetButtonContentTemplateId()
            firstButtonElement.SetAttribute(NameOf(TwinButtonItem.Template), contentTemplateId)
            secondButtonElement.SetAttribute(NameOf(TwinButtonItem.Template), contentTemplateId)
            firstButtonElement.AddEventListener("item-click", AddressOf OnButtonItemClick)
            secondButtonElement.AddEventListener("item-click", AddressOf OnButtonItemClick)
            parts(firstButton) = firstButtonElement
            parts(secondButton) = secondButtonElement
            parts(firstButtonIcon) = firstButtonElement.FindElementById(NameOf(icon))
            parts(secondButtonIcon) = secondButtonElement.FindElementById(NameOf(icon))
        End Sub
        Protected Overrides Sub CalcPartsVisibility(parts As Dictionary(Of Object, DxHtmlElement))
            Dim firstIconElement As DxHtmlElement = Nothing
            If parts.TryGetValue(firstButtonIcon, firstIconElement) AndAlso firstIconElement IsNot Nothing Then firstIconElement.Hidden = Not IsFirstIconVisible()
            Dim secondIconElement As DxHtmlElement = Nothing
            If parts.TryGetValue(secondButtonIcon, secondIconElement) AndAlso secondIconElement IsNot Nothing Then secondIconElement.Hidden = Not IsSecondIconVisible()
        End Sub
        Protected Overridable Function IsFirstIconVisible() As Boolean
            Return FirstIconImageOptions.HasImage
        End Function
        Protected Overridable Function IsSecondIconVisible() As Boolean
            Return SecondIconImageOptions.HasImage
        End Function
        Protected Overrides Function GetPartText(partName As String, element As DxHtmlElementBase) As String
            If Equals(partName, "Item.Text") Then
                If TwinButtonItem.IsButtonElement(element, firstButtonElement) Then Return If(FirstText, "First")
                If TwinButtonItem.IsButtonElement(element, secondButtonElement) Then Return If(SecondText, "Second")
            End If
            Return MyBase.GetPartText(partName, element)
        End Function
        Protected Overrides Function GetPartImage(partName As String, state As ObjectState, element As DxHtmlElementBase) As Object
            If Equals(partName, "Item.Icon") Then
                If TwinButtonItem.IsButtonElement(element, firstButtonElement) Then Return firstIconImageOptionsCore.GetImage(LookAndFeel, state)
                If TwinButtonItem.IsButtonElement(element, secondButtonElement) Then Return secondIconImageOptionsCore.GetImage(LookAndFeel, state)
            End If
            Return MyBase.GetPartImage(partName, state, element)
        End Function
        Protected Overrides Overloads Function OnGotFocus(parts As Dictionary(Of Object, DxHtmlElement), root As DxHtmlRootElement) As Boolean
            activeElement?.Focus(True)
            Return activeElement IsNot Nothing
        End Function
        Protected Overrides Overloads Function OnLostFocus(parts As Dictionary(Of Object, DxHtmlElement), root As DxHtmlRootElement) As Boolean
            activeElement?.Focus(False)
            Return activeElement IsNot Nothing
        End Function
        Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean
            If keyData = Keys.Left OrElse keyData = Keys.Right Then
                activeElement?.Focus(False)
                If activeElement Is firstButtonElement Then
                    activeElement = secondButtonElement
                Else
                    activeElement = firstButtonElement
                End If
                activeElement.Focus(True)
                UpdateViewInfoState()
                Return True
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function
        Private isKeyPressedCore As Boolean
        Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
            MyBase.OnKeyDown(e)
            If e.Handled Then Return
            If e.KeyData = Keys.Space Then
                isKeyPressedCore = True
                UpdateViewInfoState()
            End If
        End Sub
        Protected Overrides Sub OnKeyUp(e As KeyEventArgs)
            MyBase.OnKeyUp(e)
            If e.Handled Then Return
            If e.KeyData = Keys.Space Then
                Dim wasPressed = isKeyPressedCore
                isKeyPressedCore = False
                UpdateViewInfoState()
                If wasPressed Then OnKeyClick()
            End If
        End Sub
        Protected Overridable Sub OnKeyClick()
            If activeElement IsNot Nothing Then Me.OnButtonItemClick(New DxHtmlElementEventArgs(activeElement))
        End Sub
        Protected Overrides Overloads Sub OnGotFocus(e As EventArgs)
            activeElement = If(activeElement, firstButtonElement)
            MyBase.OnGotFocus(e)
        End Sub
        Protected Overrides Overloads Sub OnLostFocus(e As EventArgs)
            MyBase.OnLostFocus(e)
            activeElement?.Focus(False)
            isKeyPressedCore = False
        End Sub
        Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
            Dim dxArgs = DXMouseEventArgs.GetMouseArgs(e)
            dxArgs.Handled = GetValidationCanceled()
            MyBase.OnMouseUp(dxArgs)
        End Sub
        Protected Overrides Function GetValidationCanceled() As Boolean
            If Not MyBase.GetValidationCanceled() Then Return False
            Return Not IsUnvalidatedControlIsParent(Me)
        End Function
#End Region
#Region "Theme"
        Protected Overridable Function GetButtonContentTemplateId() As String
            Return "twin-button-item-template"
        End Function
        Protected Overrides Function LoadDefaultTemplate() As String
            Return TwinButtonHtmlCssAsset.Default.Html
        End Function
        Protected Overrides Function LoadDefaultStyles() As String
            Return TwinButtonHtmlCssAsset.Default.Css
        End Function
        Friend NotInheritable Class TwinButtonHtmlCssAsset
            Inherits HtmlCssAsset
            Shared Sub New()
                TwinButtonItem.Register()
            End Sub
            Public Shared ReadOnly [Default] As HtmlCssAsset = New TwinButtonHtmlCssAsset()
        End Class
#End Region
        Protected Overrides Function CreateHtmlEditorPreview() As ICustomDxHtmlPreview
            Dim previewControl = New TwinButton()
            previewControl.FirstText = If(String.IsNullOrEmpty(FirstText), "{First}", FirstText)
            previewControl.SecondText = If(String.IsNullOrEmpty(SecondText), "{Second}", SecondText)
            previewControl.FirstIconImageOptions.Assign(FirstIconImageOptions)
            previewControl.SecondIconImageOptions.Assign(SecondIconImageOptions)
            Return previewControl
        End Function
    End Class
End Namespace
