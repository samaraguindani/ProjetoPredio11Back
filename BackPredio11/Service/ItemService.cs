using BackPredio11.Entities;
using BackPredio11.Repository;
using BackPredio11.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackPredio11.Service;

public class ItemService : IItemService
{
    private readonly ItemRepository _repository;

    public ItemService(ItemRepository repository)
    {
        _repository = repository;
    }
    public async Task<ActionResult<IEnumerable<Item>>> GetItens()
    {
        return await _repository.GetItens();
    }

    public async Task<ActionResult<Item>> GetItem(long id)
    {
        return await _repository.GetItem(id);
    }

    public Task<ActionResult<Item>> PostItem(Item item)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> PutItem(long id, Item item)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> DeleteItem(long id)
    {
        throw new NotImplementedException();
    }
}