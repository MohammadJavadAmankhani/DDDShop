using DDDShop.Application.BillingOrders.Commands.MarkOrderAsPaid;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace DDDShop.API.Controllers;

[ApiController]
[Route("api/billing")]
public class BillingController : ControllerBase
{
    private readonly IMediator _mediator;

    public BillingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{orderId}/pay")]
    public async Task<IActionResult> Pay(Guid orderId)
    {
        await _mediator.Send(new MarkOrderAsPaidCommand(orderId));
        return NoContent();
    }
}
