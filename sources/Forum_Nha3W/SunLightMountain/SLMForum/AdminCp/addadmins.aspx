<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="addadmins.aspx.cs" Inherits="AdminCp_addadmins" %>

<%@ Register Src="Controls/slm_addadmins.ascx" TagName="slm_addadmins" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_addadmins ID="Slm_addadmins1" runat="server" />
</asp:Content>

