using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KobiÖzelYazılım
{
    public partial class frmÜrünEkle : Form
    {
        public frmÜrünEkle()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection("Data Source = SKRILLEX; Initial Catalog = Stok_takipp; Integrated Security = True");

        bool durum;
        private void barkodkontrol()
        {

            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from urun", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (txtBarkodNo.Text == read["barkodno"].ToString() || txtBarkodNo.Text == "")
                {

                    durum = false;

                }

            }
            baglanti.Close();

        }


        private void kategorigetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kategoribilgileri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboKategori.Items.Add(read["kategori"].ToString());
            }
            baglanti.Close();
        }


        private void frmÜrünEkle_Load(object sender, EventArgs e)
        {
            kategorigetir();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboMarka.Items.Clear();
            comboMarka.Text = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select kategori,marka from markabilgileri where kategori= '" + comboKategori.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboMarka.Items.Add(read["marka"].ToString());
            }
            baglanti.Close();
        }

        private void btnYeniEkle_Click(object sender, EventArgs e)
        {

            barkodkontrol();
            if (durum == true)
            {

                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into urun(barkodno,kategori,marka,urunadi,miktari,alisfiyati,satisfiyati,tarih) values(@barkodno,@kategori,@marka,@urunadi,@miktari,@alisfiyati,@satisfiyati,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
                komut.Parameters.AddWithValue("@kategori", comboKategori.Text);
                komut.Parameters.AddWithValue("@marka", comboMarka.Text);
                komut.Parameters.AddWithValue("@urunadi", txtUrunAdi.Text);
                komut.Parameters.AddWithValue("@miktari", int.Parse(txtMiktari.Text));
                komut.Parameters.AddWithValue("@alisfiyati", double.Parse(txtAlisFiyati.Text));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(txtSatisFiyati.Text));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ürün Eklendi");

            }
            else
            {
                MessageBox.Show("Böyle bir barkod no var", "Uyarı");


            }
            comboMarka.Items.Clear();
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {

                    item.Text = "";


                }
                if (item is ComboBox)
                {

                    item.Text = "";

                }


            }


        }

        private void BarkodNotxt_TextChanged(object sender, EventArgs e)
        {



        }

        private void BarkodNotxt_TextChanged_1(object sender, EventArgs e)
        {

            if (BarkodNotxt.Text == "")
            {
                lblMiktari.Text = "";
                foreach (Control item in groupBox2.Controls)

                {

                    if (item is TextBox)
                    {

                        item.Text = "";

                    }

                }



            }



            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from urun where barkodno like '" + BarkodNotxt.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {

                Kategoritxt.Text = read["kategori"].ToString();
                Markatxt.Text = read["marka"].ToString();
                UrunAditxt.Text = read["urunadi"].ToString();
                lblMiktari.Text = read["miktari"].ToString();
                AlisFiyatitxt.Text = read["alisfiyati"].ToString();
                SatisFiyatitxt.Text = read["satisfiyati"].ToString();


            }
            baglanti.Close();

        }

        private void btnVarOlanaEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update urun set miktari=+miktari+'" + int.Parse(Miktaritxt.Text) + "'where barkodno='" + BarkodNotxt.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            foreach (Control item in groupBox2.Controls)

            {

                if (item is TextBox)
                {

                    item.Text = "";

                }

            }

            MessageBox.Show("Var olan ürüne ekleme yapıldı");

        }
    }
}
   

