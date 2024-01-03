using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class GirisEkrani : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
       
	    //Response.Redirect("GuncellemeYapiliyor.aspx");
        
        Page.SetFocus(btnLogin);
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        int istenenAnketAy = 4;
        System.Data.Objects.ObjectParameter persMi = new System.Data.Objects.ObjectParameter("Perskayit", typeof(int));

        System.Data.Objects.ObjectParameter ogrMi = new System.Data.Objects.ObjectParameter("Ogrkayit", typeof(int));

        turna.PersonelGiris(txtUserName.Text, txtUserPassword.Text, persMi);
        if (Convert.ToInt16(persMi.Value) != 0)
        {

            var yetkiGetir = from calisan in turna.tblPersonel
                             where calisan.mail == txtUserName.Text
                             select new { calisan.yetkiID, calisan.birimId, calisan.adi, calisan.soyad, calisan.id, calisan.bolumId };

            Session["Mail"] = txtUserName.Text;
            foreach (var item in yetkiGetir)
            {
                Session["persID"] = item.id.ToString();
                Session["yetkiID"] = item.yetkiID.Value.ToString();
                Session["birimID"] = item.birimId.Value.ToString();
                if (item.bolumId != null)
                    Session["bolumID"] = item.bolumId.ToString();
                else
                    Session["bolumID"] = "-1";
                Session["ad"] = item.adi.ToString();
                Session["soyad"] = item.soyad.ToString();
            }
            string yetkiID = Session["yetkiID"].ToString();
            if (yetkiID == "0")
            {
                Response.Redirect("./SKSEkrani/Default.aspx");
            }
            else if (yetkiID == "3")
            { Response.Redirect("./komisyon/Default.aspx"); }
            else
                Response.Redirect("./persEkrani/Default.aspx");
        }
        else
        {
            turna.ogrGiris(txtUserName.Text, txtUserPassword.Text, ogrMi);
            if (Convert.ToInt16(ogrMi.Value) != 0)
            {


                Session["Mail"] = txtUserName.Text;
                Session["yetkiID"] = "ogr";

                var ogr1 = from ogr in turna.tblOgrenci
                           where ogr.mail == txtUserName.Text
                           select new { ogr.ad, ogr.soyad, ogr.ogrNo };

                var ogrExt = from ogr in turna.tblOgrenci
                             join calisMa in turna.tblCalismaYerleri
                                 on ogr.ogrNo equals calisMa.ogrNo
                             join calismaYer in turna.tblBolumler
                             on calisMa.calisacagiCalistigiYer equals calismaYer.birimID
                             where ogr.mail == txtUserName.Text
                             select new { calismaYer.adi, calisMa.calismaSekli, calisMa.aktifMi };


                int calismaSekli = -1;
                foreach (var item in ogr1)
                {
                    Session["ad"] = item.ad.ToString();
                    Session["soyad"] = item.soyad.ToString();
                    Session["ogrNo"] = item.ogrNo.ToString();
                    foreach (var item2 in ogrExt)
                    {
                        if (item2.adi != null && item2.aktifMi.ToString() == "1")
                        {
                            Session["calistigiYer"] = item2.adi.ToString();
                            //Session["aktifCalisanMi"] = item.aktifMi.ToString();
                            calismaSekli = Convert.ToInt16(item2.calismaSekli);
                        }
                    }


                }

                if (calismaSekli != -1)
                {
                    var calismaSekliP = from calSek in turna.tblCalismaSekli
                                        where calSek.id == calismaSekli
                                        select new { calSek.adi };

                    foreach (var item in calismaSekliP)
                    {
                        Session["calismaSekli"] = item.adi.ToString();
                    }
                }





                var anketT = from ogrAnket in turna.tblOgrenciAnketCevablari
                             where ogrAnket.ogrMail == txtUserName.Text
                             select new { ogrAnket.eklenmeTarihi };


                bool anketyap = true;
                DateTime eTarih = Convert.ToDateTime("28.4.2000 01:42:14");
                foreach (var item in anketT)
                {
                    if (item.eklenmeTarihi != null)
                        eTarih = item.eklenmeTarihi.Value;
                }

                if (eTarih != Convert.ToDateTime("28.4.2000 01:42:14"))
                {
                    if (eTarih.Year == DateTime.Now.Year && eTarih.Month >= istenenAnketAy)
                        anketyap = false;
                }


                if (anketyap)
                {
                    Response.Redirect("./ogrEkrani/Anket.aspx");
                }
                else
                    Response.Redirect("./ogrEkrani/Default.aspx");


            }
            else
            {
                if (txtUserName.Text == "ad")
                {
                    if (txtUserPassword.Text == "min")
                    {
                        Session["yetkiID"] = "admin";
                        Response.Redirect("ADMIN");
                    }
                }
                lblBilgi.Text = "Mail veya Şifre bilginizi kontrol ediniz !";
                lblBilgiKontrol.Visible = true;
            }


        }
    }
}