using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duyuru.Entities.Models;
namespace Duyuru.BLL
{
    public class YemekcilerBLL
    {
       
        public void Ekle(Yemekciler y)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            dc.Yemekcilers.Add(y);
            dc.SaveChanges();
        }
        public void Guncelle(Yemekciler y)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            Yemekciler r = dc.Yemekcilers.Where(p=>p.YemekciID==y.YemekciID).FirstOrDefault();
            r.Yemekciler1 = y.Yemekciler1;
            r.Gun = y.Gun;
           int durum= dc.SaveChanges();
        }
        public void Sil(Yemekciler id)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            Yemekciler y = dc.Yemekcilers.Where(p => p.YemekciID == id.YemekciID).FirstOrDefault();
            dc.Yemekcilers.Remove(y);
            dc.SaveChanges();
        }
        public Yemekciler Get(DateTime dt)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            return dc.Yemekcilers.FirstOrDefault(p => p.Gun==dt);
        }
        public List<Yemekciler> GetAll()
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            return dc.Yemekcilers.ToList();
        }
    }
}
