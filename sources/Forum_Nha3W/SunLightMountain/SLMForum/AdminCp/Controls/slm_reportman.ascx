<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_reportman.ascx.cs" Inherits="AdminCp_Controls_slm_reportman" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_ReportA", "ReportManager")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_ReportA", "ForumId")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:DropDownList ID="ddlJumper" CssClass="fontmsg" runat="server" ></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_ReportA", "ReportId")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:DropDownList ID="ddlReports" CssClass="fontmsg" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:Button CssClass="btnReg" ID="btnSave" runat="server" OnClientClick="GetSlmEnc();" OnClick="btnSave_Click"  />
                        &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/> 
                        <asp:Label ID="lblReport" runat="server" CssClass="editprore"></asp:Label>
                        <script type="text/javascript"  language="Javascript">
                        function GetSlmEnc()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_reportman1_imgSpinner2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_reportman1_imgSpinner2"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_reportman1_imgSpinner2"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_reportman1_imgSpinner2"].height = "16";
                        }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height:8px"></td>
                </tr>
                <tr>
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvReportMan" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="12" DataKeyNames="ReportId,ForumId" OnPageIndexChanging="grvReportMan_PageIndexChanging" OnRowDeleting="grvReportMan_RowDeleting" >
                            <Columns>
                                <asp:BoundField DataField="Title" HeaderText="Th&#244;ng b&#225;o">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="30%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Name" HeaderText="Diễn đ&#224;n">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" Width="30%" HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:CommandField ShowDeleteButton="True">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center"
                                        VerticalAlign="Middle" Width="8%" />
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
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="grvReportMan" EventName="PageIndexChanging" />
        <asp:AsyncPostBackTrigger ControlID="grvReportMan" EventName="RowDeleting" />
    </Triggers>
</asp:UpdatePanel>