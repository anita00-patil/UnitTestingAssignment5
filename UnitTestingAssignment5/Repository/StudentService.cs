using UnitTestingAssignment5.Models;

namespace UnitTestingAssignment5.Repository
{
    public class StudentService:IStudentService
    {
        private readonly UnitDbContext _dbContext;
        public StudentService(UnitDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Student AddStudent(Student student)
        {
            var result = _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public Student UpdateStudent(Student student)
        {
            var result = _dbContext.Students.Update(student);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteStudent(int Id)
        {
            var filteredData = _dbContext.Students.Where(x => x.Id == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _dbContext.Students.ToList();
        }

        public Student GetStudent(int id)
        {
            return _dbContext.Students.Where(x => x.Id == id).FirstOrDefault();
        }
    }

}
