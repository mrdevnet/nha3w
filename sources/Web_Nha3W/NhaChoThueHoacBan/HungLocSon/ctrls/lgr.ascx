<%@ Control Language="C#" AutoEventWireup="true" CodeFile="lgr.ascx.cs" Inherits="ctrls_lgr" %>
<div class="lgrc">
    <div class="lgr0">
        <div class="lgr"><a href="default.aspx" title="Nhà 3W - Kết nối & Xanh & Hiện đại"><img style="border:0px" src="images/nha3w.png" /></a></div>
        <div class="lgr2">
            <div class="lgr21"><div class="lgc"><input runat="server" type="checkbox" id="keepps" class="lgt"/></div><label for="Lgr1_keepps" class="lgt">Lưu cho lần đăng nhập sau</label></div>
            <div class="lgr212"><a class="lgl" href="resetpass.aspx?w=0">Quên mật khẩu?</a></div>
            <div class="lgr22">
                <input runat="server" type="text" value="Tài khoản" id="user" class="usp" onfocus="if (this.value=='Tài khoản') this.value='';" onblur="if (this.value=='') this.value='Tài khoản';"/>&nbsp;&nbsp;&nbsp;
                <input runat="server" type="password" value="Mật khẩu" id="pass" class="usp"/>&nbsp;&nbsp;
                <asp:Button CssClass="susp" ID="submit" runat="server" CausesValidation="false" Text="Đăng nhập" OnClick="submit_Click"/>
            </div>
        </div>
    </div>
</div>
<asp:UpdatePanel id="sig" runat="server">
<ContentTemplate>
<div class="lgrc2">
    <div class="sg1">
        <div class="sg11"><img src="prom/villav.jpg" /></div>
    </div>
    <div class="sg2">
        <div class="sg21">Đăng ký miễn phí</div>
        <div class="sg22">Website Thông tin Bất động sản tin cậy và hữu ích</div>
        <div class="sg23">Tên đăng nhập:</div>
        <div class="sg24"><input id="user1" class="lsp" type="text" runat="server" /> <asp:RequiredFieldValidator CssClass="lvld" ControlToValidate="user1" ID="r1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></div>
        <div class="sg23">Mật khẩu:</div>
        <div class="sg24"><input id="pass1" type="password" class="lsp" runat="server"/> <asp:RequiredFieldValidator CssClass="lvld" ControlToValidate="pass1" ID="r2" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></div>
        <div class="sg23">Nhập lại Mật khẩu:</div>
        <div class="sg24"><input id="pass2" type="password" class="lsp" runat="server"/> <asp:RequiredFieldValidator CssClass="lvld" ControlToValidate="pass2" ID="r3" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></div>
        <div class="sg23">Họ và tên:</div>
        <div class="sg24"><input id="fullname" class="lsp" type="text" runat="server"/> <asp:RequiredFieldValidator CssClass="lvld" ControlToValidate="fullname" ID="r4" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></div>
        <div class="sg23">Email:</div>
        <div class="sg24"><input id="email" class="lsp" type="text" runat="server"/> <asp:RequiredFieldValidator CssClass="lvld" ControlToValidate="email" ID="r5" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></div>
        <div class="sg23">Mã bảo mật:</div>
        <div class="sg24"><div class="tis"><input id="security" class="lsp3" type="text" runat="server"/></div><div class="is"><img id="icp" src='ctrls/catpc.ashx?query=<%= querys() %>' alt="Mã bảo mật" /></div><a href="#" onclick="javascript:Catpc();" title="Mã bảo mật khác"><img class="cyl" src="images/cycle2.png" /></a></div>
        <div class="sg23"></div>
        <div class="sg24"><div class="agr1"><input runat="server" type="checkbox" id="agree" class="agr2"/></div><a href="#" class="agr" >Tôi đồng ý với các điều khoản sử dụng</a></div>
        <div class="sg23"></div>
        <div class="sg24"><asp:Button CssClass="lsp2" ID="signu" runat="server" Text="Đăng ký" OnClick="signu_Click"/><div class="dsli"><img id="sign" class="sli"/></div></div>
        <div class="pvld" id="pvlid" runat="server" visible="false"></div>
        <div class="sg25" id="prom" runat="server" >Đăng ký một tài khoản cho cá nhân, nhà môi giới hoặc doanh nghiệp</div>
    </div>
</div>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="signu" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<div class="ph1"><img src="images/bgl.png" alt=""/></div>
 <div id="footer1">
    <div class="fpln"></div>
    <div class="cprt">Nhà 3W © 2010 :: Tốt nhất với Firefox 3.6 trở lên</div>
    <div class="gfln">
        <a href="#" class="afln">Liên hệ</a>
        <a href="#" class="afln">Quảng cáo</a>
        <a href="#" class="afln">Điều khoản</a>
        <a href="#" class="afln">Bảo mật</a>
        <a href="#" class="afln">Trợ giúp</a>
        <a href="#" class="afln">Về chúng tôi</a>
        <a href="forum/default.aspx" class="afln">Diễn đàn</a>
    </div>
 </div>
 <div class="snt"><img src="images/sp.gif" alt=""/></div>
 <script type="text/javascript">
    function vlr(field)
    {
    with (field)
      {
      if (value==null||value=="")
        return false;
      else
        return true;
      }
    }
    
    function lgi()
    {
        if (vlr(document.getElementById('Lgr1_user')) == false || vlr(document.getElementById('Lgr1_pass')) == false)
        {
            alert('Tài khoản và mật khẩu chưa chính xác.');
            return false;
        }
    }
 
    function signu()
    {
        if (vlr(document.getElementById('Lgr1_user1')) && vlr(document.getElementById('Lgr1_pass1'))&& vlr(document.getElementById('Lgr1_pass2'))
        && vlr(document.getElementById('Lgr1_fullname'))&& vlr(document.getElementById('Lgr1_email')) && vlr(document.getElementById('Lgr1_security')))
        {
            document.getElementById('sign').style.visibility = "visible";
            document.getElementById('sign').src = "images/prh.png";
        }
    }
    
    function Catpc() {
            var img = document.getElementById("icp");
            img.src= "ctrls/catpc.ashx?query="+ Math.random();
        }
 
 </script>
 <%--<input type="submit" id="submit1" class="susp" runat="server" causesvalidation="false" value="Đăng nhập"/>--%>