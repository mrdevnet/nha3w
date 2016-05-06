<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_movetopic.ascx.cs" Inherits="SlmControls_slm_movetopic" %>
<%@ Register Src="slm_jump.ascx" TagName="slm_jump" TagPrefix="uc1" %>
<table cellpadding="0" cellspacing="1" class="forum" >
    <tr>
        <td class="topichead" colspan="2" >
            <span class="TopicName"><%= LoadSLMF("SLMF_Topic", "MoveTopic")%></span>
        </td>
    </tr>
    <tr>
        <td class="rating2" >
            <%--<%= LoadSLMF("SLMF_Topic", "MoveRelation")%>--%>
            <asp:RadioButton ID="rbtOldLink" runat="server" Checked="true" GroupName="Link" />&nbsp;
            <asp:RadioButton ID="rbtNotOldLink" runat="server" GroupName="Link" />
        </td>
    </tr>
    <tr>
        <td class="rating2" >
            <asp:DropDownList ID="ddlJumper" CssClass="fontmsg" runat="server" ></asp:DropDownList>
        </td>
    </tr>
</table>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="msgtd2"><br />
        </td>
    </tr>
    <tr>
        <td class="regtd2" align="center">
            <asp:Button ID="btnMoveTopic" CssClass="btnReg" runat="server" OnClick="btnMoveTopic_Click" />&nbsp;
            <asp:Button ID="btnClose" OnClientClick="javascript:window.close();" CssClass="btnReg" runat="server" />
        </td>
    </tr>
</table>