<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ValidationControls._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <fieldset>
            <legend>Register Form</legend>
            <asp:ValidationSummary runat="server" CssClass="text-danger alert alert-danger" />
            <asp:Label runat="server" ID="LabelMessage" CssClass="alert alert-success" Visible="False"></asp:Label>
            <div class="form-group">
                <label class="col-lg-2 control-label" for="TextBoxUsername">Username</label>

                <div class="col-lg-10">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="TextBoxUsername" placeholder="Username"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="TextBoxUsername"
                        CssClass="text-danger" ErrorMessage="The username name field is required." />
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-2 control-label" for="TextBoxFirstName">First Name</label>
                <div class="col-lg-10">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="TextBoxFirstName" placeholder="First name"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="TextBoxFirstName"
                        CssClass="text-danger" ErrorMessage="The first name field is required."></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-2 control-label" for="TextBoxLastName">Last name</label>
                <div class="col-lg-10">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="TextBoxLastName" placeholder="Last name"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="TextBoxLastName"
                        CssClass="text-danger" ErrorMessage="The last name field is required."></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="TextBoxAge" class="col-lg-2 control-label">Age</label>
                <div class="col-lg-10">
                    <asp:TextBox runat="server" type="number" class="form-control" ID="TextBoxAge" placeholder="21"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="TextBoxAge"
                        CssClass="text-danger" ErrorMessage="The age field is required."></asp:RequiredFieldValidator>
                    <asp:CompareValidator runat="server" Display="Dynamic" ControlToValidate="TextBoxAge"
                        ValueToCompare="18" Type="Integer" Operator="GreaterThanEqual" CssClass="text-danger"
                        ErrorMessage="Age value must be greater or equal than 18"></asp:CompareValidator>
                    <asp:CompareValidator runat="server" Display="Dynamic" ControlToValidate="TextBoxAge"
                        ValueToCompare="81" Type="Integer" Operator="LessThanEqual" CssClass="text-danger"
                        ErrorMessage="Age value must be less or equal than 81"></asp:CompareValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="TextBoxEmail" class="col-lg-2 control-label">Email</label>
                <div class="col-lg-10">
                    <asp:TextBox runat="server" type="email" class="form-control" ID="TextBoxEmail" placeholder="sample@mail.com"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="TextBoxEmail"
                        CssClass="text-danger" ErrorMessage="The email field is required."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBoxEmail"
                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage="Invalid Email Format" Display="Dynamic"
                        CssClass="text-danger"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="TextBoxAddress" class="col-lg-2 control-label">Local Address</label>
                <div class="col-lg-10">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="TextBoxAddress" placeholder="bul. Bulgaria 21"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="TextBoxAddress"
                        CssClass="text-danger" ErrorMessage="The address field is required."></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="TextBoxPhone" class="col-lg-2 control-label">Phone number</label>
                <div class="col-lg-10">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="TextBoxPhone" placeholder="0899999888"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="TextBoxPhone"
                        CssClass="text-danger" ErrorMessage="The phone number field is required."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBoxPhone"
                        ValidationExpression="08[7-9][0-9]{7}"
                        ErrorMessage="Invalid Phone number format" Display="Dynamic"
                        CssClass="text-danger"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="inputPassword" class="col-lg-2 control-label">Password</label>
                <div class="col-lg-10">
                    <asp:TextBox runat="server" type="password" class="form-control" ID="inputPassword" TextMode="Password" placeholder="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="inputPassword"
                        CssClass="text-danger" ErrorMessage="The password field is required."></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="inputPasswordConfirm" class="col-lg-2 control-label">Confirm Password</label>
                <div class="col-lg-10">
                    <asp:TextBox runat="server" type="password" class="form-control" ID="inputPasswordConfirm" placeholder="Confirm Password"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="inputPasswordConfirm"
                        CssClass="text-danger" ErrorMessage="The password field is required."></asp:RequiredFieldValidator>
                    <asp:CompareValidator runat="server" ControlToCompare="inputPassword" ControlToValidate="inputPasswordConfirm"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match."></asp:CompareValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-lg-10 col-lg-offset-2">
                    <button class="btn btn-default">Cancel</button>
                    <asp:Button runat="server" type="submit" class="btn btn-primary" Text="Register" 
                        ID="ButtonRegister" OnClick="ButtonRegister_OnClick"/>
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
