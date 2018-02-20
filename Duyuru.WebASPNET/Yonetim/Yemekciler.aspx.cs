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
    public partial class Yemekciler : System.Web.UI.Page
    {
        YemekcilerBLL yb = new YemekcilerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = yb.GetAll();
            Repeater1.DataBind();
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
        public void m(string m)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(m);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "g")
            {
               var r= yb.GetAll().FirstOrDefault(p=>p.YemekciID==Convert.ToInt32(e.CommandArgument));
               lblyemekcilikgunu.Text = r.Gun.ToLongDateString();
               txtguncelleyemekciler.Text = r.Yemekciler1;
               modal("myModalGuncelleme");
            }
            else 
            {
                var r = yb.GetAll().FirstOrDefault(p => p.YemekciID == Convert.ToInt32(e.CommandArgument));
                lblsilyemekcilikgunu.Text = r.Gun.ToLongDateString();
                lblsilyemekciler.Text = r.Yemekciler1;
                modal("myModalSil");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime gun = ConvertToDateTime(txtyemekcigun.Text);
            var result = yb.GetAll().Where(p=>p.Gun==gun).FirstOrDefault();
            if (result == null)
            {
                yb.Ekle(new Entities.Models.Yemekciler() {Gun=gun,Yemekciler1=txtyemekciler.Text});
                Repeater1.DataSource = yb.GetAll();
                Repeater1.DataBind();
                txtyemekciler.Text = txtyemekcigun.Text = "";
            }
            else
                lblhata.Text="Bugune yemekçiler eklenmiştir..";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var result = yb.Get(DateTime.Parse(lblyemekcilikgunu.Text));
            if(result!=null)
            {
                result.Yemekciler1=txtguncelleyemekciler.Text;
                yb.Guncelle(result);
                Repeater1.DataSource = yb.GetAll();
                Repeater1.DataBind();
                lblsilyemekcilikgunu.Text = txtguncelleyemekciler.Text = "";
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            var result = yb.Get(ConvertToDateTime(lblsilyemekcilikgunu.Text));
            if (result != null)
            {
                yb.Sil(result);
                Repeater1.DataSource = yb.GetAll();
                Repeater1.DataBind();
                lblsilyemekcilikgunu.Text = "";
            }
            
        }
    }
}