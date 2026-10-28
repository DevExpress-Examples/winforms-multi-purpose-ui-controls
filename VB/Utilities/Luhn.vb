Namespace DevExpress.UITemplates.Collection.Utilities

    Public Module Luhn
        Public Function IsValid(number As String) As Boolean
            Dim factor = 1, checkSum = 0
            For i = number.Length - 1 To 0 Step -1
                Dim codePoint As Integer = AscW(number(i)) - AscW("0"c)
                Dim addend = factor * codePoint
                factor = If(factor = 2, 1, 2)
                addend = addend \ 10 + addend Mod 10
                checkSum += addend
            Next
            Return checkSum Mod 10 = 0
        End Function
    End Module
End Namespace
