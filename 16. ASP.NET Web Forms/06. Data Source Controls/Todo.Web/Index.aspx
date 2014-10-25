<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Todo.Web.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3>Categories:</h3>
    <asp:ListView ID="ListViewCategories" runat="server"
        DataKeyNames="Id" DataSourceID="CategoriesRepository"
        InsertItemPosition="LastItem">
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:TextBox ID="IdTextBox" runat="server" ReadOnly="true" Text='<%# Bind("Id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <%--<td>
                        <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                    </td>--%>
                <td></td>
                <td>
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr runat="server" style="">
                                <th runat="server"></th>
                                <th runat="server">Id</th>
                                <th runat="server">Name</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style=""></td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>

    <asp:ObjectDataSource ID="CategoriesRepository" runat="server"
        TypeName="Todo.Data.Repository.CategoriesRepository"
        DeleteMethod="DeleteCategories"
        InsertMethod="InsertCategory"
        SelectMethod="SelectCategories"
        UpdateMethod="EditCategories">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    
    <h3>Todos:</h3>
    <asp:ListView ID="ListViewTodos" runat="server" DataSourceID="TodosRepository" GroupItemCount="3" InsertItemPosition="LastItem">
        <EditItemTemplate>
            <td runat="server" style="">Id:
                <asp:TextBox ID="IdTextBox" runat="server" ReadOnly="true" Text='<%# Bind("Id") %>' />
                <br />
                Title:
                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                <br />
                Category:
                <asp:TextBox ID="CategoryTextBox" runat="server" Text='<%# Bind("Category") %>' />
                <br />
                LastModified:
                <asp:TextBox ID="LastModifiedTextBox" runat="server" ReadOnly="True" Text='<%# Bind("LastModified") %>' />
                <br />
                Content:
                <asp:TextBox ID="ContentTextBox" runat="server" Text='<%# Bind("Content") %>' />
                <br />
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                <br />
            </td>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
            <td runat="server" />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <InsertItemTemplate>
            <td runat="server" style="">Id:
                <%--<asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />--%>
                <br />
                Title:
                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                <br />
                Category:
                <asp:TextBox ID="CategoryTextBox" runat="server" Text='<%# Bind("Category") %>' />
                <br />
                Content:
                <asp:TextBox ID="ContentTextBox" runat="server" Text='<%# Bind("Content") %>' />
                <br />
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                <br />
            </td>
        </InsertItemTemplate>
        <ItemTemplate>
            <td runat="server" style="">Id:
                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                <br />
                Title:
                <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                <br />
                Category:
                <asp:Label ID="CategoryLabel" runat="server" Text='<%# Eval("Category") %>' />
                <br />
                LastModified:
                <asp:Label ID="LastModifiedLabel" runat="server" Text='<%# Eval("LastModified") %>' />
                <br />
                Content:
                <asp:Label ID="ContentLabel" runat="server" Text='<%# Eval("Content") %>' />
                <br />
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                <br />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                <br />
            </td>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <td runat="server" style="">Id:
                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                <br />
                Title:
                <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                <br />
                Category:
                <asp:Label ID="CategoryLabel" runat="server" Text='<%# Eval("Category") %>' />
                <br />
                LastModified:
                <asp:Label ID="LastModifiedLabel" runat="server" Text='<%# Eval("LastModified") %>' />
                <br />
                Content:
                <asp:Label ID="ContentLabel" runat="server" Text='<%# Eval("Content") %>' />
                <br />
                <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                <br />
                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                <br />
            </td>
        </SelectedItemTemplate>
    </asp:ListView>


    <asp:ObjectDataSource ID="TodosRepository" runat="server"
        TypeName="Todo.Data.Repository.TodosRepository"
        DeleteMethod="DeleteTodo"
        InsertMethod="InsertTodo"
        SelectMethod="SelectTodos"
        UpdateMethod="EditTodo">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Content" Type="String" />
            <asp:Parameter Name="LastModified" Type="String" />
            <asp:Parameter Name="Category" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Id" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Content" Type="String" />
            <asp:Parameter Name="LastModified" Type="String" />
            <asp:Parameter Name="Category" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>

</asp:Content>
