Imports System.Runtime.InteropServices

Namespace DevExpress.UITemplates.Collection.Utilities

    Public Module PaymentCardType
        Public Function Guess(cardNumberPrefix As String) As PaymentCard.Type
            Dim minLength, maxLength As Integer
            Return Guess(cardNumberPrefix, minLength, maxLength)
        End Function
        Public Function Guess(cardNumberPrefix As String, <Out> ByRef minLength As Integer, <Out> ByRef maxLength As Integer) As PaymentCard.Type
            maxLength = 16
            minLength = maxLength
            If String.IsNullOrWhiteSpace(cardNumberPrefix) Then Return PaymentCard.Type.Undefined
            cardNumberPrefix = Normalize(cardNumberPrefix)
            If cardNumberPrefix.Length > 0 Then
                If cardNumberPrefix(0) = "2"c AndAlso cardNumberPrefix.Length > 6 Then
                    Dim code = cardNumberPrefix.Substring(1, 5)
                    Dim prefix As Integer
                    If Integer.TryParse(code, prefix) AndAlso prefix >= 22100 AndAlso prefix <= 72099 Then
                        ' MasterCard: [222100 - 272099] 16 
                        Return PaymentCard.Type.MasterCard
                    End If
                End If
                If cardNumberPrefix(0) = "3"c AndAlso cardNumberPrefix.Length > 1 Then
                    If cardNumberPrefix(1) = "0"c AndAlso cardNumberPrefix.Length > 2 Then
                        If cardNumberPrefix(2) >= "1"c AndAlso cardNumberPrefix(2) <= "5"c Then
                            ' Diners Club - Carte Blanche: [300, 301, 302, 303, 304, 305] 14 
                            maxLength = 14
                            minLength = maxLength
                            Return PaymentCard.Type.DinersClubCarteBlanche
                        End If
                    End If
                    If cardNumberPrefix(1) = "4"c OrElse cardNumberPrefix(1) = "7"c Then
                        ' American Express (AMEX): [34, 37] 15 
                        maxLength = 15
                        minLength = maxLength
                        Return PaymentCard.Type.AmericanExpress
                    End If
                    If cardNumberPrefix(1) = "5"c AndAlso cardNumberPrefix.Length > 3 Then
                        Dim code = cardNumberPrefix.Substring(1, 3)
                        Dim prefix As Integer
                        If Integer.TryParse(code, prefix) AndAlso prefix >= 528 AndAlso prefix <= 589 Then
                            ' JCB: [3528-3589] 16-19 
                            minLength = 16
                            maxLength = 19
                            Return PaymentCard.Type.JCB
                        End If
                    End If
                    If cardNumberPrefix(1) = "6"c Then
                        ' Diners Club - International: [36] 14 
                        maxLength = 14
                        minLength = maxLength
                        Return PaymentCard.Type.DinersClubInternational
                    End If
                End If
                If cardNumberPrefix(0) = "4"c Then
                    If cardNumberPrefix.Length > 3 Then
                        Dim code = cardNumberPrefix.Substring(1, 3)
                        Dim prefix As Integer
                        If Integer.TryParse(code, prefix) AndAlso (prefix = 26 OrElse prefix = 508 OrElse prefix = 844 OrElse prefix = 913 OrElse prefix = 917) Then
                            ' Visa Electron: [4026, 4508, 4844, 4913, 4917] 16 
                            maxLength = 16
                            minLength = maxLength
                            Return PaymentCard.Type.VisaElectron
                        End If
                    End If
                    If cardNumberPrefix.Length > 5 Then
                        Dim code = cardNumberPrefix.Substring(1, 5)
                        Dim prefix As Integer
                        If Integer.TryParse(code, prefix) AndAlso prefix = 17500 Then
                            ' Visa Electron: [417500] 16 
                            maxLength = 16
                            minLength = maxLength
                            Return PaymentCard.Type.VisaElectron
                        End If
                    End If
                    ' VISA: [4] 13-16-19 
                    minLength = 16
                    maxLength = 19
                    Return PaymentCard.Type.Visa
                End If
                If cardNumberPrefix(0) = "5"c AndAlso cardNumberPrefix.Length > 1 Then
                    If cardNumberPrefix(1) = "1"c OrElse cardNumberPrefix(1) = "2"c OrElse cardNumberPrefix(1) = "3"c OrElse cardNumberPrefix(1) = "5"c Then
                        ' MasterCard: [51, 52, 53, 54, 55, 222100 - 272099] 16 
                        maxLength = 16
                        minLength = maxLength
                        Return PaymentCard.Type.MasterCard
                    End If
                    If cardNumberPrefix(1) = "4"c Then
                        ' Diners Club -North America: [54] 16 
                        maxLength = 16
                        minLength = maxLength
                        Return PaymentCard.Type.DinersClubNorthAmerica
                    End If
                    If (cardNumberPrefix(1) = "0"c OrElse cardNumberPrefix(1) = "8"c) AndAlso cardNumberPrefix.Length > 3 Then
                        Dim code = cardNumberPrefix.Substring(1, 3)
                        Dim prefix As Integer
                        If Integer.TryParse(code, prefix) AndAlso prefix = 18 OrElse prefix = 20 OrElse prefix = 38 OrElse prefix = 893 Then
                            ' Maestro: [5018, 5020, 5038, 5893] 16 - 19 
                            minLength = 16
                            maxLength = 19
                            Return PaymentCard.Type.Maestro
                        End If
                    End If
                End If
                If cardNumberPrefix(0) = "6"c AndAlso cardNumberPrefix.Length > 1 Then
                    If cardNumberPrefix(1) = "0"c AndAlso cardNumberPrefix.Length > 3 Then
                        Dim code = cardNumberPrefix.Substring(1, 3)
                        Dim prefix As Integer
                        If Integer.TryParse(code, prefix) AndAlso prefix = 011 Then
                            ' Discover: [6011] 16-19 
                            minLength = 16
                            maxLength = 19
                            Return PaymentCard.Type.Discover
                        End If
                    End If
                    If cardNumberPrefix(1) = "2"c AndAlso cardNumberPrefix.Length > 5 Then
                        Dim code = cardNumberPrefix.Substring(1, 5)
                        Dim prefix As Integer
                        If Integer.TryParse(code, prefix) AndAlso prefix >= 22126 AndAlso prefix <= 22925 Then
                            ' Discover: [622126-622925] 16-19 
                            minLength = 16
                            maxLength = 19
                            Return PaymentCard.Type.Discover
                        End If
                    End If
                    If cardNumberPrefix(1) = "3"c AndAlso cardNumberPrefix.Length > 2 Then
                        Dim code = cardNumberPrefix.Substring(1, 2)
                        Dim prefix As Integer
                        If Integer.TryParse(code, prefix) AndAlso (prefix = 37 OrElse prefix = 38 OrElse prefix = 39) Then
                            ' Maestro: [637, 638, 639] 16 
                            maxLength = 16
                            minLength = maxLength
                            Return PaymentCard.Type.Maestro
                        End If
                    End If
                    If (cardNumberPrefix(1) = "3"c OrElse cardNumberPrefix(1) = "7"c) AndAlso cardNumberPrefix.Length > 3 Then
                        Dim code = cardNumberPrefix.Substring(1, 3)
                        Dim prefix As Integer
                        If Integer.TryParse(code, prefix) Then
                            If prefix = 304 OrElse prefix = 759 OrElse prefix = 761 OrElse prefix = 762 OrElse prefix = 762 Then
                                ' Maestro: [6304, 6759, 6761, 6762, 6763] 16 - 19 
                                minLength = 16
                                maxLength = 19
                                Return PaymentCard.Type.Maestro
                            End If
                        End If
                    End If
                    If cardNumberPrefix(1) = "4"c AndAlso cardNumberPrefix.Length > 2 Then
                        Dim code = cardNumberPrefix.Substring(1, 2)
                        Dim prefix As Integer
                        If Integer.TryParse(code, prefix) AndAlso prefix >= 44 AndAlso prefix <= 49 Then
                            ' Discover: [644-649] 16-19 
                            minLength = 16
                            maxLength = 19
                            Return PaymentCard.Type.Discover
                        End If
                    End If
                    If cardNumberPrefix(1) = "5"c Then
                        ' Discover: [65] 16-19 
                        minLength = 16
                        maxLength = 19
                        Return PaymentCard.Type.Discover
                    End If
                End If
            End If
            Return PaymentCard.Type.Undefined
        End Function
        Public Function Validate(cardNumber As String) As PaymentCard.Type
            If String.IsNullOrWhiteSpace(cardNumber) Then Return PaymentCard.Type.Invalid
            cardNumber = Normalize(cardNumber)
            Dim min, max As Integer
            Dim type = Guess(cardNumber, min, max)
            If Luhn.IsValid(cardNumber) Then Return type
            Return PaymentCard.Type.Invalid
        End Function
        Public Function Validate(cardNumber As String, <Out> ByRef [error] As String) As PaymentCard.Type
            [error] = String.Empty
            If String.IsNullOrWhiteSpace(cardNumber) Then Return PaymentCard.Type.Invalid
            cardNumber = Normalize(cardNumber)
            Dim min, max As Integer
            Dim type = Guess(cardNumber, min, max)
            If cardNumber.Length < min Then [error] = "Incomplete card number."
            If cardNumber.Length > max Then [error] = "The entered card number is too long."
            If Not Luhn.IsValid(cardNumber) Then
                [error] = "Invalid card number."
                Return PaymentCard.Type.Invalid
            End If
            Return type
        End Function
        Private Function Normalize(cardNumber As String) As String
            Dim sb = New Text.StringBuilder(cardNumber.Length)
            For i = 0 To cardNumber.Length - 1
                If Char.IsDigit(cardNumber(i)) Then sb.Append(cardNumber(i))
            Next
            Return sb.ToString()
        End Function

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Module
End Namespace
