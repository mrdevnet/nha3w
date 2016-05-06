<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="cateman.aspx.cs" Inherits="AdminCp_cateman" %>

<%@ Register Src="Controls/slm_cateman.ascx" TagName="slm_cateman" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_cateman ID="Slm_cateman1" runat="server" />
</asp:Content>

