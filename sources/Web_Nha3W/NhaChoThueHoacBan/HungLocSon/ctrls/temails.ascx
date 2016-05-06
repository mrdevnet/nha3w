<%@ Control Language="C#" AutoEventWireup="true" CodeFile="temails.ascx.cs" Inherits="ctrls_temails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:DataList ID="dtlPMS" runat="server" Width="780px" DataKeyField="MailId" OnItemCommand="dtlPMS_ItemCommand" >
<ItemTemplate>
    <div class="sms_content">
        <div class="sms_item_img" style="margin-left:5px;">
            <a href='<%#Eval("ToMember","default.aspx?m={0}")%>'>
                <img class="sms_item_img" src='<%# (Eval("Logo") != null && Eval("Logo").ToString() !="") ? "avas/thumbs/" + Eval("Logo") : "avas/thumbs/prof3w.png"%>' />
                <%--<img class="sms_item_img" src='<%#Eval("Logo","avas/thumbs/{0}")%>' />--%>
            </a>
        </div>
        <div class="sms_item_from">
            <asp:HyperLink ID="HyperLink1" runat="server" Width="100%"><%#Eval("FullName") %></asp:HyperLink>
                <span style="font-size:9px;"><%#HungLocSon.Tools.WebTools.FormatDateTime(DateTime.Parse(Eval("CreationDate").ToString())) %></span>
            </div>
            <div class="sms_item_container">
                <cc1:CollapsiblePanelExtender ID="cpesms" runat="server" TargetControlID="PnlSMSDT" Collapsed="true" CollapseControlID="PnlSMS" CollapsedText="(Xem)" ExpandedText="(Đóng)" ExpandControlID="PnlSMS" TextLabelID="lblsms"></cc1:CollapsiblePanelExtender>
                <cc1:CollapsiblePanelExtender ID="cpesmssmr" runat="server" TargetControlID="PnlSMSsmr" CollapseControlID="PnlSMS" ExpandControlID="PnlSMS" TextLabelID="lblsms"></cc1:CollapsiblePanelExtender>
            <asp:Panel ID="PnlSMS" runat="server" Width="100%">
            <div>
                <div class="sms_labell"><asp:LinkButton ID="btntl" runat="server" CommandName="btntl" CommandArgument='<%# Eval("MailId") %>'><%#Eval("Title")%></asp:LinkButton></div>
                <div class="sms_labelr"><asp:LinkButton ID="lblsms" runat="server" CommandName="lblsms" CommandArgument='<%# Eval("MailId") %>'>()</asp:LinkButton></div>
            </div><br/>
            <asp:Panel ID="PnlSMSsmr" runat="server">
                <div class="sms_item_sumary"><%#Eval("Message")%></div>
            </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="PnlSMSDT" runat="server" Width="100%">
                <span><%#Eval("Message")%></span>
            </asp:Panel>
            </div>
            <div>
                <asp:LinkButton ID="btndelem" runat="server" CssClass="sms_item_del" CommandArgument='<%#Eval("MailId")%>' CommandName="btndelem">x</asp:LinkButton>
            </div>
        </div>
    </ItemTemplate>
    <ItemStyle Width="780px" />
    <HeaderTemplate>
        <div style="padding-left:10px;"><h2>Email đã gửi</h2></div>
        <div class="sms_menu">
            <asp:LinkButton ID="btnwem" CssClass="sms_btn" runat="server" CommandName="btnwem">Gửi Email</asp:LinkButton>
            <asp:LinkButton ID="btndelems" CssClass="sms_btn" runat="server" CommandName="btndelems">Xóa tất cả</asp:LinkButton>
        </div>
        <div class="sms_process" style="margin-top:5px;">
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate><img style="" src="App_Themes/profile/loading.gif" /></ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </HeaderTemplate>
    <SelectedItemStyle BackColor="#E0E0E0" />
</asp:DataList>