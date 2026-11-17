<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/1436916785/26.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1337411)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Special-purpose UI Controls

This example combines DevExpress WinForms special-purpose UI controls, ready-to-use forms, and pre-designed user controls into a working application. You can integrate these controls and forms into existing projects with minimal effort.

Run the application and select a control in the navigation menu on the left (use the search box to find a control by name). Editors, buttons, and user controls open in tabs, and forms open in separate windows. Use the **Appearance** Ribbon page to change the skin palette and accent colors and see how the controls adapt to the active theme.

All controls support the following features:

* [Application Skins](https://docs.devexpress.com/WindowsForms/2399/build-an-application/skins)
* [HTML & CSS Templates](https://docs.devexpress.com/WindowsForms/403397/common-features/html-css-based-desktop-ui)
* [High DPI & DirectX Hardware Acceleration](https://docs.devexpress.com/WindowsForms/116666/common-features/high-dpi-support)
* [WinForms MVVM](https://docs.devexpress.com/WindowsForms/113955/cross-platform-app-development/winforms-mvvm)

![](media/winforms-ui-templates-overview.png)

## Files to Review

Special-purpose UI controls are located in `Editors`, `Forms`, and `UserControls` folders. Base classes are in the `Editors/Base` and `Forms/Base` subfolders. The `Views` folder contains demo pages for the editors.

### Editors

| Editor | File | Example View |
| --- | --- | --- |
| Button | C#: [Editors/Button.cs](./CS/Editors/Button.cs)<br>VB.NET: [Editors/Button.vb](./VB/Editors/Button.vb) | C#: [Views/ButtonView.cs](./CS/Views/ButtonView.cs)<br>VB.NET: [Views/ButtonView.vb](./VB/Views/ButtonView.vb) |
| ChipButton | C#: [Editors/ChipButton.cs](./CS/Editors/ChipButton.cs)<br>VB.NET: [Editors/ChipButton.vb](./VB/Editors/ChipButton.vb) | C#: [Views/ChipButtonView.cs](./CS/Views/ChipButtonView.cs)<br>VB.NET: [Views/ChipButtonView.vb](./VB/Views/ChipButtonView.vb) |
| ChipGroup | C#: [Editors/ChipGroup.cs](./CS/Editors/ChipGroup.cs)<br>VB.NET: [Editors/ChipGroup.vb](./VB/Editors/ChipGroup.vb) | C#: [Views/ChipGroupView.cs](./CS/Views/ChipGroupView.cs)<br>VB.NET: [Views/ChipGroupView.vb](./VB/Views/ChipGroupView.vb) |
| CountryChooser | C#: [Editors/CountryChooser.cs](./CS/Editors/CountryChooser.cs)<br>VB.NET: [Editors/CountryChooser.vb](./VB/Editors/CountryChooser.vb) | C#: [Views/CountryChooserView.cs](./CS/Views/CountryChooserView.cs)<br>VB.NET: [Views/CountryChooserView.vb](./VB/Views/CountryChooserView.vb) |
| DateRangePicker | C#: [Editors/DateRangePicker.cs](./CS/Editors/DateRangePicker.cs)<br>VB.NET: [Editors/DateRangePicker.vb](./VB/Editors/DateRangePicker.vb) | C#: [Views/DateRangePickerView.cs](./CS/Views/DateRangePickerView.cs)<br>VB.NET: [Views/DateRangePickerView.vb](./VB/Views/DateRangePickerView.vb) |
| EditBox | C#: [Editors/EditBox.cs](./CS/Editors/EditBox.cs)<br>VB.NET: [Editors/EditBox.vb](./VB/Editors/EditBox.vb) | C#: [Views/EditBoxView.cs](./CS/Views/EditBoxView.cs)<br>VB.NET: [Views/EditBoxView.vb](./VB/Views/EditBoxView.vb) |
| EmailBox | C#: [Editors/EmailBox.cs](./CS/Editors/EmailBox.cs)<br>VB.NET: [Editors/EmailBox.vb](./VB/Editors/EmailBox.vb) | C#: [Views/EmailBoxView.cs](./CS/Views/EmailBoxView.cs)<br>VB.NET: [Views/EmailBoxView.vb](./VB/Views/EmailBoxView.vb) |
| MultiSelectChipGroup | C#: [Editors/MultiSelectChipGroup.cs](./CS/Editors/MultiSelectChipGroup.cs)<br>VB.NET: [Editors/MultiSelectChipGroup.vb](./VB/Editors/MultiSelectChipGroup.vb) | C#: [Views/MultiSelectChipGroupView.cs](./CS/Views/MultiSelectChipGroupView.cs)<br>VB.NET: [Views/MultiSelectChipGroupView.vb](./VB/Views/MultiSelectChipGroupView.vb) |
| PasswordBox | C#: [Editors/PasswordBox.cs](./CS/Editors/PasswordBox.cs)<br>VB.NET: [Editors/PasswordBox.vb](./VB/Editors/PasswordBox.vb) | C#: [Views/PasswordBoxView.cs](./CS/Views/PasswordBoxView.cs)<br>VB.NET: [Views/PasswordBoxView.vb](./VB/Views/PasswordBoxView.vb) |
| PaymentCardBox | C#: [Editors/PaymentCardBox.cs](./CS/Editors/PaymentCardBox.cs)<br>VB.NET: [Editors/PaymentCardBox.vb](./VB/Editors/PaymentCardBox.vb) | C#: [Views/PaymentCardBoxView.cs](./CS/Views/PaymentCardBoxView.cs)<br>VB.NET: [Views/PaymentCardBoxView.vb](./VB/Views/PaymentCardBoxView.vb) |
| PhoneNumberBox | C#: [Editors/PhoneNumberBox.cs](./CS/Editors/PhoneNumberBox.cs)<br>VB.NET: [Editors/PhoneNumberBox.vb](./VB/Editors/PhoneNumberBox.vb) | C#: [Views/PhoneNumberBoxView.cs](./CS/Views/PhoneNumberBoxView.cs)<br>VB.NET: [Views/PhoneNumberBoxView.vb](./VB/Views/PhoneNumberBoxView.vb) |
| RadioButtonGroup | C#: [Editors/RadioButtonGroup.cs](./CS/Editors/RadioButtonGroup.cs)<br>VB.NET: [Editors/RadioButtonGroup.vb](./VB/Editors/RadioButtonGroup.vb) | C#: [Views/RadioButtonGroupView.cs](./CS/Views/RadioButtonGroupView.cs)<br>VB.NET: [Views/RadioButtonGroupView.vb](./VB/Views/RadioButtonGroupView.vb) |
| ToggleButton | C#: [Editors/ToggleButton.cs](./CS/Editors/ToggleButton.cs)<br>VB.NET: [Editors/ToggleButton.vb](./VB/Editors/ToggleButton.vb) | C#: [Views/ToggleButtonView.cs](./CS/Views/ToggleButtonView.cs)<br>VB.NET: [Views/ToggleButtonView.vb](./VB/Views/ToggleButtonView.vb) |
| ToggleButtonGroup | C#: [Editors/ToggleButtonGroup.cs](./CS/Editors/ToggleButtonGroup.cs)<br>VB.NET: [Editors/ToggleButtonGroup.vb](./VB/Editors/ToggleButtonGroup.vb) | C#: [Views/ToggleButtonGroupView.cs](./CS/Views/ToggleButtonGroupView.cs)<br>VB.NET: [Views/ToggleButtonGroupView.vb](./VB/Views/ToggleButtonGroupView.vb) |
| TwinButton | C#: [Editors/TwinButton.cs](./CS/Editors/TwinButton.cs)<br>VB.NET: [Editors/TwinButton.vb](./VB/Editors/TwinButton.vb) | C#: [Views/TwinButtonView.cs](./CS/Views/TwinButtonView.cs)<br>VB.NET: [Views/TwinButtonView.vb](./VB/Views/TwinButtonView.vb) |

### Forms

| Form | File |
| --- | --- |
| AddressForm | C#: [Forms/AddressForm.cs](./CS/Forms/AddressForm.cs)<br>VB.NET: [Forms/AddressForm.vb](./VB/Forms/AddressForm.vb) |
| CreditCardForm | C#: [Forms/CreditCardForm.cs](./CS/Forms/CreditCardForm.cs)<br>VB.NET: [Forms/CreditCardForm.vb](./VB/Forms/CreditCardForm.vb) |
| LoginForm | C#: [Forms/LoginForm.cs](./CS/Forms/LoginForm.cs)<br>VB.NET: [Forms/LoginForm.vb](./VB/Forms/LoginForm.vb) |
| PasswordForm | C#: [Forms/PasswordForm.cs](./CS/Forms/PasswordForm.cs)<br>VB.NET: [Forms/PasswordForm.vb](./VB/Forms/PasswordForm.vb) |
| PasswordRecoveryForm | C#: [Forms/PasswordRecoveryForm.cs](./CS/Forms/PasswordRecoveryForm.cs)<br>VB.NET: [Forms/PasswordRecoveryForm.vb](./VB/Forms/PasswordRecoveryForm.vb) |
| PaymentForm | C#: [Forms/PaymentForm.cs](./CS/Forms/PaymentForm.cs)<br>VB.NET: [Forms/PaymentForm.vb](./VB/Forms/PaymentForm.vb) |

### User Controls

| User Control | File |
| --- | --- |
| ContactList | C#: [UserControls/ContactList.cs](./CS/UserControls/ContactList.cs)<br>VB.NET: [UserControls/ContactList.vb](./VB/UserControls/ContactList.vb) |
| ContactsSimple | C#: [UserControls/ContactsSimple.cs](./CS/UserControls/ContactsSimple.cs)<br>VB.NET: [UserControls/ContactsSimple.vb](./VB/UserControls/ContactsSimple.vb) |
| EmployeeDetails | C#: [UserControls/EmployeeDetails.cs](./CS/UserControls/EmployeeDetails.cs)<br>VB.NET: [UserControls/EmployeeDetails.vb](./VB/UserControls/EmployeeDetails.vb) |
| EmployeeDetailsSimple | C#: [UserControls/EmployeeDetailsSimple.cs](./CS/UserControls/EmployeeDetailsSimple.cs)<br>VB.NET: [UserControls/EmployeeDetailsSimple.vb](./VB/UserControls/EmployeeDetailsSimple.vb) |
| EmployeesHierarchy | C#: [UserControls/EmployeesHierarchy.cs](./CS/UserControls/EmployeesHierarchy.cs)<br>VB.NET: [UserControls/EmployeesHierarchy.vb](./VB/UserControls/EmployeesHierarchy.vb) |
| EmployeesHierarchySimple | C#: [UserControls/EmployeesHierarchySimple.cs](./CS/UserControls/EmployeesHierarchySimple.cs)<br>VB.NET: [UserControls/EmployeesHierarchySimple.vb](./VB/UserControls/EmployeesHierarchySimple.vb) |
| EmployeesMasterDetail | C#: [UserControls/EmployeesMasterDetail.cs](./CS/UserControls/EmployeesMasterDetail.cs)<br>VB.NET: [UserControls/EmployeesMasterDetail.vb](./VB/UserControls/EmployeesMasterDetail.vb) |
| EmployeesMasterDetailSimple | C#: [UserControls/EmployeesMasterDetailSimple.cs](./CS/UserControls/EmployeesMasterDetailSimple.cs)<br>VB.NET: [UserControls/EmployeesMasterDetailSimple.vb](./VB/UserControls/EmployeesMasterDetailSimple.vb) |

<!-- feedback -->
## Does This Example Address Your Development Requirements/Objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-ui-templates&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-ui-templates&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
