<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LikeControl.ascx.cs" Inherits="Articles.Web.Controls.LikeControl.LikeControl" %>

<div class="like-control">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div>Likes</div>
            <div>
                <asp:LinkButton runat="server" ID="ButtonLike" CommandName="Like"
                    CommandArgument="<%# this.DataId %>" OnCommand="ButtonLike_Command"
                    CssClass="btn btn-default glyphicon glyphicon-chevron-up" />
                <asp:Label runat="server" ID="LableLikesCount" CssClass="like-value" />
                <asp:LinkButton runat="server" ID="ButtonHate" CommandName="Hate"
                    CommandArgument="<%# this.DataId %>" OnCommand="ButtonLike_Command"
                    CssClass="btn btn-default glyphicon glyphicon-chevron-down" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
