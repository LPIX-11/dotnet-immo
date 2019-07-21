using Immovable.Models;
using Immovable.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Immovable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearMonthController : ControllerBase
    {
        private YearMonthService _yearMonthService;

        public YearMonthController(YearMonthService yearMonthService)
        {
            _yearMonthService = yearMonthService;
        }

        [HttpGet]
        public ActionResult<List<YearMonth>> Get() => _yearMonthService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<YearMonth> GetyearMonth(string id)
        {
            var yearMonth = _yearMonthService.Get(id);

            return (yearMonth == null) ? null : yearMonth;
        }


        [HttpPost]
        public ActionResult<YearMonth> Create(YearMonth yearMonth)
        {
            _yearMonthService.Create(yearMonth);

            return yearMonth;
        }

        [HttpPatch("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] YearMonth yearMonthIn)
        {
            var yearMonth = _yearMonthService.Get(id);

            if (yearMonth == null)
            {
                return NotFound();
            }

            _yearMonthService.Update(id, yearMonthIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var yearMonth = _yearMonthService.Get(id);

            if (yearMonth == null)
            {
                return NotFound();
            }

            _yearMonthService.Remove(yearMonth.yearMonthId);

            return NoContent();
        }
    }
}