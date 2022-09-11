using ManagementSchool.Services.Students;
using ManagementSchool.ViewModel.Request.Students;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ManagementSchool.Utilities.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace ManagementSchool.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StudentController : ControllerBase
  {
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService) {
      _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
      var allStudent = await _studentService.GetAll();
      return Ok(allStudent);
    }
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById(int id) {
      var student = await _studentService.GetById(id);
      return Ok(JsonConvert.SerializeObject(student,
                  new JsonSerializerSettings()
                  { 
                      ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                  }));
    }
    [HttpGet("class/{classId}")]
    public async Task<IActionResult> GetStudentByClass(int classId) {
      var listStudents = await _studentService.GetStudentByClass(classId);
      return Ok(listStudents);
    }
    [HttpPost("create")]
    public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequest req) {
      if (!ModelState.IsValid) return BadRequest();
      var result = await _studentService.CreateStudent(req);
      if (!result) throw new ManageSchoolException();
      return Ok(result);
    }
    [HttpPut()]
    [Authorize]
    public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentRequest req) {
      if (!ModelState.IsValid) return BadRequest();
      var result = await _studentService.UpdateStudent(req);
      if (!result) throw new ManageSchoolException();
      return Ok(result);
    }
    [HttpPatch("{studentId}")]
    public async Task<IActionResult> UpdateClassByStudent(int studentId, [FromBody] int classId) {
      var result = await _studentService.UpdateClassByStudent(studentId, classId);
      // if (!result) throw new ManageSchoolException();
      return Ok(result);
    } 
    [HttpPost("delete")]
    public async Task<IActionResult> DeleteStudent([FromBody] int id) {
      var result = await _studentService.DeleteStudent(id);
      if (!result) throw new ManageSchoolException();
      return Ok(result);
    }
    [HttpGet("search")]
    public async Task<IActionResult> SearchStudentByName([FromQuery] string queryName) {
      var result = await _studentService.SearchStudentByName(queryName);
      return Ok(result);
    }
    [HttpGet("pagination")]
    public async Task<IActionResult> GetStudentsByPages([FromQuery] int page, [FromQuery] int limit) {
      var result = await _studentService.GetStudentsByPages(page, limit);
      return Ok(result);
    } 
  }
}