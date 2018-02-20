using System;
using System.Collections.Generic;

namespace Duyuru.Entities.Models
{
    public partial class Duyurular
    {
        public int DuyuruID { get; set; }
        public string Duyuru { get; set; }
        public Nullable<System.DateTime> SonGosterim { get; set; }
    }
}
