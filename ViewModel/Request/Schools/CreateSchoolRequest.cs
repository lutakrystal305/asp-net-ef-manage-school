using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSchool.ViewModel.Request.Schools
{
  public class CreateSchoolRequest
  {
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
  }
}