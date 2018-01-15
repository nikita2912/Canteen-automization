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
    public partial class Form13 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd,cmd1;
        MySqlDataReader dr;
        public Form13()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           /*     cmd = new MySqlCommand("select c_id,password from cook where c_id=" + textBox1.Text + " and password='" + textBox2.Text + "'", con);
            // cmd.Parameters.AddWithValue("?a", textBox1.Text);
            //cmd.Parameters.AddWithValue("?b", textBox2.Text);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if ((textBox1.Text == Convert.ToString(dr[0])) && (textBox2.Text == Convert.ToString(dr[1])))
                {

                    MessageBox.Show("Login Successful....!");
                    
                    
                    // cmd1=insert into cook_login
                
                }
            }
            else
            {

                MessageBox.Show("Invalid login");
               // this.Show();
             }
           
            dr.Close();
            cmd1 = new MySqlCommand("insert into cook_login values(?a,?b)", con);
            cmd1.Parameters.AddWithValue("?a", textBox1.Text);
            cmd1.Parameters.AddWithValue("?b", dateTimePicker1.Text);
            cmd1.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();
            //Hide();*/

          // Main m1 = new Main();
            //m1.Show();


            cmd = new MySqlCommand("select c_id,password from cook where c_id='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
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
            cmd1 = new MySqlCommand("insert into cook_login values(?a,?b)", con);
            cmd1.Parameters.AddWithValue("?a", textBox1.Text);
            cmd1.Parameters.AddWithValue("?b", dateTimePicker1.Text);
            cmd1.ExecuteNonQuery();

            textBox1.Clear();
            textBox2.Clear();
            Hide();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cfp c1 = new cfp();
            c1.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form22 f22 = new Form22();
            f22.Show();
        }
        
    }
    
}
