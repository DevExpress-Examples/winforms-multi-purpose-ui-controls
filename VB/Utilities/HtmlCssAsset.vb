Imports System
Imports System.Collections.Concurrent
Imports System.IO
Imports DevExpress.Utils.Html
Imports DevExpress.XtraEditors
Imports System.Runtime.InteropServices

Namespace DevExpress.UITemplates.Collection.Utilities

    Public MustInherit Class HtmlCssAsset
        Public Shared AssetsRoot As String = "UITemplatesExampleVB.Assets."
        Public Shared ResourcesAssembly As Reflection.Assembly = GetType(HtmlCssAsset).Assembly
        '
        Private ReadOnly htmlName, cssName As String
        Protected Sub New(Optional htmlName As String = Nothing, Optional cssName As String = Nothing)
            If String.IsNullOrEmpty(htmlName) Then
                Dim typeName = [GetType]().Name
                Me.htmlName = typeName.Substring(0, typeName.Length - NameOf(HtmlCssAsset).Length)
            Else
                Me.htmlName = htmlName
            End If
            If String.IsNullOrEmpty(cssName) Then
                Dim typeName = [GetType]().Name
                Me.cssName = typeName.Substring(0, typeName.Length - NameOf(HtmlCssAsset).Length)
            Else
                Me.cssName = cssName
            End If
        End Sub
        Private htmlCore As String
        Public ReadOnly Property Html As String
            Get
                Return If(htmlCore, Function()
                                        htmlCore = ReadText(htmlName, NameOf(HtmlCssAsset.Html))
                                        Return htmlCore
                                    End Function())
            End Get
        End Property
        Private cssCore As String
        Public ReadOnly Property Css As String
            Get
                Return If(cssCore, Function()
                                       cssCore = ReadText(cssName, NameOf(HtmlCssAsset.Css))
                                       Return cssCore
                                   End Function())
            End Get
        End Property
#Region "ReadText"
        Private ReadOnly Shared texts As ConcurrentDictionary(Of String, String) = New ConcurrentDictionary(Of String, String)(StringComparer.Ordinal)
        Private Shared Function ReadText(name As String, type As String) As String
            Dim resourceName As String = $"{AssetsRoot}{type}.{name}.{type}"

            Return texts.GetOrAdd(resourceName, AddressOf ReadResourceText)
        End Function
        Private Shared Function ReadResourceText(resourceName As String) As String
            Using stream = GetResourceStream(resourceName, ResourcesAssembly)
                If stream Is Nothing Then
                    Return String.Empty
                End If

                Using reader As New StreamReader(stream)
                    Return reader.ReadToEnd()
                End Using
            End Using
        End Function
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
                If names(i).EndsWith("." & NameOf(HtmlCssAsset.Html), StringComparison.OrdinalIgnoreCase) OrElse names(i).EndsWith("." & NameOf(HtmlCssAsset.Css), StringComparison.OrdinalIgnoreCase) Then
                    If mappings.TryAdd(names(i), names(i)) AndAlso StringComparer.OrdinalIgnoreCase.Compare(key, names(i)) = 0 Then resourceName = names(i)
                End If
            Next
        End Sub
#End Region
#Region "Apply"
        Public Sub AddTemplate(templateCollection As HtmlTemplateCollection)
            templateCollection.AddTemplate(Html, Css)
        End Sub
        Public Sub Apply(template As HtmlTemplate)
            template.Set(Html, Css)
        End Sub
        Public Sub Apply(control As HtmlContentControl)
            control.HtmlTemplate.Set(Html, Css)
        End Sub
        Public Sub Apply(popup As HtmlContentPopup)
            popup.HtmlTemplate.Set(Html, Css)
        End Sub
        Public Sub Apply(form As DirectXForm)
            form.HtmlTemplate.Set(Html, Css)
        End Sub
#End Region
    End Class
End Namespace
