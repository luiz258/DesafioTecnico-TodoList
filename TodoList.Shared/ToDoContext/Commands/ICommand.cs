using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Shared.ToDoContext.Commands
{
    public interface ICommand
    {
        bool IsValid();
    }
}
