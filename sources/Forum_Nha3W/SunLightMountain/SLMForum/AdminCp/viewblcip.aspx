<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="viewblcip.aspx.cs" Inherits="AdminCp_viewblcip"  %>

<%@ Register Src="Controls/slm_viewblcip.ascx" TagName="slm_viewblcip" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_viewblcip id="Slm_viewblcip1" runat="server">
    </uc1:slm_viewblcip>
</asp:Content>

