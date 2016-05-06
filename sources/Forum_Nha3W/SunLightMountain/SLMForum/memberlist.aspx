<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="memberlist.aspx.cs" Inherits="memberlist" %>

<%@ Register Src="SlmControls/slm_memberlist.ascx" TagName="slm_memberlist" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc1:slm_memberlist ID="Slm_memberlist1" runat="server" />
</asp:Content>

