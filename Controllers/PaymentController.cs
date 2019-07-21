using Immovable.Models;
using Immovable.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Immovable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public ActionResult<List<Payment>> Get() => _paymentService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Payment> Getpayment(string id)
        {
            var payment = _paymentService.Get(id);

            return (payment == null) ? null : payment;
        }


        [HttpPost]
        public ActionResult<Payment> Create(Payment payment)
        {
            _paymentService.Create(payment);

            return payment;
        }

        [HttpPatch("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] Payment paymentIn)
        {
            var payment = _paymentService.Get(id);

            if (payment == null)
            {
                return NotFound();
            }

            _paymentService.Update(id, paymentIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var payment = _paymentService.Get(id);

            if (payment == null)
            {
                return NotFound();
            }

            _paymentService.Remove(payment.paymentId);

            return NoContent();
        }
    }
}