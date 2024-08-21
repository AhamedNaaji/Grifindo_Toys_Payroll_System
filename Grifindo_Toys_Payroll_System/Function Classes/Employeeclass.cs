using Grifindo_Toys_Payroll_System.Commonclasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Grifindo_Toys_Payroll_System.Function_Classes
{
    internal class Employeeclass
    {
        Common cmn = new Common();
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
        public int MobileNO { get; set; }
        public string dob { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Joindate { get; set; }
        public int MonthlySalary { get; set; }
        public int Allowance { get; set; }
        public string NIC { get; set; }
        public int EmpTypeID { get; set; }

        public void InsertData()
        {
            
            string q = "INSERT INTO Employee(Name,Address, MobileNo,DOB,AGE,Gender,JoinDate,MonthlySalary,Allowances,NIC,EmployeeTypeID )"
                + "VALUES('" + EmpName + "','" + Address + "','" + MobileNO + "','" + dob + "','" + Age + "'," +
                "'" + Gender + "','" + Joindate + "','" + MonthlySalary + "','" + Allowance + "','" + NIC + "','"+ EmpTypeID + "')";
            cmn.ExecuteProgram(q, "insert");

        }
        public void UpdateData()
        {
            string q = "UPDATE Employee SET Name = '" + EmpName +
                "',Address = '" + Address +
                "', MobileNO = '" + MobileNO +
                "', DOB = '" + dob +
                "', AGE = '" + Age +
                "', Gender = '" + Gender +
                "', JoinDate = '" + Joindate +
                "', MonthlySalary = '" + MonthlySalary +
                "', Allowances = '" + Allowance +
                "', NIC = '" + NIC +
                "', EmployeeTypeID =" + EmpTypeID +
                 " WHERE EmpID = " + EmpID;
            cmn.ExecuteProgram(q, "update");
        }

        public void DeleteData()
        {
            string q = "Delete from Employee WHERE EmpID = " + EmpID ;
            cmn.ExecuteProgram(q, "delete");
        }

        public void FillEmployeToField()
        {

            string qry = "SELECT * FROM Employee WHERE EmpID =" + EmpID;
            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                EmpID = Convert.ToInt32(rd["EmpID"]);
                EmpName = rd["Name"].ToString();
                Address = rd["Address"].ToString();
                MobileNO = Convert.ToInt32(rd["MobileNO"]);
                dob = rd["DOB"].ToString();
                Age = rd["AGE"].ToString();
                Gender = rd["Gender"].ToString();
                Joindate = rd["JoinDate"].ToString();
                MonthlySalary = Convert.ToInt32(rd["MonthlySalary"]);
                Allowance = Convert.ToInt32(rd["Allowances"]);
                NIC = rd["NIC"].ToString();
            }
        }
       
    }
}
