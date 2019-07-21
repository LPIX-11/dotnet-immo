using Immovable.Models;
using Immovable.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Immovable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearController : ControllerBase
    {
        private YearService _yearService;

        public YearController(YearService yearService)
        {
            _yearService = yearService;
        }

        [HttpGet]
        public ActionResult<List<Year>> Get() => _yearService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Year> Getyear(string id)
        {
            var year = _yearService.Get(id);

            return (year == null) ? null : year;
        }


        [HttpPost]
        public ActionResult<Year> Create(Year year)
        {
            _yearService.Create(year);

            return year;
        }

        [HttpPatch("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] Year yearIn)
        {
            var year = _yearService.Get(id);

            if (year == null)
            {
                return NotFound();
            }

            _yearService.Update(id, yearIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var year = _yearService.Get(id);

            if (year == null)
            {
                return NotFound();
            }

            _yearService.Remove(year.yearId);

            return NoContent();
        }
    }
}