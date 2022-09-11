using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementSchool.ViewModel.Request.Common;

namespace ManagementSchool.Services.Common
{
  public interface IUserService
  {
    Task<string> Login(LoginRequest req);

    Task<bool> Register(RegisterRequest req);
 
  }
}