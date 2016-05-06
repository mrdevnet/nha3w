<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="addbanner.aspx.cs" Inherits="AdminCp_addbanner" %>

<%@ Register Src="Controls/slm_bannerads.ascx" TagName="slm_bannerads" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_bannerads ID="Slm_bannerads1" runat="server" />
</asp:Content>

