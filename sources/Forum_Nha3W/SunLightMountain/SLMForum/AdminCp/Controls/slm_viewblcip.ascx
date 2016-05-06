<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_viewblcip.ascx.cs" Inherits="AdminCp_Controls_slm_viewblcip" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_ViewBlockIP", "Title")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvBlockIP" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30" DataKeyNames="IP" OnPageIndexChanging="grvBlockIP_PageIndexChanging" OnRowDeleting="grvBlockIP_RowDeleting" OnSelectedIndexChanged="grvBlockIP_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="IP" HeaderText="Địa chỉ IP">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="7%" />
                                </asp:BoundField>
                                <asp:CheckBoxField DataField="Status" HeaderText="Đ&#227; kho&#225;" >
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Height="25px" Width="5%" />
                                </asp:CheckBoxField>
                                <asp:TemplateField HeaderText="Vào lúc">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="9%" />
                                    <ItemTemplate>
                                        <%# AnnounceTime(DateTime.Parse(Eval("DateBlock").ToString())) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Reason" HeaderText="L&#253; do">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="14%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Điều h&#224;nh">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                    <ItemTemplate>
                                        <a target="_blank" href='<%# "../showprofile.aspx?memberid=" + Eval("Moderator") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma"><%# Eval("ModName")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" SelectText="Xem">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                </asp:CommandField >
                                <asp:CommandField ShowDeleteButton="True">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center"
                                        VerticalAlign="Middle" Width="3%" />
                                </asp:CommandField>
                            </Columns>
                            <PagerStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab"
                                HorizontalAlign="Left" VerticalAlign="Middle" />
                            <HeaderStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="RoyalBlue" />
                            <SelectedRowStyle BackColor="#E0E0E0" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height:8px"></td>
                </tr>
            </table>
            <asp:Panel ID="pnlBlockIp" runat="server" Visible="false">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px">
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
                                    <asp:Button CssClass="btnReg" ID="btnBlockIp" runat="server" OnClick="btnBlockIp_Click" />
                                    <%--&nbsp;&nbsp;<img id="imgBlockIp" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/> --%>
                                    <asp:Label ID="lblBlockIp" runat="server" CssClass="editprore"></asp:Label>
                                    <%--<script type="text/javascript"  language="Javascript">
                                        function GetSlmEnc()
                                        {
                                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlockIp"].src = "../SlmImages/progress.gif";
                                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlockIp"].visible = true;
                                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlockIp"].width = "16";
                                        document.aspnetForm["ctl00_cplAdmin_Slm_updelmember1_imgBlockIp"].height = "16";
                                        }
                                    </script>--%>
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
        <asp:AsyncPostBackTrigger ControlID="grvBlockIP" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="grvBlockIP" EventName="PageIndexChanging" />
    </Triggers>
</asp:UpdatePanel>