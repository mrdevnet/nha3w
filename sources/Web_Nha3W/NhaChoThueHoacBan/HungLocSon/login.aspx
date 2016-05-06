﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<%@ Register Src="ctrls/lgr.ascx" TagName="lgr" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Nhà 3W - Kết nối & Xanh & Hiện đại</title>
    <link href="styles/exts.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="images/hunglocson.ico" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager ID="ssm" runat="server" />
        <uc1:lgr ID="Lgr1" runat="server" />
    </form>
</body>
</html>
