<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_updelgrpfrm.ascx.cs" Inherits="AdminCp_Controls_slm_updelgrpfrm" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("PermissionGrpFrmA", "Title")%></span>
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
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelgrpfrm1_imgSpinner2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelgrpfrm1_imgSpinner2"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelgrpfrm1_imgSpinner2"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelgrpfrm1_imgSpinner2"].height = "16";
                        }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvForums" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="5" DataKeyNames="ForumId" OnPageIndexChanging="grvForums_PageIndexChanging" OnSelectedIndexChanged="grvForums_SelectedIndexChanged" >
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
                                <asp:CommandField ShowSelectButton="True" SelectText="Quyền">
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
                            <asp:GridView ID="grvGroups" Width="100%" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="GroupId,ForumId" OnSelectedIndexChanged="grvGroups_SelectedIndexChanged" OnRowDeleting="grvGroups_RowDeleting" >
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
                                    <asp:CommandField ShowSelectButton="True" SelectText="Thiết lập Quyền">
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
            <asp:Panel ID="pnlSetPermission" runat="server" Visible="false">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("PermissionGrpFrmA", "pnlPermissionGroup")%>}</legend>
                    <div style="padding-left:8px;padding-right:8px;padding-bottom:8px;padding-top:16px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("PermissionGrpFrmA", "PermissOfMembers")%>}</legend>
                    <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%" style="height:8px" colspan="3" align="center">
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Post")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtPostY" runat="server" GroupName="Post"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtPostN" runat="server" GroupName="Post"/>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Reply")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtReplyY" runat="server" GroupName="Reply"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtReplyN" runat="server" GroupName="Reply"/>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Poll")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtPollY" runat="server" GroupName="Poll"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtPollN" runat="server" GroupName="Poll"/>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Vote")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtVoteY" runat="server" GroupName="Vote"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtVoteN" runat="server" GroupName="Vote"/>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "ThanksAuthor")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtThankY" runat="server" GroupName="Thank"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtThankN" runat="server" GroupName="Thank"/>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="3" align="center">
                            <hr />
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Rate")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtRateY" runat="server" GroupName="Rate"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtRateN" runat="server" GroupName="Rate"/>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "ViewPro")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtViewProY" runat="server" GroupName="ViewPro"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtViewProN" runat="server" GroupName="ViewPro"/>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Upload")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtUploadY" runat="server" GroupName="Upload"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtUploadN" runat="server" GroupName="Upload"/>
                        </td>
                    </tr>                    
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "SizeUpload")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:TextBox Width="107px" Text="1000" ID="txtSizeUpload" runat="server" CssClass="editprotxt"></asp:TextBox>
                            <%= LoadSLMF("PermissionGrpFrmA", "Kb")%>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="3" align="center">
                            <hr />
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Approve")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtApproveY" runat="server" GroupName="Approve"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtApproveN" runat="server" GroupName="Approve"/>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Edit")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtEditY" runat="server" GroupName="Edit"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtEditN" runat="server" GroupName="Edit"/>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "DelMsg")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtDelMsgY" runat="server" GroupName="DelMsg"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtDelMsgN" runat="server" GroupName="DelMsg"/>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "DelTopic")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtDelTopicY" runat="server" GroupName="DelTopic"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtDelTopicN" runat="server" GroupName="DelTopic"/>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="3" align="center">
                            <hr />
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Quote")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtQuoteY" runat="server" GroupName="Quote"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtQuoteN" runat="server" GroupName="Quote"/>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Forward")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtForwardY" runat="server" GroupName="Forward"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtForwardN" runat="server" GroupName="Forward"/>
                        </td>
                    </tr>                    
                     <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Pm")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtPmY" runat="server" GroupName="Pm"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtPmN" runat="server" GroupName="Pm"/>
                        </td>
                    </tr>
                     <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Em")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtEmY" runat="server" GroupName="Em"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtEmN" runat="server" GroupName="Em"/>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "RptAuthor")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtRptAuthorY" runat="server" GroupName="RptAuthor"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtRptAuthorN" runat="server" GroupName="RptAuthor"/>
                        </td>
                    </tr>
                    </table>
                    </fieldset>
                    </div>
                    <div style="padding-left:8px;padding-right:8px;padding-bottom:8px;padding-top:16px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("PermissionGrpFrmA", "PermissOfModers")%>}</legend>
                    <table width="100%" cellpadding="0" cellspacing="0">
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Lock")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtLockY" runat="server" GroupName="Lock"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtLockN" runat="server" GroupName="Lock"/>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Sticky")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtStickyY" runat="server" GroupName="Sticky"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtStickyN" runat="server" GroupName="Sticky"/>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Move")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtMoveY" runat="server" GroupName="Move"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtMoveN" runat="server" GroupName="Move"/>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="3" align="center">
                            <hr />
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "UnLock")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtUnLockY" runat="server" GroupName="UnLock"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtUnLockN" runat="server" GroupName="UnLock"/>
                        </td>
                    </tr>                    
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "ApproAuthor")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtApproAuthorY" runat="server" GroupName="ApproAuthor"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtApproAuthorN" runat="server" GroupName="ApproAuthor"/>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "ViewIp")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:RadioButton ID="rbtViewIpY" runat="server" GroupName="ViewIp"/>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rbtViewIpN" runat="server" GroupName="ViewIp"/>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="3" align="center">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "AddNew4Grp")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:LinkButton id="lbtExp2" runat="server" OnClick="lbtExp2_Click" ><img style="border:0px" src="../slmimages/expand.gif" /></asp:LinkButton> 
                            <asp:LinkButton id="lbtClo2" Visible="false" runat="server" OnClick="lbtClo2_Click" ><img style="border:0px" src="../slmimages/collapse.gif" /></asp:LinkButton>
                        </td>
                    </tr>
                    </table>
                    </fieldset>
                    </div>
                    <asp:Panel ID="pnlInsert" runat="server" Visible="false">
                    <div style="padding-left:8px;padding-right:8px;padding-bottom:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("PermissionGrpFrmA", "AddNew4Grp")%>}</legend>
                    <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%" style="height:8px" colspan="3" align="center">
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("SLMF_GroupA", "SelectAGroup2")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:DropDownList ID="ddlGroups" CssClass="fontmsg" runat="server" ></asp:DropDownList>
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                            <%= LoadSLMF("PermissionGrpFrmA", "Default4All")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:CheckBox ID="Default4All" runat="server" />
                        </td>
                    </tr>
                    <tr >
                        <td width="30%" class="EditPro">
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:Button CssClass="btnReg" ID="btnInsGroups" runat="server" OnClick="btnInsGroups_Click" />
                            <asp:Label ID="lblReportFrmSpn" runat="server" CssClass="editprore"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" style="height:8px" colspan="3" align="center">
                        </td>
                    </tr>
                    </table>
                    </fieldset>
                    </div>
                </asp:Panel>
                <table width="100%" cellpadding="0" cellspacing="0" id="tblInsert" runat="server">
                    <%--<tr>
                        <td width="100%" colspan="3" align="center">
                            <hr />
                        </td>
                    </tr>--%>
                    <tr >
                        <td width="30%" class="EditPro">
                        </td>
                        <td width="1%">
                        </td>
                        <td width="69%">
                            <asp:Button CssClass="btnReg" ID="btnUpdateSet" runat="server" OnClick="btnUpdateSet_Click" />
                            <asp:Label ID="lblPermission" runat="server" CssClass="editprore"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" style="height:8px" colspan="3" align="center">
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
        <asp:AsyncPostBackTrigger ControlID="ddlCategories" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>