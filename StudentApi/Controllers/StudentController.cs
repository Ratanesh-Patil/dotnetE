using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using StudentApi.Model;
using StudentApi.DAL;



namespace StudentController;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [EnableCors()]
     public IEnumerable<Student> GetAllStudents()
    {
        List<Student> stud = StudentDataAccess.GetAllStudents();
        return stud;
    }
   
   [HttpPost]
   [EnableCors]
   public IActionResult InsertNewStudent(Student stud)
   {
    StudentDataAccess.SaveStudent(stud);
    return Ok(new {message = "Student Inserted" });
   }

    [HttpDelete]
    [EnableCors]
     public IActionResult DeleteStudent(string name)
   {
    StudentDataAccess.DeleteStudentByname(name);
    return Ok(new {message = "Student deleted" });
   }

}
