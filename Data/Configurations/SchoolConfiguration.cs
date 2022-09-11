using System;
using System.Text;
using System.Collections.Generic;
using ManagementSchool.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementSchool.Data.Configurations
{
  class SchoolConfiguration : IEntityTypeConfiguration<School>
  {
    public void Configure(EntityTypeBuilder<School> builder) {
      builder.ToTable("Schools");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).UseIdentityColumn();

    }
    
  }
}