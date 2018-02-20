using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duyuru.Entities.Models;
namespace Duyuru.BLL
{
    public class KantincilerBLL
    {
        DB_DuyuruContext dc = new DB_DuyuruContext();
        public void Ekle(Kantinciler y)
        {
            dc.Kantincilers.Add(y);
            dc.SaveChanges();
        }
        public void Guncelle(Kantinciler y)
        {
            Kantinciler  r = dc.Kantincilers.Where(p=>p.KantinciID==y.KantinciID).FirstOrDefault();
            r.Kantinci = y.Kantinci;
            r.Gun = y.Gun;
            dc.SaveChanges();
        }
        public void Sil(int id)
        {
            Kantinciler k = dc.Kantincilers.Where(p => p.KantinciID == id).FirstOrDefault();
            dc.Kantincilers.Remove(k);
            dc.SaveChanges();
        }
        public Kantinciler Get(DateTime dt)
        {
            return dc.Kantincilers.FirstOrDefault(p => p.Gun == dt);
        }
        public List<Kantinciler> GetAll()
        {
            return dc.Kantincilers.ToList();
        }

    }
}
