using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSchool.Data.Entities
{
  public class AppUser : IdentityUser<Guid>
  {
    public string? Name { get; set; }
    // public string Email { get; set; }
    // public string Password { get; set; }
    // public Student Stud { get; set; }
    // public School Schl { get; set; }
  }
}
