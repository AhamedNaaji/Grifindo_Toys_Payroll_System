﻿using Grifindo_Toys_Payroll_System.Commonclasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Grifindo_Toys_Payroll_System.Function_Classes
{
    internal class LeaveClass
    {
        // Common object for common operations
        Common cmn = new Common();

        // Leave ID
        public int LeaveID;

        // Employee ID
        public int EmpId;


        public string leaveStartDate;
        public string leaveEndDate;
        public int totalDays;
        public int remainingDays;
        public string reason;
        int annualLeave;

        public void getAnnualLeave()
        {
            // FillOperations object for data filling operations
            FillOperations fill = new FillOperations();

            string query = "SELECT AnnualLeave FROM EmployeeType INNER JOIN Employee " +
                "ON EmployeeType.EmployeeTypeID = Employee.EmployeeTypeID WHERE EmpID =" + EmpId;

            SqlDataReader rd = fill.FillWithID(query);
            while(rd.Read())
            {
                annualLeave = (int)rd["AnnualLeave"];
            }
        }
        public void calcRemainingLeave()
        {
            FillOperations fill = new FillOperations();
            /*tring query = "SELECT COALESCE((SELECT SUM(totalDays) FROM" +
               " Leave WHERE YEAR(LeaveEndDate) =
            my sql query for */
            string query = "SELECT COALESCE((SELECT SUM(totalDays) FROM" +
               " Leave WHERE YEAR(LeaveEndDate) = " + DateTime.Now.Year + "AND EmpID = " + EmpId + "), 0) AS totalLeaves";
            SqlDataReader rd = fill.FillWithID(query);
            while (rd.Read())
            {
                remainingDays = annualLeave - (int)rd["totalLeaves"];
            }
        }
        public void insertData()
        {
            string query = "INSERT INTO Leave (EmpID, LeaveStartDate, LeaveEndDate, totalDays, Reason) VALUES (" +
                EmpId + ",'" + leaveStartDate + "','" + leaveEndDate + "'," + totalDays + ",'" + reason + "')";
            cmn.ExecuteProgram(query, "insert");
        }
        public void updateData()
        {
            string query = "UPDATE Leave SET LeaveStartDate = '" + leaveStartDate + "', LeaveEndDate = '" +
                leaveEndDate + "', totalDays = '" + totalDays + "', Reason = '" + reason + "' WHERE LeaveID = " + LeaveID;
            cmn.ExecuteProgram(query, "update");
        }
        public void deleteData()
        {
            string query = "DELETE FROM Leave WHERE LeaveID = " + LeaveID;
            cmn.ExecuteProgram(query, "delete");
        }
        public void fillLeaveToField()
        {
            string qry = "SELECT * FROM Leave WHERE LeaveID =" + LeaveID;
            FillOperations fill = new FillOperations();
            SqlDataReader rd = fill.FillWithID(qry);
            if (rd.Read())
            {
                EmpId = Convert.ToInt32(rd["EmpID"]);
                leaveStartDate = rd["LeaveStartDate"].ToString();
                leaveEndDate = rd["LeaveEndDate"].ToString();
                totalDays = (int)rd["totalDays"];
                reason = rd["Reason"].ToString();
            }
        }
    }
}
