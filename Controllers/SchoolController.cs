using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementSchool.Services.Schools;
using ManagementSchool.ViewModel.Request.Schools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ManagementSchool.Utilities.Exceptions;

namespace ManagementSchool.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SchoolController : ControllerBase
  {
    private readonly ISchoolService _schoolService;
    public SchoolController(ISchoolService schoolService) {
      _schoolService = schoolService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll() {
      var allSchool = await _schoolService.GetAll();
      if (allSchool == null) throw new ManageSchoolException();
      return Ok(allSchool);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) {
      var school = await _schoolService.GetById(id);
      return Ok(JsonConvert.SerializeObject(school,
                  new JsonSerializerSettings()
                  { 
                      ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                  }));
    }
    [HttpPost("create")]
    public async Task<IActionResult> CreateSchool([FromBody] CreateSchoolRequest req) {
      if (!ModelState.IsValid) return BadRequest();
      var result = await _schoolService.CreateSchool(req);
      if (!result) throw new ManageSchoolException();
      return Ok(result);
    }
    [HttpPut()]
    public async Task<IActionResult> UpdateSchool(UpdateSchoolRequest req) {
      if (!ModelState.IsValid) return BadRequest();
      var result = await _schoolService.UpdateSchool(req);
      if (!result) throw new ManageSchoolException();
      return Ok(result);
    }
    [HttpPost("delete")]
    public async Task<IActionResult> DeleteSchool([FromBody] int id) {
      var result = await _schoolService.DeleteSchool(id);
      if (!result) throw new ManageSchoolException();
      return Ok(result);
    }
    [HttpGet("search")]
    public async Task<IActionResult> SearchSchoolByName([FromQuery]string queryName) {
      var result = await _schoolService.SearchSchoolByName(queryName);
      return Ok(result);
    }
  }
}