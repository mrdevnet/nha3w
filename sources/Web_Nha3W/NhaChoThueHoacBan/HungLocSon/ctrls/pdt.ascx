<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pdt.ascx.cs" Inherits="ctrls_pdt" %>
<%--<div class="ph1"><img src="images/sp.gif" alt=""/></div>--%>
<div class="iahere" id="stay" runat="server"></div>
<div class="ph1dtp"><img src="images/sp.gif" alt=""/></div>
<div class="tdt" runat="server" id="hls1"></div>
<div class="vlg" runat="server" id="hls2" visible="false"><img class="vg2" src="images/vip1.png"/></div>
<div class="vlg" runat="server" id="hls2s" visible="false"><img class="vg3" src="images/silvers7.png"/></div>
<div class="sid" >
    <div class="imd">
        <div class="idt2" id="a">
            <img id="ihs" runat="server" src="pros/villav.jpg" class="idt0"/>
            <div class="tplnk">Lưu trữ tại nha3w.com</div>
            <div class="ilisth" id="imgs">
                <asp:Repeater ID="rhs" runat="server">
                    <ItemTemplate>
                        <a onclick="javascript:void(selectH('<%# Eval("Images") %>'));return false;" class="selectH" href="">
                            <img border="0" id="i1" runat="server" src='<%# "../pros/" + DateTime.Parse(Eval("CreationDate").ToString()).Year.ToString()+ "/" + DateTime.Parse(Eval("CreationDate").ToString()).Month.ToString()+ "/" + Eval("PostId").ToString() +"/thumbs/" + Eval("Images") %>' class="ilh"/>
                        </a> 
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="idt3" id="b">
            <img runat="server" id="map" />
            <input type="hidden" id="maph1" runat="server" />
            <input type="hidden" id="maph2" runat="server" />
            <div class="zin"><a onclick="javascript:zoomin('ctl00_cphc_Pdt1_map');return false;" href="" title="Phóng to"><img src="images/zoomin.jpeg" class="ci"/></a></div>
            <div class="zou"><a onclick="javascript:zoomout('ctl00_cphc_Pdt1_map');return false;" href="" title="Thu nhỏ"><img src="images/zoomout.jpeg" class="ci"/></a></div>
        </div>
        <a onclick="javascript:Active_Map('a','b','ta1');return false;" href="" class="gmap"><div class="itl" id="ta1"><img alt="Hình ảnh" src="images/ico_mayanh.gif" class="ci"/> HÌNH ẢNH</div></a>
        <a onclick="javascript:Active_Map('b','a','ta2');return false;" href="" class="gmap"><div class="itr" id="ta2"><img alt="Bản đồ" src="images/ico_m.gif" class="ci"/> BẢN ĐỒ</div></a>
    </div>
    <div class="isd">
        <div class="lic" ><img src="images/ico_canban.gif" runat="server" id="hls3"/></div>
        <div class="ric" ><div class="tdt3">Mã số :</div><div class="tdt4" runat="server" id="hls4"></div></div>
        <div class="tdt2" runat="server" id="hls5"></div>
        <div class="vdt0">
            <div class="vdt2">
                <a id="v1" onclick="javascript:changev('v1','s1','u1','vnd');return false;" runat="server" href="~/#" class="vus">VND</a> 
                <a id="s1" onclick="javascript:changev('s1','v1','u1','sjc');return false;" runat="server" href="~/#" class="vus">SJC</a> 
                <a id="u1" onclick="javascript:changev('u1','s1','v1','usd');return false;" runat="server" href="~/#" class="vus">USD</a>
            </div><div class="vdtv"><img src="images/sp.gif" alt=""/></div>
            <div class="vdtu" id="vnd" runat="server"><span runat="server" id="hls6"></span></div>
            <div class="vdtu" id="sjc" runat="server"><span runat="server" id="hls7"></span></div>
            <div class="vdtu" id="usd" runat="server"><span runat="server" id="hls8"></span></div>
        </div>
        <div class="uti">
            <span class="sitt" title="Phòng Khách" id="stt" runat="server">-</span>
            <span class="bed" title="Phòng Ngủ" id="bed" runat="server">-</span>
            <span class="bath" title="Phòng Tắm / WC" id="bat" runat="server">-</span>
            <span class="othr" title="Phòng Khác" id="oth" runat="server">-</span>
        </div>
        <div class="are">Diện tích khuôn viên: <strong><span id="wi" runat="server"></span></strong></div>
        <div class="are">Diện tích sử dụng: <strong><span id="are" runat="server"></span><sup>2</sup></strong></div>
        <div class="cont">
            <div class="c1">LIÊN HỆ</div>
            <div class="c2"><img src="images/ico_user.gif" class="ci"/>&nbsp;<span id="cname" runat="server"></span></div>
            <div class="c3"><img runat="server" id="iphonew" src="../images/ico_phone.gif" class="ci"/>&nbsp;<span id="cph" runat="server"></span></div>
            <div class="c4"><img runat="server" id="imobilew" src="../images/ico_dd.gif" class="ci2"/>&nbsp;<span id="cmb" runat="server"></span></div>
            <div class="c5"><img runat="server" id="iaddw" src="../images/ico_add.gif" class="ci"/>&nbsp;<span id="ca" runat="server"></span></div>
            <div class="c6"><img runat="server" id="inotew" src="../images/ico_note.gif" class="ci"/>&nbsp;<span id="cnt" runat="server"></span></div>
        </div>
    </div>
    <div class="indt">
    <div class="ind2">Thông tin chi tiết</div>
    <div class="ind3" runat="server" id="hls9"></div>
    <div class="ind4">
        CẤU TRÚC VÀ TIỆN ÍCH
    </div>
    <div class="ind5">
        <div class="i51">Tổng diện tích sử dụng: <strong><span id="are2" runat="server"></span> m<sup>2</sup></strong></div>
        <div class="i52"><strong>Diện tích khuôn viên</strong></div>
        <div class="i53">Chiều ngang : <strong><span id="wi2" runat="server"></span> m</strong></div>
        <div class="i54">Chiều dài : <strong><span id="le2" runat="server"></span> m</strong></div>
    </div>
    <div class="ind6">
        <div class="i51">Loại địa ốc: <strong><span id="hls10" runat="server"></span></strong></div>
        <div class="i52">Pháp lý: <strong><span id="hls11" runat="server"></span></strong></div>
        <div class="i51">Hướng: <strong><span id="hls12" runat="server"></span></strong></div>
        <div class="i52">Đường trước nhà: <strong><span id="hls13" runat="server"></span> m</strong></div>
        <div class="i51">Vị trí điạ ốc: <strong><span id="hls14" runat="server"></span></strong></div>
        <div class="i54">Số lầu: <strong><span id="hls15" runat="server"></span></strong></div>
        <div class="i53">Phòng khách: <strong><span id="hls16" runat="server"></span></strong></div>
        <div class="i54">Phòng ngủ: <strong><span id="hls17" runat="server"></span></strong></div>
        <div class="i53">Phòng tắm / WC: <strong><span id="hls18" runat="server"></span></strong></div>
        <div class="i54">Phòng khác: <strong><span id="hls19" runat="server"></span></strong></div>
    </div>
    <div class="ind7">
        <div class="i51">Đầy đủ tiện nghi <img visible="false" id="hls20" runat="server" src="../images/ico_check.gif" class="ci"/></div>
        <div class="i52">Chỗ đậu xe hơi <img visible="false" id="hls21" runat="server" src="../images/ico_check.gif" class="ci"/></div>
        <div class="i51">Sân vườn <img visible="false" id="hls22" runat="server" src="../images/ico_check.gif" class="ci"/></div>
        <div class="i52">Hồ bơi <img visible="false" id="hls23" runat="server" src="../images/ico_check.gif" class="ci"/></div>
        <div class="i53">Tiện kinh doanh <img visible="false" id="hls24" runat="server" src="../images/ico_check.gif" class="ci"/></div>
        <div class="i54">Tiện để ở <img visible="false" id="hls25" runat="server" src="../images/ico_check.gif" class="ci"/></div>
        <div class="i53">Tiện làm văn phòng <img visible="false" id="hls26" runat="server" src="../images/ico_check.gif" class="ci"/></div>
        <div class="i54">Tiện cho sản xuất <img visible="false" id="hls27" runat="server" src="../images/ico_check.gif" class="ci"/></div>
        <div class="i53">Cho sinh viên thuê <img visible="false" id="hls28" runat="server" src="../images/ico_check.gif" class="ci"/></div>
    </div>
    </div>
    <div class="snd">
        <%--<div class="sd2"><img src="images/cmt.png" class="ci"/> <a href="#" class="r4l">Bình luận</a></div>--%>
        <asp:UpdatePanel id="n3ws" runat="server">
            <ContentTemplate>
                <div class="sd5" id="n3wsave" runat="server"><img src="images/svp2.png" class="ci" style="margin-bottom : -5px"/> 
                    <asp:LinkButton ID="pn" runat="server" CssClass="r4l" OnClick="pn_Click">Lưu tin</asp:LinkButton>
                    <%--<a href="#" class="r4l">Lưu tin</a>  OnClick='<%# Saved() %>'--%>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="n3wpm2" runat="server">
            <div id="pms" class="shwft2"><img src="images/pm.png" class="ci" style="margin-bottom : -5px"/> <a href="#" class="r4l" onclick="swft('swpm','pms','pmh');return false;">Tin nhắn</a></div> 
            <div id="pmh" class="hdwft"><img src="images/pm.png" class="ci" style="margin-bottom : -5px"/> <a href="#" class="r4l" onclick="hdft('swpm','pmh','pms');return false;">Tin nhắn</a></div>
        </div>
        <div id="n3wem2" runat="server">
            <div id="ems" class="shwft2"><img src="images/em.png" class="ci" style="margin-bottom : -5px"/> <a href="#" class="r4l" onclick="swft('swem','ems','emh');return false;">Gửi email</a></div>
            <div id="emh" class="hdwft"><img src="images/em.png" class="ci" style="margin-bottom : -5px"/> <a href="#" class="r4l" onclick="hdft('swem','emh','ems');return false;">Gửi email</a></div>
        </div>
        <div class="sd5"><img src="images/share2.png" class="ci"/> 
            <!-- ADDTHIS BUTTON BEGIN -->
            <script type="text/javascript">
                addthis_pub             = 'nha3W.com';
                addthis_logo            = '';
                addthis_logo_background = 'EFEFFF';
                addthis_logo_color      = '666699';
                addthis_brand           = 'Nha3W.com';
                addthis_options         = 'favorites, email, digg, delicious, myspace, facebook, google, live, more';
            </script>
            <a class="r4l" href="#" onmouseover="return addthis_open(this, '', '<%=Request.Url.ToString()  %>', '<%= hls5.InnerText.ToString() %>')" onmouseout="addthis_close()" onclick="return addthis_sendto()">Chia sẻ</a>
            <script type="text/javascript" src="java/addthis.js"></script>
            <!-- ADDTHIS BUTTON END -->
            <%--<a href="#" class="r4l">Chia sẻ</a>--%>
        </div>
        <div class="sd5"><img src="images/print.jpeg" class="ci"/> <a onclick="javascript:window.print();return false;" href="" class="r4l">Bản in</a></div>
        <asp:UpdatePanel id="upc" runat="server">
            <ContentTemplate>
                <div class="sd4" id="n3wfns" runat="server"><img src="images/calling.png" class="ci"/> 
                    <%--<a href="#" class="r4l">Đã bán</a>--%>
                    <asp:LinkButton OnClientClick="javascript:alert('Cảm ơn bạn đã thông báo thông tin này đến với chúng tôi!');" ID="ps" runat="server" CssClass="r4l" OnClick="ps_Click">Báo đã bán</asp:LinkButton>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="n3wcals" runat="server"><%-- class="sd4" <img src="images/alert.png" class="ci"/> --%> 
            <%--<a href="#" class="r4l">Vi phạm</a>--%>
            <div id="vios" class="shwft2"><img src="images/alert.png" class="ci"/> <a href="#" class="r4l" onclick="swft('swvi','vios','vioh');return false;">Vi phạm</a></div> 
            <div id="vioh" class="hdwft"><img src="images/alert.png" class="ci"/> <a href="#" class="r4l" onclick="hdft('swvi','vioh','vios');return false;">Vi phạm</a></div>
            <%--<asp:LinkButton OnClientClick="javascript:alert('Cảm ơn bạn đã thông báo thông tin này đến với chúng tôi!');" ID="pv" runat="server" CssClass="r4l" OnClick="pv_Click">Vi phạm</asp:LinkButton>--%>
        </div>
        <div class="sd3"><img src="images/back.png" class="ci"/> <a onclick="javascript:history.go(-1);return false;" href="" class="r4l">Quay Lại</a></div>
    </div>
    <div id="swpm" class="hdwft">
        <asp:UpdatePanel id="up1" runat="server">
            <ContentTemplate>
                <div class="cont3">
                    <div id="p1303" class="p130" >
                        <div class="p130s2">Tiêu đề:</div>
                    </div>
                    <div id="p2703" class="p270">
                        <div class="p270s2">
                            <div class="c1"><input style="width:398px" runat="server" type="text" class="fat" id="titlepm" /></div>
                        </div>
                    </div>
                    <div id="Div1" class="p130">
                        <div class="p130s2">Nội dung tin nhắn:</div>
                    </div>
                    <div id="Div2" class="p270">
                        <div class="p270s2">
                            <div class="c1">
                                <textarea rows="7" cols="20" style="width:398px" runat="server" class="fat" id="msgpm"></textarea>
                            </div>
                        </div>
                    </div>
                    <div id="Div3" class="p130">
                        <div class="p130s2"></div>
                    </div>
                    <div id="Div4" class="p270">
                        <div class="p270s2">
                            <div class="c1">
                                <asp:Button CssClass="lsp2" ID="btnpm" runat="server" Text="Gửi tin nhắn" OnClick="btnpm_Click" />&nbsp;
                                <asp:Literal ID="respm" runat="server"></asp:Literal>
                                <img id="sign" class="sli"/>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="swem" class="hdwft">
        <asp:UpdatePanel id="up2" runat="server">
            <ContentTemplate>
                <div class="cont3">
                    <div id="Div5" class="p130" >
                        <div class="p130s2">Tiêu đề:</div>
                    </div>
                    <div id="Div6" class="p270">
                        <div class="p270s2">
                            <div class="c1"><input style="width:398px" runat="server" type="text" class="fat" id="titleem" /></div>
                        </div>
                    </div>
                    <div id="Div7" class="p130">
                        <div class="p130s2">Nội dung Email:</div>
                    </div>
                    <div id="Div8" class="p270">
                        <div class="p270s2">
                            <div class="c1">
                                <textarea rows="7" cols="20" style="width:398px" runat="server" class="fat" id="msgem"></textarea>
                            </div>
                        </div>
                    </div>
                    <div id="Div9" class="p130">
                        <div class="p130s2"></div>
                    </div>
                    <div id="Div10" class="p270">
                        <div class="p270s2">
                            <div class="c1">
                                <asp:Button CssClass="lsp2" ID="btnem" runat="server" Text="Gửi Email" OnClick="btnem_Click" />
                                <asp:Literal ID="resem" runat="server"></asp:Literal>
                                <img id="sign2" class="sli"/>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div id="swvi" class="hdwft">
        <asp:UpdatePanel id="upv" runat="server">
            <ContentTemplate>
                <div class="cont3">
                    <div id="Div14" class="p130">
                        <div class="p130s2">Lý do vi phạm:</div>
                    </div>
                    <div id="Div15" class="p270">
                        <div class="p270s2">
                            <div class="c1">
                                <textarea rows="7" cols="20" style="width:398px" runat="server" class="fat" id="msgvio"></textarea>
                            </div>
                        </div>
                    </div>
                    <div id="Div16" class="p130">
                        <div class="p130s2"></div>
                    </div>
                    <div id="Div17" class="p270">
                        <div class="p270s2">
                            <div class="c1">
                                <asp:Button CssClass="lsp2" ID="btnvio" runat="server" Text="Gửi thông báo" OnClick="btnvio_Click" />&nbsp;
                                <asp:Literal ID="resvio" runat="server"></asp:Literal>
                                <img id="sign3" class="sli"/>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="cont2">
            <div class="c1">THÔNG TIN THÀNH VIÊN</div>
            <div class="mlg"><img style="width:50px" runat="server" id="iwnlg" class="ci" src="../prom/nha3wlgo.png"/></div>
            <div class="mif">
                <div class="c2" id="hls29" runat="server"></div>
                <div class="c5" id="hls30" runat="server"></div>
                <div class="c5" id="hlsadr" runat="server" style="float:left;width:80%"></div>
                <div class="cm1"><img src="images/ico_dd.gif" class="ci2"/>&nbsp;<span id="hls31" runat="server"></span></div>
            </div>
    </div>
    
    
