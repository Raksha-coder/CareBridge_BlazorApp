using App.Core.Dtos;
using Domain.ReponseModel;


namespace Infra.Repository.Interface
{
    public interface IStaffRepository
    {
        Task<JsonModel> RegisterStaffAsync(StaffRegistrationDto registerDto);
        Task<JsonModel> LoginStaffAsync(LoginDto loginDto);
        Task<JsonModel> GetStaffByIdAsync(int staffId);
        Task<JsonModel> ForgotPasswordAsync(ForgotPasswordDto forgotPassword);
    }
}
