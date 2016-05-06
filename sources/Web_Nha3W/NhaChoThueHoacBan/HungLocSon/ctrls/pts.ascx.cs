using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HungLocSon.BHLS;
using HungLocSon.EHLS;
using HungLocSon.UHLS;
using Subgurim.Controles;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

public partial class ctrls_pts : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (lk() != "")
        {
            if (fp1.IsPosting) this.managePost1();
            if (fp2.IsPosting) this.managePost2();
            if (fp1.IsDeleting) this.manageDel1();
            if (fp2.IsDeleting) this.manageDel2();
            signu.Attributes.Add("onclick", "signu();");
            if (!IsPostBack)
            {
                if (Request.Params["p"] != null)
                {
                    int id = int.Parse(Request.Params["p"].ToString());
                    Pdts(id);
                    signu.Text = "Cập nhật";
                }
                else
                {
                    EPager page = new EPager();
                    page.PageSize = GUHLS.Size;
                    Nwsr();
                    k1.Attributes["class"] = "k1style";
                    oscar();
                    EMember m = new EMember();
                    m.UserName = lk();
                    EProfile f = BMember.PMember(m);
                    ic.Value = f.FullName;
                    it.Value = EncryptM.ToOutput(f.Tel);
                    ml.Value = EncryptM.ToOutput(f.Mobile);
                    ar.Value = f.Address;
                    if (f.Company != null && f.Company != "") nts.Value = f.Company;
                    if (f.Email != null && f.Email != "") nts.Value += " - Email: " + EncryptM.ToOutput(f.Email);
                    if (f.Yahoo != null && f.Yahoo != "") nts.Value += " - Yahoo: " + f.Yahoo;
                    if (f.Website != null && f.Website != "") nts.Value += " - Website: " + f.Website;
                    if (f.Skype != null && f.Skype != "") nts.Value += " - Skype: " + f.Skype;
                }
            }
        }
    }

    private void Pdts(int id)
    {
        EPosts p = new EPosts(id);
        p.UserName = lk();
        p = BPosts.Pdt(p);

        //StringBuilder ly = new StringBuilder(1000);
        //ly.Append("<a class=\"agr1\" href=\"default.aspx\">N3W</a>");
        //string strMap = "";
        ////src="http://maps.google.com/maps/api/staticmap?center=Tran Hung Dao, Quan 1, Ho Chi Minh&zoom=14&size=379x300&markers=color:blue|label:N|Tran Hung Dao, Quan 1, Ho Chi Minh&sensor=true&format=png" 
        //map.Src = "http://maps.google.com/maps/api/staticmap?center=";
        ////Tran Hung Dao, Quan 1, Ho Chi Minh + "&zoom=14&size=379x300&markers=color:blue|label:N|" + Tran Hung Dao, Quan 1, Ho Chi Minh + "&sensor=true&format=png";

        //ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + p.CategoryId + "\">" + p.CateName + "</a>");
        //ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + p.ClassId + "\">" + p.ClassName + "</a>");
        //ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + p.ProjectId + "\">" + p.ProName + "</a>");
        //ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + p.LocationId + "\">" + p.LocaName + "</a>");
        //ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + p.StreetId + "\">" + p.StrName + "</a>");
        //strMap = p.StrName + ",";
        //ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + p.WardId + "\">" + p.WardName + "</a>");
        //strMap += p.WardName + ",";
        //ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + p.DistrictId + "\">" + p.DistrictName + "</a>");
        //strMap += p.DistrictName + ",";
        //ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + p.CityId + "\">" + p.CityName + "</a>");
        //strMap += p.CityName + ",Việt Nam";
        //maph1.Value = "http://maps.google.com/maps/api/staticmap?center=" + strMap;
        //maph2.Value = "&size=379x300&markers=color:blue|label:N|" + strMap + "&sensor=true&format=png";
        //map.Src += strMap + "&zoom=14&size=379x300&markers=color:blue|label:N|" + strMap + "&sensor=true&format=png";

        if (p.IsOwner) rc.Checked = true;// ly.Append(" » Chính chủ");
        else rm.Checked = true;// ly.Append(" » Môi giới");

        Nwsr();
        Utilities();

        title.Value = p.Title.ToString();
        descript.Value = p.Description.ToString();

        n3w2.SelectedValue = p.ClassId.ToString();
        n3w3.SelectedValue = p.LocationId.ToString();
        n3w4.SelectedValue = p.CityId.ToString();

        EDistricts dt = new EDistricts();
        dt.CityId = p.CityId;
        n3w6.Items.Clear();
        Districts(dt);

        n3w6.SelectedValue = p.DistrictId.ToString();

        EWards wr = new EWards();
        wr.DistrictId = p.DistrictId;
        n3w7.Items.Clear();
        Wards(wr);

        if (p.WardId > 0) n3w7.SelectedValue = p.WardId.ToString();

        EStreets t = new EStreets();
        t.DistrictId = p.DistrictId;
        n3w8.Items.Clear();
        Streets(t);

        if (p.StreetId > 0) n3w8.SelectedValue = p.StreetId.ToString();
        fa.Value = p.LotNumber;

        EProjects pj = new EProjects();
        pj.DistrictId = p.DistrictId;
        n3w9.Items.Clear();
        Projects(pj);

        if (p.ProjectId.ToString() != null && p.ProjectId > 0) n3w9.SelectedValue = p.ProjectId.ToString();

        Session["iptn3w"] = p.CreationDate.Year.ToString() + "/" + p.CreationDate.Month.ToString() + "/" + id.ToString();
        //hls1.InnerHtml = p.Title;
        //hls5.InnerHtml = p.Title;
        //if (p.IsVip)
        //{
        //    hls2.Visible = true;
        //}
        //else if (p.Silver && !p.IsVip)
        //{
        //    hls2s.Visible = true;
        //}

        if (p.HaveHouses)
        {
            //ihs.Src = "../pros/" + p.Images;
            EHouses eh = new EHouses();
            eh.PostId = id;
            List<EHouses> lh = new List<EHouses>();
            lh = BHouses.utis2(eh);
            //lh = BHouses.utis(eh);
            gImages.DataSource = lh;
            gImages.DataBind();
            fp1.MaxFiles = 10 - lh.Count;
            fp2.Visible = false;
        }
        //else
        //{
        //    ihs.Src = "../pros/villav.jpg";
        //}


        switch (p.CategoryId)
        {
            case 2:
                {
                    r2.Checked = true; break;
                    //hls3.Src = "../images/ico_chothue.gif";
                    //hls3.Alt = "Cho thuê";
                    //break;
                }
            case 3:
                {
                    r3.Checked = true; break;
                    //hls3.Src = "../images/ico_canmua.gif";
                    //hls3.Alt = "Cần mua";
                    //break;
                }
            case 4:
                {
                    r4.Checked = true; break;
                    //hls3.Src = "../images/ico_canthue.gif";
                    //hls3.Alt = "Cần thuê";
                    //break;
                }
            case 5:
                {
                    r5.Checked = true;
                    break;
                    //hls3.Src = "../images/ico_canban.gif";
                    //hls3.Alt = "Cần bán";
                    //break;
                }
            default:
                {
                    r1.Checked = true; break;
                    //hls3.Src = "../images/ico_canban.gif";
                    //hls3.Alt = "Cần bán";
                    //break;
                }
        }

        //if (p.IsOwner)
        //{
        //    hls4.InnerHtml = id + " - CC";
        //}
        //else
        //{
        //    hls4.InnerHtml = id + " - MG";
        //}

        //DateTime ag = p.Updated;
        //TimeSpan ts = DateTime.Now - ag;
        //if (ts.Days > 0 && ts.Days <= 7)
        //{
        //    hls4.InnerHtml += " : " + ts.Days + " ngày";
        //}
        //else if (ts.Days == 0 && ts.Hours > 0)
        //{
        //    hls4.InnerHtml += " : " + ts.Hours + "h";
        //}
        //else if (ts.Minutes > 0 && ts.Hours == 0)
        //{
        //    hls4.InnerHtml += " : " + ts.Minutes + "'";
        //}
        //else if (ts.Minutes == 0 && ts.Seconds > 0)
        //{
        //    hls4.InnerHtml += " : " + ts.Seconds + "''";
        //}

        pvalue.Value = string.Format("{0:0,0}",p.Values);

        if (p.Percents > 0) 
        {
            k1.Attributes["class"] = "k1style2";
            r7.Checked = true; 
            agen1.Value = p.Percents.ToString();
            //genc.Visible = true; 
            //agen1.Visible = true;
        }

        if (p.CurrencyId == 1)
        {
            //hls6.InnerHtml = Changes2((int)p.Values);
            //hls7.InnerHtml = string.Format("{0:0,0}", ((int)p.Values / GUHLS.SJC)) + " lượng";
            //hls8.InnerHtml = string.Format("{0:0,0}", ((int)p.Values / GUHLS.USD)) + " usd";
            //vnd.Attributes["class"] = "vdt";
            //v1.Attributes["class"] = "vss";
            kpri.SelectedIndex = 0;
        }
        else if (p.CurrencyId == 2)
        {
            //int v = (int)(GUHLS.USD * p.Values);
            //hls6.InnerHtml = Changes2(v);
            //hls7.InnerHtml = string.Format("{0:0,0}", ((int)v / GUHLS.SJC)) + " lượng";
            //hls8.InnerHtml = string.Format("{0:0,0}", p.Values) + " usd";
            //usd.Attributes["class"] = "vdt";
            //u1.Attributes["class"] = "vss";

            kpri.SelectedIndex = 1;
        }
        else
        {
            //int s = (GUHLS.SJC * (int)p.Values);
            //hls6.InnerHtml = Changes2(s);
            //hls7.InnerHtml = string.Format("{0:0,0}", (int)p.Values) + " lượng";
            //hls8.InnerHtml = string.Format("{0:0,0}", (s / GUHLS.USD)) + " usd";
            //sjc.Attributes["class"] = "vdt";
            //s1.Attributes["class"] = "vss";

            kpri.SelectedIndex = 2;
        }

        if (p.UnitId == 2)
        {
            //hls6.InnerHtml += "/m2";
            //hls7.InnerHtml += "/m2";
            //hls8.InnerHtml += "/m2";

            upri.SelectedIndex = 1;
        }
        else if (p.UnitId == 3)
        {
            upri.SelectedIndex = 2;

            //hls6.InnerHtml += "/tháng";
            //hls7.InnerHtml += "/tháng";
            //hls8.InnerHtml += "/tháng";
        }

        EProperties pro = new EProperties(id);
        pro = BProperties.pro(pro);
        //if (pro.SittingRoom != 0) stt.InnerHtml = pro.SittingRoom.ToString();
        //if (pro.BedRoom != 0) bed.InnerHtml = pro.BedRoom.ToString();
        //if (pro.BathRoom != 0) bat.InnerHtml = pro.BathRoom.ToString();
        //if (pro.Other != 0) oth.InnerHtml = pro.Other.ToString();

        w.Value = p.Width;
        l.Value = p.Length;
        area.Value = p.Area.ToString();

        //wi.InnerHtml = p.Width + " m x " + p.Length + " m";
        //are.InnerHtml = p.Area + " m";

        ic.Value = p.ContactName;
        it.Value = EncryptM.ToOutput(p.Tel);
        ml.Value = EncryptM.ToOutput(p.Mobile);
        ar.Value = p.Address;
        nts.Value = p.Notes;

        //cname.InnerHtml = p.ContactName;
        //cph.InnerHtml = p.Tel;
        //cmb.InnerHtml = p.Mobile;
        //ca.InnerHtml = p.Address;
        //cnt.InnerHtml = p.Notes;

        //hls9.InnerHtml = p.Description;
        //are2.InnerHtml = p.Area.ToString();
        //wi2.InnerHtml = p.Width;
        //le2.InnerHtml = p.Length;

        if (pro.DocId.ToString() != null && pro.DocId > 0) doc.SelectedValue = pro.DocId.ToString();
        if (pro.SetId.ToString() != null && pro.SetId > 0) set.SelectedValue = pro.SetId.ToString();
        if (pro.SizeOfLane > 0) land.Value = pro.SizeOfLane.ToString();

        if (pro.Floor > 0) flor.Value = pro.Floor.ToString();
        if (pro.SittingRoom > 0) liv.SelectedValue = pro.SittingRoom.ToString();
        if (pro.BedRoom > 0) bed.SelectedValue = pro.BedRoom.ToString();
        if (pro.BathRoom > 0) bro.SelectedValue = pro.BathRoom.ToString();
        if (pro.Other > 0) othr.SelectedValue = pro.Other.ToString();

        ///////////////////////////////

        //hls10.InnerHtml = p.ClassName;
        //hls11.InnerHtml = pro.DocName;
        //hls12.InnerHtml = pro.SetName;
        //ly.Append(" » <a class=\"agr\" href=\"default.aspx?c=" + pro.SetId + "\">" + pro.SetName + "</a>");
        //if (pro.SizeOfLane > 0) hls13.InnerHtml = pro.SizeOfLane.ToString();
        //else hls13.InnerHtml = "_";
        //hls14.InnerHtml = p.LocaName;

        //if (pro.Floor > 0) hls15.InnerHtml = pro.Floor.ToString();
        //else hls15.InnerHtml = "_";
        //if (pro.SittingRoom > 0) hls16.InnerHtml = pro.SittingRoom.ToString();
        //else hls16.InnerHtml = "_";
        //if (pro.BedRoom > 0) hls17.InnerHtml = pro.BedRoom.ToString();
        //else hls17.InnerHtml = "_";
        //if (pro.BathRoom > 0) hls18.InnerHtml = pro.BathRoom.ToString();
        //else hls18.InnerHtml = "_";
        //if (pro.Other > 0) hls19.InnerHtml = pro.Other.ToString();
        //else hls19.InnerHtml = "_";

        List<EUtilities> eu = new List<EUtilities>();
        pro.PostId = id;
        eu = BUtilities.utis(pro);
        foreach (EUtilities j in eu)
        {
            if (j.UtilityId == 1)
            {
                us1.Checked = true;
            }
            else if (j.UtilityId == 2)
            {
                us2.Checked = true;
            }
            else if (j.UtilityId == 3)
            {
                us3.Checked = true;
            }
            else if (j.UtilityId == 4)
            {
                us4.Checked = true;
            }
            else if (j.UtilityId == 5)
            {
                us5.Checked = true;
            }
            else if (j.UtilityId == 6)
            {
                us6.Checked = true;
            }
            else if (j.UtilityId == 7)
            {
                us7.Checked = true;
            }
            else if (j.UtilityId == 8)
            {
                us8.Checked = true;
            }
            else if (j.UtilityId == 9)
            {
                us9.Checked = true;
            }
        }

        //hls29.InnerHtml = p.UserName;
        //stay.InnerHtml += ly.ToString();
    }

    private string ihn(string i)
    {
        int a = 0;
        if (i.Contains(".jpg")) a = 1;
        else if (i.Contains(".JPG")) a = 2;
        else if (i.Contains(".gif")) a = 3;
        else if (i.Contains(".GIF")) a = 4;
        else if (i.Contains(".png")) a = 5;
        else if (i.Contains(".PNG")) a = 6;

        switch (a)
        {
            case 1:
                {
                    i = i.Replace(".jpg", "");
                    i = i + GUHLS.NetId() + ".jpg";
                    break;
                }
            case 2:
                {
                    i = i.Replace(".JPG", "");
                    i = i + GUHLS.NetId() + ".jpg";
                    break;
                }
            case 3:
                {
                    i = i.Replace(".gif", "");
                    i = i + GUHLS.NetId() + ".gif";
                    break;
                }
            case 4:
                {
                    i = i.Replace(".GIF", "");
                    i = i + GUHLS.NetId() + ".gif";
                    break;
                }
            case 5:
                {
                    i = i.Replace(".png", "");
                    i = i + GUHLS.NetId() + ".png";
                    break;
                }
            case 6:
                {
                    i = i.Replace(".PNG", "");
                    i = i + GUHLS.NetId() + ".png";
                    break;
                }
        }
        return i;
    }

    private void oscar()
    {
        int a = 0, c = 0, d = 0;
        BPosts.solos(ref a, ref c, ref d);
        a += 1;
        HungLocSon.Tools.WebTools.CreateFolder("~/pros/" + d.ToString());
        HungLocSon.Tools.WebTools.CreateFolder("~/pros/" + d.ToString() + "/" + c.ToString());
        HungLocSon.Tools.WebTools.CreateFolder("~/pros/" + d.ToString() + "/" + c.ToString() + "/" + a.ToString());
        HungLocSon.Tools.WebTools.CreateFolder("~/pros/" + d.ToString() + "/" + c.ToString() + "/" + a.ToString() + "/thumbs");
        Session["iptn3w"] = null;
    }

    private void colo(HttpPostedFileAJAX pf)
    {
        string n3wi = ihn(pf.FileName);
        //System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~\\" + "pros/tpls/" + pf.FileName));
        //Bitmap bmp = img as Bitmap;
        byte[] imgData = getData(Server.MapPath("~\\" + "pros/tpls/" + pf.FileName));
        System.Drawing.Image img = System.Drawing.Image.FromStream(new System.IO.MemoryStream(imgData));
        Bitmap bmp = new Bitmap(new Bitmap(img));
        // remove test Graphics g = Graphics.FromImage(bmp); 
        Bitmap bmpNew = new Bitmap(bmp);
        bmp.Dispose();
        img.Dispose();
        //code to manipulate bmpNew goes here.
        Bitmap log = new Bitmap(Server.MapPath("~/prom/nha3wlgo.png"));
        bmpNew = EncryptM.CreateThumbnail(bmpNew, 379, 300);
        bmpNew = EncryptM.ChangeLogo(bmpNew, log, bmpNew.Width - 32, bmpNew.Height - 32);
        if (Session["iptn3w"] == null || Session["iptn3w"].ToString() == "")
        {
            int a = 0, c = 0, d = 0;
            BPosts.solos(ref a, ref c, ref d);
            a += 1;
            Session["iptn3w"] = d.ToString() + "/" + c.ToString() + "/" + a.ToString();
        }
        //bmpNew.Save(Server.MapPath("~/pros/" + d.ToString() + "/" + c.ToString() + "/" + a.ToString() + "/") + n3wi);
        if (Session["iptn3w"] != null && Session["iptn3w"].ToString() != "")
        {
            bmpNew.Save(Server.MapPath("~/pros/" + Session["iptn3w"].ToString() + "/") + n3wi);
            bmpNew.Dispose();
            crble(n3wi);
        }
    }

    private byte[] getData(string filePath)
    {
        System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
        byte[] data = br.ReadBytes((int)fs.Length);
        br.Close();
        fs.Close();
        return data;
    }


    private void managePost1()
    {
        HttpPostedFileAJAX pf = fp1.PostedFile;
        if ((pf.Type == HttpPostedFileAJAX.fileType.image) && (pf.ContentLength <= 5 * 1024 * 1024))
        {
            fp1.SaveAs("pros/tpls", pf.FileName);
            colo(pf);
        }
        fp1.PostedFile.responseMessage_Uploaded_NotSaved = "<span style=\"font-family: Tahoma; font-size: 11px;\">File không hợp lệ.</span>";
    }

    private void manageDel1()
    {
        List<HttpPostedFileAJAX> pf = new List<HttpPostedFileAJAX>();
        pf = fp1.historial;
        dso(pf);
        //if (pf != null)
        //{
        //    if (pf.Count > 0)
        //    {
        //        for (int i = 0; i < pf.Count; i++)
        //        {
        //            if (pf[i].Deleted)
        //            {
        //                if (Session["iptn3w"] != null && Session["iptn3w"].ToString() != "")
        //                {
        //                    string a = Session["iptn3w"].ToString();
        //                    string f1 = Server.MapPath("~/pros/" + a + "/thumbs/" + ihn(pf[i].FileName));
        //                    if (System.IO.File.Exists(f1)) System.IO.File.Delete(f1);
        //                    string f2 = Server.MapPath("~/pros/" + a + "/" + ihn(pf[i].FileName));
        //                    if (System.IO.File.Exists(f2)) System.IO.File.Delete(f2);
        //                }
        //            }
        //        }
        //    }
        //}
    }

    private void dso(List<HttpPostedFileAJAX> pf)
    {
        if (pf != null)
        {
            if (pf.Count > 0)
            {
                for (int i = 0; i < pf.Count; i++)
                {
                    if (pf[i].Deleted)
                    {
                        if (Session["iptn3w"] != null && Session["iptn3w"].ToString() != "")
                        {
                            string a = Session["iptn3w"].ToString();
                            string f1 = Server.MapPath("~/pros/" + a + "/thumbs/" + ihn(pf[i].FileName));
                            if (System.IO.File.Exists(f1)) System.IO.File.Delete(f1);
                            string f2 = Server.MapPath("~/pros/" + a + "/" + ihn(pf[i].FileName));
                            if (System.IO.File.Exists(f2)) System.IO.File.Delete(f2);
                        }
                    }
                }
            }
        }
    }

    private void manageDel2()
    {
        List<HttpPostedFileAJAX> pf = new List<HttpPostedFileAJAX>();
        pf = fp2.historial;
        dso(pf);
    }

    private void crble(string filename)
    {
        string f1 = filename;
        filename = "~/pros/" + Session["iptn3w"].ToString() + "/" + filename;
        System.Drawing.Image image = System.Drawing.Image.FromFile(Server.MapPath(filename));
        using (System.Drawing.Image bigImage = new Bitmap(Server.MapPath(filename)))
        {
            int height = bigImage.Height / 7;
            int width = bigImage.Width / 7;
            using (System.Drawing.Image smallImage = image.GetThumbnailImage(width, height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero))
            {
                smallImage.Save(Server.MapPath("~\\" + "pros/" + Session["iptn3w"].ToString() + "/thumbs/" + f1), System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }

    private bool ThumbnailCallback()
    {
        return false;
    }

    private void managePost2()
    {
        HttpPostedFileAJAX pf = fp2.PostedFile;
        if ((pf.Type == HttpPostedFileAJAX.fileType.image) && (pf.ContentLength <= 5 * 1024 * 1024))
        {
            fp2.SaveAs("pros/tpls", pf.FileName);
            colo(pf);
        }
        fp2.PostedFile.responseMessage_Uploaded_NotSaved = "<span style=\"font-family: Tahoma; font-size: 11px;\">File không hợp lệ.</span>";
    }

    private void Nwsr()
    {
        int i = -1;
        int j = 0;

        List<EClasses> l = new List<EClasses>();
        l = BClasses.Classes();
        i = -1;
        j = 0;
        while (l.Count > 0 && j < l.Count)
        {
            if (i == -1)
            {
                n3w2.Items.Add("Danh mục địa ốc");
                n3w2.Items[i + 1].Value = "-1";
                i++;
                n3w2.Items.Add("---------------");
                n3w2.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w2.Items.Add(l[j].ClassName);
            n3w2.Items[i].Value = l[j].ClassId.ToString();
            i++;
            j++;
        }

        List<ELocations> lt = new List<ELocations>();
        lt = BLocations.Locations();
        i = -1;
        j = 0;
        while (lt.Count > 0 && j < lt.Count)
        {
            if (i == -1)
            {
                n3w3.Items.Add("Vị trí địa ốc");
                n3w3.Items[i + 1].Value = "-1";
                i++;
                n3w3.Items.Add("---------------");
                n3w3.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w3.Items.Add(lt[j].LocaName);
            n3w3.Items[i].Value = lt[j].LocationId.ToString();
            i++;
            j++;
        }

        List<ECities> y = new List<ECities>();
        y = BCities.Cities();
        i = -1;
        j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                n3w4.Items.Add("Tỉnh/Thành phố");
                n3w4.Items[i + 1].Value = "-1";
                i++;
                n3w4.Items.Add("---------------");
                n3w4.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w4.Items.Add(y[j].CityName);
            n3w4.Items[i].Value = y[j].CityId.ToString();
            i++;
            j++;
        }

        List<ESets> st = new List<ESets>();
        st = BSets.Sets();
        set.Items.Clear();
        i = -1;
        j = 0;
        while (st.Count > 0 && j < st.Count)
        {
            if (i == -1)
            {
                set.Items.Add("Hướng");
                set.Items[i + 1].Value = "-1";
                i++;
                set.Items.Add("---------------");
                set.Items[i + 1].Value = "0";
                i += 2;
            }
            set.Items.Add(st[j].SetName);
            set.Items[i].Value = st[j].SetId.ToString();
            i++;
            j++;
        }

        List<EDocuments> dc = new List<EDocuments>();
        dc = BDocuments.Documents();
        doc.Items.Clear();
        i = -1;
        j = 0;
        while (dc.Count > 0 && j < dc.Count)
        {
            if (i == -1)
            {
                doc.Items.Add("Tình trạng pháp lý");
                doc.Items[i + 1].Value = "-1";
                i++;
                doc.Items.Add("---------------");
                doc.Items[i + 1].Value = "0";
                i += 2;
            }
            doc.Items.Add(dc[j].DocName);
            doc.Items[i].Value = dc[j].DocId.ToString();
            i++;
            j++;
        }
    }

    private void Utilities()
    {
        int i = -1;
        int j = 0;
        flor.Items.Clear();
        while (j < 70)
        {
            if (i == -1)
            {
                flor.Items.Add("Số lầu");
                flor.Items[i + 1].Value = "-1";
                i++;
                flor.Items.Add("---------------");
                flor.Items[i + 1].Value = "0";
                i += 2;
            }
            flor.Items.Add((j + 1).ToString());
            flor.Items[i].Value = (j+1).ToString();
            i++;
            j++;
        }

        i = -1;
        j = 0;
        liv.Items.Clear();
        while (j < 20)
        {
            if (i == -1)
            {
                liv.Items.Add("Phòng khách");
                liv.Items[i + 1].Value = "-1";
                i++;
                liv.Items.Add("---------------");
                liv.Items[i + 1].Value = "0";
                i += 2;
            }
            liv.Items.Add((j + 1).ToString());
            liv.Items[i].Value = (j + 1).ToString();
            i++;
            j++;
        }

        i = -1;
        j = 0;
        bed.Items.Clear();
        while (j < 70)
        {
            if (i == -1)
            {
                bed.Items.Add("Phòng ngủ");
                bed.Items[i + 1].Value = "-1";
                i++;
                bed.Items.Add("---------------");
                bed.Items[i + 1].Value = "0";
                i += 2;
            }
            bed.Items.Add((j + 1).ToString());
            bed.Items[i].Value = (j + 1).ToString();
            i++;
            j++;
        }

        i = -1;
        j = 0;
        bro.Items.Clear();
        while (j < 70)
        {
            if (i == -1)
            {
                bro.Items.Add("Phòng tắm/vệ sinh");
                bro.Items[i + 1].Value = "-1";
                i++;
                bro.Items.Add("---------------");
                bro.Items[i + 1].Value = "0";
                i += 2;
            }
            bro.Items.Add((j + 1).ToString());
            bro.Items[i].Value = (j + 1).ToString();
            i++;
            j++;
        }

        i = -1;
        j = 0;
        othr.Items.Clear();
        while (j < 4)
        {
            if (i == -1)
            {
                othr.Items.Add("Phòng khác");
                othr.Items[i + 1].Value = "-1";
                i++;
                othr.Items.Add("---------------");
                othr.Items[i + 1].Value = "0";
                i += 2;
            }
            othr.Items.Add((j + 1).ToString());
            othr.Items[i].Value = (j + 1).ToString();
            i++;
            j++;
        }
    }


    private void Districts(EDistricts d)
    {
        List<EDistricts> y = new List<EDistricts>();
        y = BDistricts.Districts(d);
        int i = -1;
        int j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                n3w6.Items.Add("Quận/Huyện");
                n3w6.Items[i + 1].Value = "-1";
                i++;
                n3w6.Items.Add("-----------");
                n3w6.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w6.Items.Add(y[j].DistrictName);
            n3w6.Items[i].Value = y[j].DistrictId.ToString();
            i++;
            j++;
        }

        Utilities();
    }

    private void Wards(EWards w)
    {
        List<EWards> y = new List<EWards>();
        y = BWards.Wards(w);
        int i = -1;
        int j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                n3w7.Items.Add("Phường/Xã");
                n3w7.Items[i + 1].Value = "-1";
                i++;
                n3w7.Items.Add("-----------");
                n3w7.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w7.Items.Add(y[j].WardName);
            n3w7.Items[i].Value = y[j].WardId.ToString();
            i++;
            j++;
        }
    }

    private void Streets(EStreets w)
    {
        List<EStreets> y = new List<EStreets>();
        if (w.DistrictId > 0) y = BStreets.Streets(w);
        else if (w.WardId > 0) y = BStreets.Streets2(w);
        int i = -1;
        int j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                n3w8.Items.Add("Tên đường");
                n3w8.Items[i + 1].Value = "-1";
                i++;
                n3w8.Items.Add("-----------");
                n3w8.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w8.Items.Add(y[j].Name);
            n3w8.Items[i].Value = y[j].StreetId.ToString();
            i++;
            j++;
        }
    }

    private void Projects(EProjects w)
    {
        List<EProjects> y = new List<EProjects>();
        y = BProjects.Projects(w);
        int i = -1;
        int j = 0;
        while (y.Count > 0 && j < y.Count)
        {
            if (i == -1)
            {
                n3w9.Items.Add("Dự án địa ốc");
                n3w9.Items[i + 1].Value = "-1";
                i++;
                n3w9.Items.Add("-----------");
                n3w9.Items[i + 1].Value = "0";
                i += 2;
            }
            n3w9.Items.Add(y[j].ProjectName);
            n3w9.Items[i].Value = y[j].ProjectId.ToString();
            i++;
            j++;
        }
    }

    protected void n3w4_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = int.Parse(n3w4.SelectedValue);
        if (i > 0)
        {
            EDistricts dt = new EDistricts();
            dt.CityId = i;
            n3w6.Items.Clear();
            Districts(dt);
        }
    }

    protected void n3w6_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = int.Parse(n3w6.SelectedValue);
        if (i > 0)
        {
            EWards w = new EWards();
            w.DistrictId = i;
            n3w7.Items.Clear();
            Wards(w);
            EStreets t = new EStreets();
            t.DistrictId = i;
            n3w8.Items.Clear();
            Streets(t);
            EProjects p = new EProjects();
            p.DistrictId = i;
            n3w9.Items.Clear();
            Projects(p);
        }
    }
    protected void n3w7_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = int.Parse(n3w7.SelectedValue);
        if (i > 0)
        {
            EStreets t = new EStreets();
            t.WardId = i;
            n3w8.Items.Clear();
            Streets(t);
        }
    }
    protected void signu_Click(object sender, EventArgs e)
    {
        subpst();
    }

    private void isimg(int j)
    {
        List<HttpPostedFileAJAX> fpn = new List<HttpPostedFileAJAX>();
        fpn = fp1.historial;
        List<HttpPostedFileAJAX> fpn2 = new List<HttpPostedFileAJAX>();
        fpn2 = fp2.historial;

        if (fpn != null)
        {
            if (fpn.Count > 0)
            {
                for (int i = 0; i < fpn.Count; i++)
                {
                    if (fpn[i].Deleted)
                    {
                        if (Session["iptn3w"] != null && Session["iptn3w"].ToString() != "")
                        {
                            string a = Session["iptn3w"].ToString();
                            string f1 = Server.MapPath("~/pros/" + a + "/thumbs/" + ihn(fpn[i].FileName));
                            if (System.IO.File.Exists(f1)) System.IO.File.Delete(f1);
                            string f2 = Server.MapPath("~/pros/" + a + "/" + ihn(fpn[i].FileName));
                            if (System.IO.File.Exists(f2)) System.IO.File.Delete(f2);
                        }
                        //string f1 = Server.MapPath("~/pros/thumbs/" + ihn(fpn[i].FileName));
                        //if (System.IO.File.Exists(f1)) System.IO.File.Delete(f1);
                        //string f2 = Server.MapPath("~/pros/" + ihn(fpn[i].FileName));
                        //if (System.IO.File.Exists(f2)) System.IO.File.Delete(f2);
                    }
                    else
                    {
                        EHouses t = new EHouses();
                        t.Images = ihn(fpn[i].FileName);
                        if (j>0) 
                        {
                            t.PostId = j;
                            BHouses.UHouses(t);
                        }
                        else BHouses.IHouses(t);
                    }
                    //string f3 = Server.MapPath("~/pros/" + fpn[i].FileName);
                    //if (System.IO.File.Exists(f3)) System.IO.File.Delete(f3);
                }
            }
            fp1.historial.Clear();
        }
        if (fpn2 != null)
        {
            if (fpn2.Count > 0)
            {
                for (int i = 0; i < fpn2.Count; i++)
                {
                    if (fpn2[i].Deleted)
                    {
                        if (Session["iptn3w"] != null && Session["iptn3w"].ToString() != "")
                        {
                            string a = Session["iptn3w"].ToString();
                            string f3 = Server.MapPath("~/pros/" + a + "/thumbs/" + ihn(fpn2[i].FileName));
                            if (System.IO.File.Exists(f3)) System.IO.File.Delete(f3);
                            string f4 = Server.MapPath("~/pros/" + a + "/" + ihn(fpn2[i].FileName));
                            if (System.IO.File.Exists(f4)) System.IO.File.Delete(f4);
                        }
                        //string f1 = Server.MapPath("~/pros/thumbs/" + ihn(fpn2[i].FileName));
                        //if (System.IO.File.Exists(f1)) System.IO.File.Delete(f1);
                        //string f2 = Server.MapPath("~/pros/" + ihn(fpn2[i].FileName));
                        //if (System.IO.File.Exists(f2)) System.IO.File.Delete(f2);
                    }
                    else
                    {
                        EHouses t = new EHouses();
                        t.Images = ihn(fpn2[i].FileName);
                        if (j > 0)
                        {
                            t.PostId = j;
                            BHouses.UHouses(t);
                        }
                        else BHouses.IHouses(t);
                    }
                    //string f3 = Server.MapPath("~/pros/" + fpn2[i].FileName);
                    //if (System.IO.File.Exists(f3)) System.IO.File.Delete(f3);
                }
            }
            fp2.historial.Clear();
        }
        Session["iptn3w"] = null;
    }

    private string rplc(string a)
    {
        a = a.Replace("\n", "<br/>");
        a = a.Replace("<", "&lt;");
        a = a.Replace(">", "&gt;");
        a = a.Replace("&lt;br/&gt;", "<br/>");
        return a;
    }

    private void subpst()
    {
        if (avail())
        {
            EPosts pst = new EPosts();
            if (r1.Checked) pst.CategoryId = 1;
            else if (r2.Checked) pst.CategoryId = 2;
            else if (r3.Checked) pst.CategoryId = 3;
            else if (r4.Checked) pst.CategoryId = 4;
            else if (r5.Checked) pst.CategoryId = 5;
            if (rm.Checked) pst.IsOwner = false;
            else if (rc.Checked) pst.IsOwner = true;
            if (n3w2.SelectedValue != "-1" && n3w2.SelectedValue != "0") pst.ClassId = int.Parse(n3w2.SelectedValue);
            if (n3w3.SelectedValue != "-1" && n3w3.SelectedValue != "0") pst.LocationId = int.Parse(n3w3.SelectedValue);
            pst.CountryId = 1;
            if (n3w4.SelectedValue != "-1" && n3w4.SelectedValue != "0") pst.CityId = int.Parse(n3w4.SelectedValue);
            if (n3w6.SelectedValue != "-1" && n3w6.SelectedValue != "0") pst.DistrictId = int.Parse(n3w6.SelectedValue);
            if (n3w7.SelectedValue != "-1" && n3w7.SelectedValue != "0" && n3w7.SelectedValue != "") pst.WardId = int.Parse(n3w7.SelectedValue);
            pst.LotNumber = fa.Value;
            if (n3w8.SelectedValue != "-1" && n3w8.SelectedValue != "0" && n3w8.SelectedValue != "") pst.StreetId = int.Parse(n3w8.SelectedValue);
            if (n3w9.SelectedValue != "-1" && n3w9.SelectedValue != "0" && n3w9.SelectedValue != "") pst.ProjectId = int.Parse(n3w9.SelectedValue);
            if (pvalue.Value != "") pst.Values = float.Parse(pvalue.Value);
            if (kpri.Value == "vnd") pst.CurrencyId = 1;
            else if (kpri.Value == "usd") pst.CurrencyId = 2;
            else if (kpri.Value == "sjc") pst.CurrencyId = 3;
            if (upri.Value == "ar") pst.UnitId = 1;
            else if (upri.Value == "m2") pst.UnitId = 2;
            else if (upri.Value == "mon") pst.UnitId = 3;
            if (r6.Checked) pst.Percents = 0;
            else if (r7.Checked && agen1.Value != "") pst.Percents = int.Parse(agen1.Value);
            pst.Area = float.Parse(area.Value);
            if (w.Value != "" && w.Value != "Chiều ngang") pst.Width = w.Value;
            else pst.Width = "";
            if (l.Value != "" && l.Value != "Chiều dài") pst.Length = l.Value;
            else pst.Length = "";

            GUHLS at = new GUHLS();
            pst.Title = rplc(at.ReleaseInput(title.Value, 145));
            pst.Description = rplc(descript.Value);

            EProperties pr = new EProperties();
            if (doc.SelectedValue != "-1" && doc.SelectedValue != "0") pr.DocId = int.Parse(doc.SelectedValue);
            if (set.SelectedValue != "-1" && set.SelectedValue != "0") pr.SetId = int.Parse(set.SelectedValue);
            if (land.Value != "-1" && land.Value != "0") pr.SizeOfLane = int.Parse(land.Value);
            if (flor.Value != "-1" && flor.Value != "0") pr.Floor = int.Parse(flor.Value);
            if (liv.SelectedValue != "-1" && liv.SelectedValue != "0") pr.SittingRoom = int.Parse(liv.SelectedValue);
            if (bed.SelectedValue != "-1" && bed.SelectedValue != "0") pr.BedRoom = int.Parse(bed.SelectedValue);
            if (bro.SelectedValue != "-1" && bro.SelectedValue != "0") pr.BathRoom = int.Parse(bro.SelectedValue);
            if (othr.SelectedValue != "-1" && othr.SelectedValue != "0") pr.Other = int.Parse(othr.SelectedValue);

            pst.ContactName = ic.Value;
            pst.Tel = EncryptM.ToInput(it.Value);
            pst.Mobile = EncryptM.ToInput(ml.Value);
            pst.Address = ar.Value;
            pst.Notes = nts.Value;
            pst.HaveHouses = false;
            pst.IsVip = false;
            pst.Expiration = DateTime.Now.AddMonths(2);
            pst.IP = HttpContext.Current.Request.UserHostAddress;
            pst.UserName = lk();
            //pst.ByUser = "admin";
            EAuthorizations aut = new EAuthorizations();
            EMember mr = new EMember();
            mr.UserName = lk();
            aut = BAuthorizations.Authors2(mr);

            //pst.ByUser = "";
            if (aut.IsApproved) { pst.StateId = 2; pst.ByUser = ""; }
            else
            {
                pst.StateId = 1;
                pst.ByUser = lk();
            }

            pst.Silver = false;
            if (aut.Post && Request.Params["p"] == null)
            {
                int a = BPosts.IPost(pst, pr);
                EUtilities us = new EUtilities();
                if (us1.Checked) { us.UtilityId = 1; BUtilities.IUtilities(us); }
                if (us2.Checked) { us.UtilityId = 2; BUtilities.IUtilities(us); }
                if (us3.Checked) { us.UtilityId = 3; BUtilities.IUtilities(us); }
                if (us4.Checked) { us.UtilityId = 4; BUtilities.IUtilities(us); }
                if (us5.Checked) { us.UtilityId = 5; BUtilities.IUtilities(us); }
                if (us6.Checked) { us.UtilityId = 6; BUtilities.IUtilities(us); }
                if (us7.Checked) { us.UtilityId = 7; BUtilities.IUtilities(us); }
                if (us8.Checked) { us.UtilityId = 8; BUtilities.IUtilities(us); }
                if (us9.Checked) { us.UtilityId = 9; BUtilities.IUtilities(us); }

                isimg(0);
                BServer.Remove("Posts", true);
                Response.Redirect("details.aspx?p=" + a);
            }
            else if (Request.Params["p"] != null && aut.Edit)
            {
                pst.PostId = int.Parse(Request.Params["p"].ToString());
                EPosts p2 = new EPosts(pst.PostId);
                p2.UserName = lk();
                p2 = BPosts.Pdt(p2);
                EModerAuthors autr = new EModerAuthors();
                EMember mrr = new EMember();
                mrr.UserName = lk();
                autr = BModerAuthors.ModerAuthors2(mrr);
                if (p2.UserName.ToLower() == lk().ToLower() || autr.Edit)
                {
                    if (p2.UserName.ToLower() != lk().ToLower())
                    {
                        pst.UserName = p2.UserName;
                    }
                    if (p2.Silver) pst.Silver = true;
                    else if (p2.IsVip) pst.IsVip = true;

                    BPosts.UPost(pst, pr);

                    EUtilities us = new EUtilities();
                    us.PostId = int.Parse(Request.Params["p"].ToString());

                    if (us1.Checked) { us.UtilityId = 1; BUtilities.UUtilities(us); }
                    if (us2.Checked) { us.UtilityId = 2; BUtilities.UUtilities(us); }
                    if (us3.Checked) { us.UtilityId = 3; BUtilities.UUtilities(us); }
                    if (us4.Checked) { us.UtilityId = 4; BUtilities.UUtilities(us); }
                    if (us5.Checked) { us.UtilityId = 5; BUtilities.UUtilities(us); }
                    if (us6.Checked) { us.UtilityId = 6; BUtilities.UUtilities(us); }
                    if (us7.Checked) { us.UtilityId = 7; BUtilities.UUtilities(us); }
                    if (us8.Checked) { us.UtilityId = 8; BUtilities.UUtilities(us); }
                    if (us9.Checked) { us.UtilityId = 9; BUtilities.UUtilities(us); }

                    isimg(pst.PostId);
                    BServer.Remove("Posts", true);
                    Response.Redirect("details.aspx?p=" + pst.PostId);
                }
            }
        }
    }

    private bool avail()
    {
        bool a = true;
        StringBuilder h = new StringBuilder(1000);
        
        if (n3w2.SelectedValue == "-1" || n3w2.SelectedValue == "0")
        {
            a = false; //chua chon loai dia oc
            h.Append("Bạn chưa chọn loại địa ốc<br/>");
        }
        if (n3w3.SelectedValue == "-1" || n3w3.SelectedValue == "0")
        {
            a = false;
            h.Append("Bạn chưa chọn vị trí địa ốc<br/>");
        }
        if (n3w4.SelectedValue == "-1" || n3w4.SelectedValue == "0")
        {
            a = false;
            h.Append("Bạn chưa chọn Thành phố<br/>");
        }
        if (n3w6.SelectedValue == "-1" || n3w6.SelectedValue == "0")
        {
            a = false;
            h.Append("Bạn chưa chọn Quận huyện<br/>");
        }
        if (area.Value == "" || float.Parse(area.Value) <0)
        {
            a = false;
            h.Append("Bạn chưa nhập Diện tích<br/>");
        }
        if (title.Value == "")
        {
            a = false;
            h.Append("Bạn chưa nhập Tiêu đề<br/>");
        }
        if (descript.Value == "")
        {
            a = false;
            h.Append("Bạn chưa nhập Mô tả chi tiết tin đăng<br/>");
        }
        if (ic.Value == "" && (it.Value == "" || ml.Value == ""))
        {
            a = false;
            h.Append("Bạn chưa nhập đầy đủ Thông tin liên hệ<br/>");
        }
        if (!a)
        {
            pvlid.InnerHtml = h.ToString();
            pvlid.Visible = true;
        }
        return a;
    }

    private string lk()
    {
        HttpCookie ck = new HttpCookie("hlsbrlg");
        ck = Request.Cookies["hlsbrlg"];
        string us = "";
        if (ck != null && ck.Value != "" &&
             ck.Value != null)
        {
            us = ck.Value.ToString();
        }
        return us;
    }
    protected void gImages_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DelPros")
        {
            int i = int.Parse(e.CommandArgument.ToString());
            GridViewRow r = gImages.Rows[i];
            int j = int.Parse(gImages.DataKeys[r.RowIndex].Values[0].ToString());
            EHouses eh = new EHouses();
            eh.PostId = int.Parse(gImages.DataKeys[r.RowIndex].Values[1].ToString());
            DateTime a = DateTime.Parse(gImages.DataKeys[r.RowIndex].Values[3].ToString());
            string file = Server.MapPath("~/pros/" + a.Year.ToString() + "/" + a.Month.ToString() + "/" + eh.PostId.ToString() + "/thumbs/" + gImages.DataKeys[r.RowIndex].Values[2].ToString());
            if (System.IO.File.Exists(file)) System.IO.File.Delete(file);
            string file2 = Server.MapPath("~/pros/" + a.Year.ToString() + "/" + a.Month.ToString() + "/" + eh.PostId.ToString() + "/" + gImages.DataKeys[r.RowIndex].Values[2].ToString());
            if (System.IO.File.Exists(file2)) System.IO.File.Delete(file2);
            BHouses.EHouses(j);
            List<EHouses> lh = new List<EHouses>();
            lh = BHouses.utis2(eh);
            gImages.DataSource = lh;
            gImages.DataBind();
            BServer.Remove("Posts", true);
        }
    }
}
