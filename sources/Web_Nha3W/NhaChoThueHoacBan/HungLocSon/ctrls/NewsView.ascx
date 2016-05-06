<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsView.ascx.cs" Inherits="NewsView" Debug="true" %>
<%@ Register Src="MapLink.ascx" TagName="MapLink" TagPrefix="uc1" %>
<table  width="100%" >
    <tr>
        <td align="left" valign="top">
            <uc1:MapLink ID="lm" runat="server" /><hr />
            <asp:Label ID="lbTD" runat="server" text="" Font-Size="12pt" ForeColor="#336699" Font-Bold="true"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            <asp:Label ID="lbND" runat="server" text="" Font-Italic="true"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top" >
            <div style="width:100%; padding:5px 0px 10px 0px">
                <div style="width:170px; float:left" align="center" >
                    <asp:Image ID="imgMH" runat="server" width="150px"/>
                </div>
                <asp:Label ID="lbTT" runat="server" text="" Font-Bold="true"></asp:Label>
            </div><br />
        </td>
    </tr>
    <tr>
        <td id="NoiDung" runat="server" style="overflow:auto; padding:10px 5px 20px 5px;" align="left" valign="top"></td>
    </tr>
    <tr>
        <td style="text-align: right" >
            <div style="width:100%; padding-top:5px; text-align:left;">
                <span style="font-size:15px; padding:5px; font-weight:bold; color:#3B5998">Tags : </span><a id="tags" runat="server" href=""></a>
            </div>
            <div class="dot2" style="width:100%; padding-top:5px; margin-top:5px;">
            <div style="width:40%; text-align: left; float:left;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div style="float:left;">
                            <asp:ImageButton Alternatetext="Bài hay" ID="btBinhChon" runat="server" ImageUrl="~/Images/rang.gif" OnClick="btBinhChon_Click" />
                        </div>
                        <div style="text-align:left; vertical-align:bottom; color:#73AC59; font-weight:bold; padding-top:2px;">&nbsp;
                            <asp:Label ID="lbRating" runat="server" Font-Size="14px"></asp:Label><span> Ý kiến</span>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div style="width:60%; text-align:right; padding-top:2px; float:left;" >
                <!-- ADDTHIS BUTTON BEGIN -->
                <script type="text/javascript">
                    addthis_pub             = 'nha3w.com';
                    addthis_logo            = '';
                    addthis_logo_background = 'EFEFFF';
                    addthis_logo_color      = '666699';
                    addthis_brand           = 'nha3w.com';
                    addthis_options         = 'favorites, email, digg, delicious, myspace, facebook, google, live, more';
                </script>
                <img src="../App_Themes/User/bc.png" style="border:0px; " width="16" height="16" alt="" />
                <a href="#" onmouseover="return addthis_open(this, '', '<%=Request.Url.ToString()  %>', '<%= lbTD.Text.ToString() %>')" onmouseout="addthis_close()" onclick="return addthis_sendto()">Chia Sẻ</a>
                <img src="../App_Themes/User/yahoo.jpg" style="border:0px; " width="16" height="16" alt=""  />
                <a href="ymsgr:im?+&amp;msg=<%=Request.Url.ToString()  %> : <%= lbTD.Text.ToString() %>" style="cursor: pointer;">Gửi YM</a>
                <script type="text/javascript" src="../JaVa/addthis.js"></script>
                <!-- ADDTHIS BUTTON END -->
                <img alt="" src="../App_Themes/User/printer.gif" />
                <a id="linkIn" href="" runat="server">Tạo trang in</a>
                <img alt="" src="../App_Themes/User/arrowtop.gif" />
                <a href="#">Về đầu trang</a>
                <img alt="" src="../App_Themes/User/arrowLest.gif" />
                <a href="javascript:history.go(-1)">Quay lại</a>
            </div>
        </div>
    </td>
    </tr>
    <tr>
        <td  align="left" valign="top">
            <div class="dot2" style="width:100%; padding-top:5px;">
                <ul id="TinLQ" class="newsList" runat="server"></ul>
            </div>
        </td>
    </tr>
</table>
