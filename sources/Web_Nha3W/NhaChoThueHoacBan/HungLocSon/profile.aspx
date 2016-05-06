<%@ Page Language="C#" MasterPageFile="~/HLSProperty.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile"%>

<%@ Register Src="ctrls/pst.ascx" TagName="pst" TagPrefix="uc5" %>
<%@ Register Src="ctrls/fgps.ascx" TagName="fgps" TagPrefix="uc4" %>
<%@ Register Src="ctrls/flowings.ascx" TagName="flowings" TagPrefix="uc3" %>
<%@ Register Src="ctrls/nwall.ascx" TagName="nwall" TagPrefix="uc2" %>
<%@ Register Src="ctrls/ads.ascx" TagName="ads" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphc" Runat="Server">
    <uc2:nwall id="Nwall1" runat="server"></uc2:nwall>
    <uc3:flowings ID="Flowings1" runat="server" />
    <uc4:fgps id="Fgps1" runat="server"></uc4:fgps>
    <uc5:pst ID="Pst1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphr" Runat="Server">
    <uc1:ads ID="Ads1" runat="server" />
</asp:Content>

