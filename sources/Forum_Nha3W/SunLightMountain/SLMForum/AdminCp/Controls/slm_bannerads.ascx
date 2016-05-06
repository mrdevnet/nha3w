<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_bannerads.ascx.cs" Inherits="AdminCp_Controls_slm_bannerads" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_AddBanners", "Title")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvSponsors" Width="100%" runat="server" AllowPaging="false" AutoGenerateColumns="False" PageSize="100" DataKeyNames="SponsorId" OnSelectedIndexChanged="grvSponsors_SelectedIndexChanged" OnRowDeleting="grvSponsors_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="SponsorId" HeaderText="Banner">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Height="25px" Width="4%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Script">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Left" VerticalAlign="Middle" Width="30%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblScript" runat="server" Text='<%# Eval("Scripts") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Description" HeaderText="Mô tả">
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="8%" />
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True" SelectText="Cập nhật">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="4%" />
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
             <asp:Panel ID="pnlForums" runat="server" Visible="false">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("SLMF_AddBanners", "PositionsOfBanner")%>}</legend>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="100%" class="EditPro" colspan="3" align="center">
                            <asp:GridView ID="grvForums" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30" DataKeyNames="SponsorId,ForumId" OnPageIndexChanging="grvForums_PageIndexChanging" OnRowDeleting="grvForums_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="SponsorId" HeaderText="Banner">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Height="25px" Width="3%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Diễn đàn">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" />
                                        <ItemTemplate>
                                            <a target="_blank" href='<%# "../topicdisplay.aspx?forumid=" + Eval("ForumId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma"><%# Eval("Name")%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nhóm Diễn đàn">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Left" VerticalAlign="Middle" Width="14%" />
                                        <ItemTemplate>
                                            <a target="_blank" href='<%# "../forumdisplay.aspx?groupid=" + Eval("CategoryId") %>' style="color:OliveDrab;font-size:11px;font-family:Tahoma"><%# Eval("CateName")%></a>
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
                            <%= LoadSLMF("SLMF_AddBanners", "ChooseForumDDl2")%>
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
                            <%= LoadSLMF("SLMF_AddBanners", "ChooseForum")%>
                        </td>
                        <td width="1%">
                        </td>
                        <td width="78%">
                            <asp:DropDownList ID="ddlJumper2" CssClass="fontmsg" runat="server" ></asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="trInsertFrmSpn2" visible="false" runat="server">
                        <td width="21%" class="EditPro">
                        </td>
                        <td width="1%">
                        </td>
                        <td width="78%">
                            <asp:Button CssClass="btnReg" ID="btnInsertFrmSpn" runat="server" OnClick="btnInsertFrmSpn_Click" />
                            <asp:Label ID="lblReportFrmSpn" runat="server" CssClass="editprore"></asp:Label>
                        </td>
                    </tr>
                </table>
                </fieldset>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlBanners" runat="server" Visible="false">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px">
                    <fieldset >
                    <legend>{<%= LoadSLMF("SLMF_AddBanners", "Details")%>}</legend>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="100%" class="EditPro" align="center" colspan="3">
                                    <FCKeditorV2:FCKeditor ID="txtScripts" 
                                            BasePath="~/FCKeditor/" 
                                            ToolbarSet="F91" 
                                            Height="300px" 
                                            AutoDetectLanguage="false" 
                                            DefaultLanguage="en" 
                                            SkinPath= 'skins/silver/' 
                                            runat="server">
                                    </FCKeditorV2:FCKeditor>
                                </td>
                            </tr>
                            <tr>
                                <td width="21%" class="EditPro">
                                    <%= LoadSLMF("SLMF_AddBanners", "Description")%>
                                </td>
                                <td width="1%">
                                </td>
                                <td width="78%">
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="editprotxt"></asp:TextBox> 
                                    <asp:LinkButton id="lbtExpandIp" runat="server" OnClick="lbtExpandIp_Click" ><img style="border:0px" src="../slmimages/expand.gif" /></asp:LinkButton> 
                                    <asp:LinkButton id="lbtCloseIp" Visible="false" runat="server" OnClick="lbtCloseIp_Click" ><img style="border:0px" src="../slmimages/collapse.gif" /></asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="trInsert" visible="false" runat="server">
                                <td width="21%" class="EditPro">
                                    <%= LoadSLMF("SLMF_AddBanners", "ChooseForum")%>
                                </td>
                                <td width="1%">
                                </td>
                                <td width="78%">
                                    <asp:DropDownList ID="ddlJumper" CssClass="fontmsg" runat="server" ></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td width="21%" class="EditPro">
                                </td>
                                <td width="1%">
                                </td>
                                <td width="78%">
                                    <asp:Button CssClass="btnReg" ID="btnInsert" runat="server" OnClick="btnInsert_Click" />
                                    <asp:Button CssClass="btnReg" ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" />
                                    <%--&nbsp;&nbsp;<img id="imgUpdateBlock" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/> --%>
                                    <asp:Label ID="lblReports" runat="server" CssClass="editprore"></asp:Label>
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
        <asp:AsyncPostBackTrigger ControlID="grvSponsors" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="grvSponsors" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="lbtExpandIp" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtCloseIp" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnInsert" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnInsertFrmSpn" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="grvForums" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="grvForums" EventName="PageIndexChanging" />
        <asp:AsyncPostBackTrigger ControlID="lbtExp2" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="lbtClo2" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>