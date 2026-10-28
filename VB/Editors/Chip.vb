Imports System.ComponentModel

Namespace DevExpress.UITemplates.Collection.Editors

    <TypeConverter(GetType(Chip.Converter))>
    Public Class Chip
        Inherits ItemBase
        Public Sub New()
            MyBase.New(Nothing, String.Empty, Nothing)
        End Sub
        Public Sub New(value As Object,
    <Localizable(True)> caption As String)
            MyBase.New(value, caption, Nothing)
        End Sub
        Public Sub New(value As Object,
    <Localizable(True)> caption As String, tag As Object)
            MyBase.New(value, caption, tag)
        End Sub
        Protected Overrides Function Clone() As ItemBase
            Return New Chip(Value, Caption, Tag)
        End Function
#Region "internals"
        Public Class Collection
            Inherits Collection(Of Chip)
            Protected Overrides Function CreateItem(value As Object, caption As String) As Chip
                Return New Chip(value, caption)
            End Function
        End Class
        Public Class Selection
            Inherits Selection(Of Chip)
        End Class
        Public Class Converter
            Inherits Converter(Of Chip)
        End Class
#End Region
    End Class
End Namespace
