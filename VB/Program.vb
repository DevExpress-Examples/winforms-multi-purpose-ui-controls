Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Public Module Program
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <STAThread>
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2)

        Dim host = CreateHostBuilder().Build()
        Application.Run(New MainForm(host.Services))
    End Sub

    Private Function CreateHostBuilder() As IHostBuilder
        Return Host.CreateDefaultBuilder().ConfigureServices(
            Sub(context, services)
                ' Forms
                services.AddTransient(Of DevExpress.UITemplates.Collection.Forms.AddressForm)()
                services.AddTransient(Of DevExpress.UITemplates.Collection.Forms.CreditCardForm)()
                services.AddTransient(Of DevExpress.UITemplates.Collection.Forms.LoginForm)()
                services.AddTransient(Of DevExpress.UITemplates.Collection.Forms.PasswordForm)()
                services.AddTransient(Of DevExpress.UITemplates.Collection.Forms.PasswordRecoveryForm)()
                services.AddTransient(Of DevExpress.UITemplates.Collection.Forms.PaymentForm)()

                ' User Controls
                services.AddTransient(Of DevExpress.UITemplates.Collection.UserControls.ContactList)()
                services.AddTransient(Of DevExpress.UITemplates.Collection.UserControls.ContactsSimple)()
                services.AddTransient(Of DevExpress.UITemplates.Collection.UserControls.EmployeeDetailsSimple)()
                services.AddTransient(Of DevExpress.UITemplates.Collection.UserControls.EmployeeDetails)()
                services.AddTransient(Of DevExpress.UITemplates.Collection.UserControls.EmployeesHierarchySimple)()
                services.AddTransient(Of DevExpress.UITemplates.Collection.UserControls.EmployeesHierarchy)()
                services.AddTransient(Of DevExpress.UITemplates.Collection.UserControls.EmployeesMasterDetailSimple)()
                services.AddTransient(Of DevExpress.UITemplates.Collection.UserControls.EmployeesMasterDetail)()

                ' Editors
                services.AddTransient(Of Views.CountryChooserView)()
                services.AddTransient(Of Views.DateRangePickerView)()
                services.AddTransient(Of Views.EditBoxView)()
                services.AddTransient(Of Views.EmailBoxView)()
                services.AddTransient(Of Views.PasswordBoxView)()
                services.AddTransient(Of Views.PaymentCardBoxView)()
                services.AddTransient(Of Views.PhoneNumberBoxView)()

                ' Buttons
                services.AddTransient(Of Views.ButtonView)()
                services.AddTransient(Of Views.ChipButtonView)()
                services.AddTransient(Of Views.ChipGroupView)()
                services.AddTransient(Of Views.MultiSelectChipGroupView)()
                services.AddTransient(Of Views.RadioButtonGroupView)()
                services.AddTransient(Of Views.ToggleButtonView)()
                services.AddTransient(Of Views.ToggleButtonGroupView)()
                services.AddTransient(Of Views.TwinButtonView)()
            End Sub)
    End Function
End Module
