<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_register.ascx.cs" Inherits="SlmControls_slm_register" %>
<script type="text/javascript">
    function Spinner() 
    {
        document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinner"].src = "SlmImages/progress.gif";
        document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinner"].visible = true;
        document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinner"].width = "16";
        document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinner"].height = "16";
    }
</script>
<script type="text/javascript">
    function Spinner1() 
    {
        document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinner1"].src = "SlmImages/progress.gif";
        document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinner1"].visible = true;
        document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinner1"].width = "16";
        document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinner1"].height = "16";
    }
    
    function reloadscr()
    {
        document.getElementById("ctl00_slmf1_Slm_register1_imgSecr").src = "secrcode.aspx";
        document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinner1"].src = "SlmImages/progress.gif";
        document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinner1"].visible = true;
        document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinner1"].width = "16";
        document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinner1"].height = "16";
        return false;
    }
</script>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink"><%= LoadTitle("WelHeader", "ForumName")%></a>
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
                        <span class="reg2lblTitle"><%= LoadTitle("SLMF_Reg", "Title")%></span>
                    </td>
                </tr>
                <tr>
                    <td class="reg2td2" colspan="2" align="center">
                        <%= LoadTitle("SLMF_Reg", "Details")%>
                    </td>
                </tr>
                <tr>
                    <td class="reg2td3" >
                        <span class="reg2lblRegUser"><%= LoadTitle("SLMF_Reg", "UserName")%></span>
                    </td>
                    <td class="reg2td32">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="reg2txtUserName"></asp:TextBox>&nbsp;&nbsp;
                        <asp:LinkButton ID="lbtCheck" runat="server" CssClass="Refresh" OnClick="lbtCheck_Click"></asp:LinkButton>&nbsp;
                        <img id="imgSpinner" alt="" visible="true" src="../SlmImages/onepix1.jpg" runat="server"/><asp:Label ID="lblUserExist" runat="server" CssClass="regUserExists"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="reg2td3">
                        <span class="reg2lblRegUser"><%= LoadTitle("SLMF_Reg", "Password")%></span>                        
                    </td>
                    <td class="reg2td32">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="reg2txtUserName" TextMode="Password"></asp:TextBox>
                        <script type="text/javascript"  language="Javascript">
                            function GetSlmEnc()
                            {
                                document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinReg"].src = "SlmImages/progress.gif";
                                document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinReg"].visible = true;
                                document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinReg"].width = "16";
                                document.aspnetForm["ctl00_slmf1_Slm_register1_imgSpinReg"].height = "16";
                                
                                var txt3 = document.aspnetForm["ctl00_slmf1_Slm_register1_txtPassword"];
                                var txt4 = document.aspnetForm["ctl00_slmf1_Slm_register1_slmhas"];
                                
                                txt4.value = MD5(txt3.value);
                                document.aspnetForm["ctl00_slmf1_Slm_register1_slmhas"].value = txt4.value;
                            }
                        </script>
                        <asp:HiddenField ID="slmhas" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="reg2td3">
                        <span class="reg2lblRegUser"><%= LoadTitle("SLMF_Reg", "ReEnterPass")%></span>
                    </td>
                    <td class="reg2td32">
                        <asp:TextBox ID="txtPassword2" runat="server" CssClass="reg2txtUserName" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="reg2td3">
                        <span class="reg2lblRegUser"><%= LoadTitle("SLMF_Reg", "Email")%></span>
                    </td>
                    <td class="reg2td32">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="reg2txtUserName"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="reg2td2" align="center">
                        <%= LoadTitle("SLMF_Reg", "Profile")%>
                    </td>                    
                </tr>
                <tr>
                    <td class="reg2td3">
                        <span class="reg2lblRegUser"><%= LoadTitle("SLMF_Reg", "FullName")%></span>
                    </td>
                    <td class="reg2td32">
                        <asp:TextBox ID="txtFullName" runat="server" CssClass="reg2txtUserName"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="reg2td3">
                        <span class="reg2lblRegUser"><%= LoadTitle("SLMF_Reg", "Location")%></span>
                    </td>
                    <td class="reg2td32">
                        <asp:TextBox ID="txtLocation" runat="server" CssClass="reg2txtUserName"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="reg2td3">
                        <span class="reg2lblRegUser"><%= LoadTitle("SLMF_Reg", "Website")%></span>
                    </td>
                    <td class="reg2td32">
                        <asp:TextBox ID="txtWebsite" runat="server" CssClass="reg2txtUserName"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="reg2td2" align="center">
                        <%= LoadTitle("SLMF_Reg", "SecurTitle")%>
                    </td>                    
                </tr>
                <tr>
                    <td class="reg2td3">
                        <span class="reg2lblRegUser"><%= LoadTitle("SLMF_Reg", "Security")%></span>
                    </td>                    
                    <td class="reg2td32">
                        <asp:TextBox ID="txtSecurity" runat="server" CssClass="reg2txtUserName"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                        <img alt="Refresh code image" runat="server" id="imgSecr" align="absmiddle" src="../secrcode.aspx" oncontextmenu="return false" />&nbsp;&nbsp;
                        <%--<input id="iptRefresh" onclick="return reloadscr();" type="submit" value="<%= LoadTitle("SLMF_Reg", "Refresh")%>"/>--%>
                        <asp:LinkButton ID="lbtRefresh" runat="server" CssClass="Refresh" ><%= LoadTitle("SLMF_Reg", "Refresh")%></asp:LinkButton>
                        <%--<a id="hrfRefresh" href="javascript:reloadscr();" class="Refresh"><%= LoadTitle("SLMF_Reg", "Refresh")%></a>--%>
                        <%--<asp:LinkButton ID="lbtRefresh" OnClientClick="reloadscr();" runat="server" CssClass="Refresh" ></asp:LinkButton>--%>
                        &nbsp;<img id="imgSpinner1" alt="" visible="true" src="../SlmImages/onepix1.jpg" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="reg2td4" >
                        <asp:Button ID="btnRegister" runat="server" CssClass="btnReg" OnClick="btnRegister_Click" />
                        &nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="btnReg" OnClick="btnCancel_Click" />
                        &nbsp;&nbsp;&nbsp;<img id="imgSpinReg" alt="" visible="true" src="../SlmImages/onepix1.jpg" runat="server"/>
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