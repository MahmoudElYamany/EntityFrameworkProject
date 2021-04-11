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
    public partial class New_Edit_items : Form
    {
        public New_Edit_items()
        {
            InitializeComponent();
            comboBox_showList();
            New_btn.Enabled = false; Update_btn.Enabled = false; Delete_btn.Enabled = false;

        }

        private void comboBox_showList()
        {
            comboBox1.Items.Clear();
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            var stroge = from s in company_Project.Storages select s;
            foreach (var items in stroge) { comboBox1.Items.Add(items.name); }
            var item = from i in company_Project.items select i;
            foreach (var items in item) { comboBox2.Items.Add(items.name); }
        }

        private void New_Click(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            try
            {
                string manf = dateTimePicker1.Value.ToShortDateString();
                string exp = dateTimePicker2.Value.ToShortDateString();
                var itNAme = (from i in company_Project.items 
                              where i.name == comboBox2.Text && i.size == textBox3.Text &&
                              i.ManifuctureDate == manf && i.expireDate == exp
                              select i).First();
                
                Storage_item si = new Storage_item();
                si.amount = int.Parse(textBox4.Text);
                si.Item_ID = int.Parse(textBox1.Text);

                var st = (from i in company_Project.Storages
                          where i.name == comboBox1.Text
                          select i).First();
                si.Storage_ID = st.ID_storage;
                company_Project.Storage_item.Add(si);
                company_Project.SaveChanges();
                MessageBox.Show($"New {comboBox2.Text} added in {comboBox1.Text}.");

            }
            catch
            {
                item it = new item();
                Random rnd = new Random();
                textBox1.Text = rnd.Next().ToString();
                it.ID_item = int.Parse(textBox1.Text);
                try
                {
                    var itNAme = (from i in company_Project.items where i.name == comboBox2.Text select i).First();
                    MessageBox.Show("this name is exist.");
                }
                catch
                {
                    it.name = comboBox2.Text;
                    it.size = textBox3.Text;
                    it.ManifuctureDate = dateTimePicker1.Value.ToShortDateString();
                    it.expireDate = dateTimePicker2.Value.ToShortDateString();

                    Storage_item si = new Storage_item();
                    if (textBox4.Text == String.Empty) { MessageBox.Show("item have to have ammount"); }
                    else { si.amount = int.Parse(textBox4.Text); }
                    
                    si.Item_ID = int.Parse(textBox1.Text);

                    var st = (from i in company_Project.Storages
                              where i.name == comboBox1.Text
                              select i).First();
                    si.Storage_ID = st.ID_storage;
                    company_Project.Storage_item.Add(si);
                    company_Project.items.Add(it);
                    company_Project.SaveChanges();
                    MessageBox.Show($"New {comboBox2.Text} added in {comboBox1.Text}.");
                }
                
            } 
        }
                
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            var check = (from q in company_Project.items where q.name == comboBox2.Text select q).First();
            textBox1.Text = check.ID_item.ToString();        textBox3.Text = check.size;
            dateTimePicker1.Value = DateTime.Parse(check.ManifuctureDate);
            dateTimePicker2.Value = DateTime.Parse(check.expireDate);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            try
            {
                int itmID = int.Parse(textBox1.Text);
                var st = (from i in company_Project.Storages
                      where i.name == comboBox1.Text
                      select i).First();
            
                var check = (from q in company_Project.Storage_item
                             where q.Item_ID == itmID && q.Storage_ID == st.ID_storage
                             select q).First();
                string manf = dateTimePicker1.Value.ToShortDateString();
                string exp = dateTimePicker2.Value.ToShortDateString();
                var itNAme = (from i in company_Project.items
                              where i.name == comboBox2.Text && i.size == textBox3.Text &&
                              i.ManifuctureDate == manf && i.expireDate == exp
                              select i).First();

                textBox4.Text = check.amount.ToString();
                New_btn.Enabled = false; Update_btn.Enabled = true; Delete_btn.Enabled = true;
            }
            catch
            {
                textBox4.Text = "";
                New_btn.Enabled = true; Update_btn.Enabled = false; Delete_btn.Enabled = false;
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            int itmID = int.Parse(textBox1.Text);
            var it = (from i in company_Project.items where i.ID_item == itmID select i).First();
            it.name = comboBox2.Text;
            it.size = textBox3.Text;
            it.expireDate = dateTimePicker2.Value.ToShortDateString();
            it.ManifuctureDate = dateTimePicker1.Value.ToShortDateString();

            var st = (from i in company_Project.Storages where i.name == comboBox1.Text select i).First();
            var check = (from q in company_Project.Storage_item
                         where q.Item_ID == itmID && q.Storage_ID == st.ID_storage
                         select q).First();
            check.amount = int.Parse(textBox4.Text);
            company_Project.SaveChanges();
            MessageBox.Show($"{it.name} Updated");
            
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            int itmID = int.Parse(textBox1.Text);
            var st = (from i in company_Project.Storages where i.name == comboBox1.Text select i).First();
            var check = (from q in company_Project.Storage_item
                         where q.Item_ID == itmID && q.Storage_ID == st.ID_storage
                         select q).First();
            company_Project.Storage_item.Remove(check);
            var it = (from i in company_Project.items where i.ID_item == itmID select i).First();
            company_Project.items.Remove(it);
            company_Project.SaveChanges();
            MessageBox.Show("item deleted");
        }
    }
}
