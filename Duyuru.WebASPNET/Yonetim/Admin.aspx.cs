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
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null) Response.Redirect("../Login.aspx");
                Yoneticiler yeni = Session["admin"] as Yoneticiler;
                txtad.Text = yeni.AdSoyad;
                
        }

        protected void btnguncelle_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                 Yoneticiler yeni = Session["admin"] as Yoneticiler;
                 if (yeni.Sifre == txtsifre.Text)
                 {
                     yeni.AdSoyad = txtad.Text;
                     yeni.Sifre = txtyenisifretekrar.Text;
                     YoneticilerBLL bll = new YoneticilerBLL();
                     bll.Guncelle(yeni);
                 }
                 else
                 {
                     txtsifre.Text = ""; 
                     lblhata.Text = "Sifreniz yanlış girdiniz!!!";
                 }
            }
            else Response.Redirect("~/Login.aspx");
        }

        protected void btniptal_Click(object sender, EventArgs e)
        {
            //string a=Request.RawUrl==""?"~/Yonetim/Admin.aspx":Request.RawUrl;
            Response.Redirect("YayinAkisi.aspx");
        }
    }
}