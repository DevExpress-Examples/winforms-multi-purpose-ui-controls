namespace DevExpress.UITemplates.Collection.UserControls {
    using DevExpress.Mvvm.POCO;
    using DevExpress.UITemplates.Collection.Models;
    using DevExpress.UITemplates.Collection.ViewModels;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid.Views.Base;
    using DevExpress.XtraGrid.Views.Grid;

    public partial class EmployeesMasterDetail : XtraUserControl {
        public EmployeesMasterDetail() {
            InitializeComponent();
            if(!mvvmContextDetail.IsDesignMode) {
                InitializeEditors();
                InitializeDataServices();
                InitializeBindingForMaster();
                InitializeBindingForDetails();
            }
        }
        void InitializeEditors() {
            StatusImageComboBoxEdit.Properties.Items.AddEnum<EmployeeStatus>();
            PrefixImageComboBoxEdit.Properties.Items.AddEnum<PersonPrefix>();
            DepartmentImageComboBoxEdit.Properties.Items.AddEnum<EmployeeDepartment>();
            StateImageComboBoxEdit.Properties.Items.AddEnum<USState>();
        }
        void InitializeDataServices() {
            /*
             * Here you should register your 'real' repository.
             * Example:
             * var repository = new Repositories.EF6SampleRepositoryForEmployees();
             */
            var repository = new InMemorySampleRepository();
            mvvmContextMaster.RegisterService(repository);
            mvvmContextDetail.RegisterService(repository);
        }
        void InitializeBindingForMaster() {
            // Bind the data grid.
            var fluent = mvvmContextMaster.OfType<MasterViewModel>();
            fluent.SetBinding(masterBindingSource, bs => bs.DataSource, x => x.Entities);
            fluent.SetBinding(masterGridView, view => view.FocusedRowObject, x => x.SelectedEntity);
            fluent.WithEvent<GridView, FocusedRowChangedEventArgs>(masterGridView, "FocusedRowChanged")
                .SetBinding(x => x.SelectedEntity, args => masterGridView.GetRow(args.FocusedRowHandle) as Employee,
                (gridView, entity) => {
                    if(entity == null) return;
                    int row = gridView.LocateByValue(nameof(Employee.ID), entity.ID);
                    if(row >= 0)
                        gridView.FocusedRowHandle = row;
                });
            // Bind life-cycle events.
            fluent.WithEvent(this, nameof(HandleCreated))
                .EventToCommand(x => x.OnCreate);
            fluent.WithEvent(this, nameof(HandleDestroyed))
                .EventToCommand(x => x.OnDestroy);
            // Bind commands.
            fluent.BindCommand(bbiDelete, x => x.Delete);
        }
        void InitializeBindingForDetails() {
            // Bind entity data to the editors.
            var fluent = mvvmContextDetail.OfType<DetailViewModel>();
            fluent.SetObjectDataSourceBinding(detailBindingSource, x => x.Entity, x => x.Update);
            fluent.SetBinding(this, uc => uc.Text, x => x.Title);
            // Bind life-cycle events.
            fluent.WithEvent(this, nameof(HandleDestroyed))
                .EventToCommand(x => x.OnDestroy);
            // Bind commands.
            fluent.BindCommand(bbiSave, x => x.Save);
            fluent.BindCommand(bbiNew, x => x.New);
            fluent.BindCommand(bbiResetChanges, x => x.Reset);
        }
        public class MasterViewModel : EntitiesViewModel<long, Employee> {
            public void OnCreate() {
                ReloadEntities();
            }
            protected override string GetName(Employee entity) {
                return entity.FullName;
            }
        }
        public class DetailViewModel : EntityViewModel<long, Employee> {
            protected override string GetName(Employee entity) {
                return entity.FullName;
            }
            // This is how you should implement a custom command.
            public void New() {
                LoadNew();
            }
            protected override void UpdateCommands() {
                base.UpdateCommands();
                this.RaiseCanExecuteChanged(x => x.New());
            }
        }
        sealed class InMemorySampleRepository : Repositories.InMemorySampleRepositoryForEmployees {
            static InMemorySampleRepository() {
                EmployeeSampleData.Employee1.Photo = Images.Users.SampleUser1;
                EmployeeSampleData.Employee2.Photo = Images.Users.SampleUser2;
                EmployeeSampleData.Employee3.Photo = Images.Users.SampleUser3;
            }
        }
    }
}