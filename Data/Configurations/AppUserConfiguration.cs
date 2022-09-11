using ManagementSchool.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Text;
using System.Collections.Generic;

namespace ManagementSchool.Data.Configurations
{
  class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
  {
    public void Configure(EntityTypeBuilder<AppUser> builder) {
      builder.ToTable("AppUsers");
      builder.Property(x => x.Name).IsRequired();
    }
  }
}