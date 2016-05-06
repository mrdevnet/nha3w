<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="updelreport.aspx.cs" Inherits="AdminCp_updelreport"  %>

<%@ Register Src="Controls/slm_updelreports.ascx" TagName="slm_updelreports" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_updelreports id="Slm_updelreports1" runat="server">
    </uc1:slm_updelreports>
</asp:Content>

