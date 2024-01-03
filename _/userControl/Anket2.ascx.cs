using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class userControl_Anket2 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            TurnaEntities turna = new TurnaEntities();

            string ogrNo = Session["ogrNo"].ToString();

            var anketGetir = from anketCvb in turna.tblOgrenciAnketCevablari
                             where anketCvb.ogrNo == ogrNo
                             select new { anketCvb.secimlerIDPUANEk2 };

            string verilenCevaplar = "-1";

            foreach (var item in anketGetir)
            {
                verilenCevaplar = item.secimlerIDPUANEk2;
            }

            if (verilenCevaplar != "-1")
            {
                ddl11.SelectedIndex = Convert.ToInt16(verilenCevaplar[0].ToString());
                ddl12.SelectedIndex = Convert.ToInt16(verilenCevaplar[2].ToString());
                ddl13.SelectedIndex = Convert.ToInt16(verilenCevaplar[4].ToString());
                ddl14.SelectedIndex = Convert.ToInt16(verilenCevaplar[6].ToString());
                ddl15.SelectedIndex = Convert.ToInt16(verilenCevaplar[8].ToString());

                //ddl21.SelectedIndex = Convert.ToInt16(verilenCevaplar[10].ToString());

                //ddl23.SelectedIndex = Convert.ToInt16(verilenCevaplar[12].ToString());
                //ddl24.SelectedIndex = Convert.ToInt16(verilenCevaplar[14].ToString());
                if (verilenCevaplar[16].ToString() == "1")
                {

                    ddl25.SelectedIndex = 1;
                   // CheckBox1.Checked = true;
                }
                else
                {
                    ddl25.SelectedIndex = 2;
                }


            }
        }



    }
    protected void btnDevam_Click(object sender, EventArgs e)
    {
        string anket = ddl11.SelectedIndex + " " + ddl12.SelectedIndex + " " + ddl13.SelectedIndex + " " +
          ddl14.SelectedIndex + " " + ddl15.SelectedIndex + " " + "0" /*ddl21.SelectedIndex*/ + " " +
         "0" /*ddl23.SelectedIndex */+ " " + "0"/*ddl24.SelectedIndex*/+" ";



        int anketPuan = Convert.ToInt16(ddl12.SelectedValue) + Convert.ToInt16(ddl13.SelectedValue) + Convert.ToInt16(ddl14.SelectedValue) + Convert.ToInt16(ddl15.SelectedValue);
             // +"0"/* Convert.ToInt16(ddl21.SelectedValue)*/ +"0"/* Convert.ToInt16(ddl23.SelectedValue)*/ + "0"/*Convert.ToInt16(ddl24.SelectedValue)*/;

        if (ddl25.SelectedValue == "1")
        {
            anket += "1";
        }
        else
        {
            anket += "0";
        }


        TurnaEntities turna = new TurnaEntities();

        string ogrNo = Session["ogrNo"].ToString();

        var anketGetir = from anketCvb in turna.tblOgrenciAnketCevablari
                         where anketCvb.ogrNo == ogrNo
                         select new { anketCvb.secimlerIDPUANEk1 };

        string verilenCevaplar = "-1";

        

        foreach (var item in anketGetir)
        {
            verilenCevaplar = item.secimlerIDPUANEk1;
        }

        int anketEk1Puan = Convert.ToInt16(Session["anketPuanEk1"]);

        if (verilenCevaplar != "-1")
        {

            string anket1 = Session["anketEk1"].ToString();


            turna.ogrAnketGuncelle(ogrNo, anket1, anket, anketPuan , anketEk1Puan);


            tblOgrenciAnketCevablari topPuan = turna.tblOgrenciAnketCevablari.First(n => n.ogrNo == ogrNo);

            topPuan.anketPuaniTop = Convert.ToInt16(anketPuan) + Convert.ToInt16(anketEk1Puan);

            turna.SaveChanges();

            


            if (ddl25.SelectedValue == "0")
            {
                tblOgrenciAnketCevablari ankt3Guncelle = turna.tblOgrenciAnketCevablari.First(n => n.ogrNo == ogrNo);

                    ankt3Guncelle.secimlerIDPUANEk3 = "010 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0";
                    ankt3Guncelle.anketPuani3 = 0;
                    

                    

                    turna.SaveChanges();
                    
            }



        }
        else
        {
            turna.ogrAnketCvb(Session["Mail"].ToString(), ogrNo, Session["anketEk1"].ToString(), anket, "010 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0", anketPuan, anketEk1Puan, 0, (anketEk1Puan + anketPuan));
        }


        if (ddl25.SelectedValue == "1")
        {
            Session["ozelOgr"] = "1";
            Response.Redirect("./Anket3.aspx");
        }
        else
        {
            Response.Redirect("./Default.aspx");
        }
       

    }
}