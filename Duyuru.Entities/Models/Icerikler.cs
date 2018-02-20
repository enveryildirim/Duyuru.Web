using System;
using System.Collections.Generic;

namespace Duyuru.Entities.Models
{
    public partial class Icerikler
    {
        public Icerikler()
        {
            this.YayinAkisis = new List<YayinAkisi>();
        }

        public int IcerikID { get; set; }
        public string Baslik { get; set; }
        public string IcerikURL { get; set; }
        public int EkleyenID { get; set; }
        public virtual Yoneticiler Yoneticiler { get; set; }
        public virtual ICollection<YayinAkisi> YayinAkisis { get; set; }
    }
}
