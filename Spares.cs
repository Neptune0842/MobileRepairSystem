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
    public partial class Spares : Form
    {
        Functions Con;
        public Spares()
        {
            InitializeComponent();
            Con = new Functions();
            showSpares();
        }
        private void showSpares()
        {
            string Query = "Select * from SpareTbl";
            PartsList.DataSource = Con.GetData(Query);
        }
        private void clear()
        {
            PartNameTb.Text = "";
            PartCostTb.Text = "";
            key = 0;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "" || PartCostTb.Text == "")
            {
                MessageBox.Show("Missing data!!");
            }
            else
            {
                try
                {
                    string PName = PartNameTb.Text;
                    int PCost = Convert.ToInt32(PartCostTb.Text) ;
                    string Query = "insert into  SpareTbl values ('{0}','{1}')";
                    Query = string.Format(Query, PName, PCost);
                    Con.SetData(Query);
                    MessageBox.Show("Spare Added!");
                    showSpares();
                    clear();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void PartsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PartNameTb.Text = PartsList.SelectedRows[0].Cells[1].Value.ToString();
            PartCostTb.Text = PartsList.SelectedRows[0].Cells[2].Value.ToString();

            if (PartNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PartsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "" || PartCostTb.Text == "")
            {
                MessageBox.Show("Missing data!!");
            }
            else
            {
                try
                {
                    string PName = PartNameTb.Text;
                    int PCost = Convert.ToInt32(PartCostTb.Text);
                    string Query = "update  SpareTbl set Spname = '{0}', Spcost = {1} where Spcode = {2}";
                    Query = string.Format(Query, PName, PCost, key);
                    Con.SetData(Query);
                    MessageBox.Show("Spare Updated!");
                    showSpares();
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
                MessageBox.Show("Missing data!!");
            }
            else
            {
                try
                {
                    string PName = PartNameTb.Text;
                    int PCost = Convert.ToInt32(PartCostTb.Text);
                    string Query = "delete from SpareTbl where spcode = {0}";
                    Query = string.Format(Query,key);
                    Con.SetData(Query);
                    MessageBox.Show("Spare Deleted!");
                    showSpares();
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
