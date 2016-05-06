<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="updelmember.aspx.cs" Inherits="AdminCp_updelmember"  %>

<%@ Register Src="Controls/slm_updelmember.ascx" TagName="slm_updelmember" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_updelmember ID="Slm_updelmember1" runat="server" />
</asp:Content>

