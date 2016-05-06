<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

<%@ Register Src="SlmControls/slm_search.ascx" TagName="slm_search" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc1:slm_search ID="Slm_search1" runat="server" />
</asp:Content>

