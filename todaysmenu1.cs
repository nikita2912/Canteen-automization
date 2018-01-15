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
    public partial class todaysmenu1 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd, cmd1, cmd2, cmd4;
        MySqlDataAdapter da;
        //DataSet ds;
        DataTable dt;
     
        public todaysmenu1()
        {
            InitializeComponent();
        }

        private void todaysmenu1_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");

            con.Open();


            cmd = new MySqlCommand("select * from todaysmenu where date=?d order by menu_group", con);
            cmd.Parameters.AddWithValue("?d",dateTimePicker1.Value.ToShortDateString ());
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listBox1.Items.Add(dt.Rows[i]["menu_group"].ToString()+" : "+dt.Rows[i]["menu_name"].ToString());
            }

        }
    }
}
