Imports System
Imports System.ComponentModel
Imports System.Globalization
Imports DevExpress.Data.Mask

Namespace DevExpress.UITemplates.Collection.Utilities

    <MaskManager.AutoInstall>
    Public Class PaymentCardMaskManager
        Inherits CompositeMaskManager(Of PaymentCard)
        Public Shared Sub Register()
            RegisterMaskManagerType(GetType(PaymentCardMaskManager))
            RegisterMaskManagerInfo(GetType(PaymentCardMaskManager), Nothing, description:="The mask for credit card numbers.")
        End Sub
        <Parameters("UITemplatesExampleVB, DevExpress.UITemplates.Collection.Utilities.PaymentCardMaskManager", "Card with Number/ExpDate/CVC")>
        Public Sub New(
            <Parameter("cultureInfo")>
                        <Parameter("culture", GetType(CultureInfoConverter), "Culture (name)", Visibility:=ParameterVisibility.Advanced)> cultureInfo As CultureInfo)
            MyBase.New(cultureInfo)
            cultureInfoForParts = If(cultureInfo, CultureInfo.CurrentCulture)
        End Sub
        Private cultureInfoForParts As CultureInfo
        Protected Overrides Function CreateParts(cultureInfo As CultureInfo) As MaskManager()
            cultureInfoForParts = If(cultureInfo, CultureInfo.CurrentCulture)
            Return New MaskManager() {New SimpleMaskManager("0000 0000 0000 0000", cultureInfo, "0"c, False, True), New RegExpMaskManager("(0[1-9]|1[012])", False, True, True, True, "0"c, cultureInfo, False), New SimpleMaskManager("00", cultureInfo, "0"c, False, True), New SimpleMaskManager("000", cultureInfo, "0"c, False, True)}
        End Function
        Private Shared Function GetYear([date] As Date) As String
            Return [date].ToString("yy", CultureInfo.InvariantCulture)
        End Function
        Private Shared Function GetMonth([date] As Date) As String
            Return [date].ToString("MM", CultureInfo.InvariantCulture)
        End Function
        Protected Overrides Function CombinePartsValue() As PaymentCard
            Dim number As String = TryCast(Parts(0).GetCurrentEditValue(), String)
            Dim dateMonth As String = TryCast(Parts(1).GetCurrentEditValue(), String)
            Dim dateYear As String = TryCast(Parts(2).GetCurrentEditValue(), String)
            Dim cvc As String = TryCast(Parts(3).GetCurrentEditValue(), String)
            Return New PaymentCard(number, PaymentCard.GetExpirationDate(dateMonth, dateYear), cvc)
        End Function
        Protected Overrides Function SetPartsInitialEditValue(card As PaymentCard) As Integer
            Parts(0).SetInitialEditValue(card.Number)
            Parts(0).SelectAll()
            Parts(1).SetInitialEditValue(GetMonth(card.ExpirationDate))
            Parts(1).SelectAll()
            Parts(2).SetInitialEditValue(GetYear(card.ExpirationDate))
            Parts(2).SelectAll()
            Parts(3).SetInitialEditValue(card.CVC)
            Parts(3).SelectAll()
            Return 0
        End Function
        Protected Overrides Function SetPartsInitialEmptyValue() As Integer
            Parts(0).SetInitialEditValue(Nothing)
            Parts(1).SetInitialEditValue(GetMonth(Date.Now))
            Parts(2).SetInitialEditValue(GetYear(Date.Now))
            Parts(3).SetInitialEditValue(Nothing)
            Return 0
        End Function
        Protected Overrides Function GetPartsSeparator(index As Integer) As String
            Return If(index <> 1, PaymentCard.Separator, cultureInfoForParts.DateTimeFormat.DateSeparator)
        End Function
        Public Overrides Function Insert(insertion As String) As Boolean
            Dim activePartResult As Boolean = ActivePart.Insert(insertion)
            If Not String.IsNullOrEmpty(insertion) AndAlso ActivePart.IsFinal Then Index = Math.Min(Parts.Length - 1, Index + 1)
            Return activePartResult
        End Function
        Public Overrides Function Backspace() As Boolean
            Dim activePartResult As Boolean = ActivePart.Backspace()
            If ActivePart.DisplayCursorPosition = 0 AndAlso Not activePartResult Then
                Index = Math.Max(0, Index - 1)
                Return True
            End If
            Return activePartResult
        End Function
    End Class
End Namespace
