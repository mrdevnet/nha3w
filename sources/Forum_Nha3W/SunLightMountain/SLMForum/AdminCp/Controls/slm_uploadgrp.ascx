<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_uploadgrp.ascx.cs" Inherits="AdminCp_Controls_slm_uploadgrp" %>
<table cellpadding="0" align="center" cellspacing="1" class="tblMost">
    <tr>
        <td class="TopMost2" align="center">
            <span class="MostLink" id="spnMost" runat="server"></span>
        </td>
    </tr>
    <tr>
        <td class="Mid">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GroupA", "File1")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <input id="fup1" runat="server" type="file" size="40" style="height:23px"/>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GroupA", "File2")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <input id="fup2" runat="server" type="file" size="40" style="height:23px"/>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                        <%= LoadSLMF("SLMF_GroupA", "File3")%>
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <input id="fup3" runat="server" type="file" size="40" style="height:23px"/>
                    </td>
                </tr>
                <tr>
                    <td width="21%" class="EditPro">
                    </td>
                    <td width="1%">
                    </td>
                    <td width="78%">
                        <asp:Button CssClass="btnReg" ID="btnUpload" runat="server" OnClientClick="GetSlmEnc();" OnClick="btnUpload_Click" />
                        <asp:Button CssClass="btnReg" ID="btnClose" runat="server" OnClientClick="javascript:window.close();" />
                        &nbsp;&nbsp;<img id="imgSpinner2" alt="" visible="true" src="~/SlmImages/onepix1.jpg" runat="server"/>
                        <asp:Label ID="lblReport" runat="server" Font-Names="Tahoma" Font-Size="12px" ForeColor="blue" Visible="false"></asp:Label>
                        <script type="text/javascript"  language="Javascript">
                        function GetSlmEnc()
                        {
                        document.aspnetForm["Slm_uploadgrp1_imgSpinner2"].src = "../SlmImages/progress.gif";
                        document.aspnetForm["Slm_uploadgrp1_imgSpinner2"].visible = true;
                        document.aspnetForm["Slm_uploadgrp1_imgSpinner2"].width = "16";
                        document.aspnetForm["Slm_uploadgrp1_imgSpinner2"].height = "16";
                        }
                        </script>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height:8px;padding-left:8px;padding-bottom:8px">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>