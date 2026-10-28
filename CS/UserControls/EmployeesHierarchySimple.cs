namespace DevExpress.UITemplates.Collection.UserControls {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows.Forms;
    using DevExpress.UITemplates.Collection.Models;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraTreeList;

    public partial class EmployeesHierarchySimple : XtraUserControl {
        public EmployeesHierarchySimple() {
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
            masterTree.FocusedNodeChanged += OnMasterTreeFocusedNodeChanged;
            detailBindingSource.DataSource = DataLayer.CreateNewEmployee();
            masterBindingSource.DataSource = DataLayer.LoadEmployees();
            masterTree.ExpandAll();
        }
        protected override void OnHandleDestroyed(EventArgs e) {
            detailBindingSource.ListChanged -= OnDetailEntityChanged;
            masterTree.FocusedNodeChanged -= OnMasterTreeFocusedNodeChanged;
            base.OnHandleDestroyed(e);
        }
        void OnDetailEntityChanged(object sender, ListChangedEventArgs e) {
            UpdateEnabledButtonsState();
        }
        Subordinate originalEmployeeFromDataBase;
        void OnMasterTreeFocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e) {
            originalEmployeeFromDataBase = masterTree.GetRow(e.Node.Id) as Subordinate;
            var employeeForEditing = DataLayer.CreateNewEmployee();
            employeeForEditing.Assign(originalEmployeeFromDataBase);
            detailBindingSource.DataSource = employeeForEditing;
            UpdateEnabledButtonsState();
        }
        long GetNextEmployeeID() {
            var all = (BindingList<Subordinate>)masterBindingSource.DataSource;
            return all.Count == 0 ? 1 : all.Max(x => x.ID) + 1;
        }
        void OnNewSupervisor(object sender, ItemClickEventArgs e) {
            var newSupervisor = DataLayer.CreateNewEmployee();
            newSupervisor.SupervisorID = DataLayer.DefaultSupervisorID;
            newSupervisor.ID = GetNextEmployeeID();
            masterBindingSource.Add(newSupervisor);
            masterTree.FocusedNode = masterTree.FindNodeByFieldValue(nameof(Subordinate.ID), newSupervisor.ID);
        }
        void OnNewSubordinate(object sender, ItemClickEventArgs e) {
            long supervisorID = (long)masterTree.FocusedNode.GetValue(nameof(Subordinate.ID));
            var newSubordinate = DataLayer.CreateNewEmployee();
            newSubordinate.SupervisorID = supervisorID;
            newSubordinate.ID = GetNextEmployeeID();
            masterBindingSource.Add(newSubordinate);
            masterTree.FocusedNode = masterTree.FindNodeByFieldValue(nameof(Subordinate.ID), newSubordinate.ID);
        }
        void OnDelete(object sender, ItemClickEventArgs e) {
            var employeeToDelete = masterTree.GetFocusedRow() as Subordinate;
            if(employeeToDelete != null) {
                long employeeID = (long)masterTree.FocusedNode.GetValue(nameof(Subordinate.ID));
                if(DataLayer.DeleteEmployeeFromDataBase(employeeID, employeeToDelete))
                    masterBindingSource.Remove(employeeToDelete);
            }
        }
        void OnSave(object sender, ItemClickEventArgs e) {
            var editingEmployee = detailBindingSource.DataSource as Subordinate;
            long employeeID = (long)masterTree.FocusedNode.GetValue(nameof(Subordinate.ID));
            DataLayer.SaveEmployeeToDataBase(employeeID, editingEmployee, true);
            originalEmployeeFromDataBase.Assign(editingEmployee);
            detailBindingSource.ResetCurrentItem();
            masterBindingSource.ResetBindings(false);
        }
        void OnResetChanges(object sender, XtraBars.ItemClickEventArgs e) {
            var editingEmployee = detailBindingSource.DataSource as Subordinate;
            editingEmployee.Assign(originalEmployeeFromDataBase);
            detailBindingSource.ResetCurrentItem();
            masterBindingSource.ResetBindings(false);
        }
        void UpdateEnabledButtonsState() {
            var editingEmployee = detailBindingSource.DataSource as Subordinate;
            var allEmployees = masterBindingSource.DataSource as BindingList<Subordinate>;
            bool hasChangesInEditors = !editingEmployee.Equals(originalEmployeeFromDataBase);
            bbiSave.Enabled = hasChangesInEditors && Validate(editingEmployee);
            bbiResetChanges.Enabled = hasChangesInEditors;
            bbiNewSupervisor.Enabled = editingEmployee.SupervisorID != DataLayer.DefaultSupervisorID;
            bbiDelete.Enabled = (allEmployees != null) && !allEmployees.Any(x => x.SupervisorID == editingEmployee.ID);
        }
        bool Validate(Employee employee) {
            var validationResults = new List<ValidationResult>();
            if(!Validator.TryValidateObject(employee, new ValidationContext(employee), validationResults))
                return false;
            return validationResults.Count == 0;
        }
        static class DataLayer {
            public const long DefaultSupervisorID = -1;
            static DataLayer() {
                EmployeeSampleData.Employee1.Photo = Images.Users.SampleUser1;
                EmployeeSampleData.Employee2.Photo = Images.Users.SampleUser2;
                EmployeeSampleData.Employee3.Photo = Images.Users.SampleUser3;
            }
            public static Subordinate CreateNewEmployee() {
                return new Subordinate { Address = new USAddress(), SupervisorID = DefaultSupervisorID };
            }
            public static BindingList<Subordinate> LoadEmployees() {
                BindingList<Subordinate> employees = new BindingList<Subordinate>();
                var manager = CreateNewEmployee();
                manager.Assign(EmployeeSampleData.Employee3);
                var e1 = CreateNewEmployee();
                e1.Assign(EmployeeSampleData.Employee1);
                var e2 = CreateNewEmployee();
                e2.Assign(EmployeeSampleData.Employee2);
                var e4 = CreateNewEmployee();
                e4.Assign(EmployeeSampleData.Employee4);
                var e5 = CreateNewEmployee();
                e5.Assign(EmployeeSampleData.Employee5);
                e1.SupervisorID = 0x03L;
                e2.SupervisorID = 0x03L;
                e4.SupervisorID = 0x03L;
                e5.SupervisorID = 0x03L;
                employees.Add(manager);
                employees.Add(e1);
                employees.Add(e2);
                employees.Add(e4);
                employees.Add(e5);
                return employees;
            }
            public static long SaveEmployeeToDataBase(long id, Subordinate employee, bool isNew) {
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
                    long newEmployeeId = 0;
                    return newEmployeeId;
                }
            }
            public static bool DeleteEmployeeFromDataBase(long id, Subordinate employee) {
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