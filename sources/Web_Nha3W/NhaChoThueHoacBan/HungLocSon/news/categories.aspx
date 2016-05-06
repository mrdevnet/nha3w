<%@ Page Language="C#" MasterPageFile="~/HLSNews.master" AutoEventWireup="true" CodeFile="categories.aspx.cs" Inherits="news_categories"  %>
<%@ Register Src="../ctrls/MapLink.ascx" TagName="MapLink" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" Runat="Server">
  <div style="width:700px; padding-right:10px; float:left;">  
    <div id="view" runat="server" style="width:100%">
        <uc1:MapLink ID="lm" runat="server" /><hr />
        <div style="width:100%; float:left">
        <div class = "divT1" style="text-align:center">
            <a id="AimgNB0" runat="server">
<img id="imgTB0" width="270" src="" alt="" runat="server" /></a>
        </div>
        <div class = "divT2" style="text-align:left">
            <h2 style="line-height:19px;font-size:15px;font-family:Tahoma"><a id="tdNB0" runat="server"></a></h2>
            <span id="ndNB0" runat="server" style="color:  #808080; font-size:11px"></span>
            <br /><span style="line-height:17px;font-size:12px;font-family:Tahoma" id="ttNB0" runat="server"> </span>
        </div>
    </div><br />
    <div style="width:100%; float:left">
        <asp:Repeater ID="griTT" runat="server">
            <ItemTemplate>
                <div class="dot2" style="width:100%; padding-top:10px; margin-top:10px; float:left;">
                <div style="float:left; width:100px; text-align:left; padding-right:5px; padding-bottom:20px;">
                    <a href='<%# Eval("NewsId", "articles.aspx?i={0}")%>'>
                      <img alt="" src='<%# ResolveUrl(HungLocSon.Tools.Support.DateTimeToURL(Eval("Posted").ToString())+ Eval("NewsID","{0}/image/") + Eval("Images"))  %>' width="100" /></a>                
                </div>
                  <div style="float:left; text-align:left; width:580px; padding-right:5px; padding-bottom:20px;">
                    <a style="font-weight:bold;font-size:12px;font-family:Tahoma" href='<%# Eval("NewsId", "articles.aspx?i={0}")%>'><%# Eval("Title") %></a><br />
                    <span  style="color:  #808080; font-size:11px"><%# Eval("Posted","{0:dd/MM/yyyy} {0:T}") %> </span> <br />
                    <span style="line-height:17px;font-size:12px;font-family:Tahoma"><%# Eval("Summary")%></span>
                </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div  class="fpgn">
        <asp:Literal ID="lt" runat="server"></asp:Literal>
    </div>
    </div>
    </div>
</asp:Content>

