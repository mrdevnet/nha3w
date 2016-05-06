<%@ Control Language="C#" AutoEventWireup="true" CodeFile="lostpass.ascx.cs" Inherits="ctrls_lostpass" %>
<script type="text/javascript">
function Catpc() 
 {
    var img = document.getElementById("icp");
    img.src= "ctrls/catpc.ashx?query="+ Math.random();
}
</script>
<div class="fram">
    <div class="fram_header">
        <div style="display:block;">
            <div>
            <h1 class="fram_header_txt">Quên mật khẩu</h1>
            </div>
        </div>
     </div>
     <div class="fram_container">
        <div class="fram_content">
            <div id="err" class="fram_content_err" runat="server">
                <h2 id="header_err" runat="server"></h2>
                <p class="err_txt"></p>
                <p id="text_err" runat="server"></p>
            </div>
            <div class="caption">
            Quên mật khẩu của bạn? Nhập email và tài khoản đăng nhập của bạn dưới đây và điền vào các kiểm tra an ninh. Nếu bạn sử dụng email của bạn, chúng tôi sẽ gửi bạn một email với một liên kết để đặt lại mật khẩu của bạn.
            </div>
            <div class="fram_content_login">        
                <div id="pnlcc" class="fram_row_capchart" runat="server">
                    <div class="capchart">
                        <img id="icp" src='ctrls/catpc.ashx?query=<%= querys() %>' alt="Mã bảo mật" style="width: 100%; height: 100%" />
                    </div>
                    <div class="reset_capchart">
                        <a href="#" onclick="javascript:Catpc();" title="Mã bảo mật khác">
                        <img class="cyl" style="border:0px" src="App_Themes/profile/cycle2.png" />
                        </a>
                    </div>
                </div>            
                <div class="fram_row">
                <label class="fram_row_label">Mã bảo mật:</label>
                    <asp:TextBox ID="txtCode" CssClass="fram_row_textbox" runat="server"></asp:TextBox>
                </div>
                <div class="fram_row">
                <label class="fram_row_label">Tài khoản:</label>
                    <asp:TextBox ID="txtUS" CssClass="fram_row_textbox" runat="server"></asp:TextBox>
                </div>  
                <div class="fram_row">
                <label class="fram_row_label">Email của tài khoản:</label>
                    <asp:TextBox ID="txtEM" CssClass="fram_row_textbox" runat="server"></asp:TextBox>
                </div>                
                <div style="padding:0 0 0 100px;" class="fram_row">                
                <asp:LinkButton ID="lbtLostpass" CssClass="buttons" runat="server" Width="80px" OnClick="lbtLostpass_Click">Tiếp tục</asp:LinkButton>                
                </div>
                <div class="fram_loading">
                    <asp:UpdateProgress ID="lppro" runat="server">
                    <ProgressTemplate>
                       <img class="loading" src="App_Themes/profile/loading.gif" />
                    </ProgressTemplate>    
                    </asp:UpdateProgress>
                </div>
            </div>
        <div class="caption">
        Nếu bạn không nhớ thông tin đăng ký tài khoản vui lòng liên hệ với ban quản trị website để lấy lại thông tin tài khoản.
        <br/>
        Hoặc <a href="login.aspx">đăng ký</a> một tài khoản mới nếu bạn chưa có tài khoản.
        </div>
        </div>
     </div>  
</div>