using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duyuru.Entities.Models;
namespace Duyuru.BLL
{
  
    public  class DuyuruInfoBLL
    {
        public void Ekle(DuyuruInfo d)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            dc.DuyuruInfoes.Add(d);
            dc.SaveChanges();
        }
        public void Guncelle(DuyuruInfo d)
        {
            DB_DuyuruContext  dc =new DB_DuyuruContext();
            DuyuruInfo a = dc.DuyuruInfoes.Where(p => p.DuyuruID == d.DuyuruID).FirstOrDefault();
            a.DuyuruAdi = d.DuyuruAdi;
            a.DuyuruAdresi = d.DuyuruAdresi;
            dc.SaveChanges();
        }
        public void Sil(int id)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            DuyuruInfo d = dc.DuyuruInfoes.Where(p => p.DuyuruID == id).FirstOrDefault();
            dc.DuyuruInfoes.Remove(d);
            dc.SaveChanges();
        }
        public DuyuruInfo Get(int id)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            DuyuruInfo d = dc.DuyuruInfoes.Where(p => p.DuyuruID == id).FirstOrDefault();
            return d;
        }
        public List<DuyuruInfo> GetAll()
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            return dc.DuyuruInfoes.ToList();
        }
    }
}
