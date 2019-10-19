using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.ToDoItems.Count() == 0)
            {
                _context.ToDoItems.Add(new ToDoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetTodoItems()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.ToDoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpGet("count")]
        public ActionResult<int> GetCount()
        {
            var x = 0;
            var n = 3 / x;
            return 4;
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostTodoItem(ToDoItem item)
        {
            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoItem), new { id = item.id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, ToDoItem item)
        {
            if (id != item.id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.ToDoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.ToDoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
