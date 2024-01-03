using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class komisyon_SoruGuncelle : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    static int a = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            int birimID=Convert.ToInt16(Session["birimID"]);
            var sorulariGetir = (from sorular in turna.tblMulakatSorulari where sorular.birimID == birimID select new { sorular.soru1, sorular.soru2, sorular.soru3, sorular.soru4 }).FirstOrDefault();
            txtSoru1.Text = sorulariGetir.soru1.ToString();
            txtSoru2.Text = sorulariGetir.soru2.ToString();
            txtSoru3.Text = sorulariGetir.soru3.ToString();
            txtSoru4.Text = sorulariGetir.soru4.ToString();
            return;
        }
    }
   



    public void messagebox(string mesaj)
    {


        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");

    }
    
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        string soru1al="";
        string soru2al="";
        string soru3al="";
        string soru4al="";
        
            if (txtSoru1.Text.Trim() != "")
            {
                soru1al = txtSoru1.Text.ToString().Trim();
                a = a + 1;
            }
            if (txtSoru2.Text.Trim() != "")
            {
                soru2al = txtSoru2.Text.ToString().Trim();
                a = a + 1;
            }
            if (txtSoru3.Text.Trim() != "")
            {
                soru3al = txtSoru3.Text.ToString().Trim();
                a = a + 1;
            }
            if (txtSoru4.Text.Trim() != "")
            {
                soru4al = txtSoru4.Text.ToString().Trim();
                a = a + 1;
            }
            messagebox(soru1al.ToString() + "/" + soru2al.ToString() + "/" + soru3al.ToString() + "/" + soru4al.ToString() + "/" + a.ToString());

            double soruPuanTut = 0;
            if (a == 1)
            {
                soruPuanTut = 4;
            }
            else if (a == 2)
            {
                soruPuanTut = 2;
            }
            else if (a == 3)
            {
                soruPuanTut = 1.34;
            }
            else
            {
                soruPuanTut = 1;
            }

           
            int birimID = Convert.ToInt16(Session["birimID"]);
            int persID = Convert.ToInt16(Session["persID"]);
           
            tblMulakatSorulari guncelleSoru = turna.tblMulakatSorulari.First(k => k.birimID == birimID);
            guncelleSoru.soru1 = soru1al.ToString();
            guncelleSoru.soru2 = soru2al.ToString();
            guncelleSoru.soru3 = soru3al.ToString();
            guncelleSoru.soru4 = soru4al.ToString();
            guncelleSoru.PuanMiktari = Convert.ToDecimal(soruPuanTut);
            guncelleSoru.komisyonID = Convert.ToInt16(persID);
            turna.SaveChanges();
            a = 0;
           Response.Redirect("../komisyon/Default.aspx");
           Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../komisyon/Default.aspx");
    }
}