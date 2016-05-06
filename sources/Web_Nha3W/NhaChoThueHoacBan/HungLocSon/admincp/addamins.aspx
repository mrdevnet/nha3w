<%@ Page Language="C#" MasterPageFile="~/admincp/HLSAdmins.master" AutoEventWireup="true" CodeFile="addamins.aspx.cs" Inherits="admincp_addamins" Title="Untitled Page" %>

<%@ Register Src="ctrls/adms.ascx" TagName="adms" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:adms ID="Adms1" runat="server" />
</asp:Content>

