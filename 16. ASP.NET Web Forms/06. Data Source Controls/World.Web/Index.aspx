<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="World.Web.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>World master - details</title>
</head>
<body>
    <form id="FormIndex" runat="server">
        <p>Continents:</p>
        <asp:ListBox ID="ListBoxContinents" runat="server"
            Rows="7" AutoPostBack="true" OnSelectedIndexChanged="BindCountries"
            DataKeyNames="Id" ItemType="World.Models.Continent">
        </asp:ListBox>
        <p>Countries:</p>
        <asp:GridView ID="GridViewCoutries" runat="server"
            ItemType="World.Models.Country"
            AutoGenerateColumns="False"
            OnSelectedIndexChanged="BindTowns"
            OnRowEditing="GridViewCoutries_OnRowEditing"
            OnRowCancelingEdit="GridViewCoutries_OnRowCancelingEdit"
            OnRowDeleting="GridViewCoutries_OnRowDeleting"
            OnPageIndexChanging="GridViewCoutries_OnPageIndexChanging"
            ShowFooter="True"
            AllowPaging="True" PageSize="2"
            DataKeyNames="Id">
            <Columns>
                <asp:TemplateField>
                    <FooterTemplate>
                        <asp:Button runat="server" ID="ButtonInsert" 
                            Text="Add new" OnClick="ButtonInsert_OnClick"/>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate><%#: Item.Name %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="TextBoxCountryName"
                            Text="<%#: BindItem.Name %>"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="TextBoxCountryName"
                            placeholder="Name"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Language">
                    <ItemTemplate><%#: Item.Language %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="TextBoxCountryLanguage"
                            Text="<%#: BindItem.Language %>"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="TextBoxCountryLanguage"
                            placeholder="Language"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Population">
                    <ItemTemplate><%#: Item.Population %></ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="TextBoxCountryPopulation"
                            Text="<%#: BindItem.Population %>"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="TextBoxCountryPopulation"
                            placeholder="Population"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Action"
                    ShowSelectButton="true"
                    ShowEditButton="true"
                    ShowDeleteButton="true"/>
            </Columns>
            
            <EmptyDataTemplate>
                <p>No countries for selected continent.</p>
            </EmptyDataTemplate>
        </asp:GridView>
        <p>Towns:</p>
        <asp:ListView ID="ListViewTowns" runat="server"
                ItemType="World.Models.Town"
                OnItemEditing="ListViewTowns_OnItemEditing"
                OnItemUpdating="ListViewTowns_OnItemUpdating"
                OnItemCanceling="ListViewTowns_OnItemCanceling"
                OnItemDeleting="ListViewTowns_OnItemDeleting"
                OnItemInserting="ListViewTowns_OnItemInserting"
                OnPagePropertiesChanging="ListViewTowns_OnPagePropertiesChanging"
                ItemPlaceholderID="townsPlaceHolder"
                InsertItemPosition="None"
                DataKeyNames="Id">
                <LayoutTemplate>
                    <asp:Button ID="ButtonAddTown" runat="server"
                            Text="Add new"
                            OnClick="ButtonAddTown_OnClick" />
                    <asp:PlaceHolder runat="server" ID="townsPlaceHolder"></asp:PlaceHolder>
                    <asp:DataPager ID="DataPagerTowns" runat="server" PagedControlID="ListViewTowns" PageSize="2">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                ShowNextPageButton="false" />
                            <asp:NumericPagerField ButtonType="Link" />
                            <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                        </Fields>
                    </asp:DataPager>
                </LayoutTemplate>

                <ItemTemplate>
                    <h2><%#: Item.Name %></h2>
                    <p>Population: <%# Item.Population %></p>
                    <p>
                        <asp:Button ID="ButtonEditTown" runat="server"
                            Text="Edit"
                            CommandName="Edit" />
                        <asp:Button ID="buttonDeleteTown" runat="server"
                            Text="Delete"
                            CommandName="Delete" />
                    </p>
                </ItemTemplate>

                <EditItemTemplate>
                    <p>
                        <asp:TextBox ID="TextBoxTownName" runat="server"
                            Text="<%#: Item.Name %>"></asp:TextBox>
                        <asp:TextBox ID="TextBoxTownPopulation" runat="server"
                            Text="<%#: Item.Population %>"></asp:TextBox>
                        <asp:Button ID="ButtonUpdateTown" runat="server"
                            Text="Update"
                            CommandName="Update" />
                        <asp:Button ID="ButtonCancelTown" runat="server"
                            Text="Cancel"
                            CommandName="Cancel" />
                    </p>
                </EditItemTemplate>

                <InsertItemTemplate>
                    <asp:TextBox ID="TextBoxTownName" runat="server"
                        Text="<%#: BindItem.Name %>"
                        placeholder="Name"></asp:TextBox>
                    <asp:TextBox ID="TextBoxTownPupulation" runat="server"
                        Text="<%#: BindItem.Population %>"
                        placeholder="Population"></asp:TextBox>
                     <asp:Button ID="ButtonInsertTown" runat="server"
                            Text="Insert"
                            CommandName="Insert" />
                     <asp:Button ID="ButtonCancelInsert" runat="server"
                            Text="Cancel"
                            OnClick="ButtonCancelInsert_OnClick" />
                </InsertItemTemplate>

                <EmptyDataTemplate>
                    <p>There is no towns for selected country.</p>
                </EmptyDataTemplate>
            </asp:ListView>
    </form>
</body>
</html>
