using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duyuru.Entities.Models;
namespace Duyuru.BLL
{
    public class YayinAkisiBLL
    {
        DB_DuyuruContext dc = new DB_DuyuruContext();
        public void Ekle(YayinAkisi y)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
                dc.YayinAkisis.Add(y);
                dc.SaveChanges();

        }
        public void Guncelle(YayinAkisi y)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            YayinAkisi r = dc.YayinAkisis.Where(p=>p.YayinAkisiID==y.YayinAkisiID).FirstOrDefault();
            r.GosterimSayisi = y.GosterimSayisi;
            r.GosterimSuresi = y.GosterimSuresi;
            r.IcerikID = r.IcerikID;
            r.SonGosterimTarihi = r.SonGosterimTarihi;
            dc.SaveChanges();
        }
        public void Sil(int id)
        {
            YayinAkisi y = dc.YayinAkisis.Where(p => p.YayinAkisiID == id).FirstOrDefault();
            dc.YayinAkisis.Remove(y);
            dc.SaveChanges();
        }
        public YayinAkisi Get(int id)
        {
           // dc.Duyurulars.SqlQuery("delete from YayinAkisi where SonGosterimTarihi < @date ", DateTime.Now);
            return dc.YayinAkisis.FirstOrDefault(p=>p.YayinAkisiID==id);
        }
        public List<YayinAkisi> GetAll()
        {
            dc.Duyurulars.SqlQuery("delete from YayinAkisi where SonGosterimTarihi < @date ", DateTime.Now);
            return dc.YayinAkisis.ToList();
        }
    }
}
