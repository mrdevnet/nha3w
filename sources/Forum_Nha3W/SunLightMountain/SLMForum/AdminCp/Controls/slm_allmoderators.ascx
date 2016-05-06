<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_allmoderators.ascx.cs" Inherits="AdminCp_Controls_slm_allmoderators" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("ModeratorA", "ViewAllModers")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <asp:Panel ID="pnlModerator" runat="server">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px;padding-top:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("ModeratorA", "ViewAllModers2")%>}</legend>
                    <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%" style="height:8px" colspan="3" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="EditPro" colspan="3" align="center">
                            <asp:GridView ID="grvModerators" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="GroupId,ForumId,MemberId" OnRowDeleting="grvModerators_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Moderator">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                        <ItemTemplate>
                                            <a target="_blank" href='<%# "../showprofile.aspx?memberid=" + Eval("MemberId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma"><%# Eval("UserName")%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CheckBoxField DataField="IsSuper" HeaderText="Super Moder" >
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Height="25px" Width="5%" />
                                    </asp:CheckBoxField>
                                    <asp:TemplateField HeaderText="Diễn đ&#224;n">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Left" VerticalAlign="Middle" Width="12%" />
                                        <ItemTemplate>
                                            <a target="_blank" href='<%# "../topicdisplay.aspx?forumid=" + Eval("ForumId")%>' style="color:OliveDrab;font-size:11px;font-family:Tahoma"><%# Eval("Name")%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="GroupName" HeaderText="Nh&#243;m quyền">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="6%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Set l&#250;c">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="8%" />
                                        <ItemTemplate>
                                            <%# AnnounceTime(DateTime.Parse(Eval("JobDate").ToString())) %>
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
                    </table>
                </fieldset>
                </div>
            </asp:Panel>
        </td>
    </tr>
</table>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="grvModerators" EventName="RowDeleting" />
    </Triggers>
</asp:UpdatePanel>