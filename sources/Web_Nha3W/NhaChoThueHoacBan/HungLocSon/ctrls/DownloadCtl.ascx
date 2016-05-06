<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DownloadCtl.ascx.cs" Inherits="DownloadCtl" %>
    <div style="width:100%; height:auto; overflow:hidden;font-size:11px;font-family:Tahoma" align="left">
     <ul id="TinNB" class="ulDow" runat="server">                                                
    </ul> 
    <div style="width:100%; text-align:right">
        <asp:Label ID="lbKQ" runat="server" Text=""></asp:Label>
      <%--  <asp:Label ID="lbT" runat="server" Text="<<"></asp:Label>--%>
        <asp:LinkButton ID="lT" runat="server" OnClick="lT_Click"><<</asp:LinkButton>
        |
        <asp:LinkButton ID="lS" runat="server" OnClick="lS_Click">>></asp:LinkButton>
        <asp:Label ID="lbP" runat="server" Text="3/5"></asp:Label>
       <%-- <asp:Label ID="lbS" runat="server" Text=">>"></asp:Label>--%>
        </div>                            
    </div>