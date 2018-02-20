using Duyuru.BLL;
using Duyuru.Entities.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Duyuru.WebASPNET.Yonetim
{
    public partial class Icerik : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                Repeater1.DataSource = ib.GetAll();
                Repeater1.DataBind();
                DirectoryInfo d = new DirectoryInfo(Server.MapPath("IcerikFile"));
                if (!d.Exists)
                { d.Create(); }

        }
        void modal(string m)
        {
             System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("$('#"+m+"').modal('show')");
                sb.Append("};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

      public  void m(string m)
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
        IceriklerBLL ib = new IceriklerBLL();
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Yoneticiler admin = Session["admin"] as Yoneticiler;
            if (FileUpload1.HasFile)
            {
                ///dosyayı yukleme
                FileInfo file = new FileInfo(Server.MapPath("~/IcerikFile/") + FileUpload1.FileName);
                string filename = "";
                if (!file.Exists)
                    FileUpload1.SaveAs(Server.MapPath("~/IcerikFile/") + FileUpload1.FileName);
                filename = Server.MapPath("~/IcerikFile/") + FileUpload1.FileName;

                string message;
                var result = ib.GetAll().Where(p => p.IcerikURL == filename).FirstOrDefault();
                if(result==null){
                ib.Ekle(new Icerikler() { Baslik = txtyeniicerikbaslik.Text, IcerikURL = filename, EkleyenID = 1 });
                message = "İçerik  Yüklendi!! Başlık =" + txtyeniicerikbaslik.Text + "Dosya Adı : " + FileUpload1.FileName;
                Repeater1.DataSource = ib.GetAll();
                Repeater1.DataBind();
                }
                else
                    message = "İçerik  Yüklenemedi zaten eklenmiş Başlık"+txtyeniicerikbaslik.Text+" Dosya adı:"+filename;
                
                m(message);
                
            }
            else
            {
                lblhata.Text = "Lütfen Yüklenecek Bir Dosya Seçiniz.";

            }
          }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            var g = ib.Get(Convert.ToInt32(HiddenField1.Value));
            g.Baslik = txtguncellebaslik.Text;
            if (FileUpload2.HasFile)
            {
                FileInfo fi = new FileInfo(g.IcerikURL);
                fi.Delete();
                FileUpload2.SaveAs(Server.MapPath("~/IcerikFile/") + FileUpload2.FileName);
                g.IcerikURL= Server.MapPath("~/IcerikFile/") + FileUpload2.FileName;
            }
            ib.Guncelle(g);
            Repeater1.DataSource = ib.GetAll();
            Repeater1.DataBind();
            
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "g")
            {
                var i = ib.Get(Convert.ToInt32(e.CommandArgument));
                HiddenField1.Value = i.IcerikID.ToString();
                txtguncellebaslik.Text = i.Baslik;
                lblurl.Text = i.IcerikURL.Split('\\')[i.IcerikURL.Split('\\').Count() - 1];
                modal("myModalGuncelleme");
            }
            else
            {
               
                    var i = ib.Get(Convert.ToInt32(e.CommandArgument));
                    HiddenField1.Value = i.IcerikID.ToString();
                    lblbaslik.Text = i.Baslik;
                    lblekleyen.Text = i.Yoneticiler.AdSoyad;
                    lblicerik.Text= i.IcerikURL.Split('\\')[i.IcerikURL.Split('\\').Count() - 1];
                    modal("myModalSil");
                
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            ib.Sil(Convert.ToInt32(HiddenField1.Value));
            Repeater1.DataSource = ib.GetAll();
            Repeater1.DataBind();
        }
}
}