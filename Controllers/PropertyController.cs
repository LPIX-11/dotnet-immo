using Immovable.Models;
using Immovable.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Immovable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private PropertyService _propertyService;

        public PropertyController(PropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public ActionResult<List<Property>> Get() => _propertyService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Property> GetProperty(string id)
        {
            var property = _propertyService.Get(id);

            return (property == null) ? null : property;
        }


        [HttpPost]
        public ActionResult<Property> Create(Property property)
        {
            _propertyService.Create(property);

            return property;
        }

        [HttpPatch("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] Property propertyIn)
        {
            var property = _propertyService.Get(id);

            if (property == null)
            {
                return NotFound();
            }

            _propertyService.Update(id, propertyIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var property = _propertyService.Get(id);

            if (property == null)
            {
                return NotFound();
            }

            _propertyService.Remove(property.propertyId);

            return NoContent();
        }
    }
}