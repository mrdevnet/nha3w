<%@ Page Language="C#" AutoEventWireup="true" CodeFile="print.aspx.cs" Inherits="news_print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Nhà 3W - Kết nối & Xanh & Hiện đại</title>
    <link rel="shortcut icon" href="../images/favico.ico" type="image/x-icon" /> 
    <style type="text/css">
        .style1
        {
            color: #0000CC;
            font-weight: bold;
        }
    </style>
</head>
<body style="text-align:center; font-family:Tahoma, Arial">
    <form id="form1" runat="server">
    <div style="width:700px; margin:0px auto 0px auto">
    <table  width="100%" >
        <tr>
            <td  align="left" valign="top">
                <img alt="" src="../App_Themes/User/printer.gif" />
                <a style=" font-weight:bold; font-size:13px;" href="javascript:window.print();">In Trang Tin</a>&nbsp;
                <span style="padding:0px; margin:0; font-weight:bold; line-height:15px;color:#3b5889" >Nhà 3W - Kết nối & Xanh & Hiện đại</span>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
            <hr />
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="lbTD" runat="server" Text="" Font-Size="15px" ForeColor="#336699" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:Label ID="lbND" runat="server" Font-Size="13px" Text="" Font-Italic="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <div style="width:100%; padding:5px 0px 10px 0px">
                <div style="width:170px; float:left" align="center" >
                    <asp:Image ID="imgMH" runat="server" Width="150px"/>
                </div>
                    <asp:Label ID="lbTT" runat="server" Text="" Font-Size="13px" Font-Bold="true"></asp:Label>
                </div>
                <br />
            </td>
        </tr>
        <tr>
            <td id="NoiDung" runat="server" style="overflow:auto;" align="left" valign="top">
            </td>
        </tr>
        <tr>
            <td  align="left" valign="top"><hr />
            </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
