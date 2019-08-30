using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KobiÖzelYazılım
{
    public partial class Anasayfa : Form

    {

        public Anasayfa()
        {
            InitializeComponent();
        }


        private void Anasayfa_Load(object sender, EventArgs e)
        {

         

        }

        private void button7_Click(object sender, EventArgs e)
        {

            Form1 ff = new Form1();
            ff.Show();



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
           Xml_Örnek ff = new Xml_Örnek();
            ff.Show();
        }
    }
}
