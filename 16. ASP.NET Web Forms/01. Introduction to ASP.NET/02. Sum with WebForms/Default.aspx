<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02.Sum_with_WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:TextBox ID="tbFirstNumber" runat="server" CssClass="form-control"></asp:TextBox>

    <asp:TextBox ID="tbSecondNumber" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Button ID="btnSum" runat="server" OnClick="btnSum_OnClick" Text="Sum" CssClass="btn"/>
    <br/>
    Result: <asp:Label ID="lbResult" runat="server"></asp:Label>
</asp:Content>
