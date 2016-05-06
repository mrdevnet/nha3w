<%@ Page Language="C#" MasterPageFile="~/HLSNews.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="news_Default" %>
<%@ Register Src="../ctrls/Polls.ascx" TagName="Polls" TagPrefix="uc4" %>
<%@ Register Src="../ctrls/NewNews.ascx" TagName="NewNews" TagPrefix="uc1" %>
<%@ Register Src="../ctrls/SubMenu.ascx" TagName="SubMenu" TagPrefix="uc3" %>
<%@ Register Src="../ctrls/NewsItem.ascx" TagName="NewsItem" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphUser" Runat="Server">
    <div style="width:100%">
   <div style="width:100%; float:left;">
       <uc1:NewNews ID="NewNews1" runat="server" />
   </div>
   <div style="width:100%; float:left;">
     <asp:Repeater ID="listC" runat="server" OnItemDataBound="listC_ItemDataBound">
        <ItemTemplate>
         <div style="width:700px; padding-top:6px;text-align:left; padding-bottom:20px;">
             <asp:Label ID="key" runat="server" Text='<%# Eval("CatalogId")%>' Visible="false" ></asp:Label>
           <div style="width:700px; height:30px; float:left; ">   
           <uc3:SubMenu ID="mn" runat="server" />  
           </div>
           <div style="width:690px; padding:10px; float:left;">
           <uc2:NewsItem ID="ni" runat="server" />
           
           </div>
           
         </div>
        </ItemTemplate>
        </asp:Repeater>
   </div>
   </div>
    <uc4:Polls ID="Polls1" runat="server" />
</asp:Content>

