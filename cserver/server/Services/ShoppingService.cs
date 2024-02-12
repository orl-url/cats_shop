namespace server.Services;

public class ShoppingService(
    UserBalanceService userBalanceService,
    UserCartService userCartService,
    UserPurchasesService userPurchasesService)
{
    public async Task<int?> BuyAllCartItems(string userId)
    {
        var cartItemsSum = await userCartService.GetCartItemsSum(userId);
        var userCanBuyCartItems = await CheckMoneySufficiency(userId, cartItemsSum);
        if (!userCanBuyCartItems)
        {
            return null;
        }
        var decreasedBalance = await userBalanceService.DecreaseBalance(userId, cartItemsSum);

        if (decreasedBalance == null)
        {
            return null;
        }

        var userCart = await userCartService.GetByUserIdAsync(userId);
        await userPurchasesService.AddToPurchasesAsync(userId, userCart!.Content);
        await userCartService.ClearCart(userId);

        return decreasedBalance;
    }

    private async Task<bool> CheckMoneySufficiency(string userId, decimal neededValue)
    {
        var userBalance = await userBalanceService.GetUserBalanceByUserId(userId);

        return (userBalance > neededValue);
    }
}