using App.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces.Services
{
    public class SuperAdminService : ISuperAdminService
    {
        public Task<JsonResponseDto> SuperAdminLogin(SuperAdminDto superAdminDto)
        {
            throw new NotImplementedException();
        }

        public Task<JsonResponseDto> VerifySuperAdmin(VerifySuperAdminDto verifySuperAdmin)
        {
            throw new NotImplementedException();
        }
    }
}
