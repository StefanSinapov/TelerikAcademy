<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibrarySystem.BookDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewBook"
        ItemType="LibrarySystem.Models.Book" SelectMethod="Select">
        <ItemTemplate>
            <header>
                <h1><%# this.Title %></h1>
                <h3 class="well"><%#: Item.Title %></h3>
                <p class=""><i>by <%#: Item.Author %></i></p>
                <p class=""><i>ISBN <%#: Item.ISBN %></i></p>
                <p class="">
                    <i>Web site: 
                    <a href="<%#: Item.WebSite %>"><%#: Item.WebSite %></a></i>
                </p>
            </header>
            <div class="row">
                <div class="col-md-12">
                    <p><%#: Item.Description %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>
    
    <div class="row">
        <a href="/">Back to books</a>
    </div>
</asp:Content>
