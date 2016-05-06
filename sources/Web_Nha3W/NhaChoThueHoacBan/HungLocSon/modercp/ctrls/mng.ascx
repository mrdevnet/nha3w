<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mng.ascx.cs" Inherits="modercp_ctrls_mng" %>
<div class="ph1"><img src="~/images/bgl.png" alt=""/></div>
<div class="ph3">Quản lý tin đăng</div>
<asp:UpdatePanel id="sig" runat="server">
<ContentTemplate>
<div class="ph4">
    Trạng thái : 
    <asp:DropDownList CssClass="nwf" ID="ddlStaPts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStaPts_SelectedIndexChanged" >
        <asp:ListItem Text="Tất cả" Value="-1"></asp:ListItem>
        <asp:ListItem Text="Đang hiển thị" Value="1"></asp:ListItem>
        <asp:ListItem Text="Đang chờ duyệt" Value="2"></asp:ListItem>
        <asp:ListItem Text="Chưa hợp lệ" Value="3"></asp:ListItem>
        <asp:ListItem Text="Đang soạn" Value="4"></asp:ListItem>
        <asp:ListItem Text="Ngừng đăng" Value="5"></asp:ListItem>
        <asp:ListItem Text="Hết hạn đăng" Value="6"></asp:ListItem>
        <asp:ListItem Text="Đã xoá" Value="7"></asp:ListItem>
        <asp:ListItem Text="Tin Vip/Silver" Value="8"></asp:ListItem>
    </asp:DropDownList>&nbsp;
    Tỉnh / Thành phố : <asp:DropDownList CssClass="nwf" ID="ddlCities" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCities_SelectedIndexChanged" ></asp:DropDownList>&nbsp;
    Quận / Huyện : <asp:DropDownList CssClass="nwf" ID="ddlDistricts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistricts_SelectedIndexChanged" ></asp:DropDownList>
    Thành viên : <input id="txtUserName" class="lsp" type="text" runat="server"/> <asp:Button CssClass="lsp2" ID="submit" runat="server" Text="Submit" OnClick="submit_Click"/>
    <br /><br />
    <asp:GridView ID="grvMngs" Width="99%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="12" DataKeyNames="MemberId,GroupId" BorderColor="#B3C5D8" BorderStyle="Solid" BorderWidth="1px" OnSelectedIndexChanged="grvMngs_SelectedIndexChanged" OnPageIndexChanging="grvMngs_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Th&#224;nh vi&#234;n">
                <EditItemTemplate>
                    <asp:Label ID="lbl1" runat="server" Text='<%# Bind("MemberId") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl2" runat="server" Text='<%# Bind("MemberId") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="6%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="UserName / FullName">
                <EditItemTemplate>
                    <asp:Label ID="lbl3" runat="server" Text='<%# Bind("UserFull") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl4" runat="server" Text='<%# Bind("UserFull") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <EditItemTemplate>
                    <asp:Label ID="lbl5" runat="server" Text='<%# HungLocSon.UHLS.EncryptM.ToOutput(Eval("Email").ToString()) %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl6" runat="server" Text='<%# HungLocSon.UHLS.EncryptM.ToOutput(Eval("Email").ToString()) %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nh&#243;m">
                <EditItemTemplate>
                    <asp:DropDownList CssClass="nwf" ID="ddlGroup" runat="server" DataTextField="GroupName" DataValueField="GroupId"></asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl7" runat="server" Text='<%# Bind("GroupName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="12%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ng&#224;y tạo">
                <EditItemTemplate>
                    <asp:Label ID="lbl8" runat="server" Text='<%# AnnounceTime(DateTime.Parse(Eval("DateCreation").ToString())) %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl9" runat="server" Text='<%# AnnounceTime(DateTime.Parse(Eval("DateCreation").ToString()))%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active">
                <EditItemTemplate>
                    <asp:CheckBox ID="ckbActiveE" runat="server" Checked='<%# Eval("IsActivated") %>'/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="ckbActive" Enabled="false" runat="server" Checked='<%# Eval("IsActivated") %>'/>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="center" VerticalAlign="Middle"
                    Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Login">
                <EditItemTemplate>
                    <asp:CheckBox ID="ckbLoginE" runat="server" Checked='<%# Eval("EnableLogin") %>'/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="ckbLogin" Enabled="false" runat="server" Checked='<%# Eval("EnableLogin") %>'/>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="center" VerticalAlign="Middle"
                    Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Block">
                <EditItemTemplate>
                    <asp:CheckBox ID="ckbBlockE" runat="server" Checked='<%# Eval("IsBlocked") %>'/>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="ckbBlock" Enabled="false" runat="server" Checked='<%# Eval("IsBlocked") %>'/>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="center" VerticalAlign="Middle"
                    Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Login">
                <EditItemTemplate>
                    <asp:Label ID="lbl10" runat="server" Text='<%#AnnounceTime(DateTime.Parse(Eval("LastLogin").ToString())) %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl11" runat="server" Text='<%# AnnounceTime(DateTime.Parse(Eval("LastLogin").ToString())) %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="15%" />
            </asp:TemplateField>
            <%--<asp:CommandField ShowEditButton="True" >
                <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" Width="5%" HorizontalAlign="Center"
                    VerticalAlign="Middle"/>
            </asp:CommandField>--%>
            <asp:CommandField ShowSelectButton="True" >
                <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" Width="4%" HorizontalAlign="Center"
                    VerticalAlign="Middle" />
            </asp:CommandField>
        </Columns>
        <PagerStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59"
            HorizontalAlign="Left" VerticalAlign="Middle" />
        <HeaderStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="RoyalBlue" />
        <SelectedRowStyle BackColor="#eceff5" />
    </asp:GridView><br /><br />
    <asp:GridView ID="gCities" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30" DataKeyNames="PostId,StateId" BorderColor="#B3C5D8" BorderStyle="Solid" BorderWidth="1px" OnRowDataBound="gCities_RowDataBound" OnRowCancelingEdit="gCities_RowCancelingEdit" OnRowDeleting="gCities_RowDeleting" OnRowEditing="gCities_RowEditing" OnRowUpdating="gCities_RowUpdating" OnRowCommand="gCities_RowCommand" OnPageIndexChanging="gCities_PageIndexChanging" >
        <Columns>
            <asp:TemplateField HeaderText="Loại">
                <EditItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl1" runat="server" Text='<%# Bind("CateName") %>'></asp:Label><br />
                    <asp:Label CssClass="gltx" ID="lblPIdE" Font-Bold="true" runat="server" Text='<%# Bind("PostId") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl2" runat="server" Text='<%# Bind("CateName") %>'></asp:Label><br />
                    <asp:Label CssClass="gltx" ID="lblPIdE" Font-Bold="true" runat="server" Text='<%# Bind("PostId") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ti&#234;u đề">
                <EditItemTemplate>
                    <a class="hcnbl" target="_blank" href='<%# "../details.aspx?p=" + Eval("PostId") %>'><%# Eval("Title") %></a>
                </EditItemTemplate>
                <ItemTemplate>
                    <a class="hcnbl" target="_blank" href='<%# "../details.aspx?p=" + Eval("PostId") %>'><%# Eval("Title") %></a>&nbsp;
                    <a runat="server" target="_blank" visible="false" id="modpst" style="color:#73AC59" class="hcnbl" href='<%# "~/post.aspx?p=" + Eval("PostId") %>'>(Cập nhật)</a>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle CssClass="gltx2" Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle" Width="25%"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Thời hạn">
                <EditItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl3" runat="server" ></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl4" runat="server" ></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cập nhật">
                <EditItemTemplate>
                    <asp:Label ID="lbl5" CssClass="gltx" runat="server" ></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl6" CssClass="gltx" runat="server" ></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField >
                <EditItemTemplate>
                    <asp:CheckBox ID="ckbVipE" runat="server" Checked='<%# Eval("IsVip") %>'/> 
                    <asp:DropDownList CssClass="nwf" ID="ddlMonV" runat="server">
                        <asp:ListItem Text="Tháng" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                    </asp:DropDownList><br />
                    <asp:Label CssClass="gltx" ID="lblExpVipE" runat="server" ></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="ckbVip" Enabled="false" runat="server" Checked='<%# Eval("IsVip") %>'/><br />
                    <asp:Label CssClass="gltx" ID="lblExpVip" runat="server" ></asp:Label>
                </ItemTemplate>
                <HeaderTemplate ><%# CountVip() %></HeaderTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle"
                    Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Silver">
                <EditItemTemplate>
                    <asp:CheckBox ID="ckbSilverE" runat="server" Checked='<%# Eval("Silver") %>'/> 
                    <asp:DropDownList CssClass="nwf" ID="ddlMonS" runat="server">
                        <asp:ListItem Text="Tháng" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                    </asp:DropDownList><br />
                    <asp:Label CssClass="gltx" ID="lblExpSilE" runat="server" ></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="ckbSilver" Enabled="false" runat="server" Checked='<%# Eval("Silver") %>'/>
                    <br /><asp:Label CssClass="gltx" ID="lblExpSil" runat="server" ></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle"
                    Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trạng th&#225;i">
                <EditItemTemplate>
                    <asp:DropDownList CssClass="nwf" ID="ddlState" runat="server">
                        <%--<asp:ListItem Text="Hiển thị" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Đang soạn" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Gia hạn" Value="8"></asp:ListItem>
                        <asp:ListItem Text="Ngừng đăng" Value="5"></asp:ListItem>--%>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl7" runat="server" Text='<%# Eval("StateName")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Đăng bởi">
                <EditItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl8" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl9" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Duyệt bởi">
                <EditItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl10" runat="server" Text='<%# Bind("ByUser") %>'></asp:Label>
                    <br /><asp:Label CssClass="gltx" ID="lblApproE" runat="server" ></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl11" runat="server" Text='<%# Bind("ByUser") %>'></asp:Label>
                    <br /><asp:Label CssClass="gltx" ID="lblAppro" runat="server" ></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" EditText="Sửa">
                <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" Width="5%" HorizontalAlign="Center"
                    VerticalAlign="Middle"/>
            </asp:CommandField>
            <asp:ButtonField Text="Up" CommandName="UpPosts">
                <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="5%" />
            </asp:ButtonField>
            <asp:CommandField ShowDeleteButton="True">
            <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="5%" />
            </asp:CommandField>
        </Columns>
        <PagerStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59"
            HorizontalAlign="Left" VerticalAlign="Middle" />
        <HeaderStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="White" BackColor="#3B5998" />
    </asp:GridView>
</div>
</ContentTemplate>
    <Triggers>
        <%--<asp:AsyncPostBackTrigger ControlID="submit" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowEditing" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowUpdating" />--%>
    </Triggers>
</asp:UpdatePanel>