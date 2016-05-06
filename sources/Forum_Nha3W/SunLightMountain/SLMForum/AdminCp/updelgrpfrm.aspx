<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="updelgrpfrm.aspx.cs" Inherits="AdminCp_updelgrpfrm" %>

<%@ Register Src="Controls/slm_updelgrpfrm.ascx" TagName="slm_updelgrpfrm" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_updelgrpfrm ID="Slm_updelgrpfrm1" runat="server" />    
</asp:Content>

