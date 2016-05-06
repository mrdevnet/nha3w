<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsItem.ascx.cs" Inherits="NewsItem" Debug="true" %>
<div style=" width:100%; padding:5px 0px 0px 0px; float:left;" >
    <div class="divTB" >
        <a id="LinkImage" runat="server">
        <img id="AnhNB" runat="server" style="width:80px; padding-right:5px; float:left;" alt="" src="" />
        </a>
        <h2 style="font-size:12px;font-family: Tahoma; font-weight:bold; margin:0;"><a runat="server" id="TieuDeNB"></a> &nbsp;
        <img id="new0" runat="server" alt="" src ="../Images/icon_new.jpg" visible="false" /></h2>
        <span id="NgayDang" runat="server" style="color:  #808080; font-size:11px"></span>
        <br /><span style="font-size:12px;line-height:17px;font-family: Tahoma;" id="TomtacNB" runat="server"> </span>
    </div>
    <ul class="newsUL dot1">
    <li>
    <div style="width:100%; " id="show1" runat="server" visible="false">
    <div class="it"  style="width:315px; float:left;">
     <a id="TD1"    runat="server"></a> <img id="new1" runat="server" style="margin-left:3px;" visible="false" alt="" src ="../Images/icon_new.jpg" />
     <span id="ND1" runat="server" style="color:  #808080; font-size:11px"> </span>
     </div>
     <div style="width:60px; padding:0px 5px 5px 5px; float:left;">
     <a id="a1" runat="server" href="">
      <img id="img1" src="" style="width:60px; height:35px;" alt="" runat="server" />
      </a>
     </div>
     </div>
     </li>
    <li>
    <div  style="width:100%;" id="show2" runat="server" visible="false" >
    <div class="it" style="width:315px;float:left; ">
     <a id="TD2"    runat="server"></a> <img id="new2" runat="server" style="margin-left:3px;" visible="false" alt="" src ="../Images/icon_new.jpg" />
     <span id="ND2" runat="server" style="color:  #808080; font-size:11px"> </span>
    </div>
    <div style="width:60px; padding:0px 5px 5px 5px; float:left;">
    <a id="a2" runat="server" href="">
     <img id="img2" src="" style="width:60px; height:35px;" alt="" runat="server"  />
     </a>
     </div>
    </div>
    </li>
    <li>
    <div  style="width:100%;" id="show3" runat="server" visible="false" >
    <div class="it" style="width:315px;float:left;">
     <a id="TD3"    runat="server"></a> <img id="new3" runat="server" style="margin-left:3px;" visible="false" alt="" src ="../Images/icon_new.jpg" />
     <span id="ND3" runat="server" style="color:  #808080; font-size:11px"> </span>
    </div>
    <div style="width:60px; padding:0px 5px 5px 5px; float:left;">
    <a id="a3" runat="server" href="">
     <img id="img3" src="" style="width:60px; height:35px;" alt="" runat="server"  />
     </a>
     </div>
    </div>
    </li>
    <li>
    <div  style="width:100%;"  id="show4" runat="server" visible="false">
    <div class="it" style="width:315px;float:left; ">
     <a id="TD4"     runat="server"></a> <img id="new4" runat="server" style="margin-left:3px;" visible="false" alt="" src ="../Images/icon_new.jpg" />
     <span id="ND4" runat="server"  style="color:  #808080; font-size:11px"> </span>
    </div>
    <div style="width:60px; padding:0px 5px 5px 5px; float:left;">
    <a id="a4" runat="server" href="">
     <img id="img4" src="" style="width:60px; height:35px;" alt="" runat="server"  />
     </a>
     </div>
    </div>
    </li>
    </ul>
</div>

