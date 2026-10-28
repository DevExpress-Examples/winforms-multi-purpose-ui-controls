namespace DevExpress.UITemplates.Collection.UserControls {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Windows.Forms;
    using DevExpress.UITemplates.Collection.Models;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid.Views.Base;

    public partial class EmployeesMasterDetailSimple : XtraUserControl {
        public EmployeesMasterDetailSimple() {
            InitializeComponent();
            if(!DesignMode) {
                InitializeEditors();
                InitData();
            }
        }
        void InitializeEditors() {
            StatusImageComboBoxEdit.Properties.Items.AddEnum<EmployeeStatus>();
            PrefixImageComboBoxEdit.Properties.Items.AddEnum<PersonPrefix>();
            DepartmentImageComboBoxEdit.Properties.Items.AddEnum<EmployeeDepartment>();
            StateImageComboBoxEdit.Properties.Items.AddEnum<USState>();
        }
        void InitData() {
            detailBindingSource.ListChanged += OnDetailEntityChanged;
            masterGridView.FocusedRowObjectChanged += OnMasterGridViewFocusedRowObjectChanged;
            detailBindingSource.DataSource = DataLayer.CreateNewEmployee();
            masterBindingSource.DataSource = DataLayer.LoadEmployees();
        }
        protected override void OnHandleDestroyed(EventArgs e) {
            detailBindingSource.ListChanged -= OnDetailEntityChanged;
            masterGridView.FocusedRowObjectChanged -= OnMasterGridViewFocusedRowObjectChanged;
            base.OnHandleDestroyed(e);
        }
        void OnDetailEntityChanged(object sender, ListChangedEventArgs e) {
            UpdateButtonsEnabledState();
        }
        Employee originalEmployeeFromDataBase;
        void OnMasterGridViewFocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e) {
            originalEmployeeFromDataBase = e.Row as Employee; 
            var employeeForEditing = DataLayer.CreateNewEmployee();
            employeeForEditing.Assign(originalEmployeeFromDataBase);
            detailBindingSource.DataSource = employeeForEditing;
            UpdateButtonsEnabledState();
        }
        void OnNew(object sender, ItemClickEventArgs e) {
            var newEmployee = DataLayer.CreateNewEmployee();
            int index = masterBindingSource.Add(newEmployee);
            masterGridView.FocusedRowHandle = masterGridView.GetRowHandle(index);
        }
        void OnDelete(object sender, ItemClickEventArgs e) {
            var employeeToDelete = detailBindingSource.DataSource as Employee;
            int employeeID = masterGridView.GetDataSourceRowIndex(masterGridView.FocusedRowHandle);
            if(DataLayer.DeleteEmployeeFromDataBase(employeeID, employeeToDelete))
                masterBindingSource.Remove(employeeToDelete);
        }
        void OnSave(object sender, ItemClickEventArgs e) {
            var editingEmployee = detailBindingSource.DataSource as Employee;
            int employeeID = masterGridView.GetDataSourceRowIndex(masterGridView.FocusedRowHandle);
            DataLayer.SaveEmployeeToDataBase(employeeID, editingEmployee, true);
            originalEmployeeFromDataBase.Assign(editingEmployee);
            detailBindingSource.ResetCurrentItem();
            masterBindingSource.ResetBindings(false);
        }
        void OnResetChanges(object sender, ItemClickEventArgs e) {
            var editingEmployee = detailBindingSource.DataSource as Employee;
            editingEmployee.Assign(originalEmployeeFromDataBase);
            detailBindingSource.ResetCurrentItem();
            masterBindingSource.ResetBindings(false);
        }
        void UpdateButtonsEnabledState() {
            Employee editingEmployee = detailBindingSource.DataSource as Employee;
            bool hasChangesInEditors = (originalEmployeeFromDataBase != null) && !editingEmployee.Equals(originalEmployeeFromDataBase);
            bbiSave.Enabled = hasChangesInEditors && Validate(editingEmployee);
            bbiResetChanges.Enabled = hasChangesInEditors;
            bbiDelete.Enabled = (originalEmployeeFromDataBase != null);
        }
        bool Validate(Employee employee) {
            var validationResults = new List<ValidationResult>();
            if(!Validator.TryValidateObject(employee, new ValidationContext(employee), validationResults))
                return false;
            return validationResults.Count == 0;
        }
        static class DataLayer {
            static DataLayer() {
                EmployeeSampleData.Employee1.Photo = Images.Users.SampleUser1;
                EmployeeSampleData.Employee2.Photo = Images.Users.SampleUser2;
                EmployeeSampleData.Employee3.Photo = Images.Users.SampleUser3;
            }
            public static Employee CreateNewEmployee() {
                return new Employee { Address = new USAddress() };
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
            public static int SaveEmployeeToDataBase(int id, Employee employee, bool isNew) {
                if(!isNew) {
                    /*
                     * Here you should save the changes to the database.
                     * The 'id' parameter identifies the record.
                     */
                    return id;
                }
                else {
                    /* 
                     * Here you should add a new record to the database and
                     * return its unique identifier (ID).
                     */
                    int newEmployeeId = 0;
                    return newEmployeeId;
                }
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
