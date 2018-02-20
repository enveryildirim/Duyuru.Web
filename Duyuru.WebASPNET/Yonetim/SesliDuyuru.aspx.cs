using Duyuru.BLL;
using Duyuru.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Duyuru.WebASPNET.Yonetim
{
    public partial class SesliDuyuru : System.Web.UI.Page
    {
        DuyuruInfoBLL db = new DuyuruInfoBLL();
        YapilacakDuyurularBLL yb = new YapilacakDuyurularBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = db.GetAll();
            Repeater1.DataBind(); 
        }
       static List<YapilacakDuyurular> list =  new List<YapilacakDuyurular>();
        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "g"&&list!=null)
            {
                YapilacakDuyurular a = list.Where(p => p.DuyuruID == Convert.ToInt32(e.CommandArgument.ToString())).FirstOrDefault();
                list.Remove(a);
                Repeater2.DataSource = list;
                Repeater2.DataBind();

            }
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
                var b = db.Get(Convert.ToInt32(e.CommandArgument.ToString()));
                YapilacakDuyurular a = new YapilacakDuyurular();
                a.DuyuruID = b.DuyuruID;
                a.DuyuruInfo = b;
                list.Add(a);
                Repeater2.DataSource = list;
                Repeater2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (list == null) return;
            YapilacakDuyurularBLL yb2 = new YapilacakDuyurularBLL();
            foreach (YapilacakDuyurular item in list)
                {
                    yb2.Ekle(item.DuyuruInfo);
                }
                m("Duyurular Kaydedildi ve en kısa sürede yapılacak!!!");
                list = null;
                Repeater2.DataSource = list;
                Repeater2.DataBind();
        }
    }
}