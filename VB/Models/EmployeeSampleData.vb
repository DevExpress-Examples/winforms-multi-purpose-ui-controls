Imports System.Collections.Generic

Namespace DevExpress.UITemplates.Collection.Models

    Public Module EmployeeSampleData
        '
        '
        Private _Employee1 As DevExpress.UITemplates.Collection.Models.Employee, _Employee2 As DevExpress.UITemplates.Collection.Models.Employee, _Employee3 As DevExpress.UITemplates.Collection.Models.Employee, _Employee4 As DevExpress.UITemplates.Collection.Models.Employee, _Employee5 As DevExpress.UITemplates.Collection.Models.Employee, _Employees As System.Collections.Generic.IReadOnlyCollection(Of DevExpress.UITemplates.Collection.Models.Employee)
        Sub New()
            Employee1 = New Employee() With {
                .ID = &H01,
                .FirstName = "Bradley",
                .LastName = "Jameson",
                .BirthDate = New Date(1988, 12, 10),
                .Title = "Software Developer",
                .Prefix = PersonPrefix.Mr,
                .Address = New USAddress() With {
                    .Line = "1100 Pico St",
                    .City = "San Fernando",
                    .State = USState.CA,
                    .ZipCode = "91340"
                },
                .HomePhone = "(818) 555-9098",
                .MobilePhone = "(818) 555-4646",
                .Email = "bradleyj@dx-email.com",
                .Department = EmployeeDepartment.IT,
                .Status = EmployeeStatus.Salaried,
                .HireDate = New Date(2011, 2, 3)
            }
            Employee2 = New Employee() With {
                .ID = &H02,
                .FirstName = "Leah",
                .LastName = "Simpson",
                .BirthDate = New Date(1983, 4, 19),
                .Title = "Test Coordinator",
                .Prefix = PersonPrefix.Mrs,
                .Address = New USAddress() With {
                    .Line = "6755 Newline Ave",
                    .City = "Whittier",
                    .State = USState.AK,
                    .ZipCode = "90601"
                },
                .HomePhone = "(562) 555-7372",
                .MobilePhone = "(562) 559-5830",
                .Email = "leahs@dx-email.com",
                .Department = EmployeeDepartment.Engineering,
                .Status = EmployeeStatus.Salaried,
                .HireDate = New Date(2009, 2, 14)
            }
            Employee3 = New Employee() With {
                .ID = &H03,
                .FirstName = "John",
                .LastName = "Heart",
                .BirthDate = New Date(1964, 3, 16),
                .Title = "CEO",
                .Prefix = PersonPrefix.Dr,
                .Address = New USAddress() With {
                    .Line = "351 S Hill St.",
                    .City = "Los Angeles",
                    .State = USState.CA,
                    .ZipCode = "90013"
                },
                .HomePhone = "(213) 555-9208",
                .MobilePhone = "(213) 555-9392",
                .Email = "jheart@dx-email.com",
                .Department = EmployeeDepartment.Management,
                .Status = EmployeeStatus.Commission,
                .HireDate = New Date(1995, 1, 15)
            }
            Employee4 = New Employee() With {
                .ID = &H04,
                .FirstName = "Wally",
                .LastName = "Hobbs",
                .BirthDate = New Date(1984, 12, 24),
                .Title = "Software Developer",
                .Prefix = PersonPrefix.Mr,
                .Address = New USAddress() With {
                    .Line = "10385 Shadow Oak Dr",
                    .City = "Chatsworth",
                    .State = USState.CA,
                    .ZipCode = "91311"
                },
                .HomePhone = "(818) 555-2478",
                .MobilePhone = "(818) 555-8872",
                .Email = "wallyh@dx-email.com",
                .Department = EmployeeDepartment.IT,
                .Status = EmployeeStatus.Salaried,
                .HireDate = New Date(2011, 2, 17)
            }
            Employee5 = New Employee() With {
                .ID = &H05,
                .FirstName = "Karen",
                .LastName = "Goodson",
                .BirthDate = New Date(1987, 4, 26),
                .Title = "Software Developer",
                .Prefix = PersonPrefix.Miss,
                .Address = New USAddress() With {
                    .Line = "309 Monterey Rd",
                    .City = "South Pasadena",
                    .State = USState.CA,
                    .ZipCode = "91030"
                },
                .HomePhone = "(626) 555-0822",
                .MobilePhone = "(626) 555-0908",
                .Email = "kareng@dx-email.com",
                .Department = EmployeeDepartment.IT,
                .Status = EmployeeStatus.OnLeave,
                .HireDate = New Date(2011, 3, 14)
            }
            Employees = New Employee() {Employee1, Employee2, Employee3, Employee4, Employee5}
        End Sub

        Public Property Employee1 As Employee
            Get
                Return _Employee1
            End Get
            Private Set(value As Employee)
                _Employee1 = value
            End Set
        End Property

        Public Property Employee2 As Employee
            Get
                Return _Employee2
            End Get
            Private Set(value As Employee)
                _Employee2 = value
            End Set
        End Property

        Public Property Employee3 As Employee
            Get
                Return _Employee3
            End Get
            Private Set(value As Employee)
                _Employee3 = value
            End Set
        End Property

        Public Property Employee4 As Employee
            Get
                Return _Employee4
            End Get
            Private Set(value As Employee)
                _Employee4 = value
            End Set
        End Property

        Public Property Employee5 As Employee
            Get
                Return _Employee5
            End Get
            Private Set(value As Employee)
                _Employee5 = value
            End Set
        End Property

        Public Property Employees As IReadOnlyCollection(Of Employee)
            Get
                Return _Employees
            End Get
            Private Set(value As IReadOnlyCollection(Of Employee))
                _Employees = value
            End Set
        End Property
    End Module
End Namespace
