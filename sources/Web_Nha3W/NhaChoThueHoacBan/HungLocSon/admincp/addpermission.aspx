<%@ Page Language="C#" MasterPageFile="~/admincp/HLSAdmins.master" AutoEventWireup="true" CodeFile="addpermission.aspx.cs" Inherits="admincp_addpermission"  %>

<%@ Register Src="ctrls/Permissions.ascx" TagName="Permissions" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Permissions id="Permissions1" runat="server">
    </uc1:Permissions>
</asp:Content>

