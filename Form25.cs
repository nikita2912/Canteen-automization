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

    public partial class Form25 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd, cmd1;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;
        int i;

        public Form25()
        {
            InitializeComponent();
        }

        private void Form25_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            // ds1 = new DataSet();

            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");

            con.Open();


            cmd = new MySqlCommand("select complaint.c_id as 'Complaint ID',complaint.customer_name as 'Customer Name', complaint.complaint as 'Complaint',complaint.date as 'Date' from complaint ", con);
            da = new MySqlDataAdapter(cmd);
            //        dt = new DataTable();
            da.Fill(ds);
            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd1 = new MySqlCommand();
            if (dataGridView1.Rows.Count > 1 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
            {
                cmd1.CommandText = "delete from complaint where c_id=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "";
                //con.Open();
                cmd1.Connection = con;
                cmd1.ExecuteNonQuery();
                con.Close();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                MessageBox.Show("Row has been deleted");
                Hide();
            }

        }
    }
}
