<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_message.ascx.cs" Inherits="SlmControls_slm_message" %>
<%@ Register Assembly="ASPnetPagerV2netfx2_0" Namespace="CutePager" TagPrefix="cc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<script type="text/javascript" language="javascript">
    function confirmdeltpc()
    {
        return confirm('<%= LoadText("SLMF_Message", "AskDeleteTopic")%>');
    }
    
    function confirmlcktpc()
    {
        return confirm('<%= LoadText("SLMF_Message", "AskLockTopic")%>');
    }
    
    function confirmunlcktpc()
    {
        return confirm('<%= LoadText("SLMF_Message", "AskUnLockTopic")%>');
    }
    
    function confirmIsApprove()
    {
        return confirm('<%= LoadText("SLMF_Message", "ConfirmIsAppro")%>');
    }
    
    function confirmApprove()
    {
        return confirm('<%= LoadText("SLMF_Message", "ConfirmAppro")%>');
    }
    
    function confirmThanks()
    {
        return confirm('<%= LoadText("SLMF_Message", "AskThanks")%>');
    }
</script>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink"><%= LoadText("WelHeader", "ForumName")%></a>
            <span class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="hplCategory" ></a>
            <span runat="server" visible="false" id="panelparf1" class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="parf1" ></a>
            <span class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="hplForum" ></a>
            <span class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><asp:Label ID="lblTopicTitle1" runat="server" CssClass="RedLink2" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="regtd2"></td>
    </tr>
    <tr>
        <td class="tblforum">
            <table class="tblmsg" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="left" class="lnkpagemsg">
                        <cc1:Pager ID="PMessage1" runat="server" PageSize="20" OnCommand="PMessage1_Command" OfClause="/" BackToFirstClause="Trang đầu" GoToLastClause="Trang cuối" ShowFirstLast="true" PageClause="Trang" BackToPageClause="Trang trước:" NextToPageClause="Tiếp theo:" ShowingResultClause="Bài viết" ShowResultClause="Bài viết" ToClause="đến"/>
                    </td>
                    <td align="right">
                        <a id="hrfNewMsg1" runat="server" class="linkButton"><img src="SlmImages/b_post_reply.png"  class="imgBorderW"/></a>
                        <a id="hrfNewTpc1" runat="server" class="linkButton"><img src="SlmImages/b_post_topic.png"  class="imgBorderW"/></a>
                        <asp:LinkButton Visible="false" ID="DeleteTopic1" runat="server" CssClass="linkButton" OnClick="DeleteTopic1_Click" ><img src="SlmImages/b_delete_topic.png"  class="imgBorderW"/></asp:LinkButton>
                        <asp:LinkButton Visible="false" ID="LockTopic1" runat="server" CssClass="linkButton" OnClick="LockTopic1_Click" ><img src="SlmImages/b_lock_topic.png"  class="imgBorderW"/></asp:LinkButton>
                        <asp:LinkButton Visible="false" ID="UnLockTopic1" runat="server" CssClass="linkButton" OnClick="UnLockTopic1_Click" ><img src="SlmImages/b_unlock_topic.png"  class="imgBorderW"/></asp:LinkButton>
                        <a visible="false" id="hrfMoveTopic1" runat="server" style="cursor:pointer" class="linkButton"><img src="SlmImages/b_move_topic.png"  class="imgBorderW"/></a>
                        <%--<asp:LinkButton Visible="false" ID="MoveTopic1" runat="server" CssClass="linkButton" ><img src="SlmImages/b_move_topic.png"  class="imgBorderW"/></asp:LinkButton>--%>
                        <img id="imgLock1" runat="server" src="../SlmImages/threadclosed.gif" visible="false" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="msgtd2"></td>
    </tr>
    <tr runat="server" id="rowPoll" visible="false">
        <td class="tblforum">
            <table cellpadding="0" cellspacing="1" class="forum" >
                <tr>
                    <td class="hforumAnnounce">
                        <asp:Label ID="lblTitlePoll" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr class="forumshow">
                    <td class="ForumDescript">
                        <table width="100%">
                            <tr>
                                <td valign="top" align="center">
                                    <div runat="server" id="dv1" class="widthfieldset" width="100%">
                                        <fieldset class="fieldset">
				                            <legend><span style="color:#3b5998"><%= LoadText("SLMF_Poll", "Title")%> <asp:Label ID="lblTotalPoll" runat="server" ></asp:Label></span></legend>
				                            <div style="padding: 9px;">
				                                <div style="margin-bottom: 3px;"><strong><asp:Label ID="lblTitlePoll2" runat="server" ></asp:Label></strong></div>
                                                <asp:RadioButtonList ID="rlPoll" DataValueField="ResultId" DataTextField="Choice" runat="server"></asp:RadioButtonList>
				                            </div>
			                            </fieldset>
			                            <div>
			                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" BorderStyle="Solid" Font-Names="11px"/>
			                            </div>
			                        </div>
			                        <div runat="server" id="dv2" class="widthfieldset" width="100%">
                                        <fieldset class="fieldset">
				                            <legend><span style="color:#2e61b6"><%= LoadText("SLMF_Poll", "TitleResult")%> <asp:Label ID="lblCount" runat="server" ></asp:Label></span></legend>
				                            <div style="padding: 9px;">
				                                <table width="100%">
				                                <asp:Repeater runat="server" ID="rptVote">
				                                    <ItemTemplate>
		                                                <tr>
		                                                    <td width="50%">
		                                                        <span class="postPoll"><%# Eval("Choice") %></span>
		                                                    </td>
		                                                    <td width="25%" nowrap="nowrap" align="left">
		                                                        <img align="absmiddle" src="slmimages/vote_left.gif" /><asp:Image align="absmiddle" runat="server" id="imgPercent" Height="12px" Width='<%# PercentImage(Decimal.Parse(Eval("TotalOfChoice").ToString()))%>' ImageUrl="../slmimages/vote_center.gif" /><img align="absmiddle" src="slmimages/vote_right.gif" />
		                                                    </td>
		                                                    <td width="12%" align="center" nowrap="nowrap">
		                                                        <span class="postPoll"><strong><%# Eval("SumTotal") %></strong></span>
		                                                    </td>
		                                                    <td width="13%" align="center" nowrap="nowrap">
		                                                        <span class="postPoll"><%# Eval("TotalOfChoice") + "%"%></span>
		                                                    </td>
		                                                </tr>
		                                                <tr>
		                                                    <td colspan="4"><hr noshade size="1"></td>
		                                                </tr>
		                                            </ItemTemplate>
				                                </asp:Repeater>
				                                </table>
				                            </div>
			                            </fieldset>
			                            <div align="center">
			                                <asp:Label ID="lblPermission" CssClass="postPoll" runat="server" ></asp:Label>
			                            </div>
			                        </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr runat="server" id="rowPoll2" visible="false">
        <td class="regtd2"></td>
    </tr>
    <tr>
        <td class="tblforum">
            <table class="tblcontentmsg" cellspacing="1" cellpadding="0" border="0">
                <tr>
                    <td colspan="3" style="padding: 0px">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="msg1">
                            <tr class="msg1">
                                <td class="TopicName">
                                    <asp:Label ID="lblTopicTitle2" runat="server" />
                                </td>
                                <td class="Rss">
                                    <!-- ADDTHIS BUTTON BEGIN -->
                                    <script type="text/javascript">
                                        addthis_pub             = 'f9light';
                                        addthis_logo            = 'http://www.code2coder.com/forum/slmimages/bookmark.gif';
                                        addthis_logo_background = 'EFEFFF';
                                        addthis_logo_color      = '666699';
                                        addthis_brand           = 'BDS Viet Nam';
                                        addthis_options         = 'favorites, email, digg, delicious, myspace, facebook, google, live, more';
                                    </script>
                                    <a href="http://www.addthis.com/bookmark.php" onmouseover="return addthis_open(this, '', 'http://www.code2coder.com/forum/showtopic.aspx?topicid=<%= RequestId() %>', '<%= lblTopicTitle2.Text.ToString() %>')" onmouseout="addthis_close()" onclick="return addthis_sendto()"><img src="slmimages/delicious.png" style="border:0px" width="13" height="13" alt="" /></a>
                                    <script type="text/javascript" src="http://s7.addthis.com/js/152/addthis_widget.js"></script>
                                    <!-- ADDTHIS BUTTON END -->
                                    &nbsp;<a href="javascript:window.print()" ><img alt="" id="report" src="SlmImages/print.gif" style="border:0px;padding-top:4px"/></a> 
                                    <a id="hrfRss" href="rssfeed.aspx?topicid=<%=RequestId() %>"><img src="SlmImages/rss.png"  style="border:0px;padding-top:4px" /></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="msg2">
                    <td colspan="3" align="right" style="padding-right:5px">
                        <asp:LinkButton ID="PrevTopic" runat="server" CssClass="msg2lnk" OnClick="PrevTopic_Click"/> &middot; 
                        <asp:LinkButton ID="NextTopic" runat="server" CssClass="msg2lnk" OnClick="NextTopic_Click"/>
                    </td>
                </tr>
                <asp:Repeater ID="rptMessage" runat="server" OnItemDataBound="rptMessage_ItemDataBound" OnItemCommand="rptMessage_ItemCommand">
                    <ItemTemplate>
                        <tr class="postmsg">
	                        <td width="140px" colspan="2" class="PaddLeft">
		                        <a name='<%# "message" + Eval("MessageId")%>'/>
		                        <b><a class="UserBox" id="hrfUserName" runat="server" href='<%# "../showprofile.aspx?memberid=" + Eval("MemberId") %>' ><%# Eval("UserName") %></a></b>
	                        </td>
	                        <td width="80%">
		                        <table cellspacing="0" cellpadding="0" width="100%">
		                        <tr>
			                        <td class="postmsg3">
				                        <a id="imgIcon" title='<%# Eval("Title") %>' href='<%# "showtopic.aspx?rowid=" + Eval("RecordId") + "&messageid=" + Eval("MessageId") + "#message" + Eval("MessageId") %>' class="FdwLink"><img src="SlmImages/icon_post_show.gif" class="imgBorderW" /></a> <%# AnnounceTime(DateTime.Parse(DataBinder.Eval(Container.DataItem, "CreationDate").ToString()))%>
			                        </td>
			                        <td class="postmsg3" align="right">
				                        <asp:linkbutton CommandName="deletepost" CommandArgument='<%# Eval("MessageId") %>' Visible="false" runat="server" id="DeleteMsg"><img src="SlmImages/b_delete_post.png"  class="imgBorderW"/></asp:linkbutton>
				                        <a id="ReplyMessage" runat="server" visible="false" class="linkButton"><img src="SlmImages/b_reply_pm.png"  class="imgBorderW"/></a>
				                        <a id="QuoteMessage" runat="server" visible="false" class="linkButton"><img src="SlmImages/b_quote_post.png"  class="imgBorderW"/></a>
				                        <a id="EditMessage" runat="server" visible="false" class="linkButton"><img src="SlmImages/b_edit_post.png"  class="imgBorderW"/></a>
				                        <a runat="server" visible="false" id="ForwardMessage" style="cursor:pointer" class="linkButton"><img src="SlmImages/b_attachments.png"  class="imgBorderW"/></a>
			                        </td>
		                        </tr>
		                        </table>
	                        </td>
                        </tr>
                        <tr class="msgcontent">
	                        <td valign="top" height="100" colspan="2" class="PaddLeft">
	                            <asp:Label ID="lblUserBox" runat="server" CssClass="UserPro"></asp:Label>
	                            <table cellpadding="0" cellspacing="0" runat="server" id="tblNews2" visible="false">
                                    <tr>
                                        <td>
                                            <fieldset>
	                                            <legend><b><span style="color:#3068bb"><%= LoadText("SLMF_RssFeed", "MyRss")%></span></b></legend>
	                                            <div style="padding: 1px;">
	                                                <table runat="server" id="tblNews" cellpadding="0" cellspacing="0"></table>
	                                            </div>
                                            </fieldset>
	                                    </td>
	                                    <td width="5px"></td>
                                    </tr>
                                    <tr height="5px">
                                        <td colspan="2"></td>
                                    </tr>
                                </table>
                            </td>
	                        <td valign="top" class="postmsg2">
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
	                        </td>
                        </tr>
                        <tr>
	                        <td class="msgfooter" colspan="2">
		                        <a href="javascript:scroll(0,0)" title='<%# LoadText("SLMF_Topic", "Top")%>'><img src="SlmImages/asc.gif"  class="imgBorderW"/></a> 
		                        <img id="offline" visible="false" runat="server" src="../SlmImages/user_offline.gif"  class="imgBorderW"/> <img visible="false" id="online" runat="server" src="../SlmImages/user_online.gif"  class="imgBorderW"/> 
		                        <a id="hrfReport" visible="false" runat="server" title='<%# LoadText("SLMF_Message", "Report")%>'><img id="report" src="SlmImages/rpt.png" class="imgBorderW"/></a>
	                        </td>
	                        <td class="msgfooter2">
		                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
		                            <tr>
			                            <td>
			                                <asp:hyperlink ToolTip='<%# LoadText("SLMF_Message", "PM")%>' NavigateUrl='<%# "../pm.aspx?id=2&memberid=" + Eval("MemberId") %>' Visible="false" runat='server' id='Pm' ImageUrl="~/SlmImages/p_pm.gif"/>
			                                <asp:hyperlink Visible="false" runat='server' id='Email' ImageUrl="~/SlmImages/p_email.gif"/>
			                                <asp:hyperlink Visible="false" runat='server' id='Home' ImageUrl="~/SlmImages/p_www.gif"/>
			                                <asp:hyperlink Visible="false" runat='server' id='Blog' ImageUrl="~/SlmImages/p_blog.gif"/>
			                                <asp:hyperlink Visible="false" runat='server' id='Msn' ImageUrl="~/SlmImages/p_msn.gif"/>
			                                <asp:hyperlink Visible="false" runat='server' id='Yim' ImageUrl="~/SlmImages/p_yim.gif"/>
			                                <asp:hyperlink Visible="false" runat='server' id='Aim' ImageUrl="~/SlmImages/p_aim.gif"/>
			                                <asp:hyperlink Visible="false" runat='server' id='Icq' ImageUrl="~/SlmImages/p_icq.gif"/>
			                            </td>
			                            <td align="right" id="AdminInfo" runat="server" class="fontmsg">
			                                <asp:linkbutton OnClientClick="return confirmThanks();" CommandName="tnkpost" CommandArgument='<%# Eval("MessageId") %>' Visible="false" runat="server" id="TknsPost" CssClass="FdwLink"><img src="SlmImages/tks.png" class="imgBorderW2"/></asp:linkbutton>
			                                <asp:LinkButton Visible="false" CommandName="IsApproveMsg" CommandArgument='<%# Eval("MessageId") %>' OnClientClick="return confirmIsApprove();" ID="IsAppMessage" runat="server" ToolTip='<%# LoadText("SLMF_Message", "IsApproved")%>' CssClass="FdwLink"><img class="imgBorderW2" src="SlmImages/Approve12.png"/></asp:LinkButton>
			                                <asp:LinkButton Visible="false" CommandName="ApproveMsg" CommandArgument='<%# Eval("MessageId") %>' OnClientClick="return confirmApprove();" ID="AppMessage" runat="server" ToolTip='<%# LoadText("SLMF_Message", "Approved")%>' CssClass="FdwLink"><img class="imgBorderW2" src="SlmImages/Approve1.png"/></asp:LinkButton>&nbsp;<a id="hrfnewm" runat="server" class="FdwLink"></a>&nbsp;<asp:Label Visible="false" id="lblIP" runat="server" Text='<%# "| IP: " + Eval("IP") + " " %>'></asp:Label>&nbsp;
			                            </td>
		                            </tr>
		                        </table>
	                        </td>
                        </tr>
                        <tr class="msgstep">
                            <td colspan="3" style="height:5px">
                            </td>
                        </tr>
                        <asp:Panel runat="server" Visible="false" ID="pnlThanks">
                            <tr class="postmsg">
                                <td width="100%" height="31px" colspan="3" class="PaddLeft">
                                    <b><asp:Label id="lblTksTitle" runat="server"></asp:Label></b>
                                </td>
                            </tr>
                            <tr class="msgcontent">
                                <td valign="top" align="left" class="Sponsor" colspan="3">
                                    <asp:Repeater ID="rptThanks" runat="server">
                                        <ItemTemplate>
                                            <a class="TopicLink" href='<%# "showprofile.aspx?memberid=" + Eval("MemberId") %>' ><%# Eval("UserName") %></a> 
                                            (<%# AnnounceTime(DateTime.Parse(Eval("ThankW").ToString()))%>)
                                        </ItemTemplate>
                                        <SeparatorTemplate>,</SeparatorTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr class="msgstep">
                                <td colspan="3" style="height:5px">
                                </td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel runat="server" Visible="false" ID="pnlSponsor">
                            <tr class="postmsg">
                                <td width="140px" colspan="2" class="PaddLeft">
                                    <b><a class="UserBox" href="#"><%# LoadText("SLMF_Message", "Sponsor")%></a></b>
                                </td>
                                <td width="80%">
	                                <table cellspacing="0" cellpadding="0" width="100%">
	                                    <tr>
		                                    <td class="postmsg3">
			                                    <a id="hrfSponsor" title='<%# Eval("Title") %>' href='<%# "showtopic.aspx?rowid=" + Eval("RecordId") + "&messageid=" + Eval("MessageId") + "#message" + Eval("MessageId") %>' class="FdwLink"><img src="SlmImages/icon_post_show.gif" class="imgBorderW" /></a> <%# AnnounceTime(DateTime.Parse(DataBinder.Eval(Container.DataItem, "CreationDate").ToString()))%>
		                                    </td>
		                                    <td class="postmsg3" align="right"></td>
	                                    </tr>
	                                </table>
                                </td>
                            </tr>
                            <tr class="msgcontent">
                                <td valign="top" align="center" class="Sponsor" colspan="3">
                                    <asp:Label ID="lblMessageSponsor" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="msgstep">
                                <td colspan="3" style="height:5px">
                                </td>
                            </tr>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:Repeater>
                <tr class="msg2" runat="server" id="rowTitleQuick" visible="false">
                    <td colspan="3" align="left" style="padding-left:5px">
                        <a name='quickrepl'/>
                        <%= LoadText("SLMF_Message", "QuickReply")%>
                    </td>
                </tr>
                <tr runat="server" id="rowQuick" visible="false">
                    <td colspan="3" class="QuickReply" style="padding: 0px;">
                        <div class="post" id="QuickReplyLine" runat="server" style="margin-top: 10px; margin-left: 75px;margin-right: 75px; padding: 2px; height: 212px">
                            <FCKeditorV2:FCKeditor ID="txtReplyMsg" BasePath="~/FCKeditor/" ToolbarSet="F9Light" Height="212px" AutoDetectLanguage="false" DefaultLanguage="en" SkinPath= 'skins/silver/' runat="server"></FCKeditorV2:FCKeditor>
                        </div>
                        <div align="center" style="margin: 7px;">
                            <asp:Button Text="Gửi bài viết" ID="QuickReply" CssClass="btnReg" runat="server" OnClick="QuickReply_Click"  />&nbsp;
                            <asp:Button Text="Tùy chọn khác" ID="PostAgain" CssClass="btnReg" runat="server" OnClick="PostAgain_Click" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="topichead2" colspan="3" >
                        <%= LoadText("SLMF_Topic", "Browsing")%>
                    </td>
                </tr>
                <tr>
                    <td class="ListActiveUser" colspan="3" >
                        <%= MemberViews() %>  
                        <asp:Repeater ID="listuser" runat="server">
                            <ItemTemplate>
                                <a class="TopicLink" title='<%# "Login: " + DateTime.Parse(Eval("Request").ToString()).ToLongTimeString() + " - Online: " + Eval("Online") + " phút" %>' href='<%# "showprofile.aspx?memberid=" + Eval("MemberId") %>' ><%# Eval("UserName") %></a>
                            </ItemTemplate>
                            <SeparatorTemplate>,</SeparatorTemplate>
                        </asp:Repeater>
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
            <table class="tblmsg" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="left" class="lnkpagemsg">
                        <cc1:Pager ID="PMessage2" runat="server" PageSize="20" OfClause="/" BackToFirstClause="Trang đầu" GoToLastClause="Trang cuối" ShowFirstLast="true" PageClause="Trang" BackToPageClause="Trang trước:" NextToPageClause="Tiếp theo:" ShowingResultClause="Bài viết" ShowResultClause="Bài viết" ToClause="đến" OnCommand="PMessage2_Command" />
                    </td>
                    <td align="right">
                        <a id="hrfNewMsg2" runat="server" class="linkButton"><img src="SlmImages/b_post_reply.png"  class="imgBorderW"/></a>
                        <a id="hrfNewTpc2" runat="server" class="linkButton"><img src="SlmImages/b_post_topic.png"  class="imgBorderW"/></a>
                        <asp:LinkButton Visible="false" ID="DeleteTopic2"  runat="server" CssClass="linkButton" OnClick="DeleteTopic2_Click" ><img src="SlmImages/b_delete_topic.png"  class="imgBorderW"/></asp:LinkButton>
                        <asp:LinkButton Visible="false" ID="LockTopic2" runat="server" CssClass="linkButton" OnClick="LockTopic2_Click" ><img src="SlmImages/b_lock_topic.png"  class="imgBorderW"/></asp:LinkButton>
                        <asp:LinkButton Visible="false" ID="UnLockTopic2" runat="server" CssClass="linkButton" OnClick="UnLockTopic2_Click" ><img src="SlmImages/b_unlock_topic.png"  class="imgBorderW"/></asp:LinkButton>
                        <a visible="false" id="hrfMoveTopic2" style="cursor:pointer" runat="server" class="linkButton"><img src="SlmImages/b_move_topic.png"  class="imgBorderW"/></a>
                        <%--<asp:LinkButton Visible="false" ID="MoveTopic2" runat="server" CssClass="linkButton" ><img src="SlmImages/b_move_topic.png"  class="imgBorderW"/></asp:LinkButton>--%>
                        <img id="imgLock2" runat="server" src="../SlmImages/threadclosed.gif" visible="false" alt="Closed"/>
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
            <a href="Default.aspx" class="RedLink"><%= LoadText("WelHeader", "ForumName")%></a>
            <span class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="hplCategory2" ></a>
            <span runat="server" visible="false" id="panelparf2" class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="parf2" ></a>
            <span class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="hplForum2" ></a>
            <span class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><asp:Label ID="lblTopic2" runat="server" CssClass="RedLink2" ></asp:Label>
        </td>
    </tr>
</table>