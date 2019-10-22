using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ZiqZaq.Logic.Infrastructure;
using ZiqZaq.Shared.Models.RequestInputModels;
using ZiqZaq.Web.Core.Helper;

namespace ZiqZaq.Web.Core.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic, IOptions<AppSettings> appSettings)
        {
            _userLogic = userLogic;

            _appSettings = appSettings.Value;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _userLogic.GetByIdAsync(id));
        }

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetByPhoneNumber(string phoneNumber)
        {
            return Ok(await _userLogic.GetByPhoneNumberAsync(phoneNumber));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserLoginInputModel model)
        {
            return Ok(await _userLogic.LoginAsync(model));
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterInputModel model)
        {
            return Ok(await _userLogic.RegisterAsync(model));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UserUpdateInputModel model)
        {
            await _userLogic.UpdateAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userLogic.DeleteAsync(id);
            return Ok();
        }
    }
}