<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_newtopic.ascx.cs" Inherits="SlmControls_slm_newtopic" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<script type="text/javascript">
    function previewmessage()
    {
        document.location = "#f9preview";
    }
</script>
<div id="f9preview"></div>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink"><%= LoadText("WelHeader","ForumName") %></a>
            <span class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="hplCategory" ></a>
            <span runat="server" visible="false" id="panelparf1" class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="parf1" ></a>
            <span class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="hplForum" ></a>
            <span class="GetSpace" runat="server" visible="false" id="panelTitle"><%= LoadText("SLMF_Forum", "Space")%></span><asp:Label ID="lblTopicTitle1" runat="server" CssClass="RedLink2" ></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="regtd2"></td>
    </tr>
    <tr>
        <td class="tblforum">
            <table class="tbltopicnew" cellpadding="0" cellspacing="1" width="100%">
                <tr>
                    <td class="topichead" >
                        <span class="CreateNewTopic">
                            <asp:Label ID="lblNew" runat="server" Text="Label"></asp:Label>
                        </span>
                    </td>
                    <td class="topichead" align="right">
                        <asp:Label ID="lblForumTitle" CssClass="CateTopic" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="rowpreview" runat="server" visible="false">
                    <td class="post1" valign="top">
                        <%= LoadText("SLMF_Topic", "Preview")%>
                    </td>
                    <td class="postpreview" id="previewcell" runat="server" valign="top"></td>
                </tr>
                <tr id="rowuser" runat="server">
                    <td class="post1" >
                        <%= LoadText("SLMF_Topic", "UserName")%>
                    </td>
                    <td class="post2b" >
                        <a class="MemberCreate" id="hrfMember" runat="server" ></a>
                    </td>
                </tr>
                <tr id="rowsubject" runat="server">
                    <td class="post1" >
                        <%= LoadText("SLMF_Topic", "Subject")%>
                    </td>
                    <td class="post2" >
                        <asp:textbox id="txtSubject" runat="server" CssClass="textPost"/>
                    </td>
                </tr>
                <tr id="rowpriority" runat="server" visible="false">
                    <td class="post1" >
                        <%= LoadText("SLMF_Topic", "Priority")%>
                    </td>
                    <td class="post2" >
                        <asp:RadioButton ID="rdoNormal" GroupName="priority" runat="server" Checked="true" />&nbsp;
                        <asp:RadioButton ID="rdoSticky" GroupName="priority" runat="server" />
                    </td>
                </tr>
                <tr id="rowcreatepoll" runat="server" visible="false">
                    <td class="postlnkPoll" >
                        <asp:linkbutton id="lbtCreatePoll" CssClass="lnkPoll" runat="server" OnClick="lbtCreatePoll_Click" />
                    </td>
                    <td class="post2" >&nbsp;</td>
                </tr>
                <asp:Panel ID="pnlPoll" runat="server" Visible="false">
                <tr>
                    <td class="post1" valign="top">
                        <em><%= LoadText("SLMF_Topic", "QuestionPoll")%></em>
                    </td>
                    <td class="post2">
                        <asp:textbox TextMode="MultiLine" Height="60px" maxlength="360" id="txtQuestion" runat="server" CssClass="textPost"/>
                    </td>
                </tr>
                <tr> 
                    <td class="post1">
                        <em><%= LoadText("SLMF_Topic", "Choice1")%></em>
                    </td>
                    <td class="post2">
                        <asp:textbox maxlength="120" id="txtChoice1" runat="server" CssClass="textPost"/>
                    </td>
                </tr>
                <tr> 
                    <td class="post1">
                        <em><%= LoadText("SLMF_Topic", "Choice2")%></em>
                    </td>
                    <td class="post2">
                        <asp:textbox maxlength="120" id="txtChoice2" runat="server" CssClass="textPost"/>
                    </td>
                </tr>
                <tr> 
                    <td class="post1">
                        <em><%= LoadText("SLMF_Topic", "Choice3")%></em>
                    </td>
                    <td class="post2">
                        <asp:textbox maxlength="120" id="txtChoice3" runat="server" CssClass="textPost"/>
                    </td>
                </tr>
                <tr> 
                    <td class="post1">
                        <em><%= LoadText("SLMF_Topic", "Choice4")%></em>
                    </td>
                    <td class="post2">
                        <asp:textbox maxlength="120" id="txtChoice4" runat="server" CssClass="textPost"/>
                    </td>
                </tr>
                <tr> 
                    <td class="post1">
                        <em><%= LoadText("SLMF_Topic", "Choice5")%></em>
                    </td>
                    <td class="post2">
                        <asp:textbox maxlength="120" id="txtChoice5" runat="server" CssClass="textPost"/>
                    </td>
                </tr>
                <tr> 
                    <td class="post1">
                        <em><%= LoadText("SLMF_Topic", "Choice6")%></em>
                    </td>
                    <td class="post2">
                        <asp:textbox maxlength="120" id="txtChoice6" runat="server" CssClass="textPost"/>
                    </td>
                </tr>
                <tr> 
                    <td class="post1">
                        <em><%= LoadText("SLMF_Topic", "Choice7")%></em>
                    </td>
                    <td class="post2">
                        <asp:textbox maxlength="120" id="txtChoice7" runat="server" CssClass="textPost"/>
                    </td>
                </tr>
                <tr> 
                    <td class="post1">
                        <em><%= LoadText("SLMF_Topic", "Choice8")%></em>
                    </td>
                    <td class="post2">
                        <asp:textbox maxlength="120" id="txtChoice8" runat="server" CssClass="textPost"/>
                    </td>
                </tr>
                <tr> 
                    <td class="post1">
                        <em><%= LoadText("SLMF_Topic", "Choice9")%></em>
                    </td>
                    <td class="post2">
                        <asp:textbox maxlength="120" id="txtChoice9" runat="server" CssClass="textPost"/>
                    </td>
                </tr>
                <tr id="rowexpire" runat="server">
                    <td class="post1" >
                        <em><%= LoadText("SLMF_Topic", "PollExpire")%></em>
                    </td>
                    <td class="post2" >
                        <asp:TextBox maxlength="10" CssClass="textExpire" id="txtPollDays" runat="server" />
                        <asp:RangeValidator Display="Dynamic" ID="rvDays" runat="server" ControlToValidate="txtPollDays" MinimumValue="1" MaximumValue="1000" Type="Integer"></asp:RangeValidator>&nbsp;
                        <%= LoadText("SLMF_Topic", "PollExpain")%>
                    </td>
                </tr>
                </asp:Panel>
                <tr>
                    <td class="post1" valign="top">
                        <%= LoadText("SLMF_Topic", "Message")%><br/>
                    </td>
                    <td class="post2" align="center">
                        <FCKeditorV2:FCKeditor ID="FCKeditor1" 
                                BasePath="~/FCKeditor/" 
                                ToolbarSet="F9" 
                                Width="760px" 
                                Height="288px" 
                                AutoDetectLanguage="false" 
                                DefaultLanguage="en" 
                                SkinPath= 'skins/silver/' 
                                runat="server">
                        </FCKeditorV2:FCKeditor>
                    </td>
                </tr>
                <tr >
                    <td class="post1" >
                        <%= LoadText("SLMF_Topic", "Option")%>
                    </td>
                    <td class="post2">
                        <asp:CheckBox ID="ckbAddSignature" runat="server" />
                        <%= LoadText("SLMF_Topic", "AddSignature")%>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="ftabletopic">
                        <asp:Button id="btnPreview" cssclass="btnSubmit" runat="server" OnClick="btnPreview_Click" />&nbsp;
                        <asp:button id="btnSubmit" cssclass="btnSubmit" runat="server" OnClick="btnSubmit_Click" />&nbsp;
                        <span onclick="history.go(-1);"><input type="button" value="Quay lại" class="btnSubmit" /></span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>