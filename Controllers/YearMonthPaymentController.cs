using Immovable.Models;
using Immovable.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Immovable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearMonthPaymentController : ControllerBase
    {
        private YearMonthPaymentService _yearMonthPaymentService;

        public YearMonthPaymentController(YearMonthPaymentService yearMonthPaymentService)
        {
            _yearMonthPaymentService = yearMonthPaymentService;
        }

        [HttpGet]
        public ActionResult<List<YearMonthPayment>> Get() => _yearMonthPaymentService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<YearMonthPayment> GetyearMonthPayment(string id)
        {
            var yearMonthPayment = _yearMonthPaymentService.Get(id);

            return (yearMonthPayment == null) ? null : yearMonthPayment;
        }


        [HttpPost]
        public ActionResult<YearMonthPayment> Create(YearMonthPayment yearMonthPayment)
        {
            _yearMonthPaymentService.Create(yearMonthPayment);

            return yearMonthPayment;
        }

        [HttpPatch("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] YearMonthPayment yearMonthPaymentIn)
        {
            var yearMonthPayment = _yearMonthPaymentService.Get(id);

            if (yearMonthPayment == null)
            {
                return NotFound();
            }

            _yearMonthPaymentService.Update(id, yearMonthPaymentIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var yearMonthPayment = _yearMonthPaymentService.Get(id);

            if (yearMonthPayment == null)
            {
                return NotFound();
            }

            _yearMonthPaymentService.Remove(yearMonthPayment.yearMonthPaymentId);

            return NoContent();
        }
    }
}