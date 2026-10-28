Imports System
Imports System.ComponentModel.DataAnnotations

Namespace DevExpress.UITemplates.Collection.Models

    Public Class Contact
        Private _UserName As String, _LastActivity As System.DateTime, _LastOnline As System.DateTime, _IsActive As Boolean, _UnreadCount As Integer
        Public Sub New(userName As String)
            Me.UserName = userName
        End Sub
        Public Property Avatar As Object

        Public Property UserName As String
            Get
                Return _UserName
            End Get
            Private Set(value As String)
                _UserName = value
            End Set
        End Property

        Public Property LastActivity As System.DateTime
            Get
                Return _LastActivity
            End Get
            Private Set(value As System.DateTime)
                _LastActivity = value
            End Set
        End Property
        <System.ComponentModel.DataAnnotations.DisplayAttribute(AutoGenerateField:=False)>
        Public Property LastOnline As System.DateTime
            Get
                Return _LastOnline
            End Get
            Private Set(value As System.DateTime)
                _LastOnline = value
            End Set
        End Property
        Public ReadOnly Property LastOnlineText As String
            Get
                If Me.IsActive Then Return "Online"
                If Me.LastOnline = System.DateTime.MinValue Then Return String.Empty
                Dim diff = System.DateTime.Now.Subtract(Me.LastOnline)
                If diff.TotalMinutes < 1 Then Return "Just now"
                If diff.TotalMinutes < 60 Then Return (CInt((0.5 + diff.TotalMinutes))).ToString() & " minutes ago"
                If diff.TotalMinutes < 90 Then Return "1 hour ago"
                If diff.TotalMinutes < 360 Then Return (CInt((diff.TotalMinutes / 60 + 0.5))).ToString() & " hours ago"
                If diff.TotalMinutes < 1440 Then Return Me.LastOnline.ToShortTimeString()
                If diff.TotalMinutes < 2880 Then Return "Yesterday, " & Me.LastOnline.ToShortTimeString()
                Return Me.LastOnline.ToShortDateString()
            End Get
        End Property
        <System.ComponentModel.DataAnnotations.DisplayAttribute(AutoGenerateField:=False)>
        Public Property IsActive As Boolean
            Get
                Return _IsActive
            End Get
            Private Set(value As Boolean)
                _IsActive = value
            End Set
        End Property

        Public Property UnreadCount As Integer
            Get
                Return _UnreadCount
            End Get
            Friend Set(value As Integer)
                _UnreadCount = value
            End Set
        End Property
        <System.ComponentModel.DataAnnotations.DisplayAttribute(AutoGenerateField:=False)>
        Public ReadOnly Property HasUnreadMessages As Boolean
            Get
                Return Me.UnreadCount > 0
            End Get
        End Property
        ' API
        Public Sub SetActive(Optional value As Boolean = True)
            Me.IsActive = value
        End Sub
        Public Sub SetLastOnline(dateTime As System.DateTime)
            Me.LastOnline = dateTime
        End Sub
        Public Sub SetUnreadCount(value As Integer)
            Me.UnreadCount = value
        End Sub
        Public Overrides Function ToString() As String
            Return If(Me.IsActive, Me.UserName, $"{Me.UserName}, {Me.LastOnlineText}")
        End Function
    End Class
End Namespace
