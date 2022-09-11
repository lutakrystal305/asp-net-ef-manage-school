using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSchool.ViewModel.Request.Schools
{
  public class UpdateSchoolRequest
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
  }
}