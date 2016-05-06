<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_avatars.ascx.cs" Inherits="AdminCp_Controls_slm_avatars" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink"><%= LoadSLMF("SLMF_AvatarA", "UploadAvatars")%></span>
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
                        <%= LoadSLMF("SLMF_AvatarA", "AvatarGroup")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:DropDownList ID="ddlCategories" onchange="GetSlmEnc();" AutoPostBack="true" CssClass="fontmsg" runat="server" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged" ></asp:DropDownList> 
                        <asp:Button CssClass="btnReg" ID="btnDelete" OnClientClick="return DelCategory();" runat="server" OnClick="btnDelete_Click" /> 
                        <asp:Button CssClass="btnReg" ID="btnReload" OnClientClick="GetSlmEnc();" runat="server" OnClick="btnReload_Click" />
                        &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/>
                        <script type="text/javascript"  language="Javascript">
                        function GetSlmEnc()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_avatars1_imgSpinner2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_avatars1_imgSpinner2"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_avatars1_imgSpinner2"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_avatars1_imgSpinner2"].height = "16";
                        }
                        
                        function DelCategory()
                        {
                            var i = confirm('<%= LoadSLMF("SLMF_AvatarA", "ConfirmDeleteCate") %>');
                            if (i)
                            {
                                GetSlmEnc();
                                return i;
                            }
                            return false;
                        }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_AvatarA", "CreateNewGrp")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="editprotxt"></asp:TextBox> 
                        <asp:Button CssClass="btnReg" ID="btnSave" runat="server" OnClick="btnSave_Click"/>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_AvatarA", "UploadAvatars2")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <a id="hrfUpload" runat="server" class="RatePoints" style="cursor: pointer;color: #2860B5;">[ ... ]</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height:8px"></td>
                </tr>
            </table>
            <asp:Panel ID="pnlAvatars" runat="server">
                <div style="padding-left:8px;padding-right:8px;padding-bottom:8px">
                    <fieldset >
                    <%--<legend>{<%= LoadSLMF("PermissionGrpFrmA", "pnlGroups")%>}</legend>--%>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="100%" class="EditPro" colspan="3" align="center">
                            <asp:GridView ID="grvAvatars" Width="100%" runat="server" AllowPaging="true" PageSize="15" AutoGenerateColumns="False" DataKeyNames="AvatarId" OnPageIndexChanging="grvAvatars_PageIndexChanging" OnRowDeleting="grvAvatars_RowDeleting" >
                                <Columns>
                                    <asp:BoundField DataField="AvatarId" HeaderText="ID">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Height="25px" Width="2%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Avatar">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Height="25px" ForeColor="OliveDrab" HorizontalAlign="Center" VerticalAlign="Middle" Width="8%" />
                                        <ItemTemplate>
                                            <img src='<%# "../slmuploads/avatar/" + Eval("Avatar") %>' alt='<%# Eval("Descriptions") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Descriptions" HeaderText="Nhóm">
                                        <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Height="25px" Width="12%" />
                                    </asp:BoundField>
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
        </td>
    </tr>
</table>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="grvAvatars" EventName="PageIndexChanging" />
        <asp:AsyncPostBackTrigger ControlID="grvAvatars" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="ddlCategories" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
            