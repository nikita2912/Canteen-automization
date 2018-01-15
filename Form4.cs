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
    public partial class Form4 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public Form4()
        {
            InitializeComponent();
        }
      

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("insert into packing_product values(?a,?b,?c,?d,?e,?g)", con);
            cmd.Parameters.AddWithValue("?a",textBox1.Text);
            cmd.Parameters.AddWithValue("?b", textBox7.Text);
            cmd.Parameters.AddWithValue("?c", comboBox2.Text);
            cmd.Parameters.AddWithValue("?d", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("?e", dateTimePicker2.Text);
            
            cmd.Parameters.AddWithValue("?g", textBox9.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Value added");
            textBox1.Clear();
            textBox7.Clear();
            //textBox8.Clear();
            textBox9.Clear();
            Hide();
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
            int i = 0;
            cmd = new MySqlCommand("select max(prod_code) from packing_product",con);
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
        private void txt_keypress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)8))
                e.Handled = true;
        }

        private void textbox9_leave(object sender, EventArgs e)
        {
           // if((textBox9.Text)==true)
        }


       


      

        
    }
}
