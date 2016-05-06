<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_updelforum.ascx.cs" Inherits="AdminCp_Controls_slm_updelforum" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_ForumA", "UpdelForums")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_ForumA", "SelectCateIdTitle")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:DropDownList ID="ddlCategories" AutoPostBack="true" CssClass="fontmsg" runat="server" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvForums" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="12" DataKeyNames="ForumId" OnPageIndexChanging="grvForums_PageIndexChanging" OnRowDeleting="grvForums_RowDeleting" >
                            <Columns>
                                <asp:BoundField DataField="ForumName" HeaderText="Diễn đ&#224;n">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="30%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ParForum" HeaderText="Diễn đ&#224;n Ch&#237;nh">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                                        Width="30%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TypeName" HeaderText="Kiểu diễn đ&#224;n">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                                        Width="12%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                    <ItemTemplate>
                                        <a href='<%# "addforum.aspx?id=updfrm&frmid=" + Eval("ForumId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma">Update</a>
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
        <asp:AsyncPostBackTrigger ControlID="grvForums" EventName="PageIndexChanging" />
        <asp:AsyncPostBackTrigger ControlID="grvForums" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="ddlCategories" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>