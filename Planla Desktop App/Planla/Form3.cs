using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data.SqlTypes;

namespace Planla
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SQLiteConnection conn = new SQLiteConnection("Data Source=karakus2.sqlite;Version=3;Read Only=False;Full Control=True");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string guncelle = ("UPDATE saatler SET saat1='" + textBox1.Text + "',saat2='" + textBox2.Text + "',saat3='" + textBox3.Text + "',saat4='" + textBox4.Text + "',saat5='" + textBox5.Text + "',saat6='" + textBox6.Text + "', saat7='" + textBox7.Text + "'");
                SQLiteCommand command1 = new SQLiteCommand(guncelle, conn);
                command1.ExecuteNonQuery();
                MessageBox.Show("Saatler güncellenmiştir. [1]");
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Birşeyler ters gitti. Programı kapatıp açınız. Aksi takdirde üreticiye ulaşınız mail: karakusnavy@gmail.com");
            }
           
           
           
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from saatler";
            cmd.ExecuteNonQuery();
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr["saat1"].ToString();
                textBox2.Text = dr["saat2"].ToString();
                textBox3.Text = dr["saat3"].ToString();
                textBox4.Text = dr["saat4"].ToString();
                textBox5.Text = dr["saat5"].ToString();
                textBox6.Text = dr["saat6"].ToString();
                textBox7.Text = dr["saat7"].ToString();
            }
            conn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata! Program dosyalarında hata meydana gelmiş olabilir.");
            }
            
        }
    }
}
