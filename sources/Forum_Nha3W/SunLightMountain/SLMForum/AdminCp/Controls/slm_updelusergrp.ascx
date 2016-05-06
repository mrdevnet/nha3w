<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_updelusergrp.ascx.cs" Inherits="AdminCp_Controls_slm_updelusergrp" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_GroupA", "AddGrp4MbrTitle")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3" style="height:8px"></td>
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
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelusergrp1_imgSpinner2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelusergrp1_imgSpinner2"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelusergrp1_imgSpinner2"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelusergrp1_imgSpinner2"].height = "16";
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
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvUsers" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="5" DataKeyNames="MemberId" OnPageIndexChanging="grvUsers_PageIndexChanging" OnSelectedIndexChanged="grvUsers_SelectedIndexChanged" OnRowDeleting="grvUsers_RowDeleting">
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
                                <asp:CommandField ShowSelectButton="True" SelectText="Xem nh&#243;m">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="6%" />
                                </asp:CommandField >
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
                    <legend>{<%= LoadSLMF("SLMF_GroupA", "MbrIsGrps")%>}</legend>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="100%" class="EditPro" colspan="3" align="center">
                            <asp:GridView ID="grvGroups" Width="100%" runat="server" AllowPaging="false" AutoGenerateColumns="False" PageSize="30" DataKeyNames="MemberId,GroupId" OnRowDeleting="grvGroups_RowDeleting" >
                                <Columns>
                                    <asp:BoundField DataField="UserName" HeaderText="Tài khoản">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Height="25px" Width="12%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GroupName" HeaderText="Nhóm thành viên">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Height="25px" Width="12%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Hình ảnh Nhóm">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                                        <ItemTemplate>
                                            <img src='<%# "../slmimages/" + Eval("RankImage") %>' alt='<%# Eval("GroupName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                        <td width="21%" class="EditPro">
                            <%= LoadSLMF("SLMF_GroupA", "AddGrp4MbrTitle2")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="78%">
                            <asp:LinkButton id="lbtExp2" runat="server" OnClick="lbtExp2_Click" ><img style="border:0px" src="../slmimages/expand.gif" /></asp:LinkButton> 
                            <asp:LinkButton id="lbtClo2" Visible="false" runat="server" OnClick="lbtClo2_Click" ><img style="border:0px" src="../slmimages/collapse.gif" /></asp:LinkButton>
                        </td>
                    </tr>
                    <tr id="trInsertFrmSpn" visible="false" runat="server">
                        <td width="21%" class="EditPro">
                            <%= LoadSLMF("SLMF_GroupA", "SelectAGroup2")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="78%">
                            <asp:DropDownList ID="ddlGroups" CssClass="fontmsg" runat="server" ></asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="trInsertFrmSpn2" visible="false" runat="server">
                        <td width="21%" class="EditPro">
                        </td>
                        <td width="1%">
                        </td>
                        <td width="78%">
                            <asp:Button CssClass="btnReg" ID="btnInsGroups" runat="server" OnClick="btnInsGroups_Click" />
                            <asp:Label ID="lblReportFrmSpn" runat="server" CssClass="editprore"></asp:Label>
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
        <asp:AsyncPostBackTrigger ControlID="grvUsers" EventName="PageIndexChanging" />
        <asp:AsyncPostBackTrigger ControlID="grvUsers" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="grvGroups" EventName="RowDeleting" />
        <%--<asp:AsyncPostBackTrigger ControlID="ddlGroups" EventName="SelectedIndexChanged" />--%>
    </Triggers>
</asp:UpdatePanel>