namespace DevExpress.UITemplates.Collection.UserControls {
    using System.Linq;
    using DevExpress.Mvvm.POCO;
    using DevExpress.UITemplates.Collection.Models;
    using DevExpress.UITemplates.Collection.ViewModels;
    using DevExpress.XtraEditors;
    using DevExpress.XtraTreeList;

    public partial class EmployeesHierarchy : XtraUserControl {
        public EmployeesHierarchy() {
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
            * var repository = new Repositories.EF6SampleRepositoryForSubordinates();
            */
            var repository = new InMemorySampleRepository();
            mvvmContextMaster.RegisterService(repository);
            mvvmContextDetail.RegisterService(repository);
        }
        void InitializeBindingForMaster() {
            // Bind the data grid.
            var fluent = mvvmContextMaster.OfType<MasterViewModel>();
            fluent.SetTrigger(x => x.Entities, _ => masterTree.ExpandAll());
            fluent.SetBinding(masterBindingSource, bs => bs.DataSource, x => x.Entities);
            fluent.WithEvent<TreeList, FocusedNodeChangedEventArgs>(masterTree, "FocusedNodeChanged")
                .SetBinding(x => x.SelectedEntity, args => args.Node?.TreeList.GetDataRecordByNode(args.Node) as Subordinate,
                    (tree, entity) => {
                        if(entity == null) return;
                        var node = tree.FindNode(n => ReferenceEquals(tree.GetDataRecordByNode(n), entity));
                        if(node != null && tree.FocusedNode != node)
                            tree.FocusedNode = node;
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
            fluent.BindCommand(bbiNewSupervisor, x => x.NewSupervisor);
            fluent.BindCommand(bbiNewSubordinate, x => x.NewSubordinate);
            fluent.BindCommand(bbiResetChanges, x => x.Reset);
        }
        public class MasterViewModel : EntitiesViewModel<long, Subordinate> {
            public void OnCreate() {
                ReloadEntities();
            }
            protected override string GetName(Subordinate entity) {
                return entity.FullName;
            }
            public override bool CanDelete() {
                return SelectedEntity != null
                    && !Entities.Any(x => x.SupervisorID == SelectedEntity.ID);
            }
        }
        public class DetailViewModel : EntityViewModel<long, Subordinate> {
            const int DefaultSupervisorID = -1;
            //
            protected override string GetName(Subordinate entity) {
                return entity.FullName;
            }
            // This is how you should implement a custom command.
            public bool CanNewSupervisor() {
                return (Entity != null) && !IsNew && Entity.SupervisorID != DefaultSupervisorID;
            }
            public void NewSupervisor() {
                NewEmployee(DefaultSupervisorID);
            }
            public bool CanNewSubordinate() {
                return !IsNew;
            }
            public void NewSubordinate() {
                NewEmployee(Entity.ID);
            }
            void NewEmployee(long supervisorId) {
                LoadNew();
                Entity.SupervisorID = supervisorId;
            }
            protected override void UpdateCommands() {
                base.UpdateCommands();
                this.RaiseCanExecuteChanged(x => x.NewSupervisor());
                this.RaiseCanExecuteChanged(x => x.NewSubordinate());
            }
        }
        sealed class InMemorySampleRepository : Repositories.InMemorySampleRepositoryForSubordinate {
            static InMemorySampleRepository() {
                EmployeeSampleData.Employee1.Photo = Images.Users.SampleUser1;
                EmployeeSampleData.Employee2.Photo = Images.Users.SampleUser2;
                EmployeeSampleData.Employee3.Photo = Images.Users.SampleUser3;
            }
        }
    }
}