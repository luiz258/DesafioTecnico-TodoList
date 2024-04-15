

using TodoList.Shared.ToDoContext.Commands;

namespace TodoList.Domain.ToDoContext.Commands.ToDo.Inputs
{
    public class UpdateStatusTodo : ICommand
    {
        public Guid IdTodo { get; set; }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
