<%@ Page Language="C#" MasterPageFile="~/HLSProperty.master" AutoEventWireup="true" CodeFile="manage.aspx.cs" Inherits="manage" %>

<%@ Register Src="ctrls/mng.ascx" TagName="mng" TagPrefix="uc1" %>
<%@ Register Src="ctrls/ads.ascx" TagName="ads" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphc" Runat="Server">
    <uc1:mng ID="Mng1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphr" Runat="Server">
    <uc2:ads ID="Ads1" runat="server" />
</asp:Content>

