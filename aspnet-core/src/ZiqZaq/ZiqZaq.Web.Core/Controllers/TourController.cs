using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZiqZaq.Logic.Infrastructure;
using ZiqZaq.Shared.Models.RequestInputModels;

namespace ZiqZaq.Web.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourLogic _tourLogic;

        public TourController(ITourLogic tourLogic)
        {
            _tourLogic = tourLogic;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _tourLogic.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TourCreateInputModel model)
        {
            await _tourLogic.CreateAsync(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TourUpdateInputModel model)
        {
            await _tourLogic.UpdateAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tourLogic.DeleteAsync(id);
            return Ok();
        }
    }
}