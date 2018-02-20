using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duyuru.Entities.Models;
namespace Duyuru.BLL
{
    public class IceriklerBLL
    {
       
        DB_DuyuruContext dc = new DB_DuyuruContext();
        public void Ekle(Icerikler y)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            dc.Iceriklers.Add(y);
            dc.SaveChanges();
        }
        public void Guncelle(Icerikler y)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            var r = dc.Iceriklers.Where(p=>p.IcerikID==y.IcerikID).FirstOrDefault();
            r.IcerikURL = y.IcerikURL;
            r.Baslik = y.Baslik;
            dc.SaveChanges();
        }
        public void Sil(int id)
        {
            Icerikler i = dc.Iceriklers.Where(p => p.IcerikID == id).FirstOrDefault();
            dc.Iceriklers.Remove(i);
            dc.SaveChanges();
        }
        public Icerikler Get(int id)
        {
            return dc.Iceriklers.FirstOrDefault(p => p.IcerikID == id);
        }
        public List<Icerikler> GetAll()
        {
            return dc.Iceriklers.ToList();
        }
    
    }
}
