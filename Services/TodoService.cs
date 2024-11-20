using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApplikasjonAPIDelTo.Services
{
    public class TodoService : ITodoService
    {
        // Initial list of todos
        private static List<Todo> _todos = new List<Todo>
        {
            new Todo { Id = 1, Title = "Schedule dentist appointment", Description = "Call the clinic and book a time for the dental check-up", IsCompleted = false },
            new Todo { Id = 2, Title = "Plan weekend hike", Description = "Research trails and prepare gear for a Saturday hike", IsCompleted = false }
        };

        // Automatically calculate the next ID based on existing todos
        private static int _nextId = _todos.Any() ? _todos.Max(t => t.Id) + 1 : 1;

        // Get all todos
        public async Task<IEnumerable<Todo>> GetTodosAsync() => await Task.FromResult(_todos);
        

        // Get a specific todo by ID
        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            return await Task.FromResult(todo);
        }

        // Create a new todo
        public async Task<Todo> CreateTodoAsync(Todo todo)
        {
            todo.Id = _nextId++;
            _todos.Add(todo);
            return await Task.FromResult(todo);
        }

        // Update an existing todo
        public async Task<bool> UpdateTodoAsync(int id, Todo todo)
        {
            var existingTodo = _todos.FirstOrDefault(t => t.Id == id);
            if (existingTodo == null)
            {
                return false;
            }

            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;
            existingTodo.IsCompleted = todo.IsCompleted;

            return true;
        }

        // Delete a todo by ID
        public async Task<bool> DeleteTodoAsync(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return false;
            }

            _todos.Remove(todo);
            return true;
        }
    }
}
