using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementSchool.ViewModel.Response;
using ManagementSchool.ViewModel.Request.Schools;

namespace ManagementSchool.Services.Schools
{
  public interface ISchoolService
  {
    Task<List<SchoolViewModel>> GetAll();

    Task<SchoolViewModel> GetById(int id);
    Task<bool> CreateSchool(CreateSchoolRequest req);
    Task<bool> UpdateSchool(UpdateSchoolRequest req);
    Task<bool> DeleteSchool(int SchoolId);
    Task<List<SchoolViewModel>> SearchSchoolByName(string queryName);
  }
}