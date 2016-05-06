<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pts.ascx.cs" Inherits="ctrls_pts" %>
<%@ Register Assembly="FUA" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<asp:UpdatePanel id="n3w" runat="server">
<ContentTemplate>
<div class="ph1pts"><img src="images/sp.gif" alt=""/></div>
<div class="tdt" runat="server" id="hls1">Đăng tin mới</div>
<div class="indt">
    <div class="ind2">Thông tin cơ bản</div>
    <div class="pos1">Điền chính xác các thông tin dưới đây giúp cho tài sản của bạn xuất hiện chính xác và đầy đủ trong các kết quả theo nhu cầu của người dùng, việc này giúp cho giao dịch của bạn sẽ nhanh hơn.</div>
    <div id="p130" class="p130">
        <div class="p130s">Loại tin đăng:</div>
        <div class="p130s"><div style="margin-top:-2px">Tin đăng:</div></div>
        <div class="p130s">Loại địa ốc: <span class="red">*</span></div>
        <div class="p130s">Vị trí:</div>
        <div class="p130s"><img src="images/sp.gif" alt=""/></div>
        <div class="p130s"><img src="images/sp.gif" alt=""/></div>
        <div class="p130s"><img src="images/sp.gif" alt=""/></div>
        <div class="p130s"><img src="images/sp.gif" alt=""/></div>
        <div class="p130s"><img src="images/sp.gif" alt=""/></div>
        <div class="p130s"><div style="margin-top:60px">Thuộc Dự án:</div></div>
        <div class="p130s"><div style="margin-top:5px">Giá:</div></div>
        <div class="p130s"><img src="images/sp.gif" alt=""/></div>
        <div class="p130s"><div style="margin-top:7px">Môi giới:</div></div>
        <div class="p130s"><div style="margin-top:0px">Diện tích sử dụng: <span class="red">*</span></div></div>
        <div class="p130s"><div style="margin-top:5px">Diện tích khuôn viên:</div></div>
    </div>
    <div id="p270" class="p270">
        <div class="p270s">
            <asp:RadioButton GroupName="cate" ID="r1" runat="server" Checked="true" Text="Cần bán"/>&nbsp;&nbsp;
            <asp:RadioButton GroupName="cate" ID="r2" runat="server" Text="Cho thuê"/>&nbsp;&nbsp;
            <asp:RadioButton GroupName="cate" ID="r3" runat="server" Text="Cần mua"/>&nbsp;&nbsp;
            <asp:RadioButton GroupName="cate" ID="r4" runat="server" Text="Cần thuê"/>&nbsp;&nbsp;
            <asp:RadioButton GroupName="cate" ID="r5" runat="server" Text="Chuyển nhượng"/>
        </div>
        <div class="p270s">
            <asp:RadioButton GroupName="gc" ID="rm" runat="server" Checked="true" Text="Môi giới"/>&nbsp;&nbsp;&nbsp;
            <asp:RadioButton GroupName="gc" ID="rc" runat="server" Text="Chính chủ"/>
        </div>
        <div class="p270s">
            <asp:DropDownList Width="159px" CssClass="nwf" ID="n3w2" runat="server"></asp:DropDownList>&nbsp;&nbsp;
            <asp:DropDownList Width="159px"  CssClass="nwf" ID="n3w3" runat="server"></asp:DropDownList>
        </div>
        <div class="p270s">
            <div style="width:169px;float:left">Quốc gia <span class="red">*</span></div>&nbsp;&nbsp;
            <div style="width:159px;float:left">Tỉnh / Thành phố <span class="red">*</span></div>
        </div>
        <div class="p270s">
            <select style="width:159px" id="n3w5" runat="server" class="nwf">
                <option value="1" selected="selected">Việt Nam</option>
            </select>&nbsp;&nbsp;
            <asp:DropDownList Width="256px" CssClass="nwf" ID="n3w4" runat="server" OnSelectedIndexChanged="n3w4_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
        </div>
        <div class="p270s">
            <div style="width:169px;float:left">Quận / Huyện <span class="red">*</span></div>&nbsp;&nbsp;
            <div style="width:159px;float:left">Phường / Xã <span class="red">*</span></div>
        </div>
        <div class="p270s">
            <asp:DropDownList Width="159px" CssClass="nwf" ID="n3w6" runat="server" AutoPostBack="true" OnSelectedIndexChanged="n3w6_SelectedIndexChanged">
                <asp:ListItem Enabled="true" Text="Quận/Huyện" Value="-1"></asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;
            <asp:DropDownList Width="256px" AutoPostBack="true" CssClass="nwf" ID="n3w7" runat="server" OnSelectedIndexChanged="n3w7_SelectedIndexChanged">
                <asp:ListItem Enabled="true" Text="Phường/Xã" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="p270s">
            <div style="width:169px;float:left">Số nhà</div>&nbsp;&nbsp;
            <div style="width:159px;float:left">Tên đường / Tên phố <span class="red">*</span></div>
        </div>
        <div class="p270s">
            <input style="width:153px" runat="server" type="text" class="fat" id="fa" />&nbsp;&nbsp;
            <asp:DropDownList Width="256px" CssClass="nwf" ID="n3w8" runat="server">
                <asp:ListItem Enabled="true" Text="Tên đường" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="p270s">
            <asp:DropDownList Width="424px" CssClass="nwf" ID="n3w9" runat="server">
                <asp:ListItem Enabled="true" Text="Dự án địa ốc" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="p270s">
            <input maxlength="15" onfocusout="ConvertPriceText(this.value)" onblur="ConvertPriceText(this.value)" onkeyup="this.value = FormatNumber(this.value);"  style="width:153px" runat="server" type="text" class="fat" id="pvalue" />&nbsp;&nbsp;
            <select onclick="ConvertPriceText(document.getElementById(&quot;ctl00_cphc_Pts1_pvalue&quot;).value)" id="kpri" style="width:83px" runat="server" class="nwf">
                <option value="vnd" selected="selected">VND</option>
                <option value="usd">USD</option>
                <option value="sjc">SJC</option>
            </select>&nbsp;
            <select onclick="ConvertPriceText(document.getElementById(&quot;ctl00_cphc_Pts1_pvalue&quot;).value)" id="upri" style="width:116px" runat="server" class="nwf">
                <option value="ar" selected="selected">Tổng diện tích</option>
                <option value="m2">m2</option>
                <option value="mon">Tháng</option>
            </select>
        </div>
        <div class="p270s">
            <div id="price">Thương lượng / Tổng diện tích</div>
        </div>
        <div class="p270s">
            <asp:RadioButton GroupName="agen" ID="r6" runat="server" Text="Miễn trung gian" onclick="_DisplayDongYKG1();"/>&nbsp;&nbsp;
            <asp:RadioButton GroupName="agen" ID="r7" runat="server" Text="Ký gửi môi giới" onclick="_DisplayDongYKG();"/>&nbsp;&nbsp;
            <div id="k1" runat="server" class="k1style">
                <input style="width:83px" runat="server" type="text" class="fat" id="agen1" />&nbsp;&nbsp;
                <select id="genc" runat="server" class="nwf">
                    <option value="1" selected="selected">%</option>
                </select>
            </div>
        </div>
        <div class="p270s">
            <input style="width:113px" runat="server" type="text" class="fat" id="area" /> m<sup>2</sup>
        </div>
        <div class="p270s">
            <input style="width:113px" onfocus="if (this.value=='Chiều ngang') this.value='';" onblur="if (this.value=='') this.value='Chiều ngang';" value="Chiều ngang" runat="server" type="text" class="fat" id="w" /> m x
            <input style="width:113px" onfocus="if (this.value=='Chiều dài') this.value='';" onblur="if (this.value=='') this.value='Chiều dài';" value="Chiều dài" runat="server" type="text" class="fat" id="l" /> m
        </div>
    </div>
