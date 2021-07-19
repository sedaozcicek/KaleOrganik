using KALEORG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KALEORG.Controllers
{
    public class SiteBaseController : Controller
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        public int UserLogin = 1;

        public int MusteriListele = 2;
        public int MusteriEkle = 3;
        public int MusteriUpdate = 4;
        public int MusteriPassive =5 ;
        public int MusteriActive = 6;
        public int MusteriPassiveList = 7;
        public int MusteriAdresListe = 8;
        public int AdresEkle = 9;
        public int AdresUpdate = 10;
        public int AdresPassive = 11;
        public int AdresActive = 12;
        public int AdresPassiveList = 13;

        public int KategoriListele = 14;
        public int KategoriEkle = 15;
        public int KategoriUpdate = 16;
        public int KategoriPassive = 17;
        public int KategoriActive = 18;
        public int KategoriPassiveList = 19; 
        
        public int UrunListele = 20;
        public int UrunEkle = 21;
        public int UrunUpdate = 22;
        public int UrunPassive = 23;
        public int UrunActive = 24;
        public int UrunPassiveList = 25;

        public int UrunSatisListele = 26;
        public int UrunSatisEkle = 27;
        public int UrunSatisUpdate = 28;
        public int UrunSatisPassive = 29;
        public int UrunSatisActive = 30;
        public int UrunSatisPassiveList  = 31;

        public int SiparisListele = 32;
        public int SiparisUpdate = 34;
        public int SiparisPasive = 53;

        public int HakkimizdaListele = 35;
        public int HakkimizdaEkle = 36;
        public int HakkimizdaUpdate = 37;
        public int HakkimizdaPassive = 38;
        public int HakkimizdaActive = 39;

        public int IletisimListele = 40;
        public int IletisimEkle = 41;
        public int IletisimUpdate = 42;

        public int KargoListele = 43;
        public int KargoEkle = 44;
        public int KargoUpdate = 45;

        public int YetkiListeleme = 46;

        public int YorumListele = 47;
        public int YorumPassive = 50;
        public int YorumActive = 51;
        public int YorumPassiveList = 52;

        public int MailListele = 54;

        public int UrunFotoListele = 55;
        public int UrunFotoEkle = 56;


        public List<SelectListItem> kategoriSelect()
        {
            List<T_KATEGORI> kategoriList = et.T_KATEGORI.Where(q => q.KAPALI == true).ToList();
            List<SelectListItem> kategoriSelect = new List<SelectListItem>();
            kategoriSelect.Add(new SelectListItem { Text = "Lütfen Seçiniz..", Value = "" });
            foreach (var i in kategoriList)
            {
                kategoriSelect.Add(new SelectListItem { Text = i.KATEGORI_ADI, Value = i.KATEGORI_ID.ToString() });
            }
            return ViewBag.Kategori = kategoriSelect;
        }
        public List<SelectListItem> urunSelect()
        {
            List<T_URUN> urunList = et.T_URUN.Where(q => q.KAPALI == true).ToList();
            List<SelectListItem> urunSelect = new List<SelectListItem>();
            urunSelect.Add(new SelectListItem { Text = "Lütfen seçiniz..", Value = "" });
            foreach (var i in urunList)
            {
                urunSelect.Add(new SelectListItem { Text = i.URUN_ADI, Value = i.URUN_ID.ToString() });
            }
            return ViewBag.Urun = urunSelect;
        }
        public List<SelectListItem> musteriSelect()
        {
            List<T_MUSTERI> musteriList = et.T_MUSTERI.Where(q => q.KAPALI == true).ToList();
            List<SelectListItem> musteriSelect = new List<SelectListItem>();
            musteriSelect.Add(new SelectListItem { Text = "Lütfen seçiniz..", Value = "" });
            foreach (var i in musteriList)
            {
                musteriSelect.Add(new SelectListItem { Text = i.MUSTERI_ADI + " " + i.MUSTERI_SOYADI, Value = i.MUSTERI_ID.ToString() });
            }
            return ViewBag.Musteri = musteriSelect;
        }
        public List<SelectListItem> kargoSelect()
        {
            List<T_KARGO> kargoList = et.T_KARGO.ToList();
            List<SelectListItem> kargoSelect = new List<SelectListItem>();
            kargoSelect.Add(new SelectListItem { Text = "Lütfen seçiniz..", Value = "" });
            foreach (var i in kargoList)
            {
                kargoSelect.Add(new SelectListItem { Text = i.FIRMA_ADI, Value = i.KARGO_FIRMA_ID.ToString() });
            }
            return ViewBag.Kargo = kargoSelect;
        }
        public List<SelectListItem> adresSelect()
        {
            List<T_ADRES> adresList = et.T_ADRES.ToList();
            List<SelectListItem> adresSelect = new List<SelectListItem>();
            adresSelect.Add(new SelectListItem { Text = "Lütfen Seçiniz..", Value = "" });
            foreach (var i in adresList)
            {
                adresSelect.Add(new SelectListItem { Text = i.ADRES + " " + i.IL + " " + i.ILCE, Value = i.ADRES_ID.ToString() });
            }
            return ViewBag.Adres = adresSelect;
        }
        public List<SelectListItem> urunSatisSelect()
        {
            List<T_URUN_SATIS> urunSatisList = et.T_URUN_SATIS.Where(q => q.KAPALI == true).ToList();
            List<SelectListItem> urunSatisSelect = new List<SelectListItem>();
            urunSatisSelect.Add(new SelectListItem { Text = "Lütfen Seçiniz..", Value = "" });
            foreach (var i in urunSatisList)
            {
                urunSatisSelect.Add(new SelectListItem { Text = i.MIKTAR.ToString(), Value = i.URUN_SATIS_ID.ToString() });
            }
            return ViewBag.UrunSatis = urunSatisSelect;
        }
        public List<SelectListItem> iletisimSelect()
        {
            List<T_ILETISIM> iletisimList = et.T_ILETISIM.ToList();
            List<SelectListItem> iletisimSelect = new List<SelectListItem>();
            iletisimSelect.Add(new SelectListItem { Text = "Lütfen seçiniz..", Value = " " });
            foreach (var i in iletisimList)
            {
                iletisimSelect.Add(new SelectListItem { Text = i.ADRES, Value = i.ILETISIM_ID.ToString() });
            }
            return ViewBag.Iletisim = iletisimSelect;
        }
        public List<SelectListItem> hakkimizdaSelect()
        {
            List<T_HAKKIMIZDA> hakkimizdaList = et.T_HAKKIMIZDA.ToList();
            List<SelectListItem> hakkimizdaSelect = new List<SelectListItem>();
            hakkimizdaSelect.Add(new SelectListItem { Text = "Lütfen seçiniz..", Value = " " });
            foreach (var i in hakkimizdaList)
            {
                hakkimizdaSelect.Add(new SelectListItem { Text = i.HAKKIMIZDA_ICERIK, Value = i.HAKKIMIZDA_ID.ToString() });
            }
            return ViewBag.Hakkimizda = hakkimizdaSelect;
        }
        public List<SelectListItem> YorumSelect()
        {
            List<T_URUN_YORUM> yorumList = et.T_URUN_YORUM.Where(q => q.KAPALI == true).ToList();
            List<SelectListItem> yorumSelect = new List<SelectListItem>();
            yorumSelect.Add(new SelectListItem { Text = "Lütfen Seçiniz..", Value = "" });
            foreach (var i in yorumList)
            {
                yorumSelect.Add(new SelectListItem { Text = i.YORUM_AD_SOYAD, Value = i.URUN_YORUM_ID.ToString() });
            }
            return ViewBag.Yorum = yorumSelect;
        }
        public Boolean getRolesKontrol(int searchRoles)
        {
            if (Session["Yetki"] == null || Session["User"] == null)
            {
                return false;
            }
            else
            {
                List<KULLANICI_KATEGORI> kullanici = (List<KULLANICI_KATEGORI>)Session["Yetki"];
                foreach (var i in kullanici)
                {
                    if (i.KATEGORI == searchRoles)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public List<T_KATEGORI> MenuList()
        {
            return ViewBag.kategoriList = et.T_KATEGORI.Where(q => q.KAPALI == true).ToList();
        }
        public List<T_URUN> randonUrunList()
        {
            return et.T_URUN.Where(q => q.KAPALI == true).OrderBy(q=>Guid.NewGuid()).Take(10).ToList();
           
        }
        public List<T_URUN> UrunDetayRandom()
        {
            return et.T_URUN.Where(q => q.KAPALI == true).OrderBy(q => Guid.NewGuid()).Take(3).ToList();

        }
        public List<T_URUN> UrunList()
        {
             return et.T_URUN.Where(q => q.KAPALI == true).ToList();
        }
        public List<T_URUN> SonAranan()
        {
            return et.T_URUN.Where(q => q.KAPALI == true).OrderBy(q => Guid.NewGuid()).Take(3).ToList();
        }
        

        public ActionResult SepeteEkle(int Id)
        {
            List<T_URUN_SEPET> urunList = new List<T_URUN_SEPET>();
            T_URUN search = et.T_URUN.Where(q => q.URUN_ID == Id).FirstOrDefault();
            List<T_URUN_SEPET> sepetler = (List<T_URUN_SEPET>)Session["Sepet"];
            int arama = 0;
            if (sepetler != null)
            {
                foreach (var i in sepetler)
                {
                    if (i.URUN_ID == Id)
                    {
                        arama += 1;
                    }
                }
            }
            if(arama == 0)
            {

                T_URUN_SEPET u = new T_URUN_SEPET();

                u.URUN_ADI = search.URUN_ADI;
                u.URUN_ID = search.URUN_ID;
                u.FOTO = search.FOTO;
                u.URUN_FIYAT = search.URUN_FIYAT;
                u.MIKTAR = 1;
                urunList.Add(u);                
                
            }
            if (sepetler != null)
            {
                foreach (var i in sepetler)
                {
                    T_URUN_SEPET r = new T_URUN_SEPET();

                    r.URUN_ADI = i.URUN_ADI;
                    r.URUN_ID = i.URUN_ID;
                    r.FOTO = i.FOTO;
                    r.URUN_FIYAT = i.URUN_FIYAT;
                    r.MIKTAR = i.MIKTAR;
                    urunList.Add(r);
                }
            }

            Session["Sepet"] = urunList;
            return RedirectToAction("Index", "Sepet");
        }

        public ActionResult Siparis(int Id)
        {
            List<T_URUN_SEPET> urunList = new List<T_URUN_SEPET>();
            T_URUN search = et.T_URUN.Where(q => q.URUN_ID == Id).FirstOrDefault();
            List<T_URUN_SEPET> sepetler = (List<T_URUN_SEPET>)Session["Sepet"];
            if (sepetler != null)
            {
                foreach (var i in sepetler)
                {
                    T_URUN_SEPET r = new T_URUN_SEPET();

                    r.URUN_ADI = i.URUN_ADI;
                    r.URUN_ID = i.URUN_ID;
                    r.FOTO = i.FOTO;
                    r.URUN_FIYAT = i.URUN_FIYAT;
                    r.MIKTAR = 1;
                    urunList.Add(r);
                }
            }

            Session["Sepet"] = urunList;
            return RedirectToAction("Index", "Siparis");
        }

        public List<SelectListItem> UrunKgSelect()
        {
            List<SelectListItem> KgSelect = new List<SelectListItem>();
            
            for (int i = 1; i < 40; i++)
            {
                KgSelect.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            return ViewBag.UrunKg = KgSelect;
        }

    }
}