<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_search.ascx.cs" Inherits="SlmControls_slm_search" %>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink"><%= LoadSLMF("WelHeader","ForumName") %></a>
            <span class="GetSpace"><%= LoadSLMF("SLMF_Forum", "Space")%></span><span class="RedLink2"><%= LoadSLMF("SLMF_SearchAdv", "Title")%></span>
        </td>
    </tr>
    <tr>
        <td class="regtd2"></td>
    </tr>
</table>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost" >
            <span class="reg2lblTitle"><%= LoadSLMF("SLMF_SearchAdv", "Title")%></span>
        </td>
    </tr>
    <tr>
        <td >
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="50%" valign="top">
                        <table cellpadding="0" align="center" cellspacing="1" class="tblMost">
                            <tr>
                                <td class="TopMost2" align="center">
                                    <span class="MostLink"><%= LoadSLMF("SLMF_SearchAdv", "Keyword")%></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid" align="center" style="padding-bottom:8px;padding-top:8px;padding-left:8px;padding-right:8px">
                                    <fieldset class="fieldset">
			                            <legend><span style="color:#3b5998"><strong><%= LoadSLMF("SLMF_SearchAdv", "Keyword2")%></strong></span></legend>
			                            <div style="padding: 9px;">
                                            <asp:TextBox ID="txtKeyword" CssClass="textPost" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvKey" runat="server" ControlToValidate="txtKeyword" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator><br />
                                            <asp:RadioButton Checked="true" GroupName="rbtSearch" ID="rbtTitle" runat="server" />&nbsp;&nbsp;
                                            <asp:RadioButton GroupName="rbtSearch" ID="rbtMsg" runat="server" />
			                            </div>
		                            </fieldset>
		                            <fieldset class="fieldset">
			                            <legend><span style="color:#3b5998"><strong><%= LoadSLMF("SLMF_SearchAdv", "ByAuthor2")%></strong></span></legend>
			                            <div style="padding: 9px;">
                                            <asp:TextBox ID="txtAuthor" CssClass="textPost" runat="server"></asp:TextBox>
			                            </div>
		                            </fieldset>
		                            <fieldset class="fieldset">
			                            <legend><span style="color:#3b5998"><strong><%= LoadSLMF("SLMF_SearchAdv", "SecurityCode")%></strong></span></legend>
			                            <div style="padding: 8px;">
                                            <asp:TextBox ID="txtSecurity" CssClass="textPostSerc" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvSerc" runat="server" ControlToValidate="txtKeyword" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            <img align="absmiddle" src="secrcode.aspx" oncontextmenu="return false" />
			                            </div>
		                            </fieldset>
		                        </td>
                            </tr>
                        </table>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="49%" valign="top">
                        <table cellpadding="0" align="center" cellspacing="1" class="tblMost">
                            <tr>
                                <td class="TopMost2" align="center">
                                    <span class="MostLink"><%= LoadSLMF("SLMF_SearchAdv", "ListForum")%></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid" align="center" style="padding-bottom:8px;padding-top:8px;padding-left:8px;padding-right:8px">
                                    <fieldset class="fieldset">
			                            <legend><span style="color:#3b5998"><strong><%= LoadSLMF("SLMF_SearchAdv", "FollowForum")%></strong></span></legend>
			                            <div style="padding: 7px;">
                                            <asp:ListBox ID="lstForum" runat="server" SelectionMode="Single" Height="125px"></asp:ListBox>
			                            </div>
		                            </fieldset>
		                            <fieldset class="fieldset">
			                            <legend><span style="color:#3b5998"><strong><%= LoadSLMF("SLMF_SearchAdv", "Order")%></strong></span></legend>
			                            <div style="padding: 7px;">
                                            <asp:RadioButton Checked="true" GroupName="rbtOrder" ID="rbtAsc" runat="server" />&nbsp;&nbsp;
                                            <asp:RadioButton GroupName="rbtOrder" ID="rbtDesc" runat="server" />
			                            </div>
		                            </fieldset>
		                        </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td height="12px" valign="top">
        </td>
    </tr>
    <tr>
        <td valign="top" align="center">
            <asp:Button ID="btnSearch" CssClass="btnReg" runat="server" OnClick="btnSearch_Click" />
        </td>
    </tr>
</table>