</div>
<div class="indt">
    <div class="ind2">Đặc điểm & Tiện ích</div>
    <div id="p330" class="p330">
        <div class="p330s">Tình trạng pháp lý:</div>
        <div class="p330s">
            <asp:DropDownList Width="160px" CssClass="nwf" ID="doc" runat="server">
                <asp:ListItem Enabled="true" Text="Tình trạng pháp lý" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="p330s">Hướng tài sản:</div>
        <div class="p330s">
            <asp:DropDownList Width="160px" CssClass="nwf" ID="set" runat="server">
                <asp:ListItem Enabled="true" Text="Hướng tài sản" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="p330s">Đường trước nhà:</div>
        <div class="p330s">
            <select id="land" style="width:160px" runat="server" class="nwf">
                <option value="-1" selected="selected">Đường trước nhà</option>
                <option value="0">------</option>
                <option value="3">< 3 m</option>
                <option value="3">> 3 m</option>
                <option value="4">> 4 m</option>
                <option value="5">> 5 m</option>
                <option value="6">> 6 m</option>
                <option value="7">> 7 m</option>
                <option value="8">> 8 m</option>
                <option value="9">> 9 m</option>
                <option value="10">> 10 m</option>
                <option value="15">> 15 m</option>
                <option value="20">> 20 m</option>
                <option value="40">> 40 m</option>
                <option value="60">> 60 m</option>
                <option value="80">> 80 m</option>
            </select>
        </div>
        <div class="p330s">Số lầu:</div>
        <div class="p330s">
            <select id="flor" style="width:160px" runat="server" class="nwf">
                <option value="-1" selected="selected">Số lầu</option>
            </select>
        </div>
    </div>
    <div id="p3301" class="p330">
        <div class="p330s">Số phòng khách:</div>
        <div class="p330s">
            <asp:DropDownList Width="160px" CssClass="nwf" ID="liv" runat="server">
                <asp:ListItem Enabled="true" Text="Số phòng khách" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="p330s">Số phòng ngủ:</div>
        <div class="p330s">
            <asp:DropDownList Width="160px" CssClass="nwf" ID="bed" runat="server">
                <asp:ListItem Enabled="true" Text="Số phòng ngủ" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="p330s">Số phòng tắm/vệ sinh:</div>
        <div class="p330s">
            <asp:DropDownList Width="160px" CssClass="nwf" ID="bro" runat="server">
                <asp:ListItem Enabled="true" Text="Số phòng tắm/vệ sinh" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="p330s">Số phòng khác:</div>
        <div class="p330s">
            <asp:DropDownList Width="160px" CssClass="nwf" ID="othr" runat="server">
                <asp:ListItem Enabled="true" Text="Số phòng khác" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div id="p440" class="p440">
        <div class="p440s">Các tiện ích:</div>
        <div class="p440s"><input type="checkbox" id="us1" runat="server" /><label for="ctl00_cphc_Pts1_us1">Đầy đủ tiện nghi</label></div>
        <div class="p440s"><input type="checkbox" id="us2" runat="server" /><label for="ctl00_cphc_Pts1_us2">Chỗ đậu xe hơi</label></div>
        <div class="p440s"><input type="checkbox" id="us3" runat="server" /><label for="ctl00_cphc_Pts1_us3">Sân vườn</label></div>
        <div class="p440s"><input type="checkbox" id="us4" runat="server" /><label for="ctl00_cphc_Pts1_us4">Hồ bơi</label></div>
        <div class="p440s2"><input type="checkbox" id="us5" runat="server" /><label for="ctl00_cphc_Pts1_us5">Tiện kinh doanh</label></div>
        <div class="p440s2"><input type="checkbox" id="us6" runat="server" /><label for="ctl00_cphc_Pts1_us6">Tiện để ở</label></div>
        <div class="p440s2"><input type="checkbox" id="us7" runat="server" /><label for="ctl00_cphc_Pts1_us7">Tiện làm văn phòng</label></div>
        <div class="p440s2"><input type="checkbox" id="us8" runat="server" /><label for="ctl00_cphc_Pts1_us8">Tiện cho sản xuất</label></div>
        <div class="p440s2"><input type="checkbox" id="us9" runat="server" /><label for="ctl00_cphc_Pts1_us9">Cho sinh viên thuê</label></div>
    </div>
