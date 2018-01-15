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
    public partial class Form1 : Form
    {

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form10 f10=new Form10();
            f10.Show();
            Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            cmd = new MySqlCommand("select uname,password from admin where uname='"+textBox1.Text+"' and password='"+textBox2.Text+"'",con);
           // cmd.Parameters.AddWithValue("?a", textBox1.Text);
            //cmd.Parameters.AddWithValue("?b", textBox2.Text);
            dr=cmd.ExecuteReader();
            if(dr.Read())
            {
                if((textBox1.Text==Convert.ToString(dr[0])) && (textBox2.Text==Convert.ToString(dr[1])))
                {
                    Hide();
                    MinimumStock f2 = new MinimumStock();
                    f2.Show();
            //        Form2 f2 = new Form2();
              //      f2.Show();
                }
            }
            else
                MessageBox.Show("Invalid login");
            dr.Close();



            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main m1 = new Main();
            m1.Show();
        }

     
    }
}
