using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duyuru.Entities.Models;
namespace Duyuru.BLL
{
    public class DurumlarBLL
    {
        DB_DuyuruContext dc = new DB_DuyuruContext();
        public void Guncelle(Durumlar d)
        {
            Durumlar r = dc.Durumlars.Where(p=>p.Adi==d.Adi).FirstOrDefault();
            if (r.Durum) r.Durum = false;
            else r.Durum = true;
            int durum= dc.SaveChanges();
        }
        public Durumlar Get(string ad)
        {
            return dc.Durumlars.FirstOrDefault(p=>p.Adi==ad);

        }
    }
}
