<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_searchusers.ascx.cs" Inherits="AdminCp_Controls_slm_searchusers" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_UserA", "Search")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="25%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "SearchBy")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="74%">
                        <asp:RadioButton ID="rbtUserName" runat="server" GroupName="Search" Checked="true"/> 
                        <asp:RadioButton ID="rbtFullName" runat="server" GroupName="Search"/> 
                        <asp:RadioButton ID="rbtEmail" runat="server" GroupName="Search"/>
                        <asp:RadioButton ID="rbtIsActivated" runat="server" GroupName="Search"/>
                        <asp:RadioButton ID="rbtIsLogin" runat="server" GroupName="Search"/>
                        <asp:RadioButton ID="rbtIsBlock" runat="server" GroupName="Search"/>
                    </td>
                </tr>
                <tr>
                    <td width="25%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "SearchByTitle")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="74%">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="editprotxt"></asp:TextBox> 
                        <asp:Button CssClass="btnReg" ID="btnSave" runat="server" OnClientClick="GetSlmEnc();" OnClick="btnSave_Click" /> 
                        &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/> 
                        <asp:Label ID="lblReport" runat="server" CssClass="editprore"></asp:Label>
                        <script type="text/javascript"  language="Javascript">
                        function GetSlmEnc()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_searchusers1_imgSpinner2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_searchusers1_imgSpinner2"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_searchusers1_imgSpinner2"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_searchusers1_imgSpinner2"].height = "16";
                        }
                        
                        function GetSlmEnc2()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_searchusers1_imgSpinner1"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_searchusers1_imgSpinner1"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_searchusers1_imgSpinner1"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_searchusers1_imgSpinner1"].height = "16";
                        }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td width="25%" class="EditPro">
                        <%= LoadSLMF("SLMF_UserA", "SearchByGroup")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="74%">
                        <asp:DropDownList ID="ddlGroups" AutoPostBack="true" CssClass="fontmsg" runat="server" OnSelectedIndexChanged="ddlGroups_SelectedIndexChanged"></asp:DropDownList>
                        &nbsp;&nbsp;<img id="imgSpinner1" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvUsers" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="15" DataKeyNames="MemberId" OnPageIndexChanging="grvUsers_PageIndexChanging" OnRowDeleting="grvUsers_RowDeleting">
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
                                <asp:BoundField DataField="FullGroup" HeaderText="Họ và tên/Nhóm">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                                        Width="12%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Đăng ký">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Left"
                                        VerticalAlign="Middle" Width="12%" />
                                    <ItemTemplate>
                                        <%#AnnounceTime(DateTime.Parse(Eval("DateCreation").ToString()))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CheckBoxField DataField="IsActivated" HeaderText="K&#237;ch hoạt">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="32px" HorizontalAlign="Center"
                                        VerticalAlign="Middle" Width="6%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:CheckBoxField>
                                <asp:CheckBoxField DataField="EnableLogin" HeaderText="Login">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="32px" HorizontalAlign="Center"
                                        VerticalAlign="Middle" Width="6%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:CheckBoxField>
                                <asp:TemplateField>
                                    <ItemStyle Height="32px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                    <ItemTemplate>
                                        <a href='<%# "updelmember.aspx?id=memberpro&mbrid=" + Eval("MemberId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma">Update</a>
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
        <asp:AsyncPostBackTrigger ControlID="grvUsers" EventName="PageIndexChanging" />
        <asp:AsyncPostBackTrigger ControlID="grvUsers" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="ddlGroups" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>