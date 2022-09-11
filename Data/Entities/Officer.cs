using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSchool.Data.Entities
{
  public class Officer
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Major { get; set; }
    public int ClassId { get; set; }
    public Class? Class { get; set; }
  }
}
