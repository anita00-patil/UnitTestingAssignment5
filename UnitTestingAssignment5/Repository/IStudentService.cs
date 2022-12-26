using UnitTestingAssignment5.Models;

namespace UnitTestingAssignment5.Repository
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudent(int id);
        public Student AddStudent(Student student);
        public Student  UpdateStudent(Student student);
        public bool DeleteStudent(int id);
    }
}
