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
using ManagementSchool.ViewModel.Request.Officers;
using ManagementSchool.ViewModel.Response;
using ManagementSchool.Utilities.Exceptions;

namespace ManagementSchool.Services.Officers
{
 public class OfficerService : IOfficerService
 {
    private readonly ManageSchoolDBContext _context;
    public OfficerService(ManageSchoolDBContext context) {
      _context = context;
    }
    public async Task<List<OfficerViewModel>> GetAll() {
      //var allOfficer = await _context.Officers.ToListAsync();
      return await _context.Officers.Select(x => new OfficerViewModel() {
        Id = x.Id,
        Name = x.Name,
        Major = x.Major,
        Class = x.Class
      }).ToListAsync();
    }
    public async Task<OfficerViewModel> GetById(int officerId) {
      var officer = await _context.Officers.FindAsync(officerId);
      if (officer == null) throw new ManageSchoolException("Officer not found");
      Console.WriteLine(officer.Class);
      var cls = await _context.Classes.FindAsync(officer.ClassId);
      return new OfficerViewModel() {
        Id = officer.Id,
        Name = officer.Name,
        Major = officer.Major,
        Class = cls,
      };
    }
    public async Task<List<OfficerViewModel>> GetOfficerByClass(int ClassId) {
      var listOfficer = from of in _context.Officers
                        where of.ClassId == ClassId
                        select of;
      if (listOfficer.ToList().Count() == 0) throw new ManageSchoolException("Officers not found"); 
      return await listOfficer.Select(x => new OfficerViewModel(){
        Id = x.Id,
        Name = x.Name,
        Major = x.Major,
        Class = x.Class,
      }).ToListAsync();
    }
    public async Task<bool> CreateOfficer(CreateOfficerRequest req) {
      var of = new Officer() {
        Name = req.Name,
        Major = req.Major
      };
      _context.Officers.Add(of);
      await _context.SaveChangesAsync();
      return true;
    }
    public async Task<bool> UpdateOfficer(UpdateOfficerRequest req) {
      var officer = await _context.Officers.FindAsync(req.Id);
      if (officer == null) throw new ManageSchoolException("Officer not found");
      return true;
    }
    public async Task<bool> UpdateClassByOfficer(int officerId, int classId) {
      var officer = await _context.Officers.FindAsync(officerId);
      if (officer == null) throw new ManageSchoolException("Officer not found");
      officer.ClassId = classId;
      return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> DeleteOfficer(int OfficerId) {
      var officer = await _context.Officers.FindAsync(OfficerId);
      if (officer == null) throw new ManageSchoolException("Officer not found");
      _context.Officers.Remove(officer);
      return true;
    } 
    public async Task<List<OfficerViewModel>> SearchOfficerByName(string queryName) {
      var listOfficer = _context.Officers.Where(x => x.Name.Contains(queryName)); 
      return await listOfficer.Select(x => new OfficerViewModel(){
        Id = x.Id,
        Name = x.Name,
        Major = x.Major,
        Class = x.Class,
      }).ToListAsync();
    }
 } 
}