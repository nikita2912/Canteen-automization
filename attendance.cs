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
    public partial class attendance : Form
    {
        MySqlConnection con;
        MySqlCommand cmd, cmd1,cmd2;
        MySqlDataReader dr,dr1;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;
        public attendance()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ds = new DataSet();
            //int p;
               cmd = new MySqlCommand("select waiter_login.w_id as'waiter Id',count(*)  as 'Total Days'from waiter_login group by w_id ", con);
               /* dr=cmd.ExecuteReader();
                if (dr.Read())

                {

                    p = Convert.ToInt32(dr[1].ToString()) * 200;
                    MessageBox.Show("" + p);
            
                
                }// */     
                ///dt = new DataTable();
          // cmd = new MySqlCommand("select waiter_login.w_id,waiter.w_name,count(*) from waiter_login left join waiter on waiter_login.w_id=waiter.w_id group by w_id", con);    
            da = new MySqlDataAdapter(cmd);
                //        dt = new DataTable();
               // da.Fill(ds);
  
               // dr.Close();
                da.Fill(ds,"w_id");
                dataGridView1.AutoGenerateColumns = true;

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Refresh();
          }
               
       

        private void attendance_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
            con.Open();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ds = new DataSet();
           // int p;
            cmd = new MySqlCommand("select cook_login.c_id as 'Cook ID', count(*) as 'Total days' from cook_login group by c_id", con);
  
         //   cmd = new MySqlCommand("select cook_login.c_id as 'Cook ID',count(*) as 'Total Days' from cook_login group by c_id ", con);
           /* dr=cmd.ExecuteReader();
            if (dr.Read())
            {
                p=Convert.ToInt32(dr[1].ToString()) * 200;
                MessageBox.Show(""+p);
            
            }
            dr.Close();
            //        dt = new DataTable();*/
            da = new MySqlDataAdapter(cmd);
            //        dt = new DataTable();
           // da.Fill(ds);
 
            da.Fill(ds,"c_id");
            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       /* private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                cmd2 = new MySqlCommand("select w_id from waiter_login where count(*)=?a ",con);
                cmd2.Parameters.AddWithValue("?a",dataGridView1);
            }

            Form14 f14 = new Form14();
            f14.Show();
            Hide();
        }*/
    }
}
