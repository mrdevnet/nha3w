<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="groupmanager.aspx.cs" Inherits="AdminCp_groupmanager"  %>

<%@ Register Src="Controls/slm_grpman.ascx" TagName="slm_grpman" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_grpman id="Slm_grpman1" runat="server">
    </uc1:slm_grpman>
</asp:Content>

