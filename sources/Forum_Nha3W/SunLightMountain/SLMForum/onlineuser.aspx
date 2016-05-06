<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="onlineuser.aspx.cs" Inherits="onlineuser" %>

<%@ Register Src="SlmControls/slm_jump.ascx" TagName="slm_jump" TagPrefix="uc2" %>

<%@ Register Src="SlmControls/slm_whoisonline.ascx" TagName="slm_whoisonline" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc1:slm_whoisonline ID="Slm_whoisonline1" runat="server" />
    <uc2:slm_jump ID="Slm_jump1" runat="server" />
</asp:Content>

