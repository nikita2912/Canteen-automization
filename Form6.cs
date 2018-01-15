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
    public partial class Form6 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd,cmd1;
        MySqlDataReader dr;
        int prod_code;
        int rate;
        public Form6()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                cmd = new MySqlCommand("select * from packing_product where prod_name=?a ", con);
                cmd.Parameters.AddWithValue("?a", comboBox1.Text);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = Convert.ToString(dr[5]);
                    rate = Convert.ToInt32(dr[5]);
                    dateTimePicker2.Value = Convert.ToDateTime(dr[4]);
                    prod_code=Convert.ToInt32 (dr[0]);
                }
                else
                {

                    MessageBox.Show("no data found");
                }
            }
            else
            if (radioButton2.Checked == true)
            {
                cmd = new MySqlCommand("select * from raw_material where prod_name=?b ", con);
                cmd.Parameters.AddWithValue("?b", comboBox1.Text);
               
                //prod_code = Convert.ToInt32(dr[0]);
                dr=cmd.ExecuteReader();
                if (dr.Read())
                {
                   // textBox2.Text = Convert.ToString(dr[6]);
                   // dateTimePicker2.Value = Convert.ToDateTime(dr[4]);
                    prod_code = Convert.ToInt32(dr[0]);
                }
                else
                {

                    MessageBox.Show("no data found");
                }

               
            }
            dr.Close();

        }

        private void Form6_Load(object sender, EventArgs e)
        {

            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
            int i = 0;
            cmd = new MySqlCommand("select max(purchase_order_no) from purchase",con);
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
                textBox3.Text = Convert.ToString(i);

            }

            dr.Close();
        }
            
        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                cmd = new MySqlCommand("select * from packing_product", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[1].ToString());
                }
                dr.Close();
            }
            else
                comboBox1.Items.Clear();
         }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                cmd = new MySqlCommand("select * from raw_material", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[2].ToString());
                }
                dr.Close();
            }
            else
                comboBox1.Items.Clear();
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("insert into purchase(purchase_order_no,product_type,product_name,suppiler,qty,date,rate,prod_code) values(?a,?b,?c,?d,?e,?f,?g,?h)", con);
            cmd.Parameters.AddWithValue("?a", textBox3.Text);
            if (radioButton1.Checked == true)
            {
                cmd.Parameters.AddWithValue("?b", "packing product");
            }
            else
            {
                cmd.Parameters.AddWithValue("?b", "Raw Material");
            }
    
            cmd.Parameters.AddWithValue("?c", comboBox1.Text);
            cmd.Parameters.AddWithValue("?d", comboBox2.Text);
            cmd.Parameters.AddWithValue("?e", textBox1.Text);
            cmd.Parameters.AddWithValue("?f", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("?g", textBox2.Text);
            cmd.Parameters.AddWithValue("?h", prod_code);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Value added");
            //textBox1.Clear();
            //textBox2.Clear();
            
            MySqlCommand cmd2;
            MySqlDataReader dr2;
            cmd2=new MySqlCommand("select * from stock where typeofproduct=?a and prod_code=?b",con);
            if (radioButton1.Checked == true)
            {
                cmd2.Parameters.AddWithValue("?a", "packing product");
            }
            else
            {
                cmd2.Parameters.AddWithValue("?a", "Raw Material");
            }
            cmd2.Parameters.AddWithValue("?b",prod_code);
 
            dr2=cmd2.ExecuteReader();
            if (dr2.Read())
            {
                dr2.Close();
                cmd1 = new MySqlCommand("update stock set total_qty=total_qty+  ?tq where prod_code=?pc and typeofproduct=?tp", con);
                cmd1.Parameters.AddWithValue("?tq", textBox1.Text);
                cmd1.Parameters.AddWithValue("?pc", prod_code);

                if (radioButton1.Checked == true)
                {
                    cmd1.Parameters.AddWithValue("?tp", "packing product");
                }
                else
                {
                    cmd1.Parameters.AddWithValue("?tp", "Raw Material");
                }

                cmd1.ExecuteNonQuery();

                MessageBox.Show("Value updated");
                textBox1.Clear();
                textBox2.Clear();
                
            }
            else
            {
                dr2.Close();
                cmd1 = new MySqlCommand("insert into stock(total_qty,prod_code,typeofproduct) values(?tq,?pc,?tp)", con);
                cmd1.Parameters.AddWithValue("?tq", textBox1.Text);
                cmd1.Parameters.AddWithValue("?pc", prod_code);

                if (radioButton1.Checked == true)
                {
                    cmd1.Parameters.AddWithValue("?tp", "packing product");
                }
                else
                {
                    cmd1.Parameters.AddWithValue("?tp", "Raw Material");
                }

                cmd1.ExecuteNonQuery();
                MessageBox.Show("Value added");
                textBox1.Clear();
                textBox2.Clear();
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox2.Text = (Convert.ToInt32(textBox1.Text) * rate).ToString();
            }
            else
                textBox2.Text = rate.ToString();
        }

        private void txt_keypress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)8))
                e.Handled = true;
      
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("payment successful......!");
            this.Hide();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
 