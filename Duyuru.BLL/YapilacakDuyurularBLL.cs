using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duyuru.Entities.Models;
namespace Duyuru.BLL
{
    public class YapilacakDuyurularBLL
    {
        DB_DuyuruContext dc = new DB_DuyuruContext();
        public List<YapilacakDuyurular> GetAll()
        {

          
            List<YapilacakDuyurular> list = dc.YapilacakDuyurulars.ToList();
            //dc.YapilacakDuyurulars.SqlQuery("delete from YapilacakDuyurular");
            dc.SaveChanges();
            if (list.Count != 0) return list;
            else return list;
        }
        public void Ekle(DuyuruInfo y)
        {
          /*  string sorgu = "insert into YapilacakDuyurular(DuyuruID) values(" + y.DuyuruID.ToString() +")";
                dc.YapilacakDuyurulars.SqlQuery(sorgu);*/
            dc.YapilacakDuyurulars.Add(new YapilacakDuyurular() {DuyuruID=y.DuyuruID});   
            dc.SaveChanges();   
        }
        public void Sil(YapilacakDuyurular y)
        {
            YapilacakDuyurular r = dc.YapilacakDuyurulars.Where(p => p.ID == y.ID).FirstOrDefault();
            dc.YapilacakDuyurulars.Remove(r);
            dc.SaveChanges();
        }
    }
}
