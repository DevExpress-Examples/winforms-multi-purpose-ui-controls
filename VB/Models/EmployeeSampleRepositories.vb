Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.UITemplates.Collection.Models

Namespace DevExpress.UITemplates.Collection.Repositories

    Public Class InMemorySampleRepositoryForEmployees
        Inherits Repositories.InMemoryRepository(Of Long, Employee)
        Protected Overrides Sub OnInitializeStorage(dataBase As Dictionary(Of Long, Employee))
            dataBase.Add(&H01L, Assign(CreateEntity(), Employee1))
            dataBase.Add(&H02L, Assign(CreateEntity(), Employee2))
            dataBase.Add(&H03L, Assign(CreateEntity(), Employee3))
            dataBase.Add(&H04L, Assign(CreateEntity(), Employee4))
            dataBase.Add(&H05L, Assign(CreateEntity(), Employee5))
        End Sub
        Public Overrides ReadOnly Property NewEntityID As Long
            Get
                Return Long.MinValue
            End Get
        End Property
        Protected Overrides Function GenerateNextID() As Long
            Return StorageKeys.Max() + 1
        End Function
        Protected Overrides Function CreateEntity() As Employee
            Return New Employee() With {
                .Address = New USAddress()
            }
        End Function
        Protected Overrides Function Assign(target As Employee, source As Employee) As Employee
            target.Assign(source)
            Return target
        End Function
        Protected Overrides Function Equals(target As Employee, source As Employee) As Boolean
            Return target.Equals(source)
        End Function
    End Class
    Public Class InMemorySampleRepositoryForSubordinate
        Inherits Repositories.InMemoryRepository(Of Long, Subordinate)
        Protected Overrides Sub OnInitializeStorage(dataBase As Dictionary(Of Long, Subordinate))
            Dim ceo = CreateEntity()
            ceo.Assign(Employee3)
            Dim e1 = CreateEntity()
            e1.Assign(Employee1)
            Dim e2 = CreateEntity()
            e2.Assign(Employee2)
            Dim e4 = CreateEntity()
            e4.Assign(Employee4)
            Dim e5 = CreateEntity()
            e5.Assign(Employee5)
            ceo.SupervisorID = -1
            e1.SupervisorID = ceo.ID
            e2.SupervisorID = ceo.ID
            e4.SupervisorID = ceo.ID
            e5.SupervisorID = ceo.ID
            dataBase.Add(ceo.ID, ceo)
            dataBase.Add(e1.ID, e1)
            dataBase.Add(e2.ID, e2)
            dataBase.Add(e4.ID, e4)
            dataBase.Add(e5.ID, e5)
        End Sub
        Public Overrides ReadOnly Property NewEntityID As Long
            Get
                Return Long.MinValue
            End Get
        End Property
        Protected Overrides Function GenerateNextID() As Long
            Return StorageKeys.Max() + 1
        End Function
        Protected Overrides Function CreateEntity() As Subordinate
            Return New Subordinate() With {
                .Address = New USAddress()
            }
        End Function
        Protected Overrides Function Assign(target As Subordinate, source As Subordinate) As Subordinate
            target.Assign(source)
            Return target
        End Function
        Protected Overrides Function Equals(target As Subordinate, source As Subordinate) As Boolean
            Return target.Equals(source)
        End Function
    End Class
End Namespace
