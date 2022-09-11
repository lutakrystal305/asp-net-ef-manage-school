using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementSchool.Services.Classes;
using ManagementSchool.ViewModel.Request.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ManagementSchool.Utilities.Exceptions;

namespace ManagementSchool.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClassController : ControllerBase
  {
    private readonly IClassService _classService;
    public ClassController(IClassService classService) {
      _classService = classService;
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAll() {
      var allClass = await _classService.GetAll();
      if (allClass == null) throw new ManageSchoolException();
      return Ok(allClass);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) {
      var cls = await _classService.GetById(id);
      return Ok(JsonConvert.SerializeObject(cls,
                  new JsonSerializerSettings()
                  { 
                      ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                  }));
    }
    [HttpGet("{schoolId}")]
    public async Task<IActionResult> GetClassBySchool(int schoolId) {
      var listClasses = await _classService.GetClassBySchool(schoolId);
      return Ok(listClasses);
    }
    [HttpPost("create")]
    public async Task<IActionResult> CreateClass([FromBody] CreateClassRequest req) {
      if (!ModelState.IsValid) return BadRequest();
      var result = await _classService.CreateClass(req);
      return Ok(result);
    }
    [HttpPost("delete")]
    public async Task<IActionResult> DeleteClass([FromBody] int id) {
      var result = await _classService.DeleteClass(id);
      return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateClass([FromBody] UpdateClassRequest req) {
      if (!ModelState.IsValid) return BadRequest();
      var result = await _classService.UpdateClass(req);
      return Ok(result);
    }
    [HttpGet()]
    public async Task<IActionResult> SearchClassByName([FromQuery]string query) {
      var result = await _classService.SearchClassByName(query);
      return Ok(result);
    }
  }
}