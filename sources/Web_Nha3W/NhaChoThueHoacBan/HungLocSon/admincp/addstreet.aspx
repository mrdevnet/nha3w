<%@ Page Language="C#" MasterPageFile="~/admincp/HLSAdmins.master" AutoEventWireup="true" CodeFile="addstreet.aspx.cs" Inherits="admincp_addstreet"  %>

<%@ Register Src="ctrls/streets.ascx" TagName="streets" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:streets ID="Streets1" runat="server" />
</asp:Content>

