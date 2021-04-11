using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace programmingDataProject
{
    public partial class Recipt_of_items : Form
    {
        public Recipt_of_items()
        {
            InitializeComponent();
            Random rnd = new Random();
            textBox1.Text = rnd.Next().ToString();
            showList();
            dt.Columns.Add("Storage Name");
            dt.Columns.Add("Product Name");
            dt.Columns.Add("quantity");
            dt.Columns.Add("manf date");
            dt.Columns.Add("exp date");
        }

        private void showList()
        {
            comboBox1.Items.Clear(); 
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            var stroge = from s in company_Project.Storages select s;
            foreach (var items in stroge) { comboBox1.Items.Add(items.name); }
            var sup = from e in company_Project.Customers_Suppliers where e.type == "Sup" select e;
            foreach (var i in sup) { listBox1.Items.Add(i.name); }
            var it = from i in company_Project.items select i;
            foreach (var items in it) { comboBox2.Items.Add(items.name); }

        }

        private void newForm()
        {
            Random rnd = new Random();
            textBox1.Text = rnd.Next().ToString();
            dateTimePicker1.Value = dateTimePicker2.Value = dateTimePicker3.Value = dateTimePicker4.Value = DateTime.Today;
            comboBox1.Text = comboBox2.Text = textBox2.Text = textBox3.Text = textBox4.Text = String.Empty;
            comboBox1.Enabled = true;
            dataGridView1.Rows.Clear();
            dt.Rows.Clear();
            listBox1.Items.Clear();
            showList();
        }

        DataTable dt = new DataTable();
        private void Add_item_Click(object sender, EventArgs e)
        {
            string manf = dateTimePicker2.Value.ToShortDateString();
            string exp = dateTimePicker3.Value.ToShortDateString();
            dataGridView1.Rows.Clear();
            DataRow row = dt.NewRow();
            row[0] = comboBox1.Text;
            row[1] = comboBox2.Text;
            row[2] = textBox3.Text;
            row[3] = manf;
            row[4] = exp;
            dt.Rows.Add(row);
                 foreach (DataRow r in dt.Rows)
                 {
                     int num = dataGridView1.Rows.Add();
                     dataGridView1.Rows[num].Cells[0].Value = r[0].ToString();
                     dataGridView1.Rows[num].Cells[1].Value = r[1].ToString();
                     dataGridView1.Rows[num].Cells[2].Value = r[2].ToString();
                     dataGridView1.Rows[num].Cells[3].Value = r[3].ToString();
                     dataGridView1.Rows[num].Cells[4].Value = r[4].ToString();
                 }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            var item = (from i in company_Project.items where i.name == comboBox2.Text select i).First();
            textBox2.Text = item.ID_item.ToString();
            dateTimePicker2.Value = DateTime.Parse(item.ManifuctureDate);
            dateTimePicker3.Value = DateTime.Parse(item.expireDate);

        }

        private void New_Recipt_Click(object sender, EventArgs e)
        {
            newForm();
        }

        private void Close_Recipt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delete_Recipt_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker2.Value = dateTimePicker3.Value = dateTimePicker4.Value = DateTime.Today;
            comboBox1.Text = comboBox2.Text = textBox2.Text = textBox3.Text = textBox4.Text = String.Empty;
            comboBox1.Enabled = true;
            dataGridView1.Rows.Clear();
            dt.Rows.Clear();
            listBox1.Items.Clear();
            showList();
        }

        private void Save_Recipt_Click(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();

            for (int a = 0; a < dt.Rows.Count; a++)
            {
                Permission per = new Permission();
                per.permission_ID = int.Parse(textBox1.Text);
                per.typePermission = "rec";
                per.Date_permission = dateTimePicker1.Value.ToShortDateString();
                
                string st_name = dt.Rows[a][0].ToString();
                var st = (from i in company_Project.Storages where i.name == st_name select i).First();
                per.stroage_id = st.ID_storage;

                string it_name = dt.Rows[a][1].ToString();
                var it = (from i in company_Project.items where i.name == it_name select i).First();
                per.item_id = it.ID_item;

                per.amount_item = int.Parse(dt.Rows[a][2].ToString()) ;

                if (listBox1.SelectedItem == null) { MessageBox.Show("select supplier"); break; }
                else 
                {
                    string newper = listBox1.SelectedItem.ToString();
                    var sup = (from q in company_Project.Customers_Suppliers 
                               where q.name == newper  && q.type == "Sup" select q).First();
                    per.name_id = sup.ID; 
                }

                per.expireDate = dateTimePicker4.Value.ToShortDateString();
                per.Comment = textBox4.Text;

                company_Project.Permissions.Add(per);
                company_Project.SaveChanges();


                try
                {
                    var check = (from i in company_Project.Storage_item
                                 where i.Storage_ID == st.ID_storage && i.Item_ID == it.ID_item
                                 select i).First();
                    check.amount += int.Parse(dt.Rows[a][2].ToString());
                }
                catch
                {
                    Storage_item st_it = new Storage_item();
                    st_it.Storage_ID = st.ID_storage;
                    st_it.Item_ID = it.ID_item;
                    st_it.amount = int.Parse(dt.Rows[a][2].ToString());
                    company_Project.Storage_item.Add(st_it);
                }
                                
                company_Project.SaveChanges();
            }

            MessageBox.Show("items added");
        }
    }
}
