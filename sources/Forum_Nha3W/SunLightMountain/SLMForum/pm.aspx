<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="pm.aspx.cs" Inherits="pm" %>

<%@ Register Src="SlmControls/slm_pm.ascx" TagName="slm_pm" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="tmn1" runat="server" />
    <uc1:slm_pm ID="Slm_pm1" runat="server" />
</asp:Content>