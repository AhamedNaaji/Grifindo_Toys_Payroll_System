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
    public partial class Salary : Form
    {
        FillOperations fill = new FillOperations();
        SalaryClass salary = new SalaryClass();
        public Salary()
        {
            InitializeComponent();
        }

        private void Salary_Load(object sender, EventArgs e)
        {
            firstRun();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            salary.EmpID = (int)cmbEmployee.SelectedValue;
            salary.fillData();
            label8.Text = salary.month;
            lblTotalLeave.Text = salary.totalLeaves.ToString();
            lblOvertimeHours.Text = salary.overTimeHours.ToString();
            lblotRate.Text = salary.overTimeRate.ToString();
            lblNoPayValue.Text = salary.noPayValue.ToString();
            lblBasePayValue.Text = salary.totalBasePay.ToString();
            lblGrossPay.Text = salary.totalGrossPay.ToString();
        }

        void firstRun()
        {
            fill.FillCombobox("SELECT * FROM Employee", cmbEmployee, "Name", "EmpID");
            fill.FillDataGridView("SELECT * FROM Salary", dgvsalary);
        }

        void FillContents()
        {
            salary.EmpID = (int)cmbEmployee.SelectedValue;
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            salary.insertSalary();
            firstRun();
        }

        private void dgvsalary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            salary.EmpID = (int)dgvsalary.Rows[e.RowIndex].Cells[0].Value;
            salary.endDate = dgvsalary.Rows[e.RowIndex].Cells[1].Value.ToString();
            salary.selectData();

        }

        private void lblTotalLeave_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
