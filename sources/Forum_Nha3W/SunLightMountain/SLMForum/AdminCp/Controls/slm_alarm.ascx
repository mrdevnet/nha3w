<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_alarm.ascx.cs" Inherits="AdminCp_Controls_slm_alarm" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_AlarmA", "Title")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvAlarm" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30" DataKeyNames="AlarmId" OnRowDeleting="grvAlarm_RowDeleting" OnSelectedIndexChanged="grvAlarm_SelectedIndexChanged" OnPageIndexChanging="grvAlarm_PageIndexChanging" >
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="Chi tiết">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="4%" />
                                </asp:CommandField >
                                <asp:BoundField DataField="Title" HeaderText="Ti&#234;u đề">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="9%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="B&#224;i viết">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" />
                                    <ItemTemplate>
                                        <a target="_blank" href='<%# "../showtopic.aspx?rowid=" + RowId(int.Parse(Eval("MessageId").ToString())) + "&messageid=" + Eval("MessageId") + "#message" + Eval("MessageId")%>' style="color:OliveDrab;font-size:11px;font-family:Tahoma"><%# Eval("TitleMsg")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gửi l&#250;c">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="10%" />
                                    <ItemTemplate>
                                        <%# AnnounceTime(DateTime.Parse(Eval("AlarmTime").ToString())) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PriorityName" HeaderText="Trạng th&#225;i">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle"
                                        Width="4%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Người gửi">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                    <ItemTemplate>
                                        <a target="_blank" href='<%# "../showprofile.aspx?memberid=" + Eval("MemberId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma"><%# Eval("UserName")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                <tr runat="server" id="trDetails" visible="false">
                    <td colspan="3" width="100%" style="padding-bottom:10px;padding-right:10px;padding-left:10px;font-family:Tahoma;font-size:12px">
                        <asp:Label ID="TitleDetail" runat="server" Font-Bold="true" ForeColor="RoyalBlue"></asp:Label>
                        <br /><br />
                        <asp:Label ID="ReportDetail" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="grvAlarm" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="grvAlarm" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="grvAlarm" EventName="PageIndexChanging" />
    </Triggers>
</asp:UpdatePanel>