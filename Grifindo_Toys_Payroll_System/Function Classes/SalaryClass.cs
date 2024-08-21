using Grifindo_Toys_Payroll_System.Commonclasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Toys_Payroll_System.Function_Classes
{
    internal class SalaryClass
    {

        Common cmn = new Common();
        public int EmpID { get; set; }
        public int totalLeaves { get; set; }
        public int overTimeHours { get; set; }
        public int absentDays { get; set; }
        public float noPayValue { get; set; }
        public float totalBasePay { get; set; }
        public float totalGrossPay { get; set; }
        public float paymentPerDay { get; set; }
        public float totalSalary { get; set; }
        public int cycleDateRange { get; set; }
        public float allowances { get; set; }
        public float overTimeRate { get; set; }
        public float taxRate { get; set; }
        public string month { get; set; }
        public string endDate { get; set; }


        public void getDate()
        {
            string qry = $"SELECT Month, endDate FROM Settings WHERE Month = DATENAME(MONTH, GETDATE())";
            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                month = rd["month"].ToString();
                endDate = rd["endDate"].ToString();
            }
        }
        public void getCycleDateRange()
        {
            string qry = "SELECT (Settings.totalDays-Settings.Holidays) AS DateRange FROM Settings WHERE Month = DATENAME(MONTH, GETDATE())";
            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                cycleDateRange = Convert.ToInt32(rd["DateRange"]);
            }
        }
        public void getTotalLeaves()
        {
            string qry = $"SELECT ISNULL(SUM(totalDays),0) AS Leaves FROM Leave WHERE DATENAME(MONTH, LeaveEndDate) = DATENAME(MONTH, GETDATE()) and\r\nDATENAME(year, LeaveEndDate) = DATENAME(year, GETDATE()) and EmpID = {EmpID}";
            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                totalLeaves = Convert.ToInt32(rd["Leaves"]);
            }
        }
        public void getOverTimeHours()
        {
            string qry = $"SELECT SUM(DATEDIFF(HOUR, InTime, OutTime)-8) AS OverTime FROM Attendance WHERE EmpID = {EmpID} and MONTH(workdate) = MONTH(GETDATE()) and\r\nDATENAME(year, workdate) = DATENAME(year, GETDATE())";
            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                if (!DBNull.Value.Equals(rd["OverTime"]))
                {
                    overTimeHours = Convert.ToInt32(rd["OverTime"]);
                    if (overTimeHours <= 0)
                    {
                        overTimeHours = 0;
                    }
                }
                else
                {
                    overTimeHours = 0;
                }
            }
        }
        public void getAbsentDays()
        {
            string qry = $"SELECT (SELECT (Settings.totalDays-Settings.Holidays) FROM Settings WHERE Month = DATENAME(MONTH, GETDATE())) - (SELECT COUNT(workdate) FROM Attendance WHERE \r\n    DATENAME(MONTH, Attendance.workdate) = DATENAME(MONTH, GETDATE()) AND\r\n    DATENAME(YEAR, Attendance.workdate) = DATENAME(YEAR, GETDATE()) AND\r\n    Attendance.EmpID = {EmpID}) - (SELECT ISNULL(SUM(totalDays),0) AS " +
                $"Leaves FROM Leave WHERE DATENAME(MONTH, LeaveEndDate) = DATENAME(MONTH, GETDATE()) and\r\nDATENAME(year, LeaveEndDate) = DATENAME(year, GETDATE()) and EmpID = {EmpID}) " +
                $"AS AbsentDays";
            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                absentDays = Convert.ToInt32(rd["AbsentDays"]);
            }
        }
        public void getAllowance()
        {
            string qry = $"SELECT Allowances FROM Employee WHERE EmpID = {EmpID}";
            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                allowances = float.Parse(rd["Allowances"].ToString());
            }
        }
        public void getSalary()
        {
            string qry = $"SELECT MonthlySalary FROM Employee WHERE EmpID = {EmpID}";
            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                totalSalary = float.Parse(rd["MonthlySalary"].ToString());
            }
        }
        public void getTaxRate()
        {
            string qry = $"SELECT government_tax_rate FROM Settings WHERE Month = DATENAME(MONTH, GETDATE())";
            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                taxRate = float.Parse(rd["government_tax_rate"].ToString());
            }
        }
        public void getOverTimeRate()
        {
            string qry = $"SELECT EmployeeType.OverTimeHourlyRate FROM EmployeeType INNER JOIN Employee ON " +
                $"Employee.EmployeeTypeID = EmployeeType.EmployeeTypeID WHERE Employee.EmpID = {EmpID}";

            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                overTimeRate = float.Parse(rd["OverTimeHourlyRate"].ToString());
            }
        }
        public void calcPaymentPerDay()
        {
            getSalary();
            getCycleDateRange();
            paymentPerDay = totalSalary / cycleDateRange;
        }
        public void calcNoPayValue()
        {
            calcPaymentPerDay();
            getAbsentDays();
            noPayValue = paymentPerDay * absentDays;
        }
        public void calcBasePayValue()
        {
            getOverTimeHours();
            getOverTimeRate();
            getAllowance();
            totalBasePay = totalSalary + allowances + (overTimeHours * overTimeRate);
        }
        public void calcGrossPayValue()
        {
            calcBasePayValue();
            getTaxRate();
            calcNoPayValue();
            totalGrossPay = totalBasePay - (noPayValue + totalBasePay * (taxRate/100)); 
        }
        public void fillData()
        {
            getDate();
            calcPaymentPerDay();
            calcNoPayValue();
            calcBasePayValue();
            calcGrossPayValue();
        }
        public void insertSalary()
        {
            string query = $"INSERT INTO Salary VALUES({EmpID}, '{endDate}', {noPayValue}, {totalBasePay}, {totalGrossPay})";
            cmn.ExecuteProgram(query, "insert");
        }
        public void updateSalary()
        {
            string query = $"UPDATE Salary SET EmpID = {EmpID}, Month= '{month}', No_Pay_value = {noPayValue}, BasePay_value = {totalBasePay}, GrossPay = {totalGrossPay})";
            cmn.ExecuteProgram(query, "update");
        }
        public void deleteSalary()
        {
            string query = $"DELETE FROM Salary WHERE EmpID = {EmpID} AND Month = '{endDate}'";
            cmn.ExecuteProgram(query, "delete");
        }
        public void selectData()
        {
            string qry = $"SELECT * FROM Salary WHERE Emp = {EmpID} AND Month = '{endDate}'";
            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                EmpID = Convert.ToInt32(rd["EmpID"]);
                endDate = rd["month"].ToString();
                noPayValue = float.Parse(rd["No_Pay_value"].ToString());
                totalBasePay = float.Parse(rd["BasePay_value"].ToString());
                totalGrossPay = float.Parse(rd["GrossPay"].ToString());
            }
        }
    }
}
