using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Part.Queries.GetAllParts;
using Application.Features.Part.Queries.GetPart;
using WebAPI.Entities.Part;
using Application.Features.Part.Commands.CreatePart;
using Application.Features.Part.Commands.UpdatePart;
using Application.Features.Part.Commands.DeletePart;

namespace AdsWebsiteAPI.Controllers
{
    [Route("/api/shops/{shopId}/cars/{carId}/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly ISender _sender;

        public PartsController(ISender sender)
        {
            _sender = sender;
        }

        // GET: api/Parts
        [HttpGet]
        public async Task<IActionResult> GetParts(int shopId, int carId)
        {
            var query = new GetAllPartsQuery(shopId, carId);
            var response = await _sender.Send(query);
            return Ok(response);
        }

        // GET: api/Parts/5
        [HttpGet("{partId}")]
        public async Task<IActionResult> GetPart(int shopId, int carId, int partId)
        {
            var query = new GetPartQuery(shopId, carId, partId);
            var response = await _sender.Send(query);
            return Ok(response);
        }

        // POST: api/Parts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostPart(int shopId, int carId, CreatePartRequest createPartRequest)
        {
            if (shopId != createPartRequest.ShopId || carId != createPartRequest.CarId)
            {
                return BadRequest();
            }

            var command = new CreatePartCommand(
                createPartRequest.Name,
                createPartRequest.Price,
                createPartRequest.CarId,
                createPartRequest.ShopId,
                User);
            var response = await _sender.Send(command);

            return CreatedAtAction("GetPart", new { shopId, carId, partId = response.Id }, response);
        }

        // PUT: api/Parts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{partId}")]
        public async Task<IActionResult> PutPart(int shopId, int carId, int partId, UpdatePartRequest updatePartRequest)
        {
            if (shopId != updatePartRequest.ShopId || carId != updatePartRequest.CarId || partId != updatePartRequest.Id)
            {
                return BadRequest();
            }

            var command = new UpdatePartCommand(
                updatePartRequest.Id,
                updatePartRequest.Name,
                updatePartRequest.Price,
                updatePartRequest.CarId,
                updatePartRequest.ShopId,
                User);
            var response = await _sender.Send(command);

            return Ok(response);
        }

        // DELETE: api/Parts/5
        [HttpDelete("{partId}")]
        public async Task<IActionResult> DeletePart(int shopId, int carId, int partId)
        {
            var command = new DeletePartCommand(shopId, carId, partId, User);
            await _sender.Send(command);
            return NoContent();
        }
    }
}
