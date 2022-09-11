using System;
using System.Text;
using System.Collections.Generic;
using ManagementSchool.Data.Entities;

namespace ManagementSchool.ViewModel.Response
{
  public class SchoolViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
    public List<Class>? Classes { get; set; }
  }
}