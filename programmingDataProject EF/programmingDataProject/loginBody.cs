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
    public partial class loginBody : Form
    {
        
        public loginBody()
        {
            InitializeComponent();
            
        }

        private void login_Click(object sender, EventArgs e)
        {
            Company_ProjectEntities company_Project = new Company_ProjectEntities();
            Emloyee emp = (from q in company_Project.Emloyees
                            select q).First();
            if (emp.name == textBox1.Text && emp.Password == int.Parse(textBox2.Text)) 
            {
                string Username = textBox1.Text;
                MainBody mainBody = new MainBody(button1.Text, Username);
                this.Hide();
                mainBody.ShowDialog();
                this.Show();
            }
            else { MessageBox.Show("Wrong Username & PAssword"); }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Ar")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-EG");
            }
            else 
            { Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US"); }
           
            this.Controls.Clear();
            InitializeComponent();
        }
    }
}
