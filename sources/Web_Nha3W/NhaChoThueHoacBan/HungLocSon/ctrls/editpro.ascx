<%@ Control Language="C#" AutoEventWireup="true" CodeFile="editpro.ascx.cs" Inherits="ctrls_editpro" %>
<%@ Register Assembly="FUA" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<link href="../App_Themes/Profile/profile.css" rel="stylesheet" type="text/css" />--%>
<asp:UpdatePanel ID="UpdatePanel" runat="server">
<ContentTemplate>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="tab" Font-Overline="False" Font-Bold="False" Width="750px" EnableTheming="False" EnableViewState="False">
        <cc1:TabPanel runat="server" ID="tab1" HeaderText="Thiết lập">
            <ContentTemplate>
                <div class="tab_container">
                    <div id="err" class="fram_content_err" style="margin:10px 10px 3px 10px;" runat="server">
                        <h2 id="header_err" runat="server"></h2>
                        <p class="err_txt"></p>
                        <p id="text_err" runat="server"></p>
                    </div>
                <div class="tab_content">
                    <cc1:CollapsiblePanelExtender ID="tabFullName" runat="server" Enabled="True" TargetControlID="pnlfullname" TextLabelID="lblfullname" ExpandControlID="pnlfn" CollapseControlID="pnlfn" Collapsed="True" SuppressPostBack="True" CollapsedText="thay đổi" ExpandedText="ẩn">
                        </cc1:CollapsiblePanelExtender>
                            <cc1:CollapsiblePanelExtender ID="tabfnTop" runat="server" CollapseControlID="pnlfn" ExpandControlID="pnlfn" TargetControlID="pnlfntop" TextLabelID="lblfullname" Enabled="True">
                            </cc1:CollapsiblePanelExtender>
                                <asp:Panel ID="pnlfn" runat="server" Width="100%">
                                    <div class="tab_label">
                                        <div class="tab_labell">Tên</div>
                                        <div class="tab_labelr"><asp:Label ID="lblfullname" runat="server" CssClass="tab_labelr" Font-Bold="False" ForeColor="#5F76C8">(ẩn)</asp:Label></div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlfntop" runat="server" Width="100%">
                                    <div class="tab_lbl">Tên thật.</div>
                                </asp:Panel>
                                <asp:Panel ID="pnlfullname" runat="server" Width="100%">
                                    <div class="tab_trf">
                                    Chúng tôi xác nhận tất cả các thay đổi về tên trước khi chúng có hiệu lực.<br />
                                    Điều này sẽ mất khoảng chừng 24 giờ, vì vậy xin bạn hãy kiên nhẫn.
                                    </div>
                                    <div class="tab_tr">
                                        <div class="tab_tdl">Họ và tên hiện tại:</div>
                                        <div class="tab_tdr">
                                            <asp:Label ID="lblFName" CssClass="lbl" runat="server" Width="100%"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="tab_tr">
                                        <div class="tab_tdl">Họ và tên thay thế:</div>
                                        <div class="tab_tdr">
                                            <asp:TextBox ID="txtfullname" runat="server" CssClass="tab_textbox"></asp:TextBox>
                                        </div>
                                    </div>
                                        <div class="tab_buttons">
                                            <asp:LinkButton ID="btnfullname" runat="server" CssClass="buttons" Font-Bold="False" OnClick="btnfullname_Click">Thay đổi tên</asp:LinkButton>
                                        </div>
                                    </asp:Panel>
                        <cc1:CollapsiblePanelExtender ID="TabEmail" runat="server" CollapseControlID="pnlem" Collapsed="True" ExpandControlID="pnlem" TargetControlID="pnlemail" TextLabelID="lblemail" Enabled="True" SuppressPostBack="True" CollapsedText="thay đổi" ExpandedText="ẩn">
                        </cc1:CollapsiblePanelExtender>
                        <cc1:CollapsiblePanelExtender ID="Tabemtop" runat="server" CollapseControlID="pnlem" ExpandControlID="pnlem" TargetControlID="pnlemailtop" TextLabelID="lblemail" Enabled="True">
                        </cc1:CollapsiblePanelExtender>
                            <asp:Panel ID="pnlem" runat="server" Width="100%">
                                <div class="tab_label">
                                    <div class="tab_labell">Email</div>
                                    <div class="tab_labelr">
                                        <asp:Label ID="lblemail" runat="server" Text="Email" CssClass="tab_labelr" Font-Bold="False" ForeColor="#5F76C8"></asp:Label>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlemailtop" runat="server" Width="100%">
                                <div class="tab_lbl">Thiết lập địa chỉ email liên lạc.</div>
                            </asp:Panel>
                            <asp:Panel ID="pnlemail" runat="server" Width="100%">
                                <div class="tab_trf">Địa chỉ email của bạn phải luôn hợp lệ.</div>
                                    <div class="tab_tr">
                                        <div class="tab_tdl">Email hiện tại:</div>
                                    <div class="tab_tdr">
                                        <asp:Label ID="lblEM" runat="server" CssClass="lbl" Width="100%"></asp:Label>
                                    </div>
                                </div>
                                <div class="tab_tr">
                                    <div class="tab_tdl">Email mới:</div>
                                    <div class="tab_tdr">
                                        <asp:TextBox ID="txtemail" runat="server" CssClass="tab_textbox"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="tab_buttons">
                                    <asp:LinkButton ID="btnemail" runat="server" CssClass="buttons" Font-Bold="False"  OnClick="btnemail_Click">Thay đổi email</asp:LinkButton>
                                </div>
                            </asp:Panel>
                        <cc1:CollapsiblePanelExtender ID="TabPassWord" runat="server" CollapseControlID="pnlp" Collapsed="True" ExpandControlID="pnlp" TargetControlID="pnlpass" TextLabelID="lblpass" Enabled="True" SuppressPostBack="True" CollapsedText="thay đổi" ExpandedText="ẩn">
                        </cc1:CollapsiblePanelExtender>
                        <cc1:CollapsiblePanelExtender ID="Tabpwtop" runat="server" CollapseControlID="pnlp" EnableViewState="False" ExpandControlID="pnlp" TargetControlID="pnlptop" TextLabelID="lblpass" Enabled="True"></cc1:CollapsiblePanelExtender>
                        <asp:Panel ID="pnlp" runat="server" Width="100%">
                            <div class="tab_label">
                                <div class="tab_labell">Mật khẩu</div>
                                <div class="tab_labelr"><asp:Label ID="lblpass" runat="server" CssClass="tab_labelr" Text="Mật khẩu" Font-Bold="False" ForeColor="#5F76C8"></asp:Label></div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlptop" runat="server" Width="100%">
                            <div class="tab_lbl">Cái bạn sử dụng để đăng nhập</div>
                        </asp:Panel>
                        <asp:Panel ID="pnlpass" runat="server" Width="100%">
                            <div class="tab_trf">
                            * Không dùng chung mật khẩu mà bạn sử dụng với những tài khoản trực tuyến khác.<br />
                            * Mật khẩu mới của bạn phải có ít nhất 6 ký tự.<br />
                            * Dùng sự kết hợp giữa kí tự, kí số và dấu chấm câu.<br />
                            * Mật khẩu có phân biệt chữ hoa và chữ thường. Xin lưu ý kiểm tra trạng thái phím CAPS LOCK.
                            </div>
                            <div class="tab_tr">
                                <div class="tab_tdl">Mật khẩu hiện tại:</div>
                                    <div class="tab_tdr">
                                        <asp:TextBox ID="txtoldpass" runat="server" CssClass="tab_textbox" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="tab_tr">
                                    <div class="tab_tdl">Mật khẩu mới:</div>
                                    <div class="tab_tdr">
                                        <asp:TextBox ID="txtnewpass" runat="server" CssClass="tab_textbox" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="tab_tr">
                                    <div class="tab_tdl" style="margin-top:0px;">Nhắc lại mật khẩu:</div>
                                    <div class="tab_tdr">
                                        <asp:TextBox ID="txtrespeakpass" runat="server" CssClass="tab_textbox" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="tab_buttons">
                                    <asp:LinkButton ID="btnpass" runat="server" CssClass="buttons" Font-Bold="False" OnClick="btnpass_Click">Thay đổi mật khẩu</asp:LinkButton>
                                </div>
                        </asp:Panel>
                    <cc1:CollapsiblePanelExtender ID="Tablogo" runat="server" CollapseControlID="pnllg" Collapsed="True" ExpandControlID="pnllg" TargetControlID="pnllogo" TextLabelID="lbllogo" Enabled="True" SuppressPostBack="True" CollapsedText="thay đổi" ExpandedText="ẩn">
                    </cc1:CollapsiblePanelExtender>
                    <cc1:CollapsiblePanelExtender ID="Tablogotop" runat="server" CollapseControlID="pnllg" EnableViewState="False" ExpandControlID="pnllg" TargetControlID="pnllgtop" TextLabelID="lbllogo" Enabled="True">
                    </cc1:CollapsiblePanelExtender>
                        <asp:Panel ID="pnllg" runat="server" Width="100%">
                            <div class="tab_label">
                                <div class="tab_labell">Logo</div>
                                <div class="tab_labelr"><asp:Label ID="lbllogo" runat="server" CssClass="tab_labelr" Text="Mật khẩu" Font-Bold="False" ForeColor="#5F76C8"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnllgtop" runat="server" Width="100%">
                            <div class="tab_lbl">Hình ảnh đại diện cá nhân hoặc Logo đại diện công ty mà bạn làm việc.</div>
                        </asp:Panel>
                        <asp:Panel ID="pnllogo" runat="server" Width="100%">
                            <div class="tab_trf">* Ảnh hiển thị đại điện cho khách hàng.<br />
                            * Logo công ty mà bạn làm việc.
                            </div>
                            <div class="tab_tr" style="height:70px">
                                <div class="tab_tdl">Logo hiện tại:</div>
                                <div class="tab_tdr" style="height:60px;">
                                    <asp:Image ID="imglogo" runat="server" /> <%--Width="60px" Height="60px" --%>
                                </div>
                            </div>
                            <div class="tab_tr">
                                <div class="tab_tdl">Logo mới:</div>
                            <div class="tab_tdr">
                                <%--<asp:FileUpload ID="fullogo" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="250px" BorderColor="#B9C4DA" CssClass="tab_textbox" />--%>
                                <cc1:FileUploaderAJAX ID="fp1" runat="server" text_Add="Thêm" text_Delete="Xoá" text_Uploading="Đang upload file"/>
                            </div>
                            </div>
                        <div class="tab_buttons">
                            <asp:LinkButton ID="btnlogo" runat="server" CssClass="buttons" Font-Bold="False" OnClick="btnlogo_Click">Thay đổi logo</asp:LinkButton>
                        </div>
                    </asp:Panel>
                    <cc1:CollapsiblePanelExtender ID="tabPrive" runat="server" CollapseControlID="pnlPriv" Collapsed="True" ExpandControlID="pnlPriv" TargetControlID="pnlPrivate" TextLabelID="lblPri" Enabled="True" SuppressPostBack="True" CollapsedText="thay đổi" ExpandedText="ẩn">
                    </cc1:CollapsiblePanelExtender>
                    <cc1:CollapsiblePanelExtender ID="tabPriveTop" runat="server" CollapseControlID="pnlPriv" EnableViewState="False" ExpandControlID="pnlPriv" TargetControlID="pnlPrivTop" TextLabelID="lblPri" Enabled="True">
                    </cc1:CollapsiblePanelExtender>
                        <asp:Panel ID="pnlPriv" runat="server" Width="100%">
                            <div class="tab_label">
                                <div class="tab_labell">Tài khoản</div>
                                <div class="tab_labelr"><asp:Label ID="lblPri" runat="server" CssClass="tab_labelr" Text="Mật khẩu" Font-Bold="False" ForeColor="#5F76C8"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlPrivTop" runat="server" Width="100%">
                            <div class="tab_lbl">Cài đặt thông tin tài khoản của bạn được hiển thị công cộng hay cá nhân.</div>
                        </asp:Panel>
                        <asp:Panel ID="pnlPrivate" runat="server" Width="100%">
                            <div class="tab_trf">
                                * Cài đặt công cộng cho phép mọi người có thể xem thông tin bài viết, bình luận, bạn bè của bạn.<br />
                                * Cài đặt cá nhân chỉ dành cho bạn bè (được duyệt trước khi kết bạn) của bạn nhìn thấy.
                            </div>
                            <div class="tab_tr">
                                <div class="tab_tdl" style="margin-top:0px;">Tài khoản:</div>
                                <div class="tab_tdr">
                                    <asp:RadioButton GroupName="Private" ID="priy" runat="server" Checked="true" Text="Công cộng"/> 
                                    <asp:RadioButton GroupName="Private" ID="prin" runat="server" Text="Cá nhân"/>
                                </div>
                            </div>
                            <div class="tab_buttons">
                                <asp:LinkButton ID="btnPrive" runat="server" CssClass="buttons" Font-Bold="False" OnClick="btnPrive_Click">Thay đổi riêng tư</asp:LinkButton>
                            </div>
                    </asp:Panel>
                </div>
            </DIV>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" ID="tab2" HeaderText="Th&#244;ng tin c&#225; nh&#226;n">
        <ContentTemplate>
            <div class="tab_container">
                <div class="tab_content">
                    <cc1:CollapsiblePanelExtender ID="Tabpf" runat="server" Enabled="True" TargetControlID="pnlprofile" TextLabelID="lblprofile" ExpandControlID="pnlpf" CollapseControlID="pnlpf" Collapsed="True" SuppressPostBack="True" CollapsedText="thay đổi" ExpandedText="ẩn">
                    </cc1:CollapsiblePanelExtender>
                    <cc1:CollapsiblePanelExtender ID="Tabpftop" runat="server" CollapseControlID="pnlpf" ExpandControlID="pnlpf" TargetControlID="pnlpftop" TextLabelID="lblprofile" Enabled="True">
                    </cc1:CollapsiblePanelExtender>
                    <asp:Panel ID="pnlpf" runat="server" Width="100%">
                        <div class="tab_label">
                            <div class="tab_labell">Thông tin liên lạc</div>
                            <div class="tab_labelr"><asp:Label ID="lblprofile" runat="server" CssClass="tab_labelr" Font-Bold="False" ForeColor="#5F76C8">(ẩn)</asp:Label>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlpftop" runat="server" Width="100%">
                        <div class="tab_lbl">Địa chỉ, điện thoại, công ty nơi bạn làm việc.</div>
                    </asp:Panel>
                    <asp:Panel ID="pnlprofile" runat="server" Width="100%">
                        <div class="tab_trf">Chúng tôi xác nhận tất cả các thay đổi về tên trước khi chúng có hiệu lực.<br />
                        Điều này sẽ mất khoảng chừng 24 giờ, vì vậy xin bạn hãy kiên nhẫn.
                        </div>
                        <div class="tab_tr">
                            <div class="tab_tdl">Họ và tên đầy đủ:</div>
                        <div class="tab_tdr">
                            <asp:TextBox ID="txtFName" runat="server" CssClass="tab_textbox"></asp:TextBox>
                        </div>
                        </div>
                        <div class="tab_tr">
                            <div class="tab_tdl">Ngày sinh:</div>
                            <div class="tab_tdr">
                                <asp:TextBox ID="txtbirthday" runat="server" CssClass="tab_textbox" Width="100px"></asp:TextBox>
                                <cc1:CalendarExtender ID="Datebd" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupPosition="BottomRight" TargetControlID="txtbirthday"></cc1:CalendarExtender>
                            </div>
                        </div>
                        <div class="tab_tr">
                            <div class="tab_tdl">Giới tính:</div>
                            <div class="tab_tdr">
                                <asp:DropDownList ID="cobGender" runat="server" CssClass="tab_textbox" Width="70px">
                                <asp:ListItem Value="0">Nữ</asp:ListItem>
                                <asp:ListItem Value="1">Nam</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="tab_tr"style="height:70px;">
                        <div class="tab_tdl">Địa chỉ:</div>
                        <div class="tab_tdr" style="height:57px;">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="tab_textbox" Height="100%" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </div>
                        </div>
                        <div class="tab_tr">
                        <div class="tab_tdl">Điện thoại:</div>
                        <div class="tab_tdr">
                            <asp:TextBox ID="txtTel" runat="server" CssClass="tab_textbox"></asp:TextBox>
                        </div>
                        </div>
                        <div class="tab_tr">
                            <div class="tab_tdl">Di động:</div>
                        <div class="tab_tdr">
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="tab_textbox"></asp:TextBox>
                        </div>
                    </div>
                    <div class="tab_tr">
                        <div class="tab_tdl">Công ty:</div>
                        <div class="tab_tdr">
                            <asp:TextBox ID="txtCompany" runat="server" CssClass="tab_textbox"></asp:TextBox>
                        </div>
                    </div>
                    <div class="tab_buttons">
                        <asp:LinkButton ID="btnprofile" runat="server" CssClass="buttons" Font-Bold="False" OnClick="btnprofile_Click">Thay đổi thông tin</asp:LinkButton>
                    </div>
                </asp:Panel>
                <cc1:CollapsiblePanelExtender ID="Tabcn" runat="server" Enabled="True" TargetControlID="pnlconnect" TextLabelID="lblconnect" ExpandControlID="pnlcn" CollapseControlID="pnlcn" Collapsed="True" SuppressPostBack="True" CollapsedText="thay đổi" ExpandedText="ẩn">
                </cc1:CollapsiblePanelExtender>
                <cc1:CollapsiblePanelExtender ID="Tabcntop" runat="server" CollapseControlID="pnlcn" ExpandControlID="pnlcn" TargetControlID="pnlcntop" TextLabelID="lblconnect" Enabled="True">
                </cc1:CollapsiblePanelExtender>
                <asp:Panel ID="pnlcn" runat="server" Width="100%">
                <div class="tab_label">
                    <div class="tab_labell">Liên hệ</div>
                    <div class="tab_labelr">
                        <asp:Label ID="lblconnect" runat="server" CssClass="tab_labelr" Font-Bold="False" ForeColor="#5F76C8">(ẩn)</asp:Label>
                    </div>
                </div>
                </asp:Panel>
                <asp:Panel ID="pnlcntop" runat="server" Width="100%">
                    <div class="tab_lbl">Email,Yahoo,Skye và địa chỉ website của bạn.</div>
                </asp:Panel>
                <asp:Panel ID="pnlconnect" runat="server" Width="100%">
                    <div class="tab_trf">
                        Thông tin các tài khoản online để chúng tôi có thể hỗ trợ bạn khi cần thiết.<br />
                        Hãy nhập những thông tin chính xác nhất.
                    </div>
                <div class="tab_tr">
                    <div class="tab_tdl">Email:</div>
                    <div class="tab_tdr">
                        <asp:TextBox ID="txtEM2" runat="server" CssClass="tab_textbox"></asp:TextBox>
                    </div>
                </div>
                <div class="tab_tr">
                    <div class="tab_tdl">Nick Yahoo:</div>
                    <div class="tab_tdr">
                        <asp:TextBox ID="txtYahoo" runat="server" CssClass="tab_textbox"></asp:TextBox>
                    </div>
                </div>
                <div class="tab_tr">
                    <div class="tab_tdl">Nick Skype:</div>
                    <div class="tab_tdr">
                        <asp:TextBox ID="txtSkype" runat="server" CssClass="tab_textbox"></asp:TextBox>
                    </div>
                </div>
                <div class="tab_tr">
                    <div class="tab_tdl">Website:</div>
                    <div class="tab_tdr">
                        <asp:TextBox ID="txtWebsite" runat="server" CssClass="tab_textbox"></asp:TextBox>
                    </div>
                </div>
                <div class="tab_buttons">
                    <asp:LinkButton ID="btnconnect" runat="server" CssClass="buttons" Font-Bold="False" OnClick="btnconnect_Click">Thay đổi thông tin</asp:LinkButton>
                </div>
            </asp:Panel>
        </div>
    </div>
</ContentTemplate>
</cc1:TabPanel>
<cc1:TabPanel  runat="server" ID="tab3" HeaderText="Di động">
    <ContentTemplate>
        <div class="tab_container">
            <div class="tab_content">
                <asp:Panel ID="Panel1" runat="server" Width="100%">
                    <div class="tab_label">
                    <div class="tab_labell">Kích hoạt di động</div>
                    <div class="tab_labelr"></div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlmobiletop" runat="server" Width="100%">
                    <div class="tab_lbl" style="height:auto;">
                    Việc kích hoạt cho phép Nha3W Mobile gửi tin nhắn tới di động của bạn, thông báo khi có yêu cầu kết bạn,tin nhắn, bài post trên Wall,...<br/>
                    Bạn cũng có thể cập nhật trạng thái của bạn, tìm kiếm số điện thoại, hoặc tải lên ảnh và phim bằng điện thoại.<p/>
                    <a>Đăng ký tin nhắn ký tự Nha3W.</a><p/>
                    <a>Đã nhận được mã xác nhận?</a>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </ContentTemplate>
</cc1:TabPanel>
</cc1:TabContainer>
</ContentTemplate>
</asp:UpdatePanel>
