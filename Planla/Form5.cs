using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;


namespace Planla
{
    
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        MySqlConnection bag = new MySqlConnection("Server=176.53.65.71;Database=bavagirc_program;Uid=bavagirc_program;Pwd=123456789a;");
        MySqlDataAdapter kurye;
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        MySqlCommand kmt;
        //--------------------------------------------------------------
        MySqlConnection bag2 = new MySqlConnection("Server=176.53.65.71;Database=bavagirc_program;Uid=bavagirc_program;Pwd=123456789a;");
        MySqlDataAdapter kurye2;
        DataSet ds2 = new DataSet();
        BindingSource bs2 = new BindingSource();
        MySqlCommand kmt2;
        void baglan()
        {
            ds.Clear();
            string sorgu;
            sorgu = "select*from mesaj";
            kurye = new MySqlDataAdapter(sorgu, bag);
            kurye.Fill(ds);
            bs.DataSource = ds.Tables[0];
        }
        void baglan2()
        {
            ds2.Clear();
            string sorgu2;
            sorgu2 = "select*from duyuru";
            kurye2 = new MySqlDataAdapter(sorgu2, bag2);
            kurye2.Fill(ds2);
            bs2.DataSource = ds2.Tables[0];
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                baglan2();
                label1.DataBindings.Add("text", bs2, "duyuru");
            }
            catch (Exception)
            {

                MessageBox.Show("Birşeyler ters gitti. Programı kapatıp açınız. Aksi takdirde üreticiye ulaşınız mail: karakusnavy@gmail.com");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
   baglan();
            
                bag.Open();
                kmt = new MySqlCommand("insert into guncelleme (guncelleme) values ('" + textBox1.Text + "')", bag);
                kmt.ExecuteNonQuery();
                bag.Close();
                baglan();
                MessageBox.Show("Gönderildi");
            }
            catch (Exception)
            {

                MessageBox.Show("Birşeyler ters gitti. Programı kapatıp açınız. Aksi takdirde üreticiye ulaşınız mail: karakusnavy@gmail.com");
            }
         
            
                
           
        
        }
    }
}
