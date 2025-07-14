using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi_Handson_4.Models;

namespace WebApi_Handson_4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var existingEmployee = EmployeeData.Employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Salary = updatedEmployee.Salary;
            existingEmployee.Permanent = updatedEmployee.Permanent;
            existingEmployee.Department = updatedEmployee.Department;
            existingEmployee.Skills = updatedEmployee.Skills;
            existingEmployee.DateOfBirth = updatedEmployee.DateOfBirth;

            return Ok(existingEmployee);
        }
    }
}
