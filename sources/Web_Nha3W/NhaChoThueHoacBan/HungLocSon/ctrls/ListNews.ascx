<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListNews.ascx.cs" Inherits="UserControl_ListNews" %>

<asp:Repeater ID="griTT" runat="server">
<ItemTemplate>
             <div class="dot2" style="width:100%; padding-top:10px; margin-top:10px; float:left;">            
              <div style="float:left; width:100px; text-align:left; padding-right:5px; padding-bottom:40px;">
                 <a href='<%# Eval("NewsId", "articles.aspx?i={0}")%>'>
                  <img alt="" src='<%# ResolveUrl("~/ImagesNews/" + Eval("NewsId").ToString() + "/image/" + Eval("Images").ToString())  %>' width="100" /></a>                
              </div>
              <div style="float:left; text-align:left; width:520px; padding-right:5px; padding-bottom:40px;">
              <a style="font-weight:bold;" href='<%# Eval("NewsId", "articles.aspx?i={0}")%>'><%# Eval("Title") %></a><br />
              <span  style="color:  #808080; font-size:11px"><%# Eval("Posted","{0:dd/MM/yyyy} {0:T}") %> </span> <br />
              <span><%# Eval("Summary")%></span>     
              </div>
             </div>
</ItemTemplate>
</asp:Repeater>
