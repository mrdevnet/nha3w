<%@ Page Language="C#" MasterPageFile="~/admincp/HLSNwAdmins.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admincp_news_Default"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainCPH" Runat="Server">
        <div style="width:98%; padding:10px;">
    <asp:GridView ID="griNews" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="griNews_RowCommand" AllowPaging="True" OnPageIndexChanging="griNews_PageIndexChanging" PageSize="20" BorderColor="Gray" BorderWidth="1px" CellPadding="4" ForeColor="#333333" GridLines="None">
    <Columns>
        <asp:TemplateField HeaderText="Ảnh">
            <ItemStyle Width="80px" HorizontalAlign="Center" />
            <ItemTemplate>
                <div style="padding:5px;">
                <img alt="" width="70" style="max-height:70px"  src='<%# ResolveUrl(HungLocSon.Tools.Support.DateTimeToURL(Eval("Posted").ToString())+ Eval("NewsID","{0}/image/") + Eval("Images")) %>' />
                <%--//<img alt="" width="70"  src='<%# Eval("NewsID","../../ImagesNews/{0}/image/") + Eval("Images") %>' />--%>
                </div>
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bản Tin">
            <ItemTemplate>
                <div style="padding-left:5px;">
                    <div style="width:100%;padding:5px" align="left">
                    <div style="width:70%; float:left;">
                        <a target="_blank" style="font-weight:bold;" href='<%# ResolveUrl(Eval("NewsId","~/News/articles.aspx?i={0}")) %>'><%#Eval("Title")%></a> (Bởi: <b><%#Eval("UserName")%></b> - IP: <%#Eval("IP")%>)<br />
                        <span style=" font-size:12px;"><%#Eval("Summary")%> </span>
                    </div>
                    <div style="width:28%; padding-left:2%; float:left;">
                        <input id="Check" runat="server" disabled="disabled" type="checkbox" checked='<%# Eval("Vip") %>' />
                        <%--Đăng Ngày : <%# Eval("Posted", "{0:dd/MM/yyyy}") %>--%>
                        <%# HungLocSon.Tools.WebTools.FormatDateTime(DateTime.Parse(Eval("Posted").ToString())) %><br />
                        Lượt Xem : <%# Eval("Views") %> <br />
                        Đánh Giá : <%# Eval("Rating") %>
                    </div>
                    </div>
                    <div style="width:100%; float:left; padding-top:2px; background:url('../../App_Themes/Admin/dotdot_menu.gif') repeat-x;" align="left">
                    | <a href ="Update.aspx?idn=adrn&or=pstnws">Insert</a> | <a href ='<%#Eval("NewsId","Update.aspx?idn=adrn&or=pstnws&id={0}")%>'>Update</a> | <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Del" OnClientClick="return confirm('Bạn có muốn xóa không ?')" CausesValidation="False" CommandArgument='<%# Eval("NewsId") %>'>Delete</asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
    </Columns>
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#EFF3FB" BorderColor="DarkGray" BorderWidth="1px" />
    <AlternatingRowStyle BorderColor="Silver" BorderWidth="1px" BackColor="White" />
    <PagerSettings FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" NextPageText="&gt;" PreviousPageText="&lt;" />
    <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <EditRowStyle BackColor="White" />
    </asp:GridView> 
</div>
</asp:Content>

