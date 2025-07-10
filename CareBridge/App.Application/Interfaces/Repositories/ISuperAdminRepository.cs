using App.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces.Repositories
{
    public interface ISuperAdminRepository
    {
        Task<JsonResponseDto> SuperAdminLogin(SuperAdminDto superAdminDto);
        Task<JsonResponseDto> VerifySuperAdmin(VerifySuperAdminDto verifySuperAdmin);
    }
}
