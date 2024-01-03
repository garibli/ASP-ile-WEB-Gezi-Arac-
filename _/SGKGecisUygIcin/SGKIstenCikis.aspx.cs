using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SGKGecisUygIcin_SGKIstenCikis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if ((Request.QueryString["sifre"]) == "19qwresgt23")
        {
            TurnaEntities turna = new TurnaEntities();

            int calismaYerID = Convert.ToInt16(Request.QueryString["id"]);
            string ogrNo = (Request.QueryString["ornNo"]).ToString();//TC geliyor.
            DateTime tarih = Convert.ToDateTime(Request.QueryString["Tarih"]);

            var ogrNoGetir = from ogrNo2 in turna.tblOgrenci
                             where ogrNo2.tc == ogrNo
                             select new { ogrNo2.ogrNo };

            string ogrNoSorgu="0";
            foreach (var item in ogrNoGetir)
            {
                ogrNoSorgu = item.ogrNo;
            }

            turna.sgkCikisEXE(ogrNoSorgu, tarih, calismaYerID);//hem çıkış yapılıyor hem pasif.
            //ÇalışmaYErleriAKtiflik 2 yapılarak işten çıkıltığı belirleniyor.
            turna.ogrAktifPasit("0", ogrNoSorgu);//ogrenci pasif yapıldı yani tekrardan yeni bir işe alınabilir.

            int gun = tarih.Day;
            while (gun < 32)
            {
                tblCalisanYoklama puantajSil = turna.tblCalisanYoklama.FirstOrDefault(n => n.ogrNo == ogrNo && n.tarih >= tarih);
                if (puantajSil != null)
                {
                    turna.DeleteObject(puantajSil);
                    turna.SaveChanges();
                }
               

                tarih.AddDays(1);

                gun++;
               
            }

            
           



            VeriIslemleri veri = new VeriIslemleri();



            veri.guncelleKontenjanArttir(calismaYerID, -1);







        }


    }
}