Create database Grifindo_Toys_Payroll_System;
use Grifindo_Toys_Payroll_System;
drop database Grifindo_Toys_Payroll_System;

-- Creation Of Tables :-)
CREATE TABLE EmployeeType (
    EmployeeTypeID INT PRIMARY KEY identity(1,1) ,
    TypeName VARCHAR(50),
    AnnualLeave INT,
	OverTimeHourlyRate float
);



CREATE TABLE Employee (
    EmpID INT IDENTITY(1, 1) PRIMARY KEY,
    Name VARCHAR(255) not null,
    Address VARCHAR(255) not null,
    MobileNo VARCHAR(15) not null,
	DOB varchar(200),
    AGE INT,
    Gender varchar(10),
	JoinDate varchar(200),
    MonthlySalary int,
    Allowances int,
	NIC varchar(15),
	EmployeeTypeID int,  
    FOREIGN KEY (EmployeeTypeID) references EmployeeType(EmployeeTypeID) ON DELETE CASCADE
);
select * from Settings;

CREATE TABLE Salary (
    EmpID INT,
    Month DATE,
    No_Pay_value DECIMAL(10, 2),
    BasePay_value DECIMAL(10, 2),
    GrossPay DECIMAL(10, 2),
    PRIMARY KEY (EmpID, Month),
	Foreign key (EmpID) references Employee(EmpID) ON DELETE CASCADE
);


CREATE TABLE Settings (
    Month varchar(20) PRIMARY KEY,
	totalDays INT,
    beginDate DATE,
    endDate DATE,
    Holidays INT ,
    government_tax_rate DECIMAL(5, 2)
);


CREATE TABLE Leave (
	LeaveID INT PRIMARY KEY identity(1,1),
    EmpID INT,
    LeaveStartDate DATE,
    LeaveEndDate DATE,
    totalDays INT,
    Reason VARCHAR(255),
	Foreign key (EmpID) references Employee(EmpID) ON DELETE CASCADE
);


CREATE TABLE Attendance (
    EmpID INT,
    workdate DATE,
    InTime TIME,
    OutTime TIME,
    Hours DECIMAL(10, 2),
	Foreign key (EmpID) references Employee(EmpID) ON DELETE CASCADE
);

CREATE TABLE Users (
	username VARCHAR(255) not null,
	password VARCHAR(255) not null
);

insert into Users VALUES('admin','123');

-- SampleData :-)


-- Sample data for EmployeeType table
INSERT INTO EmployeeType (TypeName, AnnualLeave, OverTimeHourlyRate) VALUES
('Full-Time', 20, 15.50),
('Part-Time', 10, 20.75),
('Contractor', 15, 18.00),
('Intern', 5, 0.00);

-- Sample data for Employee table
INSERT INTO Employee (Name, Address, MobileNo, DOB, AGE, Gender, JoinDate, MonthlySalary, Allowances, NIC, EmployeeTypeID) VALUES
('Ahamed Naaji', 'Market Road', '0777829779', '2001-03-02', 32, 'Male', '2022-01-15', 5000, 200, '200106202781', 1),
('Jane Smith', '456 Oak St', '0777859779', '1985-08-22', 37, 'Female', '2021-10-10', 6000, 250, '200106301781', 2),
('Bob Johnson', '789 Maple St', '0777869779', '1995-03-05', 27, 'Male', '2023-02-20', 4500, 150, '200106601781', 3),
('Alice Williams', '321 Elm St', '0777879779', '1992-12-01', 29, 'Female', '2022-05-08', 5500, 180, '200106206781', 1),
('Mark Davis', '567 Pine St', '0777889779', '1988-09-18', 33, 'Male', '2021-08-01', 4800, 120, '200106206581', 2),
('Eva Miller', '876 Birch St', '0777899779', '1993-06-30', 28, 'Female', '2023-01-12', 5200, 200, '200106209481', 3),
('Michael White', '432 Cedar St', '0777669779', '1998-04-25', 23, 'Male', '2022-09-05', 4700, 130, '200106208781', 1),
('Grace Turner', '654 Walnut St', '0777559779', '1987-02-14', 35, 'Female', '2021-12-03', 5800, 250, '200106203181', 2),
('Tom Brown', '789 Pine St', '0777669779', '1991-11-08', 30, 'Male', '2023-03-18', 4900, 140, '200106202181', 3),
('Sara Taylor', '987 Maple St', '0777259779', '1996-08-03', 25, 'Female', '2022-02-28', 5100, 170, '200106203081', 1);


INSERT INTO Settings (Month, totalDays, beginDate, endDate, Holidays, government_tax_rate) VALUES
('January', 31, '2024-01-01', '2024-01-31', 2, 10.00),
('February', 28, '2024-02-01', '2024-02-28', 2, 9.50),
('March', 31, '2024-03-01', '2024-03-31', 3, 9.75),
('April', 30, '2024-04-01', '2024-04-30', 2, 10.25),
('May', 31, '2024-05-01', '2024-05-31', 2, 10.50),
('June', 30, '2024-06-01', '2024-06-30', 1, 10.75),
('July', 31, '2024-07-01', '2024-07-31', 3, 11.00),
('August', 31, '2024-08-01', '2024-08-31', 1, 11.25),
('September', 30, '2024-09-01', '2024-09-30', 2, 11.50),
('October', 31, '2024-10-01', '2024-10-31', 3, 11.75),
('November', 30, '2024-11-01', '2024-11-30', 2, 12.00),
('December', 31, '2024-12-01', '2024-12-31', 3, 12.25);


