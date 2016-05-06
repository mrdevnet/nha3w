<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="blockusername.aspx.cs" Inherits="AdminCp_blockusername"  %>

<%@ Register Src="Controls/slm_searchme.ascx" TagName="slm_searchme" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_searchme id="Slm_searchme1" runat="server">
    </uc1:slm_searchme>
</asp:Content>

