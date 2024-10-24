using BackPredio11.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackPredio11.Service.Interfaces;

public interface IItemService
{
    Task<ActionResult<IEnumerable<Item>>> GetItens();
    Task<ActionResult<Item>> GetItem(long id);
    Task<ActionResult<Item>> PostItem(Item item);
    Task<IActionResult> PutItem(long id, Item item);
    Task<IActionResult> DeleteItem(long id);
}