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
    public partial class Kullanicilar : System.Web.UI.Page
    {
        YoneticilerBLL yb = new YoneticilerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                yukle();
                DropDownList1.DataSource = yb.GetAllYetkiler();
                DropDownList1.DataTextField = "Adi";
                DropDownList1.DataValueField = "YetkiID";
                DropDownList1.DataBind();
                DropDownList2.DataSource = yb.GetAllYetkiler();
                DropDownList2.DataTextField = "Adi";
                DropDownList2.DataValueField = "YetkiID";
                DropDownList2.DataBind();
            }
            
        }
        void yukle()
        {
            if (Session["admin"] != null)
            {
                YoneticilerBLL yc = new YoneticilerBLL();
                Yoneticiler y = Session["admin"] as Yoneticiler;
                List<Yoneticiler> kullaniciler = yc.GetAll().Where(p => p.YoneticiID != y.YoneticiID).ToList();
                Repeater1.DataSource = kullaniciler;
                Repeater1.DataBind();
            }
            else Response.Redirect("..\\Login.aspx");
        }
        void modal(string m)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("$('#" + m + "').modal('show')");
            sb.Append("};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        public void m(string m)
         {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("$('#" + m + "').modal('show')");
            sb.Append("};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "g")
            {
                var y = yb.Get(Convert.ToInt32(e.CommandArgument));
                HiddenField1.Value = y.YoneticiID.ToString();
                txtguncellekullaniciadi.Text=y.AdSoyad;
                txtguncellesifre.Text = y.Sifre;
                DropDownList2.SelectedValue = y.YetkiID.ToString();
                modal("myModalGuncelleme");
            }
            else
            {
                var y = yb.Get(Convert.ToInt32(e.CommandArgument));
                HiddenField2.Value = y.YoneticiID.ToString();
                lblkullaniciadi.Text=y.AdSoyad;
                modal("myModalSil");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Yoneticiler y = new Yoneticiler();
            y.AdSoyad = txtkullaniciadi.Text;
            y.Sifre = txtsifresi.Text;
            y.YetkiID = Convert.ToInt32(DropDownList1.SelectedValue);
            yb.Ekle(y);
            txtkullaniciadi.Text = txtsifresi.Text = "";
            DropDownList1.SelectedIndex = 0;
            yukle();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (HiddenField1.Value != "")
            {
                Yoneticiler y = yb.Get(Convert.ToInt32(HiddenField1.Value));
                y.AdSoyad = txtguncellekullaniciadi.Text;
                y.Sifre = txtguncellesifre.Text;
                y.YetkiID =Convert.ToInt32(DropDownList2.SelectedValue);
                yb.Guncelle(y);
                txtkullaniciadi.Text = txtsifresi.Text = "";
                DropDownList2.SelectedIndex = 0;
                yukle();
            }
            else
            {
                Response.Redirect("..\\Login.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (HiddenField2.Value != "")
            {
                YoneticilerBLL yc = new YoneticilerBLL();
                Yoneticiler y = yc.Get(Convert.ToInt32(HiddenField2.Value));
                yb.Sil(y.YoneticiID);
                yukle();
            }
            else
            {
                Response.Redirect("..\\Login.aspx");
            }
        }
    }
}