using System;
using System.Text;
using System.Collections.Generic;

namespace ManagementSchool.ViewModel.Request.Common
{
  public class LoginRequest
  {
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
  }
}