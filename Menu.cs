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
    public partial class Menu : Form
    {
        MySqlConnection con;
        MySqlCommand cmd,cmd1;
        MySqlDataReader dr;
        public Menu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
            int i = 0;
            cmd1 = new MySqlCommand("select max(menu_code) from menu",con);
            dr = cmd1.ExecuteReader();
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
            cmd = new MySqlCommand("insert into menu values(?a,?b,?c,?d,?e)",con);
            cmd.Parameters.AddWithValue("?a",textBox1.Text);
            cmd.Parameters.AddWithValue("?b",comboBox1.Text);
            cmd.Parameters.AddWithValue("?c", textBox2.Text);
            cmd.Parameters.AddWithValue("?d", textBox6.Text);
            cmd.Parameters.AddWithValue("?e", textBox5.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Menu inserted");
            con.Close();
            Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txt_keypress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)8))
                e.Handled = true;
    
        }
    }
}
