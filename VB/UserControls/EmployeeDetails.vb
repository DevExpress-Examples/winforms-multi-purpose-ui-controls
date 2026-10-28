Imports DevExpress.Mvvm.POCO
Imports DevExpress.UITemplates.Collection.Models
Imports DevExpress.UITemplates.Collection.ViewModels
Imports DevExpress.XtraEditors

Namespace DevExpress.UITemplates.Collection.UserControls

    Public Partial Class EmployeeDetails
        Inherits XtraUserControl
        Public Sub New()
            InitializeComponent()
            If Not mvvmContext.IsDesignMode Then
                InitializeEditors()
                InitializeBinding()
            Else
                employeeBindingSource.DataSource = Collection.Models.EmployeeSampleData.Employee1
            End If
        End Sub
        Private Sub InitializeEditors()
            StatusImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.EmployeeStatus)()
            PrefixImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.PersonPrefix)()
            DepartmentImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.EmployeeDepartment)()
            StateImageComboBoxEdit.Properties.Items.AddEnum(Of DevExpress.UITemplates.Collection.Models.USState)()
        End Sub
        Private Sub InitializeBinding()
            ' 
            '  Here you should register your 'real' repository.
            '  Example:
            '  var repository = new Repositories.EF6SampleRepositoryForEmployees();
            ' 
            Dim repository = New InMemorySampleRepository()
            mvvmContext.RegisterService(repository)
            ' Bind entity data to the editors. 
            Dim fluent = mvvmContext.OfType(Of ViewModel)()
            fluent.SetObjectDataSourceBinding(employeeBindingSource, Function(x) x.Entity, Sub(x) x.Update())
            fluent.SetBinding(Me, Function(uc) uc.Text, Function(x) x.Title)
            ' Bind life-cycle events.
            fluent.WithEvent(Me, NameOf(HandleCreated)).EventToCommand(Sub(x) x.OnCreate())
            fluent.WithEvent(Me, NameOf(HandleDestroyed)).EventToCommand(Sub(x) x.OnDestroy())
            ' Bind commands.
            fluent.BindCommand(bbiSave, Sub(x) x.Save())
            fluent.BindCommand(bbiClearEditors, Sub(x) x.ClearEditors())
            fluent.BindCommand(bbiResetChanges, Sub(x) x.Reset())
        End Sub
        Public Class ViewModel
            Inherits Collection.ViewModels.EntityViewModel(Of Long, Collection.Models.Employee)
            Protected Overrides Function GetName(entity As Collection.Models.Employee) As String
                Return entity.FullName
            End Function
            Public Sub OnCreate()
                MyBase.Load(&H01L)
                ' or LoadNew();
            End Sub
            ' This is how you should implement a custom command.
            Public Function CanClearEditors() As Boolean
                Return MyBase.Entity IsNot Nothing AndAlso Not CType(MyBase.ReadOnlyRepository, InMemorySampleRepository).IsEmpty(MyBase.Entity)
            End Function
            Public Sub ClearEditors()
                CType(MyBase.ReadOnlyRepository, InMemorySampleRepository).Clear(MyBase.Entity)
                MyBase.Update()
                Me.RaisePropertyChanged(Function(x) x.Entity)
            End Sub
            Protected Overrides Sub UpdateCommands()
                MyBase.UpdateCommands()
                RaiseCanExecuteChanged(Sub(x) x.ClearEditors())
            End Sub
        End Class
        ' You can remove this class if the real repository is used.
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
