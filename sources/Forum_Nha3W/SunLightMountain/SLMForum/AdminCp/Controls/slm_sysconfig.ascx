<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_sysconfig.ascx.cs" Inherits="AdminCp_Controls_slm_sysconfig" %>

<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_GeneralA", "System")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "AdminEmail")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtAdminEmail" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "AllowSignup")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:CheckBox ID="ckbAllowSignup" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "AllowLogin")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:CheckBox ID="ckbAllowLogin" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "MaxMsg")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtMaxMsg" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "SessionTimeOut")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtSessionTimeout" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="90%" colspan="3" style="padding:5px">
                    <hr noshade size="1">
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "GuestSearch")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:CheckBox ID="ckbGuestSearch" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "GuestProfile")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:CheckBox ID="ckbGuestProfile" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "GuestMember")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:CheckBox ID="ckbGuestMember" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="90%" colspan="3" style="padding:5px">
                    <hr noshade size="1">
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "HideRecycleBin")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:CheckBox ID="ckbHideRecycleBin" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "ActiveMember")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:CheckBox ID="ckbActiveMember" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "ReviewMember")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:CheckBox ID="ckbReviewMember" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "TimePostAgain")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtTimePostAgain" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="90%" colspan="3" style="padding:5px">
                    <hr noshade size="1">
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "MaxLogin")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtMaxLogin" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "SiteStart")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:Label ID="lblStarted" runat="server" CssClass="editprotxt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="90%" colspan="3" style="padding:5px">
                    <hr noshade size="1">
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro"></td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:Button CssClass="btnReg" ID="btnSave" runat="server" OnClientClick="GetSlmEnc();" OnClick="btnSave_Click"/>
                        &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/> 
                        <asp:Label ID="lblReport" runat="server" CssClass="editprore"></asp:Label>
                        <script type="text/javascript"  language="Javascript">
                        function GetSlmEnc()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_sysconfig1_imgSpinner2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_sysconfig1_imgSpinner2"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_sysconfig1_imgSpinner2"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_sysconfig1_imgSpinner2"].height = "16";
                        }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height:8px"></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>