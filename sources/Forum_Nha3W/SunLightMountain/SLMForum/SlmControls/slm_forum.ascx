<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_forum.ascx.cs" Inherits="SlmControls_slm_forum" %>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <table style="width:100%">
                <tr>
                    <td style="text-align:left;width:60%">
                        <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink" ><%= LoadSLMF("WelHeader","ForumName") %></a>
                        <span class="GetSpace"><asp:Label ID="lblSpace" runat="server" ><%= LoadSLMF("SLMF_Forum", "Space")%></asp:Label></span>
                        <asp:Label ID="lblGroupName" runat="server" CssClass="RedLink2" ></asp:Label>
                    </td>
                    <%--<asp:Panel ID="pnlFastLog" runat="server">
                    <td style="text-align:right;width:40%">
                        <img style="vertical-align:middle" src="slmimages/user.png"/> <asp:TextBox Width="70px" ID="txtUser" runat="server" CssClass="reg2txtUserName"></asp:TextBox> 
                        <img style="vertical-align:middle" src="slmimages/key.png"/> <asp:TextBox Width="70px" ID="txtPass" runat="server" CssClass="reg2txtUserName" TextMode="Password"></asp:TextBox> 
                        <img style="vertical-align:middle" src="slmimages/user_add.png"/><asp:CheckBox ID="ckbRemember" runat="server" Checked="true"/> 
                        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click"/>
                        <script type="text/javascript"  language="Javascript">
                            function GetSlmEnc()
                            {
                                var txt3 = document.aspnetForm["ctl00_slmf1_Slm_forum1_txtPass"];
                                var txt4 = document.aspnetForm["ctl00_slmf1_Slm_forum1_slmhas"];
                                txt4.value = MD5(txt3.value);
                                document.aspnetForm["ctl00_slmf1_Slm_forum1_slmhas"].value = txt4.value;
                            }
                        </script>
                        <asp:HiddenField ID="slmhas" runat="server" />
                        <asp:RequiredFieldValidator Font-Names="Arial" Font-Size="11px" Display="Dynamic" ControlToValidate="txtUser" ID="rfv1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator Font-Names="Arial" Font-Size="11px" Display="Dynamic" ControlToValidate="txtPass" ID="rfv2" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    </asp:Panel>--%>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="regtd2"></td>
    </tr>
    <tr>
        <td class="tblforum">
            <table cellpadding="0" cellspacing="1" class="forum" >
                <asp:Repeater ID="rptCategory" runat="server" OnItemDataBound="rptCategory_ItemDataBound">
                    <HeaderTemplate>
                        <tr>
                            <td class="hforum1" ></td>
                            <td class="hforum12">
                                <%= LoadSLMF("SLMF_Forum", "Forum")%>
                            </td>
                            <td class="hforum13" >
                                <%= LoadSLMF("SLMF_Forum", "Topics")%>
                            </td>
                            <td class="hforum14" >
                                <%= LoadSLMF("SLMF_Forum", "Posts")%>
                            </td>
                            <td class="hforum15" >
                                <%= LoadSLMF("SLMF_Forum", "LastPost")%>
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="forum2" colspan="5" >
                                <img src="SlmImages/icon2.gif" alt="" class="imgCategory"/>
                                <a href='<%# "forumdisplay.aspx?groupid=" + Eval("CategoryId")  %>' class="CategoryLink" ><%# Eval("CateName") %></a>
                            </td>
                        </tr>
                        <asp:Repeater ID="rptForum" runat="server" OnItemDataBound="rptForum_ItemDataBound" >
                            <ItemTemplate>
                                <tr class="forumshow">
                                    <td >
                                        <img runat="server" id="ifrm" src="../SlmImages/topic.gif" alt="" class="imgForum" />
                                    </td>
                                    <td class="ForumDescript">
                                        <a class="ForumLink" href='<%# "topicdisplay.aspx?forumid=" +  Eval("ForumId") %>' ><%# Eval("Name") %></a>&nbsp;&nbsp;<asp:Label CssClass="fontmsg" ID="lblViewing" runat="server"></asp:Label>
                                        <asp:Label CssClass="ForumDetails" ID="lblDescription" runat="server" Text='<%# "<br/>" + Eval("Description") + "<br/>" %>'></asp:Label>
                                        <asp:Repeater ID="rptModerator" runat="server" >
                                            <HeaderTemplate>
                                                <span class="ModerTitle"><%= LoadSLMF("SLMF_Forum", "Moderator")%></span>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <a class="TopicLink" id="hrfModer" runat="server" href='<%# "../showprofile.aspx?memberid=" + Eval("MemberId") %>' ><%# Eval("UserName") %></a>
                                            </ItemTemplate>
                                            <SeparatorTemplate>,</SeparatorTemplate>
                                            <FooterTemplate><br /></FooterTemplate>
                                        </asp:Repeater>
                                        <asp:Repeater ID="rptSubForum" runat="server" >
                                            <HeaderTemplate>
                                                <hr noshade size="1">
                                                <span class="ModerTitle"><%= LoadSLMF("SLMF_Forum", "SubForum")%></span>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <img src="SlmImages/icon_file.gif" class="imgBorderW1"/> <a class="TopicLink" title='<%# "[" + GetTextTotal("TotalTocpicSub") + Eval("TotalTopics") + ", " + GetTextTotal("TotalMessSub") + Eval("TotalMessages") + "]" %>' href='<%# "../topicdisplay.aspx?forumid=" + Eval("ForumId") %>' id="hrfSubForum"  runat="server"><%# Eval("Name").ToString().Trim() %></a>
                                            </ItemTemplate>
                                            <SeparatorTemplate>,</SeparatorTemplate>
                                        </asp:Repeater>
                                    </td>
                                    <td class="forumshow1">
                                        <asp:Label ID="lblTotalTopics" runat="server" ></asp:Label>
                                    </td>
                                    <td class="forumshow1">
                                        <asp:Label ID="lblTotalMessages" runat="server" ></asp:Label>
                                    </td>
                                    <td class="forumtocpic">
                                        <a class="TopicLink" id="hrfMessage" runat="server" ></a>
                                        <asp:Label CssClass="TimeMessage" ID="lblTime" runat="server" ></asp:Label>
                                        <a class="TopicLink" id="hrfMember" runat="server" ></a> <a id="hrfnewm" runat="server" class="TopicLink"><img src="SlmImages/icon_latest_reply.gif" class="imgBorderW" /></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </td>
    </tr>
    <tr>
        <td class="static2"></td>
    </tr>
    <tr>
        <td class="tblforum">
            <table cellpadding="0" cellspacing="1" class="forum" >
                <tr >
                    <td colspan="2" class="statictis">
                        &nbsp;<asp:ImageButton ImageUrl="../SlmImages/collapse.gif" runat="server" ID="openStatis" BorderWidth="0" ImageAlign="AbsBottom" /> 
                        <%= LoadSLMF("SLMF_Forum", "Statistic")%>
                    </td>
                </tr>
                <tr>
                    <td class="forum2" colspan="2">
                        &nbsp;<%= LoadSLMF("SLMF_Forum", "UserOnline")%>
                    </td>
                </tr>
                <tr>
                    <td class="forumshow" width="1%">
                        <img src="SlmImages/folder_who.png" class="imgForum" alt="" />
                    </td>
                    <td class="ListActiveUser">
                        <asp:Label runat="server" ID="activeuser" /><br />
                        <asp:Repeater runat="server" ID="listuser" OnItemDataBound="listuser_ItemDataBound" Visible="false">
                            <ItemTemplate>
                                <a runat="server" id="hrfUserOnline" class="TopicLink"></a>
                            </ItemTemplate>
                            <SeparatorTemplate>,</SeparatorTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td class="forum2" colspan="2">
                        &nbsp;<%= LoadSLMF("SLMF_Forum", "Stats")%>
                    </td>
                </tr>
                <tr>
                    <td class="forumshow" width="1%">
                        <img src="SlmImages/stats.gif" class="imgForum" alt="" />
                    </td>
                    <td class="ListActiveUser">
                        <asp:Label ID="stats" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="tblforum">
            <table width="100%">
                <tr>
                    <td height="3px"></td>
                </tr>
                <tr>
                    <td class="iconnewpost">
                        <img align="middle" src="SlmImages/topic_new.png" alt='<%= LoadSLMF("SLMF_Forum", "ForumNDesc")%>' />
                            <%= LoadSLMF("SLMF_Forum", "ForumN")%>&nbsp;
                        <img align="middle" src="SlmImages/topic.gif" alt='<%= LoadSLMF("SLMF_Forum", "ForumN2Desc")%>' />
                            <%= LoadSLMF("SLMF_Forum", "ForumN2")%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>