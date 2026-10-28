Imports System.Linq
Imports DevExpress.Utils
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraBars.Navigation

Partial Public Class MainForm
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    Public ReadOnly Property Services As IServiceProvider

    Private ReadOnly openedViews As New System.Collections.Generic.Dictionary(Of Type, Control)()

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(serviceProvider As IServiceProvider)
        Me.New()
        Services = serviceProvider
        AddHandler tabbedView.DocumentClosed, AddressOf OnDocumentClosed
        InitNavigationItems()
        InitAccentColors()
    End Sub

    Private Sub OnDocumentClosed(sender As Object, e As DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs)
        For Each item In openedViews.Where(Function(x) x.Value Is e.Document.Control).ToList()
            openedViews.Remove(item.Key)
        Next
    End Sub

    Private Sub InitNavigationItems()
        ' Forms
        addressFormAccordionControlElement.Tag = GetType(DevExpress.UITemplates.Collection.Forms.AddressForm)
        creditCardFormAccordionControlElement.Tag = GetType(DevExpress.UITemplates.Collection.Forms.CreditCardForm)
        loginFormAccordionControlElement.Tag = GetType(DevExpress.UITemplates.Collection.Forms.LoginForm)
        passwordFormAccordionControlElement.Tag = GetType(DevExpress.UITemplates.Collection.Forms.PasswordForm)
        passwordRecoveryFormAccordionControlElement.Tag = GetType(DevExpress.UITemplates.Collection.Forms.PasswordRecoveryForm)
        paymentFormAccordionControlElement.Tag = GetType(DevExpress.UITemplates.Collection.Forms.PaymentForm)

        ' User Controls
        contactListAccordionControlElement.Tag = GetType(DevExpress.UITemplates.Collection.UserControls.ContactList)
        contactsViewAccordionControlElement.Tag = GetType(DevExpress.UITemplates.Collection.UserControls.ContactsSimple)
        employeeDetailsAccordionControlElement.Tag = GetType(DevExpress.UITemplates.Collection.UserControls.EmployeeDetailsSimple)
        employeeDetailsMvvmAccordionControlElement.Tag = GetType(DevExpress.UITemplates.Collection.UserControls.EmployeeDetails)
        employeesHierarchyAccordionControlElement.Tag = GetType(DevExpress.UITemplates.Collection.UserControls.EmployeesHierarchySimple)
        employeesHierarchyMvvmAccordionControlElement.Tag = GetType(DevExpress.UITemplates.Collection.UserControls.EmployeesHierarchy)
        employeesMasterDetailAccordionControlElement.Tag = GetType(DevExpress.UITemplates.Collection.UserControls.EmployeesMasterDetailSimple)
        employeesMasterDetailMvvmAccordionControlElement.Tag = GetType(DevExpress.UITemplates.Collection.UserControls.EmployeesMasterDetail)

        ' Editors
        countryChooserAccordionControlElement.Tag = GetType(Views.CountryChooserView)
        dateRangePickerAccordionControlElement.Tag = GetType(Views.DateRangePickerView)
        editBoxAccordionControlElement.Tag = GetType(Views.EditBoxView)
        emailBoxAccordionControlElement.Tag = GetType(Views.EmailBoxView)
        passwordBoxAccordionControlElement.Tag = GetType(Views.PasswordBoxView)
        paymentCardBoxAccordionControlElement.Tag = GetType(Views.PaymentCardBoxView)
        phoneNumberBoxAccordionControlElement.Tag = GetType(Views.PhoneNumberBoxView)

        ' Buttons
        buttonAccordionControlElement.Tag = GetType(Views.ButtonView)
        chipButtonAccordionControlElement.Tag = GetType(Views.ChipButtonView)
        chipGroupAccordionControlElement.Tag = GetType(Views.ChipGroupView)
        multiSelectChipGroupAccordionControlElement.Tag = GetType(Views.MultiSelectChipGroupView)
        radioButtonGroupAccordionControlElement.Tag = GetType(Views.RadioButtonGroupView)
        toggleButtonAccordionControlElement.Tag = GetType(Views.ToggleButtonView)
        toggleButtonGroupAccordionControlElement.Tag = GetType(Views.ToggleButtonGroupView)
        twinButtonAccordionControlElement.Tag = GetType(Views.TwinButtonView)

        ' Clear selection
        navigationAccordion.SelectedElement = Nothing
    End Sub

    Private Sub OnSelectedAccordionElementChanged(sender As Object, e As SelectedElementChangedEventArgs) Handles navigationAccordion.SelectedElementChanged
        Dim viewType As Type = TryCast(e.Element?.Tag, Type)
        If viewType Is Nothing Then
            Return
        End If

        HideOpenForms(viewType)
        If Not GetType(Form).IsAssignableFrom(viewType) Then
            SetDocumentsVisible(True)
        End If

        Dim opened As Control = Nothing
        If openedViews.TryGetValue(viewType, opened) Then
            ' Reactivate opened forms if already shown
            Dim openedForm As Form = TryCast(opened, Form)
            If openedForm IsNot Nothing Then
                If Not openedForm.IsDisposed Then
                    If openedForm.WindowState = FormWindowState.Minimized Then
                        openedForm.WindowState = FormWindowState.Normal
                    End If
                    openedForm.Show(Me)
                    SetDocumentsVisible(False)
                    openedForm.Activate()
                    Return
                End If
                openedViews.Remove(viewType)
            Else
                ' Reactivate document if it is already added
                Dim existingDocument = tabbedView.Documents.FirstOrDefault(Function(d) d.Control Is opened)
                If existingDocument IsNot Nothing Then
                    tabbedView.Controller.Activate(existingDocument)
                    Return
                End If
                openedViews.Remove(viewType)
            End If
        End If

        Dim control As Control = DirectCast(Services.GetService(viewType), Control)
        openedViews(viewType) = control

        Dim frm As Form = TryCast(control, Form)
        If frm IsNot Nothing Then
            AddHandler frm.FormClosed,
            Sub(s, args)
                Dim current As Control = Nothing
                If openedViews.TryGetValue(viewType, current) AndAlso current Is frm Then
                    openedViews.Remove(viewType)
                End If
                SetDocumentsVisible(True)
            End Sub
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.Show(Me)
            SetDocumentsVisible(False)
        Else
            Dim document = tabbedView.AddDocument(control)
            document.Caption = e.Element.Text
        End If
    End Sub

    Private Sub SetDocumentsVisible(visible As Boolean)
        For Each c As Control In Controls
            If TypeOf c Is MdiClient Then
                c.Visible = visible
            End If
        Next
    End Sub

    Private Sub HideOpenForms(exceptViewType As Type)
        For Each item In openedViews
            Dim f As Form = TryCast(item.Value, Form)
            If item.Key IsNot exceptViewType AndAlso f IsNot Nothing AndAlso Not f.IsDisposed AndAlso f.Visible Then
                f.Hide()
            End If
        Next
    End Sub

    Private Sub InitAccentColors()
        SkinHelper.InitTrackWindowsAppMode(bciTrackWindowsAppMode)
        bciTrackWindowsAppMode.SuperTip = New SuperToolTip()
        bciTrackWindowsAppMode.SuperTip.Items.Add("This setting is available for WXI, Basic, and Bezier skins.")
        bciTrackWindowsAppMode.SuperTip.Items(0).Appearance.FontStyleDelta = FontStyle.Bold
        SkinHelper.InitResetToOriginalPalette(bciOriginalPalette)
        SkinHelper.InitTrackWindowsAccentColor(bciTrackWindowsAccentColor)
        SkinHelper.InitCustomAccentColor(Ribbon.Manager, bbiCustomColors)
        bbiCustomColors.SuperTip = New SuperToolTip()
        bbiCustomColors.SuperTip.Items.Add("Custom Accent Color.")
        bbiCustomColors.SuperTip.Items(0).Appearance.FontStyleDelta = FontStyle.Bold
        SkinHelper.InitCustomAccentColor2(Ribbon.Manager, bbiCustomColors2)
        bbiCustomColors2.SuperTip = New SuperToolTip()
        bbiCustomColors2.SuperTip.Items.Add("Custom Accent Color 2.")
        bbiCustomColors2.SuperTip.Items(0).Appearance.FontStyleDelta = FontStyle.Bold
    End Sub
End Class
