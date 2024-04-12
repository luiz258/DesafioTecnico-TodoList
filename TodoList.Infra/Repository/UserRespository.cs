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
    public class UserRespository : IUserRepository
    {
        private readonly TodoListDbContext context;

        public UserRespository(TodoListDbContext context)
        {
            this.context = context;
        }

        public async Task<User> Authenticate(string userName, string password)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
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

        public async Task Edit(User user)
        {
            context.Set<User>().Update(user);
            context.SaveChanges();
        }

        public async Task<User> GetUser(Guid id) => await context.Users.FirstOrDefaultAsync(_ => _.Id == id);

        public async Task Salve(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
