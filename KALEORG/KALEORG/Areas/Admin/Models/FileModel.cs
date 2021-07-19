using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KALEORG.Areas.Admin.Models
{
    public class FileModel
    {
        [Required(ErrorMessage ="Lütfen seçiniz.")]
        [Display(Name ="Dosya seç")]
        public HttpPostedFileBase[] files { get; set; }
        public int URUN_FOTO_ID { get; set; }
        public int URUN_ID { get; set; }
        public int FOTO { get; set; }
        

    }
}