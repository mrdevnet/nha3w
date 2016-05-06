<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_alladmins.ascx.cs" Inherits="AdminCp_Controls_slm_alladmins" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_Admins", "AllAdmins")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <asp:Panel ID="pnlModerator" runat="server">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px;padding-top:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("SLMF_Admins", "AllAdminsTitle")%>}</legend>
                    <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%" style="height:8px" colspan="3" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="EditPro" colspan="3" align="center">
                            <asp:GridView ID="grvUsers" Width="100%" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="AdminId" OnRowDeleting="grvUsers_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="UserName" HeaderText="T&#224;i khoản">
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="32px" Width="12%" />
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Email" HeaderText="Email">
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                                            Width="11%" />
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Đăng k&#253;">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Left"
                                            VerticalAlign="Middle" Width="12%" />
                                        <ItemTemplate>
                                            <%# AnnounceTime(DateTime.Parse(Eval("DateCreation").ToString())) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nh&#243;m th&#224;nh vi&#234;n">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="9%" />
                                        <ItemTemplate>
                                            <img src='<%# "../slmimages/" + Eval("RankImage") %>' alt='<%# Eval("GroupName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowDeleteButton="True">
                                        <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center"
                                            VerticalAlign="Middle" Width="5%" />
                                    </asp:CommandField>
                                    <asp:TemplateField>
                                        <ItemStyle Height="32px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                        <ItemTemplate>
                                            <a href='<%# "updelmember.aspx?id=memberpro&mbrid=" + Eval("AdminId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma">Update</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
        <asp:AsyncPostBackTrigger ControlID="grvUsers" EventName="PageIndexChanging" />
    </Triggers>
</asp:UpdatePanel>