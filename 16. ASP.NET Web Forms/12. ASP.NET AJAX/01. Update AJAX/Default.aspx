<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UpdateAjax._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="page-header">Employees</h1>


    <asp:UpdatePanel runat="server" ID="UpdatepanelEmployees">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:GridView runat="server" ID="GridViewEmloyees" AutoGenerateColumns="True"
        SelectMethod="SelectEmployees" OnSelectedIndexChanged="GridViewEmloyees_OnSelectedIndexChanged"
        AllowPaging="True" ItemType="UpdateAjax.Models.EmployeeViewModel" DataKeyNames="EmployeeID">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ItemStyle-CssClass="selectButton" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:UpdatePanel runat="server" ID="UpdatePanelOrders">
        <ContentTemplate>
            <asp:GridView runat="server" ID="GridViewOrders" AutoGenerateColumns="True"
                AllowPaging="True" PageSize="10">
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdateProgress ID="UpdateProgressOrders" runat="server">
        <ProgressTemplate>
            <img src="Images/loading.gif" />
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>
