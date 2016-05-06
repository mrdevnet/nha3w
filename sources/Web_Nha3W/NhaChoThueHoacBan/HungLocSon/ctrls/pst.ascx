<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pst.ascx.cs" Inherits="ctrls_pst" %>
<asp:UpdatePanel id="n3w" runat="server">
<ContentTemplate>
<div class="ilike" id="stay" runat="server"></div>
<div class="nwsrh" id="n3wa" runat="server">
    <div class="nwsd"><asp:DropDownList Width="108px" OnSelectedIndexChanged="n3w1_SelectedIndexChanged" AutoPostBack="True" CssClass="nwf" ID="n3w1" runat="server"></asp:DropDownList></div>
    <div class="nwsd"><asp:DropDownList Width="152px" CssClass="nwf" ID="n3w2" runat="server"></asp:DropDownList></div>
    <div class="nwsd"><asp:DropDownList Width="153px" CssClass="nwf" ID="n3w3" runat="server"></asp:DropDownList></div>
    <div class="nwsd"><asp:DropDownList Width="112px" CssClass="nwf" ID="n3w4" runat="server" OnSelectedIndexChanged="n3w4_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList></div>
    <div class="nwsd">
        <select id="n3w5" style="width:63px" runat="server" class="nwf">
            <option value="-1" selected="selected">MG/CC</option>
            <option value="0">--------</option>
            <option value="1">Môi giới</option>
            <option value="2">Chính chủ</option>
        </select>
    </div>
    <div class="nwsd">
        <asp:DropDownList Width="108px" CssClass="nwf" ID="n3w6" runat="server" AutoPostBack="true" OnSelectedIndexChanged="n3w6_SelectedIndexChanged">
            <asp:ListItem Enabled="true" Text="Quận/Huyện" Value="-1"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="nwsd">
        <asp:DropDownList Width="152px" AutoPostBack="true" CssClass="nwf" ID="n3w7" runat="server" OnSelectedIndexChanged="n3w7_SelectedIndexChanged">
            <asp:ListItem Enabled="true" Text="Phường/Xã" Value="-1"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="nwsd">
        <asp:DropDownList Width="153px" CssClass="nwf" ID="n3w8" runat="server">
            <asp:ListItem Enabled="true" Text="Tên đường" Value="-1"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="nwsd">
        <asp:DropDownList Width="182px" CssClass="nwf" ID="n3w9" runat="server">
            <asp:ListItem Enabled="true" Text="Dự án địa ốc" Value="-1"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="nwsd">
        <select id="n3w10" style="width:266px" runat="server" class="nwf">
            <option value="-1" selected="selected">Khoảng giá</option>
            <option value="0">--------</option>
            <option value="1">< 2 triệu</option>
            <option value="2">2 triệu - 5 triệu</option>
            <option value="3">5 triệu - 10 triệu</option>
            <option value="4">10 triệu - 20 triệu</option>
            <option value="5">20 triệu - 50 triệu</option>
            <option value="6">50 triệu - 100 triệu</option>
            <option value="7">100 triệu - 250 triệu</option>
            <option value="8">250 triệu - 500 triệu</option>
            <option value="9">500 triệu - 1 tỷ</option>
            <option value="10">1 tỷ - 1,5 tỷ</option>
            <option value="11">1,5 tỷ - 2 tỷ</option>
            <option value="12">2 tỷ - 3 tỷ</option>
            <option value="13">3 tỷ - 5 tỷ</option>
            <option value="14">5 tỷ - 10 tỷ</option>
            <option value="15">> 10 tỷ</option>
        </select>
    </div>
    <div class="nwsd"><input runat="server" type="text" onfocus="if (this.value=='Diện tích từ') this.value='';" onblur="if (this.value=='') this.value='Diện tích từ';" class="fat" id="fa" value="Diện tích từ" />&nbsp;&nbsp;<input runat="server" type="text" onfocus="if (this.value=='đến (m2)') this.value='';" onblur="if (this.value=='') this.value='đến (m2)';" class="fat1" id="ta" value="đến (m2)" /></div>
    <div class="nwsd"><asp:DropDownList Width="112px" CssClass="nwf" ID="n3w11" runat="server"></asp:DropDownList></div>
    <div class="nwsd">
        <select id="keepps" style="width:63px" runat="server" class="nwf">
            <option value="-1" selected="selected">Hình</option>
            <option value="0">-----</option>
            <option value="1">Có</option>
            <option value="2">Không</option>
        </select>
    </div>
    <div class="nwsd">
        <select id="n3w12" style="width:108px" runat="server" class="nwf">
            <option value="-1">Sắp xếp theo</option>
            <option value="0">--------</option>
            <option value="1">Diện tích</option>
            <option value="2">Giá</option>
            <option value="3" selected="selected">Ngày cập nhật</option>
        </select>
    </div>
    <div class="nwsd">
        <select id="n3w13" style="width:152px" runat="server" class="nwf">
            <option value="1" selected="selected">Giảm dần</option>
            <option value="2">Tăng dần</option>
        </select>
    </div>
    <div class="nwsd">
        <select id="n9wi" style="width:88px" runat="server" class="nwf">
            <option value="-1" selected="selected">Tin / Trang</option>
            <option value="0">-----</option>
            <option value="40">40 tin</option>
            <option value="60">60 tin</option>
            <option value="85">85 tin</option>
            <option value="100">100 tin</option>
        </select>
    </div>
    <div class="nwsd"><asp:Button CssClass="lsp2" ID="signu" runat="server" Text="Tìm kiếm" OnClick="signu_Click"/></div>
    <div class="nwsd"><img id="sign" class="sli"/></div>
