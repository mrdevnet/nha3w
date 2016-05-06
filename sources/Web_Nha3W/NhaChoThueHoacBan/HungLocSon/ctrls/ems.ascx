<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ems.ascx.cs" Inherits="ctrls_ems" %>
<div style="width:703px; margin:0 auto;">
<div id="err" class="fram_content_err" runat="server">
                <h2 id="header_err" runat="server"></h2>
                <p class="err_txt"></p>
                <p id="text_err" runat="server"></p>
</div>
<div class="sms_btn" style="margin-top:5px;"><h2>Gửi Email</h2></div>
<div style ="padding-top:10px;">
<label>Người nhận:</label>
<br/>
<asp:TextBox ID="txtTo" CssClass="textbox" runat="server" Width="600px"></asp:TextBox>
<br/>
<label>Tiêu đề:</label>
<br/>
<asp:TextBox ID="txtTitle" CssClass="textbox" runat="server" Width="600px"></asp:TextBox>
<br/>
<label>Nội dung (Không quá 3000 ký tự):</label>
<br/>
<asp:TextBox ID="txtMessage" CssClass="textbox" runat="server" Width="700px" TextMode="MultiLine" Height="200px"></asp:TextBox>
<br/>
<asp:LinkButton ID="btnSentMails" CssClass="buttons" runat="server"   Font-Bold="false" OnClick="btnSentMails_Click">Gửi Email</asp:LinkButton> 
</div>
<div class="sms_process">        
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">     
        <ProgressTemplate>
            <img style="" src="App_Themes/profile/loading.gif" />
        </ProgressTemplate>
        </asp:UpdateProgress>      
   </div>     
</div>