using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementSchool.ViewModel.Response;
using ManagementSchool.ViewModel.Request.Students;

namespace ManagementSchool.Services.Students
{
  public interface IStudentService
  {
    Task<List<StudentViewModel>> GetAll();
    Task<StudentViewModel> GetById(int id);
    Task<List<StudentViewModel>> GetStudentByClass(int ClassId);
    Task<bool> CreateStudent(CreateStudentRequest req);
    Task<bool> UpdateStudent(UpdateStudentRequest req);
    Task<bool> UpdateClassByStudent(int userId, int classId);
    Task<bool> DeleteStudent(int StudentId);
    Task<List<StudentViewModel>> SearchStudentByName(string queryName);
    Task<List<StudentViewModel>> GetStudentsByPages(int page, int limit);
  }
}