using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TodoList.Shared.ToDoContext.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<ICommandResult> ManipularAsync(T command);
    }
}
