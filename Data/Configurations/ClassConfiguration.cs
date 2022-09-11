using System;
using System.Text;
using System.Collections.Generic;
using ManagementSchool.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace ManagementSchool.Data.Configurations
{
  class ClassConfiguration : IEntityTypeConfiguration<Class>
  {
    public void Configure(EntityTypeBuilder<Class> builder) {
      builder.ToTable("Classes");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).UseIdentityColumn();

      builder.HasOne(x => x.School).WithMany(y => y.Classes).HasForeignKey(x => x.SchoolId);
      //builder.HasOne(x => x.Teacher).WithOne(y => y.Class).HasForeignKey(x => x.OfficerId);
    }
    
  }
}