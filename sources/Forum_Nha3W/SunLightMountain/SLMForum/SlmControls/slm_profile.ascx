<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_profile.ascx.cs" Inherits="SlmControls_slm_profile" %>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink"><%= LoadSLMF("WelHeader","ForumName") %></a>
            <span class="GetSpace"><%= LoadSLMF("SLMF_Forum", "Space")%></span><span class="RedLink2"><%= LoadSLMF("SLMF_Profile", "Personal")%></span>
        </td>
    </tr>
    <tr>
        <td class="regtd2"></td>
    </tr>
</table>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost" >
            <span class="reg2lblTitle"><%= LoadSLMF("SLMF_Profile", "Personal")%>: 
            <asp:Label ID="lblUserName" runat="server" ></asp:Label></span>
        </td>
    </tr>
    <tr>
        <td >
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="40%" valign="top">
                        <table cellpadding="0" align="center" cellspacing="1" class="tblMost">
                            <tr>
                                <td class="TopMost2" align="center">
                                    <asp:Label ID="lblUserName2" CssClass="MostUser" runat="server" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid" align="center" style="padding-bottom:8px;padding-top:8px">
                                    <img id="imgAvatar" src="../SlmImages/vCard.png" runat="server" /><br/><br/>
                                    <img id="imgRank" runat="server" /><br/>
                                    <asp:Label ID="lblAbout" CssClass="MostInfor5" runat="server" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="TopMost2" align="center">
                                    <span class="MostLink"><%= LoadSLMF("SLMF_Profile", "Information")%></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid">
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="21%" class="MostInfor">
                                                <%= LoadSLMF("SLMF_Profile", "FullName")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:Label ID="lblFullName" runat="server" CssClass="MostInfor3"></asp:Label>&nbsp;
                                                <img runat="server" id="imgGender" class="imgMost" src="../SlmImages/male.gif" />&nbsp;
                                                <a id="hrfPm" runat="server"><img class="imgMost" src="SlmImages/pm.gif" /></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="MostInfor">
                                                <%= LoadSLMF("SLMF_Profile", "Email")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:Label ID="lblEmail" runat="server" CssClass="MostInfor3"></asp:Label>&nbsp;
                                                <a id="hrfEmail" runat="server" ><img class="imgMost" src="SlmImages/emailToAuthor.gif" /></a>                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="MostInfor">
                                                <%= LoadSLMF("SLMF_Profile", "Birthday")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:Label ID="lblBirthday" runat="server" CssClass="MostInfor3"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="MostInfor">
                                                <%= LoadSLMF("SLMF_Profile", "HomePage")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <a id="hrfHome" runat="server" class="TopicLink"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="MostInfor">
                                                <%= LoadSLMF("SLMF_Profile", "Location")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:Label ID="lblLocation" runat="server" CssClass="MostInfor3"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="MostInfor">
                                                <%= LoadSLMF("SLMF_Profile", "Yahoo")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:Label ID="lblYahoo" runat="server" CssClass="MostInfor3"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="MostInfor">
                                                <%= LoadSLMF("SLMF_Profile", "MSN")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:Label ID="lblMsn" runat="server" CssClass="MostInfor3"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="MostInfor">
                                                <%= LoadSLMF("SLMF_Profile", "ICQ")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <a id="hrfIcq" runat="server" class="TopicLink"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="MostInfor">
                                                <%= LoadSLMF("SLMF_Profile", "AIM")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:Label ID="lblAim" runat="server" CssClass="MostInfor3"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="MostInfor">
                                                <%= LoadSLMF("SLMF_Profile", "Blog")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <a id="hrfBlog" runat="server" class="TopicLink"></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="MostInfor">
                                                <%= LoadSLMF("SLMF_Profile", "Interests")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:Label ID="lblInterests" runat="server" CssClass="MostInfor3"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="21%" class="MostInfor">
                                                <%= LoadSLMF("SLMF_Profile", "Job")%>
                                            </td>
                                            <td width="1%">
                                            </td>
                                            <td width="78%">
                                                <asp:Label ID="lblJob" runat="server" CssClass="MostInfor3"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="59%" valign="top">
                        <table cellpadding="0" align="center" cellspacing="1" class="tblMost">
                            <tr>
                                <td class="TopMost2" align="center">
                                    <span class="MostLink"><%= LoadSLMF("SLMF_Profile", "NewMessages")%></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid">
                                    <asp:Repeater ID="rptMessages" runat="server">
                                        <ItemTemplate>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="MostInfor3">
                                                        <img class="imgMost" src="SlmImages/posted.gif" /> 
                                                        <a href='<%# "showtopic.aspx?topicid=" + Eval("TopicId") %>' class="TitleLnk" id="hrfNewMsg" ><%# Eval("Title") %></a> 
                                                        <span class="TimeMessage"><%# System.DateTime.Parse(Eval("CreationDate").ToString()).Day + "/" + System.DateTime.Parse(Eval("CreationDate").ToString()).Month + "/" + System.DateTime.Parse(Eval("CreationDate").ToString()).Year + " " + System.DateTime.Parse(Eval("CreationDate").ToString()).ToLongTimeString()%></span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr>
                                <td class="TopMost2" align="center">
                                    <span class="MostLink"><%= LoadSLMF("SLMF_Profile", "Static")%></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid">
                                    <table width="100%" cellpadding="0" cellspacing="0">
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
                                                <img class="imgMost" src="SlmImages/pr3.gif" />&nbsp; <%= LoadSLMF("SLMF_Profile", "Online")%>
                                                <img id="imgOnline" runat="server" class="imgMost" src="../SlmImages/offline.gif" width="14" />
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