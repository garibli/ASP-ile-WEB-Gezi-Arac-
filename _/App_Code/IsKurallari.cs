using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using skscalismaModel;

/// <summary>
/// Summary description for IsKurallari
/// </summary>
public class IsKurallari
{
    
	public IsKurallari()
	{
        
	}
    public bool tcDogrulama(string tc)
    {
        if (tc.Length!=11)
        {
            return false;
        }

        int toplam = 0;
        for (int i = 0; i < (tc.Length)-1 ; i++)
        {   
          
            toplam += Convert.ToInt16(tc[i]);
                
        }
        int tcSon = (toplam % 10);
        if ( tcSon == tc[10])
            return true;
        else
            return false;
    }

    public bool karakterMi(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsNumber(str[i]))
            {
                return false;
              
            }
            
        }
        return true;
    }

    public void ilanGetir(string ogrNo)
    {
        TurnaEntities turna = new TurnaEntities();
        var getir = from ogr in turna.tblOgrenci
                    join bolum in turna.tblBolumler on ogr.bolumu equals bolum.id
                    where ogr.ogrNo == ogrNo
                    select new { bolum.bolumTuru };



    }
    
    public bool anketGuncelmi(string sessionMail)
    {
        TurnaEntities turna = new TurnaEntities();
        int istenenAnketAy = 4;
       
       
        var ogrGetirD = from ogr in turna.tblOgrenci
                        join anketD in turna.tblOgrenciAnketCevablari
                            on ogr.mail equals anketD.ogrMail
                        where ogr.mail == sessionMail
                        select new { anketD.eklenmeTarihi };
        DateTime kontrolDate = Convert.ToDateTime("01.01.2000 10:30:00");
        foreach (var item in ogrGetirD)
        {
            if (item.eklenmeTarihi != null)
                kontrolDate = item.eklenmeTarihi.Value;
        }

        if (kontrolDate.Year != DateTime.Now.Year || kontrolDate.Month < istenenAnketAy)
        {
            return false;
        }
        else
            return true;
    }
   

    public bool mailSakaryaMi(string str,string mailTipi)
    {
        
        
        string[] mailUzantısı = str.Split('@');

        if (mailUzantısı.Count() > 1)
        {
            if (mailUzantısı[1] == mailTipi)
                return true;
            else
                return false;
        }
        else
            return false;
                


    }
   
    
}