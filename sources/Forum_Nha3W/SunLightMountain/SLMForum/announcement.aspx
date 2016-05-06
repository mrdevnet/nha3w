<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="announcement.aspx.cs" Inherits="announcement" %>

<%@ Register Src="SlmControls/slm_jump.ascx" TagName="slm_jump" TagPrefix="uc2" %>

<%@ Register Src="SlmControls/slm_report.ascx" TagName="slm_report" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc1:slm_report ID="Slm_report1" runat="server" />
    <uc2:slm_jump ID="Slm_jump1" runat="server" />    
</asp:Content>

