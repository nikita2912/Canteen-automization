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
    public partial class Form29 : Form
    {
        MySqlConnection con;
        MySqlDataAdapter da;
        MySqlCommand cmd;

        public Form29()
        {
            InitializeComponent();
        }

        private void Form29_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;username=root;pwd=niku2912;database=canteen");
            con.Open();
            cmd = new MySqlCommand("select * from stock", con);

            da = new MySqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds, "tot_qty");

            CrystalReport6 myreport = new CrystalReport6();
            myreport.SetDataSource(ds.Tables["tot_qty"]);
            crystalReportViewer1.ReportSource = myreport;
            crystalReportViewer1.Show();
        }
    }
}
