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
public class UserBalanceController(UserBalanceService userBalanceService) : ControllerBase
{

    [HttpGet("{userId:length(24)}")]
    public async Task<decimal?> GetUserBalance(string userId)
    {
        return await userBalanceService.GetUserBalanceByUserId(userId);
    }
    
    // FOR DEPOSIT
    [HttpPut("/increaseBalance/{userId:length(24)}/{value}")]
    public async Task<decimal?> IncreaseBalance(string userId, int value)
    {
       return await userBalanceService.IncreaseBalance(userId, value);
    }   
 
    
}