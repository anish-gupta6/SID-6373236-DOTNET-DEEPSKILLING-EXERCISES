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

-- 1. a stored procedure to select employee details based on the DepartmentID.
CREATE PROCEDURE sp_GetEmployeesByDepartmentID
@DepartmentID INT
AS
BEGIN
    SELECT 
        E.EmployeeID,
        E.FirstName,
        E.LastName,
        E.Salary,
        E.JoinDate,
        D.DepartmentName
    FROM Employees E
    INNER JOIN Departments D ON E.DepartmentID = D.DepartmentID
    WHERE E.DepartmentID = @DepartmentID;
END;

-- For executing the stored procedure, you can use the following command:
EXEC sp_GetEmployeesByDepartmentID @DepartmentID = 1001; -- enter your desired DepartmentID here


-- 2. a stored procedure to insert a new employee into the Employees table.
CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE  
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;

-- For executing the stored procedure to insert new Employees, you can use the following command:
EXEC sp_InsertEmployee  -- enter your desired Employee Data here
    @FirstName = 'Anish', 
    @LastName = 'Gupta', 
    @DepartmentID = 1001, 
    @Salary = 69000.00, 
    @JoinDate = '2025-06-27';
