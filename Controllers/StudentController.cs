using CSharp_Ado.net.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Office_managementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentdetails _StudentinforServices;


        public StudentController(IStudentdetails StudentinforServices)
        {

            _StudentinforServices = StudentinforServices;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _StudentinforServices.GetAll();

            return Ok(students);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            Student? student = _StudentinforServices.GetById(id);
            if (student == null)
            {
                return NotFound();

            }
                

            return Ok(student);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] Student student)
        {
            string result = _StudentinforServices.Insert(student);


            if (result == "Student inserted successfully")
            {
                return Ok(result);
            }

            return Ok(result);



        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] Student  student)
        {
            String result = _StudentinforServices.Update(id, student);

            if (result == "Student updated successfully")
            {
                return Ok(result);
            }
            else if (result == "Invalid member name. Name must exist in Created_By.")
            {
                return BadRequest(result);
            }
            else if (result == "Student ID not found.")
            {
                return NotFound(result);
            }

            return BadRequest("Student update failed.");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int result = _StudentinforServices.Delete(id);

            if (result == id)
            {
                return NotFound("Student id Not Found");
            }

            return Ok("Student was Deleted successfully ");
        }
    }
}
         



