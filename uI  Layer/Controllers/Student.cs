using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using DomainLayer; // Make sure to import the namespace where Student class is defined

namespace uI__Layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly EligibilityChecker _eligibilityChecker;

        public StudentsController(IStudentService studentService, ISubjectService subjectService, EligibilityChecker eligibilityChecker)
        {
            _studentService = studentService;
            _subjectService = subjectService;
            _eligibilityChecker = eligibilityChecker;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            await _studentService.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            try
            {
                await _studentService.UpdateStudentAsync(student);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }

        [HttpGet("CheckEligibility")]
        public async Task<IActionResult> CheckEligibility(Student student, int subjectId)
        {
            if (student == null)
            {
                return BadRequest("Student information is required.");
            }

            var subject = await _subjectService.GetSubjectByIdAsync(subjectId);

            if (subject == null)
            {
                return NotFound($"Subject with ID {subjectId} not found.");
            }

            bool isEligible = _eligibilityChecker.IsStudentEligibleForSubject(student, subject);

            return Ok(new { IsEligible = isEligible, Message = isEligible ? "Student is eligible for the subject." : "Student is not eligible for the subject." });
        }



    }
}
