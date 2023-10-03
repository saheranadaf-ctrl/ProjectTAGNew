using StudentAPI.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


//using StudentAPI.DataModels;

namespace StudentApi.Controllers
{

    
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly StudentDataContext _dbContext;

        public StudentController(StudentDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<School>> CreateStudent(School student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                
                // Add any additional data validation logic here

                _dbContext.Schools.Add(student);
                 await _dbContext.SaveChangesAsync();

                return CreatedAtAction("GetStudentById", new { id = student.StudentId }, student);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var existingStudent = await _dbContext.Schools.FindAsync(id);

                if (existingStudent == null)
                {
                    return NotFound("Student not found");
                }

                _dbContext.Schools.Remove(existingStudent);
                await _dbContext.SaveChangesAsync();

                return Ok(existingStudent);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }



        [HttpGet("GetAll")]
        public IActionResult GetAll(){
            var student = this._dbContext.Schools.ToList();
            return Ok(student);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetStudentById(string id)
        {
            try
            {
                // if (!int.TryParse(id, out int studentId))
                // {
                //     return BadRequest("Invalid student ID format"); // Return 400 Bad Request for invalid ID format
                // }

                var student = _dbContext.Schools.FirstOrDefault(o=>o.StudentId == id);

                if (student == null)
                {
                    return NotFound("Student not found"); // Return 404 Not Found if the student with the given id is not found
                }

                return Ok(student); // Return 200 OK with the student data if found
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

    }
}