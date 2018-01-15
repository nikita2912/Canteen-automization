using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;

namespace Login
{
    public partial class Form30 : Form
    {
        MySqlConnection con;
        MySqlDataAdapter da;
        MySqlCommand cmd;

        public Form30()
        {
            InitializeComponent();
        }

        private void Form30_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;username=root;pwd=niku2912;database=canteen");
            con.Open();
            cmd = new MySqlCommand("select * from payment", con);

            da = new MySqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);

            CrystalReport7 myreport = new CrystalReport7();
            myreport.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = myreport;
            crystalReportViewer1.Show();
     
        }
    }
}
