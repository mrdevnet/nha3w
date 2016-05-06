<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="viewadmins.aspx.cs" Inherits="AdminCp_viewadmins" %>

<%@ Register Src="Controls/slm_alladmins.ascx" TagName="slm_alladmins" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_alladmins ID="Slm_alladmins1" runat="server" />
</asp:Content>

