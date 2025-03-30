using DDDShop.Application.ShippingOrders.Commands.UpdateShippingStatus;
using DDDShop.Domain.Aggregates.ShippingOrders.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace DDDShop.API.Controllers;

[ApiController]
[Route("api/shipping")]
public class ShippingController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShippingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{orderId}/status")]
    public async Task<IActionResult> UpdateStatus(Guid orderId, [FromBody] UpdateStatusDto dto)
    {
        var command = new UpdateShippingStatusCommand(orderId, dto.NewStatus);
        await _mediator.Send(command);
        return NoContent();
    }
}

public record UpdateStatusDto(ShippingStatus NewStatus);
