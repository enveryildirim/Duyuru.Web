using System;
using System.Collections.Generic;

namespace Duyuru.Entities.Models
{
    public partial class YapilacakDuyurular
    {
        public int ID { get; set; }
        public int DuyuruID { get; set; }
        public virtual DuyuruInfo DuyuruInfo { get; set; }
    }
}
