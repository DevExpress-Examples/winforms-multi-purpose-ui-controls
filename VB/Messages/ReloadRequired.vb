Imports System
Imports System.Collections.Generic

Namespace DevExpress.UITemplates.Collection.Messages

    Public Class ReloadRequired(Of TKey As Structure, TEntity As Class)
        Implements IEquatable(Of ReloadRequired(Of TKey, TEntity))
        Private ReadOnly idField As TKey
        Private ReadOnly isNewField As Boolean
        Private Sub New(id As TKey, isNew As Boolean)
            idField = id
            isNewField = isNew
        End Sub
        Public ReadOnly Property Id As TKey
            Get
                Return idField
            End Get
        End Property
        Public ReadOnly Property IsNew As Boolean
            Get
                Return isNewField
            End Get
        End Property
        Public Function Equals(other As ReloadRequired(Of TKey, TEntity)) As Boolean Implements IEquatable(Of ReloadRequired(Of TKey, TEntity)).Equals
            Return EqualityComparer(Of TKey).Default.Equals(other.idField, idField) AndAlso other.isNewField = isNewField
        End Function
        Public Shared Function FromID(id As TKey) As ReloadRequired(Of TKey, TEntity)
            Return New ReloadRequired(Of TKey, TEntity)(id, False)
        End Function
        Public Shared Function FromNew(id As TKey) As ReloadRequired(Of TKey, TEntity)
            Return New ReloadRequired(Of TKey, TEntity)(id, True)
        End Function
        Public Shared Function All(id As TKey) As ReloadRequired(Of TKey, TEntity)
            Return New ReloadRequired(Of TKey, TEntity)(id, False)
        End Function
    End Class
End Namespace
