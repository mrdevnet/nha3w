<%@ Control Language="C#" AutoEventWireup="true" CodeFile="resetpass.ascx.cs" Inherits="ctrls_resetpass" %>
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
            <h1 class="fram_header_txt">Thay đổi mật khẩu</h1>
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
            Hãy nhập mật khẩu mà bạn muốn thay đổi. Để đảm bảo tính bảo mật và thông tin khách hàng vui lòng đừng nhập những mật khẩu mang tính chất dễ nhớ như: ngày sinh,địa chỉ nhà, sô điện thoại....
            <br/>
            Hãy đảm bảo mật khẩu bạn nhập vào chỉ mình bạn biết.
            </div>
            <div class="fram_content_login">
                <div class="fram_row">
                <label class="fram_row_label">Mật khẩu mới:</label>
                <asp:TextBox ID="txtPass" CssClass="fram_row_textbox" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="fram_row">
                <label class="fram_row_label">Nhập lại mật khẩu:</label>
                    <asp:TextBox ID="txtPassR" CssClass="fram_row_textbox" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div id="pnlcc" runat="server">
                <div class="fram_row_capchart">
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
                    <asp:TextBox ID="txtCode" CssClass="fram_row_textbox" runat="server" Width="130px"></asp:TextBox>
                </div>
                </div>                
                <div class="fram_row" style="margin: 0 0 0 100px;">
                 <asp:LinkButton ID="lbtResetpass" CssClass="buttons" runat="server" Width="80px" OnClick="lbtResetpass_Click" >Tiếp tục</asp:LinkButton>                     
               </div>
               <div class="fram_loading">
                    <asp:UpdateProgress ID="rspro" runat="server">
                    <ProgressTemplate>
                       <img class="loading" src="App_Themes/profile/loading.gif" />
                    </ProgressTemplate>    
                    </asp:UpdateProgress>
                </div>
            </div>
        </div>
     </div>  
</div>