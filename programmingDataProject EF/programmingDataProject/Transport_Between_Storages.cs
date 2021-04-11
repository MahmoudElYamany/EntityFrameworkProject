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
    public partial class Transport_Between_Storages : Form
    {
        public Transport_Between_Storages()
        {
            InitializeComponent();
            Random rnd = new Random();
            textBox1.Text = rnd.Next().ToString();
            showList();
            dt.Columns.Add("from Storage");
            dt.Columns.Add("to Storage");
            dt.Columns.Add("producr name");
            dt.Columns.Add("quantity");
            dt.Columns.Add("manf date");
            dt.Columns.Add("exp date");

        }
        
        private void newForm()
        {
            Random rnd = new Random();
            textBox1.Text = rnd.Next().ToString();
            dateTimePicker2.Value = dateTimePicker3.Value = DateTime.Today;
            comboBox2.Text = textBox2.Text = textBox3.Text = textBox4.Text = String.Empty;
            comboBox4.Enabled = comboBox1.Enabled = true;
            dataGridView1.Rows.Clear();
            dt.Rows.Clear();
            listBox1.Items.Clear();
            showList();
        }

        private void showList()
        {
            comboBox1.Items.Clear(); comboBox4.Items.Clear(); 
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            var stroge = from s in company_Project.Storages select s;
            foreach (var items in stroge) { comboBox1.Items.Add(items.name); comboBox4.Items.Add(items.name); }
            var sup = from e in company_Project.Customers_Suppliers where e.type == "Sup" select e;
            foreach (var i in sup) { listBox1.Items.Add(i.name); }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();comboBox1.Enabled = false;
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            var st = (from i in company_Project.Storages where i.name == comboBox1.Text select i).First();
            var itemID = from i in company_Project.Storage_item
                       where i.Storage_ID == st.ID_storage
                       select i;
            
            foreach (var items in itemID) 
            {
                var item = (from i in company_Project.items
                           where i.ID_item == items.Item_ID
                           select i).First();
                comboBox2.Items.Add(item.name); 
            }
        }

        private void New_Recipt_Click(object sender, EventArgs e)
        {
            newForm();
            
        }

        private void Delete_Recipt_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            try
            {
                var item = (from i in company_Project.items where i.name == comboBox2.Text select i).First();
                var st = (from i in company_Project.Storages where i.name == comboBox1.Text select i).First();

                var amount = (from q in company_Project.Storage_item
                              where q.Item_ID == item.ID_item && q.Storage_ID == st.ID_storage
                              select q).First();
                textBox4.Text = amount.amount.ToString();
            }
            catch { MessageBox.Show("no item selected"); }
        }

        private void Save_Recipt_Click(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            

            /*List<String> quantity = new List<String>();
            List<String> productname = new List<String>();
            List<String> Manfdate = new List<String>();
            List<String> expDate = new List<String>();
            */
            for (int a = 0; a < dt.Rows.Count; a++)
            {
                Transport_items tran = new Transport_items();
                tran.Transaction_ID = int.Parse(textBox1.Text);
                tran.From_Storage = comboBox1.Text;
                tran.To_Storage = comboBox4.Text;
                tran.Product_Name = dt.Rows[a][2].ToString();
                if (listBox1.SelectedItem == null) { MessageBox.Show("select supplier"); break; }
                else { tran.supplier_Name = listBox1.SelectedItem.ToString(); }
                tran.amount = dt.Rows[a][3].ToString();
                tran.TransactionDate= dateTimePicker1.Value.ToShortDateString();
                company_Project.Transport_items.Add(tran);
                company_Project.SaveChanges();

                string qq = dt.Rows[a][2].ToString();
                var it = (from i in company_Project.items where i.name == qq select i).First();
                var st_from = (from i in company_Project.Storages where i.name == comboBox1.Text select i).First();
                var st_to = (from i in company_Project.Storages where i.name == comboBox4.Text select i).First();
                var check = (from q in company_Project.Storage_item
                             where q.Item_ID == it.ID_item && q.Storage_ID == st_from.ID_storage
                             select q).First();
                check.amount -= int.Parse(dt.Rows[a][3].ToString());

                var check2 = (from q in company_Project.Storage_item
                             where q.Item_ID == it.ID_item && q.Storage_ID == st_to.ID_storage
                             select q).First();
                check2.amount += int.Parse(dt.Rows[a][3].ToString());
                
                company_Project.SaveChanges();                

                /*quantity.Add(dt.Rows[a][3].ToString());
                productname.Add(dt.Rows[a][2].ToString());
                Manfdate.Add(dt.Rows[a][4].ToString());
                expDate.Add(dt.Rows[a][5].ToString());*/
            }

            /*string quantity_output = string.Join(", ", quantity);
            string productname_output = string.Join(", ", productname);
            string Manfdate_output = string.Join(", ", Manfdate);
            string expDate_output = string.Join(", ", expDate);*/

            MessageBox.Show("items added");



        }

        private void Close_Recipt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            var item = (from i in company_Project.items where i.name==comboBox2.Text select i).First();
            textBox2.Text = item.ID_item.ToString();
            dateTimePicker2.Value = DateTime.Parse(item.ManifuctureDate);
            dateTimePicker3.Value = DateTime.Parse(item.expireDate);

            var st = (from i in company_Project.Storages where i.name == comboBox1.Text select i).First(); 

            var amount = (from q in company_Project.Storage_item
                         where q.Item_ID == item.ID_item && q.Storage_ID == st.ID_storage
                         select q).First();
            textBox4.Text = amount.amount.ToString();
            

        }

        DataTable dt = new DataTable();

        private void Add_item_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int newamouunt = int.Parse(textBox4.Text) - int.Parse(textBox3.Text);
            if (newamouunt >= 0)
            {
                textBox4.Text = newamouunt.ToString();
                string manf = dateTimePicker2.Value.ToShortDateString();
                string exp = dateTimePicker3.Value.ToShortDateString();

                DataRow row = dt.NewRow();
                row[0] = comboBox1.Text;
                row[1] = comboBox4.Text;
                row[2] = comboBox2.Text;
                row[3] = textBox3.Text;
                row[4] = manf;
                row[5] = exp;
                dt.Rows.Add(row);
                foreach (DataRow r in dt.Rows)
                {
                    int num = dataGridView1.Rows.Add();
                    dataGridView1.Rows[num].Cells[0].Value = r[0].ToString();
                    dataGridView1.Rows[num].Cells[1].Value = r[1].ToString();
                    dataGridView1.Rows[num].Cells[2].Value = r[2].ToString();
                    dataGridView1.Rows[num].Cells[3].Value = r[3].ToString();
                    dataGridView1.Rows[num].Cells[4].Value = r[4].ToString();
                    dataGridView1.Rows[num].Cells[5].Value = r[5].ToString();
                }
            }
            else { MessageBox.Show("not enough amount in this storage to tranfer"); }
            

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Enabled = false;
        }
    }
}