</div>
<div class="snt"><img src="images/sp.gif" alt=""/><input type="hidden" id="ctlis" runat="server" /></div>

<script type="text/javascript">
    function find()
    {
        document.getElementById('sign').style.visibility = "visible";
        document.getElementById('sign').src = "images/prh.png";
    }
    
    function find2()
    {
        document.getElementById('sign2').style.visibility = "visible";
        document.getElementById('sign2').src = "images/prh.png";
    }
    
    function find3()
    {
        document.getElementById('sign3').style.visibility = "visible";
        document.getElementById('sign3').src = "images/prh.png";
    }

    function swft(a,b,c)
    {
        var v2 = document.getElementById(a);
        var v3 = document.getElementById(b);
        var v4 = document.getElementById(c);
        if (a == 'swpm') document.getElementById('swem').className = "hdwft";
        if (a == 'swem') document.getElementById('swpm').className = "hdwft";
        v2.className = "shwft";
        v3.className = "hdwft";
        v4.className = "shwft2";
    }
    
    function hdft(a,b,c)
    {
        var v2 = document.getElementById(a);
        var v3 = document.getElementById(b);
        var v4 = document.getElementById(c);
        v2.className = "hdwft";
        v3.className = "hdwft";
        v4.className = "shwft2";
    }

    function selectH(s)
    {
        var f1 = document.getElementById('ctl00_cphc_Pdt1_ctlis');
        document.aspnetForm["ctl00_cphc_Pdt1_ihs"].src = f1.value + "/" + s;
    }
    
    function changev(v,u,s,t)
    {
        v = "ctl00_cphc_Pdt1_" + v;
        u = "ctl00_cphc_Pdt1_" + u;
        s = "ctl00_cphc_Pdt1_" + s;
        t = "ctl00_cphc_Pdt1_" + t;
//        $("#" + v).removeClass('vus');
//        $("#" + v).addClass('vss');
        
        var v2 = document.getElementById(v);
        v2.className = "vss";
        var u2 = document.getElementById(u);
        u2.className = "vus";
        var s2 = document.getElementById(s);
        s2.className = "vus";
        
        var t2 = t;
        var t1 = document.getElementById(t);
        if (t2 == 'ctl00_cphc_Pdt1_vnd')
        {
            t1.className = "vdt";
            document.getElementById('ctl00_cphc_Pdt1_sjc').className = "vdtu";
            document.getElementById('ctl00_cphc_Pdt1_usd').className = "vdtu";
        }
        else if (t2 == 'ctl00_cphc_Pdt1_sjc')
        {
            t1.className = "vdt";
            document.getElementById('ctl00_cphc_Pdt1_vnd').className = "vdtu";
            document.getElementById('ctl00_cphc_Pdt1_usd').className = "vdtu";
        }
        else
        {
            t1.className = "vdt";
            document.getElementById('ctl00_cphc_Pdt1_vnd').className = "vdtu";
            document.getElementById('ctl00_cphc_Pdt1_sjc').className = "vdtu";
        }
    }
    
    function Active_Map(l,r,h)
    {
        var i1 = document.getElementById(l);
        i1.className = "idt2";
        var i2 = document.getElementById(r);
        i2.className = "idt3";
        if (h == 'ta1')
        {
            var tab = document.getElementById(h);
            tab.className = "itl";
            document.getElementById('ta2').className = "itr";
            document.getElementById('imgs').className = "ilisth";
        }
        else
        {
            var tab = document.getElementById(h);
            tab.className = "itl";
            document.getElementById('ta1').className = "itr";
            document.getElementById('imgs').className = "ihouses2";
        }        
    }
    
    var add = document.getElementById('ctl00_cphc_Pdt1_maph1');
    //"http://maps.google.com/maps/api/staticmap?center=Tran Hung Dao, Quan 1, Ho Chi Minh, Viet Nam";
    var add2 = document.getElementById('ctl00_cphc_Pdt1_maph2');
    //var add2 = "&size=379x300&markers=color:blue|label:N|Tran Hung Dao, Quan 1, Ho Chi Minh, Viet Nam&sensor=true&format=png";
    i = 14;
    function zoomin(mapid)
    {
        i= i+1;
        var id = document.getElementById(mapid);
        id.src = add.value + "&zoom=" + i + add2.value;
    }
    
    function zoomout(mapid)
    {
        i=i-1;
        var id = document.getElementById(mapid);
        id.src = add.value + "&zoom=" + i + add2.value;
    }
</script>