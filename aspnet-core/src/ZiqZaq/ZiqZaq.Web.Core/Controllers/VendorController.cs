using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZiqZaq.Logic.Infrastructure;
using ZiqZaq.Shared.Models.RequestInputModels;

namespace ZiqZaq.Web.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorLogic _vendorLogic;

        public VendorController(IVendorLogic vendorLogic)
        {
            _vendorLogic = vendorLogic;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _vendorLogic.GetByIdAsync(id));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]VendorLoginInputModel model)
        {
            return Ok(await _vendorLogic.LoginAsync(model));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]VendorCreateInputModel model)
        {
            await _vendorLogic.CreateAsync(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VendorUpdateInputModel model)
        {
            await _vendorLogic.UpdateAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _vendorLogic.DeleteAsync(id);
            return Ok();
        }
    }
}