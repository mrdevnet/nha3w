<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_forgetpassword.ascx.cs" Inherits="SlmControls_slm_forgetpassword" %>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink"><%= LoadSLMF("WelHeader","ForumName") %></a>
        </td>
    </tr>
    <tr>
        <td class="regtd2"></td>
    </tr>
    <tr>
        <td class="regtd3">
            <table class="tblreg1" cellspacing="1" cellpadding="0">
                <tr>
                    <td class="reg2td1" colspan="2">
                        <span class="reg2lblTitle"><%= LoadSLMF("SLMF_LostPass", "Title")%></span>
                    </td>
                </tr>
                <tr>
                    <td class="reg2td3" >
                        <span class="reg2lblRegUser"><%= LoadSLMF("SLMF_LostPass", "UserName")%></span>
                    </td>
                    <td class="reg2td32">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="reg2txtUserName"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtUserName" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="reg2td3">
                        <span class="reg2lblRegUser"><%= LoadSLMF("SLMF_LostPass", "Email")%></span>
                    </td>
                    <td class="reg2td32">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="reg2txtUserName"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtEmail" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="reg2td3">
                        <span class="reg2lblRegUser"><%= LoadSLMF("SLMF_LostPass", "SecurityCode")%></span>
                    </td>
                    <td class="reg2td32">
                        <asp:TextBox ID="txtSecurity" runat="server" CssClass="reg2txtUserName"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtSecurity" ErrorMessage="*"></asp:RequiredFieldValidator> 
                        <img align="absmiddle" src="secrcode.aspx" oncontextmenu="return false" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="reg2td4" >
                        <asp:Button ID="btnLogIn" runat="server" CssClass="btnReg" OnClick="btnLogIn_Click" />&nbsp;&nbsp;
                        <img id="imgSpinner2" alt="" visible="true" src="../SlmImages/onepix1.jpg" runat="server"/>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlError" runat="server" >
            <table cellpadding="1" cellspacing="0" class="tblregErr">
                <tr>
                    <td colspan="2" class="reg2Error">
                        <asp:Label ID="lblError" runat="server" CssClass="regUserError"></asp:Label>
                    </td>
                </tr>
            </table>
            </asp:Panel>
        </td>
    </tr>
</table>