using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSchool.ViewModel.Request.Classes
{
  public class CreateClassRequest
  {
    public string Name { get; set; } = null!;
    public int SchoolId { get; set; }
  }
}