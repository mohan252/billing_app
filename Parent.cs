using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BillingApplication
{
    public partial class Parent : Form
    {
        DAL dalObj = new DAL();
        public Parent()
        {
            this.IsMdiContainer = true;
            InitializeComponent();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillForm billForm = new BillForm();
            billForm.MdiParent = this;
            billForm.WindowState = FormWindowState.Maximized;
            billForm.Show();
        }

        private void dDEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DDEntry ddEntryForm = new DDEntry();
            ddEntryForm.MdiParent = this;
            ddEntryForm.Show();
        }

        private void pendingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PendingList plForm = new PendingList();
            plForm.MdiParent = this;
            plForm.Show();
        }

        private void entitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEntities aeForm = new AddEntities();
            aeForm.MdiParent = this;
            aeForm.Show();
        }
        private void Parent_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Month == 4)
            {
                if (!dalObj.IsArchiveDone())
                {
                    if (MessageBox.Show("New Accounting Year is not Created till now.\r\nDo you want to create it now?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int currYear = DateTime.Now.Year;
                        string prevAccYear = (currYear - 1) + "-" + currYear;
                        dalObj.CreateNewAccountingYear(prevAccYear);
                    }
                }
            }
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports reForm = new Reports();
            reForm.MdiParent = this;
            reForm.Show();
        }
    }
}