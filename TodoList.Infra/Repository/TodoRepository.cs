using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TodoList.Domain.ToDoContext.Entities;
using TodoList.Domain.ToDoContext.Repositories;
using TodoList.Infra.DataContext;

namespace TodoList.Infra.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoListDbContext context;

        public TodoRepository(TodoListDbContext context)
        {
            this.context = context;
        }
        public bool Delete(Guid id)
        {
            var entity = context.Users.Find(id);
            if (entity != null)
            {
                context.Set<User>().Remove(entity);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task Edit(Todo todo)
        {
            context.Set<Todo>().Update(todo);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Todo>> GetAllToDoPerUser(Guid idUser)
        {
           return await context.Todos.Where(_ => _.IdUser == idUser).ToListAsync<Todo>();
        }

        public async Task<Todo> GetToDoById(Guid id) => await context.Todos.FirstOrDefaultAsync(_ => _.Id == id);


        public async Task Salve(Todo todo)
        {
            await context.Todos.AddAsync(todo);
            await context.SaveChangesAsync();
        }
    }
}
