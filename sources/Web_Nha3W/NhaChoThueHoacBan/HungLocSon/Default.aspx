<%@ Page Language="C#" MasterPageFile="~/HLSProperty.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="ctrls/pst.ascx" TagName="pst" TagPrefix="uc1" %>
<%@ Register Src="ctrls/ads.ascx" TagName="ads" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphc" Runat="Server">
    <uc1:pst ID="Pst1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphr" Runat="Server">
    <uc2:ads ID="Ads1" runat="server" />
</asp:Content>

