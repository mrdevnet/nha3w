<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="editprofile.aspx.cs" Inherits="editprofile" %>

<%@ Register Src="SlmControls/slm_cpeditpro.ascx" TagName="slm_cpeditpro" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_cpeditpro ID="Slm_cpeditpro1" runat="server" />
</asp:Content>

