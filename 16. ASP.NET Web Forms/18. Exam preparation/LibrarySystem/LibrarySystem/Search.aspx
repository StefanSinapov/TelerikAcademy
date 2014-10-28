<%@ Page Title="Search Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LibrarySystem.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Search Results for Query "
        <asp:Literal runat="server" ID="LiteralQuery"></asp:Literal>"
    </h1>

    <div class="row">
        <div class="col-md-12">
            <asp:Repeater runat="server" ID="RepeaterBooks" ItemType="LibrarySystem.Models.Book"
                SelectMethod="ReapeaterBooks_GetData">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/BookDetails?id={0}", Item.Id) %>'> 
                            <%#: Item.Title %> by <i><%#: Item.Author %></i>
                        </asp:HyperLink>
                        (Category: <%#: Item.Category.Name %>)
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    
     <div class="row">
        <a href="/">Back to books</a>
    </div>
</asp:Content>
