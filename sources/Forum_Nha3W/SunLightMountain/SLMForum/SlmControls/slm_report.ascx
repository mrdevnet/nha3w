<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_report.ascx.cs" Inherits="SlmControls_slm_report" %>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink"><%= LoadText("WelHeader", "ForumName")%></a>
            <span class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="hplCategory" ></a>
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
                    </td>
                    <td align="right">
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
                                    <a href="http://www.addthis.com/bookmark.php" onmouseover="return addthis_open(this, '', 'http://www.code2coder.com/forum/announcement.aspx?announceid=<%= RequestId() %>', '<%= lblTopicTitle2.Text.ToString() %>')" onmouseout="addthis_close()" onclick="return addthis_sendto()"><img src="slmimages/delicious.png" style="border:0px" width="13" height="13" alt="" /></a>
                                    <script type="text/javascript" src="http://s7.addthis.com/js/152/addthis_widget.js"></script>
                                    <!-- ADDTHIS BUTTON END -->
                                    &nbsp;<a href="javascript:window.print()" ><img alt="" id="report" src="SlmImages/print.gif" style="border:0px;padding-top:4px"/></a> 
                                    <a id="hrfRss"><img src="SlmImages/rss.png"  style="border:0px;padding-top:4px" /></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="MostAnnounce">
                    <td colspan="3" align="left" style="padding-left:5px">
                        <asp:Label ID="lblTimeFinish" CssClass="MostInfor4" runat="server" />
                    </td>
                </tr>
                <asp:Repeater ID="rptMessage" runat="server" OnItemDataBound="rptMessage_ItemDataBound">
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
				                        <a id="imgIcon" title='<%# Eval("Title") %>' href='<%# "announcement.aspx?announceid=" + Eval("MessageId") + "#message" + Eval("MessageId") %>' class="FdwLink"><img src="SlmImages/icon_post_show.gif" class="imgBorderW" /></a> <%# AnnounceTime(DateTime.Parse(DataBinder.Eval(Container.DataItem, "CreationDate").ToString()))%>
			                        </td>
			                        <td class="postmsg3" align="right">
			                        </td>
		                        </tr>
		                        </table>
	                        </td>
                        </tr>
                        <tr class="msgcontent">
	                        <td valign="top" height="100" colspan="2" class="PaddLeft">
	                            <asp:Label ID="lblUserBox" runat="server" CssClass="UserPro"></asp:Label>
	                        </td>
	                        <td valign="top" class="postmsg2">
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
	                        </td>
                        </tr>
                        <tr>
	                        <td class="msgfooter" colspan="2">
		                        <a href="javascript:scroll(0,0)" title='<%# LoadText("SLMF_Topic", "Top")%>'><img src="SlmImages/asc.gif"  class="imgBorderW"/></a> 
		                        <img id="offline" visible="false" runat="server" src="../SlmImages/user_offline.gif"  class="imgBorderW"/> <img visible="false" id="online" runat="server" src="../SlmImages/user_online.gif"  class="imgBorderW"/> 
		                    </td>
	                        <td class="msgfooter2">
		                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
		                            <tr>
			                            <td>
			                                <asp:hyperlink Visible="false" runat='server' id='Home' ImageUrl="~/SlmImages/p_www.gif"/>
			                                <asp:hyperlink Visible="false" runat='server' id='Blog' ImageUrl="~/SlmImages/p_blog.gif"/>
			                                <asp:hyperlink Visible="false" runat='server' id='Msn' ImageUrl="~/SlmImages/p_msn.gif"/>
			                                <asp:hyperlink Visible="false" runat='server' id='Yim' ImageUrl="~/SlmImages/p_yim.gif"/>
			                                <asp:hyperlink Visible="false" runat='server' id='Aim' ImageUrl="~/SlmImages/p_aim.gif"/>
			                                <asp:hyperlink Visible="false" runat='server' id='Icq' ImageUrl="~/SlmImages/p_icq.gif"/>
			                            </td>
			                            <td align="right" id="AdminInfo" runat="server" class="fontmsg">
			                                <asp:Label Visible="false" id="lblIP" runat="server" Text='<%# "| IP: " + Eval("IP") + " " %>'></asp:Label>&nbsp;
			                            </td>
		                            </tr>
		                        </table>
	                        </td>
                        </tr>
                        <tr class="msgstep">
                            <td colspan="3" style="height:5px">
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td class="topichead2" colspan="3" >
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
                    </td>
                    <td align="right">
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
            <span class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><asp:Label ID="lblTopic2" runat="server" CssClass="RedLink2" ></asp:Label>
        </td>
    </tr>
</table>