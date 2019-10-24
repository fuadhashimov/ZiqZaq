using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZiqZaq.Data.EntityFramework.Contexts;
using ZiqZaq.Logic.Infrastructure;
using ZiqZaq.Shared.Models.Entities;
using ZiqZaq.Shared.Models.RequestInputModels;
using ZiqZaq.Shared.Models.RequestOutputModels;

namespace ZiqZaq.Logic
{
    public class TourLogic : ITourLogic
    {
        private readonly ZiqZaqDbContext _dbContext;
        private readonly IMapper _mapper;

        public TourLogic(ZiqZaqDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TourGetOutputModel> GetByIdAsync(int id)
        {
            var tour = await _dbContext.Tours.SingleOrDefaultAsync(p => p.Id == id);

            if (tour == null)
                throw new ArgumentException();

            var output = _mapper.Map<Tour, TourGetOutputModel>(tour);

            return output;
        }

        public async Task CreateAsync(TourCreateInputModel model)
        {
            var entity = _mapper.Map<Tour>(model);

            _dbContext.Tours.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, TourUpdateInputModel model)
        {
            var tour = await _dbContext.Tours.SingleOrDefaultAsync(p => p.Id == id);

            if (tour == null)
                throw new ArgumentException();

            var entity = _mapper.Map(model, tour);

            _dbContext.Tours.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tour = await _dbContext.Tours.SingleOrDefaultAsync(p => p.Id == id);

            if (tour == null)
                throw new ArgumentException();

            tour.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
        }
    }
}