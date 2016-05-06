<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="showtopic.aspx.cs" Inherits="showtopic" %>
<%@ Register Src="SlmControls/slm_aut.ascx" TagName="slm_aut" TagPrefix="uc3" %>
<%@ Register Src="SlmControls/slm_jump.ascx" TagName="slm_jump" TagPrefix="uc2" %>
<%@ Register Src="SlmControls/slm_message.ascx" TagName="slm_message" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc1:slm_message ID="Slm_message1" runat="server" />
    <uc2:slm_jump ID="Slm_jump1" runat="server" />
    <uc3:slm_aut ID="Slm_aut1" runat="server" />
</asp:Content>

