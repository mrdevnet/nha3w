<%@ Control Language="C#" AutoEventWireup="true" CodeFile="nwall.ascx.cs" Inherits="ctrls_nwall" %>
<asp:UpdatePanel id="sig" runat="server">
<ContentTemplate>
<div class="nwllt" id="n3wa" runat="server">
    <div class="nwall">
        <textarea class="nwtxtr" id="nwall" onkeydown="textCounter('ctl00_cphc_Nwall1_nwall','cntw',420);" onkeyup="textCounter('ctl00_cphc_Nwall1_nwall','cntw',420);" runat="server" onfocus="if (this.value=='Hôm nay, Bạn có gì mới ?') this.value='';" onblur="if (this.value=='') this.value='Hôm nay, Bạn có gì mới ?';">Hôm nay, Bạn có gì mới ?</textarea>
    </div>
    <div class="nwsta"><span id="staid" runat="server"></span></div>
    <div class="nwbts"><asp:Button CssClass="nwbtc" ID="signu" runat="server" Text="Chia sẻ" OnClick="signu_Click"/></div>
    <div class="nwbts" id="cnthd"><input class="wlsctbt" title="Số ký tự cho phép gửi" type="text" readonly="readonly" value="420" id="cntw" /></div>
    <div class="nwcnthd" id="cnthd2">
        <img id="sign" class="sli"/>
    </div>
    <script type="text/javascript">
        function find2()
        {
            var ict = document.getElementById('cnthd');
            var ict2 = document.getElementById('cnthd2');
            var i2 = document.getElementById('ctl00_cphc_Nwall1_nwall');
            i2.className = "nwtxtr2";
            var i = document.getElementById('ctl00_cphc_Nwall1_nwall').value;
            if (i == 'Hôm nay, Bạn có gì mới ?') 
            {
                i2.className = "nwtxtr3";
                return false;
            }
            var lth = i.length;
            if (lth > 420)
            {
                alert('Bài viết của bạn có ' + lth + ' ký tự. Chỉ có 420 ký tự được cho phép trong mỗi bài viết. Vui lòng xoá bớt một số ký tự khác.');
                //document.getElementById('ctl00_cphc_Nwall1_nwall').focus();
                i2.className = "nwtxtr";
                return false;
            }
            else
            {
                ict.className = "nwcnthd";
                ict2.className = "nwbts";
                document.getElementById('sign').style.visibility = "visible";
                document.getElementById('sign').src = "images/prh.png";
            }
        }
        function find3(a,c,e,g)
        {
            var i = document.getElementById(c).value;
            var f = document.getElementById(e);
            var q = document.getElementById(g);
            if (i.length > 420)
            {
                document.getElementById(a).style.visibility = "visible";
                document.getElementById(a).src = "images/prh.png";
                alert('Bài viết của bạn có ' + i.length + ' ký tự. Chỉ có 420 ký tự được cho phép trong mỗi bài viết. Vui lòng xoá bớt một số ký tự khác.');
                return false;
            }
            else
            {
                f.className = "nwbts3";
                q.className = "wls7";
                document.getElementById(a).style.visibility = "visible";
                document.getElementById(a).src = "images/prh.png";
            }
        }
        function salcs(a)
        {
            document.getElementById(a).style.visibility = "visible";
            document.getElementById(a).src = "images/prh.png";
        }
        function clalcmt(a,b)
        {
            var c = document.getElementById(a);
            var f = document.getElementById(b);
            c.style.visibility = "visible";
            f.style.visibility = "hidden";
    //            if (c.className == "wls8") c.className = "wls8cal";
    //            if (f.className == "wls8cal") f.className = "wls8";
        }
        
        function textCounter(field, countfield, maxlimit)
        {
            var c1 = document.getElementById(field);
            var c2 = document.getElementById(countfield);
            //var c3 = document.getElementById(maxlimit);
            if (c1.value.length > maxlimit)
                {c1.value = c1.value.substring(0, maxlimit);}
            else{c2.value = maxlimit - c1.value.length;}
        }
        function textchs(a)
        {
            var c1 = document.getElementById(a);
            if (c1.value.length > 0)
            {
                //c1.onblur = textchs2('a');
                //c1.attachEvent("onblur", textchs2('a'));
            }
        }
        function textchs2(b)
        {
            var c2 = document.getElementById(b);
            if (c2.value=='') c2.value='Viết bình luận...';
        }
        elasticTextArea("ctl00_cphc_Nwall1_nwall");
        function crdp()
        {
            return confirm('Bạn muốn xoá tin đăng này phải không?');
        }
        function crsp()
        {
            return confirm('Bạn muốn chia sẻ tin này cùng mọi người?');
        }
        function osclr(a)
        {
            var c1 = document.getElementById(a);
            c1.className = "wls6ov";
        }
        function ovclr(b)
        {
            var c2 = document.getElementById(b);
            c2.className = "wls6";
        }
        function osclr2(a)
        {
            var c1 = document.getElementById(a);
            c1.className = "wls6cov";
        }
        function ovclr2(b)
        {
            var c2 = document.getElementById(b);
            c2.className = "wls6c";
        }
        function chart(b,c)
        {
            var c2 = document.getElementById(b);
            var c3 = document.getElementById(c);
            c2.className = "clrcmt2";
            c3.className = "clrcmt3";
        }
        function chart2(b,c)
        {
            var c2 = document.getElementById(b);
            var c3 = document.getElementById(c);
            c2.className = "clrcmt";
            c3.className = "clrcmt4";
            if ((c2.value != "Viết bình luận...") && (c2.value.length > 0))  
            {
                c2.className = "clrcmt2";
                c3.className = "clrcmt3";
            }
        }
        function shwcmt(b,c)
        {
            var c2 = document.getElementById(b);
            c2.className = "wls7";
            var c4 = document.getElementById(c);
            c4.className = "wls4fr";
        }
        function ovfmr(a)
        {
            var c1 = document.getElementById(a);
            c1.className = "fpg3g2";
        }
        function oufmr(b)
        {
            var c2 = document.getElementById(b);
            c2.className = "fpg3g";
        }
    </script>
