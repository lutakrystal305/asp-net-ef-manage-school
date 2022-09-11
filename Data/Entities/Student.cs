using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSchool.Data.Entities
{
  public class Student
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Address { get; set; }
    public int ClassId { get; set; }
    public Class? Class { get; set; }
  }
}