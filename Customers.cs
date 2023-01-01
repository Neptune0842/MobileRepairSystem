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
            string Query = "Select * from CustomerTbl";
            CustomersList.DataSource = Con.GetData(Query);
        }

        private void clear()
        {
            CustomerNameTb.Text = "";
            CustomerPhoneTb.Text = "";
            CustomerAddressTb.Text = "";
            key = 0;
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
                    string Query = "insert into  CustomerTbl values ('{0}','{1}','{2}')";
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
        int key = 0;
        private void CustomersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustomerNameTb.Text = CustomersList.SelectedRows[0].Cells[1].Value.ToString();
            CustomerPhoneTb.Text = CustomersList.SelectedRows[0].Cells[2].Value.ToString();
            CustomerAddressTb.Text = CustomersList.SelectedRows[0].Cells[3].Value.ToString();

            if (CustomerNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CustomersList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
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
                    string Query = "Update  CustomerTbl set CustName = '{0}',CustPhone = '{1}',CustAdd = '{2}' where CustCode = {3}";
                    Query = string.Format(Query, CName, CPhone, CAdd,key);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Has Been Updated!");
                    showCustomers();
                    clear();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Customer");
            }
            else
            {
                try
                {
                    string CName = CustomerNameTb.Text;
                    string CPhone = CustomerPhoneTb.Text;
                    string CAdd = CustomerAddressTb.Text;
                    string Query = "delete from  CustomerTbl where CustCode = {0}";
                    Query = string.Format(Query,key);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Deleted!!");
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