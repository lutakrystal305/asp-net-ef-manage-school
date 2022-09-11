using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSchool.ViewModel.Request.Students
{
  public class CreateStudentRequest
  {
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
    public int Age { get; set; }
    public int ClassId { get; set; }
  }
}