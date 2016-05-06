<%@ Page Language="C#" MasterPageFile="~/HLSNews.master" AutoEventWireup="true" CodeFile="articles.aspx.cs" Inherits="news_articles" %>
<%@ Register Src="../ctrls/NewsView.ascx" TagName="NewsView" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" Runat="Server">
    <uc1:NewsView ID="NewsView1" runat="server" />
</asp:Content>

