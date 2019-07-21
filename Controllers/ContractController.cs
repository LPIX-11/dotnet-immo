using Immovable.Models;
using Immovable.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Immovable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private ContractService _contractService;

        public ContractController(ContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public ActionResult<List<Contract>> Get() => _contractService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Contract> Getcontract(string id)
        {
            var contract = _contractService.Get(id);

            return (contract == null) ? null : contract;
        }


        [HttpPost]
        public ActionResult<Contract> Create(Contract contract)
        {
            _contractService.Create(contract);

            return contract;
        }

        [HttpPatch("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] Contract contractIn)
        {
            var contract = _contractService.Get(id);

            if (contract == null)
            {
                return NotFound();
            }

            _contractService.Update(id, contractIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var contract = _contractService.Get(id);

            if (contract == null)
            {
                return NotFound();
            }

            _contractService.Remove(contract.contractId);

            return NoContent();
        }
    }
}