<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_cateman.ascx.cs" Inherits="AdminCp_Controls_slm_cateman" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_ForumA", "CategoryManTitle")%></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_ForumA", "CategoryName")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtName" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_ForumA", "OrderBy")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtOrderBy" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:Button CssClass="btnReg" ID="btnSave" runat="server" OnClientClick="GetSlmEnc();" OnClick="btnSave_Click" />
                        &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/>
                        <script type="text/javascript"  language="Javascript">
                        function GetSlmEnc()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_cateman1_imgSpinner2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_cateman1_imgSpinner2"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_cateman1_imgSpinner2"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_cateman1_imgSpinner2"].height = "16";
                        }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height:8px"></td>
                </tr>
                <tr>
                    <td width="100%" class="EditPro" colspan="3" align="center">
                        <asp:GridView ID="grvCategory" Width="100%" runat="server" AutoGenerateColumns="False" PageSize="30" DataKeyNames="CategoryId" OnRowDeleting="grvCategory_RowDeleting" >
                            <Columns>
                                <asp:BoundField DataField="CateName" HeaderText="Danh mục">
                                    <ItemStyle Font-Names="Tahoma" Font-Bold="true" Font-Size="11px" HorizontalAlign="Left" VerticalAlign="Middle" Height="25px" Width="40%" />
                                    <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OrderBy" HeaderText="Vị tr&#237;">
                                    <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center"
                                        VerticalAlign="Middle" Width="8%" />
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
        <asp:AsyncPostBackTrigger ControlID="grvCategory" EventName="PageIndexChanging" />
        <asp:AsyncPostBackTrigger ControlID="grvCategory" EventName="RowDeleting" />
    </Triggers>
</asp:UpdatePanel>