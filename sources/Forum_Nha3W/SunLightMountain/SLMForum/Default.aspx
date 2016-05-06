<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"  %>
<%@ Register Src="SlmControls/slm_newposts.ascx" TagName="slm_newposts" TagPrefix="uc3" %>
<%@ Register Src="SlmControls/slm_topannoun.ascx" TagName="slm_topannoun" TagPrefix="uc2" %>
<%@ Register Src="SlmControls/slm_forum.ascx" TagName="slm_forum" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc2:slm_topannoun ID="Slm_topannoun1" runat="server" />
    <uc3:slm_newposts ID="Slm_newposts1" runat="server" />
    <uc1:slm_forum ID="Slm_forum1" runat="server" />
</asp:Content>

