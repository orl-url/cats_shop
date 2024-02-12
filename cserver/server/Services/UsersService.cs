using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using server.Models;

namespace server.Services;

public class UsersService(
    IOptions<CatsStoreDatabaseSettings> catsStoreDatabaseSettings,
    UserPurchasesService userPurchasesService,
    UserBalanceService userBalanceService,
    UserCartService userCartService)
    : CRUDService<User>(catsStoreDatabaseSettings, "Users")
{
    public async Task<User?> CreateUserAsync(User newUser)
    {
        var user = await GetUserByName(newUser.Name);

        if (user != null)
        {
            return null;
        }
        
        var createdUser = await CreateAsync(newUser);

        await userPurchasesService.CreateAsync(newUser);

        await userBalanceService.CreateAsync(newUser);

        await userCartService.CreateAsync(newUser);

        return createdUser;
    }

    public async Task<User?> GetUserByName(string userName)
    {
        var user = await Collection.Find(x => x.Name == userName).FirstOrDefaultAsync();
        return user;
    }
}