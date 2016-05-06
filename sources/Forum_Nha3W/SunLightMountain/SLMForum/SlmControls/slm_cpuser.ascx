<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_cpuser.ascx.cs" Inherits="SlmControls_slm_cpuser" %>
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
                        <table cellpadding="0" align="center" cellspacing="1" class="tblMost">
                            <tr>
                                <td class="TopMost2" align="center">
                                    <span class="MostLink"><%= LoadSLMF("SLMF_CPUser", "YourProfile")%></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid">
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="MostInfor2">
                                                <img class="imgMost" src="SlmImages/posted.gif" />&nbsp; <%= LoadSLMF("SLMF_Profile", "FullName")%>
                                                <asp:Label ID="lblFullName" runat="server" CssClass="MostInfor3"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="MostInfor2">
                                                <img class="imgMost" src="SlmImages/emailToAuthor.gif" />&nbsp; <%= LoadSLMF("SLMF_Profile", "Email")%>
                                                <asp:Label ID="lblEmail" runat="server" CssClass="MostInfor3"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="MostInfor2">
                                                <img class="imgMost" src="SlmImages/pr1.gif" />&nbsp; <%= LoadSLMF("SLMF_Profile", "JoinUs")%>
                                                <asp:Label ID="lblJoinUs" runat="server" CssClass="MostInfor3"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="MostInfor2">
                                                <img class="imgMost" src="SlmImages/pr2.gif" />&nbsp; <%= LoadSLMF("SLMF_Profile", "TotalPosts")%>
                                                <a id="hrefTotalPosts" runat="server" class="TitleLnk" ></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="MostInfor2">
                                                <img class="imgMost" src="SlmImages/pr4.gif" />&nbsp; <%= LoadSLMF("SLMF_Profile", "NewestPost")%>
                                                <asp:Label ID="lblLastPost" runat="server" CssClass="MostInfor3"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="MostInfor2">
                                                <img class="imgMost" src="SlmImages/pr5.gif" />&nbsp; <%= LoadSLMF("SLMF_Profile", "LastLogin")%>
                                                <asp:Label ID="lblLastLogin" runat="server" CssClass="MostInfor3"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="TopMost2" align="center">
                                    <span class="MostLink"><%= LoadSLMF("SLMF_Profile", "Signature")%></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid" align="center" style="padding-top:16px;padding-bottom:16px">
                                    <asp:Label ID="lblSign" runat="server" CssClass="MostInfor3"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>