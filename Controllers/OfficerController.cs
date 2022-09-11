using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementSchool.Services.Officers;
using ManagementSchool.ViewModel.Request.Officers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ManagementSchool.Utilities.Exceptions;

namespace ManagementSchool.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OfficerController : ControllerBase
  {
    private readonly IOfficerService _officerService;
    public OfficerController(IOfficerService officerService) {
      _officerService = officerService;
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAll() {
      var allOfficer = await _officerService.GetAll();
      if (allOfficer == null) throw new ManageSchoolException();
      return Ok(allOfficer);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) {
      var officer = await _officerService.GetById(id);
      return Ok(JsonConvert.SerializeObject(officer,
                  new JsonSerializerSettings()
                  { 
                      ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                  }));
    }
    [HttpGet("class/{classId}")]
    public async Task<IActionResult> GetOfficerByClass(int classId) {
      var listOfficers = await _officerService.GetOfficerByClass(classId);
      return Ok(listOfficers);
    }
    [HttpPost("create")]
    public async Task<IActionResult> CreateOfficer([FromBody] CreateOfficerRequest req) {
      if (!ModelState.IsValid) return BadRequest();
      var result = await _officerService.CreateOfficer(req);
      if (!result) throw new ManageSchoolException();
      return Ok(result);
    }
    [HttpPost("delete")]
    public async Task<IActionResult> DeleteOfficer([FromBody] int id) {
      var result = await _officerService.DeleteOfficer(id);
      if (!result) throw new ManageSchoolException();
      return Ok(result);
    }
    [HttpPut()]
    public async Task<IActionResult> UpdateOfficer(UpdateOfficerRequest req) {
      if (!ModelState.IsValid) return BadRequest();
      var result = await _officerService.UpdateOfficer(req);
      if (!result) throw new ManageSchoolException();
      return Ok(result);
    }
    [HttpPut("join-class/{classId}")]
    public async Task<IActionResult> UpdateClassByOfficer([FromBody] int officerId, int classId) {
      var result = await _officerService.UpdateClassByOfficer(officerId, classId);
      if (!result) throw new ManageSchoolException();
      return Ok(result);
    }
    [HttpGet("search")]
    public async Task<IActionResult> SearchOfficerByName([FromQuery] string queryName) {
      var result = await _officerService.SearchOfficerByName(queryName);
      return Ok(result);
    }
  }
}