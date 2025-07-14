namespace WebApi_Handson_4.Models
{
    public static class EmployeeData
    {
        public static List<Employee> Employees = new List<Employee>
    {
        new Employee
        {
            Id = 1,
            Name = "Anish Gupta",
            Salary = 100000,
            Permanent = true,
            DateOfBirth = new DateTime(2003, 09, 21),
            Department = new Department { Id = 1, Name = "Development" },
            Skills = new List<Skill> {
                new Skill { Id = 1, Name = "C#" },
                new Skill { Id = 2, Name = "SQL" }
            }
        },
        new Employee
        {
            Id = 2,
            Name = "Rahul Sharma",
            Salary = 40000,
            Permanent = false,
            DateOfBirth = new DateTime(2005, 03, 25),
            Department = new Department { Id = 2, Name = "QA" },
            Skills = new List<Skill> {
                new Skill { Id = 3, Name = "Selenium" }
            }
        }
    };
    }
}
