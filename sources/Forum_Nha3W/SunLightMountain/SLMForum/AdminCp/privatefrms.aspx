<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="privatefrms.aspx.cs" Inherits="AdminCp_privatefrms" %>
<%@ Register Src="Controls/slm_privatefrm.ascx" TagName="slm_privatefrm" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_privatefrm ID="Slm_privatefrm1" runat="server" />
</asp:Content>

