using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSchool.ViewModel.Request.Students
{
  public class UpdateStudentRequest
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public int Age { get; set; }
    public int ClassId { get; set; }
  }
}