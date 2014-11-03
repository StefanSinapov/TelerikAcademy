<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CrowdChat.Web._Default" %>
<%@ Import Namespace="CrowdChat.Common" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome to Crowd Chat</h1>
        <p>Crowd Chat is a private place, where we can send post to all other users.</p>
        <h2>Admin and Moderator accounts:</h2>
        <ul>
            <li>Admin:
                <ul>
                    <li><strong>Username:</strong> <%= GlobalConstants.AdministratorUserName %></li>
                    <li><strong>Password:</strong> <%= GlobalConstants.AdministratorPassword %></li>
                </ul>
            </li>
             <li>Moderator:
                <ul>
                    <li><strong>Username:</strong> <%= GlobalConstants.ModeratorUserName %></li>
                    <li><strong>Password:</strong> <%= GlobalConstants.ModeratorPassword %></li>
                </ul>
            </li>
        </ul>
    </div>

</asp:Content>
