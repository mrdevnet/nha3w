<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_pm.ascx.cs" Inherits="SlmControls_slm_pm" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<table cellpadding="0" cellspacing="0" class="tblreg">
    <tr>
        <td class="regtd1">
            <img style="vertical-align:middle" src="slmimages/home.png"/> <a href="Default.aspx" class="RedLink"><%= LoadSLMF("WelHeader","ForumName") %></a>
            <span class="GetSpace"><%= LoadSLMF("SLMF_Forum", "Space")%></span><span class="RedLink2"><%= LoadSLMF("SLMF_CPUser", "ControlPanel")%></span>
        </td>
    </tr>
    <tr>
        <td class="regtd2"></td>
    </tr>
</table>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost" >
            <span class="reg2lblTitle"><%= LoadSLMF("SLMF_CPUser", "YourProfile")%>: 
            <asp:Label ID="lblUserName" runat="server" ></asp:Label></span>
        </td>
    </tr>
    <tr>
        <td >
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="19%" valign="top">
                        <table cellpadding="0" align="center" cellspacing="1" class="tblMost">
                            <tr>
                                <td class="TopMost2" align="center">
                                    <a href="profile.aspx"><span class="MostLink"><%= LoadSLMF("SLMF_Profile", "Personal")%></span></a>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid">
                                    <a href="editprofile.aspx" class="editpro"><%= LoadSLMF("SLMF_CPUser", "EditProfile")%></a><br />
                                    <a href="editavatar.aspx" class="editpro"><%= LoadSLMF("SLMF_CPUser", "EditAvatar")%></a>
                                </td>
                            </tr>
                            <tr>
                                <td class="TopMost2" align="center">
                                    <span class="MostLink"><%= LoadSLMF("SLMF_CPUser", "PersonalMessage")%></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid">
                                    <a href="pm.aspx?id=0" class="editpro"><%= LoadSLMF("SLMF_CPUser", "PmInbox")%></a><br />
                                    <a href="pm.aspx?id=1" class="editpro"><%= LoadSLMF("SLMF_CPUser", "PmSent")%></a><br />
                                    <a href="pm.aspx?id=2" class="editpro"><%= LoadSLMF("SLMF_CPUser", "PmNew")%></a>
                                    <%--<br /><a href="em.aspx" class="editpro"><%= LoadSLMF("SLMF_CPUser", "EmailNew")%></a>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="TopMost2" align="center">
                                    <span class="MostLink"><%= LoadSLMF("SLMF_CPUser", "Options")%></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="Mid">
                                    <a href="signature.aspx" class="editpro"><%= LoadSLMF("SLMF_CPUser", "Signature")%></a>
                                    <%--<br /><a href="changepassword.aspx" class="editpro"><%= LoadSLMF("SLMF_CPUser", "EmailPass")%></a>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="80%" valign="top">
                        <ajaxToolkit:TabContainer ID="TabContainer2" runat="server">
                        <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" >
                            <HeaderTemplate>
                                <%= LoadSLMF("SLMF_Pm", "Inbox")%>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:UpdatePanel ID="updLogin" runat="server">
                                    <ContentTemplate>
                                        <table cellpadding="0" align="center" cellspacing="1" class="tblMost">
                                            <tr>
                                                <td class="TopMost2" align="center">
                                                    <span class="MostLink"><%= LoadSLMF("SLMF_CPUser", "PmInbox")%></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Mid">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="100%" colspan="3">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left" valign="top">
                                                                            <asp:GridView Width="100%" BorderColor="silver" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" ID="grvPmMail" runat="server" AutoGenerateColumns="False" ShowHeader="False" OnRowDeleting="grvPmMail_RowDeleting" OnSelectedIndexChanged="grvPmMail_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="grvPmMail_PageIndexChanging" PageSize="8" BorderWidth="1px" DataKeyNames="PmId" OnRowDataBound="grvPmMail_RowDataBound">
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <img runat="server" id="imgPm" src="../SlmImages/board_s.gif" />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="4%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="Title">
                                                                                        <ItemStyle Font-Bold="True" Width="48%" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <a class="TopicLink" href='<%# "showprofile.aspx?memberid=" + Eval("FromMember") %>'><%= LoadSLMF("SLMF_Pm", "From")%> <%# Eval("UserName")%></a>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="14%"/>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <%# AnnounceTime(DateTime.Parse(Eval("Sent").ToString())) %>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="20%"/>
                                                                                    </asp:TemplateField>
                                                                                    <asp:CommandField SelectText="Xem" ShowSelectButton="True">
                                                                                        <ItemStyle Width="7%" Font-Names="Verdana" Font-Size="11px" HorizontalAlign="Center" VerticalAlign="Middle"/>
                                                                                    </asp:CommandField>
                                                                                    <asp:CommandField DeleteText="X&#243;a" ShowDeleteButton="True" >
                                                                                        <ItemStyle Width="7%" Font-Names="Verdana" Font-Size="11px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                    </asp:CommandField>
                                                                                </Columns>
                                                                                <PagerStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                <RowStyle Height="28px" />
                                                                                <SelectedRowStyle BackColor="#d3d9e1" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <script type="text/javascript"  language="Javascript">
                                                                function GetSlmEnc()
                                                                {
                                                                document.aspnetForm["ctl00_slmf1_Slm_pm1_TabContainer2_TabPanel4_imgSpinner2"].src = "SlmImages/progress.gif";
                                                                document.aspnetForm["ctl00_slmf1_Slm_pm1_TabContainer2_TabPanel4_imgSpinner2"].visible = true;
                                                                document.aspnetForm["ctl00_slmf1_Slm_pm1_TabContainer2_TabPanel4_imgSpinner2"].width = "16";
                                                                document.aspnetForm["ctl00_slmf1_Slm_pm1_TabContainer2_TabPanel4_imgSpinner2"].height = "16";
                                                                }
                                                            </script>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" width="90%" colspan="3" style="padding-left:5px;padding-right:5px">
                                                                <img id="imgSpinner2" alt="" visible="true" src="../SlmImages/onepix1.jpg" runat="server"/>
                                                            </td>
                                                        </tr>
                                                        <tr id="tdMessage2" runat="server" visible="false">
                                                            <td width="90%" colspan="3" style="padding-left:5px;padding-right:5px">
                                                            <hr noshade size="1">
                                                            </td>
                                                        </tr>
                                                        <tr id="tdMessage" runat="server" visible="false">
                                                            <td width="100%" colspan="3">
                                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="4%"></td>
                                                                        <td width="96%" valign="top" class="postmsg2">
                                                                            <strong><asp:Label runat="server" ID="lblTitle" ></asp:Label></strong> 
                                                                            <asp:Label runat="server" ID="lblTime" ></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="4%"></td>
                                                                        <td width="96%" height="4px"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="4%"></td>
                                                                        <td width="96%" valign="top" class="postmsg2">
                                                                            <asp:Label runat="server" ID="lblMessage" ></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="grvPmMail" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" >
                                <HeaderTemplate>
                                    <%= LoadSLMF("SLMF_Pm", "Sent")%>
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table cellpadding="0" align="center" cellspacing="1" class="tblMost">
                                            <tr>
                                                <td class="TopMost2" align="center">
                                                    <span class="MostLink"><%= LoadSLMF("SLMF_CPUser", "PmSent")%></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Mid">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="100%" colspan="3">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left" valign="top">
                                                                            <asp:GridView Width="100%" BorderColor="silver" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle" ID="grvPmMail2" runat="server" AutoGenerateColumns="False" ShowHeader="False" AllowPaging="True" PageSize="8" BorderWidth="1px" DataKeyNames="PmId" OnPageIndexChanging="grvPmMail2_PageIndexChanging" OnRowDataBound="grvPmMail2_RowDataBound" OnSelectedIndexChanged="grvPmMail2_SelectedIndexChanged" >
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <img runat="server" id="imgPm2" src="../SlmImages/board_s.gif" />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="4%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="Title">
                                                                                        <ItemStyle Font-Bold="True" Width="48%" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <a class="TopicLink" href='<%# "showprofile.aspx?memberid=" + Eval("ToMember") %>'><%= LoadSLMF("SLMF_Pm", "To")%> <%# Eval("UserName")%></a>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="14%"/>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <%# AnnounceTime(DateTime.Parse(Eval("Sent").ToString())) %>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="20%"/>
                                                                                    </asp:TemplateField>
                                                                                    <asp:CommandField SelectText="Xem" ShowSelectButton="True">
                                                                                        <ItemStyle Width="14%" Font-Names="Verdana" Font-Size="11px" HorizontalAlign="Center" VerticalAlign="Middle"/>
                                                                                    </asp:CommandField>
                                                                                </Columns>
                                                                                <PagerStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                                                <RowStyle Height="28px" />
                                                                                <SelectedRowStyle BackColor="#d3d9e1" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <script type="text/javascript"  language="Javascript">
                                                                function GetSlmEnc2()
                                                                {
                                                                document.aspnetForm["ctl00_slmf1_Slm_pm1_TabContainer2_TabPanel5_imgSpin2"].src = "SlmImages/progress.gif";
                                                                document.aspnetForm["ctl00_slmf1_Slm_pm1_TabContainer2_TabPanel5_imgSpin2"].visible = true;
                                                                document.aspnetForm["ctl00_slmf1_Slm_pm1_TabContainer2_TabPanel5_imgSpin2"].width = "16";
                                                                document.aspnetForm["ctl00_slmf1_Slm_pm1_TabContainer2_TabPanel5_imgSpin2"].height = "16";
                                                                }
                                                            </script>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" width="90%" colspan="3" style="padding-left:5px;padding-right:5px">
                                                                <img id="imgSpin2" alt="" visible="true" src="../SlmImages/onepix1.jpg" runat="server"/>
                                                            </td>
                                                        </tr>
                                                        <tr id="Tr1" runat="server" visible="false">
                                                            <td width="90%" colspan="3" style="padding-left:5px;padding-right:5px">
                                                            <hr noshade size="1">
                                                            </td>
                                                        </tr>
                                                        <tr id="Tr2" runat="server" visible="false">
                                                            <td width="100%" colspan="3">
                                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="4%"></td>
                                                                        <td width="96%" valign="top" class="postmsg2">
                                                                            <strong><asp:Label runat="server" ID="lblTitle2" ></asp:Label></strong> 
                                                                            <asp:Label runat="server" ID="lblTime2" ></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="4%"></td>
                                                                        <td width="96%" height="4px"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="4%"></td>
                                                                        <td width="96%" valign="top" class="postmsg2">
                                                                            <asp:Label runat="server" ID="lblMessage2" ></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="grvPmMail2" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel ID="TabPanel6" runat="server" >
                                <HeaderTemplate>
                                    <%= LoadSLMF("SLMF_Pm", "SendNew")%>
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table cellpadding="0" align="center" cellspacing="1" class="tblMost">
                                            <tr>
                                                <td class="TopMost2" align="center">
                                                    <span class="MostLink"><%= LoadSLMF("SLMF_CPUser", "PmNew")%></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="Mid">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="90%" colspan="3" height="4px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="20%" align="center">
                                                                <asp:Label ID="lblName" runat="server"></asp:Label>
                                                            </td>
                                                            <td width="80%" colspan="2" align="left">
                                                                <asp:TextBox CssClass="editprotxt" ID="txtName" runat="server"></asp:TextBox> 
                                                                <asp:DropDownList DataTextField="UserName" DataValueField="UserName" Visible="false" ID="ddlName" runat="server"></asp:DropDownList> 
                                                                <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" /> 
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="90%" colspan="3" height="4px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="20%" align="center">
                                                                <asp:Label ID="lblTitleSend" runat="server"></asp:Label>
                                                            </td>
                                                            <td width="80%" colspan="2" align="left">
                                                                <asp:TextBox CssClass="editprotxt3" ID="txtTitleSend" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="90%" colspan="3" height="4px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" colspan="3">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="left" valign="top">
                                                                            <%--<FCKeditorV2:FCKeditor ID="txtReplyMsg" 
                                                                                BasePath="~/FCKeditor/" 
                                                                                ToolbarSet="F9PmSend" 
                                                                                Height="178px" 
                                                                                AutoDetectLanguage="false" 
                                                                                DefaultLanguage="en" 
                                                                                SkinPath= 'skins/silver/' 
                                                                                runat="server">
                                                                            </FCKeditorV2:FCKeditor>--%>
                                                                            <asp:TextBox runat="server" Wrap="True" TextMode="MultiLine" ID="txtReplyMsg" style="width:99.5%;height:178px"></asp:TextBox>
                                                                            <%--<input runat="server" type="text" id="txtReplyMsg" style="width:98%;height:178px"/>--%>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <script type="text/javascript"  language="Javascript">
                                                                function GetSlmEnc3()
                                                                {
                                                                document.aspnetForm["ctl00_slmf1_Slm_pm1_TabContainer2_TabPanel6_img3"].src = "SlmImages/progress.gif";
                                                                document.aspnetForm["ctl00_slmf1_Slm_pm1_TabContainer2_TabPanel6_img3"].visible = true;
                                                                document.aspnetForm["ctl00_slmf1_Slm_pm1_TabContainer2_TabPanel6_img3"].width = "16";
                                                                document.aspnetForm["ctl00_slmf1_Slm_pm1_TabContainer2_TabPanel6_img3"].height = "16";
                                                                }
                                                            </script>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" width="90%" colspan="3" style="padding-left:5px;padding-right:5px">
                                                                <img id="img3" alt="" visible="true" src="../SlmImages/onepix1.jpg" runat="server"/>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="90%" colspan="3" style="padding-left:5px;padding-right:5px">
                                                            <hr noshade size="1">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="100%" colspan="3" align="center">
                                                                <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" /> 
                                                                <asp:Label runat="server" ID="lblSendaNew" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="90%" colspan="3" height="4px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnSend" EventName="Click" />
                                            <asp:AsyncPostBackTrigger ControlID="btnFind" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:TabContainer>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>