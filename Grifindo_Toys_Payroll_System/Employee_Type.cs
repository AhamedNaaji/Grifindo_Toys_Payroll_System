using Grifindo_Toys_Payroll_System.Commonclasses;
using Grifindo_Toys_Payroll_System.Function_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Toys_Payroll_System
{
    public partial class Employee_Type : Form
    {
        Employeetypeclass emptypeclass = new Employeetypeclass();
        FillOperations fill = new FillOperations();
        public Employee_Type()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            emptypeclass.InsertData();
            FirstRun();
        }

        private void Employee_Type_Load(object sender, EventArgs e)
        {
            FirstRun();
        }
        void FirstRun()
        {
            txtName.Text = "";
            txtNoOfALeave.Text = "";
            txthourlyrate.Text = "";
            fill.FillDataGridView("SELECT * FROM EmployeeType", dgvemptype);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            emptypeclass.typeName = txtName.Text.Trim();

        }

        private void txtNoOfALeave_TextChanged(object sender, EventArgs e)
        {
            int noAnnLeaves;
            if (int.TryParse(txtNoOfALeave.Text, out noAnnLeaves))
            {
                emptypeclass.NoAnnLeaves = noAnnLeaves;
            }
            else
            {
                noAnnLeaves = 0;
                emptypeclass.NoAnnLeaves = noAnnLeaves;
            }





        }


        private void dgvemptype_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            emptypeclass.EmpTypeID = Convert.ToInt32(dgvemptype.Rows[e.RowIndex].Cells[0].Value);
            emptypeclass.FillEmployeTypeToField();
            txtName.Text = emptypeclass.typeName;
            txtNoOfALeave.Text = emptypeclass.NoAnnLeaves.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            emptypeclass.UpdateData();
            FirstRun();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            emptypeclass.DeleteData();
            FirstRun();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtNoOfALeave.Text = "";
            txthourlyrate.Text = "";
        }

        private void dgvemptype_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dgvemptype_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            emptypeclass.EmpTypeID = Convert.ToInt32(dgvemptype.Rows[e.RowIndex].Cells[0].Value);
            emptypeclass.FillEmployeTypeToField();
            fillContents();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            emptypeclass.UpdateData();
            FirstRun();
        }

        private void dgvemptype_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            emptypeclass.EmpTypeID = Convert.ToInt32(dgvemptype.Rows[e.RowIndex].Cells[0].Value);
            
        }

        void fillContents()
        {
            txtName.Text = emptypeclass.typeName;
            txtNoOfALeave.Text = emptypeclass.NoAnnLeaves.ToString();
            txthourlyrate.Text = emptypeclass.overTimeHourlyRate.ToString();
        }

        private void txthourlyrate_TextChanged(object sender, EventArgs e)
        {
            if(txthourlyrate.Text != "")
            {
            emptypeclass.overTimeHourlyRate = Convert.ToDouble(txthourlyrate.Text);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
