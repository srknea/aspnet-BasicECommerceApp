﻿using BasicECommerceApp.Application.Configurations.Auth;
using BasicECommerceApp.Application.DTOs.Auth;
using BasicECommerceApp.Application.Services.Auth;
using BasicECommerceApp.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Persistance.Services.Auth
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly CustomTokenOption _tokenOption;

        public TokenService(UserManager<AppUser> userManager, IOptions<CustomTokenOption> options)
        {
            _userManager = userManager;
            _tokenOption = options.Value;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];

            using var rnd = RandomNumberGenerator.Create();

            rnd.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }

        // Üyelik sistemi gerektiren bir token oluşturmak istediğimizde PAYLOAD'ı dolduracak
        private async Task<IEnumerable<Claim>> GetClaims(AppUser userApp, List<string> audiences)
        {
            var userRoles = await _userManager.GetRolesAsync(userApp); // Kullanıcı rollerini çekiyoruz. Örn: admin, manager
            // List<string> <-------> ["admin","manager"]

            var userList = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier,userApp.Id),
            new Claim(JwtRegisteredClaimNames.Email, userApp.Email),
            new Claim(ClaimTypes.Name,userApp.UserName),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            userList.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x))); // Kullanıcı rollerini ClaimTypes.Role ile Payload'a ekliyoruz

            return userList;
        }

        // Üyelik sistemi gerektirmeyen bir token oluşturmek istediğimizde PAYLOAD'ı dolduracak
        private IEnumerable<Claim> GetClaimsByClient(Client client)
        {
            var claims = new List<Claim>();
            claims.AddRange(client.Audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());
            new Claim(JwtRegisteredClaimNames.Sub, client.Id.ToString()); // Sub: Subject ---> Bu token kime ait

            return claims;
        }

        // Token oluşturmak için kullanacağımız metot
        public async Task<TokenDto> CreateTokenAsync(AppUser userApp)
        {
            var accessTokenExpiration = DateTime.UtcNow.AddMinutes(_tokenOption.AccessTokenExpiration); // Token'ın ömrü
            var refreshTokenExpiration = DateTime.UtcNow.AddMinutes(_tokenOption.RefreshTokenExpiration);
            var securityKey = SignService.GetSymmetricSecurityKey(_tokenOption.SecurityKey); // Token'ı imzalayacak olan key

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature); // Token'ı imzalayacak olan algoritma. HEADER kısmında şu şekilde belirtilecek ---> alg:HS256

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOption.Issuer,
                expires: accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                claims: await GetClaims(userApp, _tokenOption.Audience),
                signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler(); // Token'ı oluşturacak olan nesne

            var token = handler.WriteToken(jwtSecurityToken); // Token'ı oluşturuyoruz

            var tokenDto = new TokenDto
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpiration = accessTokenExpiration,
                RefreshTokenExpiration = refreshTokenExpiration
            };

            return tokenDto;
        }

        // Üyelik sistemi gerektirmeyen Client'lar için token oluşturacağımız method
        public ClientTokenDto CreateTokenByClient(Client client)
        {
            var accessTokenExpiration = DateTime.UtcNow.AddMinutes(_tokenOption.AccessTokenExpiration);

            var securityKey = SignService.GetSymmetricSecurityKey(_tokenOption.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOption.Issuer,
                expires: accessTokenExpiration,
                 notBefore: DateTime.UtcNow,
                 claims: GetClaimsByClient(client),
                 signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new ClientTokenDto
            {
                AccessToken = token,

                AccessTokenExpiration = accessTokenExpiration,
            };

            return tokenDto;
        }
    }
}
