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
        private YearMonthPaymentService _yearMonthPayments;

        public YearMonthPaymentController(YearMonthPaymentService yearMonthPaymentService)
        {
            _yearMonthPayments = yearMonthPaymentService;
        }

        [HttpGet]
        public ActionResult<List<YearMonthPayment>> Get() => _yearMonthPayments.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<YearMonthPayment> GetYearMonthPayment(string id)
        {
            var property = _yearMonthPayments.Get(id);

            return (property == null) ? null : property;
        }


        [HttpPost]
        public ActionResult<YearMonthPayment> Create(YearMonthPayment yearMonthPayment)
        {
            _yearMonthPayments.Create(yearMonthPayment);

            return yearMonthPayment;
        }

        [HttpPatch("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] YearMonthPayment yearMonthPaymentIn)
        {
            var yearMonthPayment = _yearMonthPayments.Get(id);

            if (yearMonthPayment == null)
            {
                return NotFound();
            }

            _yearMonthPayments.Update(id, yearMonthPaymentIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var yearMonthPayment = _yearMonthPayments.Get(id);

            if (yearMonthPayment == null)
            {
                return NotFound();
            }

            _yearMonthPayments.Remove(yearMonthPayment.yearMonthPaymentId);

            return NoContent();
        }
    }
}