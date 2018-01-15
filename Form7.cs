using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Login
{
    public partial class Form7 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
       
        int toa;
        int bno;
        public Form7(int bno,int toa)
        {
            InitializeComponent();
            this.toa = toa;
            this.bno = bno;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
            textBox4.Text = Convert.ToInt32(toa).ToString();
            textBox1.Text = Convert.ToInt32(bno).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("insert into credit values(?a,?b,?c,?d,?e)", con);
            cmd.Parameters.AddWithValue("?a", textBox1.Text);
            cmd.Parameters.AddWithValue("?b", textBox2.Text);
            cmd.Parameters.AddWithValue("?c", textBox3.Text);
            cmd.Parameters.AddWithValue("?d", textBox4.Text);
            cmd.Parameters.AddWithValue("?e", dateTimePicker1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("succesfully Added...!");


            Form8 f8 = new Form8();
            f8.Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_keypress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)8))
            {
                e.Handled = true;
             }
                
      
        }

        private void txt_leave(object sender, EventArgs e)
        {
            if ((textBox3.Text.Length > 10) || (textBox3.Text.Length < 10))
            {
                MessageBox.Show("invalid phone no");
            }

        }
    }
}
