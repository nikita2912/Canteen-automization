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
    public partial class Form27 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd,cmd1,cmd2,cmd3,cmd4,cmd5,cmd6;
        MySqlDataReader dr,dr1,dr2,dr3;
        TextBox[] data;
        ComboBox[] prod;
        TextBox[] qty;
        TextBox[] rate;
        TextBox[] tot_amt;
        DateTimePicker[] date;
        double tot_amount;
        //int prod_code;
        int pcode;

        int cnt;

        public Form27()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }




        private void Form27_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
           /* int i = 0;
            cmd = new MySqlCommand("select max(Bill_no) from purchase_new", con);
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
            dr.Close();*/
            cmd1 = new MySqlCommand("select * from supplier", con);
            dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1[1].ToString());
            }
            dr1.Close();

           // dr.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < cnt; i++)
            {

                if (radioButton1.Checked == true)
                {
                    cmd = new MySqlCommand("select * from packing_product", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        prod[i].Items.Add(dr[1].ToString());
                    }
                    dr.Close();
                }
                else
                    prod[i].Items.Clear();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < cnt; i++)
            {

                if (radioButton2.Checked == true)
                {
                    cmd = new MySqlCommand("select * from raw_material", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        prod[i].Items.Add(dr[2].ToString());
                    }
                    dr.Close();
                }
                else
                    prod[i].Items.Clear();
            }
        }

        private void amtcal(object sender, EventArgs e)
        {
            int flag = 0;

            cmd = new MySqlCommand("select * from packing_product where prod_name=?pn", con);
            cmd.Parameters.AddWithValue("?pn", ((ComboBox)sender).SelectedItem);

            dr =cmd.ExecuteReader();

           if (dr.Read())
            {
                /*for (int i = 0; i < cnt; i++)
                {
                    if (prod[i].Tag == ((ComboBox)sender).Tag && Convert.ToInt32(prod[i].Tag) == i)
                    {
                        rate[i].Text = dr["rate"].ToString();
                    }
                }
                flag = 1; */
            }

            dr.Close();
          /*  if (flag == 0)
            {
                cmd = new MySqlCommand("select * from packing_product where prod_name=?pn", con);
                cmd.Parameters.AddWithValue("?pn", ((ComboBox)sender).SelectedItem);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        if (prod[i].Tag == ((ComboBox)sender).Tag && Convert.ToInt32(prod[i].Tag) == i)
                        {
                            rate[i].Text = dr["rate"].ToString();
                        }
                    }
                    flag = 1;
                }

                dr.Close();*/

           // }
        }

        private void cal(object sender, EventArgs e)
        {

            for (int i = 0; i < cnt; i++)
            {
                if (qty[i].Tag == ((TextBox)sender).Tag && Convert.ToDouble(qty[i].Tag) == i)
                {
                    if (qty[i].Text != "")
                    {
                        tot_amt[i].Text =( (Convert.ToDouble(rate[i].Text) * Convert.ToDouble(qty[i].Text))).ToString();
                        tot_amount +=Convert.ToDouble(tot_amt[i].Text);
                       // textBox3.Text =(tot_amount).ToString();
                    }
                }
                tot_amount = 0;
            }

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            if (textBox2.Text != "")
            {
                cnt = Convert.ToInt32(textBox2.Text);
                data = new TextBox[cnt];
                prod = new ComboBox[cnt];
                rate = new TextBox[cnt];
                qty = new TextBox[cnt];
                tot_amt = new TextBox[cnt];
                date = new DateTimePicker[cnt];

            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tot_amt = 0;
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < cnt; i++)
            {
                data[i] = new TextBox();
                data[i].Size = new Size(67, 22);
                data[i].Text = (i + 1).ToString();
                flowLayoutPanel1.Controls.Add(data[i]);

                prod[i] = new ComboBox();
                prod[i].Size = new Size(130, 24);
                prod[i].Tag = i;
                flowLayoutPanel1.Controls.Add(prod[i]);

                rate[i] = new TextBox();
                rate[i].Size = new Size(130, 22);
                rate[i].Tag = i;
                flowLayoutPanel1.Controls.Add(rate[i]);

                qty[i] = new TextBox();
                qty[i].Size = new Size(130, 24);
                qty[i].Tag = i;
                flowLayoutPanel1.Controls.Add(qty[i]);

                date[i] = new DateTimePicker();
                date[i].Size = new Size(130, 24);
                flowLayoutPanel1.Controls.Add(date[i]);

                tot_amt[i] = new TextBox();
                tot_amt[i].Size = new Size(130, 24);
                tot_amt[i].Tag = i;
                flowLayoutPanel1.Controls.Add(tot_amt[i]);

                //TextChanged=data[i];
                prod[i].SelectedValueChanged += new EventHandler(amtcal);
                qty[i].TextChanged += new EventHandler(cal);
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             /*cmd1 = new MySqlCommand("select * from supplier", con);
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        comboBox1.Items.Add(dr[2].ToString());
                    }
                  dr1.Close();*/
                


        }

        private void button2_Click(object sender, EventArgs e)
        {
 
             int pcode=0;
            int count = Convert.ToInt32(textBox2.Text);
            for (int i = 0; i < count; i++)
            {

                cmd2 = new MySqlCommand("insert into purchase_new values(?a,?b,?c,?d,?e,?f,?g,?h,?i,?j,?k,?l,?m,?n)", con);
                cmd2.Parameters.AddWithValue("?a", textBox1.Text);
                cmd2.Parameters.AddWithValue("?b", comboBox1.Text);

                if (radioButton1.Checked == true)
                {
                    cmd2.Parameters.AddWithValue("?c", "packing product");
                }
                else
                {
                    cmd2.Parameters.AddWithValue("?c", "Raw Material");
                }

                cmd2.Parameters.AddWithValue("?d", comboBox2.Text);

                cmd2.Parameters.AddWithValue("?e", prod[i].Text);
                cmd2.Parameters.AddWithValue("?f", rate[i].Text);
                cmd2.Parameters.AddWithValue("?g", qty[i].Text);
                cmd2.Parameters.AddWithValue("?h", tot_amt[i].Text);
                cmd2.Parameters.AddWithValue("?i", textBox3.Text);

                cmd2.Parameters.AddWithValue("?j", comboBox3.Text);
                cmd2.Parameters.AddWithValue("?k", textBox5.Text);
                cmd2.Parameters.AddWithValue("?l", date[i].Text);
                cmd2.Parameters.AddWithValue("?m", dateTimePicker1.Text);
                //  cmd2.Parameters.AddWithValue("?j", textBox5.Text);
                cmd2.Parameters.AddWithValue("?n", pcode);
                cmd2.ExecuteNonQuery();
               // MessageBox.Show("Value added");

                if (radioButton1.Checked == true)
                {
                    cmd2 = new MySqlCommand("select * from packing_product where prod_name=?pc", con);
                    cmd2.Parameters.AddWithValue("?pc", prod[i].Text);
                    dr = cmd2.ExecuteReader();
                    if (dr.Read())
                    {
                        pcode =Convert.ToInt32(dr["prod_code"]);
                       // MessageBox.Show(pcode.ToString());
                    }
                    dr.Close();
                }
                else
                {
                    cmd2 = new MySqlCommand("select * from raw_material where prod_name=?pc", con);
                    cmd2.Parameters.AddWithValue("?pc", prod[i].Text);
                    dr = cmd2.ExecuteReader();
                    if (dr.Read())
                    {
                        pcode = Convert.ToInt32(dr["prod_code"]);
                    }
                    dr.Close();
                }

              
                cmd3 = new MySqlCommand("select * from stock where typeofproduct=?a and prod_code=?b", con);
                if (radioButton1.Checked == true)
                {
                    cmd3.Parameters.AddWithValue("?a", "packing product");
                }
                else
                {
                    cmd3.Parameters.AddWithValue("?a", "Raw Material");
                }
                cmd3.Parameters.AddWithValue("?b", pcode);

                dr2 = cmd3.ExecuteReader();
                if (dr2.Read())
                {
                    dr2.Close();
                    cmd4 = new MySqlCommand("update stock set total_qty=total_qty+  ?tq where prod_code=?pc and typeofproduct=?tp", con);
                    cmd4.Parameters.AddWithValue("?tq", qty[i].Text);
                    cmd4.Parameters.AddWithValue("?pc", pcode);

                    if (radioButton1.Checked == true)
                    {
                        cmd4.Parameters.AddWithValue("?tp", "packing product");
                    }
                    else
                    {
                        cmd4.Parameters.AddWithValue("?tp", "Raw Material");
                    }

                    cmd4.ExecuteNonQuery();

                    //  MessageBox.Show("Value updated");
                    //textBox1.Clear();
                    //textBox2.Clear();

                }
                else
                {
                    dr2.Close();
                    cmd4 = new MySqlCommand("insert into stock(total_qty,prod_code,typeofproduct) values(?tq,?pc,?tp)", con);
                    cmd4.Parameters.AddWithValue("?tq", qty[i].Text);
                    cmd4.Parameters.AddWithValue("?pc", pcode);

                    if (radioButton1.Checked == true)
                    {
                        cmd4.Parameters.AddWithValue("?tp", "packing product");
                    }
                    else
                    {
                        cmd4.Parameters.AddWithValue("?tp", "Raw Material");
                    }

                    cmd4.ExecuteNonQuery();
                   // MessageBox.Show("Value added into stock");
                    //textBox1.Clear();
                    //textBox2.Clear();
                }
            }
                if (comboBox2.Text == "Cash")
                {
                    MessageBox.Show("Payment successful");
                }
                else
                {
                    cmd5 = new MySqlCommand("insert into supplier_credit values(?bn,?sn,?na)", con);
                    cmd5.Parameters.AddWithValue("?bn", textBox1.Text);
                    cmd5.Parameters.AddWithValue("?sn", comboBox1.Text);
                    cmd5.Parameters.AddWithValue("?na", textBox5.Text);
                    cmd5.ExecuteNonQuery();
                    Form28 f28 = new Form28();
                    f28.Show();
                    // updating stock as per product 
                }
                Hide();    
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            double vat_amt;
            if (comboBox3.Text == (13.5).ToString())
            {
                vat_amt = ((Convert.ToDouble(textBox3.Text) * Convert.ToDouble(comboBox3.Text)) / 100);
                textBox5.Text = (Convert.ToDouble(textBox3.Text) + vat_amt).ToString();
            }
            else
            {
                vat_amt = ((Convert.ToDouble(textBox3.Text) * Convert.ToDouble(comboBox3.Text)) / 100);
                textBox5.Text = (Convert.ToDouble(textBox3.Text) + vat_amt).ToString();
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            totalcal(sender, e);
        }
        private void totalcal(object sender, EventArgs e)
        {
            double x = 0;
            for (int i = 0; i < cnt; i++)
            {
                if (tot_amt[i].Text != "")
                {
                    x += Convert.ToDouble(tot_amt[i].Text);


                }


            }
            textBox3.Text = x.ToString();

        }
        
        
    }
}

