using System;
using System.Collections.Generic;

namespace Duyuru.Entities.Models
{
    public partial class YayinAkisi
    {
        public int YayinAkisiID { get; set; }
        public int IcerikID { get; set; }
        public int GosterimSuresi { get; set; }
        public Nullable<System.DateTime> SonGosterimTarihi { get; set; }
        public Nullable<int> GosterimSayisi { get; set; }
        public virtual Icerikler Icerikler { get; set; }
    }
}
