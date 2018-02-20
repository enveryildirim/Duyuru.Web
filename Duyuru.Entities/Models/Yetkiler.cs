using System;
using System.Collections.Generic;

namespace Duyuru.Entities.Models
{
    public partial class Yetkiler
    {
        public Yetkiler()
        {
            this.Yoneticilers = new List<Yoneticiler>();
        }

        public int YetkiID { get; set; }
        public string Adi { get; set; }
        public virtual ICollection<Yoneticiler> Yoneticilers { get; set; }
    }
}
