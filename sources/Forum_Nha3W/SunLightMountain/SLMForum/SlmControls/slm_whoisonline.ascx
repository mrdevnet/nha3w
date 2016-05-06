<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_whoisonline.ascx.cs" Inherits="SlmControls_slm_whoisonline" %>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink" ><%= LoadSLMF("WelHeader","ForumName") %></a>
            <span class="GetSpace"><%= LoadSLMF("SLMF_Forum", "Space")%></span>
            <span class="RedLink2"><%= LoadSLMF("SLMF_Online", "WhoisOnline")%></span>
        </td>
    </tr>
    <tr>
        <td class="regtd2"></td>
    </tr>
    <tr>
        <td class="tblforum">
            <table cellpadding="0" cellspacing="1" class="forum" >
                <tr>
                    <td class="hforum22">
                        <%= LoadSLMF("SLMF_Online", "User")%>
                    </td>
                    <td class="hforum23" >
                        <%= LoadSLMF("SLMF_Online", "Action")%>
                    </td>
                    <td class="hforum24" >
                        <%= LoadSLMF("SLMF_Online", "LastAction")%>
                    </td>
                    <td class="hforum25" >
                        <%= LoadSLMF("SLMF_Online", "TimeOfOnline")%>
                    </td>
                </tr>
                <tr>
                    <td class="forum2" colspan="4" >
                        <img src="SlmImages/icon2.gif" alt="" class="imgCategory"/>
                        <span class="MostLink2"><%= Details()%></span>
                    </td>
                </tr>
                <asp:Repeater ID="rptForum" runat="server" OnItemDataBound="rptForum_ItemDataBound" >
                    <ItemTemplate>
                        <tr class="forumshow">
                            <td class="ForumDescript">
                                <a class="TopicLink2" href='<%# "showprofile.aspx?memberid=" + Eval("MemberId") %>'><%# Eval("UserName") %></a>
                            </td>
                            <td class="forumshow12" >
                                <asp:Label CssClass="postannount" ID="lblAction" runat="server" ></asp:Label> 
                                <a id="hrfAction" runat="server" class="ForumLink" ></a>
                            </td>
                            <td class="forumshow1">
                                <span class="postannount" ><%# System.DateTime.Parse(Eval("Posted").ToString()).ToLongTimeString() %></span>
                            </td>
                            <td class="forumtocpic">
                                <span class="postannount" ><%# Eval("Online") + " phút" %></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </td>
    </tr>
    <tr>
        <td class="static2"></td>
    </tr>
    <tr>
        <td class="tblforum">
        </td>
    </tr>    
</table>