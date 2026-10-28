Imports System.Collections.Generic

Namespace DevExpress.UITemplates.Collection.Models

    Public Module ContactSampleData
        '
        Private _Contact1 As DevExpress.UITemplates.Collection.Models.Contact, _Contact2 As DevExpress.UITemplates.Collection.Models.Contact, _Contacts As System.Collections.Generic.IReadOnlyCollection(Of DevExpress.UITemplates.Collection.Models.Contact)
        Sub New()
            Contact1 = New Contact("John Smith")
            Call Contact1.SetActive()
            Contact1.SetUnreadCount(2)
            Contact2 = New Contact("Mary Brown")
            Contact2.SetLastOnline(Date.Now.AddHours(-4))
            Contacts = New Contact() {Contact1, Contact2}

        End Sub

        Public Property Contact1 As Contact
            Get
                Return _Contact1
            End Get
            Private Set(value As Contact)
                _Contact1 = value
            End Set
        End Property

        Public Property Contact2 As Contact
            Get
                Return _Contact2
            End Get
            Private Set(value As Contact)
                _Contact2 = value
            End Set
        End Property

        Public Property Contacts As IReadOnlyCollection(Of Contact)
            Get
                Return _Contacts
            End Get
            Private Set(value As IReadOnlyCollection(Of Contact))
                _Contacts = value
            End Set
        End Property
    End Module
End Namespace
