using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Planla
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=karakus2.sqlite;Version=3;Read Only=False;Full Control=True");
            conn.Open();
            MessageBox.Show("Veriler Sağlandı");
            SQLiteCommand cmd2 = conn.CreateCommand();
            cmd2.CommandText = "select * from pazartesi";
            cmd2.ExecuteNonQuery();
            SQLiteDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                bunifuMetroTextbox1.Text = dr2["saat1"].ToString();
                bunifuMetroTextbox2.Text = dr2["saat2"].ToString();
                bunifuMetroTextbox3.Text = dr2["saat3"].ToString();
                bunifuMetroTextbox4.Text = dr2["saat4"].ToString();
                bunifuMetroTextbox5.Text = dr2["saat5"].ToString();
                bunifuMetroTextbox6.Text = dr2["saat6"].ToString();
                bunifuMetroTextbox7.Text = dr2["saat7"].ToString();
            }
            conn.Close();
            label6.Text = DateTime.Now.DayOfWeek.ToString();
            timer1.Start();
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from saatler";
            cmd.ExecuteNonQuery();
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label1.Text = dr["saat1"].ToString();
                label3.Text = dr["saat2"].ToString();
                label5.Text = dr["saat3"].ToString();
                label7.Text = dr["saat4"].ToString();
                label9.Text = dr["saat5"].ToString();
                label11.Text = dr["saat6"].ToString();
                label13.Text = dr["saat7"].ToString();
            }
            conn.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
            try
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=karakus2.sqlite;Version=3;Read Only=False;Full Control=True");
                conn.Open();
                string guncelle = ("UPDATE pazartesi SET saat1='" + bunifuMetroTextbox1.Text + "',saat2='" + bunifuMetroTextbox2.Text + "',saat3='" + bunifuMetroTextbox3.Text + "',saat4='" + bunifuMetroTextbox4.Text + "',saat5='" + bunifuMetroTextbox5.Text + "',saat6='" + bunifuMetroTextbox6.Text + "', saat7='" + bunifuMetroTextbox7.Text + "'");
                SQLiteCommand command1 = new SQLiteCommand(guncelle, conn);
                command1.ExecuteNonQuery();
                MessageBox.Show("Değişiklikler kaydedildi. [1]");
            }
            catch (Exception)
            {
                MessageBox.Show("Birşeyler ters gitti. Programı kapatıp açınız. Aksi takdirde üreticiye ulaşınız mail: karakusnavy@gmail.com");
            }
                WindowState = FormWindowState.Minimized;
                this.ShowIcon = false;
                this.ShowInTaskbar = false;
            
                
        }

      

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
        }
        Form4 frm4 = new Form4();
        private void timer1_Tick(object sender, EventArgs e)
        {
            SQLiteConnection conn2 = new SQLiteConnection("Data Source=karakus2.sqlite;Version=3;Read Only=False;Full Control=True");

            conn2.Open();
            SQLiteCommand cmd2 = conn2.CreateCommand();
            cmd2.CommandText = "select * from saatler";
            cmd2.ExecuteNonQuery();
            SQLiteDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                label1.Text = dr2["saat1"].ToString();
                label3.Text = dr2["saat2"].ToString();
                label5.Text = dr2["saat3"].ToString();
                label7.Text = dr2["saat4"].ToString();
                label9.Text = dr2["saat5"].ToString();
                label11.Text = dr2["saat6"].ToString();
                label13.Text = dr2["saat7"].ToString();
            }
            conn2.Close();

            //--------------------
            SQLiteConnection conn = new SQLiteConnection("Data Source=karakus2.sqlite;Version=3;Read Only=False;Full Control=True");
            label8.Text = DateTime.Now.ToShortTimeString();
            if ((label1.Text == label8.Text) && (bunifuiOSSwitch1.Value == true))
            {
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select * from pazartesi";
                    cmd.ExecuteNonQuery();
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bunifuiOSSwitch1.Value = false;
                        frm4.Show();
                        WindowState = FormWindowState.Normal;

                    }
                    conn.Close();
            }
            //--------------------------------------------------------------------------------------------------
            else if ((label3.Text == label8.Text) && (bunifuiOSSwitch2.Value == true))
            {
           

                   
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select * from pazartesi";
                    cmd.ExecuteNonQuery();
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bunifuiOSSwitch2.Value = false;
                        frm4.Show();
                        WindowState = FormWindowState.Normal;

                    }
                    conn.Close();
                
            }
            //-------------------------------------------------------------------------------------------------
            else if ((label5.Text == label8.Text) && (bunifuiOSSwitch3.Value == true))
            {
           
           
                 
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select * from pazartesi";
                    cmd.ExecuteNonQuery();
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bunifuiOSSwitch3.Value = false;
                        frm4.Show();
                        WindowState = FormWindowState.Normal;

                    }
                    conn.Close();
                
            }
            //--------------------------------------------------------------------------------------------------
            else if ((label7.Text == label8.Text) && (bunifuiOSSwitch4.Value == true))
            {
               
                 
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select * from pazartesi";
                    cmd.ExecuteNonQuery();
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bunifuiOSSwitch4.Value = false;
                        frm4.Show();
                        WindowState = FormWindowState.Normal;

                    }
                    conn.Close();
                
            }
            //-------------------------------------------------------------------------------------------------
            else if ((label9.Text == label8.Text) && (bunifuiOSSwitch5.Value == true))
            {
               
                
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select * from pazartesi";
                    cmd.ExecuteNonQuery();
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bunifuiOSSwitch5.Value = false;
                        frm4.Show();
                        WindowState = FormWindowState.Normal;

                    }
                    conn.Close();
                
            }
            //--------------------------------------------------------------------------------------------------
            else if ((label11.Text == label8.Text) && (bunifuiOSSwitch6.Value == true))
            {
                
                   
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select * from pazartesi";
                    cmd.ExecuteNonQuery();
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bunifuiOSSwitch6.Value = false;
                        frm4.Show();

                        WindowState = FormWindowState.Normal;
                    }
                    conn.Close();
                
            }
            //-------------------------------------------------------------------------------------------------
            else if ((label13.Text == label8.Text) && (bunifuiOSSwitch7.Value == true))
            {
        
               
                
                
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select * from pazartesi";
                    cmd.ExecuteNonQuery();
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bunifuiOSSwitch7.Value = false;
                        frm4.Show();

                        WindowState = FormWindowState.Normal;
                    }
                    conn.Close();
                
               

            }
            
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
           
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
         
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
           
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=karakus2.sqlite;Version=3;Read Only=False;Full Control=True");
                conn.Open();
                
                string guncelle = ("UPDATE pazartesi SET saat1='" + bunifuMetroTextbox1.Text + "',saat2='" + bunifuMetroTextbox2.Text + "',saat3='" + bunifuMetroTextbox3.Text + "',saat4='" + bunifuMetroTextbox4.Text + "',saat5='" + bunifuMetroTextbox5.Text + "',saat6='" + bunifuMetroTextbox6.Text + "', saat7='" + bunifuMetroTextbox7.Text + "'");
                SQLiteCommand command1 = new SQLiteCommand(guncelle, conn);
                command1.ExecuteNonQuery();
                MessageBox.Show("Değişiklikler kaydedildi. [1]");
            }
            catch (Exception)
            {
                MessageBox.Show("Birşeyler ters gitti. Programı kapatıp açınız. Aksi takdirde üreticiye ulaşınız mail: karakusnavy@gmail.com");
            }
          
        }

        private void timer2_Tick_2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://facebook.com/karakusbilisimcom");
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saatleri istediğiniz gibi ayarladıktan sonra aktif hale getirip kaydedince kullanım aktif hale gelecektir");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
           
        }
    }
}
