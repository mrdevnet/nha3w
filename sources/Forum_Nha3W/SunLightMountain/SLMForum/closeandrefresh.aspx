<%@ Page Language="C#" AutoEventWireup="true" CodeFile="closeandrefresh.aspx.cs" Inherits="closeandrefresh" %>

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
    <div align="center">
    <br />
    <br />
    <asp:Label ID="lblReport" runat="server" CssClass="RedLink2"></asp:Label>
    <br />
    <br />
    <a id="href1" class="TopicLink" href="javascript:void(history.go(-1));" runat="server"><%= LoadSLMF("SLMF_Topic", "MoveBack")%></a>
    <a id="href2" class="TopicLink" href="javascript:void self.close(); opener.focus(); opener.location.reload();" runat="server"><%= LoadSLMF("SLMF_Topic", "CloseAndRefresh")%></a>
    </div>
    </form>
</body>
</html>
