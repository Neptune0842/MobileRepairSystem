using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileRepairSystem
{
    public partial class Customers : Form
    {
        Functions Con;
        public Customers()
        {
            InitializeComponent();
            Con = new Functions();
            showCustomers();
        }

        private void showCustomers()
        {
            string Query = "Select * from CustomerTable";
            CustomersList.DataSource = Con.GetData(Query);
        }

        private void clear()
        {
            CustomerNameTb.Text = "";
            CustomerPhoneTb.Text = "";
            CustomerAddressTb.Text = "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

            if (CustomerNameTb.Text == "" || CustomerPhoneTb.Text == "" || CustomerAddressTb.Text == "")
            {
                MessageBox.Show("Missing data!!");
            }
            else
            {
                try
                {
                    string CName = CustomerNameTb.Text;
                    string CPhone = CustomerPhoneTb.Text;
                    string CAdd = CustomerAddressTb.Text;
                    string Query = "insert into  CustomerTable values ('{0}','{1}','{2}')";
                    Query = string.Format(Query, CName, CPhone, CAdd);
                    Con.SetData(Query);
                    MessageBox.Show("New Customer Added!");
                    showCustomers();
                    clear();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}