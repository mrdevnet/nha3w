<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="showprofile.aspx.cs" Inherits="showprofile" %>

<%@ Register Src="SlmControls/slm_profile.ascx" TagName="slm_profile" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc1:slm_profile ID="Slm_profile1" runat="server" />
</asp:Content>

