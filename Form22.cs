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
    public partial class Form22 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd,cmd2;
        MySqlDataReader dr;
        MySqlDataAdapter da,da1;
        DataSet ds,ds1;
     
        public Form22()
        {
            InitializeComponent();
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
           
            ds = new DataSet();
            da = new MySqlDataAdapter("select *  from cook", con);
            da.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "c_name";
            comboBox1.ValueMember = "c_id";


            ds1 = new DataSet();
            da1 = new MySqlDataAdapter("select *  from raw_material", con);
            da1.Fill(ds1);
            comboBox2.DataSource = ds1.Tables[0];
            comboBox2.DisplayMember = "prod_name";
            comboBox2.ValueMember = "prod_code";

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmd = new MySqlCommand("select * from cook where c_name=?a", con);
            cmd.Parameters.AddWithValue("?a", comboBox1.Text);

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = Convert.ToString(dr[0]);
            }
            dr.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pcode = 0;
            cmd2 = new MySqlCommand("select * from raw_material where prod_name=?pc", con);
            cmd2.Parameters.AddWithValue("?pc", comboBox2.Text);
            dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                pcode = Convert.ToInt32(dr["prod_code"]);
            }
            dr.Close();

            cmd2 = new MySqlCommand("update stock set total_qty=total_qty-?qt where  typeofproduct='Raw Material' and prod_code=?pc", con);
            cmd2.Parameters.AddWithValue("?qt", textBox2.Text);

            cmd2.Parameters.AddWithValue("?pc", pcode);
            cmd2.ExecuteNonQuery();
            cmd2 = new MySqlCommand("select total_qty from stock where prod_code=?pc", con);
            cmd2.Parameters.AddWithValue("?pc", pcode);
            dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                if (Convert.ToInt32(dr["total_qty"]) <= 3)
                    MessageBox.Show(comboBox2.Text + " remaining only " + dr[0]);
            }
            dr.Close();
            MessageBox.Show("Raw Material Updated...!");
            this.Hide();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_keypress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)8))
                e.Handled = true;
    
        }
    }
}
