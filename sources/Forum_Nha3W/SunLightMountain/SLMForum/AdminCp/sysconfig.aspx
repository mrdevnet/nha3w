<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="sysconfig.aspx.cs" Inherits="AdminCp_sysconfig" %>

<%@ Register Src="Controls/slm_sysconfig.ascx" TagName="slm_sysconfig" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_sysconfig id="Slm_sysconfig1" runat="server">
    </uc1:slm_sysconfig>
</asp:Content>

