using Immovable.Models;
using Immovable.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Immovable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private PictureService _pictureService;

        public PictureController(PictureService PictureService)
        {
            _pictureService = PictureService;
        }

        [HttpGet]
        public ActionResult<List<Picture>> Get() => _pictureService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Picture> GetPicture(string id)
        {
            var picture = _pictureService.Get(id);

            return (picture == null) ? null : picture;
        }


        [HttpPost]
        public ActionResult<Picture> Create(Picture picture)
        {
            _pictureService.Create(picture);

            return picture;
        }

        [HttpPatch("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody] Picture pictureIn)
        {
            var picture = _pictureService.Get(id);

            if (picture == null)
            {
                return NotFound();
            }

            _pictureService.Update(id, pictureIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var picture = _pictureService.Get(id);

            if (picture == null)
            {
                return NotFound();
            }

            _pictureService.Remove(picture.pictureId);

            return NoContent();
        }
    }
}