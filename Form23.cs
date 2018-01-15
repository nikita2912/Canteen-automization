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
    public partial class Form23 : Form
    {

        MySqlConnection con;
        MySqlDataAdapter da;
        MySqlCommand cmd;

        public Form23()
        {
            InitializeComponent();
        }

        private void Form23_Load(object sender, EventArgs e)
        {

            con = new MySqlConnection("server=localhost;username=root;pwd=niku2912;database=canteen");
            con.Open();
            cmd = new MySqlCommand("select * from purchase", con);

            da = new MySqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds, "prod_code");

            CrystalReport5 myreport = new CrystalReport5();
            myreport.SetDataSource(ds.Tables["prod_code"]);
            crystalReportViewer1.ReportSource = myreport;
            crystalReportViewer1.Show();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
