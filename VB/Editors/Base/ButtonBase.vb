Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq.Expressions
Imports System.Windows.Forms
Imports DevExpress.Utils
Imports DevExpress.Utils.Design
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils.Html
Imports DevExpress.Utils.MVVM
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Internal

Namespace DevExpress.UITemplates.Collection.Editors

    Public MustInherit Class ButtonBase
        Inherits HtmlButtonBase
        Implements DevExpress.Utils.MVVM.ISupportCommandBinding
        Private ReadOnly iconImageOptionsCore As ButtonImageOptions
        Protected Sub New()
            iconImageOptionsCore = CreateImageOptions()
            AddHandler IconImageOptions.Changed, AddressOf OnIconImageOptionsChanged
        End Sub
        Protected Overrides Sub Dispose(disposing As Boolean)
            If iconImageOptionsCore IsNot Nothing Then
                RemoveHandler IconImageOptions.Changed, AddressOf OnIconImageOptionsChanged
                iconImageOptionsCore.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
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
            If AutoSize Then AdjustSize()
            OnPropertiesChanged()
        End Sub
        <SmartTagProperty("AutoSize", "", 3)>
        Public Overrides Property AutoSize As Boolean
            Get
                Return MyBase.AutoSize
            End Get
            Set(value As Boolean)
                MyBase.AutoSize = value
            End Set
        End Property
        Protected MustOverride Sub SetButtonElementSize(value As SizeType)
#Region "Icon"
        <ComponentModel.Category(XtraEditors.CategoryName.Appearance), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <SmartTagProperty("Icon", "", 2, SmartTagActionType.RefreshBoundsAfterExecute Or SmartTagActionType.RefreshContentAfterExecute)>
        Public ReadOnly Property IconImageOptions As ButtonImageOptions
            Get
                Return iconImageOptionsCore
            End Get
        End Property
        Protected Overridable Sub OnIconImageOptionsChanged(sender As Object, args As ImageOptionsChangedEventArgs)
            shouldRaiseSizeableChanged = args.ImageSizeChanged
            OnPropertiesChanged()
        End Sub
        Protected Overridable Function CreateImageOptions() As ButtonImageOptions
            Return New ButtonImageOptions()
        End Function
        Public Class ButtonImageOptions
            Inherits ButtonImageOptionsBase
        End Class
#End Region
        Protected Shared ReadOnly icon As Object = New Object()
        '
        Protected Overrides Sub FindParts(parts As Dictionary(Of Object, DxHtmlElement), root As DxHtmlRootElement)
            parts(icon) = root.FindElementById(NameOf(icon))
        End Sub
        Protected Overrides Sub CalcPartsVisibility(parts As Dictionary(Of Object, DxHtmlElement))
            Dim iconElement As DxHtmlElement = Nothing
            If parts.TryGetValue(icon, iconElement) AndAlso iconElement IsNot Nothing Then iconElement.Hidden = Not IsIconVisible()
        End Sub
        Protected Overridable Function IsIconVisible() As Boolean
            Return IconImageOptions.HasImage
        End Function
        Protected Overrides Function GetPartImage(partName As String, state As ObjectState, element As DxHtmlElementBase) As Object
            If Equals(partName, "Icon") Then Return iconImageOptionsCore.GetImage(LookAndFeel, state)
            Return MyBase.GetPartImage(partName, state, element)
        End Function
        Protected Overrides Function CalcPartBounds(parts As Dictionary(Of Object, DxHtmlElement), partKey As Object) As Rectangle
            If Object.Equals(partKey, icon) Then Return parts(icon).AbsoluteBounds
            Return Rectangle.Empty
        End Function
        Protected Overrides Sub UpdateFromOwner(buttonInfo As EditorButtonObjectInfoArgs)
            MyBase.UpdateFromOwner(buttonInfo)
            buttonInfo.Button.ImageOptions.ImageToTextAlignment = XtraEditors.ImageAlignToText.LeftCenter
            buttonInfo.Button.ImageOptions.Assign(IconImageOptions)
        End Sub
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
            OnClick(EventArgs.Empty)
        End Sub
        Protected Overrides Sub OnLostFocus(e As EventArgs)
            MyBase.OnLostFocus(e)
            isKeyPressedCore = False
        End Sub
        Protected Overrides Function GetValidationCanceled() As Boolean
            If Not MyBase.GetValidationCanceled() Then Return False
            Return Not IsUnvalidatedControlIsParent(Me)
        End Function
