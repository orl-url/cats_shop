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
public class UserCartController(UserCartService userCartService) : ControllerBase
{
    [HttpGet("{userId:length(24)}")]
    public async Task<List<Card>> GetCart(string userId)
    {
        var userCart = await userCartService.GetCardsByUserId(userId);

        return userCart;
    }


    [HttpPut("{userId:length(24)}/{cardId:length(24)}")]
    public async Task<Card> AddToCart(string userId, string cardId)
    {
        var card = await userCartService.AddToCart(userId, cardId);

        return card;
    }


    [HttpDelete("{userId:length(24)}/{cardId:length(24)}")]
    public async Task<Card?> DeleteFromCart(string userId, string cardId)
    {
        var card = await userCartService.RemoveFromCart(userId, cardId);
    
        return card;
    }

    [HttpDelete("{userId:length(24)}")]
    public async Task ClearCart(string userId)
    {
      await userCartService.ClearCart(userId);
    }
}