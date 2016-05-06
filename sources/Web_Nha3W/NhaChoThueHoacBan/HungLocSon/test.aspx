<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:LinkButton ID="blki2" runat="server" CssClass="hc" OnClick="blki2_Click">Khoá kết nối </asp:LinkButton>
    
    
    <div id="page_container">
         <div id="header">
            <div id="logo"><a href="Default.aspx" title="Nhà 3W - Kết nối & Xanh & Hiện đại"><img src="images/nha3w.png" id="img2" class="ilogo" /></a></div>
            <div id="banner">
                <div class="ins">
                    <input type="text" id="txtS" value="Tìm kiếm" class="search" onfocus="if (this.value=='Tìm kiếm') this.value='';" onblur="if (this.value=='') this.value='Tìm kiếm';" />
                </div>
                <div class="ins2">
                    <input id="btnS" type="image" src="images/sr.jpeg"  alt="Tìm kiếm" runat="server" />
                </div>
                <div class="mnuH">
                    <a class="Header" href="Default.aspx">Trang chủ</a>
                </div>
                <div id="pri" class="mnuH" runat="server" visible="false">
                    <a class="Header" href="#">Cá nhân</a>
                </div>
                <div class="mnuH">
                    <a class="Header" href="#">Diễn đàn</a>
                </div>
                <div class="mnuH">
                    <a class="Header" href="#">Tin tức</a>
                </div>
                <div id="reg" class="mnuH" visible="true" runat="server">
                    <a class="Header" href="login.aspx">Đăng ký</a>
                </div>
                <div id="lg" class="mnuH" visible="true" runat="server">
                    <a class="Header" href="login.aspx">Đăng nhập</a>
                </div>
                <div id="sg" class="mnuH" visible="false" runat="server">
                    <a class="Header" href="signout.aspx">Thoát</a>
                </div>
            </div>
         </div>
         <div id="linkr"><img src="images/bgl.png" alt=""/></div>
    </div>
    
    <asp:TextBox ID="a" runat="server"></asp:TextBox>
    
    <asp:Button ID="btn" runat="server" OnClick="btn_Click" />
    
     <asp:TextBox ID="b" runat="server"></asp:TextBox>
     
     <div style="width: 100%; text-align: left; border-bottom: 1px solid rgb(175, 195, 214); margin-top: -3px; background-color: rgb(216, 223, 234);">
        <div id="ctl00_Menu1_MN" style="width: 100%; height: 30px;">
            <ul class="ulMn">
                <li class="top">
                    <a href="Default.aspx" class="top_link"><span>Trang Chủ</span></a>
                </li>
                <li class="top">
                    <a href="categories.aspx?c=1" class="top_link"><span>Xã hội</span></a>
                    <ul class="sub">
                        <li>
                            <a href="categories.aspx?c=2">Giáo dục</a>
                        </li>
                        <li>
                            <a href="categories.aspx?c=3">Du lịch</a>
                        </li>
                        <li>
                            <a href="categories.aspx?c=4">Nhịp điệu trẻ</a>
                        </li>
                    </ul>
                </li>
                <li class="top">
                    <a href="categories.aspx?c=5" class="top_link"><span>Công nghệ</span></a>
                    <ul class="sub">
                        <li>
                            <a href="categories.aspx?c=6">Vi tính</a>
                        </li>
                        <li>
                            <a href="categories.aspx?c=8">Công nghệ mới</a>
                        </li>
                        <li>
                            <a href="categories.aspx?c=7">Mobile</a>
                        </li>
                        <li>
                            <a href="categories.aspx?c=18">2342342</a>
                        </li>
                    </ul>
                </li>
                <li class="top">
                    <a href="categories.aspx?c=9" class="top_link"><span>Thể Thao</span></a>
                    <ul class="sub">
                        <li>
                            <a href="categories.aspx?c=10">Bóng đá</a>
                        </li>
                        <li>
                            <a href="categories.aspx?c=11">360"</a>
                        </li>
                    </ul>
                </li>
                <li class="top">
                    <a href="categories.aspx?c=12" class="top_link"><span>Đời Sống</span></a>
                    <ul class="sub">
                        <li>
                            <a href="categories.aspx?c=14">Teen</a>
                        </li>
                        <li>
                            <a href="categories.aspx?c=13">Thời trang</a>
                        </li>
                    </ul>
                </li>
            </ul>
        </div>
    </div>

             
    </form>
</body>
</html>
