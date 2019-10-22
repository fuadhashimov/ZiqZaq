using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ZiqZaq.Data.EntityFramework.Contexts;
using ZiqZaq.Logic.Infrastructure;
using ZiqZaq.Shared.Models.Entities;
using ZiqZaq.Shared.Models.RequestInputModels;
using ZiqZaq.Shared.Models.RequestOutputModels;

namespace ZiqZaq.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ZiqZaqDbContext _dbContext;

        private readonly IMapper _mapper;

        public UserLogic(UserManager<ApplicationUser> userManager,
            ZiqZaqDbContext dbContext, IMapper mapper)
        {
            _userManager = userManager;
            _dbContext = dbContext;

            _mapper = mapper;
        }

        public async Task<UserGetOutputModel> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                throw new ArgumentException();

            var outputModel = _mapper.Map<ApplicationUser, UserGetOutputModel>(user);

            return outputModel;
        }

        public async Task<UserGetByPhoneNumberOutputModel> GetByPhoneNumberAsync(string phoneNumber)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(p => p.PhoneNumber == phoneNumber);

            if (user == null)
                throw new ArgumentException();

            var outputModel = _mapper.Map<ApplicationUser, UserGetByPhoneNumberOutputModel>(user);

            return outputModel;
        }

        public async Task<UserLoginOutputModel> LoginAsync(UserLoginInputModel model)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(p => p.PhoneNumber == model.PhoneNumber);

            if (user == null)
                throw new ArgumentException();

            //var accessToken = CreateAccessToken(user);

            var outputModel = _mapper.Map<ApplicationUser, UserLoginOutputModel>(user);

            return outputModel;
        }

        public async Task<UserRegisterOutputModel> RegisterAsync(UserRegisterInputModel model)
        {
            var isPhoneAlreadyRegistered = await _userManager.Users.AnyAsync(p => p.PhoneNumber == model.PhoneNumber);

            if (isPhoneAlreadyRegistered)
                throw new DuplicateNameException("This user has already been registered");

            var entity = _mapper.Map<ApplicationUser>(model);
            entity.UserName = model.PhoneNumber; //TODO: must change

            var result = await _userManager.CreateAsync(entity, model.Password);

            if (!result.Succeeded)
                throw new ApplicationException(result.Errors.FirstOrDefault()?.Description);

            await _dbContext.SaveChangesAsync();

            var outputModel = _mapper.Map<ApplicationUser, UserRegisterOutputModel>(entity);

            return outputModel;
        }

        public async Task UpdateAsync(string id, UserUpdateInputModel model)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null || user.PhoneNumber != model.PhoneNumber)
                throw new ArgumentException();

            var entity = _mapper.Map(model, user);

            await _userManager.UpdateAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                throw new ArgumentException();

            user.IsActive = false;

            await _userManager.UpdateAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        private static string CreateAccessToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("test");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
