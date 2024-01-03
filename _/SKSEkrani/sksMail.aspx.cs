using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Text;
using skscalismaModel;
public partial class SKSEkrani_sksMail : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var personel = from pers in turna.tblPersonel select new { pers.id, pers.adi, pers.soyad, pers.mail };
            dtListPersonel.DataSource = personel.ToList();
            dtListPersonel.DataBind();
        }

    }

    protected void chkHepsiSec_CheckedChanged(object sender, EventArgs e)
    {
        if (chkHepsiSec.Checked == true)
        {
            lstBoxMails.Items.Clear();
            var personel = from pers in turna.tblPersonel select new { pers.mail };
            foreach (var item in personel)
            {
                lstBoxMails.Items.Add(item.mail.ToString());
            }
        }
        else
        {
            var personel = from pers in turna.tblPersonel select new { pers.mail };
            foreach (var item in personel)
            {
                lstBoxMails.Items.Clear();

            }
        }
    }
    protected void dtListPersonel_ItemCommand(object source, DataListCommandEventArgs e)
    {

        string mailAdresleri = e.CommandArgument.ToString();

        try
        {
            foreach (var item in lstBoxMails.Items)
            {
                if (mailAdresleri == item.ToString())
                {
                    lstBoxMails.Items.Remove(item.ToString());
                }
            }
        }
        catch { }
        lstBoxMails.Items.Add(mailAdresleri);
    }
    protected void btnGonder_Click(object sender, EventArgs e)
    {
        string mesajKonu = "";
        string mesajIcerik = "";
        string mailAdresi = Session["Mail"].ToString();
        string AdSoyad = Session["ad"].ToString() + " " + Session["soyad"].ToString();
        string mailSifre = txtSifre.Text;
        mesajKonu = txtKonu.Text.ToString();
        mesajIcerik = txtIcerik.Text.ToString();

        try
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential(mailAdresi, mailSifre);

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(mailAdresi, AdSoyad);

            foreach (var item in lstBoxMails.Items)
            {
                mail.To.Add(item.ToString().Trim());
            }
            mail.Subject = mesajKonu;
            mail.IsBodyHtml = true;
            mail.Body = mesajIcerik;

            sc.Send(mail);
        }
        catch 
        {
            Response.Write("<script>alert('Giriş yaptığınız mail adresi yada Şifre hatalıdır. Lütfen aktif olarak kullandığınız mail adresinizle giriş yapınız ve mail adresinizin şifresini kullanınız')</script>");
           
        }
    }
    protected void btnCıkar_Click(object sender, EventArgs e)
    {
        while (lstBoxMails.SelectedItem != null)
            lstBoxMails.Items.Remove(lstBoxMails.SelectedItem);
    }
}