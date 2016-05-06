<%@ Page Language="C#" MasterPageFile="~/SLMountain.master" AutoEventWireup="true" CodeFile="report.aspx.cs" Inherits="report" %>

<%@ Register Src="SlmControls/slm_alarm.ascx" TagName="slm_alarm" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="slmf1" Runat="Server">
    <uc1:slm_alarm ID="Slm_alarm1" runat="server" />
</asp:Content>

