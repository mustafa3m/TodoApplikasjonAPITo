using Microsoft.AspNetCore.Mvc;
using TodoApplikasjonAPIDelTo.Services;

namespace TodoApplikasjonAPIDelTo.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            var todos = await _todoService.GetTodosAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodoById(int id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo([FromBody] Todo newTodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTodo = await _todoService.CreateTodoAsync(newTodo);
            return CreatedAtAction(nameof(GetTodoById), new { id = createdTodo.Id }, createdTodo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTodo(int id, [FromBody] Todo updatedTodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _todoService.UpdateTodoAsync(id, updatedTodo);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            var result = await _todoService.DeleteTodoAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
