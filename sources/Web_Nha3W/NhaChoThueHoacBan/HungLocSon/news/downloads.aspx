<%@ Page Language="C#" AutoEventWireup="true" CodeFile="downloads.aspx.cs" Inherits="news_downloads" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Nhà 3W - Kết nối & Xanh & Hiện đại</title>
    <link rel="shortcut icon" href="../images/favico.ico" type="image/x-icon" />
</head>
<body style="font-family:Tahoma,Arial,Times New Roman; font-size:13px;">
    <form id="form1" runat="server">
    <div style="width:100%; text-align:left;">
        <span id="TD" runat="server" style="font-weight:bold; font-size:18px; line-height:28px; color:#3B5998"></span><br />
        Download : <span id="DL" runat="server" style="color:Red;" ></span><br />
        <span id="TT" runat ="server" style="text-align:justify;"></span> <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Download Now</asp:LinkButton>
        <br />
    </div>
    </form>
</body>
</html>
