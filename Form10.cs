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
    public partial class Form10 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
      
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new MySqlCommand("update canteen.admin set password=?b,c_password=?c where uname='"+textBox1.Text+"'", con);
                if (textBox2.Text == textBox3.Text)
                {

                    cmd.Parameters.AddWithValue("?b", textBox2.Text);
                    cmd.Parameters.AddWithValue("?c", textBox3.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Password updated");
                }
                else
                    MessageBox.Show("Password and confirm password do not match");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());

            }
            Hide();

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        
    }

}