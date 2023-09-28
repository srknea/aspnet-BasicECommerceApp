using BasicECommerceApp.Application.Configurations.Auth;
using BasicECommerceApp.Application.DTOs.Auth;
using BasicECommerceApp.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Services.Auth
{
    public interface ITokenService
    {
        Task<TokenDto> CreateTokenAsync(AppUser userApp);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}
