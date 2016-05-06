<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="editmessage.aspx.cs" Inherits="editmessage" %>

<%@ Register Src="SlmControls/slm_newtopic.ascx" TagName="slm_newtopic" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc1:slm_newtopic ID="Slm_newtopic1" runat="server" />
</asp:Content>

