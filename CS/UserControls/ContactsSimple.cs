namespace DevExpress.UITemplates.Collection.UserControls {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using DevExpress.UITemplates.Collection.Images;
    using DevExpress.UITemplates.Collection.Models;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;

    public partial class ContactsSimple : XtraUserControl {
        public ContactsSimple() {
            InitializeComponent();
            if(!DesignMode) {
                InitializeEditors();
                InitData();
            }
        }
        void InitData() {
            contactsBindingSource.DataSource = DataLayer.LoadEmployees();
            contactsBindingSource.AddingNew += OnContactsBindingSourceAddingNew;
            colDepartment.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
        }
        void InitializeEditors() {
            bicbStatus.Items.Add("(All)", (EmployeeStatus)(-1), -1);
            bicbStatus.Items.AddEnum<EmployeeStatus>();
            icbStatus.Items.AddEnum<EmployeeStatus>();
            icbPrefix.Items.AddEnum<PersonPrefix>();
            icbPrefix.SmallImages = PersonPrefixes.SvgImages;
            beStatusFilter.EditValue = (EmployeeStatus)(-1);
            colMobilePhone.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            colMobilePhone.ImageOptions.SvgImage = DataEntry.Phone;
            colFullName.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            colFullName.ImageOptions.SvgImage = DataEntry.Employees;
        }
        void OnRowCellClick(object sender, XtraGrid.Views.Grid.RowCellClickEventArgs e) {
            if(e.RowHandle > -1 && e.Column.FieldName == nameof(Employee.Email))
                DevExpress.Data.Utils.SafeProcess.TryOpenHyperlinkWithValidation("mailto:" + (string)e.CellValue);
        }
        void OnCustomRowCellEditForEditing(object sender, XtraGrid.Views.Grid.CustomRowCellEditEventArgs e) {
            if(e.Column == colEmail) e.RepositoryItem = teMail;
        }
        void OnEditFormShowing(object sender, XtraGrid.Views.Grid.EditFormShowingEventArgs e) {
            foreach(GridColumn column in contactsGridView.Columns) {
                bool isRequired = column.ColumnAnnotationAttributes.IsRequired.GetValueOrDefault();
                string caption = column.GetCaption() + (isRequired ? " <color=red>*</color>" : string.Empty);
                column.OptionsEditForm.Caption = caption;
            }
        }
        void OnShowingPopupEditForm(object sender, XtraGrid.Views.Grid.ShowingPopupEditFormEventArgs e) {
            e.EditForm.IconOptions.SvgImage = DataEntry.Employees;
            GridView view = sender as GridView;
            if(GetParent(view) != null)
                e.EditForm.Location = GetParent(view).PointToScreen(new Point(
                    view.GridControl.Location.X - (e.EditForm.Width - view.GridControl.Width) / 2,
                    view.GridControl.Location.Y - (e.EditForm.Height - view.GridControl.Height) / 2));
            else
                e.EditForm.StartPosition = FormStartPosition.CenterParent;
        }
        Control GetParent(GridView view) {
            return view?.GridControl.Parent;
        }
        void OnStatusFilterChanged(object sender, EventArgs e) {
            var status = (EmployeeStatus)beStatusFilter.EditValue;
            if(status == (EmployeeStatus)(-1))
                contactsBindingSource.DataSource = DataLayer.LoadEmployees();
            else
                contactsBindingSource.DataSource = DataLayer.LoadEmployees(x => x.Status == status);
        }
        void OnContactsBindingSourceAddingNew(object sender, AddingNewEventArgs e) {
            e.NewObject = DataLayer.CreateNewEmployee();
        }
        protected override void OnHandleDestroyed(EventArgs e) {
            contactsBindingSource.AddingNew -= OnContactsBindingSourceAddingNew;
            base.OnHandleDestroyed(e);
        }
        Employee currentEmployee;
        void OnFocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e) {
            currentEmployee = e.Row as Employee;
            UpdateButtonsEnabledState();
        }
        void OnNew(object sender, ItemClickEventArgs e) {
            contactsGridView.AddNewRow();
            contactsGridView.ShowEditForm();
        }
        void OnDelete(object sender, ItemClickEventArgs e) {
            int employeeID = contactsGridView.GetDataSourceRowIndex(contactsGridView.FocusedRowHandle);
            if(DataLayer.DeleteEmployeeFromDataBase(employeeID, currentEmployee))
                contactsBindingSource.Remove(currentEmployee);
        }
        void OnReload(object sender, ItemClickEventArgs e) {
            contactsBindingSource.ResetBindings(false);
        }
        void OnPrint(object sender, ItemClickEventArgs e) {
            contactsGridView.ShowPrintPreview();
        }
        void UpdateButtonsEnabledState() {
            bbiReload.Enabled = bbiDelete.Enabled = bbiPrint.Enabled = (currentEmployee != null);
        }
        //
        static class DataLayer {
            static DataLayer() {
                EmployeeSampleData.Employee1.Photo = Images.Users.SampleUser1;
                EmployeeSampleData.Employee2.Photo = Images.Users.SampleUser2;
                EmployeeSampleData.Employee3.Photo = Images.Users.SampleUser3;
            }
            public static Employee CreateNewEmployee() {
                return new Employee { Address = new USAddress() };
            }
            public static BindingList<Employee> LoadEmployees(Func<Employee, bool> filter) {
                var employees = LoadEmployees();
                if(filter == null)
                    return employees;
                var filtered = employees.Where(filter).ToList();
                return new BindingList<Employee>(filtered);
            }
            public static BindingList<Employee> LoadEmployees() {
                BindingList<Employee> employees = new BindingList<Employee>();
                /*
                 * Here you should load employee information from the database.
                 */
                foreach(var sampleEmployee in EmployeeSampleData.Employees) {
                    var employee = CreateNewEmployee();
                    employee.Assign(sampleEmployee);
                    employees.Add(employee);
                }
                return employees;
            }
            public static bool DeleteEmployeeFromDataBase(int id, Employee employee) {
                string q = $"Do you really want to delete {employee.FullName} employee?";
                if(XtraMessageBox.Show(q, "Employee Deletion", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return false;
                /*
                 * Here you should remove a record from the database.
                 * The 'id' parameter identifies the record.
                 */
                return true;
            }
        }
    }
}
