<%@ Page Language="C#" MasterPageFile="~/AdminCp/SLMAdmin.master" AutoEventWireup="true" CodeFile="alarm.aspx.cs" Inherits="AdminCp_alarm"  %>

<%@ Register Src="Controls/slm_alarm.ascx" TagName="slm_alarm" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplAdmin" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <uc1:slm_alarm id="Slm_alarm1" runat="server">
    </uc1:slm_alarm>
</asp:Content>

