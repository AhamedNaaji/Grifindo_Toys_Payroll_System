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
    public partial class Attendance : Form
    {
        FillOperations fill = new FillOperations();
        AttendanceClass attendance = new AttendanceClass();
        public Attendance()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbemployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            attendance.EmpId = Convert.ToInt32(cmbemployeeID.SelectedValue);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            attendance.outTime = endTimePicker.Value.TimeOfDay.ToString("hh\\:mm\\:ss");
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            attendance.InTime = startTimePicker.Value.TimeOfDay.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
            attendance.workDate = workDatePicker.Value.ToString("yyyy/MM/dd");
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            fill.FillCombobox("SELECT * FROM Employee", cmbemployeeID, "Name", "EmpID");
            fill.FillDataGridView("SELECT * FROM Attendance", dgvattendance);
        }

        private void dgvemptype_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            attendance.EmpId = Convert.ToInt32(dgvattendance.Rows[e.RowIndex].Cells[0].Value);
            attendance.workDate = dgvattendance.Rows[e.RowIndex].Cells[1].Value.ToString();
            attendance.FillAttendanceToField();
            fillContents();
        }

        void calcHrs()
        {
            TimeSpan hours = endTimePicker.Value.TimeOfDay.Subtract(startTimePicker.Value.TimeOfDay);
            if(hours <= TimeSpan.Zero)
            {
                MessageBox.Show("Enter Valid Time");
            }
            else {
                attendance.hours = Convert.ToInt32(hours.ToString().Substring(0, 2));
                lblworkinghours.Text = hours.ToString().Substring(0, 2); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            calcHrs();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            attendance.insertAttendance();
            loadData();
        }

        void fillContents()
        {
            cmbemployeeID.SelectedValue = attendance.EmpId;
            DateTime parsedInTime = DateTime.Parse(attendance.InTime);
            startTimePicker.Value = parsedInTime;
            DateTime parsedOutTime = DateTime.Parse(attendance.outTime);
            endTimePicker.Value = parsedOutTime;
            lblworkinghours.Text = attendance.hours.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            attendance.updtateAttendance();
            loadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            attendance.deleteAttendance();
            loadData();
        }
    }
}
