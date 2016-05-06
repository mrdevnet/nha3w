<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_viewblcmember.ascx.cs" Inherits="AdminCp_Controls_slm_viewblcmember" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_ViewBlockMember", "Title")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvViewBlcMember" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30" DataKeyNames="MemberId" OnSelectedIndexChanged="grvViewBlcMember_SelectedIndexChanged" OnPageIndexChanging="grvViewBlcMember_PageIndexChanging" OnRowDeleting="grvViewBlcMember_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="T&#224;i khoản">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                    <ItemTemplate>
                                        <a target="_blank" href='<%# "../showprofile.aspx?memberid=" + Eval("MemberId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma"><%# Eval("UserName")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="MemberId" Visible="False" />
                                <asp:CheckBoxField DataField="Status" HeaderText="Đ&#227; kho&#225;" >
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Height="25px" Width="5%" />
                                </asp:CheckBoxField>
                                <asp:TemplateField HeaderText="Bắt đầu">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="11%" />
                                    <ItemTemplate>
                                        <%# AnnounceTime(DateTime.Parse(Eval("Start").ToString())) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Kết th&#250;c">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="11%" />
                                    <ItemTemplate>
                                        <%# AnnounceTime(DateTime.Parse(Eval("Finish").ToString())) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Reason" HeaderText="L&#253; do">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="11%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Điều h&#224;nh">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                    <ItemTemplate>
                                        <a target="_blank" href='<%# "../showprofile.aspx?memberid=" + Eval("Moderator") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma"><%# Eval("ModName")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" SelectText="Xem">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                </asp:CommandField >
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
            <asp:Panel ID="pnlBlockUser" runat="server" Visible="false">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("SLMF_UserA", "BlockUser")%>}</legend>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="21%" class="EditPro">
                                    <%= LoadSLMF("SLMF_UserA", "BlockStatus")%>
                                </td>
                                <td width="1%">
                                </td>
                                <td width="78%">
                                    <asp:RadioButton ID="rbtBlock" runat="server" GroupName="BlockUser"/>
                                    <asp:RadioButton ID="rbtUnBlock" runat="server" Checked="true" GroupName="BlockUser"/>
                                </td>
                            </tr>
                            <tr>
                                <td width="21%" class="EditPro">
                                    <%= LoadSLMF("SLMF_UserA", "BlockStart")%>
                                </td>
                                <td width="1%">
                                </td>
                                <td width="78%">
                                    <asp:TextBox ID="txtStart" runat="server" CssClass="editprotxt"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server" TargetControlID="txtStart">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td width="21%" class="EditPro">
                                    <%= LoadSLMF("SLMF_UserA", "BlockFinish")%>
                                </td>
                                <td width="1%">
                                </td>
                                <td width="78%">
                                    <asp:TextBox ID="txtFinish" runat="server" CssClass="editprotxt"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender2" runat="server" TargetControlID="txtFinish">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td width="21%" class="EditPro">
                                    <%= LoadSLMF("SLMF_UserA", "BlockReason")%>
                                </td>
                                <td width="1%">
                                </td>
                                <td width="78%">
                                    <asp:TextBox ID="txtReason" runat="server" CssClass="editprotxt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="21%" class="EditPro">
                                </td>
                                <td width="1%">
                                </td>
                                <td width="78%">
                                    <asp:Button CssClass="btnReg" ID="btnUpdateBlock" runat="server" OnClick="btnUpdateBlock_Click" />
                                    <%--&nbsp;&nbsp;<img id="imgUpdateBlock" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/> --%>
                                    <asp:Label ID="lblBlockUser" runat="server" CssClass="editprore"></asp:Label>
                                    <%--<script type="text/javascript"  language="Javascript">
                                        function GetSlmEnc()
                                        {
                                        document.aspnetForm["ctl00_cplAdmin_Slm_viewblcmember1_imgUpdateBlock"].src = "../SlmImages/progress.gif";
                                        document.aspnetForm["ctl00_cplAdmin_Slm_viewblcmember1_imgUpdateBlock"].visible = true;
                                        document.aspnetForm["ctl00_cplAdmin_Slm_viewblcmember1_imgUpdateBlock"].width = "16";
                                        document.aspnetForm["ctl00_cplAdmin_Slm_viewblcmember1_imgUpdateBlock"].height = "16";
                                        }
                                    </script>--%>
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
        <asp:AsyncPostBackTrigger ControlID="grvViewBlcMember" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="grvViewBlcMember" EventName="PageIndexChanging" />
    </Triggers>
</asp:UpdatePanel>