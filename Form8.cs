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
    public partial class Form8 : Form
    {
        int i;
        MySqlConnection con;
        MySqlCommand cmd,cmd1,cmd2;
        MySqlDataReader dr;
        TextBox[] data; 
        ComboBox[] item;
        TextBox[] rate ;
        TextBox[] qty ;
        TextBox[] netamt; 
        int cnt;
        int toa;
        int bno;
        double totamt;
        public Form8()
        {
            InitializeComponent();
            cnt = 0;
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

       
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = (Convert.ToInt16(textBox5.Text) - Convert.ToInt16(textBox4.Text)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cmd = new MySqlCommand("insert into bill values(?a,?b,?c,?d,?e,?f)", con);
            cmd.Parameters.AddWithValue("?a", textBox1.Text);
            cmd.Parameters.AddWithValue("?b", comboBox2.Text);
            cmd.Parameters.AddWithValue("?c", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("?d", textBox2.Text);
            cmd.Parameters.AddWithValue("?e", textBox4.Text);
            cmd.Parameters.AddWithValue("?f", comboBox1.Text);

            cmd.ExecuteNonQuery();
            int pcode=0;
            int count = Convert.ToInt32(textBox2.Text);
             for (i = 0; i < count; i++)
             {
                 cmd1 = new MySqlCommand("insert into bill_order values(?in,?rt,?qt,?ta,?bn)", con);
                 cmd1.Parameters.AddWithValue("?in", item[i].Text);
                 cmd1.Parameters.AddWithValue("?rt", rate[i].Text);
                 cmd1.Parameters.AddWithValue("?qt", qty[i].Text);
                 cmd1.Parameters.AddWithValue("?ta", textBox4.Text);
                 cmd1.Parameters.AddWithValue("?bn", textBox1.Text);
                 cmd1.ExecuteNonQuery();


                 cmd2 = new MySqlCommand("select * from packing_product where prod_name=?pc", con);
                 cmd2.Parameters.AddWithValue("?pc", item[i].Text);
                 dr=cmd2.ExecuteReader();
                 if (dr.Read())
                 {
                     pcode = Convert.ToInt32(dr["prod_code"]);
                 }
                 dr.Close();
                 cmd2 = new MySqlCommand("update stock set total_qty=total_qty-?qt where  typeofproduct='packing product' and prod_code=?pc", con);
                 cmd2.Parameters.AddWithValue("?qt", qty[i].Text);
                 
                 cmd2.Parameters.AddWithValue("?pc", pcode);
                cmd2.ExecuteNonQuery();
                cmd2 = new MySqlCommand("select total_qty from stock where prod_code=?pc", con);
                cmd2.Parameters.AddWithValue("?pc",pcode);
                dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    if (Convert.ToInt32(dr["total_qty"]) <= 3)
                        MessageBox.Show(item[i].Text + " remaining only " + dr[0]);
                }
                dr.Close();
            
                 // updating stock as per product 
             }
             if (comboBox2.Text == "Cash")
             {
                 MessageBox.Show("Payment Successful...!");
             }
             else
             {
                 toa = Convert.ToInt32(textBox4.Text);
                 bno = Convert.ToInt32(textBox1.Text);
                 Form7 f7 = new Form7(bno,toa);
                 f7.Show();
             }
             Hide();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
             con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
            int i = 0;
          //  int s = 1;
            //textBox7.Text = (1).ToString();
            cmd = new MySqlCommand("select max(bill_no) from bill", con);
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

            //this.reportViewer1.RefreshReport();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {

            totamt = 0;
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < cnt; i++)
            {
                data[i] = new TextBox();
                data[i].Size = new Size(67, 22);
                data[i].Text = (i + 1).ToString();
                flowLayoutPanel1.Controls.Add(data[i]);

                item[i] = new ComboBox();
                item[i].Size = new Size(109, 24);
                item[i].Tag = i;
                flowLayoutPanel1.Controls.Add(item[i]);

                rate[i] = new TextBox();
                rate[i].Size = new Size(109, 24);
                rate[i].Tag=i;
                flowLayoutPanel1.Controls.Add(rate[i]);

                qty[i] = new TextBox();
                qty[i].Size = new Size(109, 24);
                qty[i].Tag = i;
                flowLayoutPanel1.Controls.Add(qty[i]);

                netamt[i] = new TextBox();
                netamt[i].Size = new Size(109, 24);
                flowLayoutPanel1.Controls.Add(netamt[i]);
                //TextChanged=data[i];
                item[i].SelectedValueChanged  += new EventHandler(amtcal);
                qty[i].TextChanged += new EventHandler(cal);
              //  netamt[i].TextChanged += new EventHandler(totalcal);

            }
            for (int i = 0; i < cnt; i++)
            {
            
            cmd = new MySqlCommand("select * from todaysmenu where date=?d ", con);
            cmd.Parameters.AddWithValue("?d", dateTimePicker1.Value.ToShortDateString());

            dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    item[i].Items.Add(dr["menu_name"]);
                }
                dr.Close();
            
            }
            for (int i = 0; i < cnt; i++)
            {
            
            cmd = new MySqlCommand("select * from packing_product where expiry_date<=?d ", con);
            cmd.Parameters.AddWithValue("?d", dateTimePicker1.Text);

            dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    item[i].Items.Add(dr["prod_name"]);
                }
                dr.Close();
        
            }
         
            }

        private void amtcal(object sender, EventArgs e)
        {
            int flag = 0;
            totamt = 0;
            cmd = new MySqlCommand("select * from packing_product where prod_name=?pn", con);
            cmd.Parameters.AddWithValue("?pn", ((ComboBox)sender).SelectedItem);

             dr = cmd.ExecuteReader();

            if(dr.Read())
                {
                for(i=0;i<cnt;i++)
                {
                    if(item[i].Tag==((ComboBox)sender).Tag && Convert.ToInt32 (item[i].Tag) == i)
                    {
                    rate[i].Text= dr["rate"].ToString();
                    }
                }
                flag = 1;
               }

            dr.Close();
            if (flag == 0)
             {
                cmd = new MySqlCommand("select * from menu where menu_name=?pn", con);
                cmd.Parameters.AddWithValue("?pn", ((ComboBox)sender).SelectedItem);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    for (i = 0; i < cnt; i++)
                    {
                        if (item[i].Tag == ((ComboBox)sender).Tag && Convert.ToDouble(item[i].Tag) == i)
                        {
                        
                            rate[i].Text = dr["rate"].ToString();
                
                        }
                    }
                    flag = 1;
                }

                dr.Close();
            
            }
        }

        private void cal(object sender, EventArgs e)
        {

                for (i = 0; i < cnt; i++)
                {
                    if (qty[i].Tag == ((TextBox)sender).Tag && Convert.ToDouble(qty[i].Tag) == i)
                    {
                        if (qty[i].Text != "" )
                        {
                        netamt[i].Text = ((Convert.ToDouble (rate[i].Text) * Convert.ToDouble (qty[i].Text))).ToString();
                        totamt += Convert.ToDouble(netamt[i].Text);
                        //textBox4.Text = totamt.ToString();


                        }
                    }
                    totamt = 0;
                }
        }

        private void totalcal(object sender, EventArgs e)
        {
            double x=0;
            for (i = 0; i < cnt; i++)
            {
                    if (netamt[i].Text != "")
                    {
                        x += Convert.ToDouble(netamt[i].Text);
                        

                    }
                
              
            }
        textBox4.Text = x.ToString();

        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
            int i = 0;
            cmd = new MySqlCommand("select max(bill_no) from bill", con);
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //int s = 0;
            /*con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
            int s = 0;
            //cmd = new MySqlCommand("select max(bill_no) from bill_order", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (Convert.ToString(dr[0]) == "")
                {
                    s = 1;

                }
                else
                {
                    s = Convert.ToInt32(dr[0].ToString()) + 1;

                }
                textBox1.Text = Convert.ToString(s);

            }

            dr.Close();*/

            TextBox[] data = new TextBox[10];
            data[i]=new TextBox();
            data[i].Text = (i + 1).ToString();


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox2.Text != "")
            {
                cnt = Convert.ToInt32(textBox2.Text);
                data = new TextBox[cnt];
                item = new ComboBox[cnt];
                rate = new TextBox[cnt];
                qty = new TextBox[cnt];
                netamt = new TextBox[cnt];
            }        
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtb2_keypress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)8))
                e.Handled = true;
      
        }

        private void txtb3_keypress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)8))
                e.Handled = true;
      

        }

        private void txtb5_keypress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)8))
                e.Handled = true;
      
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            totalcal(sender,e);
        }
    }
}
