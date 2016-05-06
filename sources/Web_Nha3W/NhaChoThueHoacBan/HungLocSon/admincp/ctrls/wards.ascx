<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wards.ascx.cs" Inherits="admincp_ctrls_wards" %>
<div class="ph1"><img src="~/images/bgl.png" alt=""/></div>
<div class="ph3">Phường Xã</div>
<asp:UpdatePanel id="sig" runat="server">
<ContentTemplate>
<div class="ph4">
    Tỉnh / Thành phố : <asp:DropDownList CssClass="nwf" ID="ddlCities" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCities_SelectedIndexChanged" ></asp:DropDownList>&nbsp;
    Quận / Huyện : <asp:DropDownList CssClass="nwf" ID="ddlDistricts" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistricts_SelectedIndexChanged" ></asp:DropDownList>
    <br /><br />
    Phường Xã : <input id="txtWardName" class="lsp" type="text" runat="server"/> <asp:Button CssClass="lsp2" ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
    <br /><br />
    <asp:GridView ID="gCities" Width="99%" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30" DataKeyNames="WardId,DistrictId,CityId" BorderColor="#B3C5D8" BorderStyle="Solid" BorderWidth="1px" OnRowDeleting="gCities_RowDeleting" OnRowCancelingEdit="gCities_RowCancelingEdit" OnRowDataBound="gCities_RowDataBound" OnRowEditing="gCities_RowEditing" OnRowUpdating="gCities_RowUpdating" OnPageIndexChanging="gCities_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Phường xã">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("WardId") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("WardId") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" Height="25px" HorizontalAlign="Center"
                    VerticalAlign="Middle" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tên Phường xã">
                <EditItemTemplate>
                    <asp:TextBox ID="txtWardName2" runat="server" Text='<%# Bind("WardName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("WardName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quận Huyện">
                <EditItemTemplate>
                    <asp:DropDownList CssClass="nwf" ID="ddlDistricts2" runat="server" DataTextField="DistrictName" DataValueField="DistrictId"></asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("DistrictName")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Height="25px" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Left" VerticalAlign="Middle"
                    Width="20%" />
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
        <asp:AsyncPostBackTrigger ControlID="ddlCities" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlDistricts" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowEditing" />
        <asp:AsyncPostBackTrigger ControlID="gCities" EventName="RowUpdating" />
    </Triggers>
</asp:UpdatePanel>