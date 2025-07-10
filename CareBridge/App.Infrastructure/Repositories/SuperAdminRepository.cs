using App.Application.DTOs;
using App.Application.Interfaces;
using App.Application.Interfaces.DbContext;
using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;
using App.Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{
    public class SuperAdminRepository : ISuperAdminRepository
    {
        private readonly IMasterDbContext _context;
        private readonly ILogger<SuperAdminRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public SuperAdminRepository(IMasterDbContext context, ILogger<SuperAdminRepository> logger, IConfiguration configuration, IEmailService emailService)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
            _emailService = emailService;
        }
        public async Task<JsonResponseDto> SuperAdminLogin(SuperAdminDto superAdminDto)
        {
            try
            {
                var checkuser = await _context.Set<SuperAdmin>().FirstOrDefaultAsync(x => x.Email == superAdminDto.Email);

                if (checkuser == null)
                {
                    _logger.LogWarning("User not found.");
                    return new JsonResponseDto(404, "User not found.", null);
                }
                if (checkuser.Password != superAdminDto.Password)
                {
                    _logger.LogError("Invalid username or password.");
                    return new JsonResponseDto(404, "Invalid username or password.", null);
                }
                return new JsonResponseDto(200, "Login Successfully", checkuser.Adapt<SuperAdminDto>());
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while logging in.");
            }
        }

        public async Task<JsonResponseDto> VerifySuperAdmin(VerifySuperAdminDto verifySuperAdmin)
        {
            try
            {
                var otp = await _context.Set<Otp>().FirstOrDefaultAsync(x => x.Email == verifySuperAdmin.Email && x.Code == verifySuperAdmin.Otp);

                if (otp == null || otp.Expiration < DateTime.Now)
                {
                    _logger.LogError("Invalid or expired OTP.");
                    throw new Exception("Invalid or expired OTP.");
                }
                var superAdmin = await _context.Set<SuperAdmin>().FirstOrDefaultAsync(x => x.Email == verifySuperAdmin.Email);
                if (superAdmin == null)
                {
                    _logger.LogError("SuperAdmin not found.");
                    return new JsonResponseDto(404, "SuperAdmin not found.", null);
                }
                var claim = new[]
               {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("SuperAdminId", superAdmin.Id.ToString()),
                new Claim("Email", superAdmin.Email),
                new Claim(ClaimTypes.Role,"SuperAdmin")
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claim,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signIn);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                _logger.LogInformation("OTP Verified Successfully.");
                return new JsonResponseDto(200, "OTP Verified Successfully", jwt);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while verify otp.");
                return new JsonResponseDto(500, "Internal Server Error", null);
            }
        }
    }
}
