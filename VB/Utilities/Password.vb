Imports System
Imports System.Linq
Imports System.Runtime.InteropServices

Namespace DevExpress.UITemplates.Collection.Utilities

    Public Module Password
        Public Enum Strength
            Blank
            VeryWeak
            Weak
            Medium
            Strong
            VeryStrong
        End Enum
        <Flags>
        Public Enum Requirements
            None = 0
            Digits = 1
            Letters = 2
            Capitals = 4
            SpecialSymbols = 8
            Length = 16
        End Enum
        Public Function Check(password As String) As Strength
            Dim requirements As Requirements
            Return Check(password, requirements)
        End Function
        Public Function Check(password As String, <Out> ByRef requirements As Requirements) As Strength
            requirements = Requirements.None
            If String.IsNullOrEmpty(password) Then Return Strength.Blank
            If password.Length < 4 Then Return Strength.VeryWeak
            Dim score = 1
            If password.Length >= 8 Then
                requirements = requirements Or Requirements.Length
                score += 1
            End If
            If password.Length >= 12 Then score += 1
            If password.Any(New Func(Of Char, Boolean)(AddressOf Char.IsDigit)) Then
                requirements = requirements Or Requirements.Digits
                score += 1
            End If
            If password.Any(New Func(Of Char, Boolean)(AddressOf Char.IsLetter)) Then requirements = requirements Or Requirements.Letters
            If password.Any(New Func(Of Char, Boolean)(AddressOf Char.IsLower)) AndAlso password.Any(New Func(Of Char, Boolean)(AddressOf Char.IsUpper)) Then
                requirements = requirements Or Requirements.Capitals
                score += 1
            End If
            If password.Any(New Func(Of Char, Boolean)(AddressOf IsSpecialSymbol)) Then
                requirements = requirements Or Requirements.SpecialSymbols
                score += 1
            End If
            Return CType(Math.Min(5, score), Strength)
        End Function
        Private Function IsSpecialSymbol(c As Char) As Boolean
            Dim code = Microsoft.VisualBasic.AscW(c)
            If code >= 32 AndAlso code <= 47 Then Return True
            If code >= 58 AndAlso code <= 64 Then Return True
            If code >= 91 AndAlso code <= 96 Then Return True
            If code >= 123 AndAlso code <= 126 Then Return True
            Return False
        End Function
    End Module
End Namespace
