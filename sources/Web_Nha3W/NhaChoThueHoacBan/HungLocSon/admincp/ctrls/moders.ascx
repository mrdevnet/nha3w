<%@ Control Language="C#" AutoEventWireup="true" CodeFile="moders.ascx.cs" Inherits="admincp_ctrls_moders" %>
<div class="ph1"><img src="~/images/bgl.png" alt=""/></div>
<div class="ph3">Tài khoản Quản lý</div>
<asp:UpdatePanel id="sig" runat="server">
<ContentTemplate>
<div class="ph4">
    Cấp bậc : <input id="txtModerName" class="lsp" type="text" runat="server"/> &nbsp;<asp:Button CssClass="lsp2" ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
    <br /><br />
    <asp:GridView ID="gCities" Width="99%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30" DataKeyNames="ModerId" BorderColor="#B3C5D8" BorderStyle="Solid" BorderWidth="1px" OnRowCancelingEdit="gCities_RowCancelingEdit" OnRowDeleting="gCities_RowDeleting" OnRowEditing="gCities_RowEditing" OnRowUpdating="gCities_RowUpdating" OnSelectedIndexChanged="gCities_SelectedIndexChanged" >
        <Columns>
            <asp:TemplateField HeaderText="Cấp bậc">
                <EditItemTemplate>
                    <asp:Label ID="lbl1" runat="server" Text='<%# Bind("ModerId") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl2" runat="server" Text='<%# Bind("ModerId") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Moder">
                <EditItemTemplate>
                    <asp:TextBox ID="txtEModerName" runat="server" Text='<%# Bind("ModerName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl3" runat="server" Text='<%# Bind("ModerName") %>'></asp:Label>
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
    <div class="rt2">Quyền sửa</div>
    <div class="rt3"><asp:RadioButton ID="rbt1edity" runat="server" GroupName="Edit" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt1editn" runat="server" GroupName="Edit" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Quyền xoá</div>
    <div class="rt3"><asp:RadioButton ID="rbt2dely" runat="server" GroupName="Del" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt2deln" runat="server" GroupName="Del" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Quyền duyệt</div>
    <div class="rt3"><asp:RadioButton ID="rbt3Approy" runat="server" GroupName="Approve" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt3Appron" runat="server" GroupName="Approve" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Quyền Vip</div>
    <div class="rt3"><asp:RadioButton ID="rbt5Vipy" runat="server" GroupName="Vip" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt5Vipn" runat="server" GroupName="Vip" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    <div class="rt1">Nhóm</div>
    <div class="rt2">Quyền Silver</div>
    <div class="rt3"><asp:RadioButton ID="rbt6Silvery" runat="server" GroupName="Silver" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt6Silvern" runat="server" GroupName="Silver" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    
    <div class="rt1">Nhóm</div>
    <div class="rt2">Quyền Gia hạn</div>
    <div class="rt3"><asp:RadioButton ID="rbt7Renewy" runat="server" GroupName="Renew" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt7Renewn" runat="server" GroupName="Renew" Text="Không"/></div>
    <div class="rt5"><hr noshade size="1"></div>
    
    <div class="rt1">Nhóm</div>
    <div class="rt2">Quyền Up Tin</div>
    <div class="rt3"><asp:RadioButton ID="rbt8Upsy" runat="server" GroupName="Ups" Text="Có"/></div>
    <div class="rt4"><asp:RadioButton ID="rbt8Upsn" runat="server" GroupName="Ups" Text="Không"/></div>
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