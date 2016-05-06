<%@ Page Language="C#" MasterPageFile="~/admincp/HLSAdmins.master" AutoEventWireup="true" CodeFile="adddistrict.aspx.cs" Inherits="admincp_adddistrict"  %>

<%@ Register Src="ctrls/districts.ascx" TagName="districts" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:districts ID="Districts1" runat="server" />
</asp:Content>

