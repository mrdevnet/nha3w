<%@ Page Language="C#" MasterPageFile="~/HLSProperty.master" AutoEventWireup="true" CodeFile="details.aspx.cs" Inherits="details" %>

<%@ Register Src="ctrls/ads.ascx" TagName="ads" TagPrefix="uc1" %>
<%@ Register Src="ctrls/pdt.ascx" TagName="pdt" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphc" Runat="Server">
    <uc2:pdt ID="Pdt1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphr" Runat="Server">
    <uc1:ads ID="Ads1" runat="server" />
</asp:Content>

