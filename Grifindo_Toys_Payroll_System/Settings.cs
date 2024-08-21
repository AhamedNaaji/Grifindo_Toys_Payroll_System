using Grifindo_Toys_Payroll_System.Commonclasses;
using Grifindo_Toys_Payroll_System.Function_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Toys_Payroll_System
{
    public partial class Settings : Form
    {
        SettingsClass settings = new SettingsClass();
        FillOperations fill = new FillOperations();

        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novermber", "December" };
        public Settings()
        {
            InitializeComponent();
            fillCombobox();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            fillFields();
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void fillCombobox()
        {
            for (int i = 0; i < months.Length; i++)
            {
                cmbmonth.Items.Add(months[i]);
            }
        }

        private void dtpBeginDate_ValueChanged(object sender, EventArgs e)
        {
            int totalDays = calcDate(dtpEndDate.Value, dtpBeginDate.Value);
            settings.totalDays = totalDays;
            lblSalaryCycleDays.Text = totalDays.ToString();
            settings.beginDate = dtpBeginDate.Value.ToString("yyyy/MM/dd");
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

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            int totalDays = calcDate(dtpEndDate.Value, dtpBeginDate.Value);
            settings.totalDays = totalDays;
            lblSalaryCycleDays.Text = totalDays.ToString();
            settings.endDate = dtpEndDate.Value.ToString("yyyy/MM/dd");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            settings.insertSetting();
            fillFields();
        }

        private void fillFields()
        {
            fill.FillDataGridView("SELECT * FROM Settings", dgvsettings);
        }

        private void cmbmonth_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            settings.month = cmbmonth.Text;
        }

        private void txtNo_of_Holidays_TextChanged(object sender, EventArgs e)
        {
            settings.holidays = Convert.ToInt32(txtNo_of_Holidays.Text);
        }

        private void txtGovtTaxRate_TextChanged(object sender, EventArgs e)
        {
            settings.taxRate = float.Parse(txtGovtTaxRate.Text);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            settings.updateSetting();
            fillFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            settings.deleteSetting();
            fillFields();
        }

        private void dgvsettings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            settings.month = dgvsettings.Rows[e.RowIndex].Cells[0].Value.ToString();
            settings.fillSettingsToField();
            cmbmonth.Text = settings.month;
            dtpBeginDate.Value = DateTime.Parse(settings.beginDate);
            dtpEndDate.Value = DateTime.Parse(settings.endDate);
            txtNo_of_Holidays.Text = settings.holidays.ToString();
            txtGovtTaxRate.Text = settings.taxRate.ToString();

        }
    }
}
