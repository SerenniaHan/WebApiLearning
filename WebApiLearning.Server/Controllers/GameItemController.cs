using Microsoft.AspNetCore.Mvc;
using WebApiLearning.Dtos;
using WebApiLearning.Server.Mappers;
using WebApiLearning.Server.Repositories;

namespace WebApiLearning.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class GameItemsController(IGameItemsRepository repository) : ControllerBase
{
    // GET /items
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameItemDto>>> GetItemsAsync()
    {
        return Ok((await repository.GetItemsAsync().ConfigureAwait(false)).Select(x => x.ToDto()));
    }
    
    // GET /items/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GameItemDto>> GetItemAsync(Guid id)
    {
        var item = await repository.GetItemAsync(id.ToString());
        if (item is null)
        {
            return NotFound();
        }

        return Ok(item.ToDto());
    }
    
    // POST /items
    [HttpPost]
    public async Task<ActionResult> CreateItemAsync(CreateGameItemDto itemDto)
    {
        var gameItem = itemDto.FromDto();
        await repository.CreateItemAsync(gameItem).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetItemAsync), new { id = gameItem.Id }, itemDto);
    }
    
    // PUT /items/{id}
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateGameItemDto itemDto)
    {
        var existingItem = await repository.GetItemAsync(id.ToString());
        if (existingItem is null)
        {
            return NotFound();
        }

        var gameItem = existingItem with
        {
            Name = itemDto.Name,
            Price = itemDto.Price
        };
        await repository.UpdateItemAsync(gameItem).ConfigureAwait(false);
        return NoContent();
    }
    
    // DELETE /items/{id}
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteItemAsync(Guid id)
    {
        var existingItem = await repository.GetItemAsync(id.ToString());
        if (existingItem is null)
        {
            return NotFound();
        }

        await repository.DeleteItemAsync(id.ToString()).ConfigureAwait(false);
        return NoContent();
    }
}