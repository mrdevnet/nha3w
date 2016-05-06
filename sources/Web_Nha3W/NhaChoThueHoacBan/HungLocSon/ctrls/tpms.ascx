<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tpms.ascx.cs" Inherits="ctrls_tpms" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<link href="../App_Themes/pm.css" rel="stylesheet" type="text/css" />
<link href="../App_Themes/master_pm.css" rel="stylesheet" type="text/css" />--%>
<asp:DataList ID="dtlPMS" runat="server" Width="780px" OnItemCommand="dtlPMS_ItemCommand" DataKeyField="PmId" >
    <ItemTemplate>     
        <div class="sms_content"> 
            <div class="sms_item_ckb">
                <asp:CheckBox ID="ckbpm" runat="server" Enabled='<%#Eval("IsRead")%>' Checked='<%# !bool.Parse(Eval("IsRead").ToString()) %>' Width="25px" />
            </div> 
            <div class="sms_item_img">
            <a href='<%#Eval("FromMember","default.aspx?m={0}")%>'>
                <img class="sms_item_img" src='<%# (Eval("Logo") != null && Eval("Logo").ToString() !="") ? "avas/thumbs/" + Eval("Logo") : "avas/thumbs/prof3w.png"%>' />
                <%--src='<%# Eval("Logo","avas/thumbs/{0}")%>' />--%>
            </a>    
            </div> 
            <div class="sms_item_from">
                <asp:HyperLink ID="HyperLink1" runat="server" Width="100%"><%#Eval("FullName") %></asp:HyperLink>
                <span style="font-size:9px;"><%#HungLocSon.Tools.WebTools.FormatDateTime(DateTime.Parse(Eval("Sent").ToString()))%></span>
            </div>
            <div class="sms_item_container" >
            <cc1:CollapsiblePanelExtender ID="cpesms" runat="server" TargetControlID="PnlSMSDT" Collapsed="true" CollapseControlID="PnlSMS" CollapsedText="(Xem)" ExpandedText="(Đóng)" ExpandControlID="PnlSMS" TextLabelID="lblsms">
            </cc1:CollapsiblePanelExtender>
            <cc1:CollapsiblePanelExtender ID="cpesmssmr" runat="server" TargetControlID="PnlSMSsmr" CollapseControlID="PnlSMS" ExpandControlID="PnlSMS" TextLabelID="lblsms">
            </cc1:CollapsiblePanelExtender>
            <asp:Panel ID="PnlSMS" runat="server" Width="100%">
            <div>           
               <div class="sms_labell"><asp:LinkButton ID="btntl" runat="server" CommandName="btntl" CommandArgument='<%# Eval("PmId") %>'><%#Eval("Title")%></asp:LinkButton></div>            
               <div class="sms_labelr"><asp:LinkButton ID="lblsms" runat="server" CommandName="lblsms" CommandArgument='<%# Eval("PmId") %>'>()</asp:LinkButton></div>   
            </div> 
            <br/>                       
            <asp:Panel ID="PnlSMSsmr" runat="server">
               <div class="sms_item_sumary"><%#Eval("Message")%></div>
             </asp:Panel>                    
             </asp:Panel>                   
             <asp:Panel ID="PnlSMSDT" runat="server" Width="100%">            
                <span><%#Eval("Message")%></span> 
                <label class="label">Tiêu đề</label>
                <asp:TextBox ID="txtTitle" CssClass="textbox" runat="server" Width="500px"></asp:TextBox>
                <label class="label">Nội dung (Không quá 3000 ký tự)</label>
                 <asp:TextBox ID="txtMessage" CssClass="textbox" runat="server" Width="500px" TextMode="MultiLine" Height="80px"></asp:TextBox>
                 <asp:LinkButton ID="btnReply" CssClass="buttonss" runat="server" CommandArgument='<%# Eval("FromMember") %>' CommandName="btnReply">Trả lời</asp:LinkButton>
             </asp:Panel>    
            </div>
            <div>     
              <asp:LinkButton ID="btndelpm" runat="server" CssClass="sms_item_del" CommandArgument='<%#Eval("PmId")%>' CommandName="btndelpm">X</asp:LinkButton>              
            </div>
        </div>        
    </ItemTemplate>
    <ItemStyle Width="780px" />
    <HeaderTemplate>
    <div style="padding-left:10px"><h2>Tin nhắn đã nhận</h2></div>
    <div class="sms_menu">
    <asp:LinkButton ID="btnunread" CssClass="sms_btn" runat="server" CommandName="btnunread">Tin nhắn chưa đọc</asp:LinkButton>
    <asp:LinkButton ID="btndelsms" CssClass="sms_btn" runat="server" CommandName="btndelsms">Xóa tất cả</asp:LinkButton>
    </div>
    <div class="sms_menubt">    
    Chọn: 
        <asp:LinkButton ID="btnasl" runat="server" CommandName="btnasl">Tất cả</asp:LinkButton>,
        <asp:LinkButton ID="btnarsl" runat="server" CommandName="btnarsl">Đã đọc</asp:LinkButton> 
    </div>
    <div class="sms_process">        
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">     
        <ProgressTemplate>
            <img style="" src="../App_Themes/profile/loading.gif" />
        </ProgressTemplate>
        </asp:UpdateProgress>      
   </div>     
     </HeaderTemplate>
    <SelectedItemStyle BackColor="#E0E0E0" />
</asp:DataList>