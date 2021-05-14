using Holidays.Services.DTO;
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
        [Route("InputHolidays")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> InputHolidays()
        {
            await _holidayAppService.InputHolidays();
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<HolidayDTO>>> Get()
        {
            return Ok(await _holidayAppService.GetAllHolidays());
        }
    }
}
