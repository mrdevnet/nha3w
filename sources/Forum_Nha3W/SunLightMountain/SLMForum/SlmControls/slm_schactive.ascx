<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_schactive.ascx.cs" Inherits="SlmControls_slm_schactive" %>
<%@ Register Assembly="ASPnetPagerV2netfx2_0" Namespace="CutePager" TagPrefix="cc1" %>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink" ><%= LoadSLMF("WelHeader","ForumName") %></a>
            <span class="GetSpace"><%= LoadSLMF("SLMF_Forum", "Space")%></span>
            <span class="RedLink2"><%= LoadSLMF("SLMF_Active", "NewTopic")%></span>
        </td>
    </tr>
    <tr>
        <td class="regtd2"></td>
    </tr>
    <tr>
        <td class="topic1">
            <table class="tblTopic1" cellspacing="0" cellpadding="0" >
                <tr>
                    <td class="linkPager" align="left">
                        <cc1:Pager ID="TMessage1" runat="server" PageSize="15" OfClause="/" PageClause="Trang" BackToPageClause="Trang trước:" NextToPageClause="Tiếp theo:" ShowingResultClause="Bài viết" ShowResultClause="Bài viết" ToClause="đến" OnCommand="TMessage1_Command" />
                    </td>
                    <td align="right">
                        <asp:DropDownList AutoPostBack="true" ID="ddlSearch" CssClass="fontmsg" runat="server" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged"></asp:DropDownList>
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
                    <td class="hforum1" ></td>
                    <td class="hforum23">
                        <%= LoadSLMF("SLMF_Active", "Topic")%>
                    </td>
                    <td class="hforum32" >
                        <%= LoadSLMF("SLMF_Active", "Forum")%>
                    </td>
                    <td class="hforum34" >
                        <%= LoadSLMF("SLMF_Active", "Author")%>
                    </td>
                    <td class="hforum13" >
                        <%= LoadSLMF("SLMF_Active", "Reply")%>
                    </td>
                    <td class="hforum14" >
                        <%= LoadSLMF("SLMF_Active", "View")%>
                    </td>
                    <td class="hforum35" >
                        <%= LoadSLMF("SLMF_Active", "LastPost")%>
                    </td>
                </tr>
                <asp:Repeater ID="rptForum" runat="server" OnItemDataBound="rptForum_ItemDataBound" >
                    <ItemTemplate>
                        <tr class="forumshow">
                            <td >
                                <img runat="server" id="imgActive" src="../SlmImages/topic.gif" alt="" class="imgForum" />
                            </td>
                            <td class="ForumDescript">
                                <a href='<%# "showtopic.aspx?goto=newmessage&topicid=" + Eval("TopicId") %>' class="TitleLnk" ><%# Eval("Title") %></a>
                            </td>
                            <td class="forumshow1" >
                                <a href='<%# "topicdisplay.aspx?forumid=" + Eval("ForumId") %>' class="ForumLink" ><%# Eval("Name") %></a>
                            </td>
                            <td class="ForumDescript">
                                <a class="TopicLink" href='<%# "showprofile.aspx?memberid=" + Eval("AuthorId") %>'><%# Eval("Author") %></a>
                            </td>
                            <td class="forumshow1">
                                <span class="postannount" ><%# Eval("TotalReplies") %></span>
                            </td>
                            <td class="forumtocpic">
                                <span class="postannount" ><%# Eval("TotalViews") %></span>
                            </td>
                            <td class="forumtocpic">
                                <asp:Label CssClass="TimeMessage" ID="lblTime" runat="server" Text='<%# AnnounceTime(DateTime.Parse(Eval("CreationDate").ToString())) %>'></asp:Label><br />
                                <a class="TopicLink" href='<%# "showprofile.aspx?memberid=" + Eval("LastAuthorId") %>'><%# Eval("LastAuthor") %></a> 
                                <a title='<%= LoadSLMF("SLMF_Forum", "GoToNewPost") %>' href='<%# "showtopic.aspx?messageid=" + Eval("MessageId") + "#message" + Eval("MessageId")%>' class="TopicLink"><img src="SlmImages/icon_latest_reply.gif" class="imgBorderW" /></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
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
                        <cc1:Pager ID="TMessage2" runat="server" PageSize="15" OfClause="/" PageClause="Trang" BackToPageClause="Trang trước:" NextToPageClause="Tiếp theo:" ShowingResultClause="Bài viết" ShowResultClause="Bài viết" ToClause="đến" OnCommand="TMessage2_Command" />
                    </td>
                    <td align="right"></td>
                </tr>
            </table>
        </td>
    </tr>
</table>