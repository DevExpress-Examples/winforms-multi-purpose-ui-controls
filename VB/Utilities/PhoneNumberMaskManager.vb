Imports System
Imports DevExpress.Data.Mask

Namespace DevExpress.UITemplates.Collection.Utilities

    <MaskManager.AutoInstall>
    Public Class PhoneNumberMaskManager
        Inherits CustomTextMaskManager
        Public Shared Sub Register()
            RegisterMaskManagerType(GetType(PhoneNumberMaskManager))
            RegisterMaskManagerInfo(GetType(PhoneNumberMaskManager), Nothing, description:="Mask to enter phone number")
        End Sub
        <Parameters("UITemplatesExampleVB, DevExpress.UITemplates.Collection.Utilities.PhoneNumberMaskManager", "Phone Number")>
        Public Sub New(
            <ComponentModel.DefaultValueAttribute(GetType(Object), Nothing)>
        <Parameter("tag", "Tag")> Optional tag As Object = Nothing)
            MyBase.New(tag)
        End Sub
        Protected Overrides Sub ProcessCustomTextMaskInput(ea As CustomTextMaskInputArgs)
            Dim number = PhoneNumber.Sanitize(ea.ResultEditText)
            If ea.CurrentEditText = number AndAlso ea.ActionType <> CustomTextMaskInputAction.Init Then
                ea.Cancel()
                Return
            End If
            ea.SetResult(number, Math.Min(number.Length, ea.ResultCursorPosition))
        End Sub
    End Class
End Namespace
