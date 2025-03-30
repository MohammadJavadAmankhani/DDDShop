using DDDShop.Application.Orders.Commands.CreateOrder;
using DDDShop.Application.Orders.Commands.AddItemToOrder;
using DDDShop.Application.Orders.Commands.ChangeShippingAddress;
using DDDShop.Application.Orders.Commands.PlaceOrder;
using DDDShop.API.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace DDDShop.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
    {
        var orderId = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = orderId }, new { id = orderId });
    }

    [HttpPost("{id}/items")]
    public async Task<IActionResult> AddItem(Guid id, [FromBody] AddItemToOrderDto dto)
    {
        var command = new AddItemToOrderCommand(id, dto.ProductId, dto.Name, dto.UnitPrice, dto.Quantity);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id}/address")]
    public async Task<IActionResult> ChangeAddress(Guid id, [FromBody] ChangeShippingAddressDto dto)
    {
        var command = new ChangeShippingAddressCommand(id, dto.Street, dto.City, dto.PostalCode, dto.Country);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("{id}/place")]
    public async Task<IActionResult> Place(Guid id)
    {
        await _mediator.Send(new PlaceOrderCommand(id));
        return NoContent();
    }

    // Dummy Get for testing CreatedAtAction
    [HttpGet("{id}")]
    public IActionResult Get(Guid id) => Ok(new { id });
}
