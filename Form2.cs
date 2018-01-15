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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main f1 = new Main();
            f1.Show();

        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayStock ds = new DisplayStock();
            ds.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form27 f27 = new Form27();
            f27.MdiParent = this;
            f27.Show();



        }

        private void productInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void packingProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void rawMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void addCookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.Show();
        }

        private void addWaiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Show();

        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void deleteCookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form18 f18 = new Form18();
            f18.Show();
        }

        private void deleteWaiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form19 f19 = new Form19();
            f19.Show();
        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            f15.Show();
        }

        private void deletSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form20 f20 = new Form20();
            f20.Show();

        }

        private void addMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu m1 = new Menu();
            m1.Show();
        }

        private void deleteMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deletemenu d1 = new deletemenu();
            d1.Show();
        }

        private void todaysMenuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            todaysmenu tm = new todaysmenu();
            tm.Show();
        }

        private void packingProductToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void rawMaterialToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void salesBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void todaysMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            todaysmenu tm = new todaysmenu();
            tm.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayStock ds = new DisplayStock();
            ds.Show();
        }

        private void tRANSACTIONToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updatedRawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form22 f22 = new Form22();
            f22.Show();
        }

        private void displayCreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void saleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form21 f21 = new Form21();
            f21.Show();
        }

        private void supplierCreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form28 f28 = new Form28();
            f28.Show();
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            attendance a1 = new attendance();
            a1.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form24 f24 = new Form24();
            f24.Show();
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form25 f25 = new Form25();
            f25.Show();
        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form31 f31 = new Form31();
            f31.Show();
  
        }

        private void minimumStockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void packingProductToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form32 f32 = new Form32();
            f32.Show();
        }

        private void rawMaterialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form33 f33 = new Form33();
            f33.Show();
        }

        private void productReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
     }
  }

