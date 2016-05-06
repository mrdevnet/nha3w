<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pm.ascx.cs" Inherits="ctrls_pm" %>
<%@ Register Src="ems.ascx" TagName="ems" TagPrefix="uc5" %>
<%@ Register Src="temails.ascx" TagName="temail" TagPrefix="uc4" %>
<%@ Register Src="pms.ascx" TagName="pms" TagPrefix="uc3" %>
<%@ Register Src="fpms.ascx" TagName="fpms" TagPrefix="uc2" %>
<%@ Register Src="tpms.ascx" TagName="tpms" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="content_left">
      <div class="ctl_img">
        <a href="editpro.aspx"><asp:Image ID="Imgmb" CssClass="imgmb" Width="60px" runat="server" ImageUrl="~/App_Themes/profile/member.gif" BorderWidth="0px"/></a>
        <asp:HyperLink ID="Hplmb" CssClass="hplmb" runat="server" Font-Bold="True">[Hplmb]</asp:HyperLink> <%--CssClass="hplmb"--%>
        <br />
        <a href="editpro.aspx" style="padding-top:3px;">Sửa thông tin</a>  <%--style="padding-top:3px;"--%>
     </div> 
     <div class="menu_sms">
         <%--<cc1:CollapsiblePanelExtender ID="cpeSMS" runat="server" TargetControlID="PnlPMS" CollapseControlID="Pnlsms" CollapsedText="Tin nhắn" ExpandControlID="Pnlsms" ExpandedText="Tin nhắn" TextLabelID="lblpms" Collapsed="true" SuppressPostBack="True" Enabled="True">
         </cc1:CollapsiblePanelExtender>--%>
         <asp:Panel ID="Pnlsms" runat="server" Width="100%">
         <div class="hpltop">
         <img class="imgtop" src="images/pm.png" />
         <asp:Label ID="lblpms" CssClass="lbltop" runat="server" Text="Tin nhắn cá nhân"></asp:Label> 
         </div>          
         </asp:Panel>
         <asp:Panel ID="PnlPMS" runat="server" Width="100%">
         <asp:LinkButton ID="btnwsms" CssClass="hplitem" runat="server" OnClick="btnwsms_Click" >Gửi tin nhắn</asp:LinkButton>
          <asp:LinkButton ID="btnnewsms" CssClass="hplitem" runat="server" OnClick="btnnewsms_Click">Tin nhắn đã nhận</asp:LinkButton>
          <asp:LinkButton ID="btntosms" CssClass="hplitem" runat="server" OnClick="btntosms_Click">Tin nhắn đã gửi</asp:LinkButton>
         </asp:Panel>          
     </div>
    <div class="menu_sms" style="padding-bottom:30px; margin-top:3px;">
         <%--<cc1:CollapsiblePanelExtender ID="cpeEM" runat="server" TargetControlID="PnlEMS" Enabled="True" CollapseControlID="Pnlem" CollapsedText="Hộp thư" ExpandControlID="Pnlem" ExpandedText="Hộp thư" TextLabelID="lblem" Collapsed="false" SuppressPostBack="True">
         </cc1:CollapsiblePanelExtender>--%>
         <asp:Panel ID="Pnlem" runat="server" Width="100%">
         <div class="hpltop">
         <img class="imgtop" src="images/em.png" />
         <asp:Label ID="lblem" CssClass="lbltop" runat="server" Text="Email"></asp:Label>
         </div>           
         </asp:Panel>
         <asp:Panel ID="PnlEMS" CssClass="pnlitem" runat="server" Width="100%">                
             <asp:LinkButton ID="lbtEm" CssClass="hplitem" runat="server" OnClick="lbtEm_Click">Gửi Email</asp:LinkButton>
             <asp:LinkButton ID="lbtEMS" CssClass="hplitem" runat="server" OnClick="lbtEMS_Click">Email đã gửi</asp:LinkButton>                 
         </asp:Panel>         
    </div>
</div>
<div id="content_right">   
  <%--<div id="newsms" style="text-align:center; margin-top:60px; margin-bottom:10px;" runat="server">
    <div class="sms_process">        
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">     
        <ProgressTemplate>
            <img style="" src="App_Themes/profile/loading.gif" />
        </ProgressTemplate>
        </asp:UpdateProgress>      
   </div>  
  </div>--%>     
  <div class="styledtl"><uc1:tpms ID="TPms" runat="server" Visible="false"/>
  <uc2:fpms id="FPms" runat="server" Visible="false"/>  
  <uc3:pms ID="WPms" runat="server" Visible="false" />
  <uc4:temail ID="Temail" runat="server" Visible="false"/>
  <uc5:ems id="WEms" runat="server" Visible="false"/></div>
  <div class="ctfpm">
        <asp:Repeater ID="rptAds" runat="server">
            <ItemTemplate>
                <div class="r2pfe">
                    <div style="padding-bottom:7px"><a href='<%# Eval("Url") %>' class="rads3"><%# Eval("Title") %></a></div>
                    <div style="padding-bottom:7px"><a href='<%# Eval("Url") %>' class="rads2"><img src='ads/<%# Eval("Image") %>' class="bads"/></a></div>
                    <a href='<%# Eval("Url") %>' class="rads4"><%# Eval("BodyText") %></a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
  </div>