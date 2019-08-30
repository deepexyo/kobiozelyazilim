using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;


namespace KobiÖzelYazılım
{
    public partial class Xml_Örnek : Form
    {
        public Xml_Örnek()
        {
            InitializeComponent();
        }

        private void Xml_Örnek_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(bugun);
            DateTime tarih = Convert.ToDateTime(xmldoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);

            string USD = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/BanknoteSelling").InnerXml;
            label1.Text = string.Format("Tarih {0} USD; {1}", tarih.ToShortDateString(), USD);

            string Euro = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            label2.Text = string.Format("Tarih {0} EURO; {1}", tarih.ToShortDateString(), Euro);

            string POUND = xmldoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            label3.Text = string.Format("Tarih {0} POUND; {1}", tarih.ToShortDateString(), POUND);

        }
    }
}
