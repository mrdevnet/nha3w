<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile" %>

<%@ Register Src="SlmControls/slm_cpuser.ascx" TagName="slm_cpuser" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc1:slm_cpuser ID="Slm_cpuser1" runat="server" />
</asp:Content>

