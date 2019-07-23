using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

Web API handles serialization for you, so you do not need to call JsonConvert.SerializeObject.That is why you are getting an escaped string as your output value.Just pass the datatable directly to CreateResponse.Web API will turn it into JSON or XML for you depending on what was sent in the Accept header of the request. (It uses Json.Net under the covers.)

return Request.CreateResponse(HttpStatusCode.OK, dt);

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpsController : ControllerBase
    {
        private readonly TodoContext _context;
        private DataTable<ToDoItem> tbl;

        public EmpsController(TodoContext context)
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

    }
}
