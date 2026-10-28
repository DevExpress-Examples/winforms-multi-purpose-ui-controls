Imports DevExpress.Mvvm.POCO
Imports DevExpress.UITemplates.Collection.Models
Imports DevExpress.UITemplates.Collection.ViewModels
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Namespace DevExpress.UITemplates.Collection.UserControls

    Partial Public Class EmployeesMasterDetail
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
            '  var repository = new Repositories.EF6SampleRepositoryForEmployees();
            ' 
            Dim repository = New InMemorySampleRepository()
            mvvmContextMaster.RegisterService(repository)
            mvvmContextDetail.RegisterService(repository)
        End Sub
        Private Sub InitializeBindingForMaster()
            ' Bind the data grid.
            Dim fluent = mvvmContextMaster.OfType(Of MasterViewModel)()
            fluent.SetBinding(masterBindingSource, Function(bs) bs.DataSource, Function(x) x.Entities)
            fluent.SetBinding(masterGridView, Function(view) view.FocusedRowObject, Function(x) x.SelectedEntity)
            fluent.WithEvent(Of GridView, FocusedRowChangedEventArgs)(masterGridView, "FocusedRowChanged").SetBinding(
                Function(x) x.SelectedEntity,
                Function(args) TryCast(masterGridView.GetRow(args.FocusedRowHandle), Employee),
                Sub(gridView, entity)
                    If entity Is Nothing Then Return

                    Dim row As Integer = gridView.LocateByValue(NameOf(Employee.ID), entity.ID)

                    If row >= 0 Then
                        gridView.FocusedRowHandle = row
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
            fluent.BindCommand(bbiNew, Sub(x) x.[New]())
            fluent.BindCommand(bbiResetChanges, Sub(x) x.Reset())
        End Sub
        Public Class MasterViewModel
            Inherits Collection.ViewModels.EntitiesViewModel(Of Long, Collection.Models.Employee)
            Public Sub OnCreate()
                MyBase.ReloadEntities()
            End Sub
            Protected Overrides Function GetName(entity As Collection.Models.Employee) As String
                Return entity.FullName
            End Function
        End Class
        Public Class DetailViewModel
            Inherits Collection.ViewModels.EntityViewModel(Of Long, Collection.Models.Employee)
            Protected Overrides Function GetName(entity As Collection.Models.Employee) As String
                Return entity.FullName
            End Function
            ' This is how you should implement a custom command.
            Public Sub [New]()
                MyBase.LoadNew()
            End Sub
            Protected Overrides Sub UpdateCommands()
                MyBase.UpdateCommands()
                RaiseCanExecuteChanged(Sub(x) x.[New]())
            End Sub
        End Class
        Friend NotInheritable Class InMemorySampleRepository
            Inherits Collection.Repositories.InMemorySampleRepositoryForEmployees
            Shared Sub New()
                Collection.Models.EmployeeSampleData.Employee1.Photo = Collection.Images.Users.SampleUser1
                Collection.Models.EmployeeSampleData.Employee2.Photo = Collection.Images.Users.SampleUser2
                Collection.Models.EmployeeSampleData.Employee3.Photo = Collection.Images.Users.SampleUser3
            End Sub
        End Class
    End Class
End Namespace
