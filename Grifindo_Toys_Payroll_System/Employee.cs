using Grifindo_Toys_Payroll_System.Commonclasses;
using Grifindo_Toys_Payroll_System.Function_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Grifindo_Toys_Payroll_System
{
    public partial class Employee : Form
    {
        FillOperations fill = new FillOperations();
        Employeeclass employee = new Employeeclass();
        public Employee()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnmale.Checked)
            {
                employee.Gender = "Male";
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            employee.InsertData();
            FirstRun();
        }

        private void txtNIC_TextChanged(object sender, EventArgs e)
      {
            employee.NIC = txtNIC.Text;
        }



        private void txtMonthlySalary_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            fill.FillCombobox("SELECT * FROM EmployeeType", cmbemployeetypeid, "TypeName", "EmployeeTypeID");
            FirstRun();
        }

        private void cmbemployeetypeid_SelectedIndexChanged(object sender, EventArgs e)
        {
            employee.EmpTypeID = Convert.ToInt32(cmbemployeetypeid.SelectedValue);
        }

        void FirstRun()
        {
            txtEmpName.Text = "";
            cmbemployeetypeid.Text = "";
            txtAddress.Text = "";
            txtMobileno.Text = "";
            
            txtNIC.Text = "";
            txtdob.Text = "";
            txtage.Text = "";
            rbtnmale.Checked = false;
            rbtnfemale.Checked = false;
            dtpJoiningDate.Value = DateTime.Now;
            txtMonthlySalary.Text = string.Empty;
            txtAllowance.Text = string.Empty;
            fill.FillDataGridView("SELECT * FROM Employee", dgvemployee);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            try
            {
                txtdob.Text = "";
                txtage.Text = "";
                rbtnmale.Checked = false;
                rbtnfemale.Checked = false;
                string NICNo = txtNIC.Text;
                int dayText = 0;
                string year = "";

                if (NICNo.Length != 10 && NICNo.Length != 12)
                {
                    throw new Exception("Invalid NIC NO");
                }
                else if (NICNo.Length == 10 && !IsNumeric(NICNo.Substring(0, 9)))
                {
                    throw new Exception("Invalid NIC NO");
                }
                else
                {
                    if (NICNo.Length == 10)
                    {
                        year = "19" + NICNo.Substring(0, 2);
                        dayText = int.Parse(NICNo.Substring(2, 3));
                    }
                    else
                    {
                        year = NICNo.Substring(0, 4);
                        dayText = int.Parse(NICNo.Substring(4, 3));
                    }
                    if (dayText > 500)
                    {
                        dayText -= 500;
                        rbtnfemale.Checked = true;
                    }
                    else
                    {
                        rbtnmale.Checked = true;
                    }
                    if (dayText < 1 || dayText > 366)
                    {
                        throw new Exception("Invalid NIC NO");
                    }
                    else
                    {
                        DateTime birthday = new DateTime(int.Parse(year), 1, 1).AddDays(dayText - 2);
                        int age = DateTime.Now.Year - birthday.Year;
                        if (birthday.AddYears(age) > DateTime.Now)
                        {
                            age--;
                        }
                        txtage.Text = age.ToString();


                        txtdob.Text = birthday.ToString("yyyy-MM-dd");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsNumeric(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            employee.EmpName = txtEmpName.Text.Trim();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            employee.Address = txtAddress.Text;
        }

        private void txtMobileno_TextChanged(object sender, EventArgs e)
        {
            
            string pattern = @"^[^A-Za-z]*$";

            
            Regex regex = new Regex(pattern);

            
            Match match = regex.Match(txtMobileno.Text);

             
            if (match.Success && txtMobileno.Text != "")
            {
                
                employee.MobileNO = Convert.ToInt32(txtMobileno.Text);
            }
            else
            {
                MessageBox.Show("Invalid Mobile Number");
                txtMobileno.Text = "";
            }


        }

       

        private void dtpJoiningDate_ValueChanged(object sender, EventArgs e)
        {
            employee.Joindate = dtpJoiningDate.Value.ToString("yyyy/MM/dd");
        }

        private void txtMonthlySalary_TextChanged(object sender, EventArgs e)
        {
            employee.MonthlySalary = (txtMonthlySalary.Text == "") ? 0 : Convert.ToInt32(txtMonthlySalary.Text);
        }

        private void txtAllowance_TextChanged(object sender, EventArgs e)
        {
            employee.Allowance = (txtAllowance.Text == "") ? 0 : Convert.ToInt32(txtAllowance.Text);
        }

        private void dgvemployee_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            employee.EmpID = Convert.ToInt32(dgvemployee.Rows[e.RowIndex].Cells[0].Value);
            employee.FillEmployeToField();
            fillContents();


            btnInsert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void rbtnfemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnfemale.Checked)
            {
                employee.Gender = "Female";
            }
        }

        private void txtdob_TextChanged(object sender, EventArgs e)
        {
            employee.dob = txtdob.Text;
        }

        private void txtage_TextChanged(object sender, EventArgs e)
        {
            employee.Age = txtage.Text;

        }

        private void dgvemployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            employee.EmpID = Convert.ToInt32(dgvemployee.Rows[e.RowIndex].Cells[0].Value);
            employee.FillEmployeToField();
            fillContents();


            btnInsert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            employee.DeleteData();
            FirstRun();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            fillContents();
            employee.UpdateData();
            FirstRun();
        }

        void fillContents()
        {
            txtEmpName.Text = employee.EmpName;
            cmbemployeetypeid.SelectedValue = employee.EmpTypeID;
            txtAddress.Text = employee.Address;
            txtMobileno.Text = employee.MobileNO.ToString();
            txtNIC.Text = employee.NIC.ToString();
            txtdob.Text = employee.dob.ToString();
            txtage.Text = employee.Age.ToString();
            rbtnmale.Checked = employee.Gender == "male";
            rbtnmale.Checked = employee.Gender == "Female";
            dtpJoiningDate.Text = employee.Joindate;
            txtMonthlySalary.Text = employee.MonthlySalary.ToString();
            txtAllowance.Text = employee.Allowance.ToString();
        }
    }
}

