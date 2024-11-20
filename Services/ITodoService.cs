using TodoApplikasjonAPIDelTo;

namespace TodoApplikasjonAPIDelTo.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetTodosAsync();
        Task<Todo> GetTodoByIdAsync(int id);
        Task<Todo> CreateTodoAsync(Todo todo);
        Task<bool> UpdateTodoAsync(int id, Todo todo);
        Task<bool> DeleteTodoAsync(int id);
    }



}
