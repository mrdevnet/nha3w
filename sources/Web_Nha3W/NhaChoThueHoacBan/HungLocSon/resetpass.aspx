<%@ Page Language="C#" MasterPageFile="~/HLSLogin.master" AutoEventWireup="true" CodeFile="resetpass.aspx.cs" Inherits="resetpass" %>
<%@ Register Src="ctrls/lostpass.ascx" TagName="lostpass" TagPrefix="uc2" %>
<%@ Register Src="ctrls/resetpass.ascx" TagName="resetpass" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
<asp:UpdatePanel id="upnlreset" runat="server">
    <ContentTemplate>
        <div>
            <uc1:resetpass id="hlsresetpass" runat="server"></uc1:resetpass>
        </div>
        <div>
            <uc2:lostpass ID="hlslostpass" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

