<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_moderator.ascx.cs" Inherits="AdminCp_Controls_slm_moderator" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("ModeratorA", "Manager")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3" style="height:8px"></td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_ForumA", "SelectCateIdTitle")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:DropDownList ID="ddlCategories" onchange="GetSlmEnc();" AutoPostBack="true" CssClass="fontmsg" runat="server" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged" ></asp:DropDownList>
                        &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/>
                        <script type="text/javascript"  language="Javascript">
                        function GetSlmEnc()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_moderator1_imgSpinner2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_moderator1_imgSpinner2"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_moderator1_imgSpinner2"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_moderator1_imgSpinner2"].height = "16";
                        }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvForums" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="5" DataKeyNames="ForumId" OnSelectedIndexChanged="grvForums_SelectedIndexChanged" OnPageIndexChanging="grvForums_PageIndexChanging" >
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
                                <asp:CommandField ShowSelectButton="True" SelectText="Nhóm">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                </asp:CommandField >
                                <asp:TemplateField>
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
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
             <asp:Panel ID="pnlGroups" runat="server" Visible="false">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("PermissionGrpFrmA", "pnlGroups")%>}</legend>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="100%" class="EditPro" colspan="3" align="center">
                            <asp:GridView ID="grvGroups" Width="100%" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="GroupId,ForumId" OnSelectedIndexChanged="grvGroups_SelectedIndexChanged" OnRowDeleting="grvGroups_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="GroupName" HeaderText="Nh&#243;m th&#224;nh vi&#234;n">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Height="25px" Width="12%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GetPosts" HeaderText="B&#224;i viết y&#234;u cầu">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Height="25px" Width="12%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="H&#236;nh ảnh Nh&#243;m">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                                        <ItemTemplate>
                                            <img src='<%# "../slmimages/" + Eval("RankImage") %>' alt='<%# Eval("GroupName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Chọn Moderator">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                </asp:CommandField >
                                    <asp:CommandField ShowDeleteButton="True">
                                        <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center"
                                            VerticalAlign="Middle" Width="4%" />
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
            <asp:Panel ID="pnlModerator" runat="server" Visible="false">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("ModeratorA", "PnlModeratorTitle")%>}</legend>
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
                            <asp:GridView ID="grvUsers" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="3" DataKeyNames="MemberId" OnSelectedIndexChanged="grvUsers_SelectedIndexChanged" OnPageIndexChanging="grvUsers_PageIndexChanging">
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
                                    <asp:CommandField ShowSelectButton="True" SelectText="Chọn làm Moder">
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
                            <%= LoadSLMF("ModeratorA", "IsSuper")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:CheckBox ID="SuperModer" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" class="EditPro">
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:Button CssClass="btnReg" Visible="false" ID="btnSetModer" runat="server" OnClick="btnSetModer_Click" />
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
            <asp:Panel ID="pnlGrpFrmUsers" runat="server" Visible="false">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("ModeratorA", "pnlModerators")%>}</legend>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="100%" class="EditPro" colspan="3" align="center">
                                <asp:GridView ID="grvGrpFrmUsers" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="GroupId,ForumId,MemberId" OnRowDeleting="grvGrpFrmUsers_RowDeleting" >
                                    <Columns>
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
                                        <asp:TemplateField HeaderText="Moderator">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                            <ItemTemplate>
                                                <a target="_blank" href='<%# "../showprofile.aspx?memberid=" + Eval("MemberId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma"><%# Eval("UserName")%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CheckBoxField DataField="IsSuper" HeaderText="Super Moder" >
                                            <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Height="25px" Width="6%" />
                                        </asp:CheckBoxField>
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
                    </table>
                    </fieldset>
                </div>
            </asp:Panel>
        </td>
    </tr>
</table>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="grvForums" EventName="PageIndexChanging" />
        <asp:AsyncPostBackTrigger ControlID="grvForums" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="grvGroups" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="grvGroups" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="grvUsers" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="grvUsers" EventName="PageIndexChanging" />
        <asp:AsyncPostBackTrigger ControlID="grvGrpFrmUsers" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="btnSetModer" EventName="Click" />        
        <asp:AsyncPostBackTrigger ControlID="ddlCategories" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>