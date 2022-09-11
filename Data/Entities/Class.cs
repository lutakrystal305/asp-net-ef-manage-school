using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSchool.Data.Entities
{
  public class Class
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public int SchoolId { get; set; }
    //public int OfficerId { get; set; }
    public School? School { get; set; }
    //public Officer Teacher { get; set; }
    public List<Officer>? Officers { get; set; }
    public List<Student>? Students { get; set; }
  }
}