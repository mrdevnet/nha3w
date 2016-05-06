<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Polls.ascx.cs" Inherits="Polls" Debug="true" %>

<div style="width:700px; padding-top:10px; text-align:left; float:left;">

<div style="width:100%; float:left; ">
   <div  class="divtopMN"> 
   <span style="color:White ; font:13px Tahoma;white-space:nowrap;font-weight:bold;">Thăm dò ý kiến</span>
   </div>
</div>
<div style="width:700px; height:auto; float:left;">
    <asp:UpdatePanel ID="up" runat="server">
    <ContentTemplate>
      <table style="width:700px;padding-top:5px">
        <tr>
            <td  colspan="2">
              <span id="ch" runat="server" style="color:#3B5998 ; padding-top:12px;padding-bottom:12px;padding-left:10px;font:12px Tahoma;font-weight:bold;">Thăm dò ý kiến </span>
                <span id="bc" runat="server" style="color:#67A54B" >binchon</span> <span id="Err" runat="server" style="color:Red;" ></span>
             <div class="dot2" style=" height:1px; width:100%; margin-top:5px;"></div>   
            </td>
        </tr>
        <tr>
            <td style=" max-width:330px; min-width:50px; padding:5px 0px;">
        <asp:RadioButtonList ID="rbl" runat="server" Font-Bold="False" Font-Italic="False" Font-Names="Tahoma" Font-Size="12px" ForeColor="Black" DatatextField="Title" DataValueField="ResultId">
        </asp:RadioButtonList></td>
            <td style="width:auto; min-width:300px; max-width:700px;">
            <div id="divT"  runat="server" visible="false" style="width:100%;float:left">            
             
            </div> 
            </td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
     <asp:AsyncPostBackTrigger ControlID="oke" EventName="Click" />
     <asp:AsyncPostBackTrigger ControlID="show" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    
  <div class="dot2" style="width:100%; float:left; padding-top:5px;">
  <div style="width:199px; float:left;">
  <asp:Button ID="oke" CssClass="cmd" runat="server" text="Bình chọn" width="86px" OnClick="oke_Click" Font-Names="tahoma" />
  <asp:Button ID="show" CssClass="cmd" runat="server" text="Kết quả" OnClick="show_Click" Font-Names="tahoma" width="100px" />
  </div>
  <div   style="padding:5px;">       
   
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up">
          <ProgressTemplate>
          
              <img alt="" src="../Images/loadingPoll.gif" />
          </ProgressTemplate>
      </asp:UpdateProgress>                                      
  </div>
            
  </div>
</div>
</div>
