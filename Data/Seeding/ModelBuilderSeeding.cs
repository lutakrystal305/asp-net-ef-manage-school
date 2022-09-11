using ManagementSchool.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSchool.Data.Seeding
{
  public static class ModelBuilderSeeding
  {
    public static void Seed(this ModelBuilder modelBuilder) {
      modelBuilder.Entity<School>().HasData(       
        new School()
        { Id = 1, Name="Nguyen Hue", Address = "Quang Nam"},
        new School()
        { Id = 2, Name="Nguyen Trai", Address = "Quang Nam"}
      );
      modelBuilder.Entity<Class>().HasData(
        new Class()
        { Id = 3, Name = "1A", SchoolId = 1 },
        new Class()
        { Id = 4, Name = "1B", SchoolId = 1 },
        new Class()
        { Id = 5, Name = "1A", SchoolId = 2 },
        new Class()
        { Id = 6, Name = "1B", SchoolId = 2 }
      );
      modelBuilder.Entity<Officer>().HasData(
        new Officer()
        { Id = 7, Name="Phuong", Major="Math", ClassId=3 },
        new Officer()
        { Id = 8, Name="Hang", Major="Physical", ClassId=3 },
        new Officer()
        { Id = 9, Name="Anh", Major="Chemistry", ClassId=4 }
      );
      modelBuilder.Entity<Student>().HasData(
        new Student()
        { Id=10, Name="Ai", Age=10, Address="DaNang", ClassId=4 },
        new Student()
        { Id=11, Name="Hai", Age=10, Address="DaNang", ClassId=5 },
        new Student()
        { Id=12, Name="Ki",Age=8, Address="DaNang", ClassId=5 },
        new Student()
        { Id=13, Name="Khanh", Age=6, Address="DaNang", ClassId=6 },
        new Student()
        { Id=14, Name="Ha", Age=7, Address="DaNang", ClassId=6 },
        new Student()
        { Id=15, Name="Thu", Age=8, Address="DaNang", ClassId=3 }
      );

      var userId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
      var hasher = new PasswordHasher<AppUser>();
      modelBuilder.Entity<AppUser>().HasData(
        new AppUser() {
          Id = userId,
          UserName = "admin",
          NormalizedUserName = "admin",
          Email = "thaidaik305@gmail.com",
          NormalizedEmail = "thaidaik305@gmail.com",
          EmailConfirmed = true,
          PasswordHash = hasher.HashPassword(null, "Abcd1234@"),
          SecurityStamp = string.Empty,
          Name = "Thai"
        }
      );

    }
  }
}