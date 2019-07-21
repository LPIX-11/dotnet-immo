using Immovable.Models;
using Immovable.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Immovable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get() => _customerService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Customer> Getcustomer(string id)
        {
            var customer = _customerService.Get(id);

            return (customer == null) ? null : customer;
        }


        [HttpPost]
        public ActionResult<Customer> Create(Customer customer)
        {
            _customerService.Create(customer);

            return customer;
        }

        [HttpPatch("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] Customer customerIn)
        {
            var customer = _customerService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            _customerService.Update(id, customerIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var customer = _customerService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            _customerService.Remove(customer.customerId);

            return NoContent();
        }
    }
}