<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="usergroup.aspx.cs" Inherits="AdminCp_usergroup" %>

<%@ Register Src="Controls/slm_updelusergrp.ascx" TagName="slm_updelusergrp" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_updelusergrp ID="Slm_updelusergrp1" runat="server" />
</asp:Content>

