<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_rating.ascx.cs" Inherits="SlmControls_slm_rating" %>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd2">
            <span class="postannount"><%= LoadSLMF("SLMF_Rating", "Rating")%></span> <asp:DropDownList class="fontmsg" ID="ddlRating" runat="server"></asp:DropDownList> 
            <asp:Button ID="btnRating" CssClass="btnReg" runat="server" OnClick="btnRating_Click"/>
        </td>
    </tr>
    <tr>
        <td class="msgtd2">
        </td>
    </tr>
    <tr>
        <td class="tblforum">
            <table cellpadding="0" cellspacing="1" class="forum" >
                <tr>
                    <td class="topichead" colspan="2" >
                        <span class="TopicName"><%= LoadSLMF("SLMF_Rating", "MemberRate")%></span>
                    </td>
                </tr>
                <tr>
                    <td class="rating2">
                        <%= LoadSLMF("SLMF_Rating", "Member")%>
                    </td>
                    <td class="rating3" >
                        <%= LoadSLMF("SLMF_Rating", "Time")%>
                    </td>
                </tr>
                <asp:Repeater ID="rptRating" runat="server">
                    <ItemTemplate>
                        <tr class="showtopic1">
                            <td class="ForumDescript">
                                <a class="TopicLink" id="hrfStarter"><%# Eval("UserName")%></a>
                            </td>
                            <td >
                                <span class="TopicName"><%# AnnounceTime(DateTime.Parse(Eval("RatingDate").ToString())) %></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </td>
    </tr>
</table>