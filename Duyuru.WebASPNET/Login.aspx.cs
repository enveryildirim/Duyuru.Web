using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Duyuru.BLL;
using Duyuru.Entities.Models;
namespace Duyuru.WebASPNET
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
           lbluyari.Text=Request.QueryString["q"];
        }

        protected void btngiris_Click(object sender, EventArgs e)
        {

            if (txtad.Text != "" || txtsifre.Text != "")
            {
                YoneticilerBLL yb =new YoneticilerBLL();
                var y = yb.GetAll().Where(p => p.AdSoyad == txtad.Text && p.Sifre == txtsifre.Text).FirstOrDefault();
                if (y != null)
                {
                    Session["admin"] = y;
                    if (y.YetkiID == 1 || y.YetkiID == 2)
                        Response.Redirect("Yonetim/YayinAkisi.aspx");
                    else if (y.YetkiID == 3)
                        Response.Redirect("Yonetim/Yemekciler.aspx");
                    else if (y.YetkiID == 4)
                        Response.Redirect("Yonetim/Nobetciler.aspx");
                    else if (y.YetkiID == 6)
                        Response.Redirect("Yonetim/Kantin.aspx");
                    else lbluyari.Text = "Sistemde hata oldu lütfen yetkili birisine başvurunuz!!!!";
                }
                else
                {
                    lbluyari.Text = "Hata bilgi girdiniz lütfen kontrol ediniz.";
                }
            }
            else
                lbluyari.Text = "Boş Bırakmayınız!!!!";

        }

        protected void btniptal_Click(object sender, EventArgs e)
        {
            txtsifre.Text = txtad.Text = "";
        }
    }
}