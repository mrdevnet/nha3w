<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_changepass.ascx.cs" Inherits="SlmControls_slm_changepass" %>
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
                                    <a href="signature.aspx" class="editpro"><%= LoadSLMF("SLMF_CPUser", "Signature")%></a><br />
                                    <a href="changepassword.aspx" class="editpro"><%= LoadSLMF("SLMF_ChangePassword", "ChangePass")%></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="80%" valign="top">
                        <asp:UpdatePanel ID="updLogin" runat="server">
                        <ContentTemplate>
                        <table cellpadding="0" align="center" cellspacing="1" class="tblMost">
                            <tr>
                                <td class="TopMost2" align="center">
                                    <span class="MostLink"><%= LoadSLMF("SLMF_ChangePassword", "ChangePass")%></span>
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
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_ChangePassword", "OldPassword")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtOldPass" TextMode="Password" runat="server" CssClass="editprotxt"></asp:TextBox> 
                                                <asp:RequiredFieldValidator ID="rfv1" ControlToValidate="txtOldPass" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="90%" colspan="3" height="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_ChangePassword", "NewPassword")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" CssClass="editprotxt"></asp:TextBox> 
                                                <asp:RequiredFieldValidator ID="rfv2"  ControlToValidate="txtNewPass" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="90%" colspan="3" height="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_ChangePassword", "NewPasswordConfirm")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtNewPassConfirm" TextMode="Password" runat="server" CssClass="editprotxt"></asp:TextBox> 
                                                <asp:RequiredFieldValidator ID="rfv3" ControlToValidate="txtNewPassConfirm" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator> 
                                                <asp:CompareValidator ID="cv1"  ControlToValidate="txtNewPass" ControlToCompare="txtNewPassConfirm" runat="server" ErrorMessage="*"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="90%" colspan="3" height="4">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="90%" colspan="3" style="padding-left:5px;padding-right:5px">
                                            <hr noshade size="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" /> 
                                                <asp:Label runat="server" ID="lblSendaNew" ></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%" colspan="3" align="center"></td>
                                        </tr>
                                        <tr>
                                            <td width="90%" colspan="3" height="4">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSend" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>