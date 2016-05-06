<%@ Page Language="C#" MasterPageFile="~/admincp/HLSNwAdmins.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admincp_polls_Default"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainCPH" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div style="width:98%; padding:10px; text-align:center;">
<div id="ShowPoll" style="width:98%" runat="server">
   <div style="width:99%;padding:5px; text-align:center;">
                <table>
                    <tr>
                        <td style="width: 74px; text-align: left;">Câu Hỏi :</td>
                        <td style="width: 334px; text-align: left;">
                            <asp:TextBox ID="txtT" runat="server" Width="307px" ValidationGroup="poll"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtT" ErrorMessage="*" ValidationGroup="poll"></asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 218px; text-align: right;" colspan="2">
                            <asp:CheckBox ID="ckbR" runat="server" Text="Cho phép bình chọn nhiều lần" />
                        </td>
                        <td style="width: 100px; text-align: right;">
                            <asp:Button ID="btok" runat="server" BackColor="#67A54B" BorderColor="Black" BorderWidth="1px" Font-Bold="True" ForeColor="White" OnClick="btok_Click" Text="Submit" Width="91px" ValidationGroup="poll" />
                        </td>
                    </tr>
                </table>
            </div>
   <div style="width:99%;padding:5px; text-align:center;">
        <asp:GridView ID="griPoll" runat="server" AutoGenerateColumns="False" BorderColor="Gray" BorderWidth="1px" CellPadding="4" DataKeyNames="PollId" ForeColor="#333333" GridLines="None" Width="100%" OnRowCancelingEdit="griPoll_RowCancelingEdit" OnRowEditing="griPoll_RowEditing" OnRowUpdating="griPoll_RowUpdating" AllowPaging="True" OnPageIndexChanging="griPoll_PageIndexChanging" OnRowCommand="griPoll_RowCommand" PageSize="20" EmptyDataText="Không có dữ liệu">
        <RowStyle BackColor="#EFF3FB" BorderColor="Gray" BorderWidth="1px" />
            <Columns>
                <asp:TemplateField HeaderText="C&#226;u Hỏi">
                    <EditItemTemplate>
                        <div style=" padding:5px;">
                            <asp:TextBox ID="txtTe" Width="100%" Text='<%#Eval("Title") %>' runat="server"></asp:TextBox>
                        </div>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <div style="width:auto; padding:5px; text-align:left;">
                        <asp:LinkButton ID="showVote" CommandName="vote" CommandArgument='<%# Eval("PollId") %>' runat="server" Font-Bold="true" CausesValidation="False"><%# Eval("Title") %></asp:LinkButton>
                        ( <%# Eval("Total") %> ) <asp:LinkButton ID="showResult" CommandName="result" CommandArgument='<%# Eval("PollId") %>' runat="server" CausesValidation="False">Đáp án</asp:LinkButton>
                        </div>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Lặp Lại">
                    <EditItemTemplate>
                        <asp:CheckBox ID="ckbRe" Checked='<%# Eval("Repeat") %>' runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="ckbRi" Enabled="false" Checked='<%# Eval("Repeat") %>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="80px" />
                </asp:TemplateField>
               <asp:CommandField ShowEditButton="True" HeaderText="Edit" CausesValidation="False">
                    <ItemStyle Width="80px" ForeColor="#3B5889" />
                </asp:CommandField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="cmdDel1" CommandName="del" OnClientClick="return confirm('Bạn có muốn xóa không ?')"  CommandArgument='<%# Eval("PollId") %>' runat="server" CausesValidation="False">Delete</asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="60px" />
                </asp:TemplateField>
            </Columns>
           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
           <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <EditRowStyle BackColor="White" />
           <AlternatingRowStyle BackColor="White" />
       </asp:GridView>&nbsp;
       </div>
    </div>
    <div style="width:770px; overflow:hidden;">
        <div id="ShowTitle" runat="server" visible="false" style="width:770px;padding:5px; text-align:left; font-weight:bold; color:#3B5889">
            <div style="float:left; width: 714px;">Câu Hỏi :
                <asp:Label ID="lbPollT" runat="server"></asp:Label>&nbsp;
                <asp:Label ID="lbPollId" runat="server" Visible="False"></asp:Label>
            </div>
            <div  style=" margin:0px 0px 0px auto; color:Red;">
                <asp:LinkButton ID="lCl" runat="server" ForeColor="#C00000" OnClick="lCl_Click">Close</asp:LinkButton>
            </div>
        </div>
        <div id="ShowResult" runat="server" visible="false" style="width:760px;padding:5px; text-align:center;">
        <div style=" width:500px; padding:10px 130px 10px 130px; text-align:left;">Đáp án :
            <asp:TextBox ID="txtRe" runat="server" ValidationGroup="res" Width="333px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRe" ErrorMessage="*" ValidationGroup="res"></asp:RequiredFieldValidator>
            <asp:Button ID="btRs" runat="server" BackColor="#67A54B" BorderColor="Black" BorderWidth="1px" Font-Bold="True" ForeColor="White" OnClick="btRs_Click" Text="Submit" Width="73px" ValidationGroup="res" />
        </div>
        <div style=" width:500px; padding:0px 130px 0px 130px;">
            <asp:GridView ID="griResult" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" BorderColor="#404040" BorderWidth="1px" OnRowCancelingEdit="griResult_RowCancelingEdit" OnRowCommand="griResult_RowCommand" OnRowEditing="griResult_RowEditing" OnRowUpdating="griResult_RowUpdating" DataKeyNames="ResultId" EmptyDataText="Không có dữ liệu">
            <RowStyle BackColor="#EFF3FB" BorderColor="#404040" BorderWidth="1px" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Đ&#225;p &#225;n">
                <EditItemTemplate>
                    <asp:TextBox ID="txtTe2" Width="95%" Text='<%#Eval("Title") %>' runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <div style="padding:5px;"><%# Eval("Title") %> ( <%# Eval("Total") %> )</div>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:CommandField CausesValidation="False" HeaderText="Edit" ShowEditButton="True">
                    <ItemStyle ForeColor="#3B5889" Width="80px" />
                </asp:CommandField>
                <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:LinkButton ID="cmdDel2" CommandName="del" OnClientClick="return confirm('Bạn có muốn xóa không ?')"  CommandArgument='<%# Eval("ResultId") %>' runat="server" CausesValidation="False">Delete</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="60px" />
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
        </div>
    </div>
    <div id="ShowVote" runat="server" visible="false" style="width:760px;padding:5px; text-align:center;">
    <div style=" width:500px; padding:0px 130px 0px 130px;">
    <asp:GridView ID="griVote" runat="server" BorderColor="Gray" BorderWidth="1px" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="STT" PageSize="30" OnPageIndexChanging="griVote_PageIndexChanging" EmptyDataText="Không có dữ liệu">
    <RowStyle BackColor="#EFF3FB" BorderColor="Gray" BorderWidth="1px" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="STT" HeaderText="STT" SortExpression="STT">
        <ItemStyle Width="50px" />
        </asp:BoundField>
        <asp:BoundField DataField="IP" HeaderText="IP Kh&#225;nh" SortExpression="IP" />
        <asp:BoundField DataField="VoteDate" DataFormatString="{0:dd/MM/yyy}" HeaderText="Ng&#224;y b&#236;nh chọn" SortExpression="VoteDate">
        <ItemStyle Width="150px" />
        </asp:BoundField>
    </Columns>
    </asp:GridView>
    </div>
    </div>
    </div>
    </div>
</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="griResult" EventName="RowDeleting" />
        <asp:AsyncPostBackTrigger ControlID="griResult" EventName="RowEditing" />
        <asp:AsyncPostBackTrigger ControlID="griResult" EventName="RowUpdating" />
    </Triggers>
</asp:UpdatePanel>
</asp:Content>

