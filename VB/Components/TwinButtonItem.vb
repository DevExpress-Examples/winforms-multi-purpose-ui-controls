Imports DevExpress.Utils
Imports DevExpress.Utils.Html

Namespace DevExpress.UITemplates.Collection.Components

    Public NotInheritable Class TwinButtonItem
        Inherits DxHtmlComponent
        Public Shared Sub Register()
            DxHtmlDocument.Define(Of TwinButtonItem)("twin-button-item")
        End Sub
        Public Shared Function IsButtonElement(element As DxHtmlElementBase, buttonElement As DxHtmlElementBase) As Boolean
            Dim parent = element.ParentElement
            While parent IsNot Nothing
                If parent.TagName = "twin-button-item" Then Return buttonElement Is parent
                parent = parent.ParentElement
            End While
            Return False
        End Function
        '
        Public Enum Size
            Small = -1
            [Default] = 0
            Large = 1
        End Enum
        Public ReadOnly Property Template As String
            Get
                Return If(TryCast(GetAttribute(NameOf(TwinButtonItem.Template)), String), String.Empty)
            End Get
        End Property
        Public ReadOnly Property ItemSize As Size?
            Get
                Dim value As Object = GetAttribute(NameOf(TwinButtonItem.ItemSize))
                If TypeOf value Is Integer Then Return New Size?(CType(CInt(value), Size))
                If TypeOf value Is String Then
                    If String.Equals(CStr(value), NameOf(Size.Small), StringComparison.OrdinalIgnoreCase) Then Return Size.Small
                    If String.Equals(CStr(value), NameOf(Size.Default), StringComparison.OrdinalIgnoreCase) Then Return Size.Default
                    If String.Equals(CStr(value), NameOf(Size.Large), StringComparison.OrdinalIgnoreCase) Then Return Size.Large
                End If
                Return If(TypeOf value Is Size, New Size?(CType(value, Size)), Nothing)
            End Get
        End Property
        Public Overrides Sub AttributeChangedCallback(attributeName As String)
            MyBase.AttributeChangedCallback(attributeName)
            If String.Equals(attributeName, NameOf(TwinButtonItem.Template), StringComparison.OrdinalIgnoreCase) Then
                Reset()
                Return
            End If
            If String.Equals(attributeName, NameOf(TwinButtonItem.ItemSize), StringComparison.OrdinalIgnoreCase) Then
                EnsureItemSize(originalParentClassName)
                Return
            End If
        End Sub
        Private originalParentClassName As String
        Public Overrides Sub ConnectedCallback()
            MyBase.ConnectedCallback()
            AddEventListener("mouseup", AddressOf OnItemMouseUp)
            SetAttribute("self", Me)
            EnsureTemplate()
            originalParentClassName = Element.ParentElement.ClassName
            Me.EnsureItemSize(originalParentClassName)
        End Sub
        Public Overrides Sub DisconnectedCallback()
            RemoveEventListener("mouseup", AddressOf OnItemMouseUp)
            MyBase.DisconnectedCallback()
        End Sub
        Public Sub Reset()
            ClearChildren()
            EnsureTemplate()
            EnsureItemSize(originalParentClassName)
        End Sub
        Private Sub EnsureTemplate()
            Dim templateId As String = TryCast(GetAttribute(NameOf(TwinButtonItem.Template)), String)
            If Not String.IsNullOrEmpty(templateId) Then
                Dim template = Element.RootElement.FindTemplate(templateId)
                If template IsNot Nothing Then AppendChild(template.CloneNode(True))
            End If
            If String.IsNullOrEmpty(Element.ClassName) Then Element.ClassName = "twin-button-item"
        End Sub
        Private Sub EnsureItemSize(parentClassName As String)
            Element.ParentElement.ClassName = CalcClassName(parentClassName, ItemSize)
        End Sub
        Private Shared Function CalcClassName(className As String, size As Size?) As String
            Return className & " " & size.GetValueOrDefault().ToString().ToLowerInvariant()
        End Function
        Private Sub OnItemMouseUp(args As DxHtmlElementEventArgs)
            Dim mouseArgs = TryCast(args, DxHtmlElementMouseEventArgs)
            If mouseArgs IsNot Nothing AndAlso mouseArgs.IsClick Then
                Dim meArgs = TryCast(mouseArgs.MouseArgs, DXMouseEventArgs)
                If meArgs IsNot Nothing AndAlso meArgs.Handled Then Return
                Me.OnItemClick(args)
            End If
        End Sub
        Private Sub OnItemClick(args As DxHtmlElementEventArgs)
            DispatchEvent("item-click", args)
            args.CancelBubble = True
            args.SuppressOwnerEvent = True
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
