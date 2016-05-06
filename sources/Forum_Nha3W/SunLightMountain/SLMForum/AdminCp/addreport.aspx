<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="addreport.aspx.cs" Inherits="AdminCp_addreport"  %>

<%@ Register Src="Controls/slm_addreports.ascx" TagName="slm_addreports" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_addreports id="Slm_addreports1" runat="server">
    </uc1:slm_addreports>
</asp:Content>

