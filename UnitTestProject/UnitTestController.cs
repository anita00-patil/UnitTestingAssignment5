using Moq;
using UnitTestingAssignment5.Controllers;
using UnitTestingAssignment5.Models;
using UnitTestingAssignment5.Repository;

namespace UnitTestProject
{
    public class UnitTestController
    {
      
         private readonly Mock<IStudentService> studentService;
        public UnitTestController()
        {
            studentService = new Mock<IStudentService>();
        }
        [Fact]
        public void GetStudentList_StudentList()
        {
            //arrange
            var studentList = GetStudentsData();
            studentService.Setup(x => x.GetStudents())
                .Returns(studentList);
            var studentController = new StudentController(studentService.Object);
            //act
            var studentResult = studentController.StudentList();
            //assert
            Assert.NotNull(studentResult);
            Assert.Equal(GetStudentsData().Count(), studentResult.Count());
            Assert.Equal(GetStudentsData().ToString(), studentResult.ToString());
            Assert.True(studentList.Equals(studentResult));
        }
        [Fact]
        public void GetStudentByID_Studentt()
        {
            //arrange
            var studentList = GetStudentsData();
            studentService.Setup(x => x.GetStudent(2))
                .Returns(studentList[1]);
            var studentController = new StudentController(studentService.Object);
            //act
            var studentResult = studentController.GetStudentById(2);
            //assert
            Assert.NotNull(studentResult);
            Assert.Equal(studentList[1].Id, studentResult.Id);
            Assert.True(studentList[1].Id == studentResult.Id);
        }
        [Theory]
        [InlineData("Shreyas")]
        public void CheckStudenttExistOrNotByStudentName_Studentt(string name)
        {
            //arrange
            var studentList = GetStudentsData();
            studentService.Setup(x => x.GetStudents())
                .Returns(studentList);
            var studentController = new StudentController(studentService.Object);
            //act
            var studentResult = studentController.StudentList();
            var expectedStudenttName = studentResult.ToList()[0].Name;
            //assert
            Assert.Equal(name, expectedStudenttName);
        }

        [Fact]
        public void AddStudent_Student()
        {
            //arrange
            var studentList = GetStudentsData();
            studentService.Setup(x => x.AddStudent(studentList[2]))
                .Returns(studentList[2]);
            var studentController = new StudentController(studentService.Object);
            //act
            var studentResult = studentController.AddStudent(studentList[2]);
            //assert
            Assert.NotNull(studentResult);
            Assert.Equal(studentList[2].Id, studentResult.Id);
            Assert.True(studentList[2].Id == studentResult.Id);
        }

        private List<Student> GetStudentsData()
        {
            List<Student> StudentsData = new List<Student>
        {
            new Student
            {
                Id = 2,
                Name = "Shreyas",
                Address = "Banglore",
                Age = 22,
                Class = 10,
                SubjectName="Science"
            },
             new Student
            {
                Id = 3,
                Name = "Shreya",
                Address = "Mysore",
                Age = 21,
                Class = 9,
                SubjectName="Social"
            },
             new Student
            {
               Id = 4,
                Name = "Sindhu",
                Address = "Manglore",
                Age = 25,
                Class = 11,
                SubjectName="English"
            },
        };
            return StudentsData;
        }
    }

}