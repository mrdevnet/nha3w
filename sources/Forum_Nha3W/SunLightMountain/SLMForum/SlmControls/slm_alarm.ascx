<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_alarm.ascx.cs" Inherits="SlmControls_slm_alarm" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<script language="javascript" type="text/javascript">
    function submitvalidate()
    {
        if (document.getElementById("ctl00_slmf1_Slm_alarm1_txtSubject").value == "")
        {
            alert('<%= LoadText("SLMF_Report", "Form1Validate")%>');
            return false;
        }
//        if (document.getElementById("ctl00_slmf1_Slm_alarm1_FCKeditor1").value == "")
//        {
//            alert('<%= LoadText("SLMF_Report", "Form2Validate")%>');
//            return false;
//        }
        return true;
    }
</script>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink"><%= LoadText("WelHeader","ForumName") %></a>
            <span class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="hplCategory" ></a>
            <span runat="server" visible="false" id="panelparf1" class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="parf1" ></a>
            <span class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><a class="RedLink" runat="server" id="hplForum" ></a>
            <span class="GetSpace"><%= LoadText("SLMF_Forum", "Space")%></span><asp:Label ID="lblTopicTitle1" runat="server" CssClass="RedLink2" ></asp:Label>
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
                            <%= LoadText("SLMF_Report", "Title")%>
                        </span>
                    </td>
                    <td class="topichead" align="right">
                        <asp:Label ID="lblForumTitle" CssClass="CateTopic" runat="server"></asp:Label>
                    </td>
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
                        <%= LoadText("SLMF_Report", "Reason")%>
                    </td>
                    <td class="post2" >
                        <asp:textbox id="txtSubject" runat="server" CssClass="textPost"/>
                    </td>
                </tr>
                <tr>
                    <td class="post1" valign="top">
                        <%= LoadText("SLMF_Report", "Detail")%><br/>
                    </td>
                    <td class="post2" align="center">
                        <FCKeditorV2:FCKeditor ID="FCKeditor1" 
                                BasePath="~/FCKeditor/" 
                                ToolbarSet="F9Signature" 
                                Width="760px" 
                                Height="188px" 
                                AutoDetectLanguage="false" 
                                DefaultLanguage="en" 
                                SkinPath= 'skins/silver/' 
                                runat="server">
                        </FCKeditorV2:FCKeditor>
                    </td>
                </tr>
                <tr >
                    <td class="post1">
                        <%= LoadText("SLMF_Report", "Priority")%>
                    </td>
                    <td class="post2">
                        <asp:DropDownList ID="ddlPriority" DataTextField="PriorityName" DataValueField="PriorityId" runat="server" ></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="ftabletopic">
                        <asp:button id="btnSubmit" cssclass="btnSubmit" runat="server" OnClick="btnSubmit_Click" />&nbsp;
                        <span onclick="history.go(-1);"><input type="button" value="Quay lại" class="btnSubmit" /></span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>