using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementSchool.ViewModel.Response;
using ManagementSchool.ViewModel.Request.Classes;

namespace ManagementSchool.Services.Classes
{
  public interface IClassService
  {
    Task<List<ClassViewModel>> GetAll();
    Task<ClassViewModel> GetById(int ClassId);
    Task<List<ClassViewModel>> GetClassBySchool(int SchoolId);
    Task<bool> CreateClass(CreateClassRequest req);
    Task<bool> UpdateClass(UpdateClassRequest req);
    Task<bool> DeleteClass(int ClassId);
    Task<List<ClassViewModel>> SearchClassByName(string queryName);
    // Task<bool> AddStudentToClass(int StudentId, int ClassId);
    // Task<bool> RemoveStudentFromClass(int StudentId, int ClassId);
    // Task<bool> AddOfficerToClass(int OfficerId, int ClassId);
    // Task<bool> RemoveOfficerFromClass(int OfficerId, int ClassId);
  }
}