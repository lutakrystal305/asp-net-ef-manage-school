using Microsoft.AspNetCore.Identity;
using ManagementSchool.Services.Schools;
using ManagementSchool.Services.Classes;
using ManagementSchool.Services.Officers;
using ManagementSchool.Services.Students;
using ManagementSchool.Data.Entities;
using ManagementSchool.Data.EF;
using Microsoft.EntityFrameworkCore;
using ManagementSchool.Services.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ManagementSchool.Services.Tokens;
using Microsoft.Extensions.Configuration;

// Build a config object, using env vars and JSON providers.
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ManageSchoolDBContext>(options =>
    options.UseSqlServer("Server=.;Database=ManagementSchool;Trusted_Connection=True;"));

builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ManageSchoolDBContext>();

builder.Services.AddTransient<ISchoolService, SchoolService>();
builder.Services.AddTransient<IClassService, ClassService>();
builder.Services.AddTransient<IOfficerService, OfficerService>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();



builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string issuer =  config["Jwt:Issuer"]; //https://localhost:5001";
string signingKey =  config["Jwt:Key"]; //"robben, kante, ziyech, alves, cancelo, pobba, mbappe, neymar, raphinha";
byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

builder.Services.AddAuthentication(opt => { 
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = issuer,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = System.TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger managementSchool V1");
    });
}

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
