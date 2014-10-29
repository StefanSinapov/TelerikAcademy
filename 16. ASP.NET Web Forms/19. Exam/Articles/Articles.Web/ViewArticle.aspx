<%@ Page Title="View Article" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewArticle.aspx.cs" Inherits="Articles.Web.ViewArticle" %>

<%@ Register Src="~/Controls/LikeControl/LikeControl.ascx" TagPrefix="uc1" TagName="LikeControl" %>


<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewArticle" ItemType="Articles.Web.Models.Article"
        SelectMethod="Select">
        <ItemTemplate>
            <div class="row">
                <div class="col-md-1" runat="server">
                    <uc1:LikeControl Visible="False"
                        runat="server" ID="LikeControl"
                        LikesValue="<%# Item.LikesCount %>"
                        OnLike="LikeControl_Like"
                        DataId="<%# Item.Id %>"
                        UserVote="<%# GetUserVote(Item) %>" />
                </div>

                <div class="col-md-11">
                    <h2><%#: Item.Title %> <small>Category: <%#:Item.Category.Name %></small></h2>
                    <p><%#: Item.Content %></p>
                    <p>
                        <span>Author: <%#: Item.Author.UserName %></span>
                        <span class="pull-right"><%#: Item.DateCreated %></span>
                    </p>
                </div>
            </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
