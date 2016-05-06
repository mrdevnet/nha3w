<%@ Page Language="C#" MasterPageFile="~/admincp/HLSAdmins.master" AutoEventWireup="true" CodeFile="addgroup.aspx.cs" Inherits="admincp_addgroup"  %>

<%@ Register Src="ctrls/groups.ascx" TagName="groups" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:groups ID="Groups1" runat="server" />
</asp:Content>

