using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ManagementSchool.Data.EF;
using ManagementSchool.Data.Entities;
using ManagementSchool.ViewModel.Request.Students;
using ManagementSchool.ViewModel.Response;
using ManagementSchool.Utilities.Exceptions;

namespace ManagementSchool.Services.Students
{
 public class StudentService : IStudentService
 {
    private readonly ManageSchoolDBContext _context;
    public StudentService(ManageSchoolDBContext context) {
      _context = context;
    }
    public async Task<List<StudentViewModel>> GetAll() {
      //var allStudent = await _context.Students.FindAsync();
      return await _context.Students.Select(x => new StudentViewModel() {
        Id = x.Id,
        Name = x.Name,
        Age = x.Age,
        Address = x.Address,
        Class = x.Class
      }).ToListAsync();
    }
    public async Task<StudentViewModel> GetById(int id) {
      var student = await _context.Students.FindAsync(id);
      if (student == null) throw new ManageSchoolException("Student not found");
      Console.WriteLine(student);
      var cls = await _context.Classes.FindAsync(student.ClassId);
      return new StudentViewModel() {
        Id = student.Id,
        Name = student.Name,  
        Age = student.Age,
        Address = student.Address,
        Class = cls
      };
    }
    public async Task<List<StudentViewModel>> GetStudentByClass(int ClassId) {
      var listStudent = from std in _context.Students
                        where std.ClassId == ClassId
                        select std;
      return await listStudent.Select(x => new StudentViewModel() {
        Id = x.Id,
        Name = x.Name,
        Age = x.Age,
        Address = x.Address,
        Class = x.Class
      }).ToListAsync();
    }
    public async Task<bool> CreateStudent(CreateStudentRequest req) {
      var std = new Student() {
        Name = req.Name,
        Age = req.Age,
        Address = req.Address,
        ClassId = req.ClassId,
      };
      _context.Students.Add(std);
      await _context.SaveChangesAsync();
      return true;
    }
    public async Task<bool> UpdateStudent(UpdateStudentRequest req) {
      var student = await _context.Students.FindAsync(req.Id);
      if (student == null) throw new ManageSchoolException("Student not found");
      return true;
    }
    public async Task<bool> UpdateClassByStudent(int studentId, int classId) {
      var student = await _context.Students.FindAsync(studentId);
      if (student == null) throw new ManageSchoolException("Student not found");
      student.ClassId = classId;
      return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> DeleteStudent(int StudentId) {
      var student = await _context.Students.FindAsync(StudentId);
      if (student == null) throw new ManageSchoolException("Student not found");
      _context.Students.Remove(student);
      return true;
    }
    public async Task<List<StudentViewModel>> SearchStudentByName(string queryName) {
      var listStudent = _context.Students.Where(x => x.Name.Contains(queryName));
      return await listStudent.Select(x => new StudentViewModel() {
        Id = x.Id,
        Name = x.Name,
        Age = x.Age,
        Address = x.Address,
        Class = x.Class
      }).ToListAsync();
    }
    public async Task<List<StudentViewModel>> GetStudentsByPages(int page, int limit) {
      
      return await _context.Students.Skip((page - 1)*limit).Take(limit).Select(x => new StudentViewModel() {
        Id = x.Id,
        Name = x.Name,
        Age = x.Age,
        Address = x.Address,
        Class = x.Class
      }).ToListAsync();
    }
 } 
}