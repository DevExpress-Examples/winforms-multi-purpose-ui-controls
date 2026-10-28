Imports System.ComponentModel.DataAnnotations

Namespace DevExpress.UITemplates.Collection.Models

    Public Class Person
        Inherits Entity(Of Long)
        Public Property Photo As Object
        <Required, Display(Name:="First Name")>
        Public Property FirstName As String
        <Required, Display(Name:="Last Name")>
        Public Property LastName As String
        <Display(Name:="Full Name")>
        Public ReadOnly Property FullName As String
            Get
                Return FirstName & " " & LastName
            End Get
        End Property
        <Display(Name:="Birth Date")>
        Public Property BirthDate As Date?
        Public Overrides Function Equals(obj As Object) As Boolean
            Dim p As Person = TryCast(obj, Person)
            If ReferenceEquals(p, Nothing) OrElse Not MyBase.Equals(obj) Then Return False
            Return Equals(FirstName, p.FirstName) AndAlso Equals(LastName, p.LastName) AndAlso Nullable.Equals(BirthDate, p.BirthDate) AndAlso Equals(Photo, p.Photo)
        End Function
        Public Overrides Function GetHashCode() As Integer
            Return MyBase.GetHashCode()
        End Function
        Public Overrides Sub Assign(source As Entity(Of Long))
            MyBase.Assign(source)
            Dim personSource = TryCast(source, Person)
            If personSource IsNot Nothing Then
                FirstName = personSource.FirstName
                LastName = personSource.LastName
                BirthDate = personSource.BirthDate
                Photo = personSource.Photo
            End If
        End Sub
        Public Overrides Function ToString() As String
            Return FullName
        End Function
    End Class
    Public Enum PersonPrefix
        Dr = 0
        Mr = 1
        Ms = 2
        Miss = 3
        Mrs = 4
    End Enum
    '
    Public Class Employee
        Inherits Person
        <Required, EmailAddress>
        Public Property Email As String
        <Display(Name:="Home Phone")>
        Public Property HomePhone As String
        <Required, Display(Name:="Mobile Phone"), Phone>
        Public Property MobilePhone As String
        <Required, Display(Name:="Hire Date")>
        Public Property HireDate As Date?
        Public Property Department As EmployeeDepartment
        <Required>
        Public Property Title As String
        Public Property Prefix As PersonPrefix
        Public Property Status As EmployeeStatus
        Public Overridable Property Address As Address
        Public Overrides Function Equals(obj As Object) As Boolean
            Dim e As Employee = TryCast(obj, Employee)
            If ReferenceEquals(e, Nothing) OrElse Not MyBase.Equals(obj) Then Return False
            Return Equals(Title, e.Title) AndAlso Equals(Email, e.Email) AndAlso Equals(HomePhone, e.HomePhone) AndAlso Equals(MobilePhone, e.MobilePhone) AndAlso Nullable.Equals(HireDate, e.HireDate) AndAlso Prefix = e.Prefix AndAlso Department = e.Department AndAlso Status = e.Status AndAlso Equals(Address, e.Address)
        End Function
        Public Overrides Function GetHashCode() As Integer
            Return MyBase.GetHashCode()
        End Function
        Public Overrides Sub Assign(source As Entity(Of Long))
            MyBase.Assign(source)
            Dim employeeSource = TryCast(source, Employee)
            If employeeSource IsNot Nothing Then
                Title = employeeSource.Title
                Email = employeeSource.Email
                HomePhone = employeeSource.HomePhone
                MobilePhone = employeeSource.MobilePhone
                HireDate = employeeSource.HireDate
                Prefix = employeeSource.Prefix
                Department = employeeSource.Department
                Status = employeeSource.Status
                Address.Assign(employeeSource.Address)
            End If
        End Sub
    End Class
    Public Enum EmployeeStatus
        Salaried = 0
        Commission = 1
        Terminated = 2
        OnLeave = 3
    End Enum
    Public Enum EmployeeDepartment
        Sales = 1
        Support = 2
        Shipping = 3
        Engineering = 4
        <Display(Name:="Human Resources")>
        HumanResources = 5
        Management = 6
        IT = 7
    End Enum
    '
    Public Class Subordinate
        Inherits Employee
        Public Property SupervisorID As Long
        Public Overrides Function Equals(obj As Object) As Boolean
            Dim s As Subordinate = TryCast(obj, Subordinate)
            If ReferenceEquals(s, Nothing) OrElse Not MyBase.Equals(obj) Then Return False
            Return SupervisorID = s.SupervisorID
        End Function
        Public Overrides Function GetHashCode() As Integer
            Return MyBase.GetHashCode()
        End Function
        Public Overrides Sub Assign(source As Entity(Of Long))
            MyBase.Assign(source)
            Dim subordinateSource = TryCast(source, Subordinate)
            If subordinateSource IsNot Nothing Then SupervisorID = subordinateSource.SupervisorID
        End Sub
    End Class
End Namespace
