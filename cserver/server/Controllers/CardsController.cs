using Microsoft.AspNetCore.Cors;
using server.Services;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers;

[EnableCors]
[ApiController]
[Route("[controller]")]
public class CardsController(CardsService cardsService) : ControllerBase
{
    [HttpGet]
    public async Task<List<Card>> Get() =>
        await cardsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Card>> Get(string id)
    {
        var card = await cardsService.GetByIdAsync(id);

        if (card is null)
        {
            return NotFound();
        }

        return card;
    }

    [HttpPost]
    public async Task <Card> Post(Card newCard)
    {
        await cardsService.CreateAsync(newCard);
        return newCard;
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Card changedCard)
    {
        var card = await cardsService.GetByIdAsync(id);

        if (card is null)
        {
            return NotFound();
        }

        changedCard.Id = card.Id;

        await cardsService.UpdateAsync(changedCard, id);

        return NoContent();
    }

    // [HttpDelete("{id:length(24)}")]
    // public async Task<IActionResult> Delete(string id)
    // {
    //     var book = await cardsService.GetByUserIdAsync(id);
    //
    //     if (book is null)
    //     {
    //         return NotFound();
    //     }
    //
    //     await cardsService.RemoveAsync(id);
    //
    //     return NoContent();
    // }
}