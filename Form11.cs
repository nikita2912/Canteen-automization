using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Login
{
    public partial class Form11 : Form
    {
        
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                Form12 f12=new Form12();
                f12.Show();
             }
            else
            {
                Form13 f13=new Form13();
                f13.Show();
            }
            Hide();
         
            }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
         }

        
    }

       



