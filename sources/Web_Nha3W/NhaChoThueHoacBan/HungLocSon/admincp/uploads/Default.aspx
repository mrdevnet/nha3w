<%@ Page Language="C#" MasterPageFile="~/admincp/HLSNwAdmins.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admincp_uploads_Default"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainCPH" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px; width: 98%; padding-top: 10px; text-align: center">
    <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; width: 770px; padding-top: 5px; text-align: center">
        <div style="width: 100%; text-align: left">
            <asp:LinkButton id="lbNew" onclick="lbNew_Click" runat="server" CausesValidation="False" Font-Bold="true">Upload new file [+]</asp:LinkButton>
            <asp:Label id="lbID" runat="server" Visible="False"></asp:Label>
        </div>
        <table style="border-right: #3b5889 1px solid; border-top: #3b5889 1px solid; MARGIN: 0px auto; border-left: #3b5889 1px solid; width: 100%; border-bottom: #3b5889 1px solid" id="Show" runat="server" visible="false">
            <tbody>
            <tr>
                    <td style="width: 30%" align=left>Tiêu đề </td>
                    <td align=left>Thông Tin File</td>
                    <td style="width: 30%" align="left">Nhóm</td>
            </tr>
            <tr>
                    <td style="width: 30%" align="left">
                        <asp:TextBox id="txtT" runat="server" width="195px"></asp:TextBox>
                    <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtT"></asp:RequiredFieldValidator>
                </td>
                <td valign="top" align="left" rowspan="5">
                        <asp:TextBox id="txtD" runat="server" width="265px" textMode="MultiLine" Height="93px"></asp:TextBox>
                </td>
                    <td style="width: 30%" align="left">
                    <asp:DropDownList id="cbC" runat="server" width="192px" DataValueField="CatalogId" DatatextField="Name"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                    <td style="width: 30%" align="left">File URL</td>
                    <td style="width: 30%" align="left">Hiển Thị</td>
                </tr>
            <tr>
                    <td style="width: 30%" align="left">
                        <asp:TextBox id="txtUrl" runat="server" width="195px"></asp:TextBox>
                </td>
                    <td style="width: 30%" align="left">
                    <asp:CheckBox id="ckbV" runat="server" text="Đồng ý"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                    <td style="width: 30%" align="left">Upload File <span style="COLOR: #ff0000">(&lt; 10MB)</span></td>
                <td style="width: 30%" align="left"></td>
            </tr>
            <tr>
                    <td style="width: 30%" align="left">
                    <asp:FileUpload id="ful" runat="server" width="195px"></asp:FileUpload>
                </td>
                    <td style="width: 30%" align="left">&nbsp; 
                        <asp:Button id="btok" onclick="btok_Click" runat="server" Font-Bold="true" width="91px" text="Submit" ForeColor="White" borderwidth="1px" borderColor="Black" BackColor="#67A54B"></asp:Button> &nbsp; <asp:Button id="btC" onclick="btC_Click" runat="server" CausesValidation="False" Font-Bold="true" width="91px" text="Cancel" ForeColor="White" borderwidth="1px" borderColor="Black" BackColor="#67A54B"></asp:Button>
                </td>
                </tr>
            </tbody>
            </table>
        </div>
    <div style="width: 100%; padding-top: 10px; text-align: center">
        <asp:GridView id="griDL" runat="server" width="100%" ForeColor="#333333" borderwidth="1px" borderColor="Navy" PageSize="20" OnPageIndexChanging="griDL_PageIndexChanging" AllowPaging="true" OnRowCommand="griDL_RowCommand" GridLines="None" Cellpadding="4" AutoGenerateColumns="False" EmptyDatatext="Không có dữ liệu">
        <RowStyle BackColor="#EFF3FB" borderColor="#404040" borderwidth="1px"></RowStyle>
        <Columns>
        <asp:TemplateField Headertext="Th&#244;ng Tin">
            <ItemTemplate>
                <div style=" width:auto; padding:5px; font-weight:bold;"><%# Eval("Title") %></div> (Download: <b><i><%# Eval("Download") %></i></b>)
            </ItemTemplate>
                <ItemStyle Horizontalalign="left" width="200px"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField Headertext="Url">
                <ItemTemplate>
                    <div style=" width:auto; padding:5px;"><%# Eval("URL") %></div> (Bởi: <b><%# Eval("UserName") %></b> - IP: <%# Eval("IP") %> - Lúc: <%# HungLocSon.Tools.WebTools.FormatDateTime(DateTime.Parse(Eval("Upload").ToString())) %>)
            </ItemTemplate>
                <ItemStyle Horizontalalign="left"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField Headertext="Nh&#243;m">
                <ItemTemplate>
                    <span style="padding:5px;"><%# Eval("Name") %></span>
                </ItemTemplate>
        <ItemStyle width="100px"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField Headertext="Hiển Thị">
                <ItemTemplate>
                    <asp:CheckBox ID="Check" Enabled="false" Checked='<%# Eval("Visible") %>' runat="server" />
            </ItemTemplate>
            <ItemStyle width="60px"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField Headertext="Edit">
                <ItemTemplate>
                    <asp:LinkButton ID="cbedit" CommandName="cbedit" CommandArgument='<%# Eval("DownloadId") %>' runat="server" CausesValidation="False">Edit</asp:LinkButton>
            </ItemTemplate>
            <ItemStyle width="50px"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField Headertext="Delete">
                <ItemTemplate>
                    <asp:LinkButton ID="cbdel" CommandName="cbdel" OnClientClick="return confirm('Bạn có muốn xóa không ?')" CommandArgument='<%# Eval("DownloadId") %>' runat="server" CausesValidation="False">Delete</asp:LinkButton>
            </ItemTemplate>
            <ItemStyle width="50px"></ItemStyle>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
    <PagerStyle Horizontalalign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>
    <EditrowStyle BackColor="#2461BF"></EditrowStyle>
    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView>
    </div>
</div>
</ContentTemplate>
    <Triggers>
        <asp:PostBacktrigger ControlID="btok" />
    </Triggers>
</asp:UpdatePanel>
</asp:Content>

