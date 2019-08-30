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
    public partial class frmSatışListele : Form
    {
        public frmSatışListele()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = SKRILLEX; Initial Catalog = Stok_takipp; Integrated Security = True");
        DataSet daset = new DataSet();

        private void satışListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from satis", baglanti);
            adtr.Fill(daset, "sepet");
            dataGridView1.DataSource = daset.Tables["satis"];

            baglanti.Close();





        }



        private void frmSatışListele_Load(object sender, EventArgs e)
        {

            satışListele();


        }
    }
}
