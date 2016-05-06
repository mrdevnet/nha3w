<%@ Page Language="C#" MasterPageFile="~/admincp/HLSAdmins.master" AutoEventWireup="true" CodeFile="addcity.aspx.cs" Inherits="admincp_addcity"  %>

<%@ Register Src="ctrls/cities.ascx" TagName="cities" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:cities ID="Cities1" runat="server" />
</asp:Content>

