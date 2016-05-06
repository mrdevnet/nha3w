<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_poll.ascx.cs" Inherits="SlmControls_slm_poll" %>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="static2"></td>
    </tr>
    <tr>
        <td class="tblforum">
            <table cellpadding="0" cellspacing="1" class="forum" >
                <tr>
                    <td class="hforumAnnounce">
                        <asp:Label ID="lblTitlePoll" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr class="forumshow">
                    <td class="ForumDescript">
                        <table >
                            <tr>
                                <td align="center">
                                    <a id="hrfAnnounce" runat="server" class="ForumLink" ></a>
                                </td>
                            </tr>
                            <tr>
                                <td class="postannount" valign="top">
                                    <div style="width: 90%;" align="center">
                                        <fieldset class="fieldset">
				                            <legend><%= LoadText("SLMF_Announce", "NewAnnounce")%></legend>
				                            <div style="padding: 3px;">
				                                <div style="margin-bottom: 3px;"><strong><asp:Label ID="lblTitlePoll2" runat="server" ></asp:Label></strong></div>
                                                <asp:RadioButtonList ID="rlPoll" runat="server"></asp:RadioButtonList>
				                            </div>
			                            </fieldset>
			                            <div>
			                                <span style="float: right;"><a href="poll.php?do=showresults&amp;pollid=7"><%= LoadText("SLMF_Announce", "NewAnnounce")%></a></span>
                                            <asp:Button ID="btnSubmit" runat="server"/>
			                            </div>
			                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                            </tr>
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