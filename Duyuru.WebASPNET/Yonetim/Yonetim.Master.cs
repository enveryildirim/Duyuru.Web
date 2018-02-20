using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Duyuru.Entities.Models;
using Duyuru.BLL;
namespace Duyuru.WebASPNET.Yonetim
{
    public partial class Yonetim : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Yoneticiler y =new Yoneticiler();
            List<kategori> link = new List<kategori>();
            y = Session["admin"] as Yoneticiler;
            if (y != null)
            {
                lblad.Text = y.AdSoyad;
                if (y.YetkiID == 1||y.YetkiID==2)
                {
                   
                    link.Add(new kategori() { link = "YayinAkisi.aspx", yazi = "Yayın Akışı" });
                    link.Add(new kategori() { link = "Icerik.aspx", yazi = "İçerikler" }); 
                    link.Add(new kategori() { link = "Yemekciler.aspx", yazi = "Yemekçiler" }); 
                    link.Add(new kategori() { link = "Nobetciler.aspx", yazi = "Nöbetçiler" });
                    link.Add(new kategori() { link = "Kantin.aspx", yazi = "Kantin" });
                    link.Add(new kategori() { link = "Kullanicilar.aspx", yazi = "Kullanıcılar" });
                    link.Add(new kategori() { link = "Admin.aspx", yazi = "Profilim" });
                    link.Add(new kategori() { link = "SesliDuyuru.aspx", yazi = "Sesli Duyurular" });
                }
                else if(y.YetkiID==3)
                {
                    link.Add(new kategori() { link = "Yemekciler.aspx", yazi = "Yemekçiler" }); 
                    link.Add(new kategori() { link = "Admin.aspx", yazi = "Profilim" });
                }

                else if (y.YetkiID == 4)
                {
                    link.Add(new kategori() { link = "Nobetciler.aspx", yazi = "Nöbetçiler" });
                    link.Add(new kategori() { link = "Admin.aspx", yazi = "Profilim" });
                }
                else if (y.YetkiID == 6)
                {
                    link.Add(new kategori() { link = "Kantin.aspx", yazi = "Kantin" });
                    link.Add(new kategori() { link = "Admin.aspx", yazi = "Profilim" });
                }
                else 
                {
                    Response.Redirect("../Login.aspx?q=Sistemde hata vardır lütfen yetkili ile görüşünüz");
                }
                Repeater1.DataSource = link;
                Repeater1.DataBind();


            }
            else 
            {
                Response.Redirect("../Login.aspx?q=İzinsiz giriş. Yetkili değilsiniz!!!");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Session.Remove("admin");
            Response.Redirect("../Login.aspx");
        }
    }
}