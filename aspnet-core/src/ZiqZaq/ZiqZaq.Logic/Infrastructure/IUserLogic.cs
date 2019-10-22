using System.Threading.Tasks;
using ZiqZaq.Shared.Models.RequestInputModels;
using ZiqZaq.Shared.Models.RequestOutputModels;

namespace ZiqZaq.Logic.Infrastructure
{
    public interface IUserLogic
    {
        Task<UserGetOutputModel> GetByIdAsync(string id);
        Task<UserGetByPhoneNumberOutputModel> GetByPhoneNumberAsync(string phoneNumber);
        Task<UserLoginOutputModel> LoginAsync(UserLoginInputModel model);
        Task<UserRegisterOutputModel> RegisterAsync(UserRegisterInputModel model);
        Task UpdateAsync(string id, UserUpdateInputModel model);
        Task DeleteAsync(string id);
    }
}