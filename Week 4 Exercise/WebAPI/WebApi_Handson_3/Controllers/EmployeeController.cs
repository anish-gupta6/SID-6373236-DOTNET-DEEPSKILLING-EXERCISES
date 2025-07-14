using Microsoft.AspNetCore.Mvc;
using WebApi_Handson_3.Models;
using WebApi_Handson_3.Filters;

namespace WebApi_Handson_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomAuthFilter))]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>();

        public EmployeeController()
        {
            if (!employees.Any())
            {
                employees = GetStandardEmployeeList();
            }
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Id = 101, Name = "IT" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "ASP.NET Core" }
                    },
                    DateOfBirth = new DateTime(1990, 1, 1)
                }
            };
        }

        [HttpGet("standard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(employees);
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            employees.Add(emp);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, Employee emp)
        {
            var existing = employees.FirstOrDefault(e => e.Id == id);
            if (existing == null) return NotFound();

            existing.Name = emp.Name;
            existing.Salary = emp.Salary;
            existing.Permanent = emp.Permanent;
            existing.Department = emp.Department;
            existing.Skills = emp.Skills;
            existing.DateOfBirth = emp.DateOfBirth;

            return Ok();
        }
    }
}
