<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="listactive.aspx.cs" Inherits="listactive" %>

<%@ Register Src="SlmControls/slm_jump.ascx" TagName="slm_jump" TagPrefix="uc2" %>

<%@ Register Src="SlmControls/slm_schactive.ascx" TagName="slm_schactive" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc1:slm_schactive ID="Slm_schactive1" runat="server" />
    <uc2:slm_jump ID="Slm_jump1" runat="server" />
</asp:Content>