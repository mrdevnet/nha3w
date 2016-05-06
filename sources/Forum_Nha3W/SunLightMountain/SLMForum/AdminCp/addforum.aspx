<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="addforum.aspx.cs" Inherits="AdminCp_addforum"  %>

<%@ Register Src="Controls/slm_addforums.ascx" TagName="slm_addforums" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_addforums id="Slm_addforums1" runat="server">
    </uc1:slm_addforums>
</asp:Content>

