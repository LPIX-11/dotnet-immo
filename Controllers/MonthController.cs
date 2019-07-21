using Immovable.Models;
using Immovable.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Immovable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthController : ControllerBase
    {
        private MonthService _monthService;

        public MonthController(MonthService monthService)
        {
            _monthService = monthService;
        }

        [HttpGet]
        public ActionResult<List<Month>> Get() => _monthService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Month> Getmonth(string id)
        {
            var month = _monthService.Get(id);

            return (month == null) ? null : month;
        }


        [HttpPost]
        public ActionResult<Month> Create(Month month)
        {
            _monthService.Create(month);

            return month;
        }

        [HttpPatch("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] Month monthIn)
        {
            var month = _monthService.Get(id);

            if (month == null)
            {
                return NotFound();
            }

            _monthService.Update(id, monthIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var month = _monthService.Get(id);

            if (month == null)
            {
                return NotFound();
            }

            _monthService.Remove(month.monthId);

            return NoContent();
        }
    }
}