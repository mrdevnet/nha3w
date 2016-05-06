<%@ Control Language="C#" AutoEventWireup="true" CodeFile="slm_jump.ascx.cs" Inherits="SlmControls_slm_jump" %>
<table width="100%">
    <tr>
        <td height="10px">
        </td>
    </tr>
    <tr>
        <td align="right" class="JumperList">
            <%= LoadSLMF("SLMF_Forum", "JumpTo")%>&nbsp;<asp:DropDownList ID="ddlJumper" CssClass="fontmsg" runat="server" OnSelectedIndexChanged="ddlJumper_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </td>
    </tr>
</table>