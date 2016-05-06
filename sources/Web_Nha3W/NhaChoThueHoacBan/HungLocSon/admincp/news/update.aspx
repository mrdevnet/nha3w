<%@ Page Language="C#" MasterPageFile="~/admincp/HLSNwAdmins.master" AutoEventWireup="true" CodeFile="update.aspx.cs" Inherits="admincp_news_update"  %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainCPH" Runat="Server">
<script src="../../Java/InsertNumber.js" type="text/javascript"> </script>
<table style="width:98%; padding:10px; margin:0px auto 0px auto; text-align:center;">
    <tr>
        <td  style="text-align:left;  font-weight:bold; color:#3b5889" colspan="2">&nbsp;Thông Tin Chung&nbsp;
            <asp:Label ID="lbMB" runat="server" ForeColor="#67A54B"></asp:Label>
        </td>
    </tr>
    <tr>
        <td  style="width:200px; text-align:right;">Tiêu Đề :</td>
        <td style="width:auto; text-align:left; padding-left:5px;">
            <asp:TextBox ID="txtT" runat="server" Width="402px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtT" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td  style="width: 200px; text-align: right">Tóm Tắt :</td>
        <td style="padding-left: 5px; width: auto; text-align: left">
            <asp:TextBox ID="txtS" runat="server" Width="402px" Height="93px" TextMode="MultiLine"></asp:TextBox>
            <img alt="" id="img"  runat="server"  src="../../Images/Noimages.jpg" style="width:70px; height:70px; margin:5px; padding:5px;" />
        </td>
    </tr>
    <tr>
        <td  style="width: 200px; text-align: right">Nhóm Tin :</td>
        <td style="padding-left: 5px; width: auto; text-align: left">
            <asp:DropDownList ID="cbC" runat="server" Width="182px" DataTextField="Name" DataValueField="CatalogId"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td  style="width: 200px; text-align: right">Tag :</td>
        <td style="padding-left: 5px; width: auto; text-align: left">
            <asp:TextBox ID="txtTa" runat="server" Width="402px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td  style="width: 200px; text-align: right">Bình Luận :</td>
        <td style="padding-left: 5px; width: auto; text-align: left">
            <input id="txtRa" runat="server" style="width:170px;" onkeypress="return numbersonly(this, event)" size="20"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRa" ErrorMessage="*" ValidationGroup="ttt"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td  style="width: 200px; text-align: right">Lượt Xem :</td>
        <td style="padding-left: 5px; width: auto; text-align: left">
            <input id="txtView" runat="server" style="width:170px;" onkeypress="return numbersonly(this, event)" size="20"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtView" ErrorMessage="*" ValidationGroup="ttt"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td  style="width: 200px; text-align: right">Ảnh Đại Diện :</td>
        <td style="padding-left: 5px; width: auto; text-align: left">
            <asp:FileUpload ID="fulImage" runat="server" Width="407px" />
        </td>
    </tr>
    <tr>
        <td  style="width: 200px; text-align: right">Nổi Bật :</td>
        <td style="padding-left: 5px; width: auto; text-align: left">
            <asp:CheckBox ID="ckbT" runat="server" Text="Cho Phép" />
        </td>
    </tr>
    <tr>
        <td  style="text-align:left;font-weight:bold; color:#3b5889" colspan="2">&nbsp;Nội Dung&nbsp;
            <asp:Label ID="lbND" runat="server" ForeColor="#67A54B"></asp:Label>
        </td>
    </tr>
    <%--<tr>
        <td  style="text-align:center; color:#808080" colspan="2">Nôi Dung Bài Viết</td>
    </tr>--%>
    <tr>
        <td  style="text-align:center;" colspan="2">
            <fckeditorv2:fckeditor id="fckC" runat="server" basepath="~/fckeditor/" height="476px" width="85%"></fckeditorv2:fckeditor>
        </td>
    </tr>
    <tr>
        <td  style="text-align:center" colspan="2">
            <asp:Button ID="btok" runat="server" BackColor="#67A54B" BorderColor="Black" BorderWidth="1px" Font-Bold="True" ForeColor="White" Text="Submit" Width="91px" OnClick="btok_Click" ValidationGroup="ttt"  />
        </td>
    </tr>
</table>
</asp:Content>
