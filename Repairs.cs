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
        }
        private void showRepairs()
        {
            string Query = "select * from RepairTbl";
            RepairsList.DataSource = Con.GetData(Query);
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustCb.SelectedIndex == -1 || PhoneTb.Text == "" || DNameTb.Text == "" || DModelTb.Text == "" || ProblemTb.Text == "" || SpareCb.SelectedIndex == -1 || SpareCostTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Missing data!!");
            }
            else
            {
                try
                {
                    string RDate = RepDateTb.Value.Date.ToString();
                    int Customer = Convert.ToInt32(CustCb.SelectedValue.ToString());
                    string CPhone = PhoneTb.Text;
                    string DeviceName = DNameTb.Text;
                    string DeviceModel = DModelTb.Text;
                    string Problem = ProblemTb.Text;
                    int Spare = Convert.ToInt32(SpareCb.SelectedValue.ToString());
                    int Total = Convert.ToInt32(TotalTb.Text);
                    string Query = "insert into  RepairTbl values ('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7})";
                    Query = string.Format(Query, RDate, Customer,CPhone, DeviceName, DeviceModel, Problem, Spare, Total);
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
    }
}
