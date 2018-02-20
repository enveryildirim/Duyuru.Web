using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duyuru.Entities.Models;
using System.Data.Entity;

namespace Duyuru.BLL
{
    public class YoneticilerBLL
    {
        DB_DuyuruContext dc = new DB_DuyuruContext();
        public void Ekle(Yoneticiler y)
        {
            dc.Yoneticilers.Add(y);
            dc.SaveChanges();
        }
        public void Guncelle(Yoneticiler y)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            Yoneticiler r = dc.Yoneticilers.Where(p => p.YoneticiID == y.YoneticiID).SingleOrDefault();
            r.AdSoyad = y.AdSoyad;
            r.Sifre = y.Sifre;
            r.YetkiID = y.YetkiID;
           int durum= dc.SaveChanges();
            
        }
        public void Sil(int id)
        {
                 Yoneticiler y = dc.Yoneticilers.Where(p => p.YoneticiID == id).FirstOrDefault();
                dc.Yoneticilers.Remove(y);
                dc.SaveChanges();

         }
        public Yoneticiler Get(int id)
        {
            return dc.Yoneticilers.FirstOrDefault(p=>p.YoneticiID==id);
        }
        public List<Yoneticiler> GetAll()
        {
            return dc.Yoneticilers.ToList();
        }
        public Yoneticiler Login(string ad, string sifre)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            var result = dc.Yoneticilers.Where(p=>p.AdSoyad==ad || p.Sifre==sifre).FirstOrDefault();
            result.LoginMi = true;
            dc.SaveChanges();
            return result;
        }
        public void Logout(int id)
        {
            DB_DuyuruContext dc = new DB_DuyuruContext();
            var r = dc.Yoneticilers.FirstOrDefault(p=>p.YoneticiID==id);
            r.LoginMi = false;
            dc.SaveChanges();
        }
        public List<Yetkiler> GetAllYetkiler()
        {
            return dc.Yetkilers.ToList();
        }
    }

}
