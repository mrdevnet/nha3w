<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_updelmember.ascx.cs" Inherits="AdminCp_Controls_slm_updelmember" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_UserA", "System")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "UserName")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="editprotxt"></asp:TextBox> 
                        <asp:LinkButton id="lbtBlockUser" OnClientClick="GetSlmEnc2();" runat="server" OnClick="lbtBlockUser_Click"><img style="border:0px" src="../slmimages/Approve12.PNG" /></asp:LinkButton> 
                        <asp:LinkButton id="lbtCloseBlock" OnClientClick="GetSlmEnc2();" Visible="false" runat="server" OnClick="lbtCloseBlock_Click" ><img style="border:0px" src="../slmimages/Approve1.PNG" /></asp:LinkButton>
                        &nbsp;&nbsp;<img id="imgBlock" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/>
                    </td>
                </tr>
            </table>
                <asp:Panel ID="pnlBlockUser" runat="server" Visible="false">
                <div style="padding:8px">
                <fieldset >
                <legend>{<%= LoadSLMF("SLMF_UserA", "BlockUser")%>}</legend>
                <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "BlockStatus")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:RadioButton ID="rbtBlock" runat="server" GroupName="BlockUser"/>
                        <asp:RadioButton ID="rbtUnBlock" runat="server" Checked="true" GroupName="BlockUser"/>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "BlockStart")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtStart" runat="server" CssClass="editprotxt"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtStart">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "BlockFinish")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtFinish" runat="server" CssClass="editprotxt"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender2" runat="server" TargetControlID="txtFinish">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "BlockReason")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtReason" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:Button CssClass="btnReg" ID="btnUpdateBlock" runat="server" OnClientClick="GetSlmEnc3();" OnClick="btnUpdateBlock_Click" />
                        &nbsp;&nbsp;<img id="imgUpdateBlock" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/> 
                        <asp:Label ID="lblBlockUser" runat="server" CssClass="editprore"></asp:Label>
                    </td>
                </tr>
                </table>
                </fieldset>
                </div>
                </asp:Panel>
                <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "MemberTitle")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtMemberTitle" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "Avatar")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <img id="imgAvatar" alt="" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "Email")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "FullName")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtFullName" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="90%" colspan="3" style="padding:5px">
                    <hr noshade size="1">
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "Gender")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:RadioButton ID="rbtMale" runat="server" Checked="true" GroupName="Gender"/>
                        <asp:RadioButton ID="rbtFemale" runat="server" GroupName="Gender"/>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "UserStatus")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:RadioButton ID="rbtOnline" runat="server" Checked="true" GroupName="Online"/>
                        <asp:RadioButton ID="rbtOffline" runat="server" GroupName="Online"/>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "DateCreation")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtDateCreation" runat="server" CssClass="editprotxt"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="cldDate" runat="server" TargetControlID="txtDateCreation">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "IsActivated")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:RadioButton ID="rbtActivated" runat="server" Checked="true" GroupName="Activated"/>
                        <asp:RadioButton ID="rbtNotActivated" runat="server" GroupName="Activated"/>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "EnableLogin")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:RadioButton ID="rbtLogin" runat="server" Checked="true" GroupName="Login"/>
                        <asp:RadioButton ID="rbtNotLogin" runat="server" GroupName="Login"/>
                    </td>
                </tr>
                <tr>
                    <td width="90%" colspan="3" style="padding:5px">
                    <hr noshade size="1">
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "AboutMe")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtAboutMe" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "Interests")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtInterests" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "Job")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtJob" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "Location")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtLocation" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "Birthday")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtBirthday" runat="server" CssClass="editprotxt"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="cldBirthday" runat="server" TargetControlID="txtBirthday">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td width="90%" colspan="3" style="padding:5px">
                    <hr noshade size="1">
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "Yahoo")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtYahoo" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "AIM")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtAim" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "ICQ")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtIcq" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "MSN")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtMsn" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "Blog")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtBlog" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "HomePage")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtHomePage" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="90%" colspan="3" style="padding:5px">
                    <hr noshade size="1">
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "Signature")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtSignature" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "AlwaysSig")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:RadioButton ID="rbtAlways" runat="server" Checked="true" GroupName="AlwaysSig"/>
                        <asp:RadioButton ID="rbtNotAlways" runat="server" GroupName="AlwaysSig"/>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "IP")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtIp" runat="server" CssClass="editprotxt"></asp:TextBox>
                        <asp:LinkButton id="lbtExpandIp" OnClientClick="GetSlmEnc5();" runat="server" OnClick="lbtExpandIp_Click" ><img style="border:0px" src="../slmimages/expand.gif" /></asp:LinkButton> 
                        <asp:LinkButton id="lbtCloseIp" OnClientClick="GetSlmEnc5();" Visible="false" runat="server" OnClick="lbtCloseIp_Click" ><img style="border:0px" src="../slmimages/collapse.gif" /></asp:LinkButton>
                        &nbsp;&nbsp;<img id="imgBlockIp2" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/>
                    </td>
                </tr>
                </table>
                <asp:Panel ID="pnlBlockIp" runat="server" Visible="false">
                <div style="padding:8px">
                <fieldset >
                <legend>{<%= LoadSLMF("SLMF_UserA", "ExpandIp")%>}</legend>
                <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "IP")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtIp2" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "BlockStatus")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:RadioButton ID="rbtLockIp" runat="server" GroupName="BlockIp"/>
                        <asp:RadioButton ID="rbtUnLockIp" runat="server" Checked="true" GroupName="BlockIp"/>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "BlockIpDate")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtBlockIpDate" runat="server" CssClass="editprotxt"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender3" runat="server" TargetControlID="txtBlockIpDate">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "BlockReason")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtReasonIp" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:Button CssClass="btnReg" ID="btnBlockIp" runat="server" OnClientClick="GetSlmEnc4();" OnClick="btnBlockIp_Click" />
                        &nbsp;&nbsp;<img id="imgBlockIp" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/> 
                        <asp:Label ID="lblBlockIp" runat="server" CssClass="editprore"></asp:Label>
                    </td>
                </tr>
                </table>
                </fieldset>
                </div>
                </asp:Panel>
                <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "IsEmailPublished")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:RadioButton ID="rbtPublished" runat="server" Checked="true" GroupName="IsEmailPublished"/>
                        <asp:RadioButton ID="rbtNotPublished" runat="server" GroupName="IsEmailPublished"/>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "CanSendE")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:RadioButton ID="rbtCanSend" runat="server" Checked="true" GroupName="CanSendE"/>
                        <asp:RadioButton ID="rbtNotCanSend" runat="server" GroupName="CanSendE"/>
                    </td>
                </tr>
                <tr>
                    <td width="90%" colspan="3" style="padding:5px">
                    <hr noshade size="1">
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "TotalPosts")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtTotalPosts" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "CountLostPass")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtCountLostPass" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "LastLogin")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:Label ID="lblLastLogin" runat="server" CssClass="editprotxt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "LastBrowse")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:Label ID="lblLastBrowse" runat="server" CssClass="editprotxt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "Posted")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:Label ID="lblPosted" runat="server" CssClass="editprotxt"></asp:Label>
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
                        <asp:Button CssClass="btnReg" ID="btnSave" runat="server" OnClientClick="GetSlmEnc();" OnClick="btnSave_Click" />
                        &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/> 
                        <asp:Label ID="lblReport" runat="server" CssClass="editprore"></asp:Label>
                        <script type="text/javascript"  language="Javascript">
                        function GetSlmEnc()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgSpinner2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgSpinner2"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgSpinner2"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgSpinner2"].height = "16";
                        }
                        
                        function GetSlmEnc2()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlock"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlock"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlock"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlock"].height = "16";
                        }
                        
                        function GetSlmEnc3()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgUpdateBlock"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgUpdateBlock"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgUpdateBlock"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgUpdateBlock"].height = "16";
                        }
                        
                        function GetSlmEnc4()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlockIp"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlockIp"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlockIp"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlockIp"].height = "16";
                        }
                        
                        function GetSlmEnc5()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlockIp2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlockIp2"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlockIp2"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlockIp2"].height = "16";
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