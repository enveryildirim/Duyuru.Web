using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duyuru.Entities.Models;
namespace Duyuru.BLL
{
    class DuyurularBLL
    {
        DB_DuyuruContext dc = new DB_DuyuruContext();
        public void Ekle(Duyurular y)
        {
            dc.Duyurulars.Add(y);
            dc.SaveChanges();
        }
        public void Guncelle(Duyurular y)
        {
            var r = dc.Duyurulars.Where(p=>p.DuyuruID==y.DuyuruID).FirstOrDefault();
            r.Duyuru = y.Duyuru;
            r.SonGosterim = y.SonGosterim;
            dc.SaveChanges();
        }
        public void Sil(int id)
        {
            Duyurular d = dc.Duyurulars.Where(p => p.DuyuruID == id).FirstOrDefault();
            dc.Duyurulars.Remove(d);
            dc.SaveChanges();
        }
        public Duyurular Get(int id)
        {
            dc.Duyurulars.SqlQuery("delete from Duyurular where songosterim < @date ",DateTime.Now);
            return dc.Duyurulars.FirstOrDefault(p => p.DuyuruID == id);
        }
        public List<Duyurular> GetAll()
        {
            dc.Duyurulars.SqlQuery("delete from Duyurular where songosterim < @date ", DateTime.Now);
            return dc.Duyurulars.ToList();
        }
    }
}
