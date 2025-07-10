using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class SuperAdminService : ISuperAdminService
    {
        private readonly ISuperAdminRepository _superAdminRepository;

        public SuperAdminService(ISuperAdminRepository superAdminRepository)
        {
            _superAdminRepository = superAdminRepository;
        }

        public Task<JsonResponseDto> SuperAdminLogin(SuperAdminDto superAdminDto)
        {
            try
            {
                return _superAdminRepository.SuperAdminLogin(superAdminDto);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while processing the SuperAdmin login.", ex);
            }

        }

        public Task<JsonResponseDto> VerifySuperAdmin(VerifySuperAdminDto verifySuperAdmin)
        {
            try
            {
                return _superAdminRepository.VerifySuperAdmin(verifySuperAdmin);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("An error occurred while verifying the SuperAdmin.", ex);
            }
        }

    }
}
