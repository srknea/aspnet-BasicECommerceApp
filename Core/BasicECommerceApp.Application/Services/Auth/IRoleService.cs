using BasicECommerceApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Services.Auth
{
    public interface IRoleService
    {
        Task<CustomResponseDto<NoContentDto>> CreateUserRoles(string userName);
    }
}
