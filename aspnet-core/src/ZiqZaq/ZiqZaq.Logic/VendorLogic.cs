using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZiqZaq.Data.EntityFramework.Contexts;
using ZiqZaq.Logic.Infrastructure;
using ZiqZaq.Shared.Models.Entities;
using ZiqZaq.Shared.Models.RequestInputModels;
using ZiqZaq.Shared.Models.RequestOutputModels;

namespace ZiqZaq.Logic
{
    public class VendorLogic : IVendorLogic
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ZiqZaqDbContext _dbContext;

        private readonly IMapper _mapper;

        public VendorLogic(UserManager<ApplicationUser> userManager, ZiqZaqDbContext dbContext,
            IMapper mapper)
        {
            _userManager = userManager;
            _dbContext = dbContext;

            _mapper = mapper;
        }

        public async Task<VendorGetOutputModel> GetByIdAsync(int id)
        {
            var vendor = await _dbContext.Vendors.SingleOrDefaultAsync(p => p.Id == id);

            if (vendor == null)
                throw new ArgumentException();

            var outputModel = _mapper.Map<Vendor, VendorGetOutputModel>(vendor);

            return outputModel;
        }

        public async Task<VendorLoginOutputModel> LoginAsync(VendorLoginInputModel model)
        {
            var vendor = await _dbContext.Vendors.SingleOrDefaultAsync(p => p.ApplicationUser.PhoneNumber == model.PhoneNumber);

            if (vendor == null)
                throw new ArgumentException();

            //var accessToken = CreateAccessToken(user);

            var outputModel = _mapper.Map<Vendor, VendorLoginOutputModel>(vendor);

            return outputModel;
        }

        public async Task CreateAsync(VendorCreateInputModel model)
        {
            var isPhoneAlreadyRegistered = await _userManager.Users.AnyAsync(p => p.PhoneNumber == model.PhoneNumber);

            if (isPhoneAlreadyRegistered)
                throw new DuplicateNameException("This user has already been registered");

            var user = _mapper.Map<ApplicationUser>(model);
            user.UserName = model.PhoneNumber; //TODO: must change

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                throw new ApplicationException(result.Errors.FirstOrDefault()?.Description);

            var entity = _mapper.Map<Vendor>(model);
            entity.UserId = user.Id;

            _dbContext.Vendors.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, VendorUpdateInputModel model)
        {
            var vendor = await _dbContext.Vendors.SingleOrDefaultAsync(p => p.Id == id);

            if (vendor == null)
                throw new ArgumentException();

            var entity = _mapper.Map(model, vendor);

            _dbContext.Vendors.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var vendor = await _dbContext.Vendors.SingleOrDefaultAsync(p => p.Id == id);

            if (vendor == null)
                throw new ArgumentException();

            vendor.ApplicationUser.IsActive = false;

            _dbContext.Vendors.Update(vendor);
            await _dbContext.SaveChangesAsync();
        }
    }
}