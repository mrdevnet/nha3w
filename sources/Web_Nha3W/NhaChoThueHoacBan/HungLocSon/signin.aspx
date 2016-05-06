<%@ Page Language="C#" MasterPageFile="~/HLSLogin.master" AutoEventWireup="true" CodeFile="signin.aspx.cs" Inherits="signin" %>
<%@ Register Src="ctrls/login.ascx" TagName="login" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <asp:UpdatePanel id="uplnlogin" runat="server">
        <ContentTemplate>
            <uc1:login id="hsllogin" runat="server"></uc1:login>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

