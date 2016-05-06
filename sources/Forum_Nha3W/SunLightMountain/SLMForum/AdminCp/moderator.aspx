<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="moderator.aspx.cs" Inherits="AdminCp_moderator" %>

<%@ Register Src="Controls/slm_moderator.ascx" TagName="slm_moderator" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_moderator ID="Slm_moderator1" runat="server" />
</asp:Content>

