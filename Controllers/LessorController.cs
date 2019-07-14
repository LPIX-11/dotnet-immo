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

        [HttpPost]
        public ActionResult<Lessor> Create(Lessor lessor)
        {
            _lessorService.Create(lessor);

            return CreatedAtRoute("GetLessor", new { id = lessor.lessorId.ToString() }, lessor);
        }
    }
}