<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="addgroup.aspx.cs" Inherits="AdminCp_addgroup"  %>

<%@ Register Src="Controls/slm_updelgroup.ascx" TagName="slm_updelgroup" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_updelgroup id="Slm_updelgroup1" runat="server">
    </uc1:slm_updelgroup>
</asp:Content>

