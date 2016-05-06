<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="topicdisplay.aspx.cs" Inherits="topicdisplay"  %>

<%@ Register Src="SlmControls/slm_aut.ascx" TagName="slm_aut" TagPrefix="uc3" %>
<%@ Register Src="SlmControls/slm_jump.ascx" TagName="slm_jump" TagPrefix="uc2" %>
<%@ Register Src="SlmControls/slm_topic.ascx" TagName="slm_topic" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc1:slm_topic id="Slm_topic1" runat="server"></uc1:slm_topic>
    <uc2:slm_jump ID="Slm_jump1" runat="server" />
    <uc3:slm_aut ID="Slm_aut1" runat="server" />
</asp:Content>

