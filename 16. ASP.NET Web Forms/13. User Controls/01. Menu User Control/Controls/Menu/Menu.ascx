<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="MenuUserControl.Controls.Menu.Menu" %>

<ul class="nav nav-pills nav-stacked">
    <asp:DataList runat="server" ID="DataListLinks">
        <ItemTemplate>
            <a class="list-group-item" href="<%#: Eval("Url") %>"  style='color: <%#: Eval("FontColor") %>'>
                <%#: Eval("Title") %> 
            </a>
        </ItemTemplate>
    </asp:DataList>
</ul>
