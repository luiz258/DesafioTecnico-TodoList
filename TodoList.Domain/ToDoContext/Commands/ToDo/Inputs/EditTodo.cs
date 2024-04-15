using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Shared.ToDoContext.Commands;

namespace TodoList.Domain.ToDoContext.Commands.ToDo.Inputs
{
    public class EditTodo : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreateDate { get; set; }


        public Guid IdUser { get; set; }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
