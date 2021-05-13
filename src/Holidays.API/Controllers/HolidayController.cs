using Holidays.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Holidays.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayAppService _holidayAppService;

        public HolidayController(IHolidayAppService holidayAppService)
        {
            _holidayAppService = holidayAppService;
        }

        [HttpGet]
        [Route("LoadHolidays")]
        public async Task<IActionResult> LoadHolidays()
        {
            await _holidayAppService.LoadHolidays();

            return Ok();
        }
    }
}
