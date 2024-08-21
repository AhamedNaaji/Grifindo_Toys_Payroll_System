using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace Grifindo_Toys_Payroll_System.Commonclasses
{
    internal class FillOperations
    {
        Dbconnection con = new Dbconnection();
        public void FillCombobox(string qry, ComboBox cmbox_name, string display_mem, string value_mem)
        {
            

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(qry, con.myCon);
            da.Fill(dt);
            cmbox_name.DisplayMember = display_mem;
            cmbox_name.ValueMember = value_mem;
            cmbox_name.DataSource = dt; 

        }

        public void FillDataGridView(string qry, DataGridView dgv)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(qry, con.myCon);
            da.Fill(dt);
            dgv.DataSource = dt;
        }

        public SqlDataReader FillWithID(string qry)
        {
            con.myCon.Open();
            SqlCommand cmd = new SqlCommand(qry, con.myCon);
            SqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
           
        }

        public void FillReportView(string qry, ReportViewer rpt)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(qry, con.myCon);
            da.Fill(dt);

            rpt.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("SalaryReport", dt);
            ReportDataSource source1 = new ReportDataSource("Employee", dt);
            ReportDataSource source2 = new ReportDataSource("EmployeeType", dt);
            ReportDataSource source3 = new ReportDataSource("Salary", dt);
            rpt.LocalReport.ReportPath = "C:\\ESOFT\\Programming\\ASSIGNMENT\\Grifindo Toys Payroll System\\Grifindo_Toys_Payroll_System\\EmployeeReport.rdlc";
            rpt.LocalReport.DataSources.Add(source);
            rpt.LocalReport.DataSources.Add(source1);
            rpt.LocalReport.DataSources.Add(source2);
            rpt.LocalReport.DataSources.Add(source3);
            rpt.RefreshReport();
        }
    }
}
