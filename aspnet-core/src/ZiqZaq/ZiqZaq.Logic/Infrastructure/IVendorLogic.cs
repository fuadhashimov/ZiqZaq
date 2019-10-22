using System.Threading.Tasks;
using ZiqZaq.Shared.Models.RequestInputModels;
using ZiqZaq.Shared.Models.RequestOutputModels;

namespace ZiqZaq.Logic.Infrastructure
{
    public interface IVendorLogic
    {
        Task<VendorGetOutputModel> GetByIdAsync(int id);
        Task<VendorLoginOutputModel> LoginAsync(VendorLoginInputModel model);
        Task CreateAsync(VendorCreateInputModel model);
        Task UpdateAsync(int id, VendorUpdateInputModel model);
        Task DeleteAsync(int id);
    }
}