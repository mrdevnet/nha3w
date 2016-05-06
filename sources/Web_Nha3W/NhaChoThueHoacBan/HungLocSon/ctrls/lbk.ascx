<%@ Control Language="C#" AutoEventWireup="true" CodeFile="lbk.ascx.cs" Inherits="ctrls_lbk" %>
<div class="clt-content">
    <div class="clt-left">Gía trị căn hộ</div>
    <div class="clt-right">
        <input id="gia" type="text" class="clt-textbox"  onkeyup="this.value = FormatNumber(this.value)" value="1,000,000,000"/><span>VNĐ</span></div>
    <div class="clt-left">Số tiền trả trước</div>
    <div class="clt-right">
        <input id="truoc" type="text" class="clt-textbox" onkeyup="settruoc()" value="100,000,000"/><span>VNĐ</span></div>
    <div class="clt-left">Tương đương</div>
    <div class="clt-right">
        <input id="phan" type="text" class="clt-textbox" onkeyup="setphan()" value="0"/><span>%</span></div>
    <div class="clt-left">Thời hạn vay</div>
    <div class="clt-right">
        <input id="thang" type="text" class="clt-textbox"  onkeyup="setthang()" value="180"/><span>Tháng</span></div>
    <div class="clt-left">Tương đương</div>
    <div class="clt-right">
        <input id="nam" type="text" class="clt-textbox"  onkeyup="setnam()" value="0"/><span>Năm</span></div>
    <div class="clt-left">Lãi suất vay</div>
    <div class="clt-right">
        <input id="lai" type="text" class="clt-textbox" value="1"/><span>%/tháng</span></div>
    <div class="clt-left">Số tiền &amp; trả góp</div>
    <div class="clt-right">
        <input id="tong" type="text" class="clt-textbox" style="color:Red; font-weight:bold;" value="0"/><span>VNĐ</span></div>
    <div class="clt-content-btn">
        <input id="Tinh" class="clt-button" type="button" value="Tính" onclick="doTinh(); return false;" />
        <input id="Tinhlai" class="clt-button" type="button" value="Tính lại" onclick="doTinhlai(); return false;" />
    </div>
</div>
