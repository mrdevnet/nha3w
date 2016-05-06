<%@ Page Language="C#" MasterPageFile="~/HLSNews.master" AutoEventWireup="true" CodeFile="searchpro.aspx.cs" Inherits="news_searchpro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" Runat="Server">
    <div style="width:100%; float:left">
        <div  style="width:100%; text-align:left;">
            <a href="#"><span style="font-size:16px; font-weight:bold">Tìm kiếm</span></a><hr />
        </div>
<div style="width:700px; padding-right:10px; float:left;">
        <div style="width:100%;">
            <asp:Repeater ID="griTT" runat="server">
                <ItemTemplate>
                    <div class="dot2" style="width:100%; padding-top:10px; margin-top:10px; float:left;">
                    <div style="float:left; width:100px; text-align:left; padding-right:5px; padding-bottom:15px;">
                        <a href='<%# Eval("NewsId", "articles.aspx?i={0}")%>'>
                      <img alt="" src='<%# ResolveUrl(HungLocSon.Tools.Support.DateTimeToURL(Eval("Posted").ToString())+ Eval("NewsID","{0}/image/") + Eval("Images"))  %>' width="100" /></a>                
                    </div>
                  <div style="float:left; text-align:left; width:580px; padding-right:5px; padding-bottom:15px;">
                  <a style="font-weight:bold;" href='<%# Eval("NewsId", "articles.aspx?i={0}")%>'><%# Eval("Title") %></a><br />
                        <span  style="color:  #808080; font-size:11px"><%# Eval("Posted","{0:dd/MM/yyyy} {0:T}") %> </span> <br />
                        <span><%# Eval("Summary")%></span>
                    </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div  class="fpgn">
     <asp:Literal ID="lt" runat="server"></asp:Literal></div>
        </div>
    </div>
</asp:Content>