</div>
<div class="indt">
    <div class="ind2">Mô tả chi tiết tin đăng</div>
    <div class="pos1">
     Vùng nội dung mô tả này sẽ được kiểm duyệt thông tin trước khi cho phép hiển thị trên Nha3w.com.
Tin đăng nhập nội dung theo đúng quy định sẽ được ưu tiên duyệt hiển thị nhanh hơn.
Vui lòng nhập tiếng Việt có dấu. Nếu bạn không nhập mô tả, hệ thống sẽ lấy mô tả tự động. 
    </div>
    <div id="p1303" class="p130">
        <div class="p130s">Tiêu đề: <span class="red">*</span></div>
        <div class="p130s">Nội dung mô tả: <span class="red">*</span></div>
    </div>
    <div id="p2703" class="p270">
        <div class="p270s">
            <input style="width:398px" runat="server" type="text" class="fat" id="title" />
        </div>
        <div class="p270s">
            <textarea rows="7" cols="20" style="width:398px" runat="server" class="fat" id="descript"></textarea>
        </div>
    </div>
</div>
<div class="indt">
    <div class="ind2">Cập nhật hình ảnh</div>
    <div class="pos1">Cập nhật hình ảnh tài sản: (Tối đa 10 hình)</div>
    <div class="p440s2">Định dạng hình ảnh .jpg, .jpeg, .png, .gif.</div>
    <div class="p440s2">Dung lượng tối đa 5MB / 1 hình</div>
    <div class="p440s2"></div>
    <div id="dv2" class="p550">
        <div class="p440s">
        <asp:GridView ShowHeader="false" ID="gImages" Width="38%" runat="server" AutoGenerateColumns="False" DataKeyNames="HouseId,PostId,Images,CreationDate" OnRowCommand="gImages_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("WardId") %>'></asp:Label>--%>
                        <%--src='<%# "../pros/thumbs/" + Eval("Images") %>'--%> 
                        <img alt="" id="i1" runat="server" src='<%# "../pros/" + DateTime.Parse(Eval("CreationDate").ToString()).Year.ToString()+ "/" + DateTime.Parse(Eval("CreationDate").ToString()).Month.ToString()+ "/" + Eval("PostId").ToString() +"/thumbs/" + Eval("Images") %>' class="ilhupd"/>
                    </ItemTemplate>
                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="left"
                        VerticalAlign="Middle"/>
                </asp:TemplateField>
                <asp:ButtonField Text="Xoá" CommandName="DelPros">
                    <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" HorizontalAlign="Center"
                        VerticalAlign="Middle" Width="15%" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
        </div>
    </div>
    <div class="p440s2"></div>
    <div id="df1" class="p550">
        <div class="p440s">
            <cc1:FileUploaderAJAX ID="fp1" runat="server" MaxFiles="5" text_Add="Thêm" text_Delete="Xoá" text_Uploading="Đang upload file"/>
            <br />
            <cc1:FileUploaderAJAX showDeletedFilesOnPostBack="true" ID="fp2" runat="server" MaxFiles="5" text_Add="Thêm" text_Delete="Xoá" text_Uploading="Đang upload file"/>
        </div>
    </div>
    <%--<div id="df2" class="p550">
        <div class="p440s">
            
        </div>
    </div>--%>
