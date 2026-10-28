using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UITemplatesExample {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [System.STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();
            Application.Run(new MainForm(host.Services));
        }

        static IHostBuilder CreateHostBuilder() {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    // Forms
                    services.AddTransient<DevExpress.UITemplates.Collection.Forms.AddressForm>();
                    services.AddTransient<DevExpress.UITemplates.Collection.Forms.CreditCardForm>();
                    services.AddTransient<DevExpress.UITemplates.Collection.Forms.LoginForm>();
                    services.AddTransient<DevExpress.UITemplates.Collection.Forms.PasswordForm>();
                    services.AddTransient<DevExpress.UITemplates.Collection.Forms.PasswordRecoveryForm>();
                    services.AddTransient<DevExpress.UITemplates.Collection.Forms.PaymentForm>();

                    // User Controls
                    services.AddTransient<DevExpress.UITemplates.Collection.UserControls.ContactList>();
                    services.AddTransient<DevExpress.UITemplates.Collection.UserControls.ContactsSimple>();
                    services.AddTransient<DevExpress.UITemplates.Collection.UserControls.EmployeeDetailsSimple>();
                    services.AddTransient<DevExpress.UITemplates.Collection.UserControls.EmployeeDetails>();
                    services.AddTransient<DevExpress.UITemplates.Collection.UserControls.EmployeesHierarchySimple>();
                    services.AddTransient<DevExpress.UITemplates.Collection.UserControls.EmployeesHierarchy>();
                    services.AddTransient<DevExpress.UITemplates.Collection.UserControls.EmployeesMasterDetailSimple>();
                    services.AddTransient<DevExpress.UITemplates.Collection.UserControls.EmployeesMasterDetail>();

                    // Editors
                    services.AddTransient<Views.CountryChooserView>();
                    services.AddTransient<Views.DateRangePickerView>();
                    services.AddTransient<Views.EditBoxView>();
                    services.AddTransient<Views.EmailBoxView>();
                    services.AddTransient<Views.PasswordBoxView>();
                    services.AddTransient<Views.PaymentCardBoxView>();
                    services.AddTransient<Views.PhoneNumberBoxView>();

                    // Buttons
                    services.AddTransient<Views.ButtonView>();
                    services.AddTransient<Views.ChipButtonView>();
                    services.AddTransient<Views.ChipGroupView>();
                    services.AddTransient<Views.MultiSelectChipGroupView>();
                    services.AddTransient<Views.RadioButtonGroupView>();
                    services.AddTransient<Views.ToggleButtonView>();
                    services.AddTransient<Views.ToggleButtonGroupView>();
                    services.AddTransient<Views.TwinButtonView>();
                });
            return builder;
        }
    }
}