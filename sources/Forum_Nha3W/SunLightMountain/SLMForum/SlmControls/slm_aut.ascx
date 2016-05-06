<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_aut.ascx.cs" Inherits="SlmControls_slm_aut" %>
<table width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td valign="top">
            <table cellpadding="1" cellspacing="1" class="fontmsg" runat="server" id="tblAccess">
                <tr>
                    <td>
                        <img src="slmimages/topic_new.png" /> <%= LoadSLMF("SLMF_Topic", "IconTopicNew")%>
                    </td>
                    <td>
                        <img src="slmimages/topic.gif" /> <%= LoadSLMF("SLMF_Topic", "IconTopic")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="slmimages/topic_lock_new.gif" /> <%= LoadSLMF("SLMF_Topic", "IconNewLocked")%>
                    </td>
                    <td>
                        <img src="slmimages/topic_lock.gif" /> <%= LoadSLMF("SLMF_Topic", "IconLocked")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="slmimages/topic_announce.gif" /> <%= LoadSLMF("SLMF_Topic", "IconAnnouncement")%>
                    </td>
                    <td>
                        <img src="slmimages/topic_sticky.gif" /> <%= LoadSLMF("SLMF_Topic", "IconSticky")%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="slmimages/topic_moved.gif" /> <%= LoadSLMF("SLMF_Topic", "IconMoved")%>
                    </td>
                    <td>
                        <img src="slmimages/topic_poll.gif" /> <%= LoadSLMF("SLMF_Topic", "IconPoll")%>
                    </td>
                </tr>
            </table>
        </td>
        <td align="right">
            <table cellspacing="1" cellpadding="1">
                <tr>
                    <td align="right" valign="top" class="AccessForum">
                        <%= AccessForum() %>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>