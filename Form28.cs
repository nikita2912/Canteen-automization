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
    public partial class Form28 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;
        public Form28()
        {
            InitializeComponent();
        }

        private void Form28_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            // ds1 = new DataSet();

            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");

            con.Open();


            cmd = new MySqlCommand("select supplier_credit.bill_no as 'Bill No',supplier_credit.supp_name as 'Supplier Name', supplier_credit.net_amt as 'Total Amount' from supplier_credit ", con);
            da = new MySqlDataAdapter(cmd);
            //        dt = new DataTable();
            da.Fill(ds);
            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();

         }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd2 = new MySqlCommand("update supplier_credit set net_amt=?n where bill_no='" + dataGridView1.CurrentRow.Cells["Bill No"].Value.ToString() + "'", con);
            cmd2.Parameters.AddWithValue("?n", dataGridView1.CurrentRow.Cells["Total Amount"].Value.ToString());
            cmd2.ExecuteNonQuery();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MySqlCommand cmd1 = new MySqlCommand();
            if (dataGridView1.Rows.Count > 1 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
            {
                cmd1.CommandText = "delete from supplier_credit where bill_no=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "";
                //con.Open();
                cmd1.Connection = con;
                cmd1.ExecuteNonQuery();
                con.Close();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                MessageBox.Show("Row has been deleted");
            }

        }

        
    }
}
