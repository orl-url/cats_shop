using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Services;

namespace server.Controllers;


[Authorize]
[EnableCors]
[ApiController]
[Route("[controller]")]
public class ShoppingController(ShoppingService shoppingService) : ControllerBase
{

    [HttpPost("/buyAll/{userId:length(24)}")]
    public async Task<int?> BuyAllCartItems(string userId)
    {
       var balance =  await shoppingService.BuyAllCartItems(userId);
        return balance;
    }
    
    
    
}