using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duyuru.Entities.Models;
namespace Duyuru.BLL
{
    public class NobetcilerBLL
    {
        DB_DuyuruContext dc = new DB_DuyuruContext();
        public void Ekle(Nobetciler y)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            dc.Nobetcilers.Add(y);
            dc.SaveChanges();
        }
        public void Guncelle(Nobetciler y)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            Nobetciler r = dc.Nobetcilers.Where(p=>p.NobetciID==y.NobetciID).FirstOrDefault();
            r.Gun = y.Gun;
            r.Nobetci = y.Nobetci;
            r.Saat = y.Saat;
            dc.SaveChanges();
        }
        public void Sil(int  id)
        {
            Nobetciler n = dc.Nobetcilers.Where(p => p.NobetciID == id).FirstOrDefault();
            dc.Nobetcilers.Remove(n);
            dc.SaveChanges();
        }
        public List<Nobetciler> Get(DateTime dt)
        {
            return dc.Nobetcilers.Where(p => p.Gun == dt).ToList();
        }
        public List<Nobetciler> GetAll()
        {
            return dc.Nobetcilers.ToList();
        }

    }
}
