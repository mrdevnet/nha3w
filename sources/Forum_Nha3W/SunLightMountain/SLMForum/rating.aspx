<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rating.aspx.cs" Inherits="rating" %>

<%@ Register Src="SlmControls/slm_rating.ascx" TagName="slm_rating" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Powered by PAF - The ASP.Net Forum..</title>
    <link href="SlmStyles/SlmMsg.css" rel="stylesheet" type="text/css" />
    <link href="SlmStyles/SlmTopic.css" rel="stylesheet" type="text/css" />
    <link href="SlmStyles/SlmForum.css" rel="stylesheet" type="text/css" />
    <link href="SlmStyles/SlmControls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:slm_rating ID="Slm_rating1" runat="server" />
    </form>

</body>
</html>
