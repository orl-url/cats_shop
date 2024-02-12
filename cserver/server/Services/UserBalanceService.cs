using Microsoft.Extensions.Options;
using server.Models;

namespace server.Services;

public class UserBalanceService(
    IOptions<CatsStoreDatabaseSettings> catsStoreDatabaseSettings)
    : CRUDService<UserBalance>(catsStoreDatabaseSettings, "UserBalance")
{
    public async Task CreateAsync(User newUser)
    {
        var userBalance = new UserBalance()
        {
            UserId = newUser.UserId!,
        };
        await base.CreateAsync(userBalance);
    }

    public async Task<int?> GetUserBalanceByUserId(string userId)
    {
        var balance = await GetByUserIdAsync(userId);
        var balanceValue = balance?.Balance;

        return balanceValue;
    }

  

    public async Task<int?> IncreaseBalance(string userId, int value)
    {
        var balance = await GetByUserIdAsync(userId);
        
        balance!.Balance += value;
        await UpdateAsync(balance, userId);
        return  balance.Balance;
    }
    
    
    public async Task<int?> DecreaseBalance(string userId, int value)
    {
        var balance = await GetByUserIdAsync(userId);
        
        if (value > balance?.Balance)
        {
            return null;
        }
        balance!.Balance -= value;
        await UpdateAsync(balance, userId);
        return balance.Balance;
    }
}