<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_cpeditavatar.ascx.cs" Inherits="SlmControls_slm_cpeditavatar" %>
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
                                    <span class="MostLink"><%= LoadSLMF("SLMF_CPUser", "EditAvatar")%></span>
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
                                                <%= LoadSLMF("SLMF_Avatar", "Avatar")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <img id="imgAvatar" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="90%" colspan="3" style="padding:5px">
                                            <hr noshade size="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%" colspan="3" style="padding-left:26px">
                                                <asp:RadioButton ID="rbtChoose1" runat="server" GroupName="Avar"/> 
                                                <%= LoadSLMF("SLMF_Avatar", "Category")%> 
                                                <asp:DropDownList ID="ddlAvatars" DataTextField="Descriptions" DataValueField="CategoryId" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAvatars_SelectedIndexChanged"></asp:DropDownList>
                                                &nbsp;&nbsp;<img id="imgAvaSpin" alt="" visible="true" src="../SlmImages/onepix1.jpg" runat="server"/> 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%" colspan="3">
                                                <table width="100%">
                                                    <tr>
                                                        <td class="EditAvatar">
                                                            <asp:DataList Width="100%" ID="dtlAvatars" runat="server" RepeatColumns="8">
                                                                <ItemTemplate>
                                                                    <a href="<%# "javascript:void(selectAvatar('" + Eval("Avatar") + "'))"%>">
                                                                        <img width="60px" border="0" src='<%# "slmuploads/avatar/" + Eval("Avatar")%>'/>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <script type="text/javascript"  language="Javascript">
                                                    function selectAvatar(s)
                                                    {
                                                        document.aspnetForm["ctl00_slmf1_Slm_cpeditavatar1_imgAvatar"].src = "slmuploads/avatar/" + s;
                                                        document.aspnetForm["ctl00_slmf1_Slm_cpeditavatar1_hddAva"].value = s;
                                                    }
                                                </script>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="90%" colspan="3" style="padding:5px">
                                            <hr noshade size="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%" colspan="3" style="padding-left:26px">
                                                <asp:RadioButton ID="rbtChoose2" runat="server" GroupName="Avar"/> 
                                                <%= LoadSLMF("SLMF_Avatar", "Url")%> 
                                                <asp:TextBox ID="txtUrl" runat="server" CssClass="editavartxt"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="90%" colspan="3" style="padding:5px">
                                            <hr noshade size="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%" align="center" colspan="3">
                                                <asp:Button CssClass="btnReg" ID="btnSave" runat="server" OnClick="btnSave_Click" />
                                                &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="../SlmImages/onepix1.jpg" runat="server"/> 
                                                <asp:Label ID="lblReport" runat="server" CssClass="editprore"></asp:Label>
                                                <script type="text/javascript"  language="Javascript">
                                                function GetSlmEnc()
                                                {
                                                document.aspnetForm["ctl00_slmf1_Slm_cpeditavatar1_imgSpinner2"].src = "SlmImages/progress.gif";
                                                document.aspnetForm["ctl00_slmf1_Slm_cpeditavatar1_imgSpinner2"].visible = true;
                                                document.aspnetForm["ctl00_slmf1_Slm_cpeditavatar1_imgSpinner2"].width = "16";
                                                document.aspnetForm["ctl00_slmf1_Slm_cpeditavatar1_imgSpinner2"].height = "16";
                                                }
                                                function GetSlmEnc2()
                                                {
                                                document.aspnetForm["ctl00_slmf1_Slm_cpeditavatar1_imgAvaSpin"].src = "SlmImages/progress.gif";
                                                document.aspnetForm["ctl00_slmf1_Slm_cpeditavatar1_imgAvaSpin"].visible = true;
                                                document.aspnetForm["ctl00_slmf1_Slm_cpeditavatar1_imgAvaSpin"].width = "16";
                                                document.aspnetForm["ctl00_slmf1_Slm_cpeditavatar1_imgAvaSpin"].height = "16";
                                                }
                                                </script>
                                                <input runat="server" id="hddAva" type="hidden"/>
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
                            <asp:AsyncPostBackTrigger ControlID="ddlAvatars" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>