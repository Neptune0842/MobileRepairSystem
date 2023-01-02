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
    public partial class Repairs : Form
    {
        Functions Con;
        public Repairs()
        {
            InitializeComponent();
            Con = new Functions();
            showRepairs();
            GetCustomer();
            GetSpare();
        }
        private void GetCost()
        {
            string Query = "select * from SpareTbl where Spcode = {0}";
            Query = string.Format(Query, SpareCb.SelectedValue.ToString());
            foreach(DataRow dr in Con.GetData(Query).Rows)
            {
                SpareCostTb.Text = dr["Spcost"].ToString();
            }
        }
        private void GetCustomer()
        {
            string Query = "Select * from CustomerTbl";
            CustCb.DisplayMember = Con.GetData(Query).Columns["Custname"].ToString();
            CustCb.ValueMember = Con.GetData(Query).Columns["Custcode"].ToString();
            CustCb.DataSource = Con.GetData(Query);
        }
        private void GetSpare()
        {
            string Query = "Select * from SpareTbl";
            SpareCb.DisplayMember = Con.GetData(Query).Columns["Spname"].ToString();
            SpareCb.ValueMember = Con.GetData(Query).Columns["Spcode"].ToString();
            SpareCb.DataSource = Con.GetData(Query);
        }
        private void showRepairs()
        {
            string Query = "select * from RepairTbl";
            RepairsList.DataSource = Con.GetData(Query);
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustCb.SelectedIndex == -1 || PhoneTb.Text == "" || DNameTb.Text == "" || DModelTb.Text == "" || ProblemTb.Text == "" || SpareCb.SelectedIndex == -1 || SpareCostTb.Text == "" || SomeText.Text == "")
            {
                MessageBox.Show("Missing data!!");
            }
            else
            {
                try
                {
                    String RDate = RepDateTb.Value.Date.ToString();
                    int Customer = Convert.ToInt32(CustCb.SelectedValue.ToString());
                    String CPhone = PhoneTb.Text;
                    String DeviceName = DNameTb.Text;
                    String DeviceModel = DModelTb.Text;
                    String Problem = ProblemTb.Text;
                    int Spare = Convert.ToInt32(SpareCb.SelectedValue.ToString());
                    int Total = Convert.ToInt32(TotalTb.Text);
                    int GrdTotal = Convert.ToInt32(SpareCostTb.Text) + Total;
                    string Query = "insert into  RepairTbl values ('{0}',{1},'{2}','{3}','{4}','{5}',{6},{7})";
                    Query = string.Format(Query, RDate, Customer,CPhone, DeviceName, DeviceModel, Problem, Spare, GrdTotal);
                    Con.SetData(Query);
                    MessageBox.Show("Repair Added!");
                    showRepairs();
                    //clear();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void SpareCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCost();
        }
        int key = 0;
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Repair!!");
            }
            else
            {
                try
                {
                   
                    string Query = "delete from RepairTbl where RepCode = {0}";
                    Query = string.Format(Query,key);
                    Con.SetData(Query);
                    MessageBox.Show("Repair Deleted!");
                    showRepairs();
                    //clear();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void RepairsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(RepairsList.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}