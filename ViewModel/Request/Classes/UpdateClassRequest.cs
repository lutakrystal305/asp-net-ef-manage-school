using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSchool.ViewModel.Request.Classes
{
  public class UpdateClassRequest
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public int SchoolId { get; set; }
  }
}