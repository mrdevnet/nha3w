<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_advertises.ascx.cs" Inherits="SlmControls_slm_advertises" %>
<div style="width:96%;float:right">
<asp:Repeater ID="rptAds" runat="server">
    <ItemTemplate>
        <div class="r2">
            <a target="_blank" href='<%# Eval("Url") %>' class="rads3"><div style="padding-bottom:7px"><%# Eval("Title") %></div>
            <div style="padding-bottom:7px"><img src='../ads/<%# Eval("Image") %>' class="bads"/></div></a>
            <a target="_blank" href='<%# Eval("Url") %>' class="rads4"><%# Eval("BodyText") %></a>
        </div>
    </ItemTemplate>
</asp:Repeater>
</div>