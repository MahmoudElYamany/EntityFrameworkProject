using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programmingDataProject
{
    public partial class Storages_Report : Form
    {
        public Storages_Report()
        {
            InitializeComponent();
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            var stroge = from s in company_Project.Storages select s;
            comboBox1.Items.Add("==All==");
            foreach (var items in stroge) { comboBox1.Items.Add(items.name); }
        }

        private void button1_Click(object sender, EventArgs e)//search
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();

            if (comboBox1.Text == "==All==")
            {
                var stroge = from s in company_Project.Storages select s;
                dataGridView1.DataSource = stroge.ToList();
            }
            else
            {
                var stroge = from s in company_Project.Storages where s.name == comboBox1.Text select s;
                dataGridView1.DataSource = stroge.ToList();
            }

            if (comboBox1.Text == "==All==")
            {
                var stroge1 = from s in company_Project.Storages select s;
                foreach (var i in stroge1)
                {
                    var it_in_st = from s in company_Project.Storage_item where s.Storage_ID == i.ID_storage select s;
                    foreach (var ie in it_in_st)
                    {
                        var it = from s in company_Project.items
                                 where s.ID_item == s.ID_item
                                 select s;
                        dataGridView2.DataSource = it.ToList();
                    }
                }
                
                
            }
            else
            {
                var stroge1 = (from s in company_Project.Storages where s.name == comboBox1.Text select s).First();
                var it_in_st = from s in company_Project.Storage_item where s.Storage_ID == stroge1.ID_storage select s;
                foreach (var i in it_in_st )
                {
                    var it = from s in company_Project.items
                             where s.ID_item == s.ID_item
                             select s;
                    dataGridView2.DataSource = it.ToList();
                }
                
            }

            


        }
    }
}
