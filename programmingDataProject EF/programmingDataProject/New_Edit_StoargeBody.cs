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
    public partial class New_Edit_StoargeBody : Form
    {
        public New_Edit_StoargeBody(string lang)
        {
            InitializeComponent();
            comboBox_showList();
            Update_btn.Enabled = false;
            if (lang == "Ar")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-EG");
                this.Controls.Clear();
                InitializeComponent();
            }
        }

        private void comboBox_showList()
        {
            comboBox1.Items.Clear(); comboBox2.Items.Clear();
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            var stroge = from s in company_Project.Storages select s;
            foreach (var items in stroge) { comboBox1.Items.Add(items.ID_storage); }
            var name = from names in company_Project.Emloyees select names;
            foreach (var items in name) { comboBox2.Items.Add(items.name); }
        }

        private void EmptyForm()
        {
            textBox1.Text =textBox2.Text = textBox4.Text = textBox6.Text = String.Empty;
            comboBox1.Text = comboBox2.Text = String.Empty;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void New_Click(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            Storage storage = new Storage();
            Random rnd = new Random();
            comboBox1.Text = rnd.Next().ToString();
            storage.ID_storage = int.Parse(comboBox1.Text);
            storage.name = textBox2.Text;
            storage.location = textBox4.Text;
            storage.Comment = textBox6.Text;
            storage.Phone = int.Parse(textBox1.Text);
            var CS = (from names in company_Project.Emloyees
                      where names.name == comboBox2.Text
                      select names).First();
            try
            {
                var str_checl = (from s in company_Project.Storages
                                 where s.Manger_ID == CS.ID_Emp
                                 select s).First();
                var str = (from s in company_Project.Storages
                               where s.Manger_ID == CS.ID_Emp
                               select s).First();
                    MessageBox.Show($"Sorry this employee manage {str.name}");
                
            }
            catch 
            {
                storage.Manger_ID = CS.ID_Emp;
                company_Project.Storages.Add(storage);
                company_Project.SaveChanges();
                MessageBox.Show($"New {storage.name} Added");

                EmptyForm();
                comboBox_showList();
            }
            

        }

        private void Search_Click(object sender, EventArgs e)
        {
            Update_btn.Enabled = true;
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            int _ID = int.Parse(comboBox1.SelectedItem.ToString());
            var str = (from s in company_Project.Storages
                          where s.ID_storage == _ID
                          select s).First();
            textBox1.Text = str.Phone.ToString();
            textBox2.Text = str.name;
            textBox4.Text = str.location;
            textBox6.Text = str.Comment;

            var CS = (from names in company_Project.Emloyees
                      where names.ID_Emp == str.Manger_ID
                      select names).First();
            comboBox2.Text = CS.name;
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            int combo_id = int.Parse(comboBox1.Text);
            var str = (from s in company_Project.Storages
                       where s.ID_storage == combo_id
                       select s).First();
            company_Project.Storages.Remove(str);
            company_Project.SaveChanges();
            MessageBox.Show($"{textBox2.Text} Deleted.");
            EmptyForm(); 
            comboBox_showList();
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            int combo_id = int.Parse(comboBox1.Text);
            var str = (from s in company_Project.Storages
                       where s.ID_storage == combo_id
                       select s).First();
            str.name = textBox2.Text;          str.Phone =int.Parse(textBox1.Text) ;
            str.location = textBox4.Text;      str.Comment = textBox6.Text;
            var CS = (from names in company_Project.Emloyees
                      where names.ID_Emp == str.Manger_ID
                      select names).First();
            comboBox2.Text = str.name;
            company_Project.SaveChanges();
            MessageBox.Show($"{str.name} Updated");
            EmptyForm();Update_btn.Enabled = false;
        }
    }
}
