using Microsoft.AspNetCore.Mvc;
using ManagementSchool.Utilities.Exceptions;
using ManagementSchool.Services.Common;
using ManagementSchool.ViewModel.Request.Common;

namespace ManagementSchool.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IUserService _userService;
    public UsersController(IUserService userService) {
      _userService = userService;
    }
    [HttpGet]
    public string Get() {
      return "123";
    }
    [HttpPost("signin")]
    public async Task<IActionResult> Login([FromBody] LoginRequest req) {
      if (!ModelState.IsValid) return BadRequest();
      var result = await _userService.Login(req);
      // if (result != null) throw new ManageSchoolException();
      return Ok(result);
    }
    [HttpPost("signup")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest req) {
      if (!ModelState.IsValid) return BadRequest();
      var result = await _userService.Register(req);
      if (!result) throw new ManageSchoolException();
      return Ok(result);
    }
  }
}