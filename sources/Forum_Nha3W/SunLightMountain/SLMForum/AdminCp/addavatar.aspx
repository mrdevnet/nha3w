<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="addavatar.aspx.cs" Inherits="AdminCp_addavatar" %>

<%@ Register Src="Controls/slm_avatars.ascx" TagName="slm_avatars" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_avatars ID="Slm_avatars1" runat="server" />
</asp:Content>

