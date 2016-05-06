<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_signature.ascx.cs" Inherits="SlmControls_slm_signature" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink"><%= LoadSLMF("WelHeader","ForumName") %></a>
            <span class="GetSpace"><%= LoadSLMF("SLMF_Forum", "Space")%></span><span class="RedLink2"><%= LoadSLMF("SLMF_CPUser", "ControlPanel")%></span>
        </td>
    </tr>
    <tr>
        <td class="regtd2"></td>
    </tr>
</table>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost" >
            <span class="reg2lblTitle"><%= LoadSLMF("SLMF_CPUser", "YourProfile")%>: 
            <asp:Label ID="lblUserName" runat="server" ></asp:Label></span>
        </td>
    </tr>
    <tr>
        <td >
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="19%" valign="top">
                        <table cellpadding="0" align="center" cellspacing="1" class="tblMost">
                            <tr>
                                <td class="TopMost2" align="center">
                                    <a href="profile.aspx"><span class="MostLink"><%= LoadSLMF("SLMF_Profile", "Personal")%></span></a>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid">
                                    <a href="editprofile.aspx" class="editpro"><%= LoadSLMF("SLMF_CPUser", "EditProfile")%></a><br />
                                    <a href="editavatar.aspx" class="editpro"><%= LoadSLMF("SLMF_CPUser", "EditAvatar")%></a>
                                </td>
                            </tr>
                            <tr>
                                <td class="TopMost2" align="center">
                                    <span class="MostLink"><%= LoadSLMF("SLMF_CPUser", "PersonalMessage")%></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid">
                                    <a href="pm.aspx?id=0" class="editpro"><%= LoadSLMF("SLMF_CPUser", "PmInbox")%></a><br />
                                    <a href="pm.aspx?id=1" class="editpro"><%= LoadSLMF("SLMF_CPUser", "PmSent")%></a><br />
                                    <a href="pm.aspx?id=2" class="editpro"><%= LoadSLMF("SLMF_CPUser", "PmNew")%></a>
                                    <%--<br /><a href="em.aspx" class="editpro"><%= LoadSLMF("SLMF_CPUser", "EmailNew")%></a>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="TopMost2" align="center">
                                    <span class="MostLink"><%= LoadSLMF("SLMF_CPUser", "Options")%></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid">
                                    <a href="signature.aspx" class="editpro"><%= LoadSLMF("SLMF_CPUser", "Signature")%></a>
                                    <%--<br /><a href="changepassword.aspx" class="editpro"><%= LoadSLMF("SLMF_ChangePassword", "ChangePass")%></a>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="80%" valign="top">
                    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>--%>
                            <table cellpadding="0" align="center" cellspacing="1" class="tblMost">
                                <tr>
                                    <td class="TopMost2" align="center">
                                        <span class="MostLink"><%= LoadSLMF("SLMF_CPUser", "Signature")%></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Mid">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="90%" colspan="3" height="4">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="100%" colspan="3">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <FCKeditorV2:FCKeditor ID="txtReplyMsg" 
                                                                    BasePath="~/FCKeditor/" 
                                                                    ToolbarSet="F9Signature" 
                                                                    Height="178px" 
                                                                    AutoDetectLanguage="false" 
                                                                    DefaultLanguage="en" 
                                                                    SkinPath= 'skins/silver/' 
                                                                    runat="server">
                                                                </FCKeditorV2:FCKeditor>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <script type="text/javascript"  language="Javascript">
                                                    function GetSlmEnc3()
                                                    {
                                                    document.aspnetForm["ctl00_slmf1_Slm_signature1_img3"].src = "SlmImages/progress.gif";
                                                    document.aspnetForm["ctl00_slmf1_Slm_signature1_img3"].visible = true;
                                                    document.aspnetForm["ctl00_slmf1_Slm_signature1_img3"].width = "16";
                                                    document.aspnetForm["ctl00_slmf1_Slm_signature1_img3"].height = "16";
                                                    }
                                                </script>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="100%" colspan="3" align="center">
                                                    <asp:CheckBox ID="ckbSignature" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="90%" colspan="3" height="4">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" width="90%" colspan="3" style="padding-left:5px;padding-right:5px">
                                                    <img id="img3" alt="" visible="true" src="../SlmImages/onepix1.jpg" runat="server"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="90%" colspan="3" style="padding-left:5px;padding-right:5px">
                                                <hr noshade size="1">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="100%" colspan="3" align="center">
                                                    <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" /> 
                                                    <asp:Label runat="server" ID="lblSendaNew" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="90%" colspan="3" height="4">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <%--</ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSend" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>