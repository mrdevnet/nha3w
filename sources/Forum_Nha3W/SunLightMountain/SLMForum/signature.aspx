<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="signature.aspx.cs" Inherits="signature" %>

<%@ Register Src="SlmControls/slm_signature.ascx" TagName="slm_signature" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <%--<ajaxToolkit:ToolkitScriptManager ID="tmn1" runat="server" />--%>
    <uc1:slm_signature ID="Slm_signature1" runat="server" />
</asp:Content>

