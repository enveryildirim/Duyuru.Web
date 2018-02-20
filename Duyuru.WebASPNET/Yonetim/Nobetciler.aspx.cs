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
    public partial class Nobetciler : System.Web.UI.Page
    {
        NobetcilerBLL nb = new NobetcilerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = nb.GetAll();
            Repeater1.DataBind();
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
        public TimeSpan  ConverttoTimeSpan(string s)
        {
            try
            {
                TimeSpan saat = TimeSpan.Parse(txtnobetsaati.Text);
                return saat;
            }
            catch (Exception)
            {
                
                lblhata.Text="yanlış veri girdiniz lütfen kontrol ediniz ";
                return TimeSpan.Parse("00:00");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                DateTime gun =ConvertToDateTime(txtnobetgun.Text);
                 TimeSpan saat = TimeSpan.Parse(txtnobetsaati.Text);
                var result = nb.GetAll().Where(p => p.Gun == gun && p.Saat ==saat).FirstOrDefault();
                if (result == null)
                {
                    nb.Ekle(new Entities.Models.Nobetciler(){Gun=gun,Saat=saat,Nobetci=txtnobetci.Text});
                    Repeater1.DataSource = nb.GetAll();
                    Repeater1.DataBind();
                }
                else 
                    lblhata.Text="Bu güne ve saate eklenmiş nöbetçi var ";
            }
            catch (Exception)
            {
                
                lblhata.Text="yanlış veri girdiniz lütfen kontrol ediniz ";
            }
            

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (HiddenField1.Value != "")
            {
                var n = nb.GetAll().Where(p=>p.NobetciID==Convert.ToInt32(HiddenField1.Value)).FirstOrDefault();
                n.Saat=ConverttoTimeSpan(txtguncellemesaat.Text);
                n.Nobetci = txtguncellenobetciler.Text;
                Repeater1.DataSource = nb.GetAll();
                Repeater1.DataBind();
                lblguncelnobetcilikgunu.Text = ""; txtguncellemesaat.Text = txtguncellenobetciler.Text = ""; 
                HiddenField1.Value = "";
               

            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (HiddenField2.Value != null)
            {
                var n = nb.GetAll().Where(p => p.NobetciID == Convert.ToInt32(HiddenField2.Value)).FirstOrDefault();
                nb.Sil(n.NobetciID);
                Repeater1.DataSource = nb.GetAll();
                Repeater1.DataBind();
                lblsilnobetciler.Text ="";
                lblsilnobetcilikgunu.Text = "";
                lblsilnobetciliksaat.Text = "";
                HiddenField2.Value = "";
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "g")
            {
                var r= nb.GetAll().Where(p=>p.NobetciID==Convert.ToInt32(e.CommandArgument)).FirstOrDefault();
                lblguncelnobetcilikgunu.Text =r.Gun.ToLongDateString();
                txtguncellemesaat.Text =r.Saat.ToString();
                txtguncellenobetciler.Text =r.Nobetci;
                HiddenField1.Value = r.NobetciID.ToString();
                modal("myModalGuncelleme");
            }
            else 
            {
                var r = nb.GetAll().Where(p => p.NobetciID == Convert.ToInt32(e.CommandArgument)).FirstOrDefault();
                lblsilnobetciler.Text = r.Nobetci;
                lblsilnobetcilikgunu.Text = r.Gun.ToLongDateString();
                lblsilnobetciliksaat.Text = r.Saat.ToString();
                HiddenField2.Value = r.NobetciID.ToString();
                modal("myModalSil");
            }
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
    }
}