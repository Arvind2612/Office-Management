 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Office_managementAPI.Data;
using Office_managementAPI.Models;

namespace Office_managementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContent _dbcontext;

        public EmployeeController(ApplicationDBContent dbcontext)//constructure which creates the link to database;
        {
            _dbcontext = dbcontext;
        }
        [HttpPost]

        public ActionResult Create([FromBody] Employee employee)
        {
            employee.Id = 0;
            _dbcontext.EmpDB.Add(employee);
            _dbcontext.SaveChanges();

            return Ok();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("byname/{name}")]
        public ActionResult<Employee> GetByName(string name)
        {
            var emp = _dbcontext.EmpDB.FirstOrDefault(e=>e.Name==name);//they finds the name whether exist or not;
            if (emp == null)
            {
                return NotFound("Employee not found");

            }
                
            return Ok(emp);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Employee employee)
        {
            var emp = _dbcontext.EmpDB.Find(id);
            if (emp == null)
                return BadRequest("404");

            emp.Name = employee.Name;
            emp.Role = employee.Role;
            emp.DomainName = employee.DomainName;
            emp.Email = employee.Email;

            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var emp = _dbcontext.EmpDB.Find(id);
            if (emp == null)
                return BadRequest("Employee not found");

            _dbcontext.EmpDB.Remove(emp);
            _dbcontext.SaveChanges();
            return Ok();

           
        }




            
        }
    }

