<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_privatefrm.ascx.cs" Inherits="AdminCp_Controls_slm_privatefrm" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_PrivForumA", "Title")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3" style="height:8px"></td>
                </tr>
                <tr>
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvForums" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="ForumId" OnSelectedIndexChanged="grvForums_SelectedIndexChanged" >
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Diễn đ&#224;n Cá nhân">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="30%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CateName" HeaderText="Nhóm Diễn đàn">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                                        Width="30%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True" SelectText="Chọn Diễn đàn">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                </asp:CommandField >
                                <asp:TemplateField>
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                    <ItemTemplate>
                                        <a href='<%# "addforum.aspx?id=updfrm&frmid=" + Eval("ForumId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma">Update</a>
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
            <asp:Panel ID="pnlModerator" runat="server" Visible="true">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("SLMF_PrivForumA", "Title2")%>}</legend>
                    <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%" style="height:8px" colspan="3" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("SLMF_UserA", "SearchByTitle")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="editprotxt"></asp:TextBox> 
                            <asp:Button CssClass="btnReg" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="EditPro" colspan="3" align="center">
                            <asp:GridView ID="grvUsers" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="3" DataKeyNames="MemberId" OnSelectedIndexChanged="grvUsers_SelectedIndexChanged" OnPageIndexChanging="grvUsers_PageIndexChanging" >
                                <Columns>
                                    <asp:BoundField DataField="UserName" HeaderText="T&#224;i khoản">
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="32px" Width="12%" />
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Email" HeaderText="Email">
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                                            Width="12%" />
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Đăng k&#253;">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Left"
                                            VerticalAlign="Middle" Width="12%" />
                                        <ItemTemplate>
                                            <%#AnnounceTime(DateTime.Parse(Eval("DateCreation").ToString()))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Chọn Thành viên">
                                        <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="7%" />
                                    </asp:CommandField >
                                    <asp:TemplateField>
                                        <ItemStyle Height="32px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                        <ItemTemplate>
                                            <a href='<%# "updelmember.aspx?id=memberpro&mbrid=" + Eval("MemberId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma">Update</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:CommandField ShowDeleteButton="True">
                                        <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center"
                                            VerticalAlign="Middle" Width="5%" />
                                    </asp:CommandField>--%>
                                </Columns>
                                <PagerStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab"
                                    HorizontalAlign="Left" VerticalAlign="Middle" />
                                <HeaderStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="RoyalBlue" />
                                <SelectedRowStyle BackColor="#E0E0E0" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="trModerator" visible="false" runat="server">
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("SLMF_PrivForumA", "ChooseMember")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:Button CssClass="btnReg" Visible="false" ID="btnSetModer" runat="server" OnClick="btnSetModer_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" class="EditPro">
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:Label ID="lblModer" runat="server" CssClass="editprore"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height:8px"></td>
                    </tr>
                    </table>
                </fieldset>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlUsersFrms" runat="server" Visible="false">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("SLMF_PrivForumA", "Title3")%>}</legend>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="100%" class="EditPro" colspan="3" align="center">
                                <asp:GridView ID="grvPriUsersFrms" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="ForumId,MemberId" OnRowDeleting="grvPriUsersFrms_RowDeleting" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Diễn đ&#224;n Cá nhân">
                                            <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Left" VerticalAlign="Middle" Width="12%" />
                                            <ItemTemplate>
                                                <a target="_blank" href='<%# "../topicdisplay.aspx?forumid=" + Eval("ForumId")%>' style="color:OliveDrab;font-size:11px;font-family:Tahoma"><%# Eval("Name")%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CateName" HeaderText="Nhóm Diễn đàn">
                                            <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="6%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Thành viên">
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
                    </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </td>
    </tr>
</table>
</ContentTemplate>
    <Triggers>
        <%--<asp:AsyncPostBackTrigger ControlID="grvForums" EventName="PageIndexChanging" />
        <asp:AsyncPostBackTrigger ControlID="grvForums" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="grvGroups" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="grvGroups" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="grvUsers" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="grvUsers" EventName="PageIndexChanging" />
        <asp:AsyncPostBackTrigger ControlID="grvGrpFrmUsers" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="btnSetModer" EventName="Click" />        
        <asp:AsyncPostBackTrigger ControlID="ddlCategories" EventName="SelectedIndexChanged" />--%>
    </Triggers>
</asp:UpdatePanel>