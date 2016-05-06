<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_topannoun.ascx.cs" Inherits="SlmControls_slm_topannoun" %>
<table cellpadding="0" cellspacing="0" class="tblreg" id="rptPanel" runat="server">
    <tr>
        <td class="static2"></td>
    </tr>
    <tr>
        <td class="tblforum">
            <table cellpadding="0" cellspacing="1" class="forum" >
                <tr>
                    <td class="hforumAnnounce">
                        <%= LoadSLMF("SLMF_Announce", "NewAnnounce")%>
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
                                    <asp:Label ID="lblDescription" runat="server" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <a id="hrfDetail" runat="server" class="ForumLink" ></a>
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