using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ManagementSchool.Data.EF
{
  public class ManageSchoolDBContextFactory : IDesignTimeDbContextFactory<ManageSchoolDBContext>
  {

      public ManageSchoolDBContext CreateDbContext(string[] args) {
        var connectString =  "Server=.;Database=ManagementSchool;Trusted_Connection=True;";
        var optionBuilder = new DbContextOptionsBuilder<ManageSchoolDBContext>();
        optionBuilder.UseSqlServer(connectString);
      
        return new ManageSchoolDBContext(optionBuilder.Options);
      }
  }
}