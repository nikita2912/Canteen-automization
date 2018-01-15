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
    public partial class Form14 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd,cmd1,cmd2;
        MySqlDataReader dr,dr1,dr2,dr3;
        int pay_id;

        public Form14()
        {

            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
             int i = 0;
            cmd = new MySqlCommand("select max(p_id) from payment",con);
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
                textBox2.Text = Convert.ToString(i);

            }

            dr.Close();
        
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (radioButton1.Checked == true)
            {
                cmd1 = new MySqlCommand("select * from supplier where s_name=?a ", con);
                cmd1.Parameters.AddWithValue("?a", comboBox1.Text);
                dr1=cmd1.ExecuteReader();
                if (dr1.Read())
                {
                   
                    pay_id = Convert.ToInt32(dr[0]);
                }
                
            }
            else */
                if (radioButton2.Checked == true)
                {
                    cmd1 = new MySqlCommand("select * from waiter where w_name=?b ", con);
                    cmd1.Parameters.AddWithValue("?b", comboBox1.Text);
                   dr1= cmd1.ExecuteReader();
                   if (dr1.Read())
                    {


                        pay_id = Convert.ToInt32(dr1[0]);

                        textBox4.Text = pay_id.ToString();
                        dr1.Close();

                        cmd2 = new MySqlCommand("select count(*) from waiter_login where w_id=?c and instr(date,'" + comboBox2.Text + "')", con);
                        cmd2.Parameters.AddWithValue("?c", pay_id);
                        dr3 = cmd2.ExecuteReader();
                        if (dr3.Read())
                        {
                            textBox3.Text = dr3[0].ToString();
                            textBox1.Text = (Convert.ToDouble(textBox3.Text) * 200).ToString();
                        }
                        dr3.Close();

                       // textBox4.Text = (dr1[0]).ToString();
                    }
                }
                else if (radioButton3.Checked == true)
                    {
                        cmd1 = new MySqlCommand("select * from cook where c_name=?c ", con);
                        cmd1.Parameters.AddWithValue("?c", comboBox1.SelectedItem);
                        dr1=cmd1.ExecuteReader();

                        if (dr1.Read())
                        {

                            pay_id= Convert.ToInt32(dr1[0]);

                            textBox4.Text = pay_id.ToString();
                            dr1.Close();
                           
                            cmd2 = new MySqlCommand("select count(*) from cook_login where c_id=?c and instr(date,'"+ comboBox2.Text +"')", con);
                            cmd2.Parameters.AddWithValue("?c", pay_id);
                            dr2=cmd2.ExecuteReader();
                            if (dr2.Read())
                            {
                                textBox3.Text = dr2[0].ToString();
                                textBox1.Text = (Convert.ToDouble(textBox3.Text) * 200).ToString();
                            }
                            dr2.Close();


                        }
                    }
            dr1.Close();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                cmd = new MySqlCommand("select * from waiter", con);
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

       
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                cmd = new MySqlCommand("select * from cook", con);
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

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("insert into payment values(?id,?pn,?nm,?amt,?dt)", con);
            cmd.Parameters.AddWithValue("?id", textBox4.Text);
           /* if (radioButton1.Checked == true)
            {
                cmd.Parameters.AddWithValue("?pn", "Supplier");
            }
            else */ 
            if (radioButton2.Checked == true)
            {
                cmd.Parameters.AddWithValue("?pn", "Waiter");
                //cmd1 = new MySqlCommand("select w_id,count(*) from waiter_login where w_id=?a", con);
                //cmd1.Parameters.AddWithValue("?a", textBox4.Text);
             //  cmd1.ExecuteReader();

               
            }
            else
            {
                cmd.Parameters.AddWithValue("?pn", "Cook");
            }

            cmd.Parameters.AddWithValue("?nm", comboBox1.Text);
            cmd.Parameters.AddWithValue("?amt", textBox1.Text);
            cmd.Parameters.AddWithValue("?dt", dateTimePicker1.Text);
            
            cmd.ExecuteNonQuery();
           // dr.Close();
            MessageBox.Show("Value added");
            MessageBox.Show("Payment Successful");
            this.Hide();

        }

        private void txt_keypress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)8))
                e.Handled = true;
      
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
           // cmd2 = new MySqlCommand("select w_id,count(*) from waiter_login group by w_id=?a", con);
            //cmd2.Parameters.AddWithValue("?a", textBox4.Text);
            //dr2 = cmd2.ExecuteReader();
            //if (dr2.Read())
            //{
                //int pay = Convert.ToInt32(dr2[1].ToString()) * 200;
                //MessageBox.Show("" + pay);
            //}
            //dr2.Close();
            
        }

        /*private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }*/
    }
}
