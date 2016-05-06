<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="changepassword.aspx.cs" Inherits="changepassword" %>

<%@ Register Src="SlmControls/slm_changepass.ascx" TagName="slm_changepass" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_changepass ID="Slm_changepass1" runat="server" />
</asp:Content>