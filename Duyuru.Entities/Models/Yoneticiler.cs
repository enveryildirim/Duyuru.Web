using System;
using System.Collections.Generic;

namespace Duyuru.Entities.Models
{
    public partial class Yoneticiler
    {
        public Yoneticiler()
        {
            this.Iceriklers = new List<Icerikler>();
        }

        public int YoneticiID { get; set; }
        public string AdSoyad { get; set; }
        public string Sifre { get; set; }
        public bool LoginMi { get; set; }
        public int YetkiID { get; set; }
        public virtual ICollection<Icerikler> Iceriklers { get; set; }
        public virtual Yetkiler Yetkiler { get; set; }
    }
}