</div>
<div class="wls1ifg1" id="ifname" runat="server"></div>
<div class="wls1ifg2" runat="server" id="tgo2"><asp:Button CssClass="btfgp2" ID="iflwt" OnClick="iflwt_Click" runat="server" Text="Theo nhóm này"/></div>
<div class="phwlsgp" runat="server" id="tgo"><img src="images/sp.gif" alt=""/></div>
<asp:Repeater ID="rptClrs" runat="server" OnItemDataBound="rptClrs_ItemDataBound" OnItemCommand="rptClrs_ItemCommand">
    <ItemTemplate>
        <div class="wls1" id="icolor" runat="server">
            <div class="wls2">
                <a href='<%#"profile.aspx?v=wall&m=" + Eval("Author")%>' class="wls3hr"><img class="wllimg21" src='<%# (Eval("Logo") != null && Eval("Logo").ToString() !="") ? "avas/thumbs/" + Eval("Logo") : "avas/thumbs/prof3w.png"%>'/></a>
            </div>
            <div class="wls3">
                <div class="wls4">
                    <img runat="server" class="wls4irt" id="irt" src='<%# int.Parse(Eval("N3w").ToString()) == 0 ? "" : "../images/crt5.png"%>' /><a href='<%#"profile.aspx?v=wall&m=" + Eval("Author")%>' class="wls3hr"><%# Eval("AutName")%></a>
                    <span id="wclr"><%# (Eval("Author").ToString() != Eval("MemberId").ToString()) ? "<img src=\"images/nxt.png\" class=\"wlsimg6\"/> <a href=\"profile.aspx?v=wall&m=" + Eval("MemberId") + "\" class=\"wls3hr\">" + HungLocSon.BHLS.BMember.PMemberU(int.Parse(Eval("MemberId").ToString())) + "</a> " + Eval("Colors") : Eval("Colors")%></span>
                </div>
                <div class="wls6ov" id="iclrr" runat="server"><asp:ImageButton ToolTip="Xoá" CommandName="crdp" CommandArgument='<%# Eval("ColorId") %>' Visible="true" runat="server" ID="icrdp" ImageUrl="../images/cdp.png" /></div>
                <div class="wls5">
                    <span id="wclrd">
                        <%# ltsDate(DateTime.Parse(Eval("CrDate").ToString()))%> qua <%# Eval("Via").ToString().ToLower()%> <span class="wls5dnt">.</span> 
                        <a href="javascript:void(0);" id="swcmt" runat="server" class="wls4re">Bình luận</a> <span class="wls5dnt">.</span> 
                        <asp:linkbutton CssClass="wls4re" CommandName="crfp" CommandArgument='<%# Eval("ColorId") %>' Visible="true" runat="server" id="icrfp">Thích</asp:linkbutton> <span class="wls5dnt">.</span> 
                        <asp:linkbutton CssClass="wls4re" CommandName="crsp" CommandArgument='<%# Eval("ColorId") %>' Visible="true" runat="server" id="icrsp">Chia sẻ</asp:linkbutton>
                    </span>
                </div>
                <div id="nw3wll" class="wls5" runat="server" visible="false">
                    <img src="images/rtp2.png" class="wlsimg6" alt=""/> <span id="wclrr" runat="server"></span>
                </div>
                <div class="wls8" id="topbgw" runat="server"><img src="images/sp.gif" alt=""/></div>
                <div id="n3wwf" class="wls72c" runat="server" visible="false">
                    <img src="images/likeit.png" class="wlsimg6" alt=""/> <span id="wclfp" runat="server"></span>
                </div>
                <div id="cmtal" class="wls72c" runat="server" visible="false">
                    <img class="wlsimg6" src="images/alcmt.png"/> <asp:linkbutton CssClass="wls4re" CommandName="swall" CommandArgument='<%# Eval("ColorId") %>' Visible="false" runat="server" id="swallid">Xem tất cả <%# HungLocSon.BHLS.BColors.F2c(int.Parse(Eval("ColorId").ToString())) %> bình luận</asp:linkbutton> 
                    <div class="sacmts"><img id="sign" runat="server"/></div>
                    <input id="hashs" runat="server" value="-1" type="hidden" />
                </div>
                <asp:Repeater ID="rpticmnts" runat="server" OnItemCommand="rpticmnts_ItemCommand" OnItemDataBound="rpticmnts_ItemDataBound">
                    <ItemTemplate>
                        <div id="icmnts" class="wls72c" runat="server">
                            <div class="wls2f">
                                <a href='<%#"profile.aspx?v=wall&m=" + Eval("Author")%>' class="wls3hr"><img class="wlsimg4" src='<%# (Eval("Logo") != null && Eval("Logo").ToString() !="") ? "avas/thumbs/" + Eval("Logo") : "avas/thumbs/prof3w.png"%>'/></a>
                            </div>
                            <div class="wls3f">
                                <div class="wls4">
                                    <a href='<%#"profile.aspx?v=wall&m=" + Eval("Author")%>' class="wls4re2f"><%# Eval("AutName")%></a><span class="pad52"><%# Eval("Colors")%></span>
                                </div>
                                <div class="wls5">
                                    <%# ltsDate(DateTime.Parse(Eval("CrDate").ToString()))%> qua <%# Eval("Via").ToString().ToLower()%>
                                </div>
                                <div class="wls6cov" id="iclrr3" runat="server"><asp:ImageButton ToolTip="Xoá" CommandName="crdpc" CommandArgument='<%# Eval("CommentId") %>' Visible="true" runat="server" ID="icrdpc2" ImageUrl="../images/cdp.png" /></div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div id="n3wcmt" class="wls8" runat="server">
                    <textarea class="clrcmt" id="clrcmt" runat="server">Viết bình luận...</textarea>
                    <div class="clrcmt4" id="cmtbtns" runat="server"><asp:Button CssClass="artcbt" ID="icmts" runat="server" Text="Bình luận"/></div>
                    <div class="nwcnthd" id="signpn" runat="server">
                        <img id="sign2" runat="server" class="sli"/>
                    </div>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
<div runat="server" class="fpg3g" id="pgdv" onmouseover="ovfmr('ctl00_cphc_Nwall1_pgdv');" onmouseout="oufmr('ctl00_cphc_Nwall1_pgdv');">
    <asp:LinkButton CssClass="wls4re" ID="pg" runat="server" Text="Xem thêm" OnClientClick="salcs('sgnpg');" OnClick="pg_Click"></asp:LinkButton>
    <img id="sgnpg" class="sli"/>
    <input type="hidden" id="cntfm" runat="server" value="1"/>
</div>
<div class="phwlsgp"><img src="images/sp.gif" alt=""/></div>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="signu" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>