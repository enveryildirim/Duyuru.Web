using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Duyuru.Entities.Models;
using Duyuru.BLL;
namespace Duyuru.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void cal(string yolu)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = yolu;
            player.Play();
        }
        void CalW(string url)
        {
             //ac.Filter = "Media File(*.mpg,*.dat,*.avi,*.wmv,*.wav,*.mp3)|*.wav;*.mp3;*.mpg;*.dat;*.avi;*.wmv";
             axWindowsMediaPlayer1.URL = url;
             axWindowsMediaPlayer1.Ctlcontrols.play();
             axWindowsMediaPlayer1.Ctlcontrols.stop();
        
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            YapilacakDuyurularBLL yb = new YapilacakDuyurularBLL();
            var result = yb.GetAll();
            if (result.Count != 0)
            {
                var pl = axWindowsMediaPlayer1.playlistCollection.newPlaylist("plList");

                foreach (var item in result)
                {
                    pl.appendItem(axWindowsMediaPlayer1.newMedia(Application.StartupPath + "/mp3/" + item.DuyuruInfo.DuyuruAdresi));
                    yb.Sil(item);
                }
                axWindowsMediaPlayer1.currentPlaylist = pl;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                timer1.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Kaydet")
            {
                if (txtduyuruadi.Text != "" || txtduyurudosya.Text != "")
                {
                    FileInfo f = new FileInfo(Application.StartupPath + "/mp3/" + txtduyurudosya.Text);
                    int durum = dosyalar.IndexOf(txtduyurudosya.Text);
                    if (durum < 0) { MessageBox.Show("dosya tanınmadı"); return; }
                    if (!f.Exists) MessageBox.Show("Dosya Bulanamdı");
                    else
                    {

                        DuyuruInfoBLL db = new DuyuruInfoBLL();
                        var a = db.GetAll().Where(p => p.DuyuruAdresi == (txtduyurudosya.Text + ".mp3")).ToList();
                        if (a.Count == 0)
                        {
                            DuyuruInfo d = new DuyuruInfo();
                            d.DuyuruAdi = txtduyuruadi.Text;
                            d.DuyuruAdresi = txtduyurudosya.Text;
                            db.Ekle(d);
                            DuyuruInfoBLL db2 = new DuyuruInfoBLL();
                            foreach (var item in db2.GetAll())
                            {
                                string[] dizi = new string[] { item.DuyuruID.ToString(), item.DuyuruAdi, item.DuyuruAdresi };
                                ListViewItem li = new ListViewItem(dizi);
                                listView1.Items.Add(li);
                            }
                            txtduyuruadi.Text = "";
                            txtduyurudosya.Text = "";
                            MessageBox.Show("Eklendi :)");
                        }
                        else
                            MessageBox.Show("Dosya Ekli !!!!");
                    }
                }
                else MessageBox.Show("Lütfen Boş Bırakmayın");
            }
            else 
            {
                if (lblid.Text != "")
                {
                    DuyuruInfoBLL db = new DuyuruInfoBLL();
                    DuyuruInfo d = db.GetAll().Where(p => p.DuyuruID == Convert.ToInt32(lblid.Text)).FirstOrDefault();
                    d.DuyuruAdi = txtduyuruadi.Text;
                    d.DuyuruAdresi = txtduyurudosya.Text;
                    db.Guncelle(d);
                    DuyuruInfoBLL db2 = new DuyuruInfoBLL();
                    foreach (var item in db2.GetAll())
                    {
                        string[] dizi = new string[] { item.DuyuruID.ToString(), item.DuyuruAdi, item.DuyuruAdresi };
                        ListViewItem li = new ListViewItem(dizi);
                        listView1.Items.Add(li);
                    }
                }
            }
            
        }
        List<string> dosyalar = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            dosyalar = new List<string>();
            DirectoryInfo d = new DirectoryInfo(Application.StartupPath+"/mp3");
            foreach (FileInfo item in d.GetFiles())
            {
                if (item.Extension == ".mp3")
                {
                    dosyalar.Add(item.Name);
                    txtduyurudosya.AutoCompleteCustomSource.Add(item.Name);
                }
            }
            DuyuruInfoBLL db2 = new DuyuruInfoBLL();
            foreach (var item in db2.GetAll())
            {
                string[] dizi = new string[] { item.DuyuruID.ToString(), item.DuyuruAdi, item.DuyuruAdresi };
                ListViewItem li = new ListViewItem(dizi);
                listView1.Items.Add(li);
            }

            timer1.Start();  // Başlatma
            timer1.Interval = 1000;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id= listView1.SelectedItems[0].SubItems[0].Text;
            DuyuruInfoBLL db = new DuyuruInfoBLL();
            if (MessageBox.Show("Silinsin mi??", "Silme Onayı", MessageBoxButtons.YesNoCancel) != DialogResult.Yes) return;
            db.Sil(Convert.ToInt32(id));
            DuyuruInfoBLL db2 = new DuyuruInfoBLL();
            foreach (var item in db2.GetAll())
            {
                string[] dizi = new string[] { item.DuyuruID.ToString(), item.DuyuruAdi, item.DuyuruAdresi };
                ListViewItem li = new ListViewItem(dizi);
                listView1.Items.Add(li);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            button1.Text = "Güncelle";
            lblid.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txtduyuruadi.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtduyurudosya.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lblid.Text = txtduyuruadi.Text = txtduyurudosya.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
           /* var pl = axWindowsMediaPlayer1.playlistCollection.newPlaylist("plList");
            YapilacakDuyurularBLL yb = new YapilacakDuyurularBLL();
            var result = yb.GetAll();
            foreach (var item in result)
            {
                pl.appendItem(axWindowsMediaPlayer1.newMedia(Application.StartupPath+"/mp3/"+item.DuyuruInfo.DuyuruAdresi));
            }
            axWindowsMediaPlayer1.currentPlaylist = pl;
            axWindowsMediaPlayer1.Ctlcontrols.play();*/
         
        }

        private void axWindowsMediaPlayer1_EndOfStream(object sender, AxWMPLib._WMPOCXEvents_EndOfStreamEvent e)
        {
            
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                timer1.Start();  // Başlatma
                timer1.Interval = 1000;
            }
                
            
        }
    }
}
