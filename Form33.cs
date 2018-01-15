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
    public partial class Form33 : Form
    {
        MySqlConnection con;
        MySqlDataAdapter da, da1;
        MySqlCommand cmd;


        public Form33()
        {
            InitializeComponent();
        }

        private void Form33_Load(object sender, EventArgs e)
        
        {
            con = new MySqlConnection("server=localhost;username=root;pwd=niku2912;database=canteen");
            con.Open();
           // cmd = new MySqlCommand("select * from purchase_new", con);

            da = new MySqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
           // da.Fill(ds);

            cmd = new MySqlCommand("select raw_material.prod_code,raw_material.Prod_name, raw_material.prod_type, stock.total_qty from stock,raw_material where stock.prod_code=raw_material.prod_code and stock.total_qty<=5", con);
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            CrystalReport10 myreport = new CrystalReport10();
            myreport.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = myreport;
            crystalReportViewer1.Show();


            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
