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
    public partial class Form32 : Form
    {
        MySqlConnection con;
        MySqlDataAdapter da,da1;
        MySqlCommand cmd;

        public Form32()
        {
            InitializeComponent();
        }

        private void Form32_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;username=root;pwd=niku2912;database=canteen");
            con.Open();
           // cmd = new MySqlCommand("select * from purchase_new", con);

            da = new MySqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
           // da.Fill(ds);

            cmd = new MySqlCommand("select packing_product.prod_code ,packing_product.prod_name , packing_product.expiry_date ,stock.total_qty from stock,packing_product where stock.prod_code=packing_product.prod_code and stock.total_qty<10", con);
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            CrystalReport9 myreport = new CrystalReport9();
            myreport.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = myreport;
            crystalReportViewer1.Show();
     
        }
    }
}
