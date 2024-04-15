using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoContext.Entities;

namespace TodoList.Domain.ToDoContext.Repositories
{
    public interface ITodoRepository
    {
        Task Salve(Todo todo);
        Task Edit(Todo todo);
        bool Delete(Guid id);
        Task<Todo> GetToDoById(Guid id);

        Task<IEnumerable<Todo>> GetAllToDoPerUser(Guid idUser, int page);
    }
}
