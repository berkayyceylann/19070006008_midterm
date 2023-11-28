using _19070006008_midterm.Models;
using Microsoft.AspNetCore.Mvc;
using _19070006008_midterm.Logic.Abstract;

namespace _19070006008_midterm.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private IHouseManager _houseManager;
        public HouseController(IHouseManager houseManager)
        {
            _houseManager = houseManager;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAvailableHouses([FromQuery] QueryHouseModel model)
        {
            var response = await _houseManager.GetAvailableHouses(model);
            return Ok(response);
        }

        
        [HttpPost, Authorize]
        public async Task<IActionResult> BookHouse([FromBody] BookHouseModel model)
        {
            var response = await _houseManager.BookHouse(model);
            return Ok(response);
        }
    }
}
