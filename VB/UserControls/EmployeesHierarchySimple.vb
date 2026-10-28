Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.UITemplates.Collection.Models
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList

Namespace DevExpress.UITemplates.Collection.UserControls

    Public Partial Class EmployeesHierarchySimple
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
            AddHandler masterTree.FocusedNodeChanged, AddressOf OnMasterTreeFocusedNodeChanged
            detailBindingSource.DataSource = DataLayer.CreateNewEmployee()
            masterBindingSource.DataSource = DataLayer.LoadEmployees()
            masterTree.ExpandAll()
        End Sub
        Protected Overrides Sub OnHandleDestroyed(e As EventArgs)
            RemoveHandler detailBindingSource.ListChanged, AddressOf OnDetailEntityChanged
            RemoveHandler masterTree.FocusedNodeChanged, AddressOf OnMasterTreeFocusedNodeChanged
            MyBase.OnHandleDestroyed(e)
        End Sub
        Private Sub OnDetailEntityChanged(sender As Object, e As ListChangedEventArgs)
            UpdateEnabledButtonsState()
        End Sub
        Private originalEmployeeFromDataBase As Collection.Models.Subordinate
        Private Sub OnMasterTreeFocusedNodeChanged(sender As Object, e As FocusedNodeChangedEventArgs)
            originalEmployeeFromDataBase = TryCast(masterTree.GetRow(e.Node.Id), Collection.Models.Subordinate)
            Dim employeeForEditing = DataLayer.CreateNewEmployee()
            employeeForEditing.Assign(originalEmployeeFromDataBase)
            detailBindingSource.DataSource = employeeForEditing
            UpdateEnabledButtonsState()
        End Sub
        Private Function GetNextEmployeeID() As Long
            Dim all = CType(masterBindingSource.DataSource, BindingList(Of Subordinate))

            If all.Count = 0 Then
                Return 1L
            End If

            Return all.Max(Function(x) x.ID) + 1
        End Function
        Private Sub OnNewSupervisor(sender As Object, e As ItemClickEventArgs)
            Dim newSupervisor = DataLayer.CreateNewEmployee()
            newSupervisor.SupervisorID = DataLayer.DefaultSupervisorID
            newSupervisor.ID = GetNextEmployeeID()
            masterBindingSource.Add(newSupervisor)
            masterTree.FocusedNode = masterTree.FindNodeByFieldValue(NameOf(Subordinate.ID), newSupervisor.ID)
        End Sub
        Private Sub OnNewSubordinate(sender As Object, e As ItemClickEventArgs)
            Dim supervisorID As Long = CType(masterTree.FocusedNode.GetValue(NameOf(Collection.Models.Subordinate.ID)), Long)
            Dim newSubordinate = DataLayer.CreateNewEmployee()
            newSubordinate.SupervisorID = supervisorID
            newSubordinate.ID = GetNextEmployeeID()
            masterBindingSource.Add(newSubordinate)
            masterTree.FocusedNode = masterTree.FindNodeByFieldValue(NameOf(Subordinate.ID), newSubordinate.ID)
        End Sub
        Private Sub OnDelete(sender As Object, e As ItemClickEventArgs)
            Dim employeeToDelete = TryCast(masterTree.GetFocusedRow(), DevExpress.UITemplates.Collection.Models.Subordinate)
            If employeeToDelete IsNot Nothing Then
                Dim employeeID As Long = CType(masterTree.FocusedNode.GetValue(NameOf(Collection.Models.Subordinate.ID)), Long)
                If DataLayer.DeleteEmployeeFromDataBase(employeeID, employeeToDelete) Then masterBindingSource.Remove(employeeToDelete)
            End If
        End Sub
        Private Sub OnSave(sender As Object, e As ItemClickEventArgs)
            Dim editingEmployee = TryCast(detailBindingSource.DataSource, DevExpress.UITemplates.Collection.Models.Subordinate)
            Dim employeeID As Long = CType(masterTree.FocusedNode.GetValue(NameOf(Collection.Models.Subordinate.ID)), Long)
            DataLayer.SaveEmployeeToDataBase(employeeID, editingEmployee, True)
            originalEmployeeFromDataBase.Assign(editingEmployee)
            detailBindingSource.ResetCurrentItem()
            masterBindingSource.ResetBindings(False)
        End Sub
        Private Sub OnResetChanges(sender As Object, e As ItemClickEventArgs)
            Dim editingEmployee = TryCast(detailBindingSource.DataSource, DevExpress.UITemplates.Collection.Models.Subordinate)
            editingEmployee.Assign(originalEmployeeFromDataBase)
            detailBindingSource.ResetCurrentItem()
            masterBindingSource.ResetBindings(False)
        End Sub
        Private Sub UpdateEnabledButtonsState()
            Dim editingEmployee = TryCast(detailBindingSource.DataSource, DevExpress.UITemplates.Collection.Models.Subordinate)
            Dim allEmployees = TryCast(masterBindingSource.DataSource, BindingList(Of DevExpress.UITemplates.Collection.Models.Subordinate))
            Dim hasChangesInEditors As Boolean = Not editingEmployee.Equals(originalEmployeeFromDataBase)
            bbiSave.Enabled = hasChangesInEditors AndAlso Me.Validate(editingEmployee)
            bbiResetChanges.Enabled = hasChangesInEditors
            bbiNewSupervisor.Enabled = editingEmployee.SupervisorID <> DataLayer.DefaultSupervisorID
            bbiDelete.Enabled = allEmployees IsNot Nothing AndAlso Not allEmployees.Any(Function(x) x.SupervisorID = editingEmployee.ID)
        End Sub
        Private Function Validate(employee As Collection.Models.Employee) As Boolean
            Dim validationResults = New List(Of ValidationResult)()
            If Not Validator.TryValidateObject(employee, New ValidationContext(employee), validationResults) Then Return False
            Return validationResults.Count = 0
        End Function
        Friend NotInheritable Class DataLayer
            Public Const DefaultSupervisorID As Long = -1
            Shared Sub New()
                Collection.Models.EmployeeSampleData.Employee1.Photo = Collection.Images.Users.SampleUser1
                Collection.Models.EmployeeSampleData.Employee2.Photo = Collection.Images.Users.SampleUser2
                Collection.Models.EmployeeSampleData.Employee3.Photo = Collection.Images.Users.SampleUser3
            End Sub
            Public Shared Function CreateNewEmployee() As Collection.Models.Subordinate
                Return New Collection.Models.Subordinate With {
                    .Address = New Collection.Models.USAddress(),
                    .SupervisorID = DefaultSupervisorID
                }
            End Function
            Public Shared Function LoadEmployees() As BindingList(Of Collection.Models.Subordinate)
                Dim employees As BindingList(Of DevExpress.UITemplates.Collection.Models.Subordinate) = New BindingList(Of DevExpress.UITemplates.Collection.Models.Subordinate)()
                Dim manager = CreateNewEmployee()
                manager.Assign(Collection.Models.EmployeeSampleData.Employee3)
                Dim e1 = CreateNewEmployee()
                e1.Assign(Collection.Models.EmployeeSampleData.Employee1)
                Dim e2 = CreateNewEmployee()
                e2.Assign(Collection.Models.EmployeeSampleData.Employee2)
                Dim e4 = CreateNewEmployee()
                e4.Assign(Collection.Models.EmployeeSampleData.Employee4)
                Dim e5 = CreateNewEmployee()
                e5.Assign(Collection.Models.EmployeeSampleData.Employee5)
                e1.SupervisorID = &H03L
                e2.SupervisorID = &H03L
                e4.SupervisorID = &H03L
                e5.SupervisorID = &H03L
                employees.Add(manager)
                employees.Add(e1)
                employees.Add(e2)
                employees.Add(e4)
                employees.Add(e5)
                Return employees
            End Function
            Public Shared Function SaveEmployeeToDataBase(id As Long, employee As Collection.Models.Subordinate, isNew As Boolean) As Long
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
                    Dim newEmployeeId As Long = 0
                    Return newEmployeeId
                End If
            End Function
            Public Shared Function DeleteEmployeeFromDataBase(id As Long, employee As Collection.Models.Subordinate) As Boolean
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
