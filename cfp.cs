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
    public partial class cfp : Form
    {

        MySqlConnection con;
        MySqlCommand cmd;
        
        public cfp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              try
            {
                cmd = new MySqlCommand("update canteen.cook set password=?b,c_password=?c where c_id='" + textBox1.Text + "'", con);
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
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            Hide();
            Form13 f13 = new Form13();
            f13.Show();
        
        }

        private void cfp_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
        }
    }
}
