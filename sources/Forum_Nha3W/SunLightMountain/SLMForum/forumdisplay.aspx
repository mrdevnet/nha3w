<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="forumdisplay.aspx.cs" Inherits="forumdisplay" %>

<%@ Register Src="SlmControls/slm_jump.ascx" TagName="slm_jump" TagPrefix="uc2" %>
<%@ Register Src="SlmControls/slm_forum.ascx" TagName="slm_forum" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc1:slm_forum ID="Slm_forum1" runat="server" />
    <uc2:slm_jump ID="Slm_jump1" runat="server" />
</asp:Content>

