﻿using BasicECommerceApp.Application.DTOs.Auth;
using BasicECommerceApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Services.Auth
{
    public interface IAuthenticationService
    {
        Task<CustomResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<CustomResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<CustomResponseDto<NoContentDto>> RevokeRefreshToken(string refreshToken);
        CustomResponseDto<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);
    }
}