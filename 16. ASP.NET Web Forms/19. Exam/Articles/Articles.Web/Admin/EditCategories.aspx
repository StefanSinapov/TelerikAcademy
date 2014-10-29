<%@ Page Title="Edit Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="Articles.Web.Admin.EditCategories" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-6">
            <asp:ListView runat="server" ID="ListViewCategories"
                SelectMethod="Select"
                DeleteMethod="Delete"
                UpdateMethod="Update"
                DataKeyNames="Id"
                ItemType="Articles.Web.Models.Category">
                <LayoutTemplate>
                    <div class="row">
                        <asp:LinkButton Text="Sort By Name" runat="server" ID="LinkButtonSortByCategory" CommandName="Sort" CommandArgument="Name" CssClass="btn btn-default" />
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
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="row">
                        <div class="col-md-5"><%#: Item.Name %></div>
                        <div>
                            <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info btn-sm" Text="Edit" CommandName="Edit" />
                            <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-danger btn-sm" Text="Delete" CommandName="Delete" />
                        </div>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <div class="row">
                        <div class="col-md-5">
                            <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Name %>"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="TextBoxName"
                                CssClass="text-danger" ErrorMessage="The name field is required." />
                        </div>
                        <div>
                            <asp:LinkButton runat="server" CssClass="btn btn-success btn-sm" ID="LinkButtonEdit" Text="Save" CommandName="Update" />
                            <asp:LinkButton runat="server" CssClass="btn btn-danger btn-sm"
                                CausesValidation="False"
                                ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" />
                        </div>
                    </div>
                </EditItemTemplate>
            </asp:ListView>
            <div class="row">
                <asp:Button runat="server" ID="ButtonShowCreatePanel" OnClick="ButtonShowCreatePanel_OnClick"
                    Text="Create New" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <asp:Panel runat="server" ID="PanelCreate" CssClass="panel panel-default" Visible="False">
                <div class="panel-body">
                    <h2 class="well">Create new category</h2>

                    <label for="<%= TextBoxCategoryCreate.ClientID %>">Category: </label>
                    <asp:TextBox runat="server" ID="TextBoxCategoryCreate"
                        CssClass="form-control" placeholder="Enter category name..." />
                    <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="TextBoxCategoryCreate"
                        CssClass="text-danger" ErrorMessage="The name field is required." />
                    <br />
                    <asp:LinkButton runat="server" ID="LinkButtonCreate"
                        Text="Create" OnClick="LinkButtonCreate_OnClick" CssClass="btn btn-sm btn-success" />
                    <asp:LinkButton runat="server" ID="LinkButtonCancel"
                        Text="Cancel" OnClick="LinkButtonCancel_OnClick" CssClass="btn btn-sm btn-danger" CausesValidation="False"></asp:LinkButton>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
