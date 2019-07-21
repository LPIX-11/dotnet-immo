using Immovable.Models;
using Immovable.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Immovable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessorController : ControllerBase
    {
        private LessorService _lessorService;
        public LessorController(LessorService lessorService)
        {
            _lessorService = lessorService;
        }

        [HttpGet]
        public ActionResult<List<Lessor>> Get() => _lessorService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Lessor> GetLessor(string id)
        {
            var lessor = _lessorService.Get(id);

            return (lessor == null) ? null : lessor;
        }


        [HttpPost]
        public ActionResult<Lessor> Create(Lessor lessor)
        {
            _lessorService.Create(lessor);

            return lessor;
            //CreatedAtRoute("GetLessor", new { id = lessor.lessorId.ToString() }, lessor);
        }

        [HttpPatch("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] Lessor lessorIn)
        {
            var lessor = _lessorService.Get(id);

            if (lessor == null)
            {
                return NotFound();
            }

            _lessorService.Update(id, lessorIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var lessor = _lessorService.Get(id);

            if (lessor == null)
            {
                return NotFound();
            }

            _lessorService.Remove(lessor.lessorId);

            return NoContent();
        }
    }
}