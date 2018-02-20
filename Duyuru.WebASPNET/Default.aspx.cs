using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Duyuru.BLL;
using Duyuru.Entities.Models;
using System.Globalization;
using System.IO;
namespace Duyuru.WebASPNET
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            YayinAkisiBLL yb = new YayinAkisiBLL();
            yayin = yb.GetAll();
        }
        List<YayinAkisi> yayin = null;
         static int uzunluk=0;
         static DateTime suresigosterim=DateTime.Now;
        void IcerikYukle()
        {
            YayinAkisiBLL yb = new YayinAkisiBLL();
            if (uzunluk !=yayin.Count)
            {
                Icerikler i = yayin[uzunluk].Icerikler;
                if (DateTime.Now > suresigosterim)
                {
                    
                    suresigosterim = DateTime.Now.AddSeconds(yayin[uzunluk].GosterimSuresi);
                    string[] dizi = i.IcerikURL.Split('\\');
                    divicerik.InnerHtml = "<img src='" + dizi[dizi.Count() - 2] + "\\" + dizi[dizi.Count() - 1] + "' class='img-responsive center-block' />";
                    uzunluk++;
                    //Timer4.Interval = yayin[uzunluk].GosterimSuresi * 1000;
                }
            }
            else
            {
                yayin = yb.GetAll();
                uzunluk = 0;
            }

        }

        void YemekcileriYukle()
        {
            YemekcilerBLL yb = new YemekcilerBLL();
            string tarih = DateTime.Now.Date.ToShortDateString();
            string tarih2 = DateTime.Now.Date.AddDays(1).ToShortDateString();
            string yeni = tarih.Split('.')[1] + "." + tarih.Split('.')[0] + "." + tarih.Split('.')[2];
            string yeni2 = tarih2.Split('.')[1] + "." + tarih2.Split('.')[0] + "." + tarih2.Split('.')[2];
            var y = yb.Get(ConvertToDateTime(yeni));
            var y2 = yb.Get(ConvertToDateTime(yeni2));
            string yazi="",yazi2="";
            if(y!=null)
            {
                foreach (string item in y.Yemekciler1.Split(','))
                {
                    yazi += "-" + item + "<br/>";
                }
            }
           
            else
                ltrbugunyemekciler.Text ="Boş";
            if (y2 != null)
            {
                foreach (string item in y2.Yemekciler1.Split(','))
                {
                    yazi2 += "-" + item + "<br/>";
                }
            }
            else
                ltryarinyemekcier.Text = "Boş";
            ltrbugunyemekciler.Text = yazi;
             ltryarinyemekcier.Text = yazi2;
        }
        void NobetcileriYukle()
        {
            NobetcilerBLL nb = new NobetcilerBLL();
            string tarih = DateTime.Now.Date.ToShortDateString();
            string tarih2 = DateTime.Now.Date.AddDays(1).ToShortDateString();
            string yeni = tarih.Split('.')[1] + "." + tarih.Split('.')[0] + "." + tarih.Split('.')[2];
            string yeni2 = tarih2.Split('.')[1] + "." + tarih2.Split('.')[0] + "." + tarih2.Split('.')[2];
            var y = nb.Get(ConvertToDateTime(yeni));
            var y2 = nb.Get(ConvertToDateTime(yeni2));
            string bn = "", yn = "";
            if (y.Count != 0)
            {

                foreach (var item in y)
                {
                    bn += "Adı:" + item.Nobetci + "--Saat:" + item.Saat.ToString() +"<br/>";
                }
            }
            else bn = "Boş";

            if (y2.Count != 0)
            {
                foreach (var item in y2)
                {
                    yn += "Adı:" + item.Nobetci + "--Saat:" + item.Saat.ToString() + "<br/>";
                }
            }
            else yn = "Boş";

            ltrbugunnobetciler.Text = bn;
            ltryarinnobetciler.Text = yn;

        }
        void KantinDurumu()
        {
            DurumlarBLL db = new DurumlarBLL();
            var durum = db.Get("Kantin");
            if (durum.Durum) ltrkantin.Text = "<p class='text-primary'>Açık</p>";
            else ltrkantin.Text = "<p class='text-danger'>Kapalı</p>";
        }
        public DateTime ConvertToDateTime(string strDateTime)
        {
            DateTime dtFinaldate; string sDateTime;
            try { dtFinaldate = Convert.ToDateTime(strDateTime); }
            catch (Exception)
            {
                string[] sDate = strDateTime.Split('/');
                sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
                dtFinaldate = Convert.ToDateTime(sDateTime);
            }
            return dtFinaldate;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            YemekcileriYukle();
        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            
            NobetcileriYukle();
        }

        protected void Timer3_Tick(object sender, EventArgs e)
        {
            KantinDurumu();
        }

        protected void Timer4_Tick(object sender, EventArgs e)
        {
         IcerikYukle();
           
        }
    }
}