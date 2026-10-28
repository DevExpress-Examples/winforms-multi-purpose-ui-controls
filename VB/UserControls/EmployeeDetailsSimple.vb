Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports DevExpress.UITemplates.Collection.Models
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors

Namespace DevExpress.UITemplates.Collection.UserControls

    Public Partial Class EmployeeDetailsSimple
        Inherits XtraUserControl
        Private isNew As Boolean
        Private employeeID As Integer
        Public Sub New()
            InitializeComponent()
            If Not DesignMode Then
                employeeID = 01
                isNew = False
                InitializeEditors()
                InitData()
            End If
        End Sub
        Public Sub LoadEmployee(employeeID As Integer, Optional isNew As Boolean = False)
            Me.employeeID = employeeID
            Me.isNew = isNew
            InitData()
        End Sub
        Private Sub InitializeEditors()
            StatusImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.EmployeeStatus)()
            PrefixImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.PersonPrefix)()
            DepartmentImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.EmployeeDepartment)()
            StateImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.USState)()
        End Sub
        Private originalEmployeeFromDataBase As Collection.Models.Employee
        Private Sub InitData()
            If isNew Then
                originalEmployeeFromDataBase = DataLayer.CreateNewEmployee()
            Else
                originalEmployeeFromDataBase = DataLayer.LoadEmployeeFromDatabase(employeeID)
            End If
            Dim employeeForEditing = DataLayer.CreateNewEmployee()
            employeeForEditing.Assign(originalEmployeeFromDataBase)
            employeeBindingSource.DataSource = employeeForEditing
            AddHandler employeeBindingSource.ListChanged, AddressOf OnEmployeeChanged
        End Sub
        Protected Overrides Sub OnHandleCreated(e As EventArgs)
            MyBase.OnHandleCreated(e)
            UpdateButtonsEnabledState()
        End Sub
        Protected Overrides Sub OnHandleDestroyed(e As EventArgs)
            RemoveHandler employeeBindingSource.ListChanged, AddressOf OnEmployeeChanged
            MyBase.OnHandleDestroyed(e)
        End Sub
        Private Sub OnEmployeeChanged(sender As Object, e As ListChangedEventArgs)
            UpdateButtonsEnabledState()
        End Sub
        Private Sub UpdateButtonsEnabledState()
            Dim editingEmployee As Collection.Models.Employee = TryCast(employeeBindingSource.DataSource, Collection.Models.Employee)
            Dim hasChangesInEditors As Boolean = originalEmployeeFromDataBase IsNot Nothing AndAlso Not editingEmployee.Equals(originalEmployeeFromDataBase)
            bbiSave.Enabled = hasChangesInEditors AndAlso Me.Validate(editingEmployee)
            bbiClearEditors.Enabled = Not editingEmployee.Equals(DataLayer.EmptyEmployee)
            bbiResetChanges.Enabled = hasChangesInEditors
        End Sub
        Private Sub OnSave(sender As Object, e As ItemClickEventArgs)
            ' 
            '  Here we save all the changes made.
            ' 
            Dim editingEmployee = TryCast(employeeBindingSource.DataSource, DevExpress.UITemplates.Collection.Models.Employee)
            If isNew Then
                employeeID = DataLayer.SaveEmployeeToDataBase(-1, editingEmployee, True)
                isNew = False
            Else
                DataLayer.SaveEmployeeToDataBase(employeeID, editingEmployee, True)
            End If
            originalEmployeeFromDataBase.Assign(editingEmployee)
            employeeBindingSource.ResetCurrentItem()
        End Sub
        Private Sub OnClearEditors(sender As Object, e As ItemClickEventArgs)
            ' 
            '  Here we clear all input fields (data editors).
            ' 
            Dim editingEmployee = TryCast(employeeBindingSource.DataSource, DevExpress.UITemplates.Collection.Models.Employee)
            editingEmployee.Assign(DataLayer.EmptyEmployee)
            employeeBindingSource.ResetCurrentItem()
        End Sub
        Private Sub OnResetChanges(sender As Object, e As ItemClickEventArgs)
            ' 
            '  Here we reset all input fields (data editors) to their default values.
            ' 
            Dim editingEmployee = TryCast(employeeBindingSource.DataSource, DevExpress.UITemplates.Collection.Models.Employee)
            editingEmployee.Assign(originalEmployeeFromDataBase)
            employeeBindingSource.ResetCurrentItem()
        End Sub
        Private Function Validate(employee As Collection.Models.Employee) As Boolean
            ' 
            '  This method validates the entity based on annotation attributes.
            ' 
            Dim validationResults = New List(Of ValidationResult)()
            If Not Validator.TryValidateObject(employee, New ValidationContext(employee), validationResults) Then Return False
            Return validationResults.Count = 0
        End Function
        Friend NotInheritable Class DataLayer
            Shared Sub New()
                Collection.Models.EmployeeSampleData.Employee1.Photo = Collection.Images.Users.SampleUser1
                Collection.Models.EmployeeSampleData.Employee2.Photo = Collection.Images.Users.SampleUser2
                Collection.Models.EmployeeSampleData.Employee3.Photo = Collection.Images.Users.SampleUser3
            End Sub
            Public ReadOnly Shared EmptyEmployee As Collection.Models.Employee = CreateNewEmployee()
            Public Shared Function CreateNewEmployee() As Collection.Models.Employee
                Return New Collection.Models.Employee With {
                    .Address = New Collection.Models.USAddress()
                }
            End Function
            Public Shared Function LoadEmployeeFromDatabase(id As Integer) As Collection.Models.Employee
                ' 
                '  Here you should load employee information from the database.
                ' 
                Dim employee = CreateNewEmployee()
                Dim employeeFromDataBase = Collection.Models.EmployeeSampleData.Employees.FirstOrDefault(Function(x) x.ID = id)
                employee.Assign(If(employeeFromDataBase, EmptyEmployee))
                Return employeeFromDataBase
            End Function
            Public Shared Function SaveEmployeeToDataBase(id As Integer, employee As Collection.Models.Employee, isNew As Boolean) As Integer
                If Not isNew Then
                    ' 
                    '  Here you should save the changes to the database.
                    '  The 'id' parameter identifies the record.
                    ' 
                    Return id
                Else
                    ' 
                    '  Here you should add a new record to the database and
                    '  return its unique identifier (ID).
                    ' 
                    Dim newEmployeeId = 0
                    Return newEmployeeId
                End If
            End Function
        End Class
    End Class
End Namespace
