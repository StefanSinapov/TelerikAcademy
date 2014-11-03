<%@ Page Title="Edit Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="LibrarySystem.Admin.EditCategories" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Categories</h1>

    <div class="row">
        <div class="col-md-6">
            <asp:ListView runat="server" ID="ListViewCategories"
                SelectMethod="Select"
                DeleteMethod="Delete"
                UpdateMethod="Update"
                DataKeyNames="Id"
                ItemType="LibrarySystem.Models.Category">
                <LayoutTemplate>
                    <table class="table table-striped table-hover table-bordered">
                        <thead>
                            <tr>
                               <th scope="col">
                                    <asp:LinkButton Text="Caterory Name" runat="server" ID="LinkButtonSortByCategory" CommandName="Sort" CommandArgument="Name" />
                                </th>
                                <th scope="col">Action</th>
                            </tr>
                        </thead>
                        <tfoot>
                        </tfoot>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>

                            <tr>
                                <td colspan="2">
                                    <asp:DataPager runat="server" ID="DataPagerCategories" PageSize="3">
                                        <Fields>
                                            <asp:NumericPagerField NumericButtonCssClass="btn btn-sm btn-default"
                                                CurrentPageLabelCssClass="btn btn-primary btn-sm" />
                                        </Fields>
                                    </asp:DataPager>
                                </td>
                            </tr>
                        </tbody>

                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Name %></td>
                        <td>
                            <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-default btn-sm" Text="Edit" CommandName="Edit" />
                            <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-default btn-sm" Text="Delete" CommandName="Delete" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Name %>"
                                CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:LinkButton runat="server" CssClass="btn btn-default btn-sm" ID="LinkButtonEdit" Text="Save" CommandName="Update" />
                            <asp:LinkButton runat="server" CssClass="btn btn-default btn-sm" ID="LinkButtonDelete" Text="Cancel" CommandName="Cancel" />
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
            <asp:Button runat="server" ID="ButtonShowCreatePanel" OnClick="ButtonShowCreatePanel_OnClick"
                Text="Create New" CssClass="btn btn-primary" />
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
                    <br />
                    <asp:LinkButton runat="server" ID="LinkButtonCreate"
                        Text="Create" OnClick="LinkButtonCreate_OnClick" CssClass="btn btn-sm btn-default" />
                    <asp:LinkButton runat="server" ID="LinkButtonCancel"
                        Text="Cancel" OnClick="LinkButtonCancel_OnClick" CssClass="btn btn-sm btn-default"></asp:LinkButton>
                </div>
            </asp:Panel>
        </div>
    </div>

    <div class="row">
        <a href="/">Back to books</a>
    </div>
</asp:Content>
