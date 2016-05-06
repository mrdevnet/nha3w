<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_topic.ascx.cs" Inherits="SlmControls_slm_topic" %>
<%@ Register Assembly="ASPnetPagerV2netfx2_0" Namespace="CutePager" TagPrefix="cc1" %>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink"><%= LoadSLMF("WelHeader","ForumName") %></a>
            <span class="GetSpace"><%= LoadSLMF("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="hplCategory" ></a>
            <span runat="server" visible="false" id="parf2" class="GetSpace"><%= LoadSLMF("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="hplCategory2" ></a>
            <span class="GetSpace"><%= LoadSLMF("SLMF_Forum", "Space")%></span><asp:Label ID="lblGroupName" runat="server" CssClass="RedLink2" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="regtd2"></td>
    </tr>
    <tr>
        <td class="tblforum">
            <table cellpadding="0" cellspacing="1" class="forum" >
                <asp:Repeater ID="rptForumParent" runat="server" OnItemDataBound="rptForumParent_ItemDataBound" >
                    <HeaderTemplate>
                        <tr>
                            <td class="hforum1" ></td>
                            <td class="hforum12">
                                <%= LoadSLMF("SLMF_Forum", "SubTile")%><%= lblAnnountCate.Text.ToString()%>
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
                        <tr>
                            <td class="forum3" colspan="5" ></td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Repeater ID="rptForumSub" runat="server" OnItemDataBound="rptForumSub_ItemDataBound"  >
                            <ItemTemplate>
                                <tr class="forumshow">
                                    <td >
                                        <img runat="server" id="iconSub" src="../SlmImages/topic.gif" alt="" class="imgForum" />
                                    </td>
                                    <td class="ForumDescript">
                                        <a class="ForumLink" href='<%# "topicdisplay.aspx?forumid=" +  Eval("ForumId") %>' ><%# Eval("Name") %></a>
                                        <asp:Label CssClass="ForumDetails" ID="lblDescription" runat="server" Text='<%# "<br/>" + Eval("Description") + "<br/>" %>'></asp:Label>
                                        <asp:Repeater ID="rptModerator" runat="server" >
                                            <HeaderTemplate>
                                                <span class="ModerTitle"><%= LoadSLMF("SLMF_Forum", "Moderator")%></span>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <a class="TopicLink" id="hrfModer" runat="server" href='<%# "../showprofile.aspx?memberid=" + Eval("MemberId") %>' ><%# Eval("UserName") %></a>
                                            </ItemTemplate>
                                            <SeparatorTemplate>, </SeparatorTemplate>
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
    <asp:Panel runat="server" ID="pnlHeight1" Visible="false">
    <tr>
        <td class="regtd2"></td>
    </tr>
    </asp:Panel>
    <tr>
        <td class="tblforum">
            <asp:Panel ID="pnlAnnounce" runat="server" >
            <table cellpadding="0" cellspacing="1" class="forum" >
                <tr>
                    <td class="announce" ></td>
                    <td class="announce2" colspan="2">
                        <%= LoadSLMF("SLMF_Forum", "AnnounceTitle")%><asp:Label ID="lblAnnountCate" runat="server" ></asp:Label>
                    </td>
                </tr>
                <asp:Repeater ID="rptAnnouncement" runat="server" >
                    <ItemTemplate>
                        <tr class="forumshow">
                            <td >
                                <img src='<%# IconAnnounce(DateTime.Parse(Eval("StartDate").ToString()))%>' alt="" class="imgForum" />
                            </td>
                            <td class="ForumDescript">
                                <span class="AnnounceTitle"><%= LoadSLMF("SLMF_Forum", "Announcement")%></span><a class="ForumLink" href='<%# "announcement.aspx?announceid=" +  Eval("ReportId") %>' ><%# Eval("Title") %></a><br />
                                <a class="TopicLink" href='<%# "showprofile.aspx?memberid=" + Eval("MemberId") %>'><%# Eval("UserName") %></a>
                            </td>
                            <td class="forumannounce3" >
                                <%= LoadSLMF("SLMF_Forum", "AnnounceViews")%><asp:Label ID="lblView" runat="server" Text='<%# Eval("TotalViews") %>'></asp:Label>
                                 <a class="TopicLink" href='<%# "announcement.aspx?announceid=" +  Eval("ReportId") %>' title="<%= LoadSLMF("SLMF_Forum", "ShowAnnouncement")%>"><img src="SlmImages/icon_latest_reply.gif" class="imgBorderW"/></a><br />
                                <asp:Label CssClass="TimeMessage" ID="lblPostTime" runat="server" Text='<%# AnnounceTime(DateTime.Parse(DataBinder.Eval(Container.DataItem, "StartDate").ToString())) %>' ></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            </asp:Panel>
        </td>
    </tr>
    <asp:Panel runat="server" ID="pnlHeight2" Visible="false">
    <tr>
        <td class="HeightTopic"></td>
    </tr>
    </asp:Panel>
    <tr>
        <td class="topic1">
            <table class="tblTopic1" cellspacing="0" cellpadding="0" >
                <tr>
                    <td class="linkPager" align="left">
                        <cc1:Pager ID="TMessage1" runat="server" PageSize="20" OfClause="/" BackToFirstClause="Trang đầu" GoToLastClause="Trang cuối" ShowFirstLast="true" PageClause="Trang" BackToPageClause="Trang trước:" NextToPageClause="Tiếp theo:" ShowingResultClause="Bài viết" ShowResultClause="Bài viết" ToClause="đến" OnCommand="TMessage1_Command" />
                    </td>
                    <td align="right">
                        <asp:LinkButton ID="moderatorf" runat="server" CssClass="linkButton" />
                        <a href='newtopic.aspx?post=newtopic&forumid=<%= RequestParas() %>' class="linkButton"><img src="SlmImages/b_post_topic.png" alt="" style="border:0px" /></a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="msgtd2"></td>
    </tr>
    <tr>
        <td class="tblforum">
            <table cellpadding="0" cellspacing="1" class="forum" >
                <tr>
                    <td class="topichead" colspan="6" >
                        <span class="TopicName"><%= lblAnnountCate.Text.ToString()%></span>
                    </td>
                </tr>
                <tr>
                    <td class="topichead1" >&nbsp;</td>
                    <td class="topichead2">
                        <%= LoadSLMF("SLMF_Topic", "Topic")%>
                    </td>
                    <td class="topichead3" >
                        <%= LoadSLMF("SLMF_Topic", "TopicStarter")%>
                    </td>
                    <td class="topichead4" >
                        <%= LoadSLMF("SLMF_Topic", "Reply")%>
                    </td>
                    <td class="topichead5" >
                        <%= LoadSLMF("SLMF_Topic", "View")%>
                    </td>
                    <td class="topichead6" >
                        <%= LoadSLMF("SLMF_Topic", "NewPost")%>
                    </td>
                </tr>
                <asp:Repeater ID="rptTopic" runat="server" OnItemDataBound="rptTopic_ItemDataBound" >
                    <ItemTemplate>
                        <tr class="showtopic1">
                            <td >
                                <img runat="server" id="imgTopic" src="../SlmImages/topic.gif" alt="" class="imgForum" />
                            </td>
                            <td class="ForumDescript">
                                <asp:Label ID="lblAltTopic" CssClass="AltTopic" runat="server" Visible="false" Text='<%# LoadSLMF("SLMF_Topic", "AltSticky")%>'></asp:Label> <a class="TitleLnk" id="hrfTopicName" runat="server" ></a> 
                                <%# GotoPage(int.Parse(Eval("TopicId").ToString())) %>
                            </td>
                            <td >
                                <span class="TopicName"><a class="TopicLink" id="hrfStarter" runat="server"></a></span>
                            </td>
                            <td align="center" >
                                <%# Eval("TotalReplies")%>
                            </td>
                            <td align="center">
                                <%# Eval("TotalViews")%>
                            </td>
                            <td align="center">
                                <asp:Label CssClass="TimeMessage" ID="lblLastMsg" runat="server" ></asp:Label><br />
                                <a class="TopicLink" id="hrfLastPoster" runat="server"></a> <a id="hrfGoLastMsg" class="TopicLink" runat="server" ><img src="SlmImages/icon_latest_reply.gif" class="imgBorderW"  /></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td class="topichead2" colspan="6" >
                        <%= LoadSLMF("SLMF_Topic", "Browsing")%>
                    </td>
                </tr>
                <tr>
                    <td class="ListActiveUser" colspan="6" >
                        <%= MemberViews() %>  
                        <asp:Repeater ID="listuser" runat="server">
                            <ItemTemplate>
                                <a class="TopicLink" title='<%# "Login: " + DateTime.Parse(Eval("Request").ToString()).ToLongTimeString() + " - Online: " + Eval("Online") + " phút" %>' href='<%# "showprofile.aspx?memberid=" + Eval("MemberId") %>' ><%# Eval("UserName") %></a>
                            </ItemTemplate>
                            <SeparatorTemplate>,</SeparatorTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" class="listfrom">
                        <table cellspacing="0" cellpadding="0" width="100%">
                            <tr>
                                <td width="1%" >
                                    <nobr>
                                        <%= LoadSLMF("SLMF_Topic", "ShowFrom")%>
                                        <asp:DropDownList id="listfrom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="listfrom_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp; 
                                        <asp:TextBox id="txtSearch" runat="server" CssClass="reg2txtUserName"></asp:TextBox> 
                                        <asp:Button id="btnSearch" runat="server" CssClass="btnReg" OnClick="btnSearch_Click"></asp:Button>
                                        <asp:RequiredFieldValidator ID="rfvSearch" ControlToValidate="txtSearch" runat="server"></asp:RequiredFieldValidator>
                                    </nobr>
                                </td>
                                <td align="right">
                                   <!-- ADDTHIS BUTTON BEGIN -->
                                    <script type="text/javascript">
                                    addthis_pub             = 'f9light'; 
                                    addthis_logo            = 'http://www.code2coder.com/forum/slmimages/bookmark.gif';
                                    addthis_logo_background = 'EFEFFF';
                                    addthis_logo_color      = '666699';
                                    addthis_brand           = 'BDS Viet Nam';
                                    addthis_options         = 'favorites, email, digg, delicious, myspace, facebook, google, live, more';
                                    </script>
                                    <a href="http://www.addthis.com/bookmark.php" onmouseover="return addthis_open(this, '', 'http://www.code2coder.com/forum/topicdisplay.aspx?forumid=<%= Request.Params["ForumId"].ToString() %>', '<%= lblGroupName.Text.ToString() %>')" onmouseout="addthis_close()" onclick="return addthis_sendto()"><img src="slmimages/bookmark.gif" style="border:0px" width="83" height="16" alt="" /></a>
                                    <script type="text/javascript" src="http://s7.addthis.com/js/152/addthis_widget.js"></script>
                                    <!-- ADDTHIS BUTTON END -->
                                   &nbsp;<a id="hrfRss" href="rssfeed.aspx?forumid=<%=RequestParas() %>"><img src="SlmImages/rss.png"  style="border:0px;padding-top:2px" /></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="msgtd2"></td>
    </tr>
    <tr>
        <td class="topic1">
            <table class="tblTopic1" cellspacing="0" cellpadding="0" >
                <tr>
                    <td class="linkPager" align="left">
                        <cc1:Pager ID="TMessage2" runat="server" PageSize="20" OfClause="/" BackToFirstClause="Trang đầu" GoToLastClause="Trang cuối" ShowFirstLast="true" PageClause="Trang" BackToPageClause="Trang trước:" NextToPageClause="Tiếp theo:" ShowingResultClause="Bài viết" ShowResultClause="Bài viết" ToClause="đến" OnCommand="TMessage2_Command" />
                    </td>
                    <td align="right">
                        <asp:LinkButton ID="moderators" runat="server" CssClass="linkButton" />
                        <a href='newtopic.aspx?post=newtopic&forumid=<%= RequestParas() %>' class="linkButton"><img src="SlmImages/b_post_topic.png" alt="" style="border:0px" /></a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="regtd2"></td>
    </tr>
    <tr>
        <td class="regtd1">
            <a href="Default.aspx" class="RedLink"><%= LoadSLMF("WelHeader","ForumName") %></a>
            <span class="GetSpace"><%= LoadSLMF("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="hplCategory3" ></a>
            <span runat="server" visible="false" id="parf1" class="GetSpace"><%= LoadSLMF("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="hplCategory4" ></a>
            <span class="GetSpace"><%= LoadSLMF("SLMF_Forum", "Space")%></span><asp:Label ID="lblGroup2" runat="server" CssClass="RedLink2" ></asp:Label>
        </td>
    </tr>
</table>