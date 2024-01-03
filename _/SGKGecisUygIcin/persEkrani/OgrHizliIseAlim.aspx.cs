using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class persEkrani_OgrHizliIseAlim : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    bool kontenjanKontrol = true;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || (Session["yetkiID"].ToString() != "1" && Session["yetkiID"].ToString() != "2"))
            Response.Redirect("../Default.aspx");
        
          
          
        if (!IsPostBack)
        {
            int birim = Convert.ToInt16(Session["birimID"].ToString());
            int bolumler = Convert.ToInt16(Session["bolumID"].ToString());
            var BirimLer = from birimBilgileri in turna.tblBirimler select new { birimBilgileri.id, birimBilgileri.adi };
            ddlOkuduguBirim.DataSource = BirimLer.ToList();
            ddlOkuduguBirim.DataTextField = "adi";
            ddlOkuduguBirim.DataValueField = "id";
            ddlOkuduguBirim.DataBind();
            btnHata.Visible = false;
            btnDogru.Visible = false;

            var CalisilacakBirim = from Cbirim in turna.tblBirimler where Cbirim.id == birim select new { Cbirim.id, Cbirim.adi };
            ddlCalisacagiBirim.DataSource = CalisilacakBirim.ToList();
            ddlCalisacagiBirim.DataTextField = "adi";
            ddlCalisacagiBirim.DataValueField = "id";
            ddlCalisacagiBirim.DataBind();
            
            var bolumGetir = from bolum in turna.tblBolumler where bolum.birimID == birim select new { bolum.adi, bolum.id };
            ddlCalisacagiBolum.DataSource = bolumGetir.ToList();
            ddlCalisacagiBolum.DataValueField = "id";
            ddlCalisacagiBolum.DataTextField = "adi";
            ddlCalisacagiBolum.DataBind();
        }
    }
  
    protected void ddlOkuduguBirim_SelectedIndexChanged(object sender, EventArgs e)
    {
        int secilenBirim = Convert.ToInt16(ddlOkuduguBirim.SelectedValue);
        var BolumLer = from BolumBilgileri in turna.tblBolumler where BolumBilgileri.birimID == secilenBirim select new { BolumBilgileri.id, BolumBilgileri.adi };
        ddlOkuduguBolum.DataSource = BolumLer.ToList();
        ddlOkuduguBolum.DataTextField = "adi";
        ddlOkuduguBolum.DataValueField = "id";
        ddlOkuduguBolum.DataBind();
    }
  
    public void messagebox(string mesaj)
    {
        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");
    }
    protected void btnNumara_Click(object sender, EventArgs e)
    {

        string numara = TxtNumara.Text.ToString();
        try
        {
            var numaraKontrol = (from KisiBilgileri in turna.tblOgrenci where KisiBilgileri.ogrNo == numara select new { KisiBilgileri.ad, KisiBilgileri.soyad, KisiBilgileri.mail, KisiBilgileri.okulu, KisiBilgileri.bolumu }).FirstOrDefault();
            txtAD.Text = numaraKontrol.ad.ToString();
            txtSoyad.Text = numaraKontrol.soyad.ToString();
            txtMail.Text = numaraKontrol.mail.ToString();
            int birim = Convert.ToInt16(numaraKontrol.okulu);
            int bolum = Convert.ToInt16(numaraKontrol.bolumu);

            btnDogru.Visible = true;
            btnHata.Visible = false;

            var BirimLer = from birimBilgileri in turna.tblBirimler where  birimBilgileri.id== birim select new { birimBilgileri.id, birimBilgileri.adi };
            ddlOkuduguBirim.DataSource = BirimLer.ToList();
            ddlOkuduguBirim.DataTextField = "adi";
            ddlOkuduguBirim.DataValueField = "id";
            ddlOkuduguBirim.DataBind();
           
            var BolumLer = from BolumBilgileri in turna.tblBolumler where BolumBilgileri.id==bolum select new { BolumBilgileri.id, BolumBilgileri.adi };
            ddlOkuduguBolum.DataSource = BolumLer.ToList();
            ddlOkuduguBolum.DataTextField = "adi";
            ddlOkuduguBolum.DataValueField = "id";
            ddlOkuduguBolum.DataBind();
          

        }
        catch 
        {
            messagebox("Girilen Numara Sistemde Kayıtlı Değil. L;ütfen Tekrar Giriniz yada Sisteme Kaydını yapınız!!");
            btnHata.Visible = true;
            btnDogru.Visible = false;
        }
    }

    protected void btnHata_Click(object sender, EventArgs e)
    {
            messagebox("Hatalı numara girişi!!");   
    }

    protected void btnIseAlim_Click(object sender, EventArgs e)
    {

        int bolumler = Convert.ToInt16(Session["bolumID"].ToString());
        int birimID = Convert.ToInt16(Session["birimID"].ToString());
        int calisanS = 0;
        int verilenKontenjan = 0;
        try
        {
            var toplamKontenjan = (from kontenjan in turna.tblBolumler where kontenjan.id == bolumler && kontenjan.birimID==birimID select new { kontenjan.altKontenjan }).FirstOrDefault();
            verilenKontenjan = Convert.ToInt16(toplamKontenjan.altKontenjan);
        }
        catch 
        {
            verilenKontenjan = 0;
        }
        try
        {
            var calisanSayisi = from calisan in turna.tblCalismaYerleri where calisan.calisacagiCalistigiAltBirimi == bolumler && calisan.calisacagiCalistigiYer==birimID select new { };
            foreach (var item in calisanSayisi)
            {
                calisanS = calisanS + 1;
            }
        }
        catch
        {
            calisanS = 0;
        }
        string numara = TxtNumara.Text.ToString().Trim();
        try
        {
            var sorgulaCalisan = (from calisan in turna.tblCalismaYerleri where calisan.ogrNo == numara select new { calisan.id, calisan.ogrNo }).FirstOrDefault();
            sorgulaCalisan.id.ToString();
            sorgulaCalisan.ogrNo.ToString();
            messagebox("Bu Kişi İşe Alınmış");
        }
        catch
        {
            if (calisanS < Convert.ToInt16(verilenKontenjan))
            {
                lblKalanKontenjan.Text = (Convert.ToInt16(verilenKontenjan) - calisanS).ToString();
                if (numara == "" || ddlCalisacagiBolum.SelectedValue == null || ddlCalismaSekli.SelectedValue == "0")
                {
                    messagebox("Lütfen Çalisma Bilgileri Doldurunuz..");
                }
                else if (txtAD.Text.Trim() == "" || txtMail.Text.Trim() == "" || txtSoyad.Text.Trim() == "")
                {
                    messagebox("Lütfen Kişisel Bilgileri Doldurunuz..");
                }
                else
                {
                    try
                    {
                        var numaraGetir = (from numaraBul in turna.tblOgrenci where numaraBul.ogrNo == numara select new { numaraBul.id }).FirstOrDefault();
                        int birim = Convert.ToInt16(ddlCalisacagiBirim.SelectedValue);
                        int altBirim = Convert.ToInt16(ddlCalisacagiBolum.SelectedValue);
                        int calismaSekli = Convert.ToInt16(ddlCalismaSekli.SelectedValue);
                        turna.HizliIseAl(numaraGetir.id, numara, birim, altBirim, calismaSekli, Convert.ToInt16(Session["persID"]));
                        turna.ogrAktifPasit("1", numara);
                        messagebox("Sisteme Kayit Gerçekleşti");
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                    catch
                    {
                        messagebox("Lütfen Tekrar Deneyiniz!! Numaranın Doğru Girildiğinden Emin Olunuz");
                    }
                }
            }
            else
            {
                lblKalanKontenjan.Text = (Convert.ToInt16(verilenKontenjan) - calisanS).ToString()+" Kalan Kontenjan sayınız";
                messagebox("kontenjanınız dolmuştur!");
            }
        }
    }
       

    }
