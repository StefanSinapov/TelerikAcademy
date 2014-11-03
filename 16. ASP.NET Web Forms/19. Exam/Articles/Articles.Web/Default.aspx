<%@ Page Title="News" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Articles.Web._Default" %>

<%@ Import Namespace="Articles.Web.Extensions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1><%: Title %></h1>

    <div class="row">
        <asp:ListView runat="server" ID="ListViewMostPopular" ItemType="Articles.Web.Models.Article"
            SelectMethod="ListViewMostPupular_GetData">
            <LayoutTemplate>
                <h2>Most popular articles</h2>
                <div class="row">
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <h3><a href='<%# string.Format("/ViewArticle?id={0}",Item.Id) %>'><%#: Item.Title %></a> <small><%#: Item.Category.Name %></small></h3>
                <p><%#: Item.Content.Short(300) %></p>
                <p>Likes: <%#: Item.LikesCount %></p>
                <div>
                    <i>by <%#: Item.Author.UserName %></i>
                    <i>created on: <%#: Item.DateCreated %></i>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <div class="row">
        <h2>All Categories</h2>
        <asp:ListView runat="server" ID="ListViewCategories"
            SelectMethod="ListViewCategories_GetData"
            ItemType="Articles.Web.Models.Category"
            GroupItemCount="2">
            <GroupTemplate>
                <div class="row">
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                </div>
            </GroupTemplate>
            <ItemTemplate>
                <div class="col-md-6">
                    <h3><%#: Item.Name %></h3>
                    <asp:ListView runat="server" ID="RepeaterCategoriesArticles"
                        ItemType="Articles.Web.Models.Article" DataSource="<%# Item.Articles.Take(3) %>">
                        <LayoutTemplate>
                            <ul>
                                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li>
                                <a href='<%# string.Format("~/ViewArticle?id={0}",Item.Id) %>' runat="server">
                                    <%#: Item.Title %> by <i><%#: Item.Author.UserName %></i>
                                </a>
                            </li>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <p>No articles.</p>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
