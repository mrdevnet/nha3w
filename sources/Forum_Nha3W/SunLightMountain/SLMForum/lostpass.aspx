<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="lostpass.aspx.cs" Inherits="lostpass" %>

<%@ Register Src="SlmControls/slm_forgetpassword.ascx" TagName="slm_forgetpassword"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc1:slm_forgetpassword ID="Slm_forgetpassword1" runat="server" />
</asp:Content>

