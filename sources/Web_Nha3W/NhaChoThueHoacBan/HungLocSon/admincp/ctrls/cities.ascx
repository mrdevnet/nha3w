<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cities.ascx.cs" Inherits="admincp_ctrls_cities" %>
<div class="ph1"><img src="~/images/bgl.png" alt=""/></div>
<div class="ph3">Tỉnh / Thành phố</div>
<asp:UpdatePanel id="sig" runat="server">
<ContentTemplate>
<div class="ph4">
    Tỉnh / Thành phố : <input id="city" class="lsp" type="text" runat="server"/> <asp:Button CssClass="lsp2" ID="submit" runat="server" Text="Submit" OnClick="submit_Click"/>
    <br /><br />
    <asp:GridView ID="gCities" Width="99%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30" DataKeyNames="CityId" BorderColor="#B3C5D8" BorderStyle="Solid" BorderWidth="1px" OnRowCancelingEdit="gCities_RowCancelingEdit" OnRowDeleting="gCities_RowDeleting" OnRowEditing="gCities_RowEditing" OnRowUpdating="gCities_RowUpdating" OnPageIndexChanging="gCities_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Th&#224;nh phố">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CityId") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CityId") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="T&#234;n Th&#224;nh phố">
                <EditItemTemplate>
                    <asp:TextBox ID="txtCity" runat="server" Text='<%# Bind("CityName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("CityName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="30%" />
            </asp:TemplateField>
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