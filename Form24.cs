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
    public partial class Form24 : Form
    {
        MySqlConnection con;
        
        MySqlCommand cmd;
        MySqlDataReader dr;
        public Form24()
        {
            InitializeComponent();
        }

        private void Form24_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;username=root;pwd=niku2912;database=canteen");
            con.Open();
            int i = 0;
            cmd = new MySqlCommand("select max(c_id) from complaint", con);
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
            cmd = new MySqlCommand("insert into complaint values(?a,?b,?c,?d)", con);
            cmd.Parameters.AddWithValue("?a", textBox1.Text);
            cmd.Parameters.AddWithValue("?b", textBox2.Text);
            cmd.Parameters.AddWithValue("?c", richTextBox1.Text);
            cmd.Parameters.AddWithValue("?d", dateTimePicker1.Text);

                /*
            cmd.Parameters.AddWithValue("?e", textBox3.Text);
            cmd.Parameters.AddWithValue("?f", textBox5.Text);
            cmd.Parameters.AddWithValue("?g", textBox6.Text);*/
            cmd.ExecuteNonQuery();

            MessageBox.Show("Complaint Saved");
            Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
