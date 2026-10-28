Imports System
Imports System.Text
Imports System.Runtime.InteropServices

Namespace DevExpress.UITemplates.Collection.Utilities

    Public Module PhoneNumber
        Const PhoneNumberLength As Integer = 11
        Const PhoneNumberMaxLength As Integer = 15
        Const CountryCodeMaxLength As Integer = 5
        '
        Public Function Validate(phoneNumber As String, <Out> ByRef [error] As String, Optional info As Countries.Info = Nothing) As Boolean
            [error] = String.Empty
            If String.IsNullOrEmpty(phoneNumber) Then
                [error] = "Empty phone number."
                Return False
            End If
            Dim digits = New StringBuilder(PhoneNumberLength)
            Dim index = 0, openBracketIndex = -1, plusIndex = -1
            For Each c In phoneNumber
                If Char.IsDigit(c) Then
                    digits.Append(c)
                    index += 1
                Else
                    If IsValidCharacter(index, openBracketIndex, plusIndex, c) Then Continue For
                    [error] = "Phone number includes invalid character(s): " & c.ToString()
                    Return False
                End If
            Next
            If openBracketIndex >= 0 AndAlso digits.Length > CountryCodeMaxLength Then
                [error] = "The country code section has no closing bracket: ("
                Return False
            End If
            Dim phoneNumberDigits As String = digits.ToString()
            Dim validationInfo As Countries.Info = Nothing
            If Not Countries.IsValidPhoneCode(phoneNumberDigits, validationInfo) Then
                [error] = "Invalid country code."
                Return False
            End If
            If info Is Nothing OrElse Not Countries.HasTheSamePhoneCode(validationInfo, phoneNumberDigits) Then info = validationInfo
            If phoneNumberDigits.Length >= PhoneNumberMaxLength Then [error] = "The number is too long."
            If phoneNumberDigits.Length < PhoneNumberLength Then
                Dim digitsRemains = PhoneNumberLength - phoneNumberDigits.Length
                [error] = $"The number is too short." & Environment.NewLine & $"A valid phone number for {info.Country} requires {digitsRemains} more digit(s)."
            End If
            Return String.IsNullOrEmpty([error])
        End Function
        Public Function GetDigits(phoneNumber As String, Optional throwOnErrors As Boolean = False) As String
            Dim digits = New StringBuilder(PhoneNumberLength)
            Dim index = 0, openBracketIndex = -1, plusIndex = -1
            For Each c In phoneNumber
                If Char.IsDigit(c) Then
                    digits.Append(c)
                    index += 1
                Else
                    If IsValidCharacter(index, openBracketIndex, plusIndex, c) Then Continue For
                    If throwOnErrors Then Throw New NotSupportedException("Phone number includes invalid character: " & c.ToString())
                End If
            Next
            If openBracketIndex >= 0 AndAlso digits.Length > CountryCodeMaxLength Then
                If throwOnErrors Then Throw New NotSupportedException("The country code section has no closing bracket: (")
            End If
            Return digits.ToString()
        End Function
        Public Function Sanitize(phoneNumber As String) As String
            Dim digits = New StringBuilder(PhoneNumberLength)
            Dim index = 0, openBracketIndex = -1, plusIndex = -1
            Dim tmp = -1, firstBracket = -1
            Dim prevChar = Char.MinValue
            Dim validDigitsCount = 0
            For Each c In phoneNumber
                If Char.IsDigit(c) Then
                    If Threading.Interlocked.Increment(validDigitsCount) > PhoneNumberMaxLength Then Exit For
                    digits.Append(c)
                    index += 1
                    prevChar = c
                Else
                    tmp = openBracketIndex
                    If IsValidCharacter(index, openBracketIndex, plusIndex, c) Then
                        If openBracketIndex <> tmp AndAlso tmp = -1 Then firstBracket = digits.Length
                        If Char.IsWhiteSpace(c) Then
                            If Not Char.IsWhiteSpace(prevChar) Then digits.Append(" "c)
                        ElseIf c = "-"c Then
                            If Char.IsDigit(prevChar) Then digits.Append(c)
                        Else
                            digits.Append(c)
                        End If
                        prevChar = c
                    End If
                End If
            Next
            If openBracketIndex >= 0 AndAlso digits.Length > 9 AndAlso firstBracket >= 0 Then digits.Remove(firstBracket, 1)
            Return digits.ToString()
        End Function
        Public Function EnsureCountry(numberOrCountry As Object, oldNumberOrCountry As Object, ByRef currentCountry As Countries.Info) As String
            Dim number As String = TryCast(numberOrCountry, String)
            If Not String.IsNullOrEmpty(number) Then
                Dim digits = GetDigits(number)
                Dim info As Countries.Info = Nothing
                If Countries.IsValidPhoneCode(digits, info) Then
                    If currentCountry Is Nothing OrElse currentCountry.PhoneCodeDigits <> info.PhoneCodeDigits Then currentCountry = info
                End If
            End If
            Dim country = TryCast(numberOrCountry, Countries.Info)
            If country IsNot Nothing Then
                If currentCountry Is country Then Return If(TryCast(oldNumberOrCountry, String), ("+" & country.PhoneCode.ToString()))
                Dim prevCountry = currentCountry
                currentCountry = country
                If prevCountry IsNot Nothing AndAlso prevCountry.PhoneCodeDigits = country.PhoneCodeDigits Then
                    Return If(TryCast(oldNumberOrCountry, String), ("+" & country.PhoneCode.ToString()))
                Else
                    number = "+" & currentCountry.PhoneCode.ToString()
                End If
            End If
            Return number
        End Function
        '
        Private Function IsValidCharacter(ByRef index As Integer, ByRef openBracketIndex As Integer, ByRef plusIndex As Integer, c As Char) As Boolean
            If Char.IsWhiteSpace(c) OrElse c = "-"c AndAlso index > 0 Then
                index += 1
                Return True
            End If
            If c = "("c AndAlso openBracketIndex = -1 Then
                If plusIndex = 0 AndAlso index > 1 Then
                    openBracketIndex = Math.Min(Threading.Interlocked.Increment(index), index - 1)
                    Return True
                End If
                If plusIndex = -1 AndAlso index = 0 Then
                    openBracketIndex = Math.Min(Threading.Interlocked.Increment(index), index - 1)
                    Return True
                End If
            End If
            If c = ")"c AndAlso openBracketIndex >= 0 AndAlso index > openBracketIndex + 1 Then
                openBracketIndex = -1
                index += 1
                Return True
            End If
            If c = "+"c AndAlso plusIndex = -1 Then
                If index = 0 OrElse index = 1 AndAlso openBracketIndex = 0 Then
                    plusIndex = Math.Min(Threading.Interlocked.Increment(index), index - 1)
                    Return True
                End If
            End If
            Return False
        End Function
    End Module
End Namespace
