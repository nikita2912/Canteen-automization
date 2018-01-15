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
    public partial class MinimumStock : Form
    {
        MySqlConnection con;
        MySqlCommand cmd, cmd1, cmd2, cmd4;
        MySqlDataAdapter da,da1;
        DataSet ds,ds1;
        DataTable dt;
        int cnt;
        public MinimumStock()
        {
            InitializeComponent();
            cnt = 0;
        }

        private void DisplayStock_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds1 = new DataSet();

            con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");

            con.Open();


            cmd = new MySqlCommand("select packing_product.Prod_code as 'Product Code',packing_product.Prod_name as 'Product Name', packing_product.expiry_date as 'Expiry Date',stock.total_qty as 'Available Stock'  from stock,packing_product where stock.prod_code=packing_product.prod_code and stock.total_qty<10", con);
            da = new MySqlDataAdapter(cmd);
            //        dt = new DataTable();
            da.Fill(ds);
            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();
            cmd = new MySqlCommand("select raw_material.prod_code as 'Product Code',raw_material.Prod_name as 'Product Name', raw_material.prod_type as 'Product_type', stock.total_qty as 'Available Stock'  from stock,raw_material where stock.prod_code=raw_material.prod_code and stock.total_qty<10", con);
            da1 = new MySqlDataAdapter(cmd);
            //        dt = new DataTable();
            da1.Fill(ds1);
            dataGridView2.AutoGenerateColumns = true;

            dataGridView2.DataSource = ds1.Tables[0];
            dataGridView2.Refresh();            
         
        }

        private void packingProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataGridView1.Visible = true;
            dataGridView2.Visible = false;

        }

        private void rawMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataGridView2.Visible = true;
            dataGridView1.Visible = false;

         
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cnt < 250)
            {
                cnt++;
            }
            else
            {
                timer1.Enabled = false;
                Hide();
                Form2 ff = new Form2();
                ff.Show();
            }
       }
    }
}
