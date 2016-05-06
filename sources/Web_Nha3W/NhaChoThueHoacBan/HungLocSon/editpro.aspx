<%@ Page Language="C#" MasterPageFile="~/HLSProfile.master" AutoEventWireup="true" CodeFile="editpro.aspx.cs" Inherits="editpro"  %>

<%@ Register Src="ctrls/editpro.ascx" TagName="editpro" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
<div style="MARGIN-BOTTOM: 15px">
    <h1 id="fullname" runat="server">Thông tin cá nhân</h1>
</div>
<div class="content_contentpf">
    <uc1:editpro ID="Editpro1" runat="server" />
</div>
<div class="content_contentpf2">
    <asp:Repeater ID="rptAds" runat="server">
        <ItemTemplate>
            <div class="r2pfe">
                <a target="_blank" href='<%# Eval("Url") %>' class="rads3"><div style="padding-bottom:7px"><%# Eval("Title") %></div>
                <div style="padding-bottom:7px"><img src='ads/<%# Eval("Image") %>' class="bads"/></div></a>
                <a target="_blank" href='<%# Eval("Url") %>' class="rads4"><%# Eval("BodyText") %></a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>

