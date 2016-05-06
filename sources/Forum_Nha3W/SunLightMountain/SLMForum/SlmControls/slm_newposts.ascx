<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_newposts.ascx.cs" Inherits="SlmControls_slm_newposts" %>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="msgtd2"></td>
    </tr>
    <tr>
        <td class="tblforum">
            <table cellpadding="0" cellspacing="1" class="forum" >
                <tr>
                    <td class="hforum44">
                        <%= LoadSLMF("SLMF_Active", "Topic")%>
                    </td>                                        
                    <td class="hforum13" >
                        <%= LoadSLMF("SLMF_Active", "Reply")%>
                    </td>
                    <td class="hforum44">
                        <%= LoadSLMF("SLMF_Active", "Topic")%>
                    </td>                                        
                    <td class="hforum13" >
                        <%= LoadSLMF("SLMF_Active", "Reply")%>
                    </td>
                </tr>
                <tr class="forumshow" >
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="1" class="forum">
                            <asp:Repeater ID="rptForum" runat="server" >
                                <ItemTemplate>
                                <tr class="forumshow">
                                    <td class="ForumDescript" width="43%">
                                        <img align="absmiddle" src="slmimages/post_new.gif" /> <a title='<%# "[" + LoadSLMF("SLMF_Active", "LastPost") + ": " + Eval("LastAuthor") + " | " + LoadSLMF("SLMF_Active", "Reply") + ": " + Eval("TotalReplies") + " | " + LoadSLMF("SLMF_Active", "View") + ": " + Eval("TotalViews") + " | " + LoadSLMF("SLMF_Active", "Forum") + ": " + Eval("Name") + "]" %>' href='<%# "showtopic.aspx?goto=newmessage&topicid=" + Eval("TopicId") %>' class="NewPsts" ><%# Eval("Title") %></a>
                                    </td>
                                    <td class="forumshow1" width="7%">
                                        <span class="postannount" ><%# Eval("TotalReplies") %></span>
                                    </td>
                                </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="1" class="forum">
                            <asp:Repeater ID="rptForum2" runat="server" >
                                <ItemTemplate>
                                <tr class="forumshow">
                                    <td class="ForumDescript" width="43%">
                                        <img align="absmiddle" src="slmimages/post_new.gif" /> <a title='<%# "[" + LoadSLMF("SLMF_Active", "LastPost") + ": " + Eval("LastAuthor") + " | " + LoadSLMF("SLMF_Active", "Reply") + ": " + Eval("TotalReplies") + " | " + LoadSLMF("SLMF_Active", "View") + ": " + Eval("TotalViews") + " | " + LoadSLMF("SLMF_Active", "Forum") + ": " + Eval("Name") + "]" %>' href='<%# "showtopic.aspx?goto=newmessage&topicid=" + Eval("TopicId") %>' class="NewPsts" ><%# Eval("Title") %></a>
                                    </td>
                                    <td class="forumshow1" width="7%">
                                        <span class="postannount" ><%# Eval("TotalReplies") %></span>
                                    </td>
                                </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="regtd2"></td>
    </tr>
</table>