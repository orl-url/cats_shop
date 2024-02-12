using Microsoft.Extensions.Options;
using server.Models;

namespace server.Services;

public class UserCartService(
    IOptions<CatsStoreDatabaseSettings> catsStoreDatabaseSettings,
    CardsService cardsService)
    : CRUDService<UserCart>(catsStoreDatabaseSettings, "UserCart")
{
    public async Task CreateAsync(User newUser)
    {
        var userCart = new UserCart()
        {
            UserId = newUser.UserId!,
        };
        await base.CreateAsync(userCart);
    }

    public async Task<List<Card>> GetCardsByUserId(string? userId)
    {
        var cart = await GetByUserIdAsync(userId);
        var cardsId = cart?.Content;
        var cards = new List<Card>();

        foreach (var cardId in cardsId)
        {
            var card = await cardsService.GetByIdAsync(cardId);
            if (card != null)
            {
                cards.Add(card);
            }
        }
        return cards;
    }



    public async Task<Card> AddToCart(string userId, string cardId)
    {
        var cart = await GetByUserIdAsync(userId);
        cart?.Content.Add(cardId);
        await UpdateAsync(cart, userId);
        var card = await cardsService.GetByIdAsync(cardId);

        return card!;
    }


    public async Task<Card?> RemoveFromCart(string userId, string cardId)
    {
        var cart = await GetByUserIdAsync(userId);
        cart?.Content.Remove(cardId);
        await UpdateAsync(cart, userId);
        var card = await cardsService.GetCardById(cardId);
        return card;
    }

    public async Task<UserCart?> ClearCart(string userId)
    {
        var cart = await GetByUserIdAsync(userId);
        if (cart == null)
        {
            return null;
        }

        cart.Content.Clear();
        await UpdateAsync(cart, userId);
        return cart;
    }

    public async Task<int> GetCartItemsSum(string userId)
    {
        var cards = await GetCardsByUserId(userId);
        var sum = cards.Sum(card => card.Price);
        return sum;
    }
    
}