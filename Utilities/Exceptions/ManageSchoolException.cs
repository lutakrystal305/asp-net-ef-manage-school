using System;
using System.Text;
using System.Collections.Generic;

namespace ManagementSchool.Utilities.Exceptions
{
  public class ManageSchoolException : Exception
  {
    public ManageSchoolException()
    {
    }
    public ManageSchoolException(string message) :base(message)
    {
    }
    public ManageSchoolException(string message, Exception inner) : base(message, inner)
    {
    }
  }
}