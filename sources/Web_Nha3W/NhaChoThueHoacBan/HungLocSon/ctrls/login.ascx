<%@ Control Language="C#" AutoEventWireup="true" CodeFile="login.ascx.cs" Inherits="ctrls_login" %>
<link href="../App_Themes/Profile/master_login.css" rel="stylesheet" type="text/css" />
<link href="../App_Themes/Profile/login.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
function Catpc() 
 {
  var img = document.getElementById("icp");
   img.src= "ctrls/catpc.ashx?query="+ Math.random();
}
//function clickButton(e, buttonid)
//{
//    var evt = e ? e : window.event;
//    var bt = document.getElementById(buttonid);
//    if (bt)
//    {
//        if (evt.keyCode == 13)
//        {
//            bt.click();
//            return false;
//        }
//    }
//}
</script>
<div class="fram">
    <div class="fram_header">
        <div style="display:block;">
            <div>
            <h1 class="fram_header_txt">Đăng nhập tài khoản Nhà 3W</h1>
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
            <div class="fram_content_login">
                <div class="fram_row">
                <label class="fram_row_label">Tài khoản:</label>
                <asp:TextBox ID="txtUser" CssClass="fram_row_textbox" runat="server"></asp:TextBox>
                </div>
                <div class="fram_row">
                <label class="fram_row_label">Mật khẩu:</label>
                    <asp:TextBox ID="txtPassword" CssClass="fram_row_textbox" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div id="pnlcc"  runat="server">
                <div  class="fram_row_capchart">
                    <div class="capchart">
                        <img id="icp" src='ctrls/catpc.ashx?query=<%= querys() %>' alt="Mã bảo mật" style="width: 100%; height: 100%" />
                    </div>
                    <div class="reset_capchart">
                        <a href="#" onclick="javascript:Catpc();" title="Mã bảo mật khác">
                        <img style="border:0px" class="cyl" src="App_Themes/profile/cycle2.png" />
                        </a>
                    </div>
                </div>            
                <div class="fram_row">
                <label class="fram_row_label">Mã bảo mật:</label>
                    <asp:TextBox ID="txtCode" CssClass="fram_row_textbox" runat="server" Width="195px"></asp:TextBox>
                </div>
                </div>
                <div class="fram_row_checkbox">
                <div style="vertical-align:middle">
                    <asp:CheckBox ID="keepps" runat="server" Text="Duy trì trạng thái đăng nhập"/>
                </div>    
                </div>
                <div class="fram_row_buttons fram_row">
                <label class="fram_row_label"></label>
                <asp:LinkButton ID="lbtLogin" CssClass="buttons" runat="server" OnClick="lbtLogin_Click">Đăng nhập</asp:LinkButton>
                hoặc
                <strong>
                    <a href="login.aspx">Đăng ký tài khoản Nhà 3W</a>
                </strong> 
                <label class="fram_row_label"></label>
                <p class="fram_row_link fram_row" style="float:left;"><a href="resetpass.aspx?w=0">Quên mật khẩu ?</a></p>
                </div>
                <br/>
                <div class="fram_loading">
                    <asp:UpdateProgress ID="lgpro" runat="server">
                    <ProgressTemplate>
                       <img class="loading" src="App_Themes/profile/loading.gif" />
                    </ProgressTemplate>    
                    </asp:UpdateProgress>
                </div>
            </div>
        </div>
     </div>
</div>