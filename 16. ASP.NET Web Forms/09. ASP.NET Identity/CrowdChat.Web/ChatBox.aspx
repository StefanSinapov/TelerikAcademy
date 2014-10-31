<%@ Page Title="Chat Box" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChatBox.aspx.cs" Inherits="CrowdChat.Web.ChatBox" %>

<%@ Import Namespace="CrowdChat.Common" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: this.Title %></h1>
    <%--

    <asp:UpdatePanel RenderMode="Block" runat="server" ID="UpdatePanelChat">
        <Triggers>
            <asp:AsyncPostBackTrigger EventName="Tick" ControlID="TimerChatRefresh" />
        </Triggers>
        <ContentTemplate>--%>
    <%--
        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <div class="panel">
        <asp:ListView runat="server" ID="ListViewMessages"
            ItemType="CrowdChat.Models.Message"
            DataKeyNames="Id"
            SelectMethod="Select"
            DeleteMethod="Delete"
            UpdateMethod="Update"
            InsertMethod="Insert"
            InsertItemPosition="LastItem">
            <LayoutTemplate>
                <div class="list-group">
                    <div id="itemPlaceholder" runat="server"></div>
                </div>
            </LayoutTemplate>
            <EditItemTemplate>
                <div class="list-group-item">
                    <div>
                        <strong class=""><%#: Item.Author.UserName %></strong>
                        <small class=" text-muted">
                            <span class="glyphicon glyphicon-time"></span>
                            <%# ( DateTime.Now - Item.DateCreated).Minutes %>m ago
                        </small>
                        <asp:LinkButton runat="server" ID="LinkButtonSave" CssClass="btn btn-success btn-sm" Text="Save" CommandName="Update" />
                        <asp:LinkButton runat="server" ID="LinkButtonCancel" CssClass="btn btn-danger btn-sm" Text="Cancel" CommandName="Cancel" />
                    </div>
                    <p>
                        <asp:TextBox runat="server" ID="TextBoxContent" Text="<%#: BindItem.Content %>"
                            TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </p>
                </div>
            </EditItemTemplate>
            <ItemTemplate>
                <div class="list-group-item">
                    <div>
                        <strong class=""><%#: Item.Author.UserName %></strong>
                        <small class=" text-muted">
                            <span class="glyphicon glyphicon-time"></span>
                            <%# string.Format("{0}h {1}m ago",( DateTime.Now - Item.DateCreated).Hours,( DateTime.Now - Item.DateCreated).Minutes )%>
                        </small>
                        <asp:LoginView runat="server">
                            <RoleGroups>
                                <asp:RoleGroup Roles="Administrator">
                                    <ContentTemplate>
                                        <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-danger btn-sm" Text="Delete" CommandName="Delete" />
                                        <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info btn-sm" Text="Edit" CommandName="Edit" />
                                    </ContentTemplate>
                                </asp:RoleGroup>
                                <asp:RoleGroup Roles="Moderator">
                                    <ContentTemplate>
                                        <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info btn-sm" Text="Edit" CommandName="Edit" />
                                    </ContentTemplate>
                                </asp:RoleGroup>
                            </RoleGroups>
                        </asp:LoginView>
                    </div>
                    <p><%#: Item.Content %></p>
                </div>
            </ItemTemplate>
            <InsertItemTemplate>
                <div class="panel-footer ">
                    <div class="input-group">
                        <asp:TextBox runat="server" ID="TextBoxContent" Text="<%#: BindItem.Content %>"
                            TextMode="MultiLine" CssClass="form-control" placeholder="Type your message here..." />
                        <span class="input-group-btn">
                            <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-success btn-lg pull-right" Text="Send" CommandName="Insert" />
                        </span>
                    </div>
                </div>
            </InsertItemTemplate>

        </asp:ListView>
    </div>
    <%--<asp:Timer ID="TimerChatRefresh" runat="server" Interval="100" />--%>
</asp:Content>
