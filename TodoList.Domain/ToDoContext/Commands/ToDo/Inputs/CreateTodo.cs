using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoContext.Entities;
using TodoList.Shared.ToDoContext.Commands;

namespace TodoList.Domain.ToDoContext.Commands.ToDo.Inputs
{
    public class CreateTodo : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public Guid IdUser { get; set; }


        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
