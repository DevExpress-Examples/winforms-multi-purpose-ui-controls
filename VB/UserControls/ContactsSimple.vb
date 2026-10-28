Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.UITemplates.Collection.Images
Imports DevExpress.UITemplates.Collection.Models
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Namespace DevExpress.UITemplates.Collection.UserControls

    Public Partial Class ContactsSimple
        Inherits XtraUserControl
        Public Sub New()
            InitializeComponent()
            If Not DesignMode Then
                InitializeEditors()
                InitData()
            End If
        End Sub
        Private Sub InitData()
            contactsBindingSource.DataSource = DataLayer.LoadEmployees()
            AddHandler contactsBindingSource.AddingNew, AddressOf OnContactsBindingSourceAddingNew
            colDepartment.SortOrder = Data.ColumnSortOrder.Descending
        End Sub
        Private Sub InitializeEditors()
            bicbStatus.Items.Add("(All)", CType(-1, Collection.Models.EmployeeStatus), -1)
            bicbStatus.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.EmployeeStatus)()
            icbStatus.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.EmployeeStatus)()
            icbPrefix.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.PersonPrefix)()
            icbPrefix.SmallImages = Collection.Images.PersonPrefixes.SvgImages
            beStatusFilter.EditValue = CType(-1, Collection.Models.EmployeeStatus)
            colMobilePhone.ImageOptions.SvgImageSize = New Size(16, 16)
            colMobilePhone.ImageOptions.SvgImage = Collection.Images.DataEntry.Phone
            colFullName.ImageOptions.SvgImageSize = New Size(16, 16)
            colFullName.ImageOptions.SvgImage = Collection.Images.DataEntry.Employees
        End Sub
        Private Sub OnRowCellClick(sender As Object, e As RowCellClickEventArgs)
            If e.RowHandle > -1 AndAlso Equals(e.Column.FieldName, NameOf(Collection.Models.Employee.Email)) Then Data.Utils.SafeProcess.TryOpenHyperlinkWithValidation("mailto:" & CStr(e.CellValue))
        End Sub
        Private Sub OnCustomRowCellEditForEditing(sender As Object, e As CustomRowCellEditEventArgs)
            If e.Column Is colEmail Then e.RepositoryItem = teMail
        End Sub
        Private Sub OnEditFormShowing(sender As Object, e As EditFormShowingEventArgs)
            For Each column As GridColumn In contactsGridView.Columns
                Dim isRequired As Boolean = column.ColumnAnnotationAttributes.IsRequired.GetValueOrDefault()
                Dim caption As String = column.GetCaption() & If(isRequired, " <color=red>*</color>", String.Empty)
                column.OptionsEditForm.Caption = caption
            Next
        End Sub
        Private Sub OnShowingPopupEditForm(sender As Object, e As ShowingPopupEditFormEventArgs)
            e.EditForm.IconOptions.SvgImage = Collection.Images.DataEntry.Employees
            Dim view As GridView = TryCast(sender, GridView)
            If GetParent(view) IsNot Nothing Then
                e.EditForm.Location = GetParent(view).PointToScreen(
                    New Point(view.GridControl.Location.X - (e.EditForm.Width - view.GridControl.Width) \ 2,
                              view.GridControl.Location.Y - (e.EditForm.Height - view.GridControl.Height) \ 2))
            Else
                e.EditForm.StartPosition = FormStartPosition.CenterParent
            End If
        End Sub
        Private Function GetParent(view As GridView) As Control
            Return view?.GridControl.Parent
        End Function
        Private Sub OnStatusFilterChanged(sender As Object, e As EventArgs)
            Dim status = CType(beStatusFilter.EditValue, DevExpress.UITemplates.Collection.Models.EmployeeStatus)
            If status = CType(-1, Collection.Models.EmployeeStatus) Then
                contactsBindingSource.DataSource = DataLayer.LoadEmployees()
            Else
                contactsBindingSource.DataSource = DataLayer.LoadEmployees(Function(x) x.Status = status)
            End If
        End Sub
        Private Sub OnContactsBindingSourceAddingNew(sender As Object, e As AddingNewEventArgs)
            e.NewObject = DataLayer.CreateNewEmployee()
        End Sub
        Protected Overrides Sub OnHandleDestroyed(e As EventArgs)
            RemoveHandler contactsBindingSource.AddingNew, AddressOf OnContactsBindingSourceAddingNew
            MyBase.OnHandleDestroyed(e)
        End Sub
        Private currentEmployee As Collection.Models.Employee
        Private Sub OnFocusedRowObjectChanged(sender As Object, e As FocusedRowObjectChangedEventArgs)
            currentEmployee = TryCast(e.Row, Collection.Models.Employee)
            UpdateButtonsEnabledState()
        End Sub
        Private Sub OnNew(sender As Object, e As ItemClickEventArgs)
            contactsGridView.AddNewRow()
            contactsGridView.ShowEditForm()
        End Sub
        Private Sub OnDelete(sender As Object, e As ItemClickEventArgs)
            Dim employeeID = contactsGridView.GetDataSourceRowIndex(contactsGridView.FocusedRowHandle)
            If DataLayer.DeleteEmployeeFromDataBase(employeeID, currentEmployee) Then contactsBindingSource.Remove(currentEmployee)
        End Sub
        Private Sub OnReload(sender As Object, e As ItemClickEventArgs)
            contactsBindingSource.ResetBindings(False)
        End Sub
        Private Sub OnPrint(sender As Object, e As ItemClickEventArgs)
            contactsGridView.ShowPrintPreview()
        End Sub
        Private Sub UpdateButtonsEnabledState()
            Dim enabled = currentEmployee IsNot Nothing

            bbiReload.Enabled = enabled
            bbiDelete.Enabled = enabled
            bbiPrint.Enabled = enabled
        End Sub
        '
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
            Public Shared Function LoadEmployees(filter As Func(Of Collection.Models.Employee, Boolean)) As BindingList(Of Collection.Models.Employee)
                Dim employees = LoadEmployees()
                If filter Is Nothing Then Return employees
                Dim filtered = employees.Where(filter).ToList()
                Return New BindingList(Of DevExpress.UITemplates.Collection.Models.Employee)(filtered)
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
