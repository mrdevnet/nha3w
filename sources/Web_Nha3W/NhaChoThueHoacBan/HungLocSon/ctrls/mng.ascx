<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mng.ascx.cs" Inherits="ctrls_mng" %>
<script type="text/javascript">
    function fndht(a)
        {
            document.getElementById(a).style.visibility = "visible";
            document.getElementById(a).src = "images/prh.png";
        }
</script>
<div class="ph1pts"><img src="images/sp.gif" alt=""/></div>
<asp:UpdatePanel id="sig" runat="server">
<ContentTemplate>
<div class="tdt" runat="server" id="hls1">Đăng tin mới</div>
<div class="indt">
    <span style="font-family:Tahoma;font-size:11px">Trạng thái : </span>
    <asp:DropDownList CssClass="nwf" ID="ddlStaPts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStaPts_SelectedIndexChanged" >
        <asp:ListItem Text="Tất cả" Value="-1"></asp:ListItem>
        <asp:ListItem Text="Đang hiển thị" Value="1"></asp:ListItem>
        <asp:ListItem Text="Đang chờ duyệt" Value="2"></asp:ListItem>
        <asp:ListItem Text="Chưa hợp lệ" Value="3"></asp:ListItem>
        <asp:ListItem Text="Đang soạn" Value="4"></asp:ListItem>
        <asp:ListItem Text="Ngừng đăng" Value="5"></asp:ListItem>
        <asp:ListItem Text="Hết hạn đăng" Value="6"></asp:ListItem>
        <asp:ListItem Text="Tin Vip/Silver" Value="8"></asp:ListItem>
    </asp:DropDownList>&nbsp;
    <span style="font-family:Tahoma;font-size:11px">Tỉnh / Thành phố : </span><asp:DropDownList CssClass="nwf" ID="ddlCities" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCities_SelectedIndexChanged" ></asp:DropDownList>&nbsp;
    <span style="font-family:Tahoma;font-size:11px">Quận / Huyện : </span><asp:DropDownList CssClass="nwf" ID="ddlDistricts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistricts_SelectedIndexChanged" ></asp:DropDownList><br /><br />
    <asp:GridView ID="gCities" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30" DataKeyNames="PostId,StateId" BorderWidth="0px" RowStyle-BorderColor="#EEEEEE" GridLines="Horizontal" OnRowDataBound="gCities_RowDataBound" OnRowCancelingEdit="gCities_RowCancelingEdit" OnRowEditing="gCities_RowEditing" OnRowUpdating="gCities_RowUpdating" OnRowCommand="gCities_RowCommand" OnPageIndexChanging="gCities_PageIndexChanging" CellPadding="2" OnSelectedIndexChanged="gCities_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="Loại">
                <EditItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl1" runat="server" Text='<%# Bind("CateName") %>'></asp:Label>
                    <asp:Label CssClass="gltx" ID="lblPIdE" Font-Bold="true" runat="server" Text='<%# Bind("PostId") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl2" runat="server" Text='<%# Bind("CateName") %>'></asp:Label>
                    <asp:Label CssClass="gltx" ID="lblPId" Font-Bold="true" runat="server" Text='<%# Bind("PostId") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" CssClass="mngpst1" HorizontalAlign="Center" VerticalAlign="Top" Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ti&#234;u đề">
                <EditItemTemplate>
                    <a class="hcnbl" href='<%# "details.aspx?p=" + Eval("PostId") %>'><%# Eval("Title") %></a>
                </EditItemTemplate>
                <ItemTemplate>
                    <a class="hcnbl" href='<%# "details.aspx?p=" + Eval("PostId") %>'><%# Eval("Title") %></a>&nbsp;
                    <a runat="server" visible="false" id="mngpst" style="color:#73AC59" class="hcnbl" href='<%# "~/post.aspx?p=" + Eval("PostId") %>'>(Cập nhật)</a>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle CssClass="mngpst1" Width="30%" Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Top"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Thời hạn">
                <EditItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl3" runat="server" ></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl4" runat="server" ></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle CssClass="mngpst1" Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Top"
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
                <ItemStyle CssClass="mngpst1" Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Top"
                    Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VIP">
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
                <%--<HeaderTemplate ><%# CountVip() %></HeaderTemplate>--%>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle CssClass="mngpst1" Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Top"
                    Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IP">
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
                <ItemStyle CssClass="mngpst1" Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Top"
                    Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trạng th&#225;i">
                <EditItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl7E" runat="server" Text='<%# Eval("StateName")%>'></asp:Label><br />
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
                <ItemStyle CssClass="mngpst1" Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Top"
                    Width="10%" />
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" EditText="Sửa">
                <ItemStyle CssClass="mngpst1" Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" Width="5%" HorizontalAlign="Center"
                    VerticalAlign="Top"/>
            </asp:CommandField>
            <asp:ButtonField Text="Up" CommandName="UpPosts">
                <ItemStyle CssClass="mngpst1" Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" HorizontalAlign="Center"
                    VerticalAlign="Top" Width="5%"/>
            </asp:ButtonField>
            <asp:CommandField ShowSelectButton="True" HeaderText="Cài đặt" ButtonType="Image" ItemStyle-CssClass="igmnp1" SelectImageUrl="../images/sms19.jpeg"/>
        </Columns>
        <PagerStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59"
            HorizontalAlign="Left" VerticalAlign="Middle" />
        <HeaderStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="White" BackColor="#3B5998" />
        <RowStyle BorderColor="#EEEEEE" />
        <SelectedRowStyle BackColor="#eceff5" />
    </asp:GridView>
    <div class="dvstar1" runat="server" id="a11" visible="false">Cài đặt tính năng cho tin đăng - Tài khoản bạn hiện có:&nbsp;&nbsp;<img style="height:10px" src="images/coin4.png" />&nbsp;<span style="color:Yellow"><%= mwl() %> xu</span></div>
    <div class="dvstar4" runat="server" id="a12" visible="false">
        <div id="rdetails" runat="server" class="rdtlspts"></div>
        <div class="dvstar5">
            <asp:RadioButton AutoPostBack="true" runat="server" GroupName="TypeV" ID="rdisp" Text="Kích hoạt(12 xu)" OnCheckedChanged="rdisp_CheckedChanged"/> 
            <asp:RadioButton AutoPostBack="true" runat="server" GroupName="TypeV" ID="rtop" Text="Up Top(6 xu)" OnCheckedChanged="rtop_CheckedChanged"/> 
            <asp:RadioButton AutoPostBack="true" runat="server" GroupName="TypeV" ID="rvip" Text="Up VIP(4 xu/ngày)" OnCheckedChanged="rvip_CheckedChanged"/> 
            <asp:RadioButton AutoPostBack="true" runat="server" GroupName="TypeV" ID="rip" Text="Up IP(3 xu/ngày)" OnCheckedChanged="rip_CheckedChanged"/> 
            <asp:RadioButton AutoPostBack="true" runat="server" GroupName="TypeV" ID="rnew" Text="Gia hạn(18 xu/tháng)" OnCheckedChanged="rnew_CheckedChanged"/>
        </div>
        <div class="dvstar61" id="a13" runat="server" visible="false">
            Hiệu lực : <input style="width: 63px;" class="fat" id="rtime" type="text" runat="server" />&nbsp;
            <asp:DropDownList CssClass="nwf" id="ddlrtype" runat="server">
                <asp:ListItem Text="Ngày" Value="1"></asp:ListItem>
                <asp:ListItem Text="Tuần" Value="2"></asp:ListItem>
                <asp:ListItem Text="Tháng" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="dvstar6" runat="server" id="a14" visible="false">
            <asp:Button ID="rsubmit" CssClass="artcbt" runat="server" Text="Thực hiện" OnClick="rsubmit_Click" />
            &nbsp;<img id="sgnpg" class="sli"/>
        </div>
        <div id="rdtl2" runat="server" class="rdtlspts3" visible="false"></div>
    </div>
    <asp:GridView ID="g3" Width="100%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30" DataKeyNames="PostId" BorderWidth="0px" RowStyle-BorderColor="#EEEEEE" GridLines="Horizontal" OnRowDataBound="g3_RowDataBound" OnRowDeleting="g3_RowDeleting">
    <Columns>
            <asp:TemplateField HeaderText="Loại">
                <ItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl2" runat="server" Text='<%# Bind("CateName") %>'></asp:Label>
                    <asp:Label CssClass="gltx" ID="lblPId" Font-Bold="true" runat="server" Text='<%# Bind("PostId") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle CssClass="mngpst1" Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center" VerticalAlign="Top" Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ti&#234;u đề">
                <ItemTemplate>
                    <a class="hcnbl" href='<%# "details.aspx?p=" + Eval("PostId") %>'><%# Eval("Title") %></a>
                    <asp:Label CssClass="gltx" ID="area" runat="server" Text='<%# ", <b>"+ Eval("Area") + "</b> m2, " %>'></asp:Label>
                    <asp:Label CssClass="gltx" ID="Label1" runat="server" Text='<%# Eval("Value").ToString().Trim() =="0" ? "<b>Thoả thuận</b>" : "<b>"+ System.String.Format("{0:0,0.##}", float.Parse(Eval("Value").ToString()))+"</b>"%>'></asp:Label>
                    <asp:Label CssClass="gltx" ID="Label2" runat="server" Text='<%# " "+ Eval("CurrencyName").ToString().Trim() %>'></asp:Label>
                    <asp:Label CssClass="gltx" ID="Label5" runat="server" Text='<%# "/"+ Eval("UnitName") %>'></asp:Label>
                    <asp:Label CssClass="gltx" ID="Label3" runat="server" Text='<%# ", <b>"+ Eval("CityName") +"</b>" %>'></asp:Label>
                    <asp:Label CssClass="gltx" ID="Label4" runat="server" Text='<%# ", "+ Eval("DistrictName") %>'></asp:Label>
                    <%--<a runat="server" visible="false" id="mngpst" style="color:#73AC59" class="hcnbl" href='<%# "~/post.aspx?p=" + Eval("PostId") %>'>(Cập nhật)</a>--%>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle CssClass="mngpst1" Width="35%" Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Top"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Thời hạn">
                <ItemTemplate>
                    <asp:Label CssClass="gltx" ID="lbl4" runat="server" ></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle CssClass="mngpst1" Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Top"
                    Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cập nhật">
                <ItemTemplate>
                    <asp:Label ID="lbl6" CssClass="gltx" runat="server" ></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle CssClass="mngpst1" Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Top"
                    Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bởi">
                <ItemTemplate>
                    <a class="hcnbl" href='<%# "default.aspx?m=" + Eval("MemberId") %>'><%# Eval("UserName")%></a>&nbsp;
                    <%--<a runat="server" visible="false" id="mngpst" style="color:#73AC59" class="hcnbl" href='<%# "~/post.aspx?p=" + Eval("PostId") %>'>(Cập nhật)</a>--%>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle CssClass="mngpst1" Width="10%" Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Top"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Lưu">
                <ItemTemplate>
                    <asp:Label CssClass="gltx" ID="saved" runat="server" Text='<%# HungLocSon.Tools.WebTools.FormatDateTime(DateTime.Parse(Eval("Saved").ToString())) %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle CssClass="mngpst1" Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center" VerticalAlign="Top" Width="7%" />
            </asp:TemplateField>
        <asp:CommandField ShowDeleteButton="True" DeleteText="Xoá">
            <ItemStyle CssClass="mngpst1" Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" Width="5%" HorizontalAlign="Center"
                    VerticalAlign="Top"/>
        </asp:CommandField>
        </Columns>
        <PagerStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59"
            HorizontalAlign="Left" VerticalAlign="Middle" />
        <HeaderStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="White" BackColor="#3B5998" />
        <RowStyle BorderColor="#EEEEEE" />
    </asp:GridView>
</div>
</ContentTemplate>
    <Triggers>
        <%--<asp:AsyncPostBackTrigger ControlID="submit" EventName="Click" />--%>
        <%--<asp:AsyncPostBackTrigger ControlID="ddlCities" EventName="SelectedIndexChanged" />--%>
        <asp:AsyncPostBackTrigger ControlID="ddlStaPts" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowEditing" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowUpdating" />
    </Triggers>
</asp:UpdatePanel>