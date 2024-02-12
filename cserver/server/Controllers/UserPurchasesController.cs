using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers;



[Authorize]
[EnableCors]
[ApiController]
[Route("[controller]")]
public class UserPurchasesController(UserPurchasesService userPurchasesService) : ControllerBase
{
    [HttpGet("{userId:length(24)}")]
    public async Task<List<Card>?> GetUserPurchases(string? userId)
    {
        if (userId == null)
        {
            return null;
        }

        return await userPurchasesService.GetCardsInPurchasesByUserId(userId);
    }
    

    [HttpPut("{userId:length(24)}")]
    public async Task<List<Card>?> AddToPurchases(string userId, List<string> cardsId)
    {
        return await userPurchasesService.AddToPurchasesAsync(userId, cardsId);
    }
}
