﻿using BasicECommerceApp.Application.DTOs.Auth;
using BasicECommerceApp.Application.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicECommerceApp.API.Controllers.Auth
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return CreateActionResult(await _userService.CreateUserAsync(createUserDto));
        }

        [Authorize] // Bu endpoint e erişmek için token gerekli
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return CreateActionResult(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        }
    }
}
