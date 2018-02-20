using System;
using System.Collections.Generic;

namespace Duyuru.Entities.Models
{
    public partial class Nobetciler
    {
        public int NobetciID { get; set; }
        public string Nobetci { get; set; }
        public System.DateTime Gun { get; set; }
        public System.TimeSpan Saat { get; set; }
    }
}
