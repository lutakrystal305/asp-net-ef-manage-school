using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ManagementSchool.Data.EF;
using ManagementSchool.Data.Entities;
using ManagementSchool.ViewModel.Request.Schools;
using ManagementSchool.ViewModel.Response;
using ManagementSchool.Utilities.Exceptions;

namespace ManagementSchool.Services.Schools
{
 public class SchoolService : ISchoolService
 {
    private readonly ManageSchoolDBContext _context;

    public SchoolService(ManageSchoolDBContext context) {
      _context = context;
    }

    public async Task<List<SchoolViewModel>> GetAll() {
      //var allSchool = await _context.Schools.ToListAsync();
      return await _context.Schools.Select(x => new SchoolViewModel(){
        Id = x.Id,
        Name = x.Name,
        Address = x.Address,
        Classes = x.Classes,
      }).ToListAsync();
    }

    public async Task<SchoolViewModel> GetById(int id) {
      var school = await _context.Schools.FindAsync(id);
      if (school == null) throw new ManageSchoolException("School not found");
      var cls = await _context.Classes.Where(x => x.SchoolId == id).ToListAsync();
      return new SchoolViewModel() {
        Id = school.Id,
        Name = school.Name,
        Address = school.Address,
        Classes = cls,
      };
    }
    public async Task<bool> CreateSchool(CreateSchoolRequest req) {
      var schl = new School() {
        Name = req.Name,
        Address = req.Address,
      };
      _context.Schools.Add(schl);
      await _context.SaveChangesAsync();
      return true;
    }
    public async Task<bool> UpdateSchool(UpdateSchoolRequest req) {
      var school = await _context.Schools.FindAsync(req.Id);
      if (school == null) throw new ManageSchoolException("School not found");
      return true;
    }
    public async Task<bool> DeleteSchool(int schoolId) {
      var school = await _context.Schools.FindAsync(schoolId);
      if (school == null) throw new ManageSchoolException("School not found");
      _context.Schools.Remove(school);
      return true;
    }
    public async Task<List<SchoolViewModel>> SearchSchoolByName(string queryName) {
      var schools = _context.Schools.Where(x => x.Name.Contains(queryName));
      return await schools.Select(x => new SchoolViewModel(){
        Id = x.Id,
        Name = x.Name,
        Address = x.Address,
        Classes = x.Classes,
      }).ToListAsync();
    }
 } 
}