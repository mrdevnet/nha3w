<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_grpman.ascx.cs" Inherits="AdminCp_Controls_slm_grpman" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_GroupA", "GroupManager")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvGroup" Width="100%" runat="server" AllowPaging="false" AutoGenerateColumns="False" PageSize="30" DataKeyNames="GroupId" OnRowDeleting="grvGroup_RowDeleting" >
                            <Columns>
                                <asp:BoundField DataField="GroupName" HeaderText="Nhóm thành viên">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="12%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GetPosts" HeaderText="Bài viết yêu cầu">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle"
                                        Width="8%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Hình ảnh">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" />
                                    <ItemTemplate>
                                        <img src='<%# "../slmimages/" + Eval("RankImage") %>' alt="" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PmLimit" HeaderText="Tin nhắn tối đa">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle"
                                        Width="8%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                    <ItemTemplate>
                                        <a href='<%# "addgroup.aspx?id=grpman&grpid=" + Eval("GroupId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma">Update</a>
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
                    <td colspan="3" style="height:8px;padding-left:8px;padding-bottom:8px">
                        &nbsp;<asp:Label ID="lblReport" runat="server" Font-Names="Tahoma" Font-Size="12px" ForeColor="blue" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="grvGroup" EventName="RowDeleting" />
    </Triggers>
</asp:UpdatePanel>