using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_personelIslem : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.


        if (IsPostBack)
        {
            return;
        }

        var birimGetir = from birim in turna.tblBirimler 
                         orderby birim.adi ascending
                         select new { birim.adi, birim.id };
        DropDownListBirim.DataSource = birimGetir.ToList();
        DropDownListBirim.DataValueField = "id";
        DropDownListBirim.DataTextField = "adi";
        DropDownListBirim.DataBind();
        DropDownListBirim.Items.Insert(0, new ListItem("– Birim Seçiniz –", "-1"));

        //var yetkiGetir = from yetki in turna.tblYetkiTuru select new { yetki.id, yetki.adi };
        //DropDownListYetki.DataSource = yetkiGetir.ToList();
        //DropDownListYetki.DataValueField = "id";
        //DropDownListYetki.DataTextField = "adi";
        //DropDownListYetki.DataBind();
        //DropDownListYetki.Items.Insert(0, new ListItem("- yetki Seçiniz -", "-5"));
    }
    protected void DropDownListBirim_SelectedIndexChanged(object sender, EventArgs e)
    {
        var birimSecildi = Convert.ToInt16(DropDownListBirim.SelectedItem.Value);

        var bolumGetir = from bolum in turna.tblBolumler 
                         where bolum.birimID == birimSecildi 
                         orderby bolum.adi ascending
                         select new { bolum.adi, bolum.id };
        DropDownListBolum.DataSource = bolumGetir.ToList();
        DropDownListBolum.DataValueField = "id";
        DropDownListBolum.DataTextField = "adi";
        DropDownListBolum.DataBind();
        DropDownListBolum.Items.Insert(0, new ListItem("- Bolum Seçiniz -", "-1"));
    }
 
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {


            VeriIslemleri veri = new VeriIslemleri();

            string[] mailKontrol = txtpersMail.Text.Split('@');



            if (DropDownListYetki.SelectedValue == "0" && DropDownListBirim.SelectedValue != "49")
            {
                LblHata.Text = "SKS Yöneticisi Yalnızca SKS biriminde görevlendirilcek personel için seçilebilir.";
            }
            else
            {


                if (mailKontrol[1] == "sakarya.edu.tr")
                {




                    int ayniIsimVarmi = 0;
                    var _mail1 = txtpersMail.Text;
                    var isimKontrol = from personelisim in turna.tblPersonel where personelisim.mail == _mail1 select new { personelisim.adi };
                    int _tcKontrol = txtpersTC.Text.Length;
                    foreach (var kontrol in isimKontrol)
                    {
                        ayniIsimVarmi = 2;
                    }

                    if (ayniIsimVarmi > 0)
                    {
                        LblHata.Text = "-MAİL ADRESİ SİSTEMDE KAYITLI. FARKLI BİR MAİL ADRESİ GİRİN";
                    }
                    else if (txtpersAd.Text == "" || txtpersSoyad.Text == "" || txtpersMail.Text == "" || txtpersTC.Text == "" || TxtDahili.Text == "" || txtsifreIlk.Text == "" || DropDownListYetki.SelectedValue == "-1" || DropDownListBirim.SelectedValue == "-1" || DropDownListBirim.SelectedValue == "")
                    {
                        LblHata.Text = "-BOŞ ALAN BIRAKMIYINIZ-";
                    }
                    else if (_tcKontrol != 11)
                    {
                        LblHata.Text = "-TC NUMARASI 11 HANELİ OLMALIDIR-";
                    }
                    else
                    {
                        var _adi = txtpersAd.Text;
                        var _soyad = txtpersSoyad.Text;
                        var _mail = txtpersMail.Text;
                        var _sifre = txtsifreIlk.Text;
                        var _dahiliNo = TxtDahili.Text;
                        var _persTC = txtpersTC.Text;
                        var _birimId = Convert.ToInt16(DropDownListBirim.SelectedItem.Value);
                        var _bolumId = Convert.ToInt16(DropDownListBolum.SelectedItem.Value);
                        var _yetkiID = Convert.ToInt16(DropDownListYetki.SelectedItem.Value);


                        tblPersonel persEkle = new tblPersonel()
                        {
                            persTC = _persTC,
                            adi = _adi,
                            soyad = _soyad,
                            sifre = _sifre,
                            mail = _mail,
                            dahiliNo = _dahiliNo,
                            birimId = _birimId,
                            bolumId = _bolumId,
                            yetkiID = _yetkiID
                        };

                        turna.tblPersonel.AddObject(persEkle);

                        turna.SaveChanges();

                        txtpersAd.Text = "";
                        TxtDahili.Text = "";
                        txtpersMail.Text = "";
                        txtpersSoyad.Text = "";
                        txtpersTC.Text = "";
                        txtsifreIlk.Text = "";


                        LblHata.Text = "-KAYIT BAŞARILI";
                    }
                }
                else
                {
                    LblHata.Text = "Üniversite mail adresinin girilmesi zorunludur.";
                }
            }
        }


        catch (Exception)
        {
            LblHata.Text = "Bir hata meydana geldi girdiğiniz değerleri kontrol edip işleminizi tekrarlayınız.";

        }
    }
}