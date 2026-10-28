Imports System
Imports System.Collections.Concurrent
Imports System.Collections.Generic
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices

Namespace DevExpress.UITemplates.Collection.Utilities

    Public MustInherit Class CsvAsset
        Public Shared AssetsRoot As String = "UITemplatesExampleVB.Assets."
        Public Shared ResourcesAssembly As Reflection.Assembly = GetType(CsvAsset).Assembly
        '
        Private ReadOnly csvName As String
        Protected Sub New(Optional csvName As String = Nothing)
            If String.IsNullOrEmpty(csvName) Then
                Dim typeName = [GetType]().Name
                Me.csvName = typeName.Substring(0, typeName.Length - NameOf(CsvAsset).Length)
            Else
                Me.csvName = csvName
            End If
        End Sub
        Private headersCore As String()
        Public ReadOnly Property Headers As String()
            Get
                If headersCore Is Nothing Then ReadCsv(headersCore, rowsCore)
                Return headersCore
            End Get
        End Property
        Private rowsCore As List(Of String())
        Public ReadOnly Property Rows As IReadOnlyList(Of String())
            Get
                If rowsCore Is Nothing Then ReadCsv(headersCore, rowsCore)
                Return rowsCore
            End Get
        End Property
        Private Sub ReadCsv(ByRef headers As String(), ByRef rows As List(Of String()))
            Dim resourceName = AssetsRoot & $"CSV.{csvName}.csv"
            Using stream = GetResourceStream(resourceName, ResourcesAssembly)
                Dim reader = If(stream IsNot Nothing, New StreamReader(stream), StreamReader.Null)
                Using lineReader = New CsvLineReader(reader)
                    headers = lineReader.ReadLine()
                    rows = New List(Of String())()
                    Dim line As String() = Nothing
                    line = lineReader.ReadLine(headers.Length)

                    While line IsNot Nothing
                        rows.Add(line)
                        line = lineReader.ReadLine(headers.Length)
                    End While
                End Using
            End Using
        End Sub
#Region "ReadCSV"
        Private ReadOnly Shared mappings As ConcurrentDictionary(Of String, String) = New ConcurrentDictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        Private Shared Function GetResourceStream(key As String, resourcesAssembly As Reflection.Assembly) As Stream
            Dim resourceName As String = String.Empty
            If Not mappings.TryGetValue(key, resourceName) Then
                Dim resourceNames = resourcesAssembly.GetManifestResourceNames()
                TryAddResourceNameMappings(resourceNames, key, resourceName)
            End If
            Return If(Not String.IsNullOrEmpty(resourceName), resourcesAssembly.GetManifestResourceStream(resourceName), Nothing)
        End Function
        Private Shared Sub TryAddResourceNameMappings(names As String(), key As String, <Out> ByRef resourceName As String)
            resourceName = String.Empty
            For i = 0 To names.Length - 1
                If names(i).EndsWith(".csv", StringComparison.OrdinalIgnoreCase) Then
                    If mappings.TryAdd(names(i), names(i)) AndAlso StringComparer.OrdinalIgnoreCase.Compare(key, names(i)) = 0 Then resourceName = names(i)
                End If
            Next
        End Sub
        Protected NotInheritable Class CsvLineReader
            Implements IDisposable
            Private ReadOnly textReader As TextReader
            Private [next] As Char
            Private ReadOnly _fields As List(Of String) = New List(Of String)()
            Private ReadOnly fieldBuilder As StringBuilder = New StringBuilder()
            '
            Const Eof As Char = ChrW(0)
            Const CarriageReturn As Char = ChrW(13)
            Const LineFeed As Char = ChrW(10)
            Const TextQualifier As Char = """"c
            Const Delimiter As Char = ","c
            '
            Public Sub New(textReader As TextReader)
                Me.textReader = textReader
                [next] = ToChar(textReader.Peek())
            End Sub
            Private Sub Dispose() Implements IDisposable.Dispose
                textReader.Dispose()
            End Sub
            Public Function ReadLine(Optional count As Integer = -1) As String()
                If [next] = Eof Then Return Nothing
                _fields.Clear()
                Dim field As String = ReadField()
                While Not Equals(field, Nothing)
                    _fields.Add(field)
                    field = ReadField()
                End While
                If _fields.Count < count Then _fields.Add(String.Empty)
                Return _fields.ToArray()
            End Function
            Private Function ReadField() As String
                If [next] = CarriageReturn Then
                    Read()
                    If [next] = LineFeed Then Read()
                    Return Nothing
                End If
                If [next] = LineFeed Then
                    Read()
                    Return Nothing
                End If
                ReadWhitespace()
                If [next] = Eof Then Return Nothing
                If [next] = TextQualifier Then
                    Return ReadQualifiedField()
                Else
                    Return ReadUnqualifiedField()
                End If
            End Function
            Private Sub ReadWhitespace()
                While Char.IsWhiteSpace([next]) AndAlso [next] <> Delimiter AndAlso [next] <> CarriageReturn AndAlso [next] <> LineFeed AndAlso [next] <> Eof
                    Read()
                End While
            End Sub
            Private Function ReadQualifiedField() As String
                Read() ' Skip first quote
                fieldBuilder.Clear()
                Dim c As Char = Read()
                While c <> Eof
                    If c = TextQualifier Then
                        If [next] = TextQualifier Then
                            Read()
                        Else
                            Exit While
                        End If
                    End If
                    fieldBuilder.Append(c)
                    c = Read()
                End While
                Dim field As String = fieldBuilder.ToString()
                ReadUnqualifiedField()
                Return field
            End Function
            Private Function ReadUnqualifiedField() As String
                fieldBuilder.Clear()
                While [next] <> Delimiter AndAlso [next] <> CarriageReturn AndAlso [next] <> LineFeed AndAlso [next] <> Eof


                    fieldBuilder.Append([next])
                    Read()
                End While
                If [next] = Delimiter Then Read()
                Return fieldBuilder.ToString()
            End Function
            Private Function Read() As Char
                Dim current As Char = ToChar(textReader.Read())
                [next] = ToChar(textReader.Peek())
                Return current
            End Function
            Private Shared Function ToChar(c As Integer) As Char
                Return If(c < 0, Eof, Microsoft.VisualBasic.ChrW(c))
            End Function
        End Class
    End Class
#End Region
End Namespace
