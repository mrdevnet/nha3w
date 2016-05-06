<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_addforums.ascx.cs" Inherits="AdminCp_Controls_slm_addforums" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:UpdatePanel ID="updLogin" runat="server">
<ContentTemplate>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink" id="spnReport" runat="server"></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_ForumA", "Name")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtName" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="100%" class="EditPro" colspan="3">
                        <FCKeditorV2:FCKeditor ID="txtContent" 
                                BasePath="~/FCKeditor/" 
                                ToolbarSet="F91" 
                                Height="148px" 
                                AutoDetectLanguage="false" 
                                DefaultLanguage="en" 
                                SkinPath= 'skins/silver/' 
                                runat="server">
                        </FCKeditorV2:FCKeditor>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_ForumA", "ParForum")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:DropDownList AutoPostBack="true" ID="ddlJumper" CssClass="fontmsg" runat="server" OnSelectedIndexChanged="ddlJumper_SelectedIndexChanged" ></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_ForumA", "TypeForum")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:DropDownList ID="ddlTypeForum" CssClass="fontmsg" runat="server" ></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_ForumA", "TotalTopics")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtTotalTopics" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_ForumA", "TotalMessages")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtTotalMessages" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_ForumA", "CateId")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:DropDownList ID="ddlCategories" CssClass="fontmsg" runat="server" ></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro"></td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:Button CssClass="btnReg" ID="btnSave" runat="server" OnClientClick="GetSlmEnc();" OnClick="btnSave_Click" />
                        &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/> 
                        <asp:Label ID="lblReport" runat="server" CssClass="editprore"></asp:Label>
                        <script type="text/javascript"  language="Javascript">
                        function GetSlmEnc()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_addforums1_imgSpinner2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_addforums1_imgSpinner2"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_addforums1_imgSpinner2"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_addforums1_imgSpinner2"].height = "16";
                        }
                        </script>
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
        <asp:AsyncPostBackTrigger ControlID="ddlJumper" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>