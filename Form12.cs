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

namespace Login
{
    public partial class Form12 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd,cmd1;
        MySqlDataReader dr;
        

        public Form12()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            wfp w1 = new wfp();
            w1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("select w_id,password from waiter where w_id='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
            // cmd.Parameters.AddWithValue("?a", textBox1.Text);
            //cmd.Parameters.AddWithValue("?b", textBox2.Text);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if ((textBox1.Text == Convert.ToString(dr[0])) && (textBox2.Text == Convert.ToString(dr[1])))
                {
                    MessageBox.Show("Login Successful....!");
                    
                }
            }
            else
            {

                MessageBox.Show("Invalid login");
            }
                dr.Close();
                cmd1 = new MySqlCommand("insert into waiter_login values(?a,?b)", con);
                cmd1.Parameters.AddWithValue("?a", textBox1.Text);
                cmd1.Parameters.AddWithValue("?b", dateTimePicker1.Text);
                cmd1.ExecuteNonQuery();

                textBox1.Clear();
                textBox2.Clear();
                Hide();
                Main m1 = new Main();
                m1.Show();

            
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
