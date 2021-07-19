using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KALEORG.Models
{
    public class ViewModel
    {
        public T_MUSTERI Musteri { get; set; }
        public T_ADRES Adres { get; set; }
        public List<T_URUN_SEPET> urunSepet { get; set; }
       
    }
}