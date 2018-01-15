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
    public partial class deletemenu : Form
    {   
          MySqlConnection con;
          MySqlCommand cmd,cmd1;
          MySqlDataAdapter da;
          MySqlDataReader dr;
          DataSet ds;

        public deletemenu()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("select * from menu where menu_name=?a ", con);
            cmd.Parameters.AddWithValue("?a", comboBox2.Text);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = Convert.ToString(dr[0]);
            }
            dr.Close();

        }

        private void deletemenu_Load(object sender, EventArgs e)
        {
            
           try
            {
                ds = new DataSet();
                con = new MySqlConnection("server=localhost;uid=root;pwd=niku2912;database=canteen");
                con.Open();
                da = new MySqlDataAdapter("select *  from menu", con);
                da.Fill(ds);
                comboBox2.DataSource = ds.Tables[0];
                comboBox2.DisplayMember = "menu_name";
                comboBox2.ValueMember = "menu_code";
             }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
           
            
            
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd1= new MySqlCommand("delete from menu where menu_code=?b",con);
            cmd1.Parameters.AddWithValue("?b", textBox1.Text);
           // cmd1.CommandType = System.Data.CommandType.Text;
            cmd1.ExecuteNonQuery();
            MessageBox.Show(""+comboBox2.Text+" Deleted" );
            textBox1.Clear();
           
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
