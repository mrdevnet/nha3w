using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HungLocSon.EHLS;
using HungLocSon.BHLS;

public partial class smsways_n3wsmsway : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Các thông số nhận bao gồm:
            //•	message: Nội dung tin nhắn của khách hàng (VD: FIBO TEST)
            //•	phone: Số điện thoại của khách hàng nhắn tin (VD: 84975XXXXXX)
            //•	service: Mã số dịch vụ của đối tác tại FiboSMSGateway (VD: 1)
            //•	port: Đầu số (VD: 8022)

            HttpContext ctx = this.Context;
            string ClientIP = ctx.Request.UserHostAddress;
            string phone = "";
            string service = "";
            string message = "";

            //Chỉ cho phép truy xuất từ ip của fibo, ngăn chặn các tình trạng hack
            if (ClientIP.Equals("112.78.7.18") || ClientIP.Equals("118.69.199.9") || ClientIP.Equals("127.0.0.1"))
            {

                if (Request.QueryString["message"] != null && Request.QueryString["phone"] != null && Request.QueryString["service"] != null)
                {
                    phone = Request.QueryString["phone"].ToString(); //Số điện thoại khách hàng dùng để nhắn đến
                    service = Request.QueryString["service"].ToString();//Mã số dịch vụ của đối tác tại FiboSMSGateway
                    message = Request.QueryString["message"].ToUpper();//Nội dung khách hàng nhắn

                    string[] submessage = message.Split(' ');// Mảng nội dung


                    //Sau khi nhận được đầy đủ tham số sẽ xử lý ở đây
                    //Insert dữ liệu vào trong database, lấy dữ liệu từ database trả về cho khách hàng ....
                    //Sau khi xử lý xong sẽ đưa nội dung trả về cho khách hàng vào biến replyMessage
                    string replyMessage = "";//Nội dung tin nhắn phản hồi cho khách hàng
                    ETransIn tr = new ETransIn();
                    tr.Total = 15 * 4;
                    tr.MemberId = "";
                    tr.IP = ClientIP;
                    tr.ByMember = "";
                    tr.NumberP = HungLocSon.UHLS.EncryptM.ToInput(phone);
                    int i = 0;
                    switch (submessage[1].ToString().ToLower())
                    {
                        case "tk":
                            {
                                string uid = "";
                                if (submessage[2] != null && submessage[2].ToString() != "")
                                {
                                    if (int.TryParse(submessage[2].ToString(), out i))
                                    {
                                        EMember m = new EMember(i);
                                        uid = BMember.PMemberU(m);
                                    }
                                    else uid = submessage[2].ToString();
                                    tr.TypeId = 1;
                                    tr.MemberId = uid;
                                    tr.PostId = 0;
                                    BTransIO.ITransIn(tr);
                                    replyMessage = "Ban da nap tien thanh cong cho tai khoan: " + uid.ToLower() + 
                                        " tai website nha3w.com. Tai khoan hien co cua ban la : " + BTransIO.MyWallet(uid) + " xu.";
                                }
                                else replyMessage = "Cu phap tin nhan cua ban tai website nha3w.com chua dung. Cu phap dung: SMS TK TENDANGNHAP gui 8717.";
                                break;
                            }
                        case "vip":
                            {
                                if (submessage[2] != null && submessage[2].ToString() != "")
                                {
                                    if (int.TryParse(submessage[2].ToString(), out i))
                                    {
                                        tr.TypeId = 7;
                                        tr.PostId = i;
                                        BTransIO.ITransIn(tr);
                                        tr.Total = 7;
                                        replyMessage = BTransIO.ITransOut(tr);
                                        //replyMessage += " Tai khoan con du ban la : " + BTransIO.MyWallet(uid) + " xu.";
                                    }
                                    else replyMessage = "Ma so tin nhan : " + submessage[2].ToString() + " nay khong ton tai. Ban vui long kiem tra lai cho chinh xac.";
                                }
                                else replyMessage = "Cu phap tin nhan cua ban tai website nha3w.com chua dung. Cu phap dung: SMS TK TENDANGNHAP gui 8717.";
                                break;
                            }
                        case "ip":
                            {
                                if (submessage[2] != null && submessage[2].ToString() != "")
                                {
                                    if (int.TryParse(submessage[2].ToString(), out i))
                                    {
                                        tr.TypeId = 8;
                                        tr.PostId = i;
                                        BTransIO.ITransIn(tr);
                                        tr.Total = 7;
                                        replyMessage = BTransIO.ITransOut(tr);
                                        //replyMessage += " Tai khoan con du ban la : " + BTransIO.MyWallet(uid) + " xu.";
                                    }
                                    else replyMessage = "Ma so tin nhan : " + submessage[2].ToString() + " nay khong ton tai. Ban vui long kiem tra lai cho chinh xac.";
                                }
                                else replyMessage = "Cu phap tin nhan cua ban tai website nha3w.com chua dung. Cu phap dung: SMS TK TENDANGNHAP gui 8717.";
                                break;
                            }
                        case "up":
                            {
                                if (submessage[2] != null && submessage[2].ToString() != "")
                                {
                                    if (int.TryParse(submessage[2].ToString(), out i))
                                    {
                                        tr.TypeId = 6;
                                        tr.PostId = i;
                                        BTransIO.ITransIn(tr);
                                        tr.Total = 1;
                                        replyMessage = BTransIO.ITransOut(tr);
                                        //replyMessage += " Tai khoan con du ban la : " + BTransIO.MyWallet(uid) + " xu.";
                                    }
                                    else replyMessage = "Ma so tin nhan : " + submessage[2].ToString() + " nay khong ton tai. Ban vui long kiem tra lai cho chinh xac.";
                                }
                                else replyMessage = "Cu phap tin nhan cua ban tai website nha3w.com chua dung. Cu phap dung: SMS TK TENDANGNHAP gui 8717.";
                                break;
                            }
                        case "tin":
                            {
                                if (submessage[2] != null && submessage[2].ToString() != "")
                                {
                                    if (int.TryParse(submessage[2].ToString(), out i))
                                    {
                                        tr.TypeId = 9;
                                        tr.PostId = i;
                                        BTransIO.ITransIn(tr);
                                        tr.Total = 1;
                                        replyMessage = BTransIO.ITransOut(tr);
                                        //replyMessage += " Tai khoan con du ban la : " + BTransIO.MyWallet(uid) + " xu.";
                                    }
                                    else replyMessage = "Ma so tin nhan : " + submessage[2].ToString() + " nay khong ton tai. Ban vui long kiem tra lai cho chinh xac.";
                                }
                                else replyMessage = "Cu phap tin nhan cua ban tai website nha3w.com chua dung. Cu phap dung: SMS TK TENDANGNHAP gui 8717.";
                                break;
                            }
                        case "giahan":
                            {
                                if (submessage[2] != null && submessage[2].ToString() != "")
                                {
                                    if (int.TryParse(submessage[2].ToString(), out i))
                                    {
                                        tr.TypeId = 12;
                                        tr.PostId = i;
                                        BTransIO.ITransIn(tr);
                                        tr.Total = 1;
                                        replyMessage = BTransIO.ITransOut(tr);
                                        //replyMessage += " Tai khoan con du ban la : " + BTransIO.MyWallet(uid) + " xu.";
                                    }
                                    else replyMessage = "Ma so tin nhan : " + submessage[2].ToString() + " nay khong ton tai. Ban vui long kiem tra lai cho chinh xac.";
                                }
                                else replyMessage = "Cu phap tin nhan cua ban tai website nha3w.com chua dung. Cu phap dung: SMS TK TENDANGNHAP gui 8717.";
                                break;
                            }
                        case "qc":
                            {
                                if (submessage[2] != null && submessage[2].ToString() != "")
                                {
                                    if (int.TryParse(submessage[2].ToString(), out i))
                                    {
                                        tr.TypeId = 10;
                                        tr.PostId = i;
                                        BTransIO.ITransIn(tr);
                                        tr.Total = 1;
                                        replyMessage = BTransIO.ITransOut(tr);
                                        //replyMessage += " Tai khoan con du ban la : " + BTransIO.MyWallet(uid) + " xu.";
                                    }
                                    else replyMessage = "Ma so tin nhan : " + submessage[2].ToString() + " nay khong ton tai. Ban vui long kiem tra lai cho chinh xac.";
                                }
                                else replyMessage = "Cu phap tin nhan cua ban tai website nha3w.com chua dung. Cu phap dung: SMS TK TENDANGNHAP gui 8717.";
                                break;
                            }
                        default:
                            {
                                replyMessage = "Cu phap tin nhan cua ban tai website nha3w.com chua dung. Cu phap dung: SMS TK TENDANGNHAP gui 8717.";
                                break;
                            }
                    }
                    //Phần này dùng để in nội dung phản hồi ra trang web để FiboSMSGateway nhận và trả về cho khách hàng.
                    Response.Write("<ClientResponse><Message><PhoneNumber>" + phone + "</PhoneNumber><Message>" + replyMessage + "</Message><SMSID> -1</SMSID><ServiceNo>" + service + "</ServiceNo></Message></ClientResponse>");
                }
                else
                    //Phần này dùng để in nội dung phản hồi ra trang web để FiboSMSGateway nhận và trả về cho khách hàng.
                    Response.Write("<ClientResponse><Message><PhoneNumber>" + phone + "</PhoneNumber><Message>Cu phap tin nhan cua ban tai website nha3w.com chua dung. Cu phap dung: SMS TK TENDANGNHAP gui 8717!!</Message><SMSID> -1</SMSID><ServiceNo>" + service + "</ServiceNo></Message></ClientResponse>");
            }
            else
                //Phần này dùng để in nội dung phản hồi ra trang web để FiboSMSGateway nhận và trả về cho khách hàng.
                Response.Write("<ClientResponse><Message><PhoneNumber>" + phone + "</PhoneNumber><Message>Ban truy xuat khong phai tu dia chi ip cua fibo!!</Message><SMSID> -1</SMSID><ServiceNo>" + service + "</ServiceNo></Message></ClientResponse>");
        }
        catch (Exception ex)
        {
            //Xử lý trong trường hợp xảy ra lỗi
            string phone = "";
            string service = "";
            if (Request.QueryString["phone"] != null && Request.QueryString["service"] != null)
            {
                phone = Request.QueryString["phone"].ToString();
                service = Request.QueryString["service"].ToString();
            }
            //Phần này dùng để in nội dung phản hồi ra trang web để FiboSMSGateway nhận và trả về cho khách hàng.
            Response.Write("<ClientResponse><Message><PhoneNumber>" + phone + "</PhoneNumber><Message>Sai cu phap!!!" + ReplaceSpecialCharsForXML(ex.ToString()) + "</Message><SMSID> -1</SMSID><ServiceNo>" + service + "</ServiceNo></Message></ClientResponse>");
        }
        finally
        {
            //Bắt buộc phải có lệnh này
            Response.End();
        }
    }

    //Thay các ký tự đặc biệt không được sử dụng trong XML
    public string ReplaceSpecialCharsForXML(string strString)
    {
        string strRet = "";
        if (strString != null)
        {
            strRet = strString.Replace("\"", "&quot;");
            strRet = strRet.Replace("&", "&amp;");
            strRet = strRet.Replace("’", "&apos;");
            strRet = strRet.Replace("'", "&apos;");
            strRet = strRet.Replace("<", "&lt;");
            strRet = strRet.Replace(">", "&gt;");
        }
        return strRet;
    }
}
