using System.Threading.Tasks;
using ZiqZaq.Shared.Models.RequestInputModels;
using ZiqZaq.Shared.Models.RequestOutputModels;

namespace ZiqZaq.Logic.Infrastructure
{
    public interface ITourLogic
    {
        Task<TourGetOutputModel> GetByIdAsync(int id);
        Task CreateAsync(TourCreateInputModel model);
        Task UpdateAsync(int id, TourUpdateInputModel model);
        Task DeleteAsync(int id);
    }
}