using Grifindo_Toys_Payroll_System.Commonclasses;
using Grifindo_Toys_Payroll_System.Function_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Toys_Payroll_System
{
    public partial class Leave : Form
    {
        FillOperations fill = new FillOperations();
        LeaveClass leave = new LeaveClass();
        public Leave()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

        }

        private void Leave_Load(object sender, EventArgs e)
        {
            firstRun();
        }

        void firstRun()
        {
            fill.FillCombobox("SELECT * FROM Employee", CmbEmpID, "Name", "EmpID");
            fill.FillDataGridView("SELECT * FROM Leave", dgvLeave);

        }

        private int calcDate(DateTime startDate, DateTime endDate)
        {
            
            TimeSpan dif = startDate.Subtract(endDate);
            
            
            if ((int)dif.TotalDays == 0)
            {
                return 1;
            }
            else
            {
                return (int)dif.TotalDays + 1;
            }
        }

        private void dtpLeaveEndDate_ValueChanged(object sender, EventArgs e)
        {
            int totalDays = calcDate(dtpLeaveEndDate.Value, dtpLeaveStartDate.Value);
            leave.totalDays = totalDays;
            lblNoOfDays.Text = totalDays.ToString();
            leave.leaveEndDate = dtpLeaveEndDate.Value.ToString("yyyy/MM/dd");

        }

        private void CmbEmpID_SelectedIndexChanged(object sender, EventArgs e)
        {
            leave.EmpId = (int)CmbEmpID.SelectedValue;
            leave.getAnnualLeave();
            leave.calcRemainingLeave();
            lblRemainingLeaves.Text = leave.remainingDays.ToString();
        }

        private void dtpLeaveStartDate_ValueChanged(object sender, EventArgs e)
        {
            int totalDays = calcDate(dtpLeaveEndDate.Value, dtpLeaveStartDate.Value);
            leave.totalDays = totalDays;
            lblNoOfDays.Text = totalDays.ToString();
            leave.leaveStartDate = dtpLeaveStartDate.Value.ToString("yyyy/MM/dd");
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            leave.updateData();
            firstRun();
        }

        private void dgvLeave_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            leave.LeaveID = (int)dgvLeave.Rows[e.RowIndex].Cells[0].Value;
            leave.fillLeaveToField();
            fillContents();
        }
        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            leave.insertData();
            firstRun();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            leave.deleteData();
            firstRun();
        }

        private void fillContents()
        {
            CmbEmpID.SelectedValue = leave.EmpId;
            dtpLeaveStartDate.Value = DateTime.Parse(leave.leaveStartDate);
            dtpLeaveEndDate.Value = DateTime.Parse(leave.leaveEndDate);
            lblRemainingLeaves.Text = leave.reason;
        }

        private void lblRemainingLeaves_Click(object sender, EventArgs e)
        {

        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            leave.reason = txtReason.Text.Trim();
        }
    }
}
