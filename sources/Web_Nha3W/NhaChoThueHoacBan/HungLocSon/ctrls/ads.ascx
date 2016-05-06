<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ads.ascx.cs" Inherits="ctrls_ads" %>
<div class="r1"><a href="#" class="rads">Tạo Quảng cáo</a></div>
<asp:Repeater ID="rptAds" runat="server">
    <ItemTemplate>
        <div class="r2">
            <a target="_blank" href='<%# Eval("Url") %>' class="rads3"><div style="padding-bottom:7px"><%# Eval("Title") %></div></a>
            <a target="_blank" href='<%# Eval("Url") %>' class="rads2"><div style="padding-bottom:7px"><img src='ads/<%# Eval("Image") %>' class="bads"/></div></a>
            <a target="_blank" href='<%# Eval("Url") %>' class="rads4"><%# Eval("BodyText") %></a>
        </div>
    </ItemTemplate>
</asp:Repeater>
<div class="r3"><a href="#" class="rads">Qc khác</a></div>