</div>
<div class="indt">
    <div class="ind2">Liên hệ</div>
    <div id="inf1" class="p130">
        <div class="p130s"><div style="margin-top:4px">Người liên hệ: <span class="red">*</span></div></div>
        <div class="p130s"><div style="margin-top:4px">Điện thoại:</div></div>
        <div class="p130s"><div style="margin-top:4px">Di động: <span class="red">*</span></div></div>
        <div class="p130s"><div style="margin-top:5px">Địa chỉ:</div></div>
        <div class="p130s"><div style="margin-top:0px">Ghi chú:</div></div>
    </div>
    <div id="inf2" class="p270">
        <div class="p270s">
            <input style="width:398px" runat="server" type="text" class="fat" id="ic" />
        </div>
        <div class="p270s">
            <input style="width:398px" runat="server" type="text" class="fat" id="it" />
        </div>
        <div class="p270s">
            <input style="width:398px" runat="server" type="text" class="fat" id="ml" />
        </div>
        <div class="p270s">
            <input style="width:398px" runat="server" type="text" class="fat" id="ar" />
        </div>
        <div class="p270s">
            <textarea rows="7" cols="20" style="width:398px" runat="server" class="fat" id="nts"></textarea>
        </div>
    </div>
</div>
<div class="indt">
    <div class="ind2">Lưu ý: </div>
    <div class="pos1">Những mục có dấu <span class="red">*</span> là thông tin phải điền đầy đủ. 
    Chỉ khi bạn hoàn tất những thông tin được yêu cầu điền đầy đủ thì các chức năng Xem trước hay Đăng tài sản  mới được kích hoạt. 
    Nha3w.com không chịu trách nhiệm về những nội dung (chữ/ hình ảnh/ Video) do bạn đăng tải. 
    Khi nhấn nút đăng tài sản, bạn đã xác nhận hoàn toàn đồng ý với những (Điều khoản đăng tin).</div>
<div class="p440s2" align="center">
    <asp:Button CssClass="pts2" ID="signu" runat="server" Text="Đăng tin mới" OnClick="signu_Click" />&nbsp;
    <asp:Button CssClass="pts2" ID="save" runat="server" Text="Lưu lại tin" />
    <div class="dsli"><img id="sign" class="sli"/></div>
