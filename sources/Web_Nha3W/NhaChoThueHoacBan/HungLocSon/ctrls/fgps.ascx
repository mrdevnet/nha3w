<%@ Control Language="C#" AutoEventWireup="true" CodeFile="fgps.ascx.cs" Inherits="ctrls_fgps" %>
<div class="phwls"><img src="images/sp.gif" alt=""/></div>
<div class="wls1if" id="ifname" runat="server"></div> 
<div class="wlsgrpo" id="gpf" onmouseout="chbgb1('gpf');" onmouseover="chbgb2('gpf');" onclick="clalcmt2('ctl00_cphc_Fgps1_grpv');"><img src='images/grpo.png'/> Tạo nhóm</div>
<script type="text/javascript" language="javascript">
    function clalcmt2(a)
        {
            var c = document.getElementById(a);
            if (c.className == "wls8") c.className = "wls8cal";
            else c.className = "wls8";
        }
    function chbg(a)
    {
        var c2 = document.getElementById(a);
        c2.className = "wls1ov";
    }
    function chbgb2(a)
    {
        var c2 = document.getElementById(a);
        c2.className = "wlsgrpo2";
    }
    function chbg2(a)
    {
        var c2 = document.getElementById(a);
        c2.className = "wls1";
    }
    function chbgb1(a)
    {
        var c2 = document.getElementById(a);
        c2.className = "wlsgrpo";
    }
    function chbgb3(a)
    {
        var c2 = document.getElementById(a);
        c2.className = "wlstb2";
    }
    function chbgb3ov(a)
    {
        var c2 = document.getElementById(a);
        c2.className = "wlstb2ov";
    }
</script>
<asp:UpdatePanel id="sig2" runat="server">
<ContentTemplate>
<span id="grpv" class="wls8" runat="server">
<div class="wls1">
    <div class="wls33f">
    <div class="wls23">Tên nhóm:</div>
    <div class="wls33"><input class="gptt2" type="text" id="name" runat="server"/></div></div>
    <div class="wls33f">
    <div class="wls23">Giới thiệu:</div>
    <div class="wls33"><textarea class="gptt3" rows="3" id="desc" runat="server"></textarea></div></div>
    <div class="wls33f">
    <div class="wls23">Riêng tư:</div>
    <div class="wls33">
        <asp:RadioButton ID="pb" Text="Công cộng" runat="server" Checked="true" GroupName="private"/> 
        <asp:RadioButton ID="pr" Text="Cá nhân" runat="server" Checked="false" GroupName="private"/>
    </div></div>
    <div class="wls33f">
    <div class="wls23"><img src="images/sp.gif" alt=""/></div>
    <div class="wls33"><input type="submit" id="submit" runat="server" class="artcbt" value="Tạo nhóm" onserverclick="submit_ServerClick"/></div>
    </div>
</div>
<div class="wls1">
    <asp:GridView ID="lstgrps" Width="100%" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="ListId" BorderWidth="0px" RowStyle-BorderColor="#EEEEEE" GridLines="Horizontal" CellPadding="2" OnSelectedIndexChanged="lstgrps_SelectedIndexChanged" OnRowCommand="lstgrps_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Nhóm">
                <ItemTemplate>
                    <asp:Label CssClass="gltx" ID="lblname" runat="server" Text='<%# Eval("LstName") %>'></asp:Label> 
                    <img src='<%# bool.Parse(Eval("Prive").ToString()) == true ? "images/sp.gif" : "images/serc2.png" %>' />
                </ItemTemplate>
                <HeaderStyle Height="25px" CssClass="mnglgrps2" HorizontalAlign="left" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" CssClass="mnglgrps" HorizontalAlign="left" VerticalAlign="Top" Width="40%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mô tả">
                <ItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbldesc" runat="server" Text='<%# Eval("LstDesc") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" CssClass="mnglgrps2" HorizontalAlign="left" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" CssClass="mnglgrps" HorizontalAlign="left" VerticalAlign="Top" Width="40%" />
            </asp:TemplateField>
            <asp:CommandField ShowSelectButton="True" SelectText="Chỉnh sửa">
                <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" Width="10%" HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:CommandField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ToolTip="Xoá" OnClientClick="javascript:return confirm('Bạn muốn xoá nhóm này phải không ?');" ID="delg" CommandName="delgs" CommandArgument='<%# Eval("ListId") %>' ImageUrl='../images/delg4.png' runat="server"/>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="White" BackColor="#3B5998" />
        <RowStyle BorderColor="#EEEEEE" />
        <SelectedRowStyle BackColor="#eceff5" />
    </asp:GridView>
</div>
</span>
<div class="wls1tb">
    <a runat="server" id="tb1"><div class="wlstb1" id="tab1" runat="server"></div></a>
    <a runat="server" id="tb2"><div class="wlstb2" id="tab2" runat="server"></div></a>
</div>
<asp:Repeater ID="flwings" runat="server" OnItemDataBound="flwings_ItemDataBound">
    <ItemTemplate>
        <div class="wls1" id="icolor" runat="server">
            <div class="wlft0">
                <a href='<%#"profile.aspx?v=wall&m=" + Eval("MemberId")%>' class="wls3hr"><img class="ifwnimg" src='<%# "avas/thumbs/" + Eval("Logo")%>'/></a>
            </div>
            <div class="wlft1" runat="server" id="cntflw"></div>
            <div class="wlft2" runat="server" id="cntflw2">
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
</ContentTemplate>
</asp:UpdatePanel>