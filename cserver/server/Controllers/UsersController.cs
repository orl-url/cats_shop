using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers;

[EnableCors]
[ApiController]
[Route("[controller]")]
public class UsersController(UsersService usersService) : ControllerBase
{
    [HttpGet]
    public async Task<List<User>> Get() =>
        await usersService.GetAsync();
    
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var user = await usersService.GetByIdAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        return user;
    }

    

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, User updatedUser)
    {
        var user = await usersService.GetByIdAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        updatedUser.UserId = user.UserId;

        await usersService.UpdateAsync(updatedUser, id);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await usersService.GetByIdAsync(id);

        if (user is null)
        {
            return NotFound();
        }

        await usersService.DeleteByIdAsync(id);

        return NoContent();
    }
}