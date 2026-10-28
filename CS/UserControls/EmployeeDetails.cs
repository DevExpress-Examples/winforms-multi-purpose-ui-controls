namespace DevExpress.UITemplates.Collection.UserControls {
    using DevExpress.Mvvm.POCO;
    using DevExpress.UITemplates.Collection.Models;
    using DevExpress.UITemplates.Collection.ViewModels;
    using DevExpress.XtraEditors;

    public partial class EmployeeDetails : XtraUserControl {
        public EmployeeDetails() {
            InitializeComponent();
            if(!mvvmContext.IsDesignMode) {
                InitializeEditors();
                InitializeBinding();
            }
            else employeeBindingSource.DataSource = EmployeeSampleData.Employee1;
        }
        void InitializeEditors() {
            StatusImageComboBoxEdit.Properties.Items.AddEnum<EmployeeStatus>();
            PrefixImageComboBoxEdit.Properties.Items.AddEnum<PersonPrefix>();
            DepartmentImageComboBoxEdit.Properties.Items.AddEnum<EmployeeDepartment>();
            StateImageComboBoxEdit.Properties.Items.AddEnum<USState>();
        }
        void InitializeBinding() {
            /*
             * Here you should register your 'real' repository.
             * Example:
             * var repository = new Repositories.EF6SampleRepositoryForEmployees();
             */
            var repository = new InMemorySampleRepository();
            mvvmContext.RegisterService(repository);
            // Bind entity data to the editors. 
            var fluent = mvvmContext.OfType<ViewModel>();
            fluent.SetObjectDataSourceBinding(employeeBindingSource, x => x.Entity, x => x.Update);
            fluent.SetBinding(this, uc => uc.Text, x => x.Title);
            // Bind life-cycle events.
            fluent.WithEvent(this, nameof(HandleCreated))
                .EventToCommand(x => x.OnCreate);
            fluent.WithEvent(this, nameof(HandleDestroyed))
                .EventToCommand(x => x.OnDestroy);
            // Bind commands.
            fluent.BindCommand(bbiSave, x => x.Save);
            fluent.BindCommand(bbiClearEditors, x => x.ClearEditors);
            fluent.BindCommand(bbiResetChanges, x => x.Reset);
        }
        public class ViewModel : EntityViewModel<long, Employee> {
            protected override string GetName(Employee entity) {
                return entity.FullName;
            }
            public void OnCreate() {
                Load(0x01L/* some specific entity id */); 
                // or LoadNew();
            }
            // This is how you should implement a custom command.
            public bool CanClearEditors() {
                return (Entity != null) && !((InMemorySampleRepository)ReadOnlyRepository).IsEmpty(Entity);
            }
            public void ClearEditors() {
                ((InMemorySampleRepository)ReadOnlyRepository).Clear(Entity);
                Update();
                this.RaisePropertyChanged(x => x.Entity);
            }
            protected override void UpdateCommands() {
                base.UpdateCommands();
                this.RaiseCanExecuteChanged(x => x.ClearEditors());
            }
        }
        // You can remove this class if the real repository is used.
        sealed class InMemorySampleRepository : Repositories.InMemorySampleRepositoryForEmployees {
            static InMemorySampleRepository() {
                EmployeeSampleData.Employee1.Photo = Images.Users.SampleUser1;
                EmployeeSampleData.Employee2.Photo = Images.Users.SampleUser2;
                EmployeeSampleData.Employee3.Photo = Images.Users.SampleUser3;
            }
        }
    }
}
