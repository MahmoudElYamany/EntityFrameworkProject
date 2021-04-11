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
    public partial class Recipt_of_items_Customer : Form
    {
        DataTable dt = new DataTable();
        public Recipt_of_items_Customer()
        {
            InitializeComponent();
            Random rnd = new Random();
            textBox1.Text = rnd.Next().ToString();
            showList();
            dt.Columns.Add("Product Name");
            dt.Columns.Add("quantity");
            dt.Columns.Add("Selling Price");
            dt.Columns.Add("Total Price");
            dt.Columns.Add("Total with Tax");
        }

        private void showList()
        {
            comboBox1.Items.Clear();
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            var stroge = from s in company_Project.Storages select s;
            foreach (var items in stroge) { comboBox1.Items.Add(items.name); }
            var sup = from e in company_Project.Customers_Suppliers where e.type == "Cus" select e;
            foreach (var i in sup) { listBox1.Items.Add(i.name); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear(); comboBox1.Enabled = false;
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
                comboBox4.Items.Add(item.name);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            var item = (from i in company_Project.items where i.name == comboBox4.Text select i).First();
            textBox2.Text = item.ID_item.ToString();
        }

        private void Close_Recipt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_Recipt_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            comboBox1.Text = comboBox4.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox6.Text = string.Empty;
            comboBox1.Enabled = true;
            dataGridView1.Rows.Clear();
            dt.Rows.Clear();
            listBox1.Items.Clear();
            showList();
            showTotalRecipt = 0;
        }
        private void newForm()
        {
            Random rnd = new Random();
            textBox1.Text = rnd.Next().ToString();
            dateTimePicker1.Value = DateTime.Today;
            comboBox1.Text = comboBox4.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox6.Text = string.Empty;
            comboBox1.Enabled = true;
            dataGridView1.Rows.Clear();
            dt.Rows.Clear();
            listBox1.Items.Clear();
            showList();
            showTotalRecipt = 0;
        }
        private void New_Recipt_Click(object sender, EventArgs e)
        {
            newForm();
        }

        float showTotalRecipt = 0;
        private void Add_item_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToShortDateString();
            int total= int.Parse(textBox3.Text) * int.Parse(textBox4.Text);
            float totalTax = (float)total + ((float)total * float.Parse(textBox5.Text));
            
            dataGridView1.Rows.Clear();
            DataRow row = dt.NewRow();
            row[0] = comboBox4.Text;
            row[1] = textBox3.Text;
            row[2] = textBox4.Text;
            row[3] = total;
            row[4] = totalTax;
            dt.Rows.Add(row);
            foreach (DataRow r in dt.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = r[0].ToString();
                dataGridView1.Rows[num].Cells[1].Value = r[1].ToString();
                dataGridView1.Rows[num].Cells[2].Value = r[2].ToString();
                dataGridView1.Rows[num].Cells[3].Value = r[3].ToString();
                dataGridView1.Rows[num].Cells[4].Value = r[4].ToString();
                showTotalRecipt += float.Parse(r[4].ToString());
            }
            textBox6.Text = showTotalRecipt.ToString();
        }

        private void Save_Recipt_Click(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();

            for (int a = 0; a < dt.Rows.Count; a++)
            {
                Client cl = new Client();
                cl.Recipt_ID = int.Parse(textBox1.Text);
                cl.date = dateTimePicker1.Value.ToShortDateString();

                string st_name = comboBox1.Text;
                var st = (from i in company_Project.Storages where i.name == st_name select i).First();
                cl.storage_id = st.ID_storage;

                string it_name = dt.Rows[a][0].ToString();
                var it = (from i in company_Project.items where i.name == it_name select i).First();
                cl.item_id = it.ID_item;

                cl.amount = int.Parse(dt.Rows[a][1].ToString());

                if (listBox1.SelectedItem == null) { MessageBox.Show("select supplier"); break; }
                else
                {
                    string newper = listBox1.SelectedItem.ToString();
                    var sup = (from q in company_Project.Customers_Suppliers
                               where q.name == newper && q.type == "Cus"
                               select q).First();
                    cl.custumer_id = sup.ID;
                }

                cl.selling_Price = float.Parse(dt.Rows[a][2].ToString());
                cl.Tax = float.Parse(textBox5.Text);

                
                var check = (from i in company_Project.Storage_item
                             where i.Storage_ID == st.ID_storage && i.Item_ID == it.ID_item
                              select i).First();

                if (check.amount > int.Parse(dt.Rows[a][1].ToString()))
                {
                    check.amount -= int.Parse(dt.Rows[a][1].ToString());

                    company_Project.Clients.Add(cl);
                    company_Project.SaveChanges();
                }
                else 
                {
                    MessageBox.Show($"{dt.Rows[a][0]} can't sell it because the amount in store is less than you selling \namount in store: {check.amount} ");
                }
                
            }
            try
            {
                int trans = int.Parse(textBox1.Text);
                var check_trans = (from i in company_Project.Clients
                                   where i.Recipt_ID == trans
                                   select i).First();
                MessageBox.Show($"items Sold with transaction: {textBox1.Text} .");
                newForm();
            }
            catch { }
        }
    }
}
