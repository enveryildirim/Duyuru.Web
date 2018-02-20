using System;
using System.Collections.Generic;

namespace Duyuru.Entities.Models
{
    public partial class Kantinciler
    {
        public int KantinciID { get; set; }
        public string Kantinci { get; set; }
        public System.DateTime Gun { get; set; }
    }
}
