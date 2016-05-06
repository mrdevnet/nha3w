<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="priority.aspx.cs" Inherits="AdminCp_priority"  %>

<%@ Register Src="Controls/slm_priority.ascx" TagName="slm_priority" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_priority id="Slm_priority1" runat="server">
    </uc1:slm_priority>
</asp:Content>

