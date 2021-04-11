using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programmingDataProject
{
    public partial class MainBody : Form
    {
        string body_lang, body_username;
        public MainBody(string lang , string username)
        {
            InitializeComponent();
            if (lang == "Ar") 
            {
                arabicToolStripMenuItem.Checked = false; englishToolStripMenuItem.Checked = true;
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            }
            else 
            { 
                arabicToolStripMenuItem.Checked = true; englishToolStripMenuItem.Checked = false;
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-EG");
                this.Controls.Clear();
                InitializeComponent();
            }
            toolStripStatusLabel2_name.Text = username;
            toolStripStatusLabel3_date.Text = DateTime.Now.ToString("M/d/yyyy hh:mm tt");
            body_lang = lang;
            body_lang = username;
        }

        private void newStorageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Edit_StoargeBody stoargeBody = new New_Edit_StoargeBody(body_lang);
            stoargeBody.MdiParent = this;
            stoargeBody.Show();
        }

        private void reciptOfItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recipt_of_items Recipt_Of_Items_Supplier = new Recipt_of_items();
            Recipt_Of_Items_Supplier.MdiParent = this;
            Recipt_Of_Items_Supplier.Show();
        }

        private void transportBetweenStoragesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transport_Between_Storages transport_Between_Storages = new Transport_Between_Storages();
            transport_Between_Storages.MdiParent = this;
            transport_Between_Storages.Show();
        }

        private void newEditCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Edit_PersonBody new_Edit_PersonBody = new New_Edit_PersonBody();
            new_Edit_PersonBody.MdiParent = this;
            new_Edit_PersonBody.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cashItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recipt_of_items_Customer recipt_Of_Items_Customer = new Recipt_of_items_Customer();
            recipt_Of_Items_Customer.MdiParent = this;
            recipt_Of_Items_Customer.Show();
        }

        private void MainBody_Load(object sender, EventArgs e)
        {
            
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Edit_items new_Edit_Items = new New_Edit_items();
            new_Edit_Items.MdiParent = this;
            new_Edit_Items.Show();
        }

        private void stroagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Storages_Report storages_Report = new Storages_Report();
            storages_Report.MdiParent = this;
            storages_Report.Show();
        }

        private void componetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trasnactions_reports trasnactions_Reports = new Trasnactions_reports();
            trasnactions_Reports.MdiParent = this;
            trasnactions_Reports.Show();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            arabicToolStripMenuItem.Checked = false; englishToolStripMenuItem.Checked = true;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            this.Controls.Clear();
            InitializeComponent();
            toolStripStatusLabel2_name.Text = body_username;
            toolStripStatusLabel3_date.Text = DateTime.Now.ToString("M/d/yyyy hh:mm tt");
            body_lang = "En";
        }

        private void arabicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            arabicToolStripMenuItem.Checked = true; englishToolStripMenuItem.Checked = false;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-EG");
            this.Controls.Clear();
            InitializeComponent();
            toolStripStatusLabel2_name.Text = body_username;
            toolStripStatusLabel3_date.Text = DateTime.Now.ToString("M/d/yyyy hh:mm tt");
            body_lang = "Ar";
        }
    }
}
