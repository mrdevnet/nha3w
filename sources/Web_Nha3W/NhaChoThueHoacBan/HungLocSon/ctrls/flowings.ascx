<%@ Control Language="C#" AutoEventWireup="true" CodeFile="flowings.ascx.cs" Inherits="ctrls_flowings" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
<script type="text/javascript">
    function chbg(a)
    {
        var c2 = document.getElementById(a);
        c2.className = "wls1ov";
    }
    function chbg2(a)
    {
        var c2 = document.getElementById(a);
        c2.className = "wls1";
    }
    
    function chbg3(a)
    {
        var c3 = document.getElementById(a);
        c3.className = "wls8";
        //c3.style.visibility = "hidden";
    }
    function chbg4(a)
    {
        var c3 = document.getElementById(a);
        c3.className = "modalbg";
        //c3.style.visibility = "visible";
    }
    
    function find4()
    {
        document.getElementById('sign').style.visibility = "visible";
        document.getElementById('sign').src = "images/prh.png";
    }
</script>
<div class="phwls"><img src="images/sp.gif" alt=""/></div>
<div class="wls1if" id="ifname" runat="server"></div>
<asp:UpdatePanel id="sig2" runat="server">
<ContentTemplate>
<asp:Repeater ID="flwings" runat="server" OnItemDataBound="flwings_ItemDataBound" OnItemCommand="flwings_ItemCommand">
    <ItemTemplate>
        <div class="wls1" id="icolor" runat="server">
            <div class="wlf0">
                <a href='<%#"profile.aspx?v=wall&m=" + Eval("ToMember")%>' class="wls3hr"><img class="wllimg21" src='<%# (Eval("Logo") != null && Eval("Logo").ToString() !="") ? "avas/thumbs/" + Eval("Logo") : "avas/thumbs/prof3w.png"%>'/></a>
            </div>
            <div class="wlf1" runat="server" id="cntflw"></div>
            <div class="wlf2">
                <div id="dscmd" runat="server" class="commandthis"></div>
                <div class="wlsimg9" runat="server" id="block2" visible="false"><asp:ImageButton ID="icrblk2" CommandName="cmdblk2" ToolTip='<%# "Bỏ khoá " + Eval("UserName") %>' CommandArgument='<%# Eval("ToMember") %>' Visible="true" runat="server" ImageUrl="../images/blk3.png" /></div>
                <div class="wlsimg9" runat="server" id="spam"><asp:ImageButton ID="icrspm" CommandName="cmdspam" ToolTip='<%# "Báo " + Eval("UserName") + " đã spam" %>' CommandArgument='<%# Eval("ToMember") %>' Visible="true" runat="server" ImageUrl="../images/spmic.png" /></div>
                <div class="wlsimg9" runat="server" id="block"><asp:ImageButton ID="icrblk" CommandName="cmdblk" ToolTip='<%# "Khoá " + Eval("UserName") %>' CommandArgument='<%# Eval("ToMember") %>' Visible="true" runat="server" ImageUrl="../images/blkic.png" /></div>
                <div class="wlsimg92" id="grps" runat="server"><img src="images/grpon15.png" /></div>
                <div class="wlsimg9" runat="server" id="unflw"><asp:ImageButton ID="icruflw" CommandName="cmduflw" ToolTip='<%# "Bỏ theo đuôi " + Eval("UserName") %>' CommandArgument='<%# Eval("ToMember") %>' Visible="true" runat="server" ImageUrl="../images/uflwic.png" /></div>
                <div class="wlsimg9" runat="server" id="flwi"><asp:ImageButton ID="icrflw" CommandName="cmdflw" ToolTip='<%# "Theo đuôi " + Eval("UserName") %>' CommandArgument='<%# Eval("ToMember") %>' Visible="true" runat="server" ImageUrl="../images/flwic.png" /></div>
            </div>
        </div>
        <ajaxToolkit:ModalPopupExtender PopupDragHandleControlID="Panel3" BackgroundCssClass="modalBackground" CancelControlID="CancelButton" TargetControlID="grps" PopupControlID="icolor2" ID="mpx" runat="server"></ajaxToolkit:ModalPopupExtender>
        <div class="wls8" id="icolor2" runat="server">
            <asp:Panel ID="Panel3" runat="server" CssClass="modalbg2">
                <div><img src="images/grpo.png" /> Chọn nhóm cho thành viên <b><%# Eval("UserName")%></b></div>
            </asp:Panel>
            <asp:CheckBoxList DataTextField="LstName" Visible="true" DataValueField="ListId" runat="server" ID="cblgrps" ></asp:CheckBoxList>
            <asp:Button OnClientClick="javascript:find4();" CssClass="artcbt" ID="OkButton" runat="server" Text="Chọn nhóm" CommandName="cmdgrp" CommandArgument='<%# Eval("ToMember") %>'/>
            <asp:Button CssClass="artcbt" ID="CancelButton"  runat="server" Text="Bỏ qua" /> <img id="sign" class="sli"/>
        </div>
    </ItemTemplate>
</asp:Repeater>
</ContentTemplate>
</asp:UpdatePanel>