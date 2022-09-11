using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSchool.ViewModel.Request.Officers
{
  public class UpdateOfficerRequest
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Major { get; set; }
    public int ClassId { get; set; }
  }
}