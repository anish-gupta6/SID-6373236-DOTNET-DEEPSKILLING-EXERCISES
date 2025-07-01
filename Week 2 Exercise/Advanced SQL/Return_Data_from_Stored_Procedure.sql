--Departments Table Schema
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

--Employees Table Schema
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);

--a stored procedure to count the number of employees in the specified department.
CREATE PROCEDURE sp_GetEmployeeCountByDepartment
@DepartmentID INT
AS
BEGIN
    SELECT COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
