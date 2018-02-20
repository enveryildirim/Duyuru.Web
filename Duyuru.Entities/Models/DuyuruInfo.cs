using System;
using System.Collections.Generic;

namespace Duyuru.Entities.Models
{
    public partial class DuyuruInfo
    {
        public DuyuruInfo()
        {
            this.YapilacakDuyurulars = new List<YapilacakDuyurular>();
        }

        public int DuyuruID { get; set; }
        public string DuyuruAdi { get; set; }
        public string DuyuruAdresi { get; set; }
        public virtual ICollection<YapilacakDuyurular> YapilacakDuyurulars { get; set; }
    }
}
