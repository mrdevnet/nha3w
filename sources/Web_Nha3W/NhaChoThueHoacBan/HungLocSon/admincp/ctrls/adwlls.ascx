<%@ Control Language="C#" AutoEventWireup="true" CodeFile="adwlls.ascx.cs" Inherits="admincp_ctrls_adwlls" %>
<div class="ph1"><img src="~/images/bgl.png" alt=""/></div>
<div class="ph3">Phân quyền Admins</div>
<asp:UpdatePanel id="sig" runat="server">
<ContentTemplate>
<div class="ph4">
    Thành viên : 
    <input id="txtUserName" class="lsp" type="text" runat="server"/> 
    <asp:Button CssClass="lsp2" ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
    <br /><br />
    <asp:GridView ID="gCities" Width="99%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="10" DataKeyNames="WalletId,UserName" BorderColor="#B3C5D8" BorderStyle="Solid" BorderWidth="1px" OnSelectedIndexChanged="gCities_SelectedIndexChanged" OnPageIndexChanging="gCities_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Th&#224;nh vi&#234;n">
                <ItemTemplate>
                    <asp:Label ID="lbl2" runat="server" Text='<%# Bind("WalletId") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="UserName / FullName">
                <ItemTemplate>
                    <asp:Label ID="lbl4" runat="server" Text='<%# Eval("UserName")  + " / " + Eval("FullName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="txttotal" runat="server" Text='<%# Bind("Total") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="lbl7" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="center" VerticalAlign="Middle" Width="12%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cập nhật">
                <ItemTemplate>
                    <asp:Label ID="lbl9" runat="server" Text='<%# AnnounceTime(DateTime.Parse(Eval("Updated").ToString()))%>'></asp:Label>
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
                <ItemStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59" Width="5%" HorizontalAlign="Center"
                    VerticalAlign="Middle"/>
            </asp:CommandField>
        </Columns>
        <PagerStyle Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="#73AC59"
            HorizontalAlign="Left" VerticalAlign="Middle" />
        <HeaderStyle Font-Names="Tahoma" Font-Size="11px" ForeColor="RoyalBlue" />
        <SelectedRowStyle BackColor="#eceff5" />
    </asp:GridView><br /><br />
    Nạp xu : 
    <input id="txtWallet" class="lsp" type="text" runat="server" visible="false"/> 
    <asp:Button CssClass="lsp2" ID="Cost" runat="server" Text="Submit" OnClick="Cost_Click" visible="false"/>
    <br /><br />
</div>
</ContentTemplate>
    <Triggers>
        <%--<asp:AsyncPostBackTrigger ControlID="submit" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowEditing" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowUpdating" />--%>
    </Triggers>
</asp:UpdatePanel>