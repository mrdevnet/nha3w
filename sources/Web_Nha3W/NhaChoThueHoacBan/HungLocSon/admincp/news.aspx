<%@ Page Language="C#" MasterPageFile="~/admincp/HLSNwAdmins.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="admincp_news"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainCPH" Runat="Server">
<script src="../Java/InsertNumber.js" type="text/javascript"></script>
<asp:UpdatePanel id="UpdatePanel1" runat="server">
<ContentTemplate>
    <div style="width:780px; padding:10px; text-align:center;">
    <div style="width:100%; text-align:center;">
        <table style="margin:0px auto 0px auto;border: #3b5889 1px solid;">
            <tr>
                <td class="tdTDTT">Nhóm Tin Cha :</td>
                <td class="tdTXT">
                    <asp:DropDownList id="cbNTC" Width="155px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbNTC_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cbNTC" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td class="tdTDTT">Nhóm Tin :</td>
                <td class="tdTXT">
                    <asp:TextBox ID="txtNT1" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNT1" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="tdTDTT">Vị Trí :</td>
                <td class="tdTXT">
                    <input id="txtVT" runat="server" style="width:150px;" onkeypress="return numbersonly(this, event)" size="20"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVT" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td class="tdTDTT">Nổi Bật :</td>
                <td class="tdTXT">
                    <asp:CheckBox ID="ckbNB" runat="server" Text="Cho phép" />
                    <asp:Button ID="btCNTT" runat="server" BackColor="#67A54B" BorderColor="Black" BorderWidth="1px" Font-Bold="True" ForeColor="White" Text="Submit" Width="91px" OnClick="btCNTT_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="4" ></td>
            </tr>
        </table>
    </div>
        <div style="width:100%; padding-top:10px;">
            <asp:GridView ID="griNT" runat="server" CellPadding="3" Width="100%" BorderColor="Black" BorderWidth="1px" DataKeyNames="CatalogId,SubId" EmptyDataText="Không có dữ liệu" OnRowCommand="griNT_RowCommand" AutoGenerateColumns="False" OnRowEditing="griNT_RowEditing" OnRowCancelingEdit="griNT_RowCancelingEdit" OnRowDataBound="griNT_RowDataBound" OnRowUpdating="griNT_RowUpdating">
                <RowStyle BorderColor="#000" BorderWidth="1px"  />
                <Columns>
                <asp:TemplateField HeaderText="Nh&#243;m Tin">
                <EditItemTemplate>
                    <asp:TextBox ID="txtNT2" runat="server" Width="120px" Text='<%# Eval("Name") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNT2" ErrorMessage="*"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <a href="<%# ResolveUrl( Eval("CatalogId","~/Admincp/News/Default.aspx?idn=adrn&or=pstnws&id={0}").ToString()) %>"><%#Eval("Name")%></a>
                </ItemTemplate>
                <ItemStyle Width="250px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nh&#243;m Tin Cha">
                <EditItemTemplate>
                    <asp:DropDownList id="cbNTCa" Width="120px" runat="server"></asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <span>  <%# (Eval("SubId").ToString() == "0") ? "Không Có" : Eval("Sub").ToString() %></span>
                </ItemTemplate>
                <ItemStyle Width="150px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Thứ Tự">
                <EditItemTemplate>
                    <input id="Text1" runat="server" style="width:50px;" value='<%# Eval("OrderBy") %>'  onkeypress="return numbersonly(this, event)" size="20"/>
                </EditItemTemplate>
                <ItemTemplate>
                    <span><%# Eval("OrderBy") %></span>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nổi Bật">
                    <EditItemTemplate>
                        <asp:CheckBox ID="cbNBe"  Checked='<%# Eval("TopDefault") %>' runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbNB" Enabled="False"  runat="server" Checked='<%# Eval("TopDefault") %>'  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" HeaderText="Edit" CausesValidation="False">
                    <ItemStyle Width="100px" />
                </asp:CommandField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Del" OnClientClick="return confirm('Bạn có muốn xóa không ?')" CausesValidation="False" CommandArgument='<%# Eval("CatalogId") %>'>Delete</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="70px" />
                </asp:TemplateField>
                </Columns>
               <HeaderStyle BackColor="#E2F0FF" />
           </asp:GridView>&nbsp;
        </div>
    </div>
</ContentTemplate>
    <Triggers>
        <%--<asp:AsyncPostBackTrigger ControlID="LinkButton1" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btCNTT" EventName="Click" />--%>
        <%--<asp:AsyncPostBackTrigger ControlID="ddlCities" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlDistricts" EventName="SelectedIndexChanged" />--%>
        <asp:AsyncPostBackTrigger ControlID="griNT" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="griNT" EventName="RowEditing" />
        <asp:AsyncPostBackTrigger ControlID="griNT" EventName="RowUpdating" />
    </Triggers>
</asp:UpdatePanel>
</asp:Content>

