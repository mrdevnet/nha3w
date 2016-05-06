<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_updelgroup.ascx.cs" Inherits="AdminCp_Controls_slm_updelgroup" %>
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
                    <td width="100%" class="EditPro" colspan="3">
                        <FCKeditorV2:FCKeditor ID="txtGroupName" 
                                BasePath="~/FCKeditor/" 
                                ToolbarSet="F91" 
                                Height="120px" 
                                AutoDetectLanguage="false" 
                                DefaultLanguage="en" 
                                SkinPath= 'skins/silver/' 
                                runat="server">
                        </FCKeditorV2:FCKeditor>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GroupA", "GetPosts")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtGetPosts" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GroupA", "SelectRankImage")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:DropDownList ID="ddlRank" onchange="GetSlmEnc2();" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRank_SelectedIndexChanged"></asp:DropDownList>&nbsp;
                        <asp:LinkButton id="lbtBlockUser" OnClientClick="GetSlmEnc2();" runat="server" OnClick="lbtBlockUser_Click"><img style="border:0px" src="../slmimages/expand.gif" /></asp:LinkButton>
                        &nbsp;&nbsp;<img id="imgRefresh" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/> 
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GroupA", "RankImage")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <img id="imgRankImage" runat="server" visible="false" alt=""/>&nbsp;&nbsp;
                        <a id="hrfUpload" runat="server" class="RatePoints" style="cursor: pointer;color: #2860B5;">[ ... ]</a>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GroupA", "PmLimit")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:TextBox ID="txtPmLimit" runat="server" CssClass="editprotxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro"></td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:Button CssClass="btnReg" ID="btnSave" runat="server" OnClientClick="GetSlmEnc();" OnClick="btnSave_Click"  />
                        &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/> 
                        <asp:Label ID="lblReport" runat="server" CssClass="editprore"></asp:Label>
                        <script type="text/javascript"  language="Javascript">
                        function GetSlmEnc()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelgroup1_imgSpinner2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelgroup1_imgSpinner2"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelgroup1_imgSpinner2"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelgroup1_imgSpinner2"].height = "16";
                        }
                        function GetSlmEnc2()
                        {
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelgroup1_imgRefresh"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelgroup1_imgRefresh"].visible = true;
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelgroup1_imgRefresh"].width = "16";
                        document.aspnetForm["ctl00_cplAdmin_Slm_updelgroup1_imgRefresh"].height = "16";
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
        <asp:AsyncPostBackTrigger ControlID="lbtBlockUser" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ddlRank" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>