using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ManagementSchool.ViewModel.Request.Common;
using ManagementSchool.Data.Entities;
using ManagementSchool.Services.Tokens;

namespace ManagementSchool.Services.Common
{
  public class UserService : IUserService
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    public UserService(UserManager<AppUser> userManager,
      SignInManager<AppUser> signInManager, ITokenService tokenService) {
      _userManager = userManager;
      _signInManager = signInManager;
      _tokenService = tokenService;
    }
    public async Task<string> Login(LoginRequest req) {
      var user = await _userManager.FindByEmailAsync(req.Email);
      if (user == null) return "bad";

      var result = await _signInManager.PasswordSignInAsync(user, req.Password, false, false);
      
      return _tokenService.GeneratorToken(user);
    }


    public async Task<bool> Register(RegisterRequest req) {
      var userByName = await _userManager.FindByNameAsync(req.UserName);
      if (userByName != null) {
        return false;
      }
      var userByEmail = await _userManager.FindByEmailAsync(req.Email);
      if (userByEmail != null) {
        return false;
      }
      var user = new AppUser() {
        Email = req.Email,
        Name = req.Name,
        UserName = req.UserName
      };
      var result = await _userManager.CreateAsync(user, req.Password);
      if (result.Succeeded) {
        return true;
      }
      return false;
    }
  }
}