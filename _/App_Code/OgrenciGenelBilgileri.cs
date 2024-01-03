using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OgrenciGenelBilgileri
/// </summary>
[Serializable]
public class OgrenciGenelBilgileri
{
    public int ID { get; set; }
    public int OgrenciID { get; set; }
    public string AdSoyad { get; set; }
    //public string Soyad { get; set; }
    public string DogumYeri { get; set; }
    public string DogumTarihi { get; set; }
    public string BabaAdi { get; set; }
    public string AnneAdi { get; set; }
    public string Cinsiyeti { get; set; }
    public string Uyrugu { get; set; }
    public string TC { get; set; }
    public string CuzdanSerisi { get; set; }
    public string CuzdanNumarasi { get; set; }
    public string Ilce { get; set; }
    public string il { get; set; }
    public string SayfaSira { get; set; }
    public string MahalleKoy { get; set; }
    public string CiltNo { get; set; }
    public string HaneKutukAile { get; set; }

    public string IkametAdres { get; set; }
    public string IkametPostaKodu { get; set; }
    public string IkametSemtIlce { get; set; }
    public string IkametIl { get; set; }
    public string SakaryaAdres { get; set; }
    public string SakaryaPostaKodu { get; set; }
    public string SakaryaSemtIlce { get; set; }
    public string SakaryaIl { get; set; }
    public string OgrenciCepTel { get; set; }
    public string OgrenciTelefon { get; set; }
    public string OgrenciEmail { get; set; }
    public string AcilUlasilabilecekAdres { get; set; }
    public string AcilUlasilabilecekTelefon { get; set; }
    public string FakulteYoMyoEnstitu { get; set; }
    public string Programi { get; set; }
    public string OgrenciNo { get; set; }
    public string Sinifi { get; set; }
    public string DersKaydiVarMi { get; set; }
    public string FotografURL { get; set; }

}