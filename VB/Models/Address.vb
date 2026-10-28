Imports System.ComponentModel.DataAnnotations

Namespace DevExpress.UITemplates.Collection.Models

    Public Class Address
        Inherits Entity(Of Long)
        <Display(Name:="Address")>
        Public Property Line As String
        Public Property City As String
        Public Property Latitude As Double
        Public Property Longitude As Double
        Public Overrides Function Equals(obj As Object) As Boolean
            Dim a As Address = TryCast(obj, Address)
            If ReferenceEquals(a, Nothing) OrElse Not MyBase.Equals(a) Then Return False
            Return Equals(Line, a.Line) AndAlso Equals(City, a.City) AndAlso Latitude = a.Latitude AndAlso Longitude = a.Longitude
        End Function
        Public Overrides Function GetHashCode() As Integer
            Return MyBase.GetHashCode()
        End Function
        Public Overrides Function ToString() As String
            Return Line & ", " & City
        End Function
        Public Overrides Sub Assign(source As Entity(Of Long))
            MyBase.Assign(source)
            Dim addressSource = TryCast(source, Address)
            If addressSource IsNot Nothing Then
                Line = addressSource.Line
                City = addressSource.City
                Latitude = addressSource.Latitude
                Longitude = addressSource.Longitude
            End If
        End Sub
    End Class
    Public Class USAddress
        Inherits Address
        Public Property State As USState
        <Display(Name:="Zip code")>
        Public Property ZipCode As String
        Public Overrides Function Equals(obj As Object) As Boolean
            Dim us As USAddress = TryCast(obj, USAddress)
            If ReferenceEquals(us, Nothing) OrElse Not MyBase.Equals(obj) Then Return False
            Return Equals(ZipCode, us.ZipCode) AndAlso State = us.State
        End Function
        Public Overrides Function GetHashCode() As Integer
            Return MyBase.GetHashCode()
        End Function
        Public Overrides Sub Assign(source As Entity(Of Long))
            MyBase.Assign(source)
            Dim usSource = TryCast(source, USAddress)
            If usSource IsNot Nothing Then
                State = usSource.State
                ZipCode = usSource.ZipCode
            End If
        End Sub
    End Class
    '
    Public Enum USState
        CA = 0
        AR = 1
        AL = 2
        AK = 3
        AZ = 4
        CO = 5
        CT = 6
        DE = 7
        DC = 8
        FL = 9
        GA = 10
        HI = 11
        ID = 12
        IL = 13
        [IN] = 14
        IA = 15
        KS = 16
        KY = 17
        LA = 18
        [ME] = 19
        MD = 20
        MA = 21
        MI = 22
        MN = 23
        MS = 24
        MO = 25
        MT = 26
        NE = 27
        NV = 28
        NH = 29
        NJ = 30
        NM = 31
        NY = 32
        NC = 33
        OH = 34
        OK = 35
        [OR] = 36
        PA = 37
        RI = 38
        SC = 39
        SD = 40
        TN = 41
        TX = 42
        UT = 43
        VT = 44
        VA = 45
        WA = 46
        WV = 47
        WI = 48
        WY = 49
        ND = 50
    End Enum
End Namespace
