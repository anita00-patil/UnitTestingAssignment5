using Microsoft.AspNetCore.Mvc;
using UnitTestingAssignment5.Models;
using UnitTestingAssignment5.Repository;

namespace UnitTestingAssignment5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService _studentService)
        {
            studentService = _studentService;
        }
        [HttpGet("StudentList")]
        public IEnumerable<Student> StudentList()
        {
           var studentList = studentService.GetStudents();
            return studentList;
        }
        [HttpGet("getstudentbyid")]
        public Student GetStudentById(int Id)
        {
            return studentService.GetStudent(Id);
        }
        [HttpPost("addStudent")]
        public Student AddStudent(Student student)
        {
            return studentService.AddStudent(student);
        }
        [HttpPut("updateSstudent")]
        public Student UpdateStudent(Student student)
        {
            return studentService.UpdateStudent(student);
        }
        [HttpDelete("deletestudent")]
        public bool DeleteStudent(int Id)
        {
            return studentService.DeleteStudent(Id);
        }
    }
}
