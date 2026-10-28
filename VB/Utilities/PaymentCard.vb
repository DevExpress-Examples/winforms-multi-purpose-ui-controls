Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.Globalization
Imports System.Text
Imports DevExpress.Utils

Namespace DevExpress.UITemplates.Collection.Utilities

    Public NotInheritable Class PaymentCard
        Implements System.IEquatable(Of DevExpress.UITemplates.Collection.Utilities.PaymentCard)
        Private _Number As String, _NumberMasked As String, _ExpirationDate As System.DateTime, _CVC As String, _CardType As DevExpress.UITemplates.Collection.Utilities.PaymentCard.Type
        Public Enum Type
            Undefined
            <System.ComponentModel.DataAnnotations.DisplayAttribute(Name:="VISA")>
            Visa
            <System.ComponentModel.DataAnnotations.DisplayAttribute(Name:="MasterCard")>
            MasterCard
            <System.ComponentModel.DataAnnotations.DisplayAttribute(Name:="Maestro")>
            Maestro
            <System.ComponentModel.DataAnnotations.DisplayAttribute(Name:="American Express")>
            AmericanExpress
            <System.ComponentModel.DataAnnotations.DisplayAttribute(Name:="Diners Club - International")>
            DinersClubInternational
            <System.ComponentModel.DataAnnotations.DisplayAttribute(Name:="Diners Club - Carte Blanche")>
            DinersClubCarteBlanche
            <System.ComponentModel.DataAnnotations.DisplayAttribute(Name:="Diners Club - North America")>
            DinersClubNorthAmerica
            <System.ComponentModel.DataAnnotations.DisplayAttribute(Name:="JCB")>
            JCB
            <System.ComponentModel.DataAnnotations.DisplayAttribute(Name:="Discover")>
            Discover
            <System.ComponentModel.DataAnnotations.DisplayAttribute(Name:="Visa Electron")>
            VisaElectron
            Invalid
        End Enum
        Public Sub New(number As String, expDate As System.DateTime, cvc As String)
            Me.Number = number
            Me.NumberMasked = DevExpress.UITemplates.Collection.Utilities.PaymentCard.Mask(If(number, String.Empty))
            Me.ExpirationDate = expDate
            Me.CVC = cvc
            Me.CardType = PaymentCardType.Guess(Me.Number)
        End Sub
        Public Sub New(number As String, expDateMonth As String, expDateYear As String, cvc As String)
            Me.Number = number
            Me.NumberMasked = DevExpress.UITemplates.Collection.Utilities.PaymentCard.Mask(If(number, String.Empty))
            Me.ExpirationDate = DevExpress.UITemplates.Collection.Utilities.PaymentCard.GetExpirationDate(expDateMonth, expDateYear)
            Me.CVC = cvc
            Me.CardType = PaymentCardType.Guess(Me.Number)
        End Sub

        Public Property Number As String
            Get
                Return _Number
            End Get
            Private Set(value As String)
                _Number = value
            End Set
        End Property

        Public Property NumberMasked As String
            Get
                Return _NumberMasked
            End Get
            Private Set(value As String)
                _NumberMasked = value
            End Set
        End Property

        Public Property ExpirationDate As System.DateTime
            Get
                Return _ExpirationDate
            End Get
            Private Set(value As System.DateTime)
                _ExpirationDate = value
            End Set
        End Property

        Public Property CVC As String
            Get
                Return _CVC
            End Get
            Private Set(value As String)
                _CVC = value
            End Set
        End Property

        Public Property CardType As DevExpress.UITemplates.Collection.Utilities.PaymentCard.Type
            Get
                Return _CardType
            End Get
            Private Set(value As DevExpress.UITemplates.Collection.Utilities.PaymentCard.Type)
                _CardType = value
            End Set
        End Property
        Public Overloads Function Equals(card As DevExpress.UITemplates.Collection.Utilities.PaymentCard) As Boolean Implements Global.System.IEquatable(Of Global.DevExpress.UITemplates.Collection.Utilities.PaymentCard).Equals
            If System.[Object].ReferenceEquals(card, Nothing) Then Return False
            Dim otherDate = card.ExpirationDate.[Date]
            Return (Equals(Me.Number, card.Number)) AndAlso (Me.ExpirationDate.[Date] = otherDate) AndAlso (Equals(Me.CVC, card.CVC))
        End Function
        Public Overrides Function Equals(obj As Object) As Boolean
            Return Me.Equals(TryCast(obj, DevExpress.UITemplates.Collection.Utilities.PaymentCard))
        End Function
        Public Overrides Function GetHashCode() As Integer
            Dim [date] = Me.ExpirationDate.[Date]
            Return HashCodeHelper.CalculateGeneric(Me.Number, [date], Me.CVC)
        End Function
        Public Overrides Function ToString() As String
            If String.IsNullOrEmpty(Me.Number) AndAlso String.IsNullOrEmpty(Me.CVC) Then Return "(Empty)"
            Return DevExpress.UITemplates.Collection.Utilities.PaymentCard.PadWithZeros(Me.Number, New String("x"c, 16)) & DevExpress.UITemplates.Collection.Utilities.PaymentCard.Separator & Me.ExpirationDate.[Date].ToString("MM/yy") & DevExpress.UITemplates.Collection.Utilities.PaymentCard.Separator & DevExpress.UITemplates.Collection.Utilities.PaymentCard.PadWithZeros(Me.CVC, New String("x"c, 3))
        End Function
        Private Shared Function Mask(number As String, Optional maskCharacter As Char = "x"c) As String
            Dim builder = New System.Text.StringBuilder()
            Dim counter As Integer = 0
            For i As Integer = 0 To number.Length - 1
                If Char.IsDigit(number(i)) Then
                    If counter < 4 OrElse counter > 11 Then
                        builder.Append(number(i))
                    Else
                        builder.Append(maskCharacter)
                    End If
                    If System.Threading.Interlocked.Increment(counter) Mod 4 = 0 Then builder.Append(" "c)
                End If
            Next
            Return builder.ToString()
        End Function
        Private Shared Function PadWithZeros(number As String, [default] As String) As String
            Return If(Not String.IsNullOrEmpty(number), number.PadRight([default].Length, DevExpress.UITemplates.Collection.Utilities.PaymentCard.Zero), [default])
        End Function
        ' Constants
        Public Const Separator As String = "  "
        Public Const Zero As Char = " "c
        ' Static API
        Public Shared ReadOnly EmptyCard As DevExpress.UITemplates.Collection.Utilities.PaymentCard = New DevExpress.UITemplates.Collection.Utilities.PaymentCard(Nothing, System.DateTime.MinValue, String.Empty)
        Public Shared Function GetExpirationDate(strMonth As String, strYear As String) As System.DateTime
            Dim month, year As Integer
            If Integer.TryParse(If(strMonth, String.Empty), System.Globalization.NumberStyles.[Integer], System.Globalization.CultureInfo.InvariantCulture, month) Then
                month = System.Math.Max(1, System.Math.Min(month, 12))
            Else
                month = System.DateTime.Now.Month
            End If
            If Integer.TryParse(If(strYear, String.Empty), System.Globalization.NumberStyles.[Integer], System.Globalization.CultureInfo.InvariantCulture, year) Then
                year = 2000 + System.Math.Max(System.DateTime.Now.Year - 2000, System.Math.Min(year, System.DateTime.Now.Year - 2000 + 50))
            Else
                year = System.DateTime.Now.Year
            End If
            Return New System.DateTime(year, month, System.DateTime.DaysInMonth(year, month))
        End Function
    End Class
End Namespace
