<%@ Page Title="Edit Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="LibrarySystem.Admin.EditBooks" %>

<%@ Import Namespace="LibrarySystem" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Books</h1>

    <div class="row">
        <div class="col-md-12">
            <asp:ListView runat="server" ID="ListViewBooks"
                SelectMethod="Select"
                DeleteMethod="ListViewBooks_Delete"
                UpdateMethod="Update"
                DataKeyNames="Id"
                ItemType="LibrarySystem.Models.Book">

                <LayoutTemplate>
                    <table class="table table-striped table-hover table-bordered">
                        <thead>
                            <tr>
                                <th scope="col">
                                    <asp:LinkButton Text="Title" runat="server" ID="LinkButtonSortByTitle" CommandName="Sort" CommandArgument="Title" />
                                </th>
                                <th scope="col">
                                    <asp:LinkButton Text="Author" runat="server" ID="LinkButtonSortByAuthor" CommandName="Sort" CommandArgument="Author" />
                                </th>
                                <th scope="col">
                                    <asp:LinkButton Text="ISBN" runat="server" ID="LinkButtonSortByISBN" CommandName="Sort" CommandArgument="ISBN" />
                                </th>
                                <th scope="col">
                                    <asp:LinkButton Text="Web Site" runat="server" ID="LinkButtonSortByWebSite" CommandName="Sort" CommandArgument="WebSite" />
                                </th>
                                <th scope="col">
                                    <%--<asp:LinkButton Text="Category" runat="server" ID="LinkButtonSortByCategory" CommandName="Sort" CommandArgument="Category.Name" />--%>
                                    Category
                                </th>
                                <th scope="col">Action</th>
                            </tr>
                        </thead>
                        <tfoot>
                        </tfoot>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                            <tr>
                                <td colspan="6">
                                    <asp:DataPager runat="server" ID="DataPagerCategories" PageSize="5">
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
                        <td>
                            <%#: Item.Title.Short() %>
                        </td>
                        <td>
                            <%#: Item.Author %>
                        </td>
                        <td>
                            <%#: Item.ISBN %>
                        </td>
                        <td>
                            <a href="<%#: Item.WebSite %>"><%#: Item.WebSite.Short() %></a>
                        </td>
                        <td>
                            <%#: Item.Category.Name.Short() %>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-default btn-sm" Text="Edit" CommandName="Edit" />
                            <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-default btn-sm" Text="Delete" CommandName="Delete" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:Button runat="server" ID="ButtonShowCreatePanel" OnClick="ButtonShowCreatePanel_OnClick"
                Text="Create New" CssClass="btn btn-primary" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-7">
            <asp:Panel runat="server" ID="PanelCreate" CssClass="panel panel-default" Visible="False">
                <div class="panel-body">
                    <h2 class="well">Create New Book</h2>

                    <div class="form-group col-md-12">
                        <label for="<%= TextBoxTitleCreate.ClientID %>" class="col-md-2 control-label">Title:</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxTitleCreate"
                                CssClass="form-control"
                                placeholder="Enter book title..."></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-md-12">
                        <label for="<%= TextBoxAuthorCreate.ClientID %>" class="col-md-2 control-label">Author(s):</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxAuthorCreate"
                                CssClass="form-control"
                                placeholder="Enter book author/authors..."></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-md-12">
                        <label for="<%= TextBoxISBNCreate.ClientID %>" class="col-md-2 control-label">ISBN:</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxISBNCreate"
                                CssClass="form-control"
                                placeholder="Enter book ISBN..."></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-md-12">
                        <label for="<%= TextBoxWebSiteCreate.ClientID %>" class="col-md-2 control-label">Web Site:</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxWebSiteCreate"
                                CssClass="form-control"
                                placeholder="Enter book Web Site..."></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-md-12">
                        <label for="<%= TextBoxDescriptionCreate.ClientID %>" class="col-md-2 control-label">Description:</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxDescriptionCreate"
                                CssClass="form-control" type="textarea" Height="160" Width="280"
                                placeholder="Enter book Description..."></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="form-group col-md-12">
                        <label for="<%= DropDownListCategoryCreate.ClientID %>" class="col-md-2 control-label">Category:</label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="DropDownListCategoryCreate"
                                CssClass="form-control"
                                SelectMethod="DropDownListCategoryCreate_GetData"
                                ItemType="LibrarySystem.Models.Category" DataValueField="Id"
                                DataTextField="Name"  Width="280"
                                >
                            </asp:DropDownList>
                        </div>
                    </div>

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
        <div class="col-md-7">
             <asp:Panel runat="server" ID="PanelUpdate" CssClass="panel panel-default" Visible="False" >
                <div class="panel-body">
                    <h2 class="well">Update Book</h2>

                    <div class="form-group col-md-12">
                        <label for="<%= TextBoxTitleUpdate.ClientID %>" class="col-md-2 control-label">Title:</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxTitleUpdate"
                                CssClass="form-control"
                                placeholder="Enter book title..."></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-md-12">
                        <label for="<%= TextBoxAuthorUpdate.ClientID %>" class="col-md-2 control-label">Author(s):</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxAuthorUpdate"
                                CssClass="form-control"
                                placeholder="Enter book author/authors..."></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-md-12">
                        <label for="<%= TextBoxISBNUpdate.ClientID %>" class="col-md-2 control-label">ISBN:</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxISBNUpdate"
                                CssClass="form-control"
                                placeholder="Enter book ISBN..."></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-md-12">
                        <label for="<%= TextBoxWebSiteUpdate.ClientID %>" class="col-md-2 control-label">Web Site:</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxWebSiteUpdate"
                                CssClass="form-control"
                                placeholder="Enter book Web Site..."></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-md-12">
                        <label for="<%= TextBoxDescriptionUpdate.ClientID %>" class="col-md-2 control-label">Description:</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="TextBoxDescriptionUpdate"
                                CssClass="form-control" type="textarea" Height="160" Width="280"
                                placeholder="Enter book Description..."></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="form-group col-md-12">
                        <label for="<%= DropDownListCategoryUpdate.ClientID %>" class="col-md-2 control-label">Category:</label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="DropDownListCategoryUpdate"
                                CssClass="form-control"
                                SelectMethod="DropDownListCategoryCreate_GetData"
                                ItemType="LibrarySystem.Models.Category" DataValueField="Id"
                                DataTextField="Name"  Width="280">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <br />
                    <asp:LinkButton runat="server" ID="LinkButtonUpdate"
                        Text="Create" OnClick="LinkButtonUpdate_OnClick" CssClass="btn btn-sm btn-default" />
                    <asp:LinkButton runat="server" ID="LinkButtonCancelUpdate"
                        Text="Cancel" OnClick="LinkButtonCancel_OnClick" CssClass="btn btn-sm btn-default"></asp:LinkButton>
                </div>
            </asp:Panel>
        </div>
    </div>

    <div class="row">
        <a href="/">Back to books</a>
    </div>
</asp:Content>
