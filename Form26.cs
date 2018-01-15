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
    public partial class Form26 : Form
    {
        MySqlConnection con;
        MySqlDataAdapter da;
        MySqlCommand cmd;

        public Form26()
        {
            InitializeComponent();
        }

        private void Form26_Load(object sender, EventArgs e)
        {

        
        
        

            con = new MySqlConnection("server=localhost;username=root;pwd=niku2912;database=canteen");
            con.Open();
            cmd = new MySqlCommand("select prod_code from purchase where purchase.prod_code=raw_material.prod_code and purchase.prod_code=packing_product.prod_code ", con);

            da = new MySqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds, "prod_code");

            CrystalReport2 myreport = new CrystalReport2();
            myreport.SetDataSource(ds.Tables["prod_code"]);
            crystalReportViewer1.ReportSource = myreport;
            crystalReportViewer1.Show();
        }
    }
}
