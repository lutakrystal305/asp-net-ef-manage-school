using ManagementSchool.Data.Configurations;
using ManagementSchool.Data.Entities;
using ManagementSchool.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace ManagementSchool.Data.EF
{
  public class ManageSchoolDBContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
  {
    public ManageSchoolDBContext(DbContextOptions options): base(options)
    {

    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfiguration(new SchoolConfiguration());
      modelBuilder.ApplyConfiguration(new ClassConfiguration());
      modelBuilder.ApplyConfiguration(new OfficerConfiguration());
      modelBuilder.ApplyConfiguration(new StudentConfiguration());

      modelBuilder.ApplyConfiguration(new AppUserConfiguration());

      modelBuilder.Entity<IdentityUser<Guid>>().ToTable("AppUser");
      modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
      modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
      modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);  
      modelBuilder.Entity<IdentityUserToken<Guid>>(b =>
    {
        b.ToTable("MyUserTokens");
    });


      modelBuilder.Seed();
    }
    public DbSet<School> Schools { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Officer> Officers { get; set; }
    public DbSet<Student> Students { get; set; }
  }
}