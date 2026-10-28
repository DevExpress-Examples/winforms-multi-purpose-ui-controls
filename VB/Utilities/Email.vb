Imports System
Imports System.Runtime.InteropServices

Namespace DevExpress.UITemplates.Collection.Utilities

    Public Module Email
        Public Function Validate(email As String) As Boolean
            If String.IsNullOrEmpty(email) Then Return False
            If email.Length < 3 Then Return False
            If email.IndexOf("@", 0) < 0 Then Return False
            Try
                Dim address = New System.Net.Mail.MailAddress(email)
                Return True
            Catch __unusedFormatException1__ As FormatException
                Return False
            End Try
        End Function
        Public Function Validate(email As String, <Out> ByRef [error] As String) As Boolean
            [error] = String.Empty
            If String.IsNullOrEmpty(email) Then
                [error] = "Empty address."
                Return False
            End If
            If email.Length < 3 Then
                [error] = "Incomplete address."
                Return False
            End If
            If email.IndexOf("@", 0) < 0 Then
                [error] = "Email addresses must include the @ character."
                Return False
            End If
            Try
                Dim address = New System.Net.Mail.MailAddress(email)
            Catch e As FormatException
                [error] = e.Message
            End Try
            Return String.IsNullOrEmpty([error])
        End Function
    End Module
End Namespace