</div>
<div class="pvld" id="pvlid" runat="server" visible="false"></div>
</div>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="n3w4" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="n3w6" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="n3w7" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
<div class="snt"><img src="images/sp.gif" alt=""/></div>
<script type="text/javascript">
    function _DisplayDongYKG()
    {
        var DongYKG = document.getElementById("ctl00_cphc_Pts1_k1");
        //var DongYKG1 = document.getElementById("divDongYKG1");
        if(document.getElementById("ctl00_cphc_Pts1_r7").checked)
        {
            DongYKG.className = "k1style2";
//            DongYKG.style.display = "block";
//            //DongYKG1.style.display = "block";
//            DongYKG.style.display = "";
//            //DongYKG1.style.display = "";
        }     
    }
    
    function signu()
    {
        document.getElementById('sign').style.visibility = "visible";
        document.getElementById('sign').src = "images/prh.png";
    }
    
    function _DisplayDongYKG1()
    {
        var DongYKG = document.getElementById("ctl00_cphc_Pts1_k1");
        //var DongYKG1 = document.getElementById("divDongYKG1");
        DongYKG.className = "k1style";
        
        //DongYKG.style.display = "none";
        //DongYKG1.style.display = "none";
    }

    function FormatNumber(str){
	            var strTemp = GetNumber(str);
	            if(strTemp.length <= 3)
		            return strTemp;
	            strResult = "";
	            for(var i =0; i< strTemp.length; i++)
		            strTemp = strTemp.replace(",", "");
	            for(var i = strTemp.length; i>=0; i--)
	            {
		            if(strResult.length >0 && (strTemp.length - i -1) % 3 == 0)
			            strResult = "," + strResult;
		            strResult = strTemp.substring(i, i + 1) + strResult;
	            }	
	            return strResult;
            }
        function GetNumber(str)
        {
            for(var i = 0; i < str.length; i++)
            {	
	            var temp = str.substring(i, i + 1);		
	            if(!(temp == "," || temp == "." || (temp >= 0 && temp <=9)))
	            {
		            alert("Vui lòng nhập số (0-9)!");
		            return str.substring(0, i);
	            }
	            if(temp == " ")
	                return str.substring(0, i);
            }
            return str;
        }
        
        function ConvertPriceText(strTemp)
        {
            strTemp        = strTemp.replace(/,/g, "");
            var priceTy    = parseInt(strTemp/1000000000,0);
            var priceTrieu = parseInt((strTemp % 1000000000)/1000000,0);
            var priceNgan  = parseInt(((strTemp % 1000000000))%1000000/1000,0);
            var priceDong  = parseInt(((strTemp % 1000000000))%1000000%1000,0);
            var strTextPrice = "";
            if(strTemp == "" || strTemp == "0"){ strTextPrice = "Thương lượng";}
            if(priceTy > 0 && parseInt(strTemp,0) > 900000000){ strTextPrice = strTextPrice  + "<b>" + priceTy + "</b> tỷ ";}
            if(priceTrieu > 0){ strTextPrice = strTextPrice  + "<b>" + priceTrieu + "</b> triệu ";}
            if(priceNgan > 0){ strTextPrice = strTextPrice  + "</b>" + priceNgan + "</b> ngàn ";}
            if(document.getElementById("ctl00_cphc_Pts1_kpri").value == "vnd")
            {
                if(priceTy > 0 || priceTrieu > 0 || priceNgan > 0 || priceDong > 0) {strTextPrice = strTextPrice  + "<b>VNĐ</b>";}
            }
            if(document.getElementById("ctl00_cphc_Pts1_kpri").value == "sjc")
            {
                if(priceDong > 0){ strTextPrice = strTextPrice + priceDong;}
                if(priceTy > 0 || priceTrieu > 0 || priceNgan > 0 || priceDong > 0) {strTextPrice = FormatNumber(strTemp) + "<b> lượng SJC</b>";}
            }
            if(document.getElementById("ctl00_cphc_Pts1_kpri").value == "usd")
            {
                if(priceDong > 0) {strTextPrice = strTextPrice + priceDong;}
                if(priceTy > 0 || priceTrieu > 0 || priceNgan > 0 || priceDong > 0) {strTextPrice = FormatNumber(strTemp) + "<b> USD</b>";}
            }
            if(document.getElementById("ctl00_cphc_Pts1_upri").value == "ar") {strTextPrice = strTextPrice + "<b> / Tổng diện tích</b>";}
            if(document.getElementById("ctl00_cphc_Pts1_upri").value == "m2") {strTextPrice = strTextPrice + "<b> / Mét vuông</b>";}
            if(document.getElementById("ctl00_cphc_Pts1_upri").value == "mon") {strTextPrice = strTextPrice + "<b> / Tháng</b>";}
            document.getElementById("price").innerHTML = strTextPrice;
        }
</script>

