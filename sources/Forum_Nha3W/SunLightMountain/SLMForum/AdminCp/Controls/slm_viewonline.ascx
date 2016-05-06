<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_viewonline.ascx.cs" Inherits="AdminCp_Controls_slm_viewonline" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_ViewOnA", "TitleOnline")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvViewOnline" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30" DataKeyNames="DetailId" OnPageIndexChanging="grvViewOnline_PageIndexChanging" OnRowDeleting="grvViewOnline_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Tài khoản">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                    <ItemTemplate>
                                        <a target="_blank" href='<%# "../showprofile.aspx?memberid=" + Eval("MemberId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma"><%# Eval("UserName")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IP" HeaderText="IP">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="9%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Online" HeaderText="Online'">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="5%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="LogIn">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="12%" />
                                    <ItemTemplate>
                                        <%# AnnounceTime(DateTime.Parse(Eval("Request").ToString())) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chủ đề">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" />
                                    <ItemTemplate>
                                        <a target="_blank" href='<%# "../showtopic.aspx?goto=newmessage&topicid=" + Eval("TopicId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma"><%# Eval("Title")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Diễn đàn">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" />
                                    <ItemTemplate>
                                        <a target="_blank" href='<%# "../topicdisplay.aspx?forumid=" + Eval("ForumId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma"><%# Eval("Name")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="UserName" HeaderText="IP">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="9%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>--%>
                                <%--<asp:TemplateField HeaderText="Gửi l&#250;c">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="10%" />
                                    <ItemTemplate>
                                        <%# AnnounceTime(DateTime.Parse(Eval("AlarmTime").ToString())) %>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:CommandField ShowDeleteButton="True">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center"
                                        VerticalAlign="Middle" Width="4%" />
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
        <asp:AsyncPostBackTrigger ControlID="grvViewOnline" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="grvViewOnline" EventName="PageIndexChanging" />
    </Triggers>
</asp:UpdatePanel>