using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Duyuru.BLL;
using Duyuru.Entities.Models;
namespace Duyuru.WebASPNET.Yonetim
{
    public partial class Kantin : System.Web.UI.Page
    {
        DurumlarBLL db = new DurumlarBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            yukle();
        }
        void yukle()
        {
            var durum = db.Get("Kantin");
            if (durum.Durum)
            {
                lbldurum.Text = "Açık";
                LinkButton1.Text = "Kapat";
            }
            else
            {
                lbldurum.Text = "Kapalı";
                LinkButton1.Text = "Aç";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            db.Guncelle(db.Get("Kantin"));
            var durum = db.Get("Kantin");
            if (durum.Durum)
            {
                lbldurum.Text = "Açık";
                LinkButton1.Text = "Kapat";
            }
            else
            {
                lbldurum.Text = "Kapalı";
                LinkButton1.Text = "Aç";
            }
           
        }
    }
}