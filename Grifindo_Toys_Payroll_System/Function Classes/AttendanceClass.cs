using Grifindo_Toys_Payroll_System.Commonclasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Grifindo_Toys_Payroll_System.Function_Classes
{
    internal class AttendanceClass
    {
        Common cmn = new Common();
        public int EmpId;
        public string workDate;
        public string InTime;
        public string outTime;
        public int hours;

        public void insertAttendance()
        {
            string q = "INSERT INTO Attendance VALUES(" + EmpId + ",'" + workDate + "','" + InTime + "','" + 
                outTime + "'," + hours + ')';
            cmn.ExecuteProgram(q, "insert");
        }

        public void updtateAttendance()
        {
            string q = "UPDATE Attendance SET EmpID = " + EmpId + ",workDate = '" + workDate + "',InTime = '" + InTime + "', OutTime = '" +
                outTime + "', Hours = '" + hours + "' WHERE EmpID =" + EmpId + "AND workdate =" + "'" + workDate + "'";
            cmn.ExecuteProgram(q, "update");
        }
        public void deleteAttendance()
        {
            string q = "DELETE FROM Attendance WHERE EmpID =" + EmpId + "AND workdate =" + "'" + workDate + "'";
            cmn.ExecuteProgram(q, "delete");
        }

        public void FillAttendanceToField()
        {

            string qry = "SELECT * FROM Attendance WHERE EmpID =" + EmpId + "AND workdate =" + "'" + workDate + "'";
            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                EmpId = Convert.ToInt32(rd["EmpID"]);
                workDate = rd["workDate"].ToString();
                InTime = rd["InTime"].ToString();
                outTime = rd["OutTime"].ToString();
                hours = Convert.ToInt32(rd["Hours"]);
            }
        }

    }
}
