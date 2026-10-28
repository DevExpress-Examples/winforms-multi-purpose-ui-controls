Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Windows.Forms
Imports DevExpress.UITemplates.Collection.Models
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base

Namespace DevExpress.UITemplates.Collection.UserControls

    Public Partial Class EmployeesMasterDetailSimple
        Inherits XtraUserControl
        Public Sub New()
            InitializeComponent()
            If Not DesignMode Then
                InitializeEditors()
                InitData()
            End If
        End Sub
        Private Sub InitializeEditors()
            StatusImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.EmployeeStatus)()
            PrefixImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.PersonPrefix)()
            DepartmentImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.EmployeeDepartment)()
            StateImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.USState)()
        End Sub
        Private Sub InitData()
            AddHandler detailBindingSource.ListChanged, AddressOf OnDetailEntityChanged
            AddHandler masterGridView.FocusedRowObjectChanged, AddressOf OnMasterGridViewFocusedRowObjectChanged
            detailBindingSource.DataSource = DataLayer.CreateNewEmployee()
            masterBindingSource.DataSource = DataLayer.LoadEmployees()
        End Sub
        Protected Overrides Sub OnHandleDestroyed(e As EventArgs)
            RemoveHandler detailBindingSource.ListChanged, AddressOf OnDetailEntityChanged
            RemoveHandler masterGridView.FocusedRowObjectChanged, AddressOf OnMasterGridViewFocusedRowObjectChanged
            MyBase.OnHandleDestroyed(e)
        End Sub
        Private Sub OnDetailEntityChanged(sender As Object, e As ListChangedEventArgs)
            UpdateButtonsEnabledState()
        End Sub
        Private originalEmployeeFromDataBase As Collection.Models.Employee
        Private Sub OnMasterGridViewFocusedRowObjectChanged(sender As Object, e As FocusedRowObjectChangedEventArgs)
            originalEmployeeFromDataBase = TryCast(e.Row, Collection.Models.Employee)
            Dim employeeForEditing = DataLayer.CreateNewEmployee()
            employeeForEditing.Assign(originalEmployeeFromDataBase)
            detailBindingSource.DataSource = employeeForEditing
            UpdateButtonsEnabledState()
        End Sub
        Private Sub OnNew(sender As Object, e As ItemClickEventArgs)
            Dim newEmployee = DataLayer.CreateNewEmployee()
            Dim index = masterBindingSource.Add(newEmployee)
            masterGridView.FocusedRowHandle = masterGridView.GetRowHandle(index)
        End Sub
        Private Sub OnDelete(sender As Object, e As ItemClickEventArgs)
            Dim employeeToDelete = TryCast(detailBindingSource.DataSource, DevExpress.UITemplates.Collection.Models.Employee)
            Dim employeeID = masterGridView.GetDataSourceRowIndex(masterGridView.FocusedRowHandle)
            If DataLayer.DeleteEmployeeFromDataBase(employeeID, employeeToDelete) Then masterBindingSource.Remove(employeeToDelete)
        End Sub
        Private Sub OnSave(sender As Object, e As ItemClickEventArgs)
            Dim editingEmployee = TryCast(detailBindingSource.DataSource, DevExpress.UITemplates.Collection.Models.Employee)
            Dim employeeID = masterGridView.GetDataSourceRowIndex(masterGridView.FocusedRowHandle)
            DataLayer.SaveEmployeeToDataBase(employeeID, editingEmployee, True)
            originalEmployeeFromDataBase.Assign(editingEmployee)
            detailBindingSource.ResetCurrentItem()
            masterBindingSource.ResetBindings(False)
        End Sub
        Private Sub OnResetChanges(sender As Object, e As ItemClickEventArgs)
            Dim editingEmployee = TryCast(detailBindingSource.DataSource, DevExpress.UITemplates.Collection.Models.Employee)
            editingEmployee.Assign(originalEmployeeFromDataBase)
            detailBindingSource.ResetCurrentItem()
            masterBindingSource.ResetBindings(False)
        End Sub
        Private Sub UpdateButtonsEnabledState()
            Dim editingEmployee As Collection.Models.Employee = TryCast(detailBindingSource.DataSource, Collection.Models.Employee)
            Dim hasChangesInEditors As Boolean = originalEmployeeFromDataBase IsNot Nothing AndAlso Not editingEmployee.Equals(originalEmployeeFromDataBase)
            bbiSave.Enabled = hasChangesInEditors AndAlso Me.Validate(editingEmployee)
            bbiResetChanges.Enabled = hasChangesInEditors
            bbiDelete.Enabled = originalEmployeeFromDataBase IsNot Nothing
        End Sub
        Private Function Validate(employee As Collection.Models.Employee) As Boolean
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
            Public Shared Function CreateNewEmployee() As Collection.Models.Employee
                Return New Collection.Models.Employee With {
                    .Address = New Collection.Models.USAddress()
                }
            End Function
            Public Shared Function LoadEmployees() As BindingList(Of Collection.Models.Employee)
                Dim employees As BindingList(Of DevExpress.UITemplates.Collection.Models.Employee) = New BindingList(Of DevExpress.UITemplates.Collection.Models.Employee)()
                ' 
                '  Here you should load employee information from the database.
                ' 
                For Each sampleEmployee In Collection.Models.EmployeeSampleData.Employees
                    Dim employee = CreateNewEmployee()
                    employee.Assign(sampleEmployee)
                    employees.Add(employee)
                Next
                Return employees
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
            Public Shared Function DeleteEmployeeFromDataBase(id As Integer, employee As Collection.Models.Employee) As Boolean
                Dim q = $"Do you really want to delete {employee.FullName} employee?"
                If XtraMessageBox.Show(q, "Employee Deletion", MessageBoxButtons.YesNo) <> DialogResult.Yes Then Return False
                ' 
                '  Here you should remove a record from the database.
                '  The 'id' parameter identifies the record.
                ' 
                Return True
            End Function
        End Class
    End Class
End Namespace
