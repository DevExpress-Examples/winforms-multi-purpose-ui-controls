Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations

Namespace DevExpress.UITemplates.Collection.Models

    Public Class Entity(Of TKey)
        <Key>
        <Display(Order:=-1)>
        Public Property ID As TKey
        Public Overrides Function Equals(obj As Object) As Boolean
            Dim entity As Entity(Of TKey) = TryCast(obj, Entity(Of TKey))
            If ReferenceEquals(entity, Nothing) Then Return False
            Return EqualityComparer(Of TKey).Default.Equals(ID, entity.ID)
        End Function
        Public Overridable Sub Assign(source As Entity(Of TKey))
            If source IsNot Nothing Then
                ID = source.ID
            End If
        End Sub
        Public Overrides Function GetHashCode() As Integer
            Return MyBase.GetHashCode()
        End Function
    End Class
End Namespace
