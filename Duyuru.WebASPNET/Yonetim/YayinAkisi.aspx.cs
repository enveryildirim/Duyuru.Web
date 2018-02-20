using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Duyuru.BLL;
using Duyuru.Entities.Models;
using System.Globalization;
namespace Duyuru.WebASPNET.Yonetim
{
    public partial class YayinAkisi : System.Web.UI.Page
    {
        IceriklerBLL ib = new IceriklerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Icerikler> yakis = ib.GetAll();
            foreach (var item in yakis)
            {
                string a=item.IcerikURL.Split('\\')[item.IcerikURL.Split('\\').Count()-1];
                item.IcerikURL=a;
            }
            Repeater1.DataSource = yakis;
            Repeater1.DataBind();
            Repeater2.DataSource = yb.GetAll();
            Repeater2.DataBind();
            yayinakisi = new List<Entities.Models.YayinAkisi>();
        }
        List<Entities.Models.YayinAkisi> yayinakisi = null;
       
        YayinAkisiBLL yb = new YayinAkisiBLL();
        protected void btnkaydet_Click(object sender, EventArgs e)
        {
            if (HiddenField2.Value == "")
            {
                if (txtsuresi.Text != "" && txtsontarih.Text != "")
                {
                    Entities.Models.YayinAkisi yayin = new Entities.Models.YayinAkisi();
                    yayin.IcerikID = Convert.ToInt32(HiddenField1.Value);
                    yayin.SonGosterimTarihi = ConvertToDateTime(txtsontarih.Text);
                    yayin.GosterimSuresi = Convert.ToInt32(txtsuresi.Text);
                    yb.Ekle(yayin);
                    Repeater2.DataSource = yb.GetAll();
                    Repeater2.DataBind();
                    HiddenField1.Value = "";
                   
                }
                else m("süre ve tarih giriniz!!");
            }
            else
            {
                int a = Convert.ToInt32(HiddenField2.Value);
                Entities.Models.YayinAkisi yayin = yb.Get(a);
                yayin.SonGosterimTarihi = ConvertToDateTime(txtsontarih.Text);
                yayin.GosterimSuresi = Convert.ToInt32(txtsuresi.Text);
                yb.Guncelle(yayin);
                HiddenField2.Value = "";
                Repeater2.DataSource = yb.GetAll();
                Repeater2.DataBind();
            }
        }
        


        public DateTime ConvertToDateTime(string strDateTime)
        {
        DateTime dtFinaldate; string sDateTime;
        try { dtFinaldate = Convert.ToDateTime(strDateTime); }
        catch (Exception )
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
                var result = ib.Get(Convert.ToInt32(e.CommandArgument));
                HiddenField1.Value = e.CommandArgument.ToString();
                lblbaslik.Text = result.Baslik;
                txtsontarih.Text = "";
            }
        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "g")
            {
                string id = e.CommandArgument.ToString();
                var result = yb.Get(Convert.ToInt32(id));
                HiddenField2.Value = id;
                lblbaslik.Text = result.Icerikler.Baslik;
                txtsuresi.Text = result.GosterimSuresi.ToString();
                txtsontarih.Text = result.SonGosterimTarihi.ToString();
            }
            else
            {
                
                yb.Sil(Convert.ToInt32(e.CommandArgument));
                HiddenField2.Value = "";
                HiddenField1.Value = "";
                YayinAkisiBLL ybb = new YayinAkisiBLL();
                Repeater2.DataSource = ybb.GetAll();
                Repeater2.DataBind();
            }
        }
    }
}