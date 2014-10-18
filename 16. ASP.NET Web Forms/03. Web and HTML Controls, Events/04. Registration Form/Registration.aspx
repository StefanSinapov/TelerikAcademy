<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="RegistrationForm.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration </title>
</head>
<body>
    <h1>Registration:</h1>
    <form id="FormRegistration" runat="server">
        <div>
            <label for="firstName">First name</label>
            <asp:TextBox ID="firstName" name="firstName" required="" placeholder="First name"  runat="server"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server"
                ControlToValidate="firstname" ErrorMessage="Please enter first name."
                ValidationGroup="student"></asp:RequiredFieldValidator>
            <br/>
            <label for="lastName">Last name</label>
            <asp:TextBox id="lastName" name="lastName" required="" placeholder="Last name"  runat="server"/>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorLastName"
                ControlToValidate="lastName" ErrorMessage="Please enter last name"
                ValidationGroup="student"></asp:RequiredFieldValidator>

            <br />
            <label for="facultyNumber">Faculty number: </label>
            <asp:TextBox name="facultyNumber" id="facultyNumber" required="" placeholder="8888888"  runat="server"/>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorFacultyNumber"
                ErrorMessage="Please entery your faculty number" ControlToValidate="facultyNumber"
                ValidationGroup="student"></asp:RequiredFieldValidator>
            <asp:CompareValidator runat="server" ID="CompareValidatorFacultyNumber"
                ErrorMessage="Please enter integer faculty number" Operator="DataTypeCheck"
                Type="Integer" ValidationGroup="student" ControlToValidate="facultyNumber"></asp:CompareValidator>
            <br />


            <label for="university">University</label>
            <asp:DropDownList runat="server" ID="university" name="university" required="">
                <asp:ListItem Text="Select University" Value="" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Софийски Университет" Value="Софийски Университет"></asp:ListItem>
                <asp:ListItem Text="ТУ София" Value="ТУ София"></asp:ListItem>
                <asp:ListItem Text="ТУ Пловдив" Value="ТУ Пловдив"></asp:ListItem>
                <asp:ListItem Text="МУ София" Value="МУ София"></asp:ListItem>
                <asp:ListItem Text="МУ Пловдив" Value="МУ Пловдив"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUniversity"
                runat="server" ErrorMessage="Please select university."
                ControlToValidate="university" ValidationGroup="student"></asp:RequiredFieldValidator>
            <br />

            <label for="specialty">Specialty: </label>
            <asp:DropDownList runat="server" ID="specialty" name="specialty">
                <asp:ListItem Text="Select specialty" Value="" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Софтуерно Инженерство" Value="Софтуерно Инженерство"></asp:ListItem>
                <asp:ListItem Text="Туризъм" Value="Туризъм"></asp:ListItem>
                <asp:ListItem Text="Макетинг" Value="Маркетинг"></asp:ListItem>
                <asp:ListItem Text="Българска филология" Value="Българска филология"></asp:ListItem>
                <asp:ListItem Text="Английск филология" Value="Английска филология"></asp:ListItem>
                <asp:ListItem Text="Френска филология" Value="Френска филология"></asp:ListItem>
                <asp:ListItem Text="Медицина" Value="Медицина"></asp:ListItem>
                <asp:ListItem Text="Фармация" Value="Фармация"></asp:ListItem>
                <asp:ListItem Text="Стоматология" Value="Стоматология"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSpecialty" runat="server" 
                ErrorMessage="Please select specialty." ControlToValidate="specialty"
                 ValidationGroup="student"></asp:RequiredFieldValidator>

            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="SubmitForm" ValidationGroup="student" />

             <br />
            <asp:PlaceHolder ID="studentHolder" runat="server" />
        </div>
    </form>
</body>
</html>
