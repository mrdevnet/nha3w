<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="viewmoders.aspx.cs" Inherits="AdminCp_viewmoders" %>

<%@ Register Src="Controls/slm_allmoderators.ascx" TagName="slm_allmoderators" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_allmoderators ID="Slm_allmoderators1" runat="server" />
</asp:Content>