</div>
<div class="iswllps" id="iwllps" runat="server" visible="false"><img src="images/sp.gif" alt=""/></div>
<div class="ph1"><img src="images/sp.gif" alt=""/></div>
<asp:Repeater ID="rptPsts" runat="server" OnItemDataBound="rptPsts_ItemDataBound">
    <ItemTemplate>
        <div class="pst" id="bgpst1" runat="server">
            <div class="plc" id="cate" runat="server">
                <div class="padt">
                    <a href='<%# "default.aspx?c=" + Eval("CategoryId") %>' class="lpc"><%# Eval("CateName")%></a>
                    <div class="ptxt" id="owner" runat="server"></div>
                    <div class="inw"><img visible="false" id="inw" runat="server" /></div>
                </div>
            </div>
            <div class="prp">
                <div class="rtd1">
                    <a href='<%# "details.aspx?p=" + Eval("PostId") %>' class="rtit"><%# Eval("Title")%></a>
                    <span class="pago" id="ago" runat="server"></span>
                </div>
                <div class="rtd2"><img visible="false" id="vip" runat="server" /></div>
                <div class="rtd3">
                    <a href='<%# "default.aspx?y=" + Eval("CityId") + "&c=" + Eval("CategoryId") %>' class="rtit2"><%# Eval("CityName")%></a>
                </div>
                <div class="rtd4">
                    <div class="rt42">
                        <div class="irt42"><img src="images/sp.gif" alt=""/><img visible="false" id="ca" runat="server"/></div>
                        <div class="area42" runat="server" id="are"></div>
                        <div class="value42" runat="server" id="v1"><a class="r4v" id="vals" runat="server"></a></div>
                        <div class="value42h" runat="server" id="v2" ><a class="r4v" id="valsu" runat="server"></a></div>
                        <div class="value42h" runat="server" id="v3" ><a class="r4v" id="valss" runat="server"></a></div>
                        <div class="value42h" runat="server" id="v4" ><a class="r4v" id="valsv" runat="server"></a></div>
                        <a href='<%# "default.aspx?l=" + Eval("ClassId") + "&d=" + Eval("DistrictId") + "&c=" + Eval("CategoryId") %>' class="r4l"><%# Eval("ClassName")%></a> - 
                        <a href='<%# "default.aspx?t=" + Eval("StreetId") + "&d=" + Eval("DistrictId") + "&c=" + Eval("CategoryId") %>' class="r4l"><%# Eval("StreetName")%></a>,&nbsp;
                        <a href='<%# "default.aspx?a=" + Eval("WardId") + "&d=" + Eval("DistrictId") + "&c=" + Eval("CategoryId") %>' class="r4l"><%# Eval("WardName")%></a>
                    </div>
                </div>
                <div class="rtd5">
                    <a href='<%# "default.aspx?d=" + Eval("DistrictId") + "&c=" + Eval("CategoryId") %>' class="rtit3"><%# Eval("DistrictName")%></a>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
<div class="fpg"><asp:Literal ID="pg" runat="server"></asp:Literal></div>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="n3w4" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="n3w6" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="signu" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<div class="snt"><img src="images/sp.gif" alt=""/></div>
<script type="text/javascript">
//    function changeCurr(Price, DisplayPrice, Selected, UnSelected1, UnSelected2)
//    {
//        $("#"+ UnSelected1).removeClass("ac");
//        $("#"+ UnSelected2).removeClass("ac");
//        $("#"+ Selected).addClass("ac");
//        $("#"+ DisplayPrice).text(Price);
//        //document.getElementById(DisplayPrice).innerHTML = Price;
//    }
    
    function vchanges(s1,s2)
    {
        var s1v = document.getElementById(s1);
        var s2v = document.getElementById(s2);
        //s1v.removeAttribute("class");
        s1v.className = "value42h";
        //s2v.removeAttribute("class");
        s2v.className = "value42";
    }
    
    function shw()
    {
        var n = document.getElementById('ctl00_cphc_Pst1_n3wa');
        n.className = "nwsrh";
        var s2 = document.getElementById('sta2');
        var s1 = document.getElementById('sta1');
        s2.className = "asr";
        s1.className = "asrh";
    }
    
    function shw1()
    {
        var n = document.getElementById('ctl00_cphc_Pst1_n3wa');
        n.className = "nwsr";
        var s2 = document.getElementById('sta2');
        var s1 = document.getElementById('sta1');
        s2.className = "asrh";
        s1.className = "asr";
    }
    
    function find()
    {
        document.getElementById('sign').style.visibility = "visible";
        document.getElementById('sign').src = "images/prh.png";
    }
</script>
