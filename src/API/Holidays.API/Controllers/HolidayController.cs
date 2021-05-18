using Holidays.Services.DTO;
using Holidays.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Holidays.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(HolidayDTO holidayDTO)
        {
            if (holidayDTO == null) return BadRequest(new ArgumentNullException());

            var holidayCreated = await _holidayAppService.CreateHoliday(holidayDTO);
            return CreatedAtAction(nameof(Get), new { holidayCreated.Id }, holidayDTO);
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HolidayDTO>> Get(int id)
        {
            var holiday = await _holidayAppService.GetHoliday(id);

            if (holiday == null) return NotFound();
            return Ok(holiday);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<HolidayDTO>>> GetAll()
        {
            return Ok(await _holidayAppService.GetAllHolidays());
        }

        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, HolidayUpdateDTO holidayDTO)
        {
            var exists = await _holidayAppService.ExistsHoliday(id);

            if (exists)
            {
                await _holidayAppService.UpdateHoliday(id, holidayDTO);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _holidayAppService.ExistsHoliday(id);

            if (exists)
            {
                await _holidayAppService.DeleteHoliday(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
