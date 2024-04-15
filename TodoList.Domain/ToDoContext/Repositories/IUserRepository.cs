﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoContext.Entities;

namespace TodoList.Domain.ToDoContext.Repositories
{
    public interface IUserRepository
    {
        Task Save(User user);
        Task Edit(User user);
        bool Delete(Guid id);
        Task<User> GetUser(Guid id);
        Task<bool> SearchforUserName(string username);

        Task<User> Authenticate(string userName, string password);
    }
}
