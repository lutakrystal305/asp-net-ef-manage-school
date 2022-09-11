using System;
using System.Text;
using System.Collections.Generic;
using ManagementSchool.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementSchool.Data.Configurations
{
  class OfficerConfiguration : IEntityTypeConfiguration<Officer>
  {
    public void Configure(EntityTypeBuilder<Officer> builder) {
      builder.ToTable("Officers");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).UseIdentityColumn();

      builder.HasOne(x => x.Class).WithMany(x => x.Officers).HasForeignKey(x => x.ClassId);
      //builder.HasOne(x => x.School).WithMany(x => x.Officers).HasForeignKey(x => x.SchoolId);
    }
    
  }
}