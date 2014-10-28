<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibrarySystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1><%# Title %></h1>

    <div class="row">
        <div class="col-md-3 col-md-offset-9">
            <div class="input-group ">
                <asp:TextBox runat="server" ID="TextBoxSearch" CssClass="form-control"></asp:TextBox>
                <div class="input-group-btn">
                    <asp:LinkButton runat="server" ID="ButtonSearch" OnClick="ButtonSearch_OnClick" class="btn btn-default"><i class="glyphicon glyphicon-search"></i></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <asp:ListView runat="server" ID="ListViewBooks" ItemType="LibrarySystem.Models.Category"
        SelectMethod="Select"
        GroupItemCount="3">
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="col-md-4">
                <h2><%#: Item.Name %></h2>
                <asp:ListView runat="server" ID="ListViewBooks"
                    ItemType="LibrarySystem.Models.Book" DataSource="<%# Item.Books %>">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <a href='<%# string.Format("~/BookDetails?id={0}",Item.Id) %>' runat="server">
                                <%#: Item.Title %> by <i><%#: Item.Author %></i>
                            </a>
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <p>No books in this category</p>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
