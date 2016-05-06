<%@ Control Language="C#" AutoEventWireup="true" CodeFile="groups.ascx.cs" Inherits="admincp_ctrls_groups" %>
<%@ Register Assembly="FUA" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<div class="ph1"><img src="~/images/bgl.png" alt=""/></div>
<div class="ph3">Nhóm Thành Viên</div>
<asp:UpdatePanel id="sig" runat="server">
<ContentTemplate>
<div class="ph4">
    Nhóm : <input id="txtGroupName" class="lsp" type="text" runat="server"/> &nbsp;
    Bài viết : <input id="txtPosts" class="lsp" type="text" runat="server"/> 
    <br /><br />
    Cấp bậc : <cc1:FileUploaderAJAX ID="fp1" runat="server" MaxFiles="5" text_Add="Thêm" text_Delete="Xoá" text_Uploading="Đang upload file"/>&nbsp;
    Tin nhắn : <input id="txtPm" class="lsp" type="text" runat="server"/> <asp:Button CssClass="lsp2" ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
    <br /><br />
    <asp:GridView ID="gCities" Width="99%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30" DataKeyNames="GroupId" BorderColor="#B3C5D8" BorderStyle="Solid" BorderWidth="1px" OnRowCancelingEdit="gCities_RowCancelingEdit" OnRowDeleting="gCities_RowDeleting" OnRowEditing="gCities_RowEditing" OnRowUpdating="gCities_RowUpdating" OnSelectedIndexChanged="gCities_SelectedIndexChanged" >
        <Columns>
            <asp:TemplateField HeaderText="Nh&#243;m">
                <EditItemTemplate>
                    <asp:Label ID="lbl1" runat="server" Text='<%# Bind("GroupId") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl2" runat="server" Text='<%# Bind("GroupId") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="T&#234;n Nh&#243;m">
                <EditItemTemplate>
                    <asp:TextBox ID="txtGroupName2" runat="server" Text='<%# Bind("GroupName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl3" runat="server" Text='<%# Bind("GroupName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="B&#224;i viết">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPosts2" runat="server" Text='<%# Bind("Posts") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl4" runat="server" Text='<%# Eval("Posts")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cấp bậc">
                <EditItemTemplate>
                    <img src='../images/<%# Eval("Rank") %>' alt=""/>
                </EditItemTemplate>
                <ItemTemplate>
                    <img src='../images/<%# Eval("Rank") %>' alt=""/>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tin nhắn">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPm2" runat="server" Text='<%# Bind("Pm") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl5" runat="server" Text='<%# Eval("Pm")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="20%" />
            </asp:TemplateField>
            <asp:CommandField ShowSelectButton="True" >
                <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" Width="5%" HorizontalAlign="Center" VerticalAlign="Middle"/>
            </asp:CommandField>
            <asp:CommandField ShowEditButton="True" >
                <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" Width="5%" HorizontalAlign="Center"
                    VerticalAlign="Middle"/>
            </asp:CommandField>
            <asp:CommandField ShowDeleteButton="True">
                <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="5%" />
            </asp:CommandField>
        </Columns>
        <PagerStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59"
            HorizontalAlign="Left" VerticalAlign="Middle" />
        <HeaderStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="RoyalBlue" />
        <SelectedRowStyle BackColor="#eceff5" />
    </asp:GridView>
    <div class="ph1"><img src="~/images/bgl.png" alt=""/></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Gửi bài viết</div>
    <div class="rt3"><asp:RadioButton ID="rbt1posty" runat="server" GroupName="Posts" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt1postn" runat="server" GroupName="Posts" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Sửa bài viết</div>
    <div class="rt3"><asp:RadioButton ID="rbt2edity" runat="server" GroupName="Edit" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt2editn" runat="server" GroupName="Edit" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Xoá bài viết</div>
    <div class="rt3"><asp:RadioButton ID="rbt3dely" runat="server" GroupName="Delete" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt3deln" runat="server" GroupName="Delete" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Duyệt bài viết</div>
    <div class="rt3"><asp:RadioButton ID="rbt4IsApproy" runat="server" GroupName="IsApprove" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt4IsAppron" runat="server" GroupName="IsApprove" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Bình luận bài viết</div>
    <div class="rt3"><asp:RadioButton ID="rbt5Commenty" runat="server" GroupName="Comment" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt5Commentn" runat="server" GroupName="Comment" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Nhắn tin</div>
    <div class="rt3"><asp:RadioButton ID="rbt6Pmy" runat="server" GroupName="Pm" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt6Pmn" runat="server" GroupName="Pm" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Email</div>
    <div class="rt3"><asp:RadioButton ID="rbt7Emy" runat="server" GroupName="Email" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt7Emn" runat="server" GroupName="Email" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Báo vi phạm</div>
    <div class="rt3"><asp:RadioButton ID="rbt8Alerty" runat="server" GroupName="Alert" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt8Alertn" runat="server" GroupName="Alert" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Báo đã bán</div>
    <div class="rt3"><asp:RadioButton ID="rbt9Cally" runat="server" GroupName="Call" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt9Calln" runat="server" GroupName="Call" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Lưu tin</div>
    <div class="rt3"><asp:RadioButton ID="rbt10Savey" runat="server" GroupName="Save" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt10Saven" runat="server" GroupName="Save" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Bình chọn</div>
    <div class="rt3"><asp:RadioButton ID="rbt11Votey" runat="server" GroupName="Vote" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt11Voten" runat="server" GroupName="Vote" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Đánh giá</div>
    <div class="rt3"><asp:RadioButton ID="rbt12Ratey" runat="server" GroupName="Rate" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt12Raten" runat="server" GroupName="Rate" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Upload</div>
    <div class="rt3"><asp:RadioButton ID="rbt13Uploady" runat="server" GroupName="Upload" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt13Uploadn" runat="server" GroupName="Upload" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Size Upload</div>
    <div class="rt3"><input id="txtSize" class="lsp" type="text" runat="server"/></div>
    <div class="rt4"></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Số File Upload</div>
    <div class="rt3"><input id="txtFiles" class="lsp" type="text" runat="server"/></div>
    <div class="rt4"></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Xem Profile</div>
    <div class="rt3"><asp:RadioButton ID="rbt16Profiley" runat="server" GroupName="Profile" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt16Profilen" runat="server" GroupName="Profile" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Ẩn Profile</div>
    <div class="rt3"><asp:RadioButton ID="rbt17Hidey" runat="server" GroupName="Hide" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt17Hiden" runat="server" GroupName="Hide" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Up Tin</div>
    <div class="rt3"><asp:RadioButton ID="rbt18Upy" runat="server" GroupName="Up" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt18Upn" runat="server" GroupName="Up" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Số Tin có thể Up</div>
    <div class="rt3"><input id="txtCountUp" class="lsp" type="text" runat="server"/></div>
    <div class="rt4"></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Up Vip</div>
    <div class="rt3"><asp:RadioButton ID="rbt20Vipy" runat="server" GroupName="Vip" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt20Vipn" runat="server" GroupName="Vip" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    
    <div class="rt1">Nhóm</div>
    <div class="rt2">Số Tin VIP</div>
    <div class="rt3"><input id="txtCVip" class="lsp" type="text" runat="server"/></div>
    <div class="rt4"></div>
    <div class="rt5"><hr noshade size="1"></div>
    
    
    <div class="rt1">Nhóm</div>
    <div class="rt2">Up IP</div>
    <div class="rt3"><asp:RadioButton ID="rbt21Ipy" runat="server" GroupName="IP" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt21Ipn" runat="server" GroupName="IP" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    
    <div class="rt1">Nhóm</div>
    <div class="rt2">Số Tin IP</div>
    <div class="rt3"><input id="txtCIp" class="lsp" type="text" runat="server"/></div>
    <div class="rt4"></div>
    <div class="rt5"><hr noshade size="1"></div>
    
    <div class="rt1">Nhóm</div>
    <div class="rt2">Download</div>
    <div class="rt3"><asp:RadioButton ID="rbt22Downloady" runat="server" GroupName="Download" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt22Downloadn" runat="server" GroupName="Download" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Duyệt tin</div>
    <div class="rt3"><asp:RadioButton ID="rbt23Aprrovey" runat="server" GroupName="Approve" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt23Aprroven" runat="server" GroupName="Approve" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Gia hạn</div>
    <div class="rt3"><asp:RadioButton ID="rbt24Renewy" runat="server" GroupName="Renew" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt24Renewn" runat="server" GroupName="Renew" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="ph1"><img src="~/images/bgl.png" alt=""/></div>
    <br /><br /><div class="rt5"><asp:Button CssClass="lsp2" ID="Update" runat="server" Text="Submit" OnClick="Update_Click" /></div>
    <div class="rt5"><img src="~/images/bgl.png" alt=""/></div><br /><br />
</div>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="submit" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowEditing" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowUpdating" />
    </Triggers>
</asp:UpdatePanel>