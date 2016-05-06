<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_cpeditpro.ascx.cs" Inherits="SlmControls_slm_cpeditpro" %>
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
                        <asp:UpdatePanel ID="updLogin" runat="server">
                        <ContentTemplate>
                        <table cellpadding="0" align="center" cellspacing="1" class="tblMost">
                            <tr>
                                <td class="TopMost2" align="center">
                                    <span class="MostLink"><%= LoadSLMF("SLMF_CPUser", "EditProfile")%></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid">
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "UserName")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <strong><asp:Label ID="lblUserName2" runat="server" CssClass="MostInfor3"></asp:Label></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "FullName")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtFullName" runat="server" CssClass="editprotxt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "MemberTitle")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtMemberTitle" runat="server" CssClass="editprotxt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "Email")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="editprotxt"></asp:TextBox> 
                                                <asp:CheckBox ID="ckbEmail" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "CanSendE")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:CheckBox ID="ckbCanSendE" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "Gender")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:DropDownList ID="ddlGender" runat="server"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "Birthday")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"></asp:DropDownList>&nbsp;
                                                <asp:DropDownList ID="ddlDay" runat="server"></asp:DropDownList>&nbsp;
                                                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_RssFeed", "MyRss")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtMyRss" runat="server" CssClass="editprotxt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="90%" colspan="3" style="padding:5px">
                                            <hr noshade size="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "Website")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="editprotxt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "Location")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtLocation" runat="server" CssClass="editprotxt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "Yahoo")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtYahoo" runat="server" CssClass="editprotxt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="90%" colspan="3" style="padding:5px">
                                            <hr noshade size="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "Blog")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtBlog" runat="server" CssClass="editprotxt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "MSN")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtMsn" runat="server" CssClass="editprotxt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "ICQNumber")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtIcq" runat="server" CssClass="editprotxt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "AOL")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtAol" runat="server" CssClass="editprotxt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="90%" colspan="3" style="padding:5px">
                                            <hr noshade size="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "Job")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtJob" runat="server" CssClass="editprotxt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "Interests")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtInterests" runat="server" CssClass="editprotxt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro">
                                                <%= LoadSLMF("SLMF_EditPro", "AboutMe")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:TextBox ID="txtAboutMe" TextMode="MultiLine" runat="server" CssClass="editprotxt2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="90%" colspan="3" style="padding:5px">
                                            <hr noshade size="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="EditPro"></td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:Button CssClass="btnReg" ID="btnSave" runat="server" OnClick="btnSave_Click" />
                                                &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="../SlmImages/onepix1.jpg" runat="server"/> 
                                                <asp:Label ID="lblReport" runat="server" CssClass="editprore"></asp:Label>
                                                <script type="text/javascript"  language="Javascript">
                                                function GetSlmEnc()
                                                {
                                                document.aspnetForm["ctl00_slmf1_Slm_cpeditpro1_imgSpinner2"].src = "SlmImages/progress.gif";
                                                document.aspnetForm["ctl00_slmf1_Slm_cpeditpro1_imgSpinner2"].visible = true;
                                                document.aspnetForm["ctl00_slmf1_Slm_cpeditpro1_imgSpinner2"].width = "16";
                                                document.aspnetForm["ctl00_slmf1_Slm_cpeditpro1_imgSpinner2"].height = "16";
                                                }
                                                </script>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="height:8px"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="ddlMonth" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlYear" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>