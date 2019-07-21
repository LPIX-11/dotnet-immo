using Immovable.Models;
using Immovable.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Immovable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private PaymentTypeService _paymentTypeService;

        public PaymentTypeController(PaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        [HttpGet]
        public ActionResult<List<PaymentType>> Get() => _paymentTypeService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<PaymentType> GetpaymentType(string id)
        {
            var paymentType = _paymentTypeService.Get(id);

            return (paymentType == null) ? null : paymentType;
        }


        [HttpPost]
        public ActionResult<PaymentType> Create(PaymentType paymentType)
        {
            _paymentTypeService.Create(paymentType);

            return paymentType;
        }

        [HttpPatch("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] PaymentType paymentTypeIn)
        {
            var paymentType = _paymentTypeService.Get(id);

            if (paymentType == null)
            {
                return NotFound();
            }

            _paymentTypeService.Update(id, paymentTypeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var paymentType = _paymentTypeService.Get(id);

            if (paymentType == null)
            {
                return NotFound();
            }

            _paymentTypeService.Remove(paymentType.paymentTypeId);

            return NoContent();
        }
    }
}