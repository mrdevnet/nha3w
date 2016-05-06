<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register"  %>

<%@ Register Src="SlmControls/slm_register.ascx" TagName="slm_register" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc1:slm_register ID="Slm_register1" runat="server" />
</asp:Content>

