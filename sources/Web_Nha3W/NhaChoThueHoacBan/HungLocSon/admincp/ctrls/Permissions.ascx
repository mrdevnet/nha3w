<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Permissions.ascx.cs" Inherits="admincp_ctrls_Permissions" %>
<div class="ph1"><img src="~/images/bgl.png" alt=""/></div>
<div class="ph3">Phân quyền nhóm</div>
<asp:UpdatePanel id="sig" runat="server">
<ContentTemplate>
<div class="ph4">
    Thành viên : <input id="txtUserName" class="lsp" type="text" runat="server"/> <asp:Button CssClass="lsp2" ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
    <br /><br />
    <asp:GridView ID="gCities" Width="99%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="10" DataKeyNames="MemberId,GroupId" BorderColor="#B3C5D8" BorderStyle="Solid" BorderWidth="1px" OnRowCancelingEdit="gCities_RowCancelingEdit" OnRowEditing="gCities_RowEditing" OnRowUpdating="gCities_RowUpdating" OnRowDataBound="gCities_RowDataBound" OnSelectedIndexChanged="gCities_SelectedIndexChanged" OnPageIndexChanging="gCities_PageIndexChanging">
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
                    VerticalAlign="Middle" Width="5%" />
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
                    <asp:Label ID="lbl8" runat="server" Text='<%# AnnounceTime(DateTime.Parse(Eval("DateCreation").ToString())) %>'></asp:Label><br />
                    <asp:Label ID="lblripe" runat="server" Text='<%# Bind("RegIP") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl9" runat="server" Text='<%# AnnounceTime(DateTime.Parse(Eval("DateCreation").ToString()))%>'></asp:Label><br />
                    <asp:Label ID="lblrip" runat="server" Text='<%# Bind("RegIP") %>'></asp:Label>
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
                <%--<EditItemTemplate>
                    <asp:Label ID="lbllige" runat="server" Text='<%#AnnounceTime(DateTime.Parse(Eval("LastIn").ToString())) %>'></asp:Label><br />
                    <asp:Label ID="lbllipe" runat="server" Text='<%# Bind("LastIP") %>'></asp:Label><br />
                    <asp:Label ID="lbl10" runat="server" Text='<%#AnnounceTime(DateTime.Parse(Eval("LastLogin").ToString())) %>'></asp:Label><br />
                    <asp:Label ID="lblnagoe" runat="server" Text='<%# HungLocSon.UHLS.EncryptM.NetOn(int.Parse(Eval("nt").ToString())) %>'></asp:Label>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="lbllig" runat="server" Text='<%# (Eval("LastIn") != null && Eval("LastIn").ToString() != "") ? AnnounceTime(DateTime.Parse(Eval("LastIn").ToString())) : "" %>'></asp:Label><br />
                    <asp:Label ID="lbllip" runat="server" Text='<%# Bind("LastIP") %>'></asp:Label><br />
                    <asp:Label ID="lbl11" runat="server" Text='<%# AnnounceTime(DateTime.Parse(Eval("LastLogin").ToString())) %>'></asp:Label><br />
                    <asp:Label ID="lblnago" runat="server" Text='<%# (Eval("nt") != null && Eval("nt").ToString() != "") ? HungLocSon.UHLS.EncryptM.NetOn(int.Parse(Eval("nt").ToString())) : "" %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="15%" />
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" >
                <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" Width="5%" HorizontalAlign="Center"
                    VerticalAlign="Middle"/>
            </asp:CommandField>
            <asp:CommandField ShowSelectButton="True" >
                <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" Width="5%" HorizontalAlign="Center"
                    VerticalAlign="Middle"/>
            </asp:CommandField>
        </Columns>
        <PagerStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59"
            HorizontalAlign="Left" VerticalAlign="Middle" />
        <HeaderStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="RoyalBlue" />
        <SelectedRowStyle BackColor="#eceff5" />
    </asp:GridView><br /><br />
    <asp:DropDownList CssClass="nwf" ID="ddlModers" runat="server" DataTextField="ModerName" DataValueField="ModerId"></asp:DropDownList>&nbsp;
    <asp:Button CssClass="lsp2" ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
    <asp:GridView ID="gCities2" Width="98%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30" DataKeyNames="ModerId" OnRowDeleting="gCities2_RowDeleting" >
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
            <asp:CommandField ShowDeleteButton="True" >
            <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="5%" />
            </asp:CommandField>
        </Columns>
        <PagerStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59"
            HorizontalAlign="Left" VerticalAlign="Middle" />
        <HeaderStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="RoyalBlue" />
        <SelectedRowStyle BackColor="#ECEFF5" />
    </asp:GridView>
</div>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="submit" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowEditing" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowUpdating" />
    </Triggers>
</asp:UpdatePanel>