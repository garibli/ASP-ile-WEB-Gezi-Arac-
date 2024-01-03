using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class userControl_Anket3 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            TurnaEntities turna = new TurnaEntities();

            string ogrNo = Session["ogrNo"].ToString();

            var anketGetir = from anketCvb in turna.tblOgrenciAnketCevablari
                             where anketCvb.ogrNo == ogrNo
                             select new { anketCvb.secimlerIDPUANEk3 };

            string verilenCevaplar = "-1";

            foreach (var item in anketGetir)
            {
                verilenCevaplar = item.secimlerIDPUANEk3;
            }

            if (verilenCevaplar != "-1" && verilenCevaplar.TrimEnd(' ') != "0" )
            {
                ddl11.SelectedIndex = Convert.ToInt16(verilenCevaplar[0].ToString());
                ddl12.SelectedIndex = Convert.ToInt16(verilenCevaplar[2].ToString());
               // ddl13.SelectedIndex = Convert.ToInt16(verilenCevaplar[4].ToString());
                ddl14.SelectedIndex = Convert.ToInt16(verilenCevaplar[6].ToString());
                ddl15.SelectedIndex = Convert.ToInt16(verilenCevaplar[8].ToString());

               


            }
        }
    }
    protected void btnDevam_Click(object sender, EventArgs e)
    {
        string anket = ddl11.SelectedIndex + " " + ddl12.SelectedIndex + " " + "0" + " " +
          ddl14.SelectedIndex + " " + ddl15.SelectedIndex;


        int anketPuan = Convert.ToInt16(ddl11.SelectedValue) + Convert.ToInt16(ddl12.SelectedValue) + 0 + Convert.ToInt16(ddl14.SelectedValue) + Convert.ToInt16(ddl15.SelectedValue);
              


        TurnaEntities turna = new TurnaEntities();

        string ogrNo = Session["ogrNo"].ToString();







        turna.ogrAnketGuncelle3(ogrNo, anket, anketPuan);




        Response.Redirect("./OzelOgrenci.aspx");
        
       

    
    }
}