using App.Core.Dtos;
using Domain.ReponseModel;


namespace Infra.Repository.Interface
{
    public interface IStaffRepository
    {
        Task<JsonModel> RegisterStaffAsync(StaffRegistrationDto registerDto);
        Task<JsonModel> VerifyOtpAsync(VerifyOtpDto verifyOtpDto);
        Task<JsonModel> LoginStaffAsync(LoginDto loginDto);
        Task<StaffRegistrationDto> GetStaffByIdAsync(int staffId);
        Task<List<StaffRegistrationDto>> GetAllStaffAsync();
        Task<JsonModel> ForgotPasswordAsync(ForgotPasswordDto forgotPassword);
    }
}
