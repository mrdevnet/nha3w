<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewNews.ascx.cs" Inherits="NewNews" Debug="true" %>
<div style="width:100%; float:none;">
    <div style="width:100%">
        <div class = "divT1" style="text-align:center">
            <a id="AimgNB0" runat="server">
            <img id="imgTB0" width="300" src="" alt="" runat="server" /></a>
            </div>        
        <div class = "divT2" style="text-align:left">
            <h2 style="padding:10px 0px 10px 0px; margin:0; line-height:19px;font-size:15px;font-family:Tahoma" ><a id="tdNB0" runat="server"></a></h2>
            <span id="ndNB0" runat="server" style="color:  #808080; font-size:11px"></span>
            <br /><span style="line-height:17px;font-size:12px;font-family:Tahoma" id="ttNB0" runat="server"> </span>           
            </div>  
    </div>
    <div class="dot2"  style="width:100% ; float:left; padding-top:10px; padding-bottom:10px;">
        <div class = "divT1" style="text-align:left">
             <a id="AimgNB1" runat="server">
            <img id="imgTB1" runat="server" style="width:80px;  padding-right:5px; float:left;" alt="" src="" />
            </a>
            <h2 style="font-size:13px; font-family: Tahoma; font-weight:bold; margin:0;"><a runat="server" id="tdNB1"></a></h2>
            <span id="ndNB1" runat="server" style="color:  #808080; font-size:11px"></span>
            <br /><span style="line-height:17px;font-size:12px;font-family:Tahoma" id="ttNB1" runat="server"> </span>
        </div>
        <div class = "divT2 dot1" style="text-align:left">
          <a id="AimgNB2" runat="server">
        <img id="imgTB2" runat="server" style="width:80px; padding-right:5px; float:left;" alt="" src="" />
        </a>
        <h2 style="font-size:13px; font-family: Tahoma; font-weight:bold; margin:0;"><a runat="server" id="tdNB2"></a></h2>
        <span id="ndNB2" runat="server" style="color:  #808080; font-size:11px"></span>
        <br /><span style="line-height:17px;font-size:12px;font-family:Tahoma" id="ttNB2" runat="server"> </span></div>    
    </div >
    <div class="dot2" style="width:100% ; float:left;padding-top:15px; text-align: left;">
    
        <strong><span style="font-size:16px">
    Tin Khác </span></strong>
       <ul id="TinNB" class="newsList" runat="server">                                                
        </ul> 
    </div>
</div>