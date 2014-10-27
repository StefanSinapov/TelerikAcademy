<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebChat._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView runat="server" ID="ListViewMessages"
        ItemType="WebChat.Models.Message"
        DataKeyNames="Id">
        <LayoutTemplate>
            <div class="list-group">
                <asp:UpdatePanel runat="server" ID="UpdatePanelChat">
                    <Triggers>
                        <asp:AsyncPostBackTrigger EventName="Tick" ControlID="TimerChatRefresh" />
                    </Triggers>
                    <ContentTemplate>
                        <div id="itemPlaceholder" runat="server"></div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="list-group-item">
                <div>
                    <strong class=""><%#: Item.Username %></strong>
                    <small class=" text-muted">
                        <span class="glyphicon glyphicon-time"></span>
                        <%# ( DateTime.Now - Item.DatePublished).Minutes %>m ago
                    </small>
                </div>
                <p><%#: Item.Content %></p>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <div class="panel-footer ">
        <div class="input-group pull-left">
            <asp:TextBox runat="server" ID="TextBoxContent" type="text" CssClass="form-control" placeholder="Type your message here..." />
            <span class="input-group-btn">
                <asp:Button runat="server" CssClass="btn btn-success btn-sm pull-left" ID="ButtonSend" Text="Send"
                    OnClick="ButtonSend_OnClick" />
            </span>
        </div>
    </div>
    <asp:Timer ID="TimerChatRefresh" runat="server" Interval="500" />
</asp:Content>
