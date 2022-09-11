using System;
using System.Text;
using System.Collections.Generic;

namespace ManagementSchool.ViewModel.Request.Common
{
  public class RegisterRequest
  {
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? UserName { get; set; }

    public string Name { get; set; } = null!;
  }
}