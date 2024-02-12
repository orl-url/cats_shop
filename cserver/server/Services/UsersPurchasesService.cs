using Microsoft.Extensions.Options;
using server.Models;

namespace server.Services;

public class UserPurchasesService(
    IOptions<CatsStoreDatabaseSettings> catsStoreDatabaseSettings,
    CardsService cardsService)
    : CRUDService<UserPurchases>(catsStoreDatabaseSettings, "UserPurchases")
{
    public async Task CreateAsync(User newUser)
    {
        var userPurchases = new UserPurchases()
        {
            UserId = newUser.UserId!,
        };
        await base.CreateAsync(userPurchases);
    }

    public async Task<List<Card>> GetCardsInPurchasesByUserId(string userId)
    {
        var purchases = await GetByUserIdAsync(userId);
        var purchasesId = purchases?.Content;
        var purchaseCards = await cardsService.GetCardsById(purchasesId!);
        
        return purchaseCards;
    }

        


    public async Task<List<Card>?> AddToPurchasesAsync(string userId, List<string> cardsId)
    {
        var purchases = await GetByUserIdAsync(userId);
        purchases?.Content.AddRange(cardsId);
        await UpdateAsync(purchases, userId);
        var addedCards =  await cardsService.GetCardsById(cardsId);

        return addedCards;
    }
}