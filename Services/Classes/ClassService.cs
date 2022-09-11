using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using ManagementSchool.Data.EF;
using ManagementSchool.Data.Entities;
using ManagementSchool.ViewModel.Request.Classes;
using ManagementSchool.ViewModel.Response;
using ManagementSchool.Utilities.Exceptions;

namespace ManagementSchool.Services.Classes
{
 public class ClassService : IClassService
 {
    private readonly ManageSchoolDBContext _context;
    public ClassService(ManageSchoolDBContext context) {
      _context = context;
    }

    public async Task<List<ClassViewModel>> GetAll() {
      //var allClass = await _context.Classes.ToListAsync();
      return await _context.Classes.Select(x => new ClassViewModel() {
        Id = x.Id,
        Name = x.Name,
        School = x.School,
        Officers = x.Officers,
        Students = x.Students,
      }).ToListAsync();
    }

    public async Task<ClassViewModel?> GetById(int ClassId) {
      var cls = await _context.Classes.FindAsync(ClassId);
      if (cls == null) throw new ManageSchoolException("Class not found");
      var stds = await _context.Students.Where(x => x.ClassId == ClassId).ToListAsync();
      var ofs = await _context.Officers.Where(x => x.ClassId == ClassId).ToListAsync();
      return cls != null ? new ClassViewModel() {
        Id = cls.Id,
        Name = cls.Name,
        School = cls.School,
        Officers = ofs,
        Students = stds,
      } : null;
    }

    public async Task<List<ClassViewModel>> GetClassBySchool(int SchoolId) {
      var listClass = from cls in _context.Classes
                      where cls.SchoolId == SchoolId
                      select cls;
      if (listClass.ToList().Count() == 0) throw new ManageSchoolException("Classes not found");
      return await listClass.Select(x => new ClassViewModel() {
        Id = x.Id,
        Name = x.Name,
        School = x.School,
        Officers = x.Officers,
        Students = x.Students,
      }).ToListAsync();
    }

    public async Task<bool> CreateClass(CreateClassRequest req) {
      var cls = new Class() {
        Name = req.Name,
        SchoolId = req.SchoolId,
      };
      _context.Classes.Add(cls);
      await _context.SaveChangesAsync();
      return true;
    }

    public async Task<bool> UpdateClass(UpdateClassRequest req) {
      var cls = await _context.Classes.FindAsync(req.Id);
      if (cls == null) throw new ManageSchoolException("Class not found");
      return true;
    }

    public async Task<bool> DeleteClass(int ClassId) {
      var cls = await _context.Classes.FindAsync(ClassId); 
      if (cls == null) throw new ManageSchoolException("Class not found");
      _context.Classes.Remove(cls);
      return true;
    }
    
    public async Task<List<ClassViewModel>> SearchClassByName(string queryName) {
      var listClass = _context.Classes.Where(x => x.Name.Contains(queryName));
      return await listClass.Select(x => new ClassViewModel() {
        Id = x.Id,
        Name = x.Name,
        School = x.School,
        Officers = x.Officers,
        Students = x.Students,
      }).ToListAsync();
    }
  } 
}