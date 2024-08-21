using Grifindo_Toys_Payroll_System.Commonclasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Grifindo_Toys_Payroll_System.Function_Classes
{
    internal class SettingsClass
    {
        public string month;
        public int totalDays;
        public string beginDate;
        public string endDate;
        public int holidays;
        public float taxRate;

        Common cmn = new Common();

        public void insertSetting()
        {
            string query = "INSERT INTO Settings VALUES ('" + month + "'," + totalDays + ",'" + beginDate + "','" + endDate + "'," + holidays + "," + taxRate + ")";

            cmn.ExecuteProgram(query, "insert");
        }

        public void updateSetting()
        {
            string query = "UPDATE Settings SET Month = '" + month + "',totalDays =" + totalDays + ", beginDate = '" + beginDate + "', endDate = '" + endDate + "', Holiday = " + holidays + ", government_tax_rate = " + taxRate + "WHERE Month = '" + month + "'";
            cmn.ExecuteProgram(query, "update");
        }

        public void deleteSetting()
        {
            string query = "DELETE FROM Settings WHERE Month = '" + month + "'";
            cmn.ExecuteProgram(query, "delete");
        }

        public void fillSettingsToField()
        {
            string qry = "SELECT * FROM Settings WHERE Month ='" + month + "'";

            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                month = rd["Month"].ToString();
                totalDays = (int)rd["totalDays"];
                beginDate = rd["beginDate"].ToString();
                endDate = rd["endDate"].ToString();
                holidays = Convert.ToInt32(rd["Holidays"]);
                taxRate = Convert.ToInt32(rd["government_tax_rate"]);
            }
        }
    }
}
