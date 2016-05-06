<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="usermanager.aspx.cs" Inherits="AdminCp_usermanager"  %>

<%@ Register Src="Controls/slm_searchusers.ascx" TagName="slm_searchusers" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_searchusers ID="Slm_searchusers1" runat="server" />
</asp:Content>

