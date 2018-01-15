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
    public partial class Form16 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
   
        public Form16()
        {
            InitializeComponent();
        }


        private void Form16_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
            int i = 0;
            cmd = new MySqlCommand("select max(w_id) from waiter", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (Convert.ToString(dr[0]) == "")
                {
                    i = 1;

                }
                else
                {
                    i = Convert.ToInt32(dr[0].ToString()) + 1;

                }
                textBox1.Text = Convert.ToString(i);

            }

            dr.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("insert into waiter(w_id,w_name,address,cont_no,u_name,password,salary,date) values(?a,?b,?c,?d,?e,?f,?g,?h)", con);
            cmd.Parameters.AddWithValue("?a", textBox1.Text);
            cmd.Parameters.AddWithValue("?b", textBox2.Text);
            cmd.Parameters.AddWithValue("?c", richTextBox1.Text);
            cmd.Parameters.AddWithValue("?d", textBox4.Text);
            cmd.Parameters.AddWithValue("?e", textBox3.Text);
            cmd.Parameters.AddWithValue("?f", textBox5.Text);
            cmd.Parameters.AddWithValue("?g", textBox6.Text);
            cmd.Parameters.AddWithValue("?h",dateTimePicker1.Text);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Waiter Added");

           // Hide();
 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            Hide();
        
        }

        private void label9_Click(object sender, EventArgs e)
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
            if ((textBox4.Text.Length > 10) || (textBox4.Text.Length < 10))
            {
                MessageBox.Show("invalid phone no");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
