Imports DevExpress.Mvvm.POCO
Imports DevExpress.UITemplates.Collection.Models
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList

Namespace DevExpress.UITemplates.Collection.UserControls

    Public Partial Class EmployeesHierarchy
        Inherits XtraUserControl
        Public Sub New()
            InitializeComponent()
            If Not mvvmContextDetail.IsDesignMode Then
                InitializeEditors()
                InitializeDataServices()
                InitializeBindingForMaster()
                InitializeBindingForDetails()
            End If
        End Sub
        Private Sub InitializeEditors()
            StatusImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.EmployeeStatus)()
            PrefixImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.PersonPrefix)()
            DepartmentImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.EmployeeDepartment)()
            StateImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.USState)()
        End Sub
        Private Sub InitializeDataServices()
            ' 
            '  Here you should register your 'real' repository.
            '  Example:
            '  var repository = new Repositories.EF6SampleRepositoryForSubordinates();
            ' 
            Dim repository = New InMemorySampleRepository()
            mvvmContextMaster.RegisterService(repository)
            mvvmContextDetail.RegisterService(repository)
        End Sub
        Private Sub InitializeBindingForMaster()
            ' Bind the data grid.
            Dim fluent = mvvmContextMaster.OfType(Of MasterViewModel)()
            fluent.SetTrigger(Function(x) x.Entities, Sub(__) masterTree.ExpandAll())
            fluent.SetBinding(masterBindingSource, Function(bs) bs.DataSource, Function(x) x.Entities)
            fluent.WithEvent(Of TreeList, FocusedNodeChangedEventArgs)(masterTree, "FocusedNodeChanged").SetBinding(
                Function(x) x.SelectedEntity,
                Function(args) If(
                    args.Node Is Nothing,
                    Nothing,
                    TryCast(args.Node.TreeList.GetDataRecordByNode(args.Node), Subordinate)),
                Sub(tree, entity)
                    If entity Is Nothing Then Return

                    Dim node = tree.FindNode(
                        Function(n) ReferenceEquals(tree.GetDataRecordByNode(n), entity))

                    If node IsNot Nothing AndAlso tree.FocusedNode IsNot node Then
                        tree.FocusedNode = node
                    End If
                End Sub)
            ' Bind life-cycle events.
            fluent.WithEvent(Me, NameOf(HandleCreated)).EventToCommand(Sub(x) x.OnCreate())
            fluent.WithEvent(Me, NameOf(HandleDestroyed)).EventToCommand(Sub(x) x.OnDestroy())
            ' Bind commands.
            fluent.BindCommand(bbiDelete, Sub(x) x.Delete())
        End Sub
        Private Sub InitializeBindingForDetails()
            ' Bind entity data to the editors. 
            Dim fluent = mvvmContextDetail.OfType(Of DetailViewModel)()
            fluent.SetObjectDataSourceBinding(detailBindingSource, Function(x) x.Entity, Sub(x) x.Update())
            fluent.SetBinding(Me, Function(uc) uc.Text, Function(x) x.Title)
            ' Bind life-cycle events.
            fluent.WithEvent(Me, NameOf(HandleDestroyed)).EventToCommand(Sub(x) x.OnDestroy())
            ' Bind commands.
            fluent.BindCommand(bbiSave, Sub(x) x.Save())
            fluent.BindCommand(bbiNewSupervisor, Sub(x) x.NewSupervisor())
            fluent.BindCommand(bbiNewSubordinate, Sub(x) x.NewSubordinate())
            fluent.BindCommand(bbiResetChanges, Sub(x) x.Reset())
        End Sub
        Public Class MasterViewModel
            Inherits Collection.ViewModels.EntitiesViewModel(Of Long, Collection.Models.Subordinate)
            Public Sub OnCreate()
                MyBase.ReloadEntities()
            End Sub
            Protected Overrides Function GetName(entity As Collection.Models.Subordinate) As String
                Return entity.FullName
            End Function
            Public Overrides Function CanDelete() As Boolean
                Return SelectedEntity IsNot Nothing AndAlso
                    Not Entities.Any(Function(x) x.SupervisorID = SelectedEntity.ID)
            End Function
        End Class
        Public Class DetailViewModel
            Inherits Collection.ViewModels.EntityViewModel(Of Long, Collection.Models.Subordinate)
            Const DefaultSupervisorID As Integer = -1
            '
            Protected Overrides Function GetName(entity As Collection.Models.Subordinate) As String
                Return entity.FullName
            End Function
            ' This is how you should implement a custom command.
            Public Function CanNewSupervisor() As Boolean
                Return MyBase.Entity IsNot Nothing AndAlso Not MyBase.IsNew AndAlso MyBase.Entity.SupervisorID <> DefaultSupervisorID
            End Function
            Public Sub NewSupervisor()
                NewEmployee(DefaultSupervisorID)
            End Sub
            Public Function CanNewSubordinate() As Boolean
                Return Not MyBase.IsNew
            End Function
            Public Sub NewSubordinate()
                Me.NewEmployee(MyBase.Entity.ID)
            End Sub
            Private Sub NewEmployee(supervisorId As Long)
                MyBase.LoadNew()
                MyBase.Entity.SupervisorID = supervisorId
            End Sub
            Protected Overrides Sub UpdateCommands()
                MyBase.UpdateCommands()
                RaiseCanExecuteChanged(Sub(x) x.NewSupervisor())
                RaiseCanExecuteChanged(Sub(x) x.NewSubordinate())
            End Sub
        End Class
        Friend NotInheritable Class InMemorySampleRepository
            Inherits Collection.Repositories.InMemorySampleRepositoryForSubordinate
            Shared Sub New()
                Collection.Models.EmployeeSampleData.Employee1.Photo = Collection.Images.Users.SampleUser1
                Collection.Models.EmployeeSampleData.Employee2.Photo = Collection.Images.Users.SampleUser2
                Collection.Models.EmployeeSampleData.Employee3.Photo = Collection.Images.Users.SampleUser3
            End Sub
        End Class
    End Class
End Namespace
