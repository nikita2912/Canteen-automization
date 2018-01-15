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
    public partial class todaysmenu : Form
    {
        MySqlConnection con;
        MySqlCommand cmd,cmd1,cmd2,cmd4;
        MySqlDataAdapter da;
        //DataSet ds;
        DataTable dt;
        public todaysmenu()
        {
            InitializeComponent();
        }

        private void todaysmenu_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");

            con.Open();


            cmd = new MySqlCommand("select * from menu where menu_group='Breakfast'", con);
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                checkedListBox1.Items.Add(dt.Rows[i]["menu_name"].ToString());
            }


            cmd1 = new MySqlCommand("select * from menu where menu_group='Chinese'", con);
            da = new MySqlDataAdapter(cmd1);
            dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                checkedListBox2.Items.Add(dt.Rows[i]["menu_name"].ToString());
            }


            cmd2 = new MySqlCommand("select * from menu where menu_group='South Indian'", con);
            da = new MySqlDataAdapter(cmd2);
            dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                checkedListBox3.Items.Add(dt.Rows[i]["menu_name"].ToString());
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            foreach (string x in checkedListBox1.CheckedItems  )
            {
               // MessageBox.Show(x);
            cmd4 = new MySqlCommand("insert into todaysmenu values(?a1,?a2,?a3)",con );
            cmd4.Parameters.AddWithValue ("?a1",dateTimePicker1.Value.ToShortDateString ());
            cmd4.Parameters.AddWithValue("?a2", x);
            cmd4.Parameters.AddWithValue("?a3", label3.Text );
            cmd4.ExecuteNonQuery();
            }

            foreach (string y in checkedListBox2.CheckedItems)
            {
                cmd4 = new MySqlCommand("insert into todaysmenu values(?a1,?a2,?a3)", con);
                cmd4.Parameters.AddWithValue("?a1", dateTimePicker1.Value.ToShortDateString());
                cmd4.Parameters.AddWithValue("?a2", y);
                cmd4.Parameters.AddWithValue("?a3", label2.Text);
                cmd4.ExecuteNonQuery();
            }
            foreach (string z in checkedListBox3.CheckedItems )
            {
                cmd4 = new MySqlCommand("insert into todaysmenu values(?a1,?a2,?a3)", con);
                cmd4.Parameters.AddWithValue("?a1", dateTimePicker1.Value.ToShortDateString());
                cmd4.Parameters.AddWithValue("?a2", z);
                cmd4.Parameters.AddWithValue("?a3", label4.Text);
                cmd4.ExecuteNonQuery();
            }
          
            todaysmenu1 tdm = new todaysmenu1();
            tdm.Show();
        }
    }
}
