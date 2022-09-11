using System;
using System.Collections.Generic;
using System.Text;

  namespace ManagementSchool.Data.Entities
  {
    public class School
    {
      public int Id { get; set; }
      public string? Name { get; set; }
      public string? Address { get; set; }
      public List<Class>? Classes { get; set; }
    }
  }