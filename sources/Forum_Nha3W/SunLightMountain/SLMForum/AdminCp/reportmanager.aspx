<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="reportmanager.aspx.cs" Inherits="AdminCp_reportmanager"  %>

<%@ Register Src="Controls/slm_reportman.ascx" TagName="slm_reportman" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_reportman ID="Slm_reportman1" runat="server" />
</asp:Content>

