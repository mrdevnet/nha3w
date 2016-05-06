<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="viewonline.aspx.cs" Inherits="AdminCp_viewonline"  %>

<%@ Register Src="Controls/slm_viewonline.ascx" TagName="slm_viewonline" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_viewonline ID="Slm_viewonline1" runat="server" />
</asp:Content>

