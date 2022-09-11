using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSchool.ViewModel.Request.Officers
{
  public class CreateOfficerRequest
  {
    public string Name { get; set; } = null!;
    public string Major { get; set; } = null!;
    public int ClassId { get; set; }
  }
}