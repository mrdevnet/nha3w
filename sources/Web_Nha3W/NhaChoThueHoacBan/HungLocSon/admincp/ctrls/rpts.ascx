<%@ Control Language="C#" AutoEventWireup="true" CodeFile="rpts.ascx.cs" Inherits="admincp_ctrls_rpts" %>
<div class="ph1"><img src="~/images/bgl.png" alt=""/></div>
<div class="ph3">Thông báo</div>
<asp:UpdatePanel id="sig" runat="server">
<ContentTemplate>
<div class="ph4">
    Tiêu đề : <input id="txtTitle" class="lsp" type="text" runat="server"/> &nbsp;
    Url :<input id="txtUrl" class="lsp" type="text" runat="server"/> 
    <br /><br />
    Hiển thị :
    <asp:RadioButton ID="rdShow" runat="server" GroupName="IsShow" Text="Hiển thị" Checked="true"/>&nbsp;
    <asp:RadioButton ID="rdShown" runat="server" GroupName="IsShow" Text="Không hiển thị"/>
    <br /><br /><asp:Button CssClass="lsp2" ID="submit" runat="server" Text="Submit" OnClick="submit_Click"/>
    <br /><br />
    <asp:GridView ID="gReports" Width="99%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30" DataKeyNames="RptId" BorderColor="#B3C5D8" BorderStyle="Solid" BorderWidth="1px" OnPageIndexChanging="gReports_PageIndexChanging" OnRowCancelingEdit="gReports_RowCancelingEdit" OnRowEditing="gReports_RowEditing" OnRowUpdating="gReports_RowUpdating">
        <Columns>
            <asp:TemplateField HeaderText="Thông báo">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("RptId") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("RptId") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tiêu đề">
                <EditItemTemplate>
                    <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox> 
                    (<b> <asp:Label ID="user" runat="server" Text='<%# Bind("UserName") %>'></asp:Label> </b>)
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Title") %>'></asp:Label> 
                    (<b> <asp:Label ID="user" runat="server" Text='<%# Bind("UserName") %>'></asp:Label> </b>)
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="30%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Url">
                <EditItemTemplate>
                    <asp:TextBox ID="txtUrl" runat="server" Text='<%# Bind("Url") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <a target="_blank" href='<%# Eval("Url") %>'><%# Eval("Title") %></a>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="30%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hiển thị">
                <EditItemTemplate>
                    <asp:CheckBox ID="show" runat="server" Checked='<%# Bind("IsShow") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="show" runat="server" Checked='<%# Bind("IsShow") %>' Enabled="false"/>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ngày">
                <EditItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Updated") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Updated") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Xem">
                <EditItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="5%" />
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" >
                <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" Width="5%" HorizontalAlign="Center"
                    VerticalAlign="Middle"/>
            </asp:CommandField>
            <%--<asp:CommandField ShowDeleteButton="True">
                <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="5%" />
            </asp:CommandField>--%>
        </Columns>
        <PagerStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59"
            HorizontalAlign="Left" VerticalAlign="Middle" />
        <HeaderStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="RoyalBlue" />
    </asp:GridView>
</div>
</ContentTemplate>
    <%--<Triggers>
        <asp:AsyncPostBackTrigger ControlID="submit" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowEditing" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowUpdating" />
    </Triggers>--%>
</asp:UpdatePanel>