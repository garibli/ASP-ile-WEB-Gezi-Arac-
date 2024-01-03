using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DtoTranskriptDonemOzet
/// </summary>
public class DtoTranskriptDonemOzet
{
   public string Donem{get;set;}//": "sample string 1",
    public decimal OrtalamaDonem{get;set;}//": 2.1,
    public decimal OrtalamaToplamDonem{get;set;}//": 3.1,
    public decimal OrtalamaGenel{get;set;}//": 4.1,
    public decimal OrtalamaToplamGenel{get;set;}//": 5.1,
    public int AKTSDonem{get;set;}//": 6,
    public int AKTSGenel{get;set;}//": 7,
    public int FKOgrenciID{get;set;}//": 8
    public List<DtoTranskriptDonemOzet> NotListesi{get;set;}
}