-- Sample data for Attendance table
INSERT INTO Attendance (EmpID, workdate, InTime, OutTime, Hours) VALUES
(1, '2024-01-03', '09:00:00', '19:30:00', 10.50),
(2, '2024-01-03', '10:30:00', '20:45:00', 10.25),
(3, '2024-01-03', '08:00:00', '18:15:00', 10.25),
(4, '2024-01-03', '09:15:00', '20:00:00', 10.75),
(5, '2024-01-03', '10:00:00', '21:30:00', 11.50),
(6, '2024-01-03', '08:30:00', '19:45:00', 11.25),
(7, '2024-01-03', '09:45:00', '20:15:00', 10.50),
(8, '2024-01-03', '11:00:00', '21:30:00', 10.50),
(9, '2024-01-03', '08:15:00', '18:30:00', 10.25),
(10, '2024-01-03', '10:15:00', '21:00:00', 10.75);

SELECT * From Attendance

-- Sample data for the Leave table
INSERT INTO Leave (EmpID, LeaveStartDate, LeaveEndDate, totalDays, Reason) VALUES
(1, '2024-02-10', '2024-02-15', 6, 'Vacation'),
(2, '2024-03-05', '2024-03-10', 6, 'Family event'),
(3, '2024-04-20', '2024-04-22', 3, 'Personal reasons'),
(4, '2024-06-15', '2024-06-18', 4, 'Medical leave'),
(5, '2024-08-01', '2024-08-05', 5, 'Travel'),
(6, '2024-09-10', '2024-09-12', 3, 'Personal reasons'),
(7, '2024-11-25', '2024-11-27', 3, 'Thanksgiving'),
(8, '2024-12-20', '2024-12-27', 8, 'Year-end break'),
(9, '2025-02-08', '2025-02-10', 3, 'Personal reasons'),
(10, '2025-03-15', '2025-03-20', 6, 'Vacation');



-- Test Queries :-)

SELECT SUM(DATEDIFF(HOUR, InTime, OutTime)-8) AS OverTime FROM Attendance WHERE EmpID = EmpID and MONTH(workdate) = MONTH(GETDATE()) and DATENAME(year, workdate) = DATENAME(year, GETDATE())

SELECT (SELECT AnnualLeave FROM EmployeeType INNER JOIN Employee ON EmployeeType.EmployeeTypeID = Employee.EmployeeTypeID WHERE EmpID = 1005) - COALESCE((SELECT SUM(totalDays) FROM Leave WHERE YEAR(LeaveStartDate) = 2024 AND EmpID = 1005), 0) AS RemainingAnnualLeave



SELECT 
    (SELECT AnnualLeave FROM EmployeeType WHERE EmployeeTypeID = (SELECT EmployeeTypeID FROM Employee WHERE EmpID = 1005)) 
    - COALESCE((SELECT SUM(totalDays) FROM Leave WHERE YEAR(LeaveStartDate) = 2024 AND EmpID = 1005), 0) AS RemainingAnnualLeave;

	SELECT COALESCE((SELECT SUM(totalDays) FROM Leave WHERE YEAR(LeaveStartDate) = 2024 AND EmpID = 1005), 0) AS RemainingAnnualLeave



SELECT totalDays-Holidays FROM Settings


SELECT DATEDIFF(day,beginDate, endDate) FROM Settings AS WorkingDays

SELECT * FROM Leave

-- AbsentDays
SELECT (SELECT (Settings.totalDays-Settings.Holidays) FROM Settings WHERE Month = DATENAME(MONTH, GETDATE())) - (SELECT COUNT(workdate) FROM Attendance WHERE 
    DATENAME(MONTH, Attendance.workdate) = DATENAME(MONTH, GETDATE()) AND
    DATENAME(YEAR, Attendance.workdate) = DATENAME(YEAR, GETDATE()) AND
    Attendance.EmpID = 1) - (SELECT ISNULL(SUM(totalDays),0) AS Leaves FROM Leave WHERE DATENAME(MONTH, LeaveEndDate) = DATENAME(MONTH, GETDATE()) and
DATENAME(year, LeaveEndDate) = DATENAME(year, GETDATE()) and EmpID = 1) AS AbsentDays



--SalaryCycle
SELECT (Settings.totalDays-Settings.Holidays) AS DateRange FROM Settings WHERE Month = DATENAME(MONTH, GETDATE())

--MonthlySalary
SELECT MonthlySalary FROM Employee WHERE EmpID = 1

-- paymentEachDay
SELECT MonthlySalary FROM Employee WHERE EmpID = 1

--Allowance
SELECT Allowances FROM Employee WHERE EmpID = 1

--OverTime
SELECT * FROM Attendance

SELECT DATEDIFF(HOUR, InTime, OutTime)-8 FROM Attendance

SELECT SUM(DATEDIFF(HOUR, InTime, OutTime)-8) AS OverTime FROM Attendance WHERE EmpID = 1 and MONTH(workdate) = MONTH(GETDATE()) and
DATENAME(year, workdate) = DATENAME(year, GETDATE())

--OTRate
SELECT EmployeeType.OverTimeHourlyRate FROM EmployeeType INNER JOIN Employee ON Employee.EmployeeTypeID = EmployeeType.EmployeeTypeID WHERE Employee.EmpID = 1;

--TaxRate
SELECT government_tax_rate FROM Settings WHERE Month = DATENAME(MONTH, GETDATE())

--
SELECT SUM(totalDays) FROM Leave WHERE MONTH(LeaveEndDate) = MONTH(GETDATE()) and EmpID = 1005






SELECT SUM(DATEDIFF(HOUR, InTime, OutTime)-8) AS OverTime FROM Attendance WHERE EmpID = 1 and MONTH(workdate) = MONTH(GETDATE()) and
DATENAME(year, workdate) = DATENAME(year, GETDATE())