<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="resetnewpass.aspx.cs" Inherits="resetnewpass" %>

<%@ Register Src="SlmControls/slm_resetpass.ascx" TagName="slm_resetpass" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_resetpass ID="Slm_resetpass1" runat="server" />
</asp:Content>

