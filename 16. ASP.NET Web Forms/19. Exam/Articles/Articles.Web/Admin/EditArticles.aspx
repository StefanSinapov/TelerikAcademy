<%@ Page Title="Edit Articles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditArticles.aspx.cs" Inherits="Articles.Web.Admin.EditArticles" %>

<%@ Import Namespace="Articles.Web.Extensions" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="">
            <asp:ListView runat="server" ID="ListViewArticles"
                SelectMethod="Select"
                DeleteMethod="Delete"
                UpdateMethod="Update"
                DataKeyNames="Id"
                OnSorting="ListViewArticles_OnSorting"
                OnPagePropertiesChanging="ListViewArticles_OnPagePropertiesChanging"
                ItemType="Articles.Web.Models.Article">
                <LayoutTemplate>
                    <div class="row">
                        <asp:LinkButton Text="Sort By Title" runat="server" ID="LinkButtonSortByTitle" CommandName="Sort" CommandArgument="Title" CssClass="btn btn-default" />
                        <asp:LinkButton Text="Sort By Date" runat="server" ID="LinkButtonSortByDate" CommandName="Sort" CommandArgument="DateCreated" CssClass="btn btn-default" />
                        <asp:LinkButton Text="Sort By Category" runat="server" ID="LinkButtonSortByCategory" CommandName="Sort" CommandArgument="Category.Name" CssClass="btn btn-default" />
                        <asp:LinkButton Text="Sort By Likes" runat="server" ID="LinkButtonSortByLikes" CommandName="Sort" CommandArgument="LikesCount" CssClass="btn btn-default" />
                    </div>

                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>

                    <div class="row">
                        <asp:DataPager runat="server" ID="DataPagerCategories" PageSize="5">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonCssClass="btn btn-sm btn-default" ShowPreviousPageButton="True"
                                    ShowNextPageButton="False" />
                                <asp:NumericPagerField NumericButtonCssClass="btn btn-sm btn-default"
                                    CurrentPageLabelCssClass="btn btn-primary btn-sm" />
                                <asp:NextPreviousPagerField ButtonCssClass="btn btn-sm btn-default" ShowNextPageButton="True"
                                    ShowPreviousPageButton="False" />

                            </Fields>
                        </asp:DataPager>
                        <asp:LinkButton runat="server" ID="LinkButtonInsert" CssClass="pull-right btn btn-info" OnClick="ButtonShowCreatePanel_OnClick" Text="Insert new Article" />
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="row">
                        <h3><%#: Item.Title %>
                            <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info btn-sm" Text="Edit" CommandName="Edit" />
                            <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-danger btn-sm" Text="Delete" CommandName="Delete" />
                        </h3>
                        <p>Category: <%#: Item.Category.Name %></p>
                        <p><%#: Item.Content.Short(300) %></p>
                        <p>Likes count: <%#: Item.LikesCount %></p>
                        <div>
                            <i>by <%#: Item.Author.UserName %></i>
                            <i>created on: <%#: Item.DateCreated %></i>
                        </div>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <div class="row">
                        <h3>
                            <asp:TextBox runat="server" ID="TextBoxTitle" Text="<%#: BindItem.Title %>"></asp:TextBox>
                            <asp:LinkButton runat="server" ID="LinkButtonSave" CssClass="btn btn-success btn-sm" Text="Save" CommandName="Update" />
                            <asp:LinkButton runat="server" ID="LinkButtonCancel" CssClass="btn btn-danger btn-sm" Text="Cancel" CausesValidation="False" CommandName="Cancel" />
                            <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="TextBoxTitle"
                                CssClass="text-danger" ErrorMessage="The Title field is required." />
                        </h3>
                        <p>
                            Category:
                            <asp:DropDownList runat="server" ID="DropDownListCategory"
                                DataTextField="Name" DataValueField="Id" ItemType="Articles.Web.Models.Category"
                                SelectedValue="<%#: BindItem.CategoryId %>" SelectMethod="DropDownListCategories_GetData" />
                            <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="DropDownListCategory"
                                CssClass="text-danger" ErrorMessage="The Category field is required." />
                        </p>
                        <p>
                            <asp:TextBox TextMode="multiline" Width="400" Height="300" runat="server" ID="TextBoxContent"
                                Text="<%#: BindItem.Content %>" />
                            <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="TextBoxContent"
                                CssClass="text-danger" ErrorMessage="The Content field is required." />
                        </p>
                        <div>
                            <i>by <%#: Item.Author.UserName %></i>
                            <i>created on: <%#: Item.DateCreated %></i>
                        </div>
                    </div>
                </EditItemTemplate>
            </asp:ListView>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <asp:Panel runat="server" ID="PanelCreate" Visible="False">
                <h3>Title:
                    <asp:TextBox runat="server" ID="TextBoxTitle"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="TextBoxTitle"
                        CssClass="text-danger" ErrorMessage="The title field is required." />
                </h3>
                <p>
                    Category:
                    <asp:DropDownList runat="server" ID="DropDownListCategory"
                        DataTextField="Name" DataValueField="Id" ItemType="Articles.Web.Models.Category"
                        SelectMethod="DropDownListCategories_GetData" />
                    <br />
                    <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="DropDownListCategory"
                        CssClass="text-danger" ErrorMessage="The category field is required." />
                </p>
                <p>
                    Content:
                    <asp:TextBox TextMode="multiline" Width="400" Height="300" runat="server" ID="TextBoxContent" />
                    <br />
                    <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="TextBoxContent"
                        CssClass="text-danger" ErrorMessage="The Content field is required." />
                </p>
                <br />
                <asp:LinkButton runat="server" ID="LinkButtonCreate"
                    Text="Create" OnClick="LinkButtonCreate_OnClick" CssClass="btn btn-sm btn-success" />
                <asp:LinkButton runat="server" ID="LinkButtonCancel" CausesValidation="False"
                    Text="Cancel" OnClick="LinkButtonCancel_OnClick" CssClass="btn btn-sm btn-danger"></asp:LinkButton>
            </asp:Panel>
        </div>
    </div>

</asp:Content>
