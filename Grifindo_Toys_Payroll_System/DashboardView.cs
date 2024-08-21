using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Toys_Payroll_System
{
    public partial class DashboardView : Form
    {
        public DashboardView()
        {
            InitializeComponent();
        }            
        private void btnemployee_Click_1(object sender, EventArgs e)
        {
            Employee EmployeeForm = new Employee();
            EmployeeForm.ShowDialog();
        }
        private void btnEmployeeType_Click_1(object sender, EventArgs e)
        {
            Employee_Type Employee_Typeform = new Employee_Type();
            Employee_Typeform.ShowDialog();
        }
        private void btnAttendance_Click_1(object sender, EventArgs e)
        {
            Attendance AttendanceForm = new Attendance();
            AttendanceForm.ShowDialog();
        }
        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            Settings Settingsform = new Settings();
            Settingsform.ShowDialog();
        }
        private void btnleave_Click(object sender, EventArgs e)
        {
            Leave Leaveform = new Leave();
            Leaveform.ShowDialog();
        }
        private void btnsalary_Click(object sender, EventArgs e)
        {
            Salary Salaryform = new Salary();
            Salaryform.ShowDialog();
        }
        private void btnprintReport_Click(object sender, EventArgs e)
        {
            ReportViewerEmployee RVemployee = new ReportViewerEmployee();
            RVemployee.ShowDialog();
        }
    }
}

