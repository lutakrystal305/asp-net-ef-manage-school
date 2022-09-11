using System;
using System.Text;
using System.Collections.Generic;
using ManagementSchool.Data.Entities;

namespace ManagementSchool.ViewModel.Response
{
  public class  OfficerViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Major { get; set; }
    public Class? Class { get; set; }
  }
}