<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_memberlist.ascx.cs" Inherits="SlmControls_slm_memberlist" %>
<%@ Register Assembly="ASPnetPagerV2netfx2_0" Namespace="CutePager" TagPrefix="cc1" %>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink" ><%= LoadSLMF("WelHeader","ForumName") %></a>
            <span class="GetSpace"><%= LoadSLMF("SLMF_Forum", "Space")%></span>
            <span class="RedLink2"><%= LoadSLMF("SLMF_Members", "ListMembers")%></span>
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
                        <cc1:Pager ID="TMessage1" runat="server" PageSize="20" OfClause="/" PageClause="Trang" BackToPageClause="Trang trước:" NextToPageClause="Tiếp theo:" ShowingResultClause="Bài viết" ShowResultClause="Bài viết" ToClause="đến" OnCommand="TMessage1_Command" />
                    </td>
                    <td align="right">
                        <asp:TextBox ID="txtSearch" Width="93" runat="server" CssClass="reg2txtUserName"></asp:TextBox> 
                        <asp:Button ID="btnSearch" runat="server" CssClass="btnReg" OnClick="btnSearch_Click" />
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
                    <td class="hforum71" ></td>
                    <td class="hforum13">
                        <%= LoadSLMF("SLMF_Members", "Contact")%>
                    </td>
                    <td class="hforum34" >
                        <%= LoadSLMF("SLMF_Members", "UserName")%>
                    </td>
                    <td class="hforum556" >
                        <%= LoadSLMF("SLMF_Members", "GroupName")%>
                    </td>
                    <td class="hforum13" >
                        <%= LoadSLMF("SLMF_Members", "Posts")%>
                    </td>
                    <td class="hforum34" >
                        <%= LoadSLMF("SLMF_Members", "Join")%>
                    </td>
                    <td class="hforum34" >
                        <%= LoadSLMF("SLMF_Members", "LastOnline")%>
                    </td>
                </tr>
                <asp:Repeater ID="rptForum" runat="server" OnItemDataBound="rptForum_ItemDataBound" >
                    <ItemTemplate>
                        <tr class="forumshow" align="center">
                            <td >
                                <span class="postannount" ><%# Eval("RecordId") %></span>
                            </td>
                            <td class="forumshow1">
                                <a href='<%# "pm.aspx?id=2&memberid=" + Eval("MemberId") %>'><img src="SlmImages/pm.gif" alt="" class="imgForum" /></a>
                                <%--<a id="hrfEmail" runat="server" href='<%# "../em.aspx?memberid=" + Eval("MemberId") %>'><img src="SlmImages/emailToAuthor.gif" alt="" class="imgForum" /></a> --%>
                            </td>
                            <td class="forumshow1" >
                                <a class="TitleLnk" href='<%# "showprofile.aspx?memberid=" + Eval("MemberId") %>'><%# Eval("UserName") %></a>
                            </td>
                            <td class="forumtocpic">
                                <asp:Label runat="server" ID="lblGroup" CssClass="postannount"></asp:Label><br />
                                <img runat="server" id="imgRank" class="imgForum" />
                            </td>
                            <td class="forumshow1">
                                <a href='<%# "searchpro.aspx?author=" + Eval("UserName") %>' class="TitleLnk" ><%# Eval("TotalPosts")%></a>
                            </td>
                            <td class="forumtocpic">
                                <span class="postannount" ><%# AnnounceTime(DateTime.Parse(Eval("DateCreation").ToString()))%></span>
                            </td>
                            <td class="forumtocpic">
                                <span class="postannount" ><%# AnnounceTime(DateTime.Parse(Eval("LastLogin").ToString()))%></span>
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
                        <cc1:Pager ID="TMessage2" runat="server" PageSize="20" OfClause="/" PageClause="Trang" BackToPageClause="Trang trước:" NextToPageClause="Tiếp theo:" ShowingResultClause="Bài viết" ShowResultClause="Bài viết" ToClause="đến" OnCommand="TMessage2_Command" />
                    </td>
                    <td align="right"></td>
                </tr>
            </table>
        </td>
    </tr>
</table>