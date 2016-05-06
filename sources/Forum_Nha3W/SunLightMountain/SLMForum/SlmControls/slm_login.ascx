<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_login.ascx.cs" Inherits="SlmControls_slm_login" %>
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
            <asp:UpdatePanel ID="updLogin" runat="server">
            <ContentTemplate>
            <table class="tblreg1" cellspacing="1" cellpadding="0">
                <tr>
                    <td class="reg2td1" colspan="2">
                        <span class="reg2lblTitle"><%= LoadSLMF("SLMF_Log", "Title")%></span>
                    </td>
                </tr>
                <tr>
                    <td class="reg2td3" >
                        <span class="reg2lblRegUser"><%= LoadSLMF("SLMF_Log", "UserName")%></span>
                    </td>
                    <td class="reg2td32">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="reg2txtUserName"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="reg2td3">
                        <span class="reg2lblRegUser"><%= LoadSLMF("SLMF_Reg", "Password")%></span>
                    </td>
                    <td class="reg2td32">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="reg2txtUserName" TextMode="Password"></asp:TextBox>
                        <script type="text/javascript"  language="Javascript">
                            function GetSlmEnc()
                            {
                                document.aspnetForm["ctl00_slmf1_Slm_login1_imgSpinner2"].src = "SlmImages/progress.gif";
                                document.aspnetForm["ctl00_slmf1_Slm_login1_imgSpinner2"].visible = true;
                                document.aspnetForm["ctl00_slmf1_Slm_login1_imgSpinner2"].width = "16";
                                document.aspnetForm["ctl00_slmf1_Slm_login1_imgSpinner2"].height = "16";
                                
                                var txt3 = document.aspnetForm["ctl00_slmf1_Slm_login1_txtPassword"];
                                var txt4 = document.aspnetForm["ctl00_slmf1_Slm_login1_slmhas"];
                                
                                txt4.value = MD5(txt3.value);
                                document.aspnetForm["ctl00_slmf1_Slm_login1_slmhas"].value = txt4.value;
                            }
                        </script>
                        <asp:HiddenField ID="slmhas" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="reg2td3">
                        <span class="reg2lblRegUser"><%= LoadSLMF("SLMF_Log", "AutoLog")%></span>
                    </td>
                    <td class="reg2td32">
                        <asp:CheckBox ID="ckbRemember" runat="server" Checked="true"  BorderColor="#4C77B6" BorderWidth="1px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlSecurity" runat="server" >
                        <table cellpadding="0" cellspacing="1" class="tblreg1">
                            <tr>
                                <td colspan="2" class="reg2td2" align="center">
                                    <span class="reg2lblRegUser"><%= LoadSLMF("SLMF_Log", "SecurTitle")%></span>
                                </td>                    
                            </tr>
                            <tr>
                                <td class="reg2td3">
                                    <span class="reg2lblRegUser"><%= LoadSLMF("SLMF_Log", "Security")%></span>
                                </td>                    
                                <td class="reg2td32">
                                    <asp:TextBox ID="txtSecurity" runat="server" CssClass="reg2txtUserName"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblSecuText" runat="server" CssClass="regSecurity"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="reg2td4" >
                        <asp:Button ID="btnLogIn" runat="server" CssClass="btnReg" OnClick="btnLogIn_Click" />&nbsp;&nbsp;<asp:Button ID="btnLostPass" runat="server" CssClass="btnReg" OnClick="btnLostPass_Click" />
                        &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="../SlmImages/onepix1.jpg" runat="server"/>
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
            </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>