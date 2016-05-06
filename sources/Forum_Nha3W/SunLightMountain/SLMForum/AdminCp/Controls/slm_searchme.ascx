<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_searchme.ascx.cs" Inherits="AdminCp_Controls_slm_searchme" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_GeneralA", "BlockUserTitle")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GeneralA", "UserName")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtSearchMe" runat="server" CssClass="editprotxt"></asp:TextBox>&nbsp;
                        <asp:Button CssClass="btnReg" ID="btnSave" runat="server" OnClientClick="GetSlmEnc();" OnClick="btnSave_Click" />
                        &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/>
                        <script type="text/javascript"  language="Javascript">
                        function GetSlmEnc()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_searchme1_imgSpinner2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_searchme1_imgSpinner2"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_searchme1_imgSpinner2"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_searchme1_imgSpinner2"].height = "16";
                        }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height:8px"></td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:GridView ID="grvUserName" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="12" DataKeyNames="UserName" OnPageIndexChanging="grvUserName_PageIndexChanging" OnRowDeleting="grvUserName_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="UserName" HeaderText="T&#224;i khoản">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="300px" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:CommandField ShowDeleteButton="True">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="OliveDrab" HorizontalAlign="Center"
                                        VerticalAlign="Middle" Width="80px" />
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
        <asp:AsyncPostBackTrigger ControlID="grvUserName" EventName="PageIndexChanging" />
        <asp:AsyncPostBackTrigger ControlID="grvUserName" EventName="RowDeleting" />
    </Triggers>
</asp:UpdatePanel>