#Region "Commands"
        Public Overridable Function BindCommand(command As Object, Optional queryCommandParameter As Func(Of Object) = Nothing, Optional updateState As Action(Of ButtonBase, Func(Of Boolean)) = Nothing) As IDisposable
            If updateState Is Nothing Then updateState = Sub(button, canExecute) button.Enabled = canExecute()
            Return DevExpress.Utils.MVVM.CommandHelper.Bind(Me, Sub(button, execute) AddHandler button.Click, Sub(s, e) execute(), updateState, command, queryCommandParameter)
        End Function
        Public Overridable Function BindCommand(commandSelector As Expressions.Expression(Of Action), source As Object, updateState As Action(Of ButtonBase, Func(Of Boolean)), Optional queryCommandParameter As Func(Of Object) = Nothing) As IDisposable
            Return BindCommand(commandSelector, source, queryCommandParameter, updateState)
        End Function
        Public Overridable Function BindCommand(commandSelector As Expressions.Expression(Of Action), source As Object, Optional queryCommandParameter As Func(Of Object) = Nothing, Optional updateState As Action(Of ButtonBase, Func(Of Boolean)) = Nothing) As IDisposable
            If updateState Is Nothing Then
                updateState =
            Sub(button, canExecute)
                button.Enabled = canExecute()
            End Sub
            End If

            Return DevExpress.Utils.MVVM.CommandHelper.Bind(
        Me,
        Sub(button, execute)
            AddHandler button.Click,
                Sub(s, e)
                    execute()
                End Sub
        End Sub,
        updateState,
        commandSelector,
        source,
        queryCommandParameter)
        End Function

        Public Overridable Function BindCommand(Of T)(commandSelector As Expressions.Expression(Of Action(Of T)), source As Object, updateState As Action(Of ButtonBase, Func(Of Boolean)), Optional queryCommandParameter As Func(Of T) = Nothing) As IDisposable
            Return BindCommand(commandSelector, source, queryCommandParameter, updateState)
        End Function
        Public Overridable Function BindCommand(Of T)(
    commandSelector As Expressions.Expression(Of Action(Of T)),
    source As Object,
    Optional queryCommandParameter As Func(Of T) = Nothing,
    Optional updateState As Action(Of ButtonBase, Func(Of Boolean)) = Nothing) As IDisposable

            If updateState Is Nothing Then
                updateState =
            Sub(button, canExecute)
                button.Enabled = canExecute()
            End Sub
            End If

            Return DevExpress.Utils.MVVM.CommandHelper.Bind(
        Me,
        Sub(button, execute)
            AddHandler button.Click,
                Sub(s, e)
                    execute()
                End Sub
        End Sub,
        updateState,
        commandSelector,
        source,
        Function()
            If queryCommandParameter IsNot Nothing Then
                Return queryCommandParameter()
            Else
                Return CType(Nothing, T)
            End If
        End Function)
        End Function
        Private Function BindCommand(command As Object, queryCommandParameter As Func(Of Object)) As IDisposable
            Return BindCommand(command, queryCommandParameter, CType(Nothing, Action(Of ButtonBase, Func(Of Boolean))))
        End Function

        Private Function BindCommand(commandSelector As Expressions.Expression(Of Action), source As Object, queryCommandParameter As Func(Of Object)) As IDisposable
            Return BindCommand(commandSelector, source, queryCommandParameter, CType(Nothing, Action(Of ButtonBase, Func(Of Boolean))))
        End Function

        Private Function BindCommand(Of T)(commandSelector As Expressions.Expression(Of Action(Of T)), source As Object, queryCommandParameter As Func(Of T)) As IDisposable
            Return BindCommand(Of T)(commandSelector, source, queryCommandParameter, CType(Nothing, Action(Of ButtonBase, Func(Of Boolean))))
        End Function

        Private Function ISupportCommandBinding_BindCommand(command As Object, Optional queryCommandParameter As Func(Of Object) = Nothing) As IDisposable Implements ISupportCommandBinding.BindCommand
            Return BindCommand(command, queryCommandParameter)
        End Function

        Private Function ISupportCommandBinding_BindCommand1(Of T)(commandSelector As Expression(Of Action(Of T)), source As Object, Optional queryCommandParameter As Func(Of T) = Nothing) As IDisposable Implements ISupportCommandBinding.BindCommand
            Return BindCommand(commandSelector, source, queryCommandParameter)
        End Function

        Private Function ISupportCommandBinding_BindCommand2(commandSelector As Expression(Of Action), source As Object, Optional queryCommandParameter As Func(Of Object) = Nothing) As IDisposable Implements ISupportCommandBinding.BindCommand
            Return BindCommand(commandSelector, source, queryCommandParameter)
        End Function
#End Region
    End Class
End Namespace
