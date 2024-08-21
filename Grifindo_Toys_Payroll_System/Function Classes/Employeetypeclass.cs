using Grifindo_Toys_Payroll_System.Commonclasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grifindo_Toys_Payroll_System.Function_Classes
{
    internal class Employeetypeclass
    {
        Common cmn = new Common();
        public int EmpTypeID { get; set; }
        public string typeName { get; set; }
        public int NoAnnLeaves { get; set; }
        public double overTimeHourlyRate { get; set; }

        public void FillEmployeTypeToField()
        {
            string qry = "SELECT * FROM EmployeeType WHERE EmployeeTypeID = " + EmpTypeID;
            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                typeName = rd["typeName"].ToString();
                NoAnnLeaves = Convert.ToInt32(rd["AnnualLeave"]);
                overTimeHourlyRate = Convert.ToDouble(rd["overTimeHourlyRate"]);
            }
        }

        public void InsertData()
        {
            string q = "INSERT INTO EmployeeType(typeName, AnnualLeave, overTimeHourlyRate)" +
                 "VALUES('" + typeName + "'," + NoAnnLeaves + "," + overTimeHourlyRate + ")";
            cmn.ExecuteProgram(q, "insert");
            
        }

        public void UpdateData()
        {
           string q = "UPDATE EmployeeType SET TypeName = '" + typeName + "',AnnualLeave = " + NoAnnLeaves + ",overTimeHourlyRate = " + overTimeHourlyRate + " WHERE EmployeeTypeID = " + EmpTypeID;
            cmn.ExecuteProgram(q, "update");
        }

        public void DeleteData()
        {
            string q = "Delete from EmployeeType WHERE EmployeeTypeID = " + EmpTypeID;
            cmn.ExecuteProgram(q, "delete");
        }

        

    }
}
