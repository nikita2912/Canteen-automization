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
    public partial class Form9 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd, cmd1;
        MySqlDataAdapter da;
        DataSet ds;
        DataTable dt;
       int i;
       // grdView.DataSource = ds;
           
        MySqlCommandBuilder cmb;
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            // ds1 = new DataSet();

            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");

            con.Open();


            cmd = new MySqlCommand("select credit.bill_no as 'Bill No',credit.cust_name as 'Customer Name', credit.cont_no as 'Contact No',credit.amount as 'Amount',credit.date as 'Date'  from credit ", con);
            da = new MySqlDataAdapter(cmd);
            //        dt = new DataTable();
            da.Fill(ds);
            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd1= new MySqlCommand();
                if (dataGridView1.Rows.Count > 1 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
            {
                cmd1.CommandText = "delete from credit where bill_no=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "";
                //con.Open();
                cmd1.Connection = con;
                cmd1.ExecuteNonQuery();
         //       con.Close();
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                MessageBox.Show("Row has been deleted");
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //for (i = 0; i < dataGridView1.SelectedRows.Count;i++ )
            //{
                //DialogResult result;
                //result = MessageBox.Show();
                MySqlCommand cmd2 = new MySqlCommand("update credit set amount=?n where bill_no='"+dataGridView1.CurrentRow.Cells["Bill No"].Value.ToString()+"'",con);
                cmd2.Parameters.AddWithValue("?n",dataGridView1.CurrentRow.Cells["Amount"].Value.ToString());
                cmd2.ExecuteNonQuery();
            //}
        }

      

    }
}



        
    

