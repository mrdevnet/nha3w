<%@ Page Language="C#" MasterPageFile="~/admincp/HLSAdmins.master" AutoEventWireup="true" CodeFile="addproject.aspx.cs" Inherits="admincp_addproject"  %>

<%@ Register Src="ctrls/projects.ascx" TagName="projects" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:projects ID="Projects1" runat="server" />
</asp:Content>

