using System;
using System.Text;
using System.Collections.Generic;
using ManagementSchool.Data.Entities;

namespace ManagementSchool.ViewModel.Response
{
  public class ClassViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public School? School { get; set; }
    public List<Officer>? Officers { get; set; }
    public List<Student>? Students { get; set; }
  }
}