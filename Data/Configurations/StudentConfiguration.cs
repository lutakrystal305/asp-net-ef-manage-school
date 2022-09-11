using System;
using System.Text;
using System.Collections.Generic;
using ManagementSchool.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementSchool.Data.Configurations
{
  class StudentConfiguration : IEntityTypeConfiguration<Student>
  {
    public void Configure(EntityTypeBuilder<Student> builder) {
      builder.ToTable("Students");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).UseIdentityColumn();

      //builder.HasOne(x => x.School).WithMany(y => y.Students).HasForeignKey(x => x.SchoolId);
      builder.HasOne(x => x.Class).WithMany(y => y.Students).HasForeignKey(x => x.ClassId);
    }
    
  }
}