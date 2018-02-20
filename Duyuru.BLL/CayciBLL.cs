using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duyuru.Entities.Models;
namespace Duyuru.BLL
{
    public class CayciBLL
    {
        DB_DuyuruContext dc = new DB_DuyuruContext();
        public void Ekle(Cayciler y)
        {
            dc.Caycilers.Add(y);
            dc.SaveChanges();
        }
        public void Guncelle(Cayciler y)
        {
            Cayciler r = dc.Caycilers.Where(p => p.CayciID == y.CayciID).FirstOrDefault();
            r.Cayci = y.Cayci;
            r.Gun = y.Gun;
            dc.SaveChanges();
        }
        public void Sil(int id)
        {
            Cayciler c = dc.Caycilers.Where(p => p.CayciID==id).FirstOrDefault();
            dc.Caycilers.Remove(c);
            dc.SaveChanges();
        }
        public Cayciler Get(int id)
        {
            return dc.Caycilers.FirstOrDefault(p => p.CayciID == id);
        }
        public List<Cayciler> GetAll()
        {
            return dc.Caycilers.ToList();
        }
    }
}
