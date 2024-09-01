using Ecommerce.Presentation.Helpers;
using Ecommerce.Service.Contracts;
using Ecommerce.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentation.Controllers;

[Route("api/orders")]
[ApiController]

public class OrderController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    public OrderController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpGet]
    public async Task<IActionResult> CreateOrder([FromBody] List<CartItem> cartItems)
    {
        var UserId = UserHelpers.GetUserId(User);
        var order = await _serviceManager.OrderService.CreateOrderAsync(cartItems);
        return Ok(new { order });
    }
}