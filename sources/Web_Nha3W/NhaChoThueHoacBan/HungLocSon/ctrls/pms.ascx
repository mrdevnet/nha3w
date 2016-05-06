<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pms.ascx.cs" Inherits="ctrls_pms" %>
<div style="width:703px; margin:0 auto;">
<div id="err" class="fram_content_err" runat="server">
                <h2 id="header_err" runat="server"></h2>
                <p class="err_txt"></p>
                <p id="text_err" runat="server"></p>
</div>
<div class="sms_btn" style="margin-top:5px;"><h2>Gửi tin nhắn</h2></div>
<div style ="padding-top:10px;">
<div id="search_frm">
    <label>Tìm kiếm bạn bè</label><br/>
    <div id="info_frm" runat="server">
        <asp:Button ID="btnFMbrs" CssClass="buttons" runat="server" Height="25px" Text="Tìm" OnClick="btnFMbrs_Click" />
        <asp:TextBox ID="txtFriends" CssClass="textbox" runat="server" Width="400px"></asp:TextBox>
    </div>
    <div id="value_frm" runat="server" visible="false">
        <asp:Button ID="btnReFind" CssClass="buttons" Visible="false" runat="server" Height="25px" Text="Tìm lại" OnClick="btnReFind_Click"/> 
        <asp:Button ID="btnChoose" CssClass="buttons" runat="server" Height="26px" Text="Chọn" OnClick="btnChoose_Click"/>
        <asp:DropDownList ID="cboFriends" CssClass="nwf" runat="server" Width="400px"></asp:DropDownList>
    </div>
</div>
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
<asp:LinkButton ID="btnReply" CssClass="buttons" runat="server" OnClick="btnReply_Click"  Font-Bold="false">Gửi tin nhắn</asp:LinkButton> 
</div>
<div class="sms_process">        
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">     
        <ProgressTemplate>
            <img style="" src="App_Themes/profile/loading.gif" />
        </ProgressTemplate>
        </asp:UpdateProgress>      
   </div>     
</div>