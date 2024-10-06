using Microsoft.AspNetCore.Mvc;
   using Microsoft.EntityFrameworkCore;

   [ApiController]
   [Route("api/[controller]")]
   public class TodoController : ControllerBase
   {
       private readonly TodoContext _context;

       public TodoController(TodoContext context)
       {
           _context = context;
       }

       [HttpGet]
       public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
       {
            Console.WriteLine("get hit");
           return await _context.TodoItems.ToListAsync();
       }

       [HttpPost]
       public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
       {
           _context.TodoItems.Add(todoItem);
           await _context.SaveChangesAsync();
           return CreatedAtAction(nameof(GetTodoItems), new { id = todoItem.Id }, todoItem);
       }

       [HttpPut("{id}")]
       public async Task<IActionResult> PutTodoItem(int id, TodoItem todoItem)
       {
           if (id != todoItem.Id) return BadRequest();
           _context.Entry(todoItem).State = EntityState.Modified;
           await _context.SaveChangesAsync();
           return NoContent();
       }

       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteTodoItem(int id)
       {
           var todoItem = await _context.TodoItems.FindAsync(id);
           if (todoItem == null) return NotFound();
           _context.TodoItems.Remove(todoItem);
           await _context.SaveChangesAsync();
           return NoContent();
       }
   }