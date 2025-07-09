using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App.Application.DTOs;
using App.Application.Interfaces.Repositories;
using App.Application.Interfaces.Services;
using App.Domain.Entities;
using App.Infrastructure.DBContext;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PasswordGenerator;

namespace App.Infrastructure.Repositories
{
    public class StaffRepository : IStaffRepository
    {

        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<StaffRepository> _logger;
        public StaffRepository(AppDbContext context, IEmailService emailService, IConfiguration configuration,
            ILogger<StaffRepository> logger)
        {
            _context = context;
            _emailService = emailService;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<JsonResponseDto> ForgotPasswordAsync(ForgotPasswordDto forgotPassword)
        {
            try
            {
                var checkUser = await _context.Staff.Where(a => a.Email == forgotPassword.Email && a.IsActive == true && a.IsDeleted == false).FirstOrDefaultAsync();
                if (checkUser == null)
                {
                    _logger.LogError("User not found.");
                    throw new Exception("User not found.");
                }
                var passwordGenerator = new Password(true, true, true, true, 13);
                string password = passwordGenerator.Next();
                password = password.Replace("\\", "");
                password = $"{password}#";
                var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                checkUser.Password = encryptedPassword;
                _context.Staff.Update(checkUser);
                _context.SaveChanges();
                await _emailService.SendEmailAsync(checkUser.Email, "Password Reset", $"Your new password is: {password}");
                _logger.LogInformation("Password Reset Successfully.");
                return new JsonResponseDto(200, "Password Reset Successfully", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ForgotPasswordAsync");
                throw new Exception("An error occurred while processing your request.");
            }
        }

        public async Task<List<StaffRegistrationDto>> GetAllStaffAsync()
        {
            try
            {
                var getAllStaff = await _context.Staff.ToListAsync();

                if (getAllStaff == null || !getAllStaff.Any())
                {
                    _logger.LogError("No Staff Found.");
                    throw new Exception("No Staff Found.");
                }
                _logger.LogInformation("Retrived list of Staff.");
                return getAllStaff.Adapt<List<StaffRegistrationDto>>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllStaffAsync");
                throw new Exception("An error occurred while fetching staff data.");
            }
        }

        public async Task<StaffRegistrationDto> GetStaffByIdAsync(int staffId)
        {
            try
            {
                var checkStaff = await _context.Staff.FirstOrDefaultAsync(a => a.Id == staffId && a.IsActive == true && a.IsDeleted == false && a.RoleId == 1);

                if (checkStaff == null)
                {
                    _logger.LogError("Staff not found.");
                    throw new Exception("Staff not found.");
                }
                _logger.LogInformation("Retrived Staff.");
                return (checkStaff.Adapt<StaffRegistrationDto>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetStaffByIdAsync");
                throw new Exception("An error occurred while fetching staff data.");
            }
        }

        public async Task<JsonResponseDto> LoginStaffAsync(LoginDto loginDto)
        {
            try
            {
                var checkUser = await _context.Staff.FirstOrDefaultAsync(a => a.Username == loginDto.Username && a.IsActive == true && a.IsDeleted == false);
                if (checkUser == null)
                {
                    _logger.LogWarning("User not found.");
                    throw new Exception("User not found.");
                }
                var checkpassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, checkUser.Password);
                if (!checkpassword)
                {
                    _logger.LogError("Invalid username or password.");
                    throw new Exception("Invalid username or password.");
                }
                var otp = new Random().Next(100000, 999999).ToString();
                var existingOtps = await _context.Otp
                .Where(o => o.Username.ToLower() == checkUser.Username.ToLower())
                .ToListAsync();
                if (existingOtps.Any())
                {
                    _context.Otp.RemoveRange(existingOtps);
                }
                _context.Otp.Add(new Otp
                {
                    Email = checkUser.Email,
                    Username = checkUser.Username,
                    Code = otp,
                    Expiration = DateTime.Now.AddMinutes(5)
                });
                await _context.SaveChangesAsync();
                //await _emailService.SendEmailAsync(checkUser.Email, "OTP for login", otp);
                string subject = "Your OTP Verification Code";
                string body = $@"
    <html>
        <body>
            <h2>Hello {checkUser.Username},</h2>
            <p>Thank you for registering with us.</p>
            <p>Your One-Time Password (OTP) is:</p>
            <h1 style='color:blue'>{otp}</h1>
            <p>This OTP is valid for 10 minutes.</p>
            <br />
            <p>Regards,<br/>Blazor Sample App Team</p>
        </body>
    </html>";

                await _emailService.SendEmailAsync(checkUser.Email, subject, body);
                _logger.LogInformation("OTP Sent Successfully.");
                return new JsonResponseDto(200, "OTP Sent Successfully", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in LoginStaffAsync");
                throw new Exception("An error occurred while processing your request.");
            }
        }

        public async Task<JsonResponseDto> RegisterStaffAsync(StaffRegistrationDto registerDto)
        {
            try
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                var checkUserExits = await _context.Staff.Where(x => x.Email == registerDto.Email).FirstOrDefaultAsync();

                if (checkUserExits != null)
                {
                    _logger.LogError("Staff Already Exits.");
                    return new JsonResponseDto(400, "Staff Already Exits", null);
                }

                string formattedDOB = registerDto.DOB.ToString("ddMMyy");
                var userName = $"MV_{textInfo.ToTitleCase(registerDto.FirstName)}{registerDto.LastName.ToUpper()[0]}{formattedDOB}";
                var passwordGenerator = new Password(true, true, true, true, 13);
                string password = passwordGenerator.Next();
                password = password.Replace("\\", "");
                password = $"{password}#";
                var encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                decimal visitingCharge = 0;
                if (registerDto.RoleId == 1)
                {
                    visitingCharge = registerDto.VisitingCharge;
                }
                else
                {
                    visitingCharge = 0;
                }
                var addStaff = new Staff
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Email = registerDto.Email,
                    Username = userName,
                    Password = encryptedPassword,
                    PhoneNo = registerDto.PhoneNo,
                    Gender = registerDto.Gender,
                    RoleId = registerDto.RoleId,
                    Address = registerDto.Address,
                    City = registerDto.City,
                    StateId = registerDto.StateId,
                    CountryId = registerDto.CountryId,
                    Designation = registerDto.Designation,
                    Department = registerDto.Department,
                    VisitingCharge = visitingCharge,
                    JoiningDate = registerDto.JoiningDate,
                    DOB = registerDto.DOB,
                    ProfileImage = string.Empty,
                    CreatedBy = "Doctor",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                };
                await _context.Staff.AddAsync(addStaff);
                await _context.SaveChangesAsync();

                string subject = "Welcome to Blazor Sample App!";
                string body = $@"
    <html>
        <body style='font-family: Arial, sans-serif;'>
            <h2 style='color:#4CAF50;'>Welcome, {addStaff.FirstName}!</h2>
            <p>Thank you for registering with <strong>Blazor Sample App</strong>.</p>

            <p>Your registration details:</p>
            <ul>
                <li><strong>Name:</strong> {addStaff.FirstName} {addStaff.LastName}</li>
                <li><strong>Email:</strong> {addStaff.Email}</li>
                <li><strong>Registered On:</strong> {DateTime.Now.ToString("dd MMM yyyy")}</li>
                <li><strong>Username:</strong> {addStaff.Username}</li>
                <li><strong>Password:</strong> {password}</li>

            </ul>

            <p>We’re excited to have you on board!</p>

            <p>Regards,<br/>Blazor Sample App Team</p>
        </body>
    </html>";

                await _emailService.SendEmailAsync(addStaff.Email, subject, body);
                _logger.LogInformation("Staff Registered Successfully.");
                return new JsonResponseDto(200, "Staff Registered Successfully", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in RegisterStaffAsync");
                throw new Exception("An error occurred while processing your request.");
            }
        }

        public async Task<JsonResponseDto> VerifyOtpAsync(VerifyOtpDto verifyOtpDto)
        {
            try
            {
                var otp = await _context.Otp.FirstOrDefaultAsync(x => x.Username == verifyOtpDto.UserName && x.Code == verifyOtpDto.Otp);
                if (otp == null || otp.Expiration < DateTime.Now)
                {
                    _logger.LogError("Invalid or expired OTP.");
                    throw new Exception("Invalid or expired OTP.");
                }
                var userExist = await _context.Patient.FirstOrDefaultAsync(x => x.Username == verifyOtpDto.UserName);
                var selectrole = _context.Role.FirstOrDefault(a => a.Id == userExist.RoleId);
                var claim = new[]
                 {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("PatientId", userExist.PatientId.ToString()),
                new Claim("Username", userExist.Username),
                new Claim("Email", userExist.Email),
                new Claim(ClaimTypes.Role,selectrole.RoleName)
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
                _logger.LogError(ex, "Error in VerifyOtpAsync");
                throw new Exception("An error occurred while processing your request.");
            }
        }
    }
}
