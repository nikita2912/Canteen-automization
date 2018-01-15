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
    public partial class Form19 : Form
    {

        MySqlConnection con;
        MySqlCommand cmd,cmd1;
        MySqlDataReader dr;
        MySqlDataAdapter da;
        DataSet ds;
        public Form19()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            cmd1 = new MySqlCommand("delete from waiter where w_id=?b", con);
            cmd1.Parameters.AddWithValue("?b", textBox1.Text);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("" + comboBox1.Text +   "Deleted");
            textBox1.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("select * from waiter where w_name=?a", con);
            cmd.Parameters.AddWithValue("?a", comboBox1.Text);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox1.Text = Convert.ToString(dr[0]);
            }
            dr.Close();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
                con.Open();
                da = new MySqlDataAdapter("select * from waiter", con);
                da.Fill(ds);
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = "w_name";
                comboBox1.ValueMember = "w_id";
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            Hide();
       
        }
    }
}
