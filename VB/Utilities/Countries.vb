Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Runtime.InteropServices

Namespace DevExpress.UITemplates.Collection.Utilities

    Public Module Countries
        Private _All As System.Collections.ObjectModel.ReadOnlyCollection(Of DevExpress.UITemplates.Collection.Utilities.Countries.Info), _Asia As System.Collections.ObjectModel.ReadOnlyCollection(Of DevExpress.UITemplates.Collection.Utilities.Countries.Info), _Africa As System.Collections.ObjectModel.ReadOnlyCollection(Of DevExpress.UITemplates.Collection.Utilities.Countries.Info), _Antarctica As System.Collections.ObjectModel.ReadOnlyCollection(Of DevExpress.UITemplates.Collection.Utilities.Countries.Info), _Oceania As System.Collections.ObjectModel.ReadOnlyCollection(Of DevExpress.UITemplates.Collection.Utilities.Countries.Info), _Europe As System.Collections.ObjectModel.ReadOnlyCollection(Of DevExpress.UITemplates.Collection.Utilities.Countries.Info), _NorthAmerica As System.Collections.ObjectModel.ReadOnlyCollection(Of DevExpress.UITemplates.Collection.Utilities.Countries.Info), _SouthAmerica As System.Collections.ObjectModel.ReadOnlyCollection(Of DevExpress.UITemplates.Collection.Utilities.Countries.Info)
        Sub New()
            Dim rows = Assets.Data.Rows
            Dim all = New List(Of Info)(rows.Count)
            For i As Integer = 0 To rows.Count - 1
                Dim info = New Info(rows(i))
                mapByName.Add(info.Country, info)
                mapByFIPS.Add(info.FIPS, info)
                all.Add(info)
            Next
            Countries.All = all.AsReadOnly()
            Asia = all.Where(Function(x) x.Continent = NameOf(Asia)).ToList().AsReadOnly()
            Africa = all.Where(Function(x) x.Continent = NameOf(Africa)).ToList().AsReadOnly()
            Antarctica = all.Where(Function(x) x.Continent = NameOf(Antarctica)).ToList().AsReadOnly()
            Europe = all.Where(Function(x) x.Continent = NameOf(Europe)).ToList().AsReadOnly()
            Oceania = all.Where(Function(x) x.Continent = NameOf(Oceania)).ToList().AsReadOnly()
            NorthAmerica = Enumerable.ToList(Enumerable.Where(all, Function(x) Equals(x.Continent, "North America"))).AsReadOnly()
            SouthAmerica = Enumerable.ToList(Enumerable.Where(all, Function(x) Equals(x.Continent, "South America"))).AsReadOnly()
        End Sub
        Public NotInheritable Class Info
            Private _Country As String, _ISO2 As String, _ISO3 As String, _FIPS As String, _PhoneCode As String, _Continent As String, _Capital As String, _Currency As String
            Friend Sub New(parts As String())
                Me.New(parts(0), parts(1), parts(2), parts(3), parts(4), parts(5), parts(6), parts(7))
            End Sub
            Friend Sub New(country As String, iso2 As String, iso3 As String, fips As String, phoneCode As String, continent As String, capital As String, currency As String)
                Me.Country = country
                Me.ISO2 = iso2
                Me.ISO3 = iso3
                Me.FIPS = fips
                Me.PhoneCode = phoneCode
                PhoneCodeDigits = phoneCode.Replace("-", String.Empty)
                Me.Continent = continent
                Me.Capital = capital
                Me.Currency = currency
            End Sub

            Public Property Country As String
                Get
                    Return _Country
                End Get
                Private Set(value As String)
                    _Country = value
                End Set
            End Property

            Public Property ISO2 As String
                Get
                    Return _ISO2
                End Get
                Private Set(value As String)
                    _ISO2 = value
                End Set
            End Property

            Public Property ISO3 As String
                Get
                    Return _ISO3
                End Get
                Private Set(value As String)
                    _ISO3 = value
                End Set
            End Property

            Public Property FIPS As String
                Get
                    Return _FIPS
                End Get
                Private Set(value As String)
                    _FIPS = value
                End Set
            End Property

            Public Property PhoneCode As String
                Get
                    Return _PhoneCode
                End Get
                Private Set(value As String)
                    _PhoneCode = value
                End Set
            End Property
            Public PhoneCodeDigits As String

            Public Property Continent As String
                Get
                    Return _Continent
                End Get
                Private Set(value As String)
                    _Continent = value
                End Set
            End Property

            Public Property Capital As String
                Get
                    Return _Capital
                End Get
                Private Set(value As String)
                    _Capital = value
                End Set
            End Property

            Public Property Currency As String
                Get
                    Return _Currency
                End Get
                Private Set(value As String)
                    _Currency = value
                End Set
            End Property
            Public Overrides Function ToString() As String
                Return $"{Country}, {ISO2}/{ISO3}, {FIPS}, +{PhoneCode}, {Continent}, {Capital}, {Currency}"
            End Function
        End Class
        Private ReadOnly mapByName As Dictionary(Of String, Info) = New Dictionary(Of String, Info)(StringComparer.OrdinalIgnoreCase)
        Public Function GetCountryByName(countryName As String) As Info
            Dim info As Info = Nothing
            Return If(mapByName.TryGetValue(countryName, info), info, Nothing)
        End Function
        Private ReadOnly mapByFIPS As Dictionary(Of String, Info) = New Dictionary(Of String, Info)(StringComparer.OrdinalIgnoreCase)
        Public Function GetCountryByFIPS(fips As String) As Info
            Dim info As Info = Nothing
            Return If(mapByFIPS.TryGetValue(fips, info), info, Nothing)
        End Function
        Public Function IsValidPhoneCode(phoneCodeDigits As String, <Out> ByRef countryInfo As Info) As Boolean
            countryInfo = Nothing
            For Each info In All
                If phoneCodeDigits.StartsWith(info.PhoneCodeDigits, StringComparison.Ordinal) Then
                    countryInfo = info
                    Exit For
                End If
            Next
            Return countryInfo IsNot Nothing
        End Function
        Public Function HasTheSamePhoneCode(info As Info, phoneNumberDigits As String) As Boolean
            If info Is Nothing OrElse String.IsNullOrEmpty(phoneNumberDigits) Then Return False
            Return phoneNumberDigits.StartsWith(info.PhoneCodeDigits, StringComparison.Ordinal)
        End Function

        Public Property All As ReadOnlyCollection(Of Info)
            Get
                Return _All
            End Get
            Private Set(value As ReadOnlyCollection(Of Info))
                _All = value
            End Set
        End Property

        Public Property Asia As ReadOnlyCollection(Of Info)
            Get
                Return _Asia
            End Get
            Private Set(value As ReadOnlyCollection(Of Info))
                _Asia = value
            End Set
        End Property

        Public Property Africa As ReadOnlyCollection(Of Info)
            Get
                Return _Africa
            End Get
            Private Set(value As ReadOnlyCollection(Of Info))
                _Africa = value
            End Set
        End Property

        Public Property Antarctica As ReadOnlyCollection(Of Info)
            Get
                Return _Antarctica
            End Get
            Private Set(value As ReadOnlyCollection(Of Info))
                _Antarctica = value
            End Set
        End Property

        Public Property Oceania As ReadOnlyCollection(Of Info)
            Get
                Return _Oceania
            End Get
            Private Set(value As ReadOnlyCollection(Of Info))
                _Oceania = value
            End Set
        End Property

        Public Property Europe As ReadOnlyCollection(Of Info)
            Get
                Return _Europe
            End Get
            Private Set(value As ReadOnlyCollection(Of Info))
                _Europe = value
            End Set
        End Property

        Public Property NorthAmerica As ReadOnlyCollection(Of Info)
            Get
                Return _NorthAmerica
            End Get
            Private Set(value As ReadOnlyCollection(Of Info))
                _NorthAmerica = value
            End Set
        End Property

        Public Property SouthAmerica As ReadOnlyCollection(Of Info)
            Get
                Return _SouthAmerica
            End Get
            Private Set(value As ReadOnlyCollection(Of Info))
                _SouthAmerica = value
            End Set
        End Property
#Region "Data"
        Friend NotInheritable Class Assets
            Public Shared Data As CsvAsset = New CountryCodeCsvAsset()
            '
            Friend NotInheritable Class CountryCodeCsvAsset
                Inherits CsvAsset
            End Class
        End Class
#End Region
    End Module
End Namespace
