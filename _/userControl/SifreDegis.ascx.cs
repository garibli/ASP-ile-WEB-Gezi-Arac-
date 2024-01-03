using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class userControl_SifreDegis : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();
        string mail = Session["Mail"].ToString();

        if (txtSifre.Text == txtSifreTekrar.Text)
        {


            if ((Session["yetkiID"].ToString() == "1" || Session["yetkiID"].ToString() == "2"))
            {
                tblPersonel guncelle = turna.tblPersonel.First(n => n.mail == mail);

                guncelle.sifre = txtSifre.Text;

                turna.SaveChanges();

                lblBilgi.Text = "Şifreniz başarıyla güncellendi.";

            }
            else if (Session["yetkiID"].ToString() != "ogr")
            {
                tblOgrenci guncelle = turna.tblOgrenci.First(n => n.mail == mail);

                guncelle.sifre = txtSifre.Text;

                turna.SaveChanges();

                lblBilgi.Text = "Şifreniz başarıyla güncellendi.";

            }
            else
            {
                lblBilgi.Text = "Geçersiz yetki sisteme tekrar giriş yapınız.";

            }
        }
        else
        {
            lblBilgi.Text = "Şifreler Uyuşmamakta.";
        }
        
      

        
    }
}