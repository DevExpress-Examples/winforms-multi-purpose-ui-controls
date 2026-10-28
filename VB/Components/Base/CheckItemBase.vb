Imports DevExpress.Utils
Imports DevExpress.Utils.Html
Imports DevExpress.Utils.Html.Internal

Namespace DevExpress.UITemplates.Collection.Components

    Public NotInheritable Class CheckItemBase
        Inherits DxHtmlComponent
        Public Shared Sub Register()
            DxHtmlDocument.Define(Of CheckItemBase)("check-item")
        End Sub
        '
        Public Enum Size
            Small = -1
            [Default] = 0
            Large = 1
        End Enum
        Public ReadOnly Property Template As String
            Get
                Return If(TryCast(GetAttribute(NameOf(CheckItemBase.Template)), String), String.Empty)
            End Get
        End Property
        Public ReadOnly Property ItemSize As Size?
            Get
                Dim value = GetAttribute(NameOf(CheckItemBase.ItemSize))
                If TypeOf value Is Integer Then Return CType(CInt(value), Size)
                If TypeOf value Is String Then
                    If String.Equals(CStr(value), NameOf(Size.Small), StringComparison.OrdinalIgnoreCase) Then Return Size.Small
                    If String.Equals(CStr(value), NameOf(Size.Default), StringComparison.OrdinalIgnoreCase) Then Return Size.Default
                    If String.Equals(CStr(value), NameOf(Size.Large), StringComparison.OrdinalIgnoreCase) Then Return Size.Large
                End If
                Return If(TypeOf value Is Size, CType(value, Size?), Nothing)
            End Get
        End Property
        Public Overrides Sub AttributeChangedCallback(attributeName As String)
            MyBase.AttributeChangedCallback(attributeName)
            If String.Equals(attributeName, NameOf(CheckItemBase.Template), StringComparison.OrdinalIgnoreCase) Then
                Reset()
                Return
            End If
            If String.Equals(attributeName, NameOf(CheckItemBase.ItemSize), StringComparison.OrdinalIgnoreCase) Then
                EnsureItemSize(originalClassName)
                Return
            End If
            If String.Equals(attributeName, NameOf(CheckItemBase.IsChecked), StringComparison.OrdinalIgnoreCase) Then
                If lockCheckedChanged = 0 Then EnsureCheckedState()
                Return
            End If
        End Sub
        Private _internals As ElementInternals
        Private originalClassName As String
        Public Overrides Sub ConnectedCallback()
            MyBase.ConnectedCallback()
            _internals = AttachInternals()
            AddEventListener("mouseup", New Action(Of DxHtmlElementEventArgs)(AddressOf OnItemMouseUp))
            SetAttribute("self", Me)
            EnsureTemplate()
            EnsureCheckedState()
            originalClassName = Element.ClassName
            Me.EnsureItemSize(originalClassName)
        End Sub
        Public Overrides Sub DisconnectedCallback()
            RemoveEventListener("mouseup", New Action(Of DxHtmlElementEventArgs)(AddressOf OnItemMouseUp))
            DetachInternals()
            _internals = Nothing
            MyBase.DisconnectedCallback()
        End Sub
        Public Sub Reset()
            If _internals Is Nothing Then Return
            ClearChildren()
            EnsureTemplate()
            EnsureCheckedState()
            EnsureItemSize(originalClassName)
        End Sub
        Private Sub EnsureTemplate()
            Dim templateId As String = TryCast(GetAttribute(NameOf(CheckItemBase.Template)), String)
            If Not String.IsNullOrEmpty(templateId) Then
                Dim template = Element.RootElement.FindTemplate(templateId)
                If template IsNot Nothing Then AppendChild(template.CloneNode(True))
            End If
        End Sub
        Private Sub EnsureCheckedState()
            Dim value As Boolean = GetCheckedState()
            If isCheckedCore <> value Then
                isCheckedCore = value
                Me.UpdateStates(isCheckedCore)
            End If
        End Sub
        Private Function GetCheckedState() As Boolean
            Dim isCheckedState = GetAttribute(NameOf(CheckItemBase.IsChecked))
            If TypeOf isCheckedState Is Boolean Then Return CBool(isCheckedState)
            If TypeOf isCheckedState Is String Then Return String.Equals(CStr(isCheckedState), "true", StringComparison.OrdinalIgnoreCase)
            Return isCheckedCore
        End Function
        Private Sub EnsureItemSize(className As String)
            Element.ClassName = CalcClassName(className, ItemSize)
        End Sub
        Private Shared Function CalcClassName(className As String, size As Size?) As String
            If String.IsNullOrEmpty(className) Then className = "check-item"
            Return className & " " & size.GetValueOrDefault().ToString().ToLowerInvariant()
        End Function
        Private isCheckedCore As Boolean
        Public ReadOnly Property IsChecked As Boolean
            Get
                Return isCheckedCore
            End Get
        End Property
        Private lockCheckedChanged As Integer
        Private Sub OnItemMouseUp(args As DxHtmlElementEventArgs)
            Dim mouseArgs = TryCast(args, DxHtmlElementMouseEventArgs)
            If mouseArgs IsNot Nothing AndAlso mouseArgs.IsClick Then
                Dim meArgs = TryCast(mouseArgs.MouseArgs, DXMouseEventArgs)
                If meArgs IsNot Nothing AndAlso meArgs.Handled Then Return
                OnItemCheck(args)
            End If
        End Sub
        Private Sub OnItemCheck(args As DxHtmlElementEventArgs)
            lockCheckedChanged += 1
            isCheckedCore = Not isCheckedCore
            Me.UpdateStates(isCheckedCore)
            SetAttribute(NameOf(CheckItemBase.IsChecked), IsChecked)
            DispatchEvent("checked-changed", args)
            lockCheckedChanged -= 1
            args.CancelBubble = True
            args.SuppressOwnerEvent = True
        End Sub
        Private Sub UpdateStates(isChecked As Boolean)
            If _internals Is Nothing Then Return
            If isChecked Then
                _internals.States.Add("--checked")
            Else
                _internals.States.Delete("--checked")
            End If
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
