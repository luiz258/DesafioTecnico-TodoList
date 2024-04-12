using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Shared.ToDoContext.Commands;

namespace TodoList.Domain.ToDoContext.Commands.ToDo.Inputs
{
    public class DeleteTodo : ICommand
    {
        public Guid Id { get; set; }

        public Guid IdUser { get; set; }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
