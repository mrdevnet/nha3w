<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_updelreports.ascx.cs" Inherits="AdminCp_Controls_slm_updelreports" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_ReportA", "UpdateDeleteReport")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvReports" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="12" DataKeyNames="ReportId" OnPageIndexChanging="grvReports_PageIndexChanging" OnRowDeleting="grvReports_RowDeleting" >
                            <Columns>
                                <asp:BoundField DataField="Title" HeaderText="Th&#244;ng b&#225;o">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="30%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Ngày bắt đầu">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" Width="10%" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <%#AnnounceTime(DateTime.Parse(Eval("StartDate").ToString())) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ngày kết thúc">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" Width="10%" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <%#AnnounceTime(DateTime.Parse(Eval("FinishDate").ToString())) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tất cả/Top">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" Width="7%" HorizontalAlign="center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckbAllForum" runat="server" Checked='<%# Eval("AllForum") %>' />/<asp:CheckBox ID="ckbIsTop" runat="server" Checked='<%# Eval("IsTop") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="center" VerticalAlign="Middle" Width="5%" />
                                    <ItemTemplate>
                                        <a href='<%# "addreport.aspx?id=addrpt&rptid=" + Eval("ReportId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma">Update</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center"
                                        VerticalAlign="Middle" Width="5%" />
                                </asp:CommandField>
                            </Columns>
                            <PagerStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab"
                                HorizontalAlign="Left" VerticalAlign="Middle" />
                            <HeaderStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="RoyalBlue" />
                        </asp:GridView>
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
        <asp:AsyncPostBackTrigger ControlID="grvReports" EventName="PageIndexChanging" />
        <asp:AsyncPostBackTrigger ControlID="grvReports" EventName="RowDeleting" />
    </Triggers>
</asp:UpdatePanel>