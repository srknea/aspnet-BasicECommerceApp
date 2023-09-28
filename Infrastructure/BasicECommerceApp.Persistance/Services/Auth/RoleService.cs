using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Services.Auth;
using BasicECommerceApp.Domain.Entities.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Persistance.Services.Auth
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<CustomResponseDto<NoContentDto>> CreateUserRoles(string userName)
        {
            if (!await _roleManager.RoleExistsAsync("admin"))
            {
                // admin ve manager rolünü oluşturma
                await _roleManager.CreateAsync(new AppRole { Name = "admin" });
            }

            if (!await _roleManager.RoleExistsAsync("manager"))
            {
                // manager rolünü oluşturma
                await _roleManager.CreateAsync(new AppRole { Name = "manager" });
            }

            // İlgili kullanıcıya admin ve manager rolünü ekleme
            var user = await _userManager.FindByNameAsync(userName); // Kullanıcıyı bul
            await _userManager.AddToRoleAsync(user, "admin");
            await _userManager.AddToRoleAsync(user, "manager");

            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status201Created);
        }
    }
}
