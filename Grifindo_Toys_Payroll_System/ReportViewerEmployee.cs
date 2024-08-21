using Grifindo_Toys_Payroll_System.Commonclasses;
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
    public partial class ReportViewerEmployee : Form
    {
        int EmpID;
        string startDate;
        string endDate;

        FillOperations fill = new FillOperations();
        public ReportViewerEmployee()
        {
            InitializeComponent();
        }

        private void ReportViewerEmployee_Load(object sender, EventArgs e)
        {
            loadAtStart();
        }

        private void allEmployees_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
            cmbEmpID.Visible = false;
        }

        private void anEmployee_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            cmbEmpID.Visible = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            startDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            endDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if((dateTimePicker2.CustomFormat == " " && dateTimePicker1.CustomFormat == " ") && anEmployee.Checked) {
                string query = "SELECT Employee.Name, Employee.EmpID, Salary.Month, Salary.No_Pay_value, Salary.BasePay_value, Salary.GrossPay" +
                $" FROM Salary INNER JOIN Employee ON Salary.EmpID = Employee.EmpID WHERE Salary.EmpID = {EmpID}";
                fill.FillReportView(query, reportViewer1);
            }
            else if (anEmployee.Checked)
            {
                string query = "SELECT Employee.Name, Employee.EmpID, Salary.Month, Salary.No_Pay_value, Salary.BasePay_value, Salary.GrossPay" +
                $" FROM Salary INNER JOIN Employee ON Salary.EmpID = Employee.EmpID WHERE Salary.EmpID = {EmpID} AND Salary.Month >= '{startDate}' AND Salary.Month <= '{endDate}'";
                fill.FillReportView(query, reportViewer1);
            }
            else if(allEmployees.Checked)
            {
                string query = "SELECT Employee.Name, Employee.EmpID, Salary.Month, Salary.No_Pay_value, Salary.BasePay_value, Salary.GrossPay" +
                $" FROM Salary INNER JOIN Employee ON Salary.EmpID = Employee.EmpID WHERE Salary.Month >= '{startDate}' AND Salary.Month <= '{endDate}'";
                fill.FillReportView(query, reportViewer1);
            }
        }

        private void cmbEmpID_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmpID = (int)cmbEmpID.SelectedValue;
        }

        void loadAtStart()
        {
            string query = "SELECT Employee.Name, Employee.EmpID, Salary.Month, Salary.No_Pay_value, Salary.BasePay_value, Salary.GrossPay" +
                " FROM Salary INNER JOIN Employee ON Salary.EmpID = Employee.EmpID";
            fill.FillReportView(query, reportViewer1);
            string btnQry = "SELECT Salary.EmpID, Employee.Name FROM Employee INNER JOIN Salary ON Salary.EmpID = Employee.EmpID";
            fill.FillCombobox(btnQry, cmbEmpID, "Name", "EmpID");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
