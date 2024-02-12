using Microsoft.Extensions.Options;
using server.Models;

namespace server.Services;

public class CardsService(
    IOptions<CatsStoreDatabaseSettings> catsStoreDatabaseSettings)
    : CRUDService<Card>(catsStoreDatabaseSettings, "Cards")
{
    public new async Task CreateAsync(Card newCard)
    {
        await base.CreateAsync(newCard);
    }

    public async Task<List<Card>> GetCardsById(List<string> cardsId)
    {
        var cards = new List<Card>();
        
        foreach (var cardId in cardsId)
        {
            var card = await GetByIdAsync(cardId);
            cards.Add(card!);
        }

        return cards;
    }

    public async Task<Card?> GetCardById(string cardId)
    {
        return await GetByIdAsync(cardId);
    }
}