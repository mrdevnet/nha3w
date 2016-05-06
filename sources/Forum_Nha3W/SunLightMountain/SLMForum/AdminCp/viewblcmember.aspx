<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="viewblcmember.aspx.cs" Inherits="AdminCp_viewblcmember"  %>

<%@ Register Src="Controls/slm_viewblcmember.ascx" TagName="slm_viewblcmember" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_viewblcmember id="Slm_viewblcmember1" runat="server">
    </uc1:slm_viewblcmember>
</asp:Content>

