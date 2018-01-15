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
    public partial class Form31 : Form
    {
        MySqlConnection con;
        MySqlDataAdapter da;
        MySqlCommand cmd;

        public Form31()
        {
            InitializeComponent();
        }

        private void Form31_Load(object sender, EventArgs e)
        {
            con = new MySqlConnection("server=localhost;username=root;pwd=niku2912;database=canteen");
            con.Open();
            /*cmd = new MySqlCommand("select * from purchase_new", con);

            da = new MySqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);

            CrystalReport8 myreport = new CrystalReport8();
            myreport.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = myreport;
            crystalReportViewer1.Show();*/
     
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("select * from purchase_new where date>=?a and date<=?b", con);
            cmd.Parameters.AddWithValue("?a", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("?b", dateTimePicker2.Text);




            da = new MySqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);

            CrystalReport8 myreport = new CrystalReport8();
            myreport.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = myreport;
            crystalReportViewer1.Show();
        }
    }
}
