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
    public partial class New_Edit_PersonBody : Form
    {
        string con_ID =null;
        public New_Edit_PersonBody()
        {
            InitializeComponent();
            
            comboBox1_showList();
        }

        private void comboBox1_showList()
        {
            comboBox1.Items.Clear();
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            var name = from names in company_Project.Customers_Suppliers select names;
            foreach (var items in name) { comboBox1.Items.Add(items.name); }
        }

        private void check_radio()
        {
            Customers_Suppliers CS = new Customers_Suppliers();
            if (radioButton1.Checked) { con_ID = "Sup"; }
            else if (radioButton2.Checked) { con_ID = "Cus"; }
          
        }
        private void EmptyForm()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = String.Empty;
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Today;
        }
        private void New_cust_Click(object sender, EventArgs e)
        {
            Customers_Suppliers CS = new Customers_Suppliers();
            check_radio();
            Random rnd = new Random();
            textBox1.Text = rnd.Next().ToString();
            if (con_ID == null) { MessageBox.Show("please select the Radiobutton"); }
            else 
            {
                CS.ID = con_ID +"-"+ textBox1.Text;
                CS.name = comboBox1.Text;
                CS.type = con_ID;
                CS.BirthDate = dateTimePicker1.Value.ToShortDateString();
                CS.phone = int.Parse(textBox4.Text);
                CS.mobile = int.Parse(textBox5.Text);
                CS.fax = int.Parse(textBox6.Text);
                CS.Mail = textBox7.Text;
                CS.website = textBox2.Text;
                CS.Location = textBox3.Text;
                CS.Comments = textBox8.Text;
                if (CS.name == null) { MessageBox.Show("name is empty"); }
                else 
                {
                    Company_ProjectEntities company_Project = new Company_ProjectEntities();
                    company_Project.Customers_Suppliers.Add(CS);
                    company_Project.SaveChanges();
                    MessageBox.Show($"New {CS.type} Added");
                }
                
            }
            EmptyForm();
            comboBox1_showList();
            
        }

        private void Update_cust_Click(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            var CS = (from names in company_Project.Customers_Suppliers
                        where names.ID == textBox1.Text
                        select names).First();
            CS.name = comboBox1.Text;
            CS.type = con_ID;
            CS.BirthDate = dateTimePicker1.Value.ToShortDateString();
            CS.phone = int.Parse(textBox4.Text);
            CS.mobile = int.Parse(textBox5.Text);
            CS.fax = int.Parse(textBox6.Text);
            CS.Mail = textBox7.Text;
            CS.website = textBox2.Text;
            CS.Location = textBox3.Text;
            CS.Comments = textBox8.Text;
            company_Project.SaveChanges();
            MessageBox.Show($"{CS.name} Updated");
            EmptyForm();
            
        }

        private void Delete_cust_Click(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            var CS = (from names in company_Project.Customers_Suppliers
                      where names.ID == textBox1.Text
                      select names).First();
            company_Project.Customers_Suppliers.Remove(CS);
            company_Project.SaveChanges();
            MessageBox.Show($"{comboBox1.Text} Updated");
            EmptyForm();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = String.Empty;
            var name = (from names in company_Project.Customers_Suppliers
                       where names.name == comboBox1.SelectedItem.ToString()
                       select names).First();
            textBox1.Text = name.ID;                textBox2.Text = name.website;
            textBox3.Text = name.Location;          textBox4.Text = name.phone.ToString();
            textBox5.Text = name.mobile.ToString(); textBox6.Text = name.fax.ToString();
            textBox7.Text = name.Mail;              textBox8.Text = name.Comments;
            dateTimePicker1.Value = DateTime.Parse(name.BirthDate);
            if (name.type == "Sup") { radioButton1.Checked = true;radioButton2.Checked = false; con_ID = "Sup"; }
            else if (name.type == "Cus") { radioButton1.Checked = false; radioButton2.Checked = true; con_ID = "Cus"; }
        }

        private void Close_cust_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
