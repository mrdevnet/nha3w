<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="updelforum.aspx.cs" Inherits="AdminCp_updelforum"  %>

<%@ Register Src="Controls/slm_updelforum.ascx" TagName="slm_updelforum" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_updelforum ID="Slm_updelforum1" runat="server" />
</asp:Content>

