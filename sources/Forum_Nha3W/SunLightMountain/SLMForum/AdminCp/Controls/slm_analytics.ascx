<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_analytics.ascx.cs" Inherits="AdminCp_Controls_slm_analytics" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_Analytics", "Title2")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3" style="height:8px"></td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_Analytics", "DateAnal")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtCalendar" runat="server" CssClass="editprotxt"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="cldStart" runat="server" TargetControlID="txtCalendar">
                        </ajaxToolkit:CalendarExtender> 
                        <asp:Button CssClass="btnReg" ID="btnReload" OnClientClick="GetSlmEnc();" runat="server" OnClick="btnReload_Click" />
                        &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/>
                        <script type="text/javascript"  language="Javascript">
                        function GetSlmEnc()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_analytics1_imgSpinner2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_analytics1_imgSpinner2"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_analytics1_imgSpinner2"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_analytics1_imgSpinner2"].height = "16";
                        }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height:8px"></td>
                </tr>
            </table>
            <asp:Panel ID="pnlAvatars" runat="server">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("SLMF_Analytics", "Title3")%>}</legend>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="100%" class="EditPro" align="center">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="3" style="height:8px"></td>
                                    </tr>
                                    <tr>
                                        <td width="21%" class="EditPro">
                                            <%= LoadSLMF("SLMF_Analytics", "Members")%>
                                        </td>
                                        <td width="1%">
                                        </td>
                                        <td width="78%" align="left">
                                            <asp:Label ID="lblMembers" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="21%" class="EditPro">
                                            <%= LoadSLMF("SLMF_Analytics", "Messages")%>
                                        </td>
                                        <td width="1%">
                                        </td>
                                        <td width="78%" align="left">
                                            <asp:Label ID="lblMessages" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="21%" class="EditPro">
                                            <%= LoadSLMF("SLMF_Analytics", "Moderators")%>
                                        </td>
                                        <td width="1%">
                                        </td>
                                        <td width="78%" align="left">
                                            <asp:Label ID="lblModerators" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="21%" class="EditPro">
                                            <%= LoadSLMF("SLMF_Analytics", "Topics")%>
                                        </td>
                                        <td width="1%">
                                        </td>
                                        <td width="78%" align="left">
                                            <asp:Label ID="lblTopics" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="21%" class="EditPro">
                                            <%= LoadSLMF("SLMF_Analytics", "NewestMemberId")%>
                                        </td>
                                        <td width="1%">
                                        </td>
                                        <td width="78%" align="left">
                                            <asp:Label ID="lblNewestMemberId" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="21%" class="EditPro">
                                            <%= LoadSLMF("SLMF_Analytics", "RegisterCount")%>
                                        </td>
                                        <td width="1%">
                                        </td>
                                        <td width="78%" align="left">
                                            <asp:Label ID="lblRegisterCount" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="21%" class="EditPro">
                                            <%= LoadSLMF("SLMF_Analytics", "LoginCount")%>
                                        </td>
                                        <td width="1%">
                                        </td>
                                        <td width="78%" align="left">
                                            <asp:Label ID="lblLoginCount" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height:8px"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </td>
    </tr>
</table>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnReload" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>