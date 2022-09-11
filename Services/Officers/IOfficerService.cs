using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementSchool.ViewModel.Response;
using ManagementSchool.ViewModel.Request.Officers;

namespace ManagementSchool.Services.Officers
{
  public interface IOfficerService
  {
    Task<List<OfficerViewModel>> GetAll();
    Task<OfficerViewModel> GetById(int OfficerId);
    Task<List<OfficerViewModel>> GetOfficerByClass(int ClassId);
    Task<bool> CreateOfficer(CreateOfficerRequest req);
    Task<bool> UpdateOfficer(UpdateOfficerRequest req);
    Task<bool> UpdateClassByOfficer(int officerId, int classId);
    Task<bool> DeleteOfficer(int OfficerId);
    Task<List<OfficerViewModel>> SearchOfficerByName(string queryName);
  }
}