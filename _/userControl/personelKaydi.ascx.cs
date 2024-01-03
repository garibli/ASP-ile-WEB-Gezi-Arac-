using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class userControl_personelKaydi : System.Web.UI.UserControl
{
    TurnaEntities turna = new TurnaEntities();
    VeriIslemleri veri = new VeriIslemleri();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            veri.ddlVeriCekBirimler(ddlBirim);
            veri.ddlVeriCekPersonelYetki(ddlYetki);
        }
    }
    protected void btnGonder_Click(object sender, EventArgs e)
    {
        tblPersonel perEkle = new tblPersonel
        {
            adi = txtAd.Text,
            soyad = txtSoyad.Text,
            sifre = txtSifre.Text,
            mail = txtMail.Text,
            dahiliNo = txtDahiliNo.Text,
            birimId = Convert.ToInt16(ddlBirim.SelectedValue),
            yetkiID = Convert.ToInt16(ddlYetki.SelectedValue)
        };

        turna.tblPersonel.AddObject(perEkle);
        turna.SaveChanges();

        //turna.personelEkle(txtAd.Text, txtSoyad.Text, txtSifre.Text, txtMail.Text, txtDahiliNo.Text, Convert.ToInt16(ddlBirim.SelectedValue), Convert.ToInt16(ddlYetki.SelectedValue));
    }
}