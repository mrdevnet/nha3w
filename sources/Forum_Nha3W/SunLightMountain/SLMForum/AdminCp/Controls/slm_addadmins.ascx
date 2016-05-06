<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_addadmins.ascx.cs" Inherits="AdminCp_Controls_slm_addadmins" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_Admins", "Title")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <asp:Panel ID="pnlModerator" runat="server">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px;padding-top:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("SLMF_Admins", "Title2")%>}</legend>
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
                            <asp:Button CssClass="btnReg" OnClientClick="GetSlmEnc();" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                            &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/>
                            <script type="text/javascript"  language="Javascript">
                                function GetSlmEnc()
                                {
                                document.aspnetForm["ctl00_cplAdmin_Slm_addadmins1_imgSpinner2"].src = "../SlmImages/progress.gif";
                                document.aspnetForm["ctl00_cplAdmin_Slm_addadmins1_imgSpinner2"].visible = true;
                                document.aspnetForm["ctl00_cplAdmin_Slm_addadmins1_imgSpinner2"].width = "16";
                                document.aspnetForm["ctl00_cplAdmin_Slm_addadmins1_imgSpinner2"].height = "16";
                                }
                            </script>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="EditPro" colspan="3" align="center">
                            <asp:GridView ID="grvUsers" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="3" DataKeyNames="MemberId" OnPageIndexChanging="grvUsers_PageIndexChanging" OnSelectedIndexChanged="grvUsers_SelectedIndexChanged">
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
                                            <%# AnnounceTime(DateTime.Parse(Eval("DateCreation").ToString())) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Chọn làm Admin">
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
                    <tr>
                        <td colspan="3" style="height:8px"></td>
                    </tr>
                    </table>
                </fieldset>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlAdmins" runat="server" Visible="false">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px;padding-top:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("SLMF_Admins", "Title3")%>}</legend>
                    <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%" style="height:8px" colspan="3" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="EditPro" colspan="3" align="center">
                            <asp:GridView ID="grvAdmins" Width="100%" runat="server" AllowPaging="true" PageSize="9" AutoGenerateColumns="False" DataKeyNames="GroupId" OnSelectedIndexChanged="grvAdmins_SelectedIndexChanged" OnPageIndexChanging="grvAdmins_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="ID">
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Height="32px" Width="14%" />
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Descriptions" HeaderText="Chức năng">
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Width="44%" />
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GroupName" HeaderText="Nhóm">
                                        <ItemStyle Font-Bold="true" Font-Names="Tahoma" Font-Size="11px" HorizontalAlign="Left" VerticalAlign="Middle" Width="30%" />
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Chọn">
                                        <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="12%" />
                                    </asp:CommandField >
                                </Columns>
                                <PagerStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab"
                                    HorizontalAlign="Left" VerticalAlign="Middle" />
                                <HeaderStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="RoyalBlue" />
                                <SelectedRowStyle BackColor="#E0E0E0" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="trAddMenu" visible="false" runat="server">
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("SLMF_Admins", "btnSetLabel")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:Button CssClass="btnReg" ID="btnSet" runat="server" OnClick="btnSet_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height:8px"></td>
                    </tr>
                    </table>
                </fieldset>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlAdminGroups" runat="server" Visible="false">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px;padding-top:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("SLMF_Admins", "Title4")%>}</legend>
                    <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%" style="height:8px" colspan="3" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="EditPro" colspan="3" align="center">
                            <asp:GridView ID="grvAdminGrps" Width="100%" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="AdminId,GroupId" OnRowDeleting="grvAdminGrps_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="UserName" HeaderText="Admin">
                                        <ItemStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Height="32px" Width="14%" />
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Descriptions" HeaderText="Chức năng">
                                        <ItemStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Width="44%" />
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GroupName" HeaderText="Nh&#243;m">
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Width="30%" />
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:CommandField ShowDeleteButton="True">
                                        <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center"
                                            VerticalAlign="Middle" Width="9%" />
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