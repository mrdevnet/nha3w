<%@ Page Language="C#" MasterPageFile="~/admincp/HLSAdmins.master" AutoEventWireup="true" CodeFile="addward.aspx.cs" Inherits="admincp_addward"  %>

<%@ Register Src="ctrls/wards.ascx" TagName="wards" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:wards ID="Wards1" runat="server" />
</asp:Content>

