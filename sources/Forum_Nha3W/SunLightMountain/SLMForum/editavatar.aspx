<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="editavatar.aspx.cs" Inherits="editavatar" %>

<%@ Register Src="SlmControls/slm_cpeditavatar.ascx" TagName="slm_cpeditavatar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_cpeditavatar ID="Slm_cpeditavatar1" runat="server" />
</asp:Content>

