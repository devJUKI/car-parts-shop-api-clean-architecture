using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Application.Features.Shop.Queries.GetShop;
using Application.Features.Shop.Queries.GetAllShops;
using Application.Features.Shop.Commands.CreateShop;
using Application.Features.Shop.Commands.DeleteShop;
using Application.Features.Shop.Commands.UpdateShop;
using WebAPI.Entities.Shop;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShopsController : ControllerBase
{
    private readonly ISender _sender;

    public ShopsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetShops()
    {
        var query = new GetAllShopsQuery();
        var response = await _sender.Send(query);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetShop(int id)
    {
        var query = new GetShopQuery(id);
        var response = await _sender.Send(query);
        return Ok(response);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PostShop(CreateShopRequest createShopRequest)
    {
        Guid userId = new(User.FindFirstValue(JwtRegisteredClaimNames.Sub)!);
        var command = new CreateShopCommand(createShopRequest.Name, createShopRequest.Location, userId);
        var response = await _sender.Send(command);
        return CreatedAtAction("GetShop", new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> PutShop(int id, UpdateShopRequest updateShopRequest)
    {
        if (id != updateShopRequest.Id)
        {
            return BadRequest();
        }

        var command = new UpdateShopCommand(updateShopRequest.Id, updateShopRequest.Name, updateShopRequest.Location, User);
        var response = await _sender.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteShop(int id)
    {
        var command = new DeleteShopCommand(id, User);
        await _sender.Send(command);
        return NoContent();
    }
}
