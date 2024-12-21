using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Car.Queries.GetAllCars;
using Application.Features.Car.Queries.GetCar;
using WebAPI.Entities.Car;
using Application.Features.Car.Commands.UpdateCar;
using Application.Features.Car.Commands.DeleteCar;
using Application.Features.Car.Commands.CreateCar;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers;

[Route("api/Shops/{shopId}/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ISender _sender;

    public CarsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetCars(int shopId)
    {
        var query = new GetAllCarsQuery(shopId);
        var response = await _sender.Send(query);
        return Ok(response);
    }

    [HttpGet("{carId}")]
    public async Task<IActionResult> GetCar(int shopId, int carId)
    {
        var query = new GetCarQuery(shopId, carId);
        var response = await _sender.Send(query);
        return Ok(response);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PostCar(int shopId, CreateCarRequest createCarRequest)
    {
        if (shopId != createCarRequest.ShopId)
        {
            return BadRequest();
        }

        var command = new CreateCarCommand(
            createCarRequest.FirstRegistration,
            createCarRequest.Mileage,
            createCarRequest.Engine,
            createCarRequest.Power,
            createCarRequest.BodyTypeId,
            createCarRequest.FuelTypeId,
            createCarRequest.GearboxTypeId,
            createCarRequest.ModelId,
            createCarRequest.ShopId,
            User);

        var response = await _sender.Send(command);

        return CreatedAtAction("GetCar", new { shopId, carId = response.Id }, response);
    }

    [HttpPut("{carId}")]
    [Authorize]
    public async Task<IActionResult> PutCar(int shopId, int carId, UpdateCarRequest updateCarRequest)
    {
        if (shopId != updateCarRequest.ShopId || carId != updateCarRequest.Id)
        {
            return BadRequest();
        }

        var command = new UpdateCarCommand(
            updateCarRequest.Id,
            updateCarRequest.FirstRegistration,
            updateCarRequest.Mileage,
            updateCarRequest.Engine,
            updateCarRequest.Power,
            updateCarRequest.BodyTypeId,
            updateCarRequest.FuelTypeId,
            updateCarRequest.GearboxTypeId,
            updateCarRequest.ModelId,
            updateCarRequest.ShopId,
            User);

        var response = await _sender.Send(command);

        return Ok(response);
    }

    // DELETE: api/shops/{shopId}/Cars/5
    [HttpDelete("{carId}")]
    [Authorize]
    public async Task<IActionResult> DeleteCar(int shopId, int carId)
    {
        var command = new DeleteCarCommand(shopId, carId, User);
        await _sender.Send(command);
        return NoContent();
    